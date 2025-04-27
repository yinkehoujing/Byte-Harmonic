using Byte_Harmonic.Forms.FormUtils;
using MySql.Data.MySqlClient;

namespace ByteHarmonic.Forms
{
    /// <summary>
    /// ��ҳ̽��ҳ
    /// </summary>
    public class MainForm : Form
    {
        private readonly MouseMove _mouseHandler;//���������ƴ���
        private readonly FormStyle _styleHandler;//���ڸ��Ĵ�����ʽ

        public MainForm()
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);//˫���������˸
            InitializeComponent();
            _mouseHandler = new MouseMove(this);
            _styleHandler = new FormStyle(this);
        }

        private void Home_Load(object sender, EventArgs e)//���ڼ���
        {
            this.MaximizedBounds = Screen.PrimaryScreen.WorkingArea;//ȷ�����size
        }

        private void uiImageButton1_Click(object sender, EventArgs e)//�رհ�ť
        {
            this.Close();
        }

        private void uiImageButton2_Click(object sender, EventArgs e)//��С����ť
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

