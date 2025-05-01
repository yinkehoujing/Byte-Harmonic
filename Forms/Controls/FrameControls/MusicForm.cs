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
        public MusicForm()
        {
            InitializeComponent();

            _playbackService = new PlaybackService();
            _songRepository = new SongRepository();
        }

        private void MusicForm_Load(object sender, EventArgs e)
        {
            uiTrackBar1.MouseDown += (s, e2) => { _isDragging = true; };
            uiTrackBar1.MouseUp += (s, e2) =>
            {
                _isDragging = false;
                TimeSpan seekPosition = TimeSpan.FromSeconds(uiTrackBar1.Value);
                _playbackService.SeekTo(seekPosition);
                Console.WriteLine($"用户拖动到：{seekPosition}");
            };

            var songlist = _songRepository.GetAllSongs();

            _playbackService.SetPlaylist(new Playlist(songlist, PlaybackMode.Sequential));
            _playbackService.PlayPlaylist();
            UpdateTrackBarMaximum();
            StartTimer();

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
                secondForm = new Byte_Harmonic.Forms.WordForm();
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


        private System.Windows.Forms.Timer _timer;
        private System.Windows.Forms.Timer _log_timer;
        private PlaybackService _playbackService;
        private SongRepository _songRepository;
        private bool _isDragging = false; // 是否正在拖动进度条

        private void StartTimer()
        {
            TimerHelper.SetupTimer(ref _timer, 500, (s, e) =>
            {
                UpdateLyrics();
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

        private void UpdateLyrics()
        {
            var line = _playbackService.GetCurrentLyricsLine();
            if (line != null)
            {
                //lyricsLabel.Text = line.Text;
            }
            else
            {
                //lyricsLabel.Text = "（无歌词）";
            }


        }

        private void TestLyricsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            TimerHelper.StopAndDisposeTimer(ref _timer);
            TimerHelper.StopAndDisposeTimer(ref _log_timer);
        }

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
        }

        private void uiImageButton7_Click(object sender, EventArgs e)
        {
            _playbackService.PlayNext();
            UpdateTrackBarMaximum();
        }

        private void uiLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
