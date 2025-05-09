using Sunny.UI;
using System;
using System.Windows.Forms;
using Byte_Harmonic.Services;
using Byte_Harmonic.Utils;
using System.Data.SqlClient;
using Byte_Harmonic.Database;

namespace Byte_Harmonic.Forms.MainForms
{
    public partial class ChangePasswordForm : UIForm
    {
        private readonly UserService _userService;

        public ChangePasswordForm()
        {
            InitializeComponent();
            var userRepo = AppContext.userRepository;
            var userService = AppContext.userService;
            _userService = userService;
            InitializeComponentStyle();
        }

        private void InitializeComponentStyle()
        {
            StyleCustomMode = true;
            txtOldPassword.PasswordChar = '*';
            txtNewPassword.PasswordChar = '*';
            txtConfirm.PasswordChar = '*';
        }

        private async void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                // 清空错误提示
                lblError.Visible = false;

                // 获取输入值
                var oldPwd = txtOldPassword.Text.Trim();
                var newPwd = txtNewPassword.Text.Trim();
                var confirmPwd = txtConfirm.Text.Trim();

                // 验证输入
                if (string.IsNullOrEmpty(oldPwd))
                    throw new ArgumentException("请输入原密码");
                if (string.IsNullOrEmpty(newPwd))
                    throw new ArgumentException("请输入新密码");
                if (string.IsNullOrEmpty(confirmPwd))
                    throw new ArgumentException("请确认新密码");
                if (newPwd != confirmPwd)
                    throw new ArgumentException("新密码与确认密码不一致");

                // 更新密码
                await _userService.ChangePassword(oldPwd, newPwd);
                new MainForms.MessageForm("密码修改成功").ShowDialog();
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (ArgumentException ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
                txtOldPassword.Focus();
            }
            catch (UnauthorizedAccessException ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
                txtOldPassword.Focus();
            }
            catch (Exception ex)
            {
                new Byte_Harmonic.Forms.MainForms.MessageForm($"密码修改失败：{ex.Message}").ShowDialog();
            }
        }

        private void txtNewPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}