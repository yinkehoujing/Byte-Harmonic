using Byte_Harmonic.Forms.FormUtils;
using Byte_Harmonic.Forms.MainForms;

namespace Byte_Harmonic.Forms
{
    public partial class ExploreForm : UserControl
    {
        public ExploreForm()
        {
            InitializeComponent();
        }
        private readonly FormStyle _styleHandler;//用于更改窗口样式
        private int cornerRadius = 18;//通用设置圆角
        private Form secondForm;//用于歌词页

        private void MainForm_Load(object sender, EventArgs e)//窗口加载
        {
            _styleHandler.SetPictureBoxRoundCorners(pictureBox2, cornerRadius);//绘制圆角
        }

        private void uiImageButton2_Click(object sender, EventArgs e)//最小化按钮
        {

        }


        private void uiImageButton5_Click(object sender, EventArgs e)
        {

        }

        private void PictureBox2_SizeChanged(object? sender, EventArgs e)
        {
            _styleHandler.SetPictureBoxRoundCorners(pictureBox2, cornerRadius);
        }

        private void uiImageButton1_Click_1(object sender, EventArgs e)
        {
            // 获取主窗体引用
            Byte_Harmonic.Forms.MainForms.MainForm main = this.FindForm() as MainForm;
            if (main != null)
            {
                main.Close();
            }
        }

        private void MinButton_Click(object sender, EventArgs e)
        {
            // 获取主窗体引用
            Byte_Harmonic.Forms.MainForms.MainForm main = this.FindForm() as MainForm;
            if (main != null)
            {
                main.WindowState = FormWindowState.Minimized;
            }
        }

        private void Back_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Left > 180)
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
                pictureBox2.Left = 200;
                pictureBox2.Width = panelRight - pictureBox2.Left;
            }
        }

        private void uiImageButton1_Click(object sender, EventArgs e)
        {

        }

        private void btnGoToSettings_Click(object sender, EventArgs e)
        {
            // 获取主窗体引用
            MainForm main = this.FindForm() as MainForm;
            if (main != null)
            {
                main.LoadPage(new MusicForm());
            }
        }

        private void uiImageButton2_Click_1(object sender, EventArgs e)
        {
            // 获取主窗体引用
            MainForm main = this.FindForm() as MainForm;
            if (main != null)
            {
                main.LoadPage(new MusicForm());
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void uiImageButton14_Click(object sender, EventArgs e)
        {
            // 获取主窗体引用
            MainForm main = this.FindForm() as MainForm;
            if (main != null)
            {
                main.LoadPage(new MusicForm());
            }
        }

        private void uiImageButton1_Click_2(object sender, EventArgs e)
        {
            MainForm main = this.FindForm() as MainForm;
            if (main != null)
            {
                main.Close();
            }
        }

        private void uiImageButton3_Click(object sender, EventArgs e)
        {
            MainForm main = this.FindForm() as MainForm;
            if (main != null)
            {
                main.WindowState = FormWindowState.Minimized;
            }
        }

        private void uiImageButton12_Click(object sender, EventArgs e)
        {
            if (secondForm != null && !secondForm.IsDisposed)
            {
                secondForm.Close();
                secondForm = null;
            }
            else
            {
                secondForm = new Byte_Harmonic.Forms.WordForm();
                secondForm.Show();
            }
        }

        
        private bool isFirstForm = true; // 跟踪当前窗体形态
        private void Back_Click_1(object sender, EventArgs e)
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExploreForm));

            if (isFirstForm)
            {
                // 切换到第二个窗体形态
                // 调整pictureBox2
                pictureBox2.Location = new Point(79, 9);
                pictureBox2.Size = new Size(973, 580);

                // 调整panel1
                panel1.Location = new Point(8, 9);
                panel1.Size = new Size(65, 627);

                // 调整panel2
                panel2.Location = new Point(97, 64);
                panel2.Size = new Size(938, 512);

                // 调整pictureBox1
                pictureBox1.Location = new Point(79, 592);
                pictureBox1.Size = new Size(973, 100);

                // 调整按钮位置
                uiImageButton1.Location = new Point(1005, 28);
                uiImageButton3.Location = new Point(958, 28);
                uiImageButton2.Location = new Point(97, 28);
                uiImageButton4.Location = new Point(133, 28);

                // 调整标签位置
                uiLabel1.Location = new Point(809, 659);
                uiLabel2.Location = new Point(304, 659);
                uiLabel3.Location = new Point(97, 612);
                uiLabel4.Location = new Point(97, 652);

                // 调整进度条
                uiTrackBar1.Location = new Point(355, 659);
                uiTrackBar1.Size = new Size(448, 15);

                // 调整底部按钮
                uiImageButton5.Location = new Point(561, 606);
                uiImageButton6.Location = new Point(509, 606);
                uiImageButton7.Location = new Point(616, 605);
                uiImageButton8.Location = new Point(304, 612);
                uiImageButton9.Location = new Point(379, 613);
                uiImageButton10.Location = new Point(817, 606);
                uiImageButton11.Location = new Point(736, 607);
                uiImageButton12.Location = new Point(896, 628);
                uiImageButton13.Location = new Point(952, 628);
                uiImageButton14.Location = new Point(1005, 628);

                // 调整返回按钮
                Back.Location = new Point(26, 655);
                if (uiImageButton15 != null && this.Controls.Contains(uiImageButton15))
                {
                    this.Controls.Remove(uiImageButton15);
                    uiImageButton15.Dispose();
                    uiImageButton15 = null;
                }

                if (uiImageButton16 != null && this.Controls.Contains(uiImageButton16))
                {
                    this.Controls.Remove(uiImageButton16);
                    uiImageButton16.Dispose();
                    uiImageButton16 = null;
                }
            }
            else
            {
                // 切换回第一个窗体形态
                // 恢复pictureBox2
                pictureBox2.Location = new Point(190, 10);
                pictureBox2.Size = new Size(860, 580);

                // 恢复panel1
                panel1.Location = new Point(6, 10);
                panel1.Size = new Size(169, 627);

                // 恢复panel2
                panel2.Location = new Point(209, 65);
                panel2.Size = new Size(824, 512);

                // 恢复pictureBox1
                pictureBox1.Location = new Point(190, 593);
                pictureBox1.Size = new Size(860, 100);

                // 恢复按钮位置
                uiImageButton1.Location = new Point(1003, 29);
                uiImageButton3.Location = new Point(956, 29);
                uiImageButton2.Location = new Point(209, 29);
                uiImageButton4.Location = new Point(245, 29);

                // 恢复标签位置
                uiLabel1.Location = new Point(807, 660);
                uiLabel2.Location = new Point(416, 660);
                uiLabel3.Location = new Point(209, 613);
                uiLabel4.Location = new Point(209, 646);

                // 恢复进度条
                uiTrackBar1.Location = new Point(467, 660);
                uiTrackBar1.Size = new Size(334, 15);

                // 恢复底部按钮
                uiImageButton5.Location = new Point(620, 607);
                uiImageButton6.Location = new Point(572, 607);
                uiImageButton7.Location = new Point(670, 607);
                uiImageButton8.Location = new Point(416, 613);
                uiImageButton9.Location = new Point(467, 613);
                uiImageButton10.Location = new Point(815, 607);
                uiImageButton11.Location = new Point(765, 607);
                uiImageButton12.Location = new Point(894, 629);
                uiImageButton13.Location = new Point(950, 629);
                uiImageButton14.Location = new Point(1003, 629);

                // 恢复返回按钮
                Back.Location = new Point(24, 656);
                if (uiImageButton15 == null)
                {
                    uiImageButton15 = new Sunny.UI.UIImageButton();
                    // 初始化 uiImageButton15 的属性
                    uiImageButton15.Anchor = AnchorStyles.None;
                    uiImageButton15.BackColor = Color.Transparent;
                    uiImageButton15.Cursor = Cursors.Hand;
                    uiImageButton15.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
                    uiImageButton15.Image = (Image)resources.GetObject("uiImageButton15.Image");
                    uiImageButton15.ImageHover = (Image)resources.GetObject("uiImageButton15.ImageHover");
                    uiImageButton15.Location = new Point(75, 654);
                    uiImageButton15.Name = "uiImageButton15";
                    uiImageButton15.Size = new Size(35, 35);
                    uiImageButton15.SizeMode = PictureBoxSizeMode.StretchImage;
                    uiImageButton15.TabIndex = 28;
                    uiImageButton15.TabStop = false;
                    uiImageButton15.Text = null;
                    uiImageButton15.ZoomScaleDisabled = true;
                    this.Controls.Add(uiImageButton15);
                }

                if (uiImageButton16 == null)
                {
                    uiImageButton16 = new Sunny.UI.UIImageButton();
                    // 初始化 uiImageButton16 的属性
                    uiImageButton16.Anchor = AnchorStyles.None;
                    uiImageButton16.BackColor = Color.Transparent;
                    uiImageButton16.Cursor = Cursors.Hand;
                    uiImageButton16.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
                    uiImageButton16.Image = (Image)resources.GetObject("uiImageButton16.Image");
                    uiImageButton16.ImageHover = (Image)resources.GetObject("uiImageButton16.ImageHover");
                    uiImageButton16.Location = new Point(125, 656);
                    uiImageButton16.Name = "uiImageButton16";
                    uiImageButton16.Size = new Size(33, 33);
                    uiImageButton16.SizeMode = PictureBoxSizeMode.StretchImage;
                    uiImageButton16.TabIndex = 29;
                    uiImageButton16.TabStop = false;
                    uiImageButton16.Text = null;
                    uiImageButton16.ZoomScaleDisabled = true;
                    this.Controls.Add(uiImageButton16);
                }
            }

            isFirstForm = !isFirstForm; // 切换状态
        
        }
    }

}
