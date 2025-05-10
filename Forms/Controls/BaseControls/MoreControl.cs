using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sunny.UI;
using Byte_Harmonic.Models;
using Byte_Harmonic.Utils;
using System.Text.RegularExpressions;

namespace Byte_Harmonic.Forms.Controls.BaseControls
{
    public partial class MoreControl : UserControl
    {
        private BHButton bHButton1;
        private BHButton bHButton2;
        public MoreControl(Point ButtonLocation)
        {
            InitializeComponent();
            InitializeButton();
            this.Location = new Point(ButtonLocation.X - 60, ButtonLocation.Y - 110);
        }
        public void InitializeButton()
        {
            bHButton1 = new BHButton("icons8-scroll-down-96", "icons8-scroll-down-96 (1)", "下载");
            bHButton2 = new BHButton("icons8-圆-96 (2)", "icons8-圆-96 (1)", "添加到");
            bHButton1.Location = new Point(0, 0);
            bHButton2.Location = new Point(0, 51);
            this.Controls.Add(bHButton1);
            this.Controls.Add(bHButton2);

            bHButton2.Click += bHButton2_Click;
            bHButton1.Click += BHButton1_Click;
        }

        private void BHButton1_Click(object? sender, EventArgs e)
        {
            try
            {
                // 获取服务实例
                var songService = AppContext.songlistRepository;
                var config = ConfigManager.Instance;

                // 获取歌曲详细信息
                var song = songService.GetSongById(AppContext._playbackService.GetCurrentSong().Id);
                if (song == null) throw new Exception("歌曲不存在");

                Console.WriteLine($"song 的 MusicFilePath is {song.MusicFilePath}");

                bool IsValidMp3Path(string path)
                {
                    var pattern = @"^[a-zA-Z]:\\(?:[^\\/:*?""<>|\r\n]+\\)*[^\\/:*?""<>|\r\n]+\.mp3$";
                    return Regex.IsMatch(path, pattern, RegexOptions.IgnoreCase);
                }

                if (!IsValidMp3Path(song.MusicFilePath))
                {
                    song.MusicFilePath = FileHelper.GetAssetPath(song.MusicFilePath);

                }

                // 验证本地文件
                if (!File.Exists(song.MusicFilePath))
                    throw new Exception("本地文件不存在，无法下载");

                // 生成文件名
                var fileName = GenerateFileName(song, config.NamingStyle);
                var destPath = Path.Combine(config.DownloadPath, $"{fileName}{Path.GetExtension(song.MusicFilePath)}");

                // 确保目录存在
                Directory.CreateDirectory(Path.GetDirectoryName(destPath));

                // 复制文件
                File.Copy(song.MusicFilePath, destPath, overwrite: true);

                // 更新下载状态
                song.Downloaded = true;
                //songService.UpdateSong(song);
                new Byte_Harmonic.Forms.MainForms.MessageForm("下载成功").ShowDialog();
            }
            catch (Exception ex)
            {
                new Byte_Harmonic.Forms.MainForms.MessageForm($"下载失败：{ex.Message}").ShowDialog();
            }
        }

        private string GenerateFileName(Song song, int namingStyle)
        {
            return namingStyle switch
            {
                0 => song.Title,
                1 => $"{song.Title} - {song.Artist}",
                2 => $"{song.Artist} - {song.Title}",
                _ => song.Title
            };
        }

        private void bHButton2_Click (object sender, EventArgs e)
        {
            Song song;

            try
            {
                song = AppContext._playbackService.GetCurrentSong();
                if (song == null)
                    throw new Exception("请先播放一首歌");
            }
            catch (Exception ex)
            {
                new Byte_Harmonic.Forms.MainForms.MessageForm(ex.Message).ShowDialog();
                return;
            }

            new Byte_Harmonic.Forms.MainForms.AddSongToListForm(song).ShowDialog();
        }
    }
}
