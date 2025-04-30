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

        private void Back_Click_1(object sender, EventArgs e)
        {
            //Back.Image = Properties.Resources.slideup1;

        }
    }

}
