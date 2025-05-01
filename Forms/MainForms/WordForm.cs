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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Byte_Harmonic.Forms
{
    public partial class WordForm : Form
    {
        private readonly MouseMove _mouseHandler;//用于鼠标控制窗口
        private readonly FormStyle _styleHandler;//用于更改窗口样式

        public event Action PlayNextRequested;
        public event Action PlayPreviousRequested;
        public event Action PlayPauseRequested;
        public event Action<TimeSpan> SeekRequested; // 以上用于 MusicForm 和 Service 交互

        private readonly PlaybackService _playbackService;

        public WordForm()
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);//双缓冲减少闪烁
            InitializeComponent();
            _mouseHandler = new MouseMove(this);
            _styleHandler = new FormStyle(this);
        }

        public WordForm(MusicForm musicForm)
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);//双缓冲减少闪烁
            InitializeComponent();
            _mouseHandler = new MouseMove(this);
            _styleHandler = new FormStyle(this);

            // 订阅歌词更新事件
            musicForm.LyricsUpdated += OnLyricsUpdated;

            // 窗体关闭时取消订阅
            this.FormClosed += (s, e) =>
                musicForm.LyricsUpdated -= OnLyricsUpdated;
        }

        private void OnLyricsUpdated(string lyrics, TimeSpan position)
        {
            if (IsDisposed) return;

            RunOnUiThread(() =>
            {
                lyricsLabel.Text = lyrics;
                //HighlightCurrentLine(position); // 高亮当前行
            });
        }

        private void RunOnUiThread(Action action)
        {
            if (InvokeRequired) Invoke(action);
            else action();
        }

        private void WordForm_Load(object sender, EventArgs e)
        {
           
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
            PlayPauseRequested?.Invoke();
        }
        private void WordForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }




        private void uiImageButton6_Click(object sender, EventArgs e)
        {
            PlayPreviousRequested?.Invoke();
        }

        private void uiImageButton7_Click(object sender, EventArgs e)
        {
            PlayNextRequested?.Invoke();

        }
    }
}
