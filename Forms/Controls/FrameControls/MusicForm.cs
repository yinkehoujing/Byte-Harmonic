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

namespace Byte_Harmonic.Forms
{
    public partial class MusicForm : UserControl
    {
        private Form secondForm;

        private ExploreForm _exploreForm;

        private static MusicForm? _instance;

        public static MusicForm Instance(ExploreForm exploreForm)
        {
            if (_instance == null || _instance.IsDisposed)
                _instance = new MusicForm(exploreForm);
            return _instance;
        }

        public MusicForm(ExploreForm exploreForm)
        {
            InitializeComponent();

            _exploreForm = exploreForm;
            _playbackService = new PlaybackService();
            _timer = new System.Windows.Forms.Timer();
            _log_timer = new System.Windows.Forms.Timer();
            _songRepository = new SongRepository();

            uiTrackBar1.MouseDown += (s, e2) => { _isDragging = true; };
            uiTrackBar1.MouseUp += (s, e2) =>
            {
                _isDragging = false;
                TimeSpan seekPosition = TimeSpan.FromSeconds(uiTrackBar1.Value);
                _playbackService.SeekTo(seekPosition);
                Console.WriteLine($"用户拖动到：{seekPosition}");
            };

            // UI 层 订阅 PlaybackStopped 事件，接收到这个事件后，UI 层的回调函数会被执行,负责更新 UI 元素 
            _playbackService.CurrentSongChanged += OnCurrentSongChanged;
            _playbackService.PlaybackPaused += OnPlaybackPaused;
            _playbackService.PositionChanged += UpdatePositionUI;

            _exploreForm.PlaylistSet += OnPlaylistSet;
            _exploreForm.PlayNextRequested += () =>
            {
                _playbackService.PlayNext();
                var current = _playbackService.GetCurrentSong();
                if(current == null)
                {
                    Console.WriteLine("current song is null!");
                    current = _playbackService.GetPlaylist().PlaySongs[0];
                }
                updateSongUI?.Invoke(current);
            };

            _exploreForm.PlayPreviousRequested += () =>
            {
                _playbackService.PlayPrevious();
                var current = _playbackService.GetCurrentSong();
                updateSongUI?.Invoke(current);
            };
            _exploreForm.PlayPauseRequested += TogglePlayPause;
            _exploreForm.SeekRequested += pos => _playbackService.SeekTo(pos);

            _exploreForm.LoadInitialSongs();
            //_exploreForm.PlaySongRequested += OnPlaySongRequested;

        }

        //private void OnPlaySongRequested(int start_index)
        //{
        //    Console.WriteLine("Response to PlaySong");
        //    _playbackService.PlayPlaylist(start_index);
        //    StartTimer();
        //}

        private void OnPlaylistSet(List<Song> songs)
        {
            Console.WriteLine("Response to PlaylistSet");
            _playbackService.SetPlaylist(new Playlist(songs, PlaybackMode.Sequential));
            //_playbackService.PlayPlaylist();
            UpdateTrackBarMaximum();
            UpdateSongInfo(); // 还没有开始播放
            //StartTimer();
        }

        private void MusicForm_Load(object sender, EventArgs e)
        {

            //var songlist = _songRepository.GetAllSongs();
            //_playbackService.SetPlaylist(new Playlist(songlist, PlaybackMode.Sequential));
            //_playbackService.PlayPlaylist();
            //UpdateTrackBarMaximum();
            //UpdateSongInfo();
            //StartTimer();

        }

        private void UpdatePositionUI(TimeSpan position)
        {
            if (!_isDragging) // 防止拖动冲突
            {
                RunOnUiThread(() => {
                    uiTrackBar1.Value = (int)position.TotalSeconds;
                    uiLabel2.Text = position.ToString(@"mm\:ss");
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
                secondForm = new WordForm(this); // 仅仅为了高效访问歌词行

                // 订阅操作请求事件
                var wordForm = (WordForm)secondForm;

                // 也通知 ExploreForm 的 UI
                wordForm.PlayNextRequested += () =>
                {
                    _playbackService.PlayNext();
                    var current = _playbackService.GetCurrentSong();
                    if (current != null)
                    {
                        throw new ArgumentNullException("Song is null");
                    }
                    updateSongUI?.Invoke(current);
                };

                wordForm.PlayPreviousRequested += () =>
                {
                    _playbackService.PlayPrevious();
                    var current = _playbackService.GetCurrentSong();
                    updateSongUI?.Invoke(current);
                };

                wordForm.PlayPauseRequested += TogglePlayPause;
                wordForm.SeekRequested += pos => _playbackService.SeekTo(pos);

                secondForm.Show();
            }
        }

        private void TogglePlayPause()
        {
            Console.WriteLine("begin to Toggle PlayPause");
            if(_playbackService.GetCurrentSong() == null)
            {
                _playbackService.PlayPlaylist(0); // 假设从队首播放
                StartTimer(); // 没有对应地暂停 log_timer
            }
            else if (_playbackService.IsPaused)
            {
                _playbackService.Resume();
                TimerHelper.RestartTimer(ref _timer);
                TimerHelper.RestartTimer(ref _log_timer);
            }
            else
            {
                _playbackService.Pause();
                TimerHelper.StopTimer(ref _timer);
                TimerHelper.StopTimer(ref _log_timer);

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


        private System.Windows.Forms.Timer _timer;
        private System.Windows.Forms.Timer _log_timer;
        private PlaybackService _playbackService;
        private SongRepository _songRepository;
        private bool _isDragging = false; // 是否正在拖动进度条
        public event Action<string, TimeSpan> LyricsUpdated; // 参数：歌词文本、当前时间位置
        public event Action<Song> updateSongUI;

        private void StartTimer()
        {
            TimerHelper.SetupTimer(ref _timer, 500, (s, e) =>
            {
                var line = _playbackService.GetCurrentLyricsLine();
                if (line != null)
                {
                    lyricsLabel.Text = line.Text;
                }
                else
                {
                    lyricsLabel.Text = "（无歌词）";
                }

                // 通知 WordForm 更新歌词
                var position = _playbackService.GetCurrentPosition();

                LyricsUpdated?.Invoke(line?.Text ?? "（无歌词）", position);
                UpdatePlaybackProgress();
            });

            TimerHelper.SetupTimer(ref _log_timer, 1000, (s, e) =>
            {
                var position = _playbackService.GetCurrentPosition();
                var lyricsLine = _playbackService.GetCurrentLyricsLine()?.Text ?? "[No Lyrics]";
                Console.WriteLine($"Current Time: {position}: {lyricsLine}");
            });
        }

        private void UpdatePlaybackProgress()
        {
            if (_isDragging) return; // 正在拖动时不更新

            var current = _playbackService.GetCurrentPosition();
            var duration = _playbackService.GetCurrentSong()?.Duration ?? 0;

            uiTrackBar1.Maximum = duration;
            uiTrackBar1.Value = Math.Min((int)current.TotalSeconds, uiTrackBar1.Maximum);
            uiLabel2.Text = current.ToString(@"mm\:ss"); 
        }

        //private void UpdateLyrics()
        //{
        //    var line = _playbackService.GetCurrentLyricsLine();
        //    if (line != null)
        //    {
        //        lyricsLabel.Text = line.Text;
        //    }
        //    else
        //    {
        //        lyricsLabel.Text = "（无歌词）";
        //    }


        //}

        private void UpdateTrackBarMaximum()
        {
            var duration = _playbackService.GetCurrentSong()?.Duration ?? 0;
            uiTrackBar1.Maximum = duration;
            uiTrackBar1.Value = 0;
            TimeSpan ts = TimeSpan.FromSeconds(duration);

            // 格式化为 mm:ss 并显示到 UI
            uiLabel1.Text = ts.ToString(@"mm\:ss");  
            uiLabel2.Text = TimeSpan.Zero.ToString(@"mm\:ss"); // 输出：00:00

        }

        private void UpdateSongInfo()
        {

            var song= _playbackService.GetCurrentSong();
            if(song == null)
            {
                // 还没有开始播放
                // 假设默认播放第一首
                song = _playbackService.GetPlaylist().PlaySongs[0];
            }
            string songName = song.Title;
            string artistName = song.Artist;
            uiLabel3.Text = $"{songName}——{artistName}";

        }



        private void uiImageButton5_Click(object sender, EventArgs e)
        {
            // TODO: 切换图标
            if (!_playbackService.IsPaused)
            {
                TimerHelper.StopTimer(ref _timer);
                TimerHelper.StopTimer(ref _log_timer);
                _playbackService.Pause();
            }
            else
            {
                TimerHelper.RestartTimer(ref _timer);
                TimerHelper.RestartTimer(ref _log_timer);
                _playbackService.Resume();
            }

        }

        private void uiImageButton6_Click(object sender, EventArgs e)
        {
            _playbackService.PlayPrevious();
            UpdateTrackBarMaximum();
            UpdateSongInfo();
        }

        private void uiImageButton7_Click(object sender, EventArgs e)
        {
            _playbackService.PlayNext();
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
