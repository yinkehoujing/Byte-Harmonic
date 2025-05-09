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
using Byte_Harmonic.Forms.FormUtils;
using Byte_Harmonic.Forms.MainForms;
using Byte_Harmonic.Models;
using Byte_Harmonic.Services;
using Byte_Harmonic.Utils;
using System.Text.RegularExpressions;
using Byte_Harmonic.Forms.Controls.FrameControls.MainPanel;
using System.Collections;

namespace Byte_Harmonic.Forms.Controls.BaseControls
{
    public partial class SongItem : UserControl
    {
        private Color color;//背景色
        public int songID;//歌的ID
        private string songName;//歌名
        public bool Selected//被选
        {
            get => uiCheckBox.Checked;
        }

        public SongItem(Color color, int songID, string songName)
        {

            InitializeComponent();

            this.songID = songID;
            this.songName = songName;
            this.color = color;

            InitializeUI();
        }

        private void InitializeUI()
        {
            //// 1. 设置 uiCheckBox (左侧固定位置)
            //uiCheckBox.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom;
            //uiCheckBox.Location = new Point(10, 8);  // 左边距10px

            //// 2. 设置 uiLabel1 (中间拉伸部分)
            //uiLabel1.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            //uiLabel1.Location = new Point(40, 10);  // 从checkbox右侧开始
            //uiLabel1.AutoSize = false;  // 禁止自动调整大小

            //// 3. 设置右侧按钮组 (保持右对齐)
            //int buttonSpacing = 5;  // 按钮间距
            //int buttonRightMargin = 10;  // 右边距

            //playButton.Anchor = AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            //playButton.Location = new Point(Width - buttonRightMargin - 24, 10);

            //downloadButton.Anchor = AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            //downloadButton.Location = new Point(playButton.Left - buttonSpacing - 24, 10);

            //addButton.Anchor = AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            //addButton.Location = new Point(downloadButton.Left - buttonSpacing - 24, 10);

            //deleteButton.Anchor = AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            //deleteButton.Location = new Point(addButton.Left - buttonSpacing - 24, 10);

            //// 4. 处理容器大小变化
            //this.Resize += (sender, e) =>
            //{
            //    // 动态调整标签宽度
            //    uiLabel1.Width = deleteButton.Left - uiLabel1.Left - buttonSpacing;

            //    // 重新定位右侧按钮
            //    playButton.Left = Width - buttonRightMargin - 24;
            //    downloadButton.Left = playButton.Left - buttonSpacing - 24;
            //    addButton.Left = downloadButton.Left - buttonSpacing - 24;
            //    deleteButton.Left = addButton.Left - buttonSpacing - 24;
            //};

            this.BackColor = color;
            uiCheckBox.CheckBoxColor = color;
            uiCheckBox.ReadOnly = true;

            uiLabel1.Text = songName;
        }

        private void deleteButton1_Click(object sender, EventArgs e)
        {
            //TODO：调用删除的后端程序
            try
            {
                var parent = this.Parent;
                while (parent != null && !(parent is Download || parent is PlayList || parent is Favorite))
                {
                    parent = parent.Parent;
                }

                if (parent is Download)
                {
                    // 执行 Download 页面逻辑
                    Console.WriteLine("下载页删除逻辑");
                    AppContext._songRepository.CancelDownload(songID);
                    AppContext.TriggerDownloadUpdated();
                }
                else if (parent is PlayList)
                {
                    List<Song> songs = new List<Song>();
                    foreach(var song in AppContext._playbackService.GetPlaylist().PlaySongs)
                    {
                        if(song.Id != songID)
                        {
                            songs.Add(song);
                        }
                    }
                    AppContext._playbackService.SetPlaylist(new Playlist(songs, AppContext._playbackService.GetPlaybackMode()));
                    // 前端逻辑
                    Console.WriteLine("必须在歌曲暂停时修改播放队列!");
                    AppContext.TriggerPlaylistUpdated();

                }
                else if (parent is Favorite)
                {
                    Console.WriteLine("收藏页删除逻辑");
                }
                else
                {
                    Console.WriteLine("歌单的删除逻辑");
                    try
                    {

                        if (AppContext.currentViewingSonglist != null)
                        {
                            AppContext.songlistService.RemoveSongFromSonglist(AppContext.songlistService.GetSongById(songID), AppContext.currentViewingSonglist);
                            AppContext.TriggerSonglistDetailUpdated(AppContext.currentViewingSonglist.Name);
                        }
                    }
                    catch (Exception ex)
                    {
                        new MessageForm(ex.Message).ShowDialog();
                    }
                }

            }
            catch
            {

            }
        } 

        private void addButton_Click(object sender, EventArgs e)
        {
            //TODO:调用添加到页面
            try
            {
                new AddSongToListForm(AppContext.songlistService.GetSongById(this.songID)).ShowDialog();
            }
            catch(Exception ex)
            {
                new MessageForm(ex.Message).ShowDialog();
            }

        }

        //下载文件
        private void downloadButton_Click(object sender, EventArgs e)
        {
            try
            {
                // 获取服务实例
                var songService = AppContext.songlistRepository;
                var config = ConfigManager.Instance;

                // 获取歌曲详细信息
                var song = songService.GetSongById(this.songID);
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

        private void playButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("playButton clicked!!");
            AppContext.TogglePlayPauseSong(AppContext._songRepository.GetSongById(songID));
            AppContext.TriggerupdateSongUI(AppContext._playbackService.GetCurrentSong());
        }

        //让多选框显示
        public void BulkActions()
        {
            uiCheckBox.CheckBoxColor = MPColor.Blue3;
            uiCheckBox.ReadOnly = false;
            uiCheckBox.Visible = true;
            uiCheckBox.BringToFront();
            Console.WriteLine("bulk");
        }

        //让多选框消失
        public void CancelBulkActions()
        {
            uiCheckBox.CheckBoxColor = color;
            uiCheckBox.ReadOnly = true;
            uiCheckBox.Visible = false;
            Console.WriteLine("notbulk");
        }

        public void ChooseAction()
        {
            uiCheckBox.Checked = true;
        }

        public void NotChooseAction()
        {
            uiCheckBox.Checked = false;
        }

        private void uiLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
