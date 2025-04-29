using Byte_Harmonic.Forms.FormUtils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Byte_Harmonic.Forms
{
    public partial class LoginForm : Form
    {
        private readonly MouseMove _mouseHandler;//用于鼠标控制窗口
        private readonly FormStyle _styleHandler;//用于更改窗口样式
        public LoginForm()
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);//双缓冲减少闪烁
            InitializeComponent();
            _mouseHandler = new MouseMove(this);
            _styleHandler = new FormStyle(this);
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void uiImageButton1_Click(object sender, EventArgs e)
        {
            if (usernameBox.Text == "")
            {
                uiLabel3.Text = "请填写账户名";
            }
            else if (passwordBox.Text == "")
            {
                uiLabel3.Text = "请填写密码";
            }
            else if (uiCheckBox1.Checked == false)
            {
                uiLabel3.Text = "请确认同意服务协议";
            }
        }

        private void uiTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void uiLabel1_Click(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void uiImageButton2_Click(object sender, EventArgs e)
        {
            if (uiImageButton2.Text == "注册")
            {
                uiImageButton2.Text = "登录";
                loginButton1.Text = "注册";
            }
            else
            {
                loginButton1.Text = "登录";
                uiImageButton2.Text = "注册";
            }
        }

        private void uiImageButton3_Click(object sender, EventArgs e)
        {

        }

        private void uiCheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
