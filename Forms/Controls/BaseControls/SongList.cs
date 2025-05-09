using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Byte_Harmonic.Models;
using Sunny.UI;
using Byte_Harmonic.Forms.MainForms;
using Byte_Harmonic.Services;
using Byte_Harmonic.Utils;

namespace Byte_Harmonic.Forms.Controls.BaseControls
{
    public partial class SongList : UserControl
    {
        private bool selectAll = false;
        private bool enableBulkOp = false;
        public SongList()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.Margin = new Padding(10);
        }

        public void LoadSongs(List<Song> songs)
        {
            flowLayoutPanel.Controls.Clear(); // 清空现有项

            bool isWhite = false; // 初始颜色标记
            Color[] colors = { Color.White, Color.FromArgb(240, 240, 240) }; // 黑白交替色

            for (int i = songs.Count - 1; i >= 0; i--)
            {
                var song = songs[i];

                // 创建SongItem（交替颜色）
                SongItem item = new SongItem(
                    color: colors[isWhite ? 0 : 1],
                    songID: song.Id,
                    songName: song.Title+" —— "+song.Artist
                );

                // 添加到FlowLayoutPanel
                flowLayoutPanel.Controls.Add(item);
                item.BringToFront();
                isWhite = !isWhite; // 切换颜色标记
            }

        }

        private void SelectAllButton_Click(object sender, EventArgs e)
        {
            selectAll = !selectAll;
            if (selectAll)
            {
                foreach (SongItem item in flowLayoutPanel.Controls)
                {
                    item.ChooseAction();
                }
                
            }
            else
            {
                foreach (SongItem item in flowLayoutPanel.Controls)
                {
                    item.NotChooseAction();
                }
            }
        }

        private void PlayAllButton_Click(object sender, EventArgs e)
        {
            //var songs = AppContext._playbackService.GetPlaylist().PlaySongs;
            var songs = new List<Song>();
            var mode = AppContext._playbackService.GetPlaybackMode();
            int n = songs.Count;
            bool notChoosed = true;
            //TODO:播放被选中的第一首歌，item.Selected表示被选中
            foreach (SongItem item in flowLayoutPanel.Controls)
            {
                if (item.Selected)
                {
                    notChoosed = false;
                    songs.Add(AppContext._songRepository.GetSongById(item.songID));
                }
            }
            if (notChoosed) return; // 不修改原来的播放队列
            Console.WriteLine("得到新的播放队列!");
            AppContext._playbackService.SetPlaylist(new Playlist(songs, mode));
            AppContext.TogglePlayPause(); // 从新的位置开始播放
            AppContext.TriggerupdateSongUI(songs[0]);
            AppContext.TriggerShowPlayingBtn(true);
            var lyricsLine = AppContext._playbackService.GetCurrentLyricsLine()?.Text ?? "[No Lyrics]";
            var position = AppContext._playbackService.GetCurrentPosition();

            AppContext.TriggerLyricsUpdated(lyricsLine, position);
        }

        private void StarAllButton_Click(object sender, EventArgs e)
        {
            foreach (SongItem item in flowLayoutPanel.Controls)
            {
                if (item.Selected)
                {
                    //TODO:后端：收藏
                    //TODO:收藏成功后弹窗
                }
            }
        }

        //下载文件
        private void DownloadAllButton_Click(object sender, EventArgs e)
        {
            var config = ConfigManager.Instance;
            var songService = AppContext.songlistRepository;
            var successCount = 0;

            foreach (SongItem item in flowLayoutPanel.Controls)
            {
                if (item.Selected)
                {
                    try
                    {
                        var song = songService.GetSongById(item.songID);
                        if (!File.Exists(song.MusicFilePath)) continue;

                        var fileName = Byte_Harmonic.Utils.FileHelper.GenerateFileName(song, config.NamingStyle);
                        var destPath = Path.Combine(config.DownloadPath, $"{fileName}{Path.GetExtension(song.MusicFilePath)}");

                        File.Copy(song.MusicFilePath, destPath);
                        successCount++;
                    }
                    catch
                    {
                        // 忽略单个失败
                    }
                }
            }

            new MessageForm($"成功下载{successCount}首歌曲").ShowDialog();
        }

        private void AddAllButton_Click(object sender, EventArgs e)
        {
            //TODO:显示添加到的窗口
        }

        private void DeleteAllButton_Click(object sender, EventArgs e)
        {
           
            foreach (SongItem item in flowLayoutPanel.Controls)
            {
                if (item.Selected)
                {
                    //TODO:后端删除
                    int id = item.songID;
                }
            }
            //TODO:显示信息面：删除成功
            this.LoadSongs(AppContext.currentViewingSonglist.Songs);//更新数据
        }

        private void BulkOperateButton_Click(object sender, EventArgs e)
        {
            enableBulkOp = !enableBulkOp;
            if(enableBulkOp)
            {
                foreach (SongItem item in flowLayoutPanel.Controls)
                {
                    item.BulkActions();
                }
                SelectAllButton.Visible = true;
                SelectAllButton.Enabled = true;
                DeleteAllButton.Visible = true;
                DeleteAllButton.Enabled = true;
                AddAllButton.Visible = true;
                AddAllButton.Enabled = true;
                DownloadAllButton.Visible = true;
                DownloadAllButton.Enabled = true;
                StarAllButton.Visible = true;
                StarAllButton.Enabled = true;
                PlayAllButton.Visible = true;
                PlayAllButton.Enabled = true;
            }
            else
            {
                foreach (SongItem item in flowLayoutPanel.Controls)
                {
                    item.CancelBulkActions();
                }
                SelectAllButton.Visible = false;
                SelectAllButton.Enabled = false;
                DeleteAllButton.Visible = false;
                DeleteAllButton.Enabled = false;
                AddAllButton.Visible = false;
                AddAllButton.Enabled = false;
                DownloadAllButton.Visible = false;
                DownloadAllButton.Enabled = false;
                StarAllButton.Visible = false;
                StarAllButton.Enabled = false;
                PlayAllButton.Visible = false;
                PlayAllButton.Enabled = false;
            }
        }
    }
}
