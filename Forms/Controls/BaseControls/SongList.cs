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
using Org.BouncyCastle.Utilities;
using System.Text.RegularExpressions;
using static Sunny.UI.SnowFlakeId;
using Byte_Harmonic.Forms.Controls.FrameControls.MainPanel;

namespace Byte_Harmonic.Forms.Controls.BaseControls
{
    public partial class SongList : UserControl
    {
        private bool selectAll = false;
        private bool enableBulkOp = false;
        private FavoritesService _favoritesService;
        public SongList()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.Margin = new Padding(10);
            this.SizeChanged += Control_SizeChanged;
            _favoritesService = new FavoritesService(AppContext.userRepository);
        }



        public void LoadSongs(List<Song> songs)
        {
            Console.WriteLine("Load Songs");
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
            //播放被选中的第一首歌，item.Selected表示被选中
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
                    //后端：收藏
                    int id = item.songID;

                    try
                    {
                        _favoritesService.AddFavoriteSongAsync(AppContext.currentUser.Account, id);
                    }
                    catch (Exception ex)
                    {
                        new MainForms.MessageForm(ex.Message).ShowDialog();
                    }
                    //收藏成功后弹窗
                    new MainForms.MessageForm("收藏成功").ShowDialog();
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
                        bool IsValidMp3Path(string path)
                        {
                            var pattern = @"^[a-zA-Z]:\\(?:[^\\/:*?""<>|\r\n]+\\)*[^\\/:*?""<>|\r\n]+\.mp3$";
                            return Regex.IsMatch(path, pattern, RegexOptions.IgnoreCase);
                        }
                        if (!IsValidMp3Path(song.MusicFilePath))
                        {
                            song.MusicFilePath = FileHelper.GetAssetPath(song.MusicFilePath);
                        }
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
            List<Song> songs=new List<Song> { };
            foreach (SongItem item in flowLayoutPanel.Controls)
            {
                if (item.Selected)
                {
                    try
                    {
                        var song = AppContext.songlistService.GetSongById(item.songID);
                        songs.Add(song);
                    }
                    catch(Exception ex)
                    {
                        new MainForms.MessageForm(ex.Message).ShowDialog();
                    }
                }
            }
            //显示添加到的窗口
            new MainForms.AddSongToListForm(songs).ShowDialog();
        }

        private void DeleteAllButton_Click(object sender, EventArgs e)
        {
            var toRemoveFromDownload = new List<int>();
            var toRemoveFromPlaylist = new List<int>();
            var toRemoveFromSonglist = new List<int>();
            var toRemoveFromFavorites = new List<int>();

            bool isDownloadPage = false, isPlaylistPage = false, isFavoritePage = false, isSonglistPage = false;

            var parent = this.Parent;
            while (parent != null && !(parent is Download || parent is PlayList || parent is Favorite))
            {
                parent = parent.Parent;
            }

            if (parent is Download) isDownloadPage = true;
            else if (parent is PlayList) isPlaylistPage = true;
            else if (parent is Favorite) isFavoritePage = true;
            else isSonglistPage = true;

            foreach (SongItem item in flowLayoutPanel.Controls)
            {
                if (!item.Selected) continue;

                int songID = item.songID;

                if (isDownloadPage)
                {
                    toRemoveFromDownload.Add(songID);
                }
                else if (isPlaylistPage)
                {
                    toRemoveFromPlaylist.Add(songID);
                }
                else if (isSonglistPage)
                {
                    toRemoveFromSonglist.Add(songID);
                }
                else if (isFavoritePage)
                {
                    toRemoveFromFavorites.Add(songID);
                }
            }

            try
            {
                if (isDownloadPage && toRemoveFromDownload.Count > 0)
                {
                    foreach (var id in toRemoveFromDownload)
                    {
                        AppContext._songRepository.CancelDownload(id);
                    }
                    AppContext.TriggerDownloadUpdated();
                }

                if (isPlaylistPage && toRemoveFromPlaylist.Count > 0)
                {
                    var newSongs = AppContext._playbackService.GetPlaylist().PlaySongs
                        .Where(song => !toRemoveFromPlaylist.Contains(song.Id))
                        .ToList();
                    AppContext._playbackService.SetPlaylist(new Playlist(newSongs, AppContext._playbackService.GetPlaybackMode()));
                    AppContext.TriggerPlaylistUpdated();
                }

                if (isSonglistPage && toRemoveFromSonglist.Count > 0 && AppContext.currentViewingSonglist != null)
                {
                    foreach (var id in toRemoveFromSonglist)
                    {
                        AppContext.songlistService.RemoveSongFromSonglist(
                            AppContext.songlistService.GetSongById(id),
                            AppContext.currentViewingSonglist
                        );
                    }
                    AppContext.TriggerSonglistDetailUpdated(AppContext.currentViewingSonglist.Name);
                }

                if (isFavoritePage && toRemoveFromFavorites.Count > 0)
                {
                    var favoriteService = new FavoritesService(AppContext.userRepository);
                    foreach (var id in toRemoveFromFavorites)
                    {
                        favoriteService.RemoveFavoriteSong(AppContext.currentUser.Account, id);
                    }
                    AppContext.TriggerStarUpdated();
                    AppContext.TriggerFavoriteUpdated();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("批量删除时出错：" + ex.Message);
            }

            new MainForms.MessageForm("删除成功").ShowDialog();
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

        public void BulkOperateChange()
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

        private void Control_SizeChanged(object sender, EventArgs e)
        {
            flowLayoutPanel.Location = new Point(
                (this.Width - flowLayoutPanel.Width) / 2,
                flowLayoutPanel.Location.Y);
        }
    }

}
