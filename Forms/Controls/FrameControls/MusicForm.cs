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

namespace Byte_Harmonic.Forms
{
    public partial class MusicForm : UserControl
    {
        private Form secondForm;

        private static MusicForm? _instance;

        public static MusicForm Instance()
        {
            if (_instance == null || _instance.IsDisposed)
                _instance = new MusicForm();
            return _instance;
        }

        public MusicForm()
        {
            InitializeComponent();

            // UI 层 订阅 PlaybackStopped 事件，接收到这个事件后，UI 层的回调函数会被执行,负责更新 UI 元素 
            AppContext.updateSongUI += OnCurrentSongChanged;
            //AppContext.PlaybackPaused += OnPlaybackPaused;
            AppContext.PositionChanged += UpdatePositionUI;
            AppContext.LyricsUpdated += OnLyricsUpdated;

            var song = AppContext._playbackService.GetCurrentSong();
            // 恢复之前的界面
            if(song != null)
            {
                Console.WriteLine("恢复之前的页面显示——MusicForm");
                var text = AppContext._playbackService.GetCurrentLyricsLine()?.Text ?? "（无歌词）";
                var position = AppContext._playbackService.GetCurrentPosition();
                AppContext.TriggerupdateSongUI(song);

                AppContext.TriggerLyricsUpdated(text, position);
                //AppContext.TriggerPositionChanged(position);
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
           
           AppContext.SeekRequested += pos => AppContext._playbackService.SeekTo(pos);

            LoadInitialSongs(); // 注册完了之后就 trigger
            //_exploreForm.PlaySongRequested += OnPlaySongRequested;

        }

        private void OnLyricsUpdated(string lyrics, TimeSpan position)
        {
            if (IsDisposed) return;

            RunOnUiThread(() =>
            {
                lyricsLabel.Text = lyrics;
                uiLabel2.Text = position.ToString(@"mm\:ss");
                uiTrackBar1.Value = Math.Min((int)position.TotalSeconds, uiTrackBar1.Maximum);
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
                RunOnUiThread(() => {
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

        private void uiImageButton12_Click(object sender, EventArgs e)
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

        private void StartTimer()
        {
            TimerHelper.SetupTimer(ref AppContext._timer, 500, (s, e) =>
            {
                var line = AppContext._playbackService.GetCurrentLyricsLine();
                if (line != null)
                {
                    lyricsLabel.Text = line.Text;
                }
                else
                {
                    lyricsLabel.Text = "（无歌词）";
                }

                // 通知 WordForm 更新歌词
                var position = AppContext._playbackService.GetCurrentPosition();

                AppContext.TriggerLyricsUpdated(line?.Text ?? "（无歌词）", position);
                UpdatePlaybackProgress();
            });

            TimerHelper.SetupTimer(ref AppContext._log_timer, 1000, (s, e) =>
            {
                var position = AppContext._playbackService.GetCurrentPosition();
                var lyricsLine = AppContext._playbackService.GetCurrentLyricsLine()?.Text ?? "[No Lyrics]";
                Console.WriteLine($"Current Time: {position}: {lyricsLine}");
            });
        }

        private void UpdatePlaybackProgress()
        {
            if (_isDragging) return; // 正在拖动时不更新

            var current = AppContext._playbackService.GetCurrentPosition();
            var duration = AppContext._playbackService.GetCurrentSong()?.Duration ?? 0;

            uiTrackBar1.Maximum = duration;
            uiTrackBar1.Value = Math.Min((int)current.TotalSeconds, uiTrackBar1.Maximum);
            uiLabel2.Text = current.ToString(@"mm\:ss"); 
        }

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

            var song= AppContext._playbackService.GetCurrentSong();
            if(song == null)
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
            ResourceManager resourceManager = new ResourceManager("Byte_Harmonic.Properties.Resources", typeof(Resources).Assembly);//获取全局资源

            //if (!_playbackService.IsPaused)
            //{
            //    TimerHelper.StopTimer(ref _timer);
            //    TimerHelper.StopTimer(ref _log_timer);
            //    _playbackService.Pause();
            //    uiImageButton5.Image = ((Image)(resourceManager.GetObject("icons8-pause-96")));
            //    uiImageButton5.ImageHover = ((Image)(resourceManager.GetObject("icons8-pause-96 (1)")));

            //}
            //else
            //{
            //    TimerHelper.RestartTimer(ref _timer);
            //    TimerHelper.RestartTimer(ref _log_timer);
            //    _playbackService.Resume();
            //    uiImageButton5.Image = ((Image)(resourceManager.GetObject("icons8-play-96")));
            //    uiImageButton5.ImageHover = ((Image)(resourceManager.GetObject("icons8-play-96 (1)")));
            //}

            // Image 切换逻辑应该移入这里
            AppContext.TogglePlayPause();


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

    }
}
