using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Byte_Harmonic.Services;
using Byte_Harmonic.Forms.MainForms;
using Byte_Harmonic.Models;
using Byte_Harmonic.Database;
using Byte_Harmonic.Forms.Controls.BaseControls;

namespace Byte_Harmonic.Forms.Controls.FrameControls.MainPanel
{
    public partial class UserForm :UserControl
    {
        private List<Songlist> _songlists;
        public UserForm()
        {
            InitializeComponent();
            LoadUserData();
        }

        //载入数据
        private async void LoadUserData()
        {
            var currentUser = AppContext.userService.GetCurrentUser();

            // 用户信息
            lblAccount.Text = $"账号：     {currentUser.Account}";
            txtUsername.Text = currentUser.Username;

            // 加载歌单
            _songlists = AppContext.songlistService.GetCurrentUserSonglists();
            flowLayoutPanel1.Controls.Clear();
            int num = 1;
            foreach (var songlist in _songlists)
            {
                num %= 13;
                num++;
                Control control = new BHButton("2 (" + num.ToString() + ")", "2 (" + num.ToString() + ")", songlist.Name);
                control.Tag = songlist.Id; // 将数据对象存储在Tag中
                control.Width = 155;
                flowLayoutPanel1.Controls.Add(control);
            }
        }

        // 修改用户名
        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            if (txtUsername.Modified)
            {
                try
                {
                    AppContext.userService.UpdateUsername(txtUsername.Text.Trim());
                    new MessageForm("已修改用户名").ShowDialog();
                }
                catch (Exception ex)
                {
                    UIMessageBox.ShowError($"修改失败：{ex.Message}");
                    txtUsername.Text = AppContext.userService.GetCurrentUser().Username;
                }
            }
        }

        // 退出登录
        private void btnLogout_Click(object sender, EventArgs e)
        {
            AppContext.userService.Logout();
            var loginForm = new LoginForm();
            this.Hide();
            loginForm.Show();
            MainForm main = this.FindForm() as MainForm;
            if (main != null)
            {
                main.Close();
            }
        }

        // 修改密码
        private void btnChangePwd_Click(object sender, EventArgs e)
        {
            var changePwdForm = new ChangePasswordForm();
            if (changePwdForm.ShowDialog() == DialogResult.OK)
            {
                LoadUserData(); // 刷新数据
            }
        }
    }
}
