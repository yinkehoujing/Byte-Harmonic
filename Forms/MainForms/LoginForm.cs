using Byte_Harmonic.Database;
using Byte_Harmonic.Forms.FormUtils;
using Byte_Harmonic.Forms.MainForms;
using Byte_Harmonic.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Byte_Harmonic.Forms.MainForms
{
    public partial class LoginForm : Form
    {
        private readonly MouseMove _mouseHandler;//用于鼠标控制窗口
        private readonly FormStyle _styleHandler;//用于更改窗口样式
        private readonly SonglistRepository _songlistRepo;
        private readonly UserRepository _userRepo;
        private readonly UserService _userService;
        private readonly SearchService _searchService;
        private readonly string _connectionString =
            "server=localhost;user=root;database=Byte_Harmonic;port=3306;password=595129854";
        public LoginForm()
        {
            
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                         ControlStyles.AllPaintingInWmPaint, true);
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            _mouseHandler = new MouseMove(this);
            _styleHandler = new FormStyle(this);
            _userRepo = new UserRepository();
            _userService = new UserService(_userRepo);
           
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        //登录逻辑
        private   async  void  uiImageButton1_Click(object sender, EventArgs e)
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
            if (loginButton1.Text == "登录")
            {
                try
                {
                    // 调用登录
                    var user = await _userService.Login(usernameBox.Text.Trim(), passwordBox.Text.Trim());
                    if (user != null)
                    {
                        uiLabel3.Text = "登录成功";
                        await Task.Delay(1000); // 延迟1000毫秒（1秒）
                        MainForm mainForm = new MainForm();
                        mainForm.Show();
                        //隐藏当前界面；
                        this.Hide();
                    }
                    else
                    {
                        uiLabel3.Text = "账号或密码错误";
                    }
                }
                catch (Exception ex)
                {
                    uiLabel3.Text = "登录失败了: " + ex.Message;
                }
                AppContext.userService = _userService;

                AppContext.currentUser = _userService.GetCurrentUser();
            }
            else
            {
                try
                {
                    // 调用注册方法
                    await _userService.Register(usernameBox.Text.Trim(), passwordBox.Text.Trim());
                    uiLabel3.Text = "注册成功";
                }
                catch (Exception ex)
                {
                    uiLabel3.Text = "注册失败: " + ex.Message;
                }
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
        //密码可视化按钮
        private void uiImageButton3_Click(object sender, EventArgs e)
        {
            if (passwordBox.PasswordChar == '\0') // 如果当前密码不可见
            {
                passwordBox.PasswordChar = '*'; // 设置密码为不可见
               
            }
            else
            {
                passwordBox.PasswordChar = '\0'; // 设置密码为可见
            }
        }

        private void uiCheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void uiImageButton1_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
