using System;
using System.Windows.Forms;
using ByteHarmonic.Utils;
using ByteHarmonic.Models;
using Services;

namespace ByteHarmonic.Forms
{
    public partial class TestLyricsForm : Form
    {
        private System.Windows.Forms.Timer _timer;
        private System.Windows.Forms.Timer _log_timer;
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
                Title = "公子向北走",
                Artist = "花僮",
                MusicFilePath = FileHelper.GetAssetPath("Musics/example.mp3")
            };

            song.LoadLyrics(FileHelper.GetAssetPath("Lyrics/example.lrc"));

            _playbackService.SetPlaylist(new System.Collections.Generic.List<Song> { song });
            _playbackService.PlaySong(song);

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
            TimerHelper.DisposeTimer(ref _log_timer);
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
        private void uiipTextBox1_ValueChanged (object sender, EventArgs e){

        }

    }
}
