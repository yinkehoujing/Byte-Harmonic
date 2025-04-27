using Byte_Harmonic.Forms.FormUtils;
using MySql.Data.MySqlClient;

namespace ByteHarmonic.Forms
{
    /// <summary>
    /// 主页探索页
    /// </summary>
    public class MainForm : Form
    {
        private readonly MouseMove _mouseHandler;//用于鼠标控制窗口
        private readonly FormStyle _styleHandler;//用于更改窗口样式

        public MainForm()
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);//双缓冲减少闪烁
            InitializeComponent();
            _mouseHandler = new MouseMove(this);
            _styleHandler = new FormStyle(this);
        }

        private void Home_Load(object sender, EventArgs e)//窗口加载
        {
            this.MaximizedBounds = Screen.PrimaryScreen.WorkingArea;//确定最大size
        }

        private void uiImageButton1_Click(object sender, EventArgs e)//关闭按钮
        {
            this.Close();
        }

        private void uiImageButton2_Click(object sender, EventArgs e)//最小化按钮
        {
            this.WindowState = FormWindowState.Minimized;
        }


        private void uiImageButton5_Click(object sender, EventArgs e)
        {

        }

        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // MainForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1080, 720);
            ControlBox = false;
            FormBorderStyle = FormBorderStyle.None;
            MaximumSize = new Size(1080, 720);
            MinimumSize = new Size(1080, 720);
            Name = "MainForm";
            ResumeLayout(false);

        }
    }
}

