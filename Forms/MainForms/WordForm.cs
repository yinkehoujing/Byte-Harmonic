using Byte_Harmonic.Forms.FormUtils;
using Byte_Harmonic.Models;
using System;
using System.Windows.Forms;

namespace Byte_Harmonic.Forms
{
    public partial class WordForm : Form
    {
        private readonly MouseMove _mouseHandler;
        private readonly FormStyle _styleHandler;

        public WordForm()
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            _mouseHandler = new MouseMove(this);
            _styleHandler = new FormStyle(this);

            // 订阅 AppContext 的歌词更新事件
            AppContext.LyricsUpdated += OnLyricsUpdated;

            //// 注销事件避免内存泄漏
            //this.FormClosed += (s, e) =>
            //    AppContext.LyricsUpdated -= OnLyricsUpdated;
        }

        private void OnLyricsUpdated(string lyrics, TimeSpan position)
        {
            if (IsDisposed) return;

            RunOnUiThread(() =>
            {
                lyricsLabel.Text = lyrics;
                //HighlightCurrentLine(position); // 预留高亮处理
            });
        }

        private void RunOnUiThread(Action action)
        {
            if (InvokeRequired) Invoke(action);
            else action();
        }

        private void WordForm_Load(object sender, EventArgs e)
        {
            // 可选：加载时的逻辑
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
        }

        private void WordForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 清理逻辑已在 FormClosed 中处理，无需重复
        }
    }
}
