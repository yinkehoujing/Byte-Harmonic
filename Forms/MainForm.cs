using Byte_Harmonic.Forms.FormUtils;
using MySql.Data.MySqlClient;
using Transitions;

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

        }


        private void uiImageButton2_Click(object sender, EventArgs e)//最小化按钮
        {

        }


        private void uiImageButton5_Click(object sender, EventArgs e)
        {

        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            Back = new Sunny.UI.UIImageButton();
            pictureBox2 = new PictureBox();
            uiImageButton1 = new Sunny.UI.UIImageButton();
            ((System.ComponentModel.ISupportInitialize)Back).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)uiImageButton1).BeginInit();
            SuspendLayout();
            // 
            // Back
            // 
            Back.Anchor = AnchorStyles.None;
            Back.Cursor = Cursors.Hand;
            Back.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            Back.Image = (Image)resources.GetObject("Back.Image");
            Back.ImageHover = (Image)resources.GetObject("Back.ImageHover");
            Back.Location = new Point(12, 675);
            Back.Name = "Back";
            Back.Size = new Size(33, 33);
            Back.SizeMode = PictureBoxSizeMode.StretchImage;
            Back.TabIndex = 0;
            Back.TabStop = false;
            Back.Text = null;
            Back.ZoomScaleDisabled = true;
            Back.Click += Back_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.White;
            pictureBox2.Location = new Point(200, 20);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(860, 580);
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // uiImageButton1
            // 
            uiImageButton1.Anchor = AnchorStyles.None;
            uiImageButton1.Cursor = Cursors.Hand;
            uiImageButton1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiImageButton1.Image = (Image)resources.GetObject("uiImageButton1.Image");
            uiImageButton1.ImageHover = (Image)resources.GetObject("uiImageButton1.ImageHover");
            uiImageButton1.Location = new Point(992, 43);
            uiImageButton1.Name = "uiImageButton1";
            uiImageButton1.Size = new Size(33, 33);
            uiImageButton1.SizeMode = PictureBoxSizeMode.StretchImage;
            uiImageButton1.TabIndex = 2;
            uiImageButton1.TabStop = false;
            uiImageButton1.Text = null;
            uiImageButton1.ZoomScaleDisabled = true;
            // 
            // MainForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(250, 250, 250);
            ClientSize = new Size(1080, 720);
            ControlBox = false;
            Controls.Add(uiImageButton1);
            Controls.Add(Back);
            Controls.Add(pictureBox2);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(1080, 720);
            MinimumSize = new Size(1080, 720);
            Name = "MainForm";
            ((System.ComponentModel.ISupportInitialize)Back).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)uiImageButton1).EndInit();
            ResumeLayout(false);

        }

        private Sunny.UI.UIImageButton Back;

        private void uiImageButton1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MinButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Back_Click(object sender, EventArgs e)
        {
            if(pictureBox2.Left > 180)
            {
                int panelRight = pictureBox2.Right;
                int panelWidth = pictureBox2.Width;
                pictureBox2.Left = 100;
                pictureBox2.Width = panelRight - pictureBox2.Left;
            }
            else
            {
                int panelRight = pictureBox2.Right;
                int panelWidth = pictureBox2.Width;
                pictureBox2 .Left = 200;
                pictureBox2.Width = panelRight - pictureBox2.Left;
                
            }
        }
        private PictureBox pictureBox2;
        private Sunny.UI.UIImageButton uiImageButton1;
    }
}

