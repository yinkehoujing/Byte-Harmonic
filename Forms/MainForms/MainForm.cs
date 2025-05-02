using Byte_Harmonic.Forms.FormUtils;
using MySql.Data.MySqlClient;
using System.Drawing.Printing;
using System.Windows.Forms;
using Transitions;

namespace Byte_Harmonic.Forms.MainForms
{
    /// <summary>
    /// ��ҳ̽��ҳ
    /// </summary>
    public class MainForm : Form
    {
        private readonly MouseMove _mouseHandler;//���������ƴ���
        private readonly FormStyle _styleHandler;//���ڸ��Ĵ�����ʽ
        private int cornerRadius = 18;//ͨ������Բ��

        public MainForm()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);//˫���������˸
            InitializeComponent();
            _mouseHandler = new MouseMove(this);
            _styleHandler = new FormStyle(this);
            Load += MainForm_Load;
        }

        /// <summary>
        /// �л�̽��ҳ������ҳ
        /// </summary>
        /// <param name="page"></param>
        public void LoadPage(UserControl page)
        {
            panel.Controls.Clear();    // ���֮ǰ��ҳ��
            page.Dock = DockStyle.Fill;        // ��������
            panel.Controls.Add(page);   // �����ҳ��
        }

        private void MainForm_Load(object sender, EventArgs e)//���ڼ���
        {
            // Test MusicForm
            //LoadPage(page: new MusicForm());

            //LoadPage(page: new ExploreForm());//�Զ�����̽��ҳ

            var exploreForm = new ExploreForm();
            LoadPage(exploreForm); // ��ʾ��

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
            panel.Font = new Font("����", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
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

