using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Byte_Harmonic.Services;
using Byte_Harmonic.Forms.MainForms;
using Byte_Harmonic.Models;
using Byte_Harmonic.Database;

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
            lblAccount.Text = $"账号：{currentUser.Account}";
            txtUsername.Text = currentUser.Username;

            // 加载歌单
            _songlists = await AppContext.songlistService.GetAllPlaylistsAsync();
            songlistPanel.Controls.Clear();

            foreach (var songlist in _songlists)
            {
                var item = new SonglistItem(songlist);
                item.Width = songlistPanel.Width - 20;
                songlistPanel.Controls.Add(item);
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

    // 自定义歌单项控件
    public class SonglistItem : UIPanel
    {
        private readonly Songlist _songlist;

        public SonglistItem(Songlist songlist)
        {
            _songlist = songlist;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            Height = 60;
            Padding = new Padding(10);
            Style = UIStyle.Blue;

            // 歌单名称
            var lblName = new UILabel
            {
                Text = _songlist.Name,
                Font = new System.Drawing.Font("微软雅黑", 12),
                Location = new System.Drawing.Point(20, 15)
            };

            // 操作按钮
            var btnManage = new UIButton
            {
                Text = "管理",
                Size = new System.Drawing.Size(80, 35),
                Location = new System.Drawing.Point(Width - 120, 12)
            };

            Controls.Add(lblName);
            Controls.Add(btnManage);
        }
    }
}
