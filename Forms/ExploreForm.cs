using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Byte_Harmonic.Forms.FormUtils;
using Sunny.UI;
using System.Drawing.Printing;
using ByteHarmonic.Forms;

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
            MainForm main = this.FindForm() as MainForm;
            if (main != null)
            {
                main.Close();
            }
        }

        private void MinButton_Click(object sender, EventArgs e)
        {
            // 获取主窗体引用
            MainForm main = this.FindForm() as MainForm;
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
    }

}
