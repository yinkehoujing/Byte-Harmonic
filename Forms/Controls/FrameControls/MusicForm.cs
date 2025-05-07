using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Byte_Harmonic.Forms.MainForms;
using Byte_Harmonic.Database;
using Services;
using Byte_Harmonic.Utils;
using Byte_Harmonic.Models;
using Byte_Harmonic.Properties;
using System.Resources;
using Sunny.UI;
using Byte_Harmonic.Forms.Controls.BaseControls;
using Byte_Harmonic.Forms.FormUtils;

namespace Byte_Harmonic.Forms
{
    public partial class MusicForm : UserControl
    {
        private Form secondForm;

        public MusicForm()
        {
            InitializeComponent();
            uiLabel3.EnableAutoScroll();

            // UI 层 订阅 PlaybackStopped 事件，接收到这个事件后，UI 层的回调函数会被执行,负责更新 UI 元素 
            AppContext.updateSongUI += OnCurrentSongChanged;
            //AppContext.PlaybackPaused += OnPlaybackPaused;
            AppContext.PositionChanged += UpdatePositionUI;
            AppContext.LyricsUpdated += OnLyricsUpdated;
            AppContext.ShowPlayingBtn += OnShowPlayingBtn;

            var song = AppContext._playbackService.GetCurrentSong();
            // 恢复之前的界面
            if (song != null)
            {
                Console.WriteLine("恢复之前的页面显示——MusicForm");
                var text = AppContext._playbackService.GetCurrentLyricsLine()?.Text ?? "（无歌词）";
                var position = AppContext._playbackService.GetCurrentPosition();
                AppContext.TriggerupdateSongUI(song); // 这里的响应函数也包含了更新进度条

                AppContext.TriggerLyricsUpdated(text, position);
                AppContext.TriggerShowPlayingBtn(!AppContext._playbackService.IsPaused);
            }

            uiTrackBar1.MouseDown += (s, e2) => { _isDragging = true; };
            uiTrackBar1.MouseUp += (s, e2) =>
            {
                _isDragging = false;
                TimeSpan seekPosition = TimeSpan.FromSeconds(uiTrackBar1.Value);
                AppContext._playbackService.SeekTo(seekPosition);
                Console.WriteLine($"用户拖动到：{seekPosition}");
                AppContext.TriggerPositionChanged(seekPosition);
                //AppContext.TriggerSeekRequested(seekPosition); // 用于更新 UI
            };

            AppContext.PlaylistSetRequested += OnPlaylistSet;

            LoadInitialSongs(); // 注册完了之后就 trigger
        }

        private void OnShowPlayingBtn(bool isPaused)
        {
            ResourceManager resourceManager = new ResourceManager("Byte_Harmonic.Properties.Resources", typeof(Resources).Assembly);//获取全局资源

            if (isPaused)
            {
                uiImageButton5.Image = ((Image)(resourceManager.GetObject("icons8-pause-96")));
                uiImageButton5.ImageHover = ((Image)(resourceManager.GetObject("icons8-pause-96 (1)")));
                pictureBox1.Image = ((Image)(resourceManager.GetObject("diskgif")));

            }
            else
            {
                // 暂停了显示下面图标
                uiImageButton5.Image = ((Image)(resourceManager.GetObject("icons8-play-96")));
                uiImageButton5.ImageHover = ((Image)(resourceManager.GetObject("icons8-play-96 (1)")));
                pictureBox1.Image = ((Image)(resourceManager.GetObject("diskpng")));
            }
        }

        private void OnLyricsUpdated(string lyrics, TimeSpan position)
        {
            if (IsDisposed) return;

            RunOnUiThread(() =>
            {

                uiLabel2.Text = position.ToString(@"mm\:ss");
                uiTrackBar1.Value = Math.Min((int)position.TotalSeconds, uiTrackBar1.Maximum);

                if (uiLabel6.Text == lyrics)
                {
                    return;
                }

                int currentIndex = (AppContext._playbackService.GetCurrentIndex(position));

                string prepre = "";
                string prev = "";

                if (currentIndex > 0)
                {
                    prev = AppContext._playbackService.GetLyricsTextByIndex(currentIndex - 1);

                    if (currentIndex > 1)
                    {
                        prepre = AppContext._playbackService.GetLyricsTextByIndex(currentIndex - 2);
                    }
                }
                string nxtnxt = "", nxt = "";
                int n = AppContext._playbackService.GetCurrentLyricsCount();
                if (currentIndex < n - 1)
                {
                    nxt = AppContext._playbackService.GetLyricsTextByIndex(currentIndex + 1);

                    if (currentIndex < n - 2)
                    {
                        nxtnxt = AppContext._playbackService.GetLyricsTextByIndex(currentIndex + 2);
                    }
                }

                uiLabel4.Text = prepre;
                uiLabel5.Text = prev;
                uiLabel6.Text = lyrics;
                uiLabel7.Text = nxt;
                uiLabel8.Text = nxtnxt;



                //HighlightCurrentLine(position); // 预留高亮处理
            });
        }
        public void LoadInitialSongs()
        {

            var songlist = AppContext._songRepository.GetAllSongs();

            if (songlist.Count <= 0)
            {
                throw new ArgumentException("songlist 为空!!!");
            }

            Console.WriteLine("invoke playlistSet");
            //AppContext.TriggerPlaylistSetRequested(songlist);
        }

        private void OnPlaylistSet(List<Song> songs)
        {
            Console.WriteLine("Response to PlaylistSet");
            AppContext._playbackService.SetPlaylist(new Playlist(songs, PlaybackMode.Sequential));
            //AppContext._playbackService.PlayPlaylist();
            UpdateTrackBarMaximum();
            UpdateSongInfo(); // 还没有开始播放
            //StartTimer();
        }

        private void MusicForm_Load(object sender, EventArgs e)
        {

        }

        private void UpdatePositionUI(TimeSpan position)
        {
            if (!_isDragging) // 防止拖动冲突
            {
                RunOnUiThread(() =>
                {
                    uiLabel2.Text = position.ToString(@"mm\:ss");
                    uiTrackBar1.Value = Math.Min((int)position.TotalSeconds, uiTrackBar1.Maximum);
                });
            }
        }

        private void OnCurrentSongChanged(Song currentSong)
        {
            RunOnUiThread(() =>
            {
                uiLabel3.Text = $"{currentSong.Title}——{currentSong.Artist}";
                UpdateTrackBarMaximum(); // 播放下一首后更新 UI
            });
        }


        

        private void OnPlaybackPaused(bool isPaused)
        {
            RunOnUiThread(() =>
            {
                //btnPlayPause.Image = isPaused ? ResumeIcon : PauseIcon;
            });
        }
        private void uiLabel3_Click(object sender, EventArgs e)
        {

        }

        private void uiImageButton14_Click(object sender, EventArgs e)
        {
            MainForm main = this.FindForm() as MainForm;
            if (main != null)
            {
                // 使用已经绑定好委托的 _exploreForm 去 LoadPage
                main.LoadPage(new ExploreForm());
            }

        }

        private void uiImageButton1_Click(object sender, EventArgs e)
        {
            MainForm main = this.FindForm() as MainForm;
            if (main != null)
            {
                main.Close();
            }
        }

        private void uiImageButton3_Click(object sender, EventArgs e)
        {
            MainForm main = this.FindForm() as MainForm;
            if (main != null)
            {
                main.WindowState = FormWindowState.Minimized;
            }
        }

        private void uiTrackBar1_ValueChanged(object sender, EventArgs e)
        {

        }


        private bool _isDragging = false; // 是否正在拖动进度条

        private void UpdateTrackBarMaximum()
        {
            Console.WriteLine("UpdateTrackBarMaximum in MusicForm");
            var duration = AppContext._playbackService.GetCurrentSong()?.Duration ?? 0;
            uiTrackBar1.Maximum = duration;
            uiTrackBar1.Value = 0;
            TimeSpan ts = TimeSpan.FromSeconds(duration);

            // 格式化为 mm:ss 并显示到 UI
            uiLabel1.Text = ts.ToString(@"mm\:ss");
            uiLabel2.Text = TimeSpan.Zero.ToString(@"mm\:ss"); // 输出：00:00

        }

        private void UpdateSongInfo()
        {

            var song = AppContext._playbackService.GetCurrentSong();
            if (song == null)
            {
                // 还没有开始播放
                // 假设默认播放第一首
                song = AppContext._playbackService.GetPlaylist().PlaySongs[0];
            }
            string songName = song.Title;
            string artistName = song.Artist;
            uiLabel3.Text = $"{songName}——{artistName}";

        }



        private void uiImageButton5_Click(object sender, EventArgs e)
        {
            AppContext.TogglePlayPause(); // 内部触发事件 
            AppContext.TriggerupdateSongUI(AppContext._playbackService.GetCurrentSong());
        }

        private void uiImageButton6_Click(object sender, EventArgs e)
        {
            AppContext._playbackService.PlayPrevious();
            var current = AppContext._playbackService.GetCurrentSong();
            if (current == null)
            {
                Console.WriteLine("current song is null!");
                current = AppContext._playbackService.GetPlaylist().PlaySongs[0];
            }
            AppContext.TriggerupdateSongUI(current);
            UpdateTrackBarMaximum();
            UpdateSongInfo();
        }

        private void uiImageButton7_Click(object sender, EventArgs e)
        {
            AppContext._playbackService.PlayNext();

            var current = AppContext._playbackService.GetCurrentSong();
            if (current == null)
            {
                Console.WriteLine("current song is null!");
                current = AppContext._playbackService.GetPlaylist().PlaySongs[0];
            }
            AppContext.TriggerupdateSongUI(current);

            //updateSongUI?.Invoke(current);
            UpdateTrackBarMaximum();
            UpdateSongInfo();
        }

        private void uiLabel1_Click(object sender, EventArgs e)
        {

        }

        private void RunOnUiThread(Action action)
        {
            if (InvokeRequired)
                Invoke(action);
            else
                action();
        }

        //
        //UI:播放顺序控制
        //
        private PlayOrderControl playOrderControl = null;
        private void uiImageButton9_Click(object sender, EventArgs e)
        {
            if (playOrderControl == null)
            {
                playOrderControl = new PlayOrderControl(uiImageButton9.Location);
                this.Controls.Add(playOrderControl);
                playOrderControl.BringToFront();
            }
            else
            {
                using (playOrderControl) // 自动释放
                {
                    this.Controls.Remove(playOrderControl);
                }
                playOrderControl = null;
            }
        }


        //
        // UI:音量控制
        //
        private VolumeControl volumeControl = null;
        private void uiImageButton11_Click(object sender, EventArgs e)
        {
            if (volumeControl == null)
            {
                volumeControl = new VolumeControl(uiImageButton11.Location, (int)((AppContext._playbackService.GetVolume()) * 100));
                this.Controls.Add(volumeControl);
                volumeControl.BringToFront();
            }
            else
            {
                using (volumeControl) // 自动释放
                {
                    this.Controls.Remove(volumeControl);
                }
                volumeControl = null;
            }

        }

        //
        //UI:倍速控制
        //
        private SpeedControl speedControl = null;
        private void uiImageButton17_Click(object sender, EventArgs e)
        {
            if (speedControl == null)
            {
                speedControl = new SpeedControl(uiImageButton17.Location, AppContext._playbackService.GetPlaybackSpeed());
                this.Controls.Add(speedControl);
                speedControl.BringToFront();
            }
            else
            {
                using (speedControl) // 自动释放
                {
                    this.Controls.Remove(speedControl);
                }
                speedControl = null;
            }

        }

        //
        //UI:更多
        //
        private MoreControl moreControl = null;
        private void uiImageButton13_Click(object sender, EventArgs e)
        {
            if (moreControl == null)
            {
                moreControl = new MoreControl(uiImageButton13.Location);
                this.Controls.Add(moreControl);
                moreControl.BringToFront();
            }
            else
            {
                using (moreControl) // 自动释放
                {
                    this.Controls.Remove(moreControl);
                }
                moreControl = null;
            }
        }

        private void uiImageButton2_Click(object sender, EventArgs e)
        {
            if (secondForm != null && !secondForm.IsDisposed)
            {
                secondForm.Close();
                secondForm = null;
            }
            else
            {
                secondForm = new WordForm();
                secondForm.Show();
            }
        }

    }

}
