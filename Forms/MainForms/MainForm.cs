using Byte_Harmonic.Forms.FormUtils;
using MySql.Data.MySqlClient;
using System.Drawing.Printing;
using System.Windows.Forms;
using Transitions;

namespace Byte_Harmonic.Forms.MainForms
{
    /// <summary>
    /// 主页探索页
    /// </summary>
    public class MainForm : Form
    {
        private readonly MouseMove _mouseHandler;//用于鼠标控制窗口
        private readonly FormStyle _styleHandler;//用于更改窗口样式
        private int cornerRadius = 18;//通用设置圆角

        public MainForm()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);//双缓冲减少闪烁
            InitializeComponent();
            _mouseHandler = new MouseMove(this);
            _styleHandler = new FormStyle(this);
            Load += MainForm_Load;
        }

        /// <summary>
        /// 切换探索页与听歌页
        /// </summary>
        /// <param name="page"></param>
        public void LoadPage(UserControl page)
        {
            panel.Controls.Clear();    // 清空之前的页面
            page.Dock = DockStyle.Fill;        // 填满容器
            panel.Controls.Add(page);   // 添加新页面
        }

        private void MainForm_Load(object sender, EventArgs e)//窗口加载
        {
            // Test MusicForm
            //LoadPage(page: new MusicForm());

            //LoadPage(page: new ExploreForm());//自动载入探索页

            var exploreForm = new ExploreForm();
            LoadPage(exploreForm); // 显示它

            var musicForm = MusicForm.Instance(exploreForm);
        }

        //UI
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            panel = new Panel();
            SuspendLayout();
            // 
            // panel
            // 
            panel.Font = new Font("黑体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            panel.Location = new Point(10, 10);
            panel.Name = "panel";
            panel.Size = new Size(1060, 700);
            panel.TabIndex = 0;
            // 
            // MainForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(250, 250, 250);
            ClientSize = new Size(1080, 720);
            ControlBox = false;
            Controls.Add(panel);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(1080, 720);
            MinimumSize = new Size(1080, 720);
            Name = "MainForm";
            ResumeLayout(false);

        }
        private Panel panel;
    }
}

