using System;
using System.Windows.Forms;
using Byte_Harmonic.Utils;
using Byte_Harmonic.Models;
using Services;
using Byte_Harmonic.Database;

namespace Byte_Harmonic.Forms
{
    public partial class TestLyricsForm : Form
    {
        private System.Windows.Forms.Timer _timer;
        private System.Windows.Forms.Timer _log_timer;
        private PlaybackService _playbackService;
        private SongRepository _songRepository;

        public TestLyricsForm()
        {
            InitializeComponent();
            _playbackService = new PlaybackService();
            _songRepository = new SongRepository();
        }

        private void TestLyricsForm_Load(object sender, EventArgs e)
        {
            var song = _songRepository.GetSongByTitle("公子向北走");
            var song2 = _songRepository.GetSongByTitle("一笑江湖");
            var song3 = _songRepository.GetSongById(3);

            _playbackService.SetPlaylist(new Playlist(new System.Collections.Generic.List<Song> { song, song2, song3 }));
            //_playbackService.SetPlaylist(new Playlist(new System.Collections.Generic.List<Song> { song, song2, song3 }, PlaybackMode.Shuffle));
            //_playbackService.SetPlaylist(new Playlist(new System.Collections.Generic.List<Song> { song, song2, song3}, PlaybackMode.RepeatOne));
            _playbackService.PlayPlaylist();

            StartTimer();
        }

        private void StartTimer()
        {
            TimerHelper.SetupTimer(ref _timer, 100, (s, e) => UpdateLyrics());
            TimerHelper.SetupTimer(ref _log_timer, 1000, (s, e) =>
            {
                var position = _playbackService.GetCurrentPosition();
                var lyricsLine = _playbackService.GetCurrentLyricsLine()?.Text ?? "[No Lyrics]";
                Console.WriteLine($"Current Time: {position}: {lyricsLine}");
            });
        }

        private void UpdateLyrics()
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


        }

        private void TestLyricsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            TimerHelper.StopAndDisposeTimer(ref _timer);
            TimerHelper.StopAndDisposeTimer(ref _log_timer);
        }


        private void btnStop_Click(object sender, EventArgs e)
        {
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

        private void seekToBtn_Click(object sender, EventArgs e)
        {
            var input = uiipTextBox1.Text.Trim();
            if (TimeSpan.TryParse("00:" + input, out TimeSpan position)) // 补上小时位
            {
                _playbackService.SeekTo(position);
                Console.WriteLine($"跳转到 {position}");
            }
            else
            {
                MessageBox.Show("请输入有效的时间格式（如：1:30）", "格式错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            _playbackService.PlayNext();
        }


        private void uiipTextBox1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            _playbackService.PlayPrevious();
        }


        private void trackBarPlaybackSpeed_Scroll(object sender, EventArgs e)
        {
            double speed = 0.5 + trackBarPlaybackSpeed.Value * 0.1;
            try
            {
                _playbackService.SetPlaybackSpeed(speed);
                labelPlaybackSpeed.Text = $"x{speed:F2}";
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
