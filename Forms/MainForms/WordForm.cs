using Byte_Harmonic.Database;
using Byte_Harmonic.Forms.FormUtils;
using Byte_Harmonic.Models;
using Byte_Harmonic.Utils;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Byte_Harmonic.Forms
{
    public partial class WordForm : Form
    {
        private readonly MouseMove _mouseHandler;//用于鼠标控制窗口
        private readonly FormStyle _styleHandler;//用于更改窗口样式

        private System.Windows.Forms.Timer _timer;
        private System.Windows.Forms.Timer _log_timer;
        private PlaybackService _playbackService;
        private SongRepository _songRepository;

        public WordForm()
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);//双缓冲减少闪烁
            InitializeComponent();
            _mouseHandler = new MouseMove(this);
            _styleHandler = new FormStyle(this);
            _playbackService = new PlaybackService();
            _songRepository = new SongRepository();
        }

        private void WordForm_Load(object sender, EventArgs e)
        {
            // test part ...
            //Console.WriteLine("WordForm is loading");
            //// 请先执行 Init.sql 和 InitData.sql (更新后)!!!
            //var song = _songRepository.GetSongByTitle("公子向北走");
            //if(song == null)
            //{
            //    throw new Exception("歌曲不存在，请先执行 Init.sql 和 InitData.sql (更新后)!!!");
            //}
            //var song2 = _songRepository.GetSongByTitle("一笑江湖");
            //var song3 = _songRepository.GetSongById(3);

            //var songlist = _songRepository.GetAllSongs(5);

            //_playbackService.SetPlaylist(new Playlist(new System.Collections.Generic.List<Song> { song, song2, song3 }));
            //_playbackService.SetPlaylist(new Playlist(new System.Collections.Generic.List<Song> { song, song2, song3 }, PlaybackMode.Shuffle));
            //_playbackService.SetPlaylist(new Playlist(new System.Collections.Generic.List<Song> { song, song2, song3}, PlaybackMode.RepeatOne));
            //_playbackService.SetPlaylist(new Playlist(songlist, PlaybackMode.Sequential));
            //_playbackService.PlayPlaylist();

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


        private void uiImageButton2_Click(object sender, EventArgs e)
        {
            this.TopMost = !this.TopMost;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void uiImageButton1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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
        private void WordForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            TimerHelper.StopAndDisposeTimer(ref _timer);
            TimerHelper.StopAndDisposeTimer(ref _log_timer);
        }



        private void uiImageButton6_Click(object sender, EventArgs e)
        {
            _playbackService.PlayPrevious();
        }

        private void uiImageButton7_Click(object sender, EventArgs e)
        {
            _playbackService.PlayNext();
        }
    }
}
