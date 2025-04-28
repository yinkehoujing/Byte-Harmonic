using System;
using System.Windows.Forms;
using ByteHarmonic.Models;
using Services;

namespace ByteHarmonic.Forms
{
    public partial class TestLyricsForm : Form
    {
        private System.Windows.Forms.Timer _timer;
        private PlaybackService _playbackService;

        public TestLyricsForm()
        {
            InitializeComponent();
            _playbackService = new PlaybackService();
        }

        private void TestLyricsForm_Load(object sender, EventArgs e)
        {
            // 载入一首测试歌曲（假设路径和歌词已经准备好）
            var song = new Song
            {
                Title = "TestSong",
                Artist = "TestArtist",
                MusicFilePath = @"C:\Music\TestSong.mp3"
            };
            song.LoadLyrics(@"C:\Music\TestSong.lrc");

            _playbackService.SetPlaylist(new System.Collections.Generic.List<Song> { song });
            _playbackService.PlaySong(song);

            StartTimer();
        }

        private void StartTimer()
        {
            if (_timer == null)
            {
                _timer = new System.Windows.Forms.Timer();
                _timer.Interval = 100; // 每0.1秒更新一次
                _timer.Tick += (s, e) => UpdateLyrics();
            }
            _timer.Start();
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
            _timer?.Stop();
            _timer?.Dispose();
        }


        private void btnStop_Click(object sender, EventArgs e)
        {
            _timer?.Stop();
            _playbackService.Pause();
        }
    }
}
