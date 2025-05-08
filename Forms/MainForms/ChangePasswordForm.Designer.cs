using Sunny.UI;

namespace Byte_Harmonic.Forms.MainForms
{
    partial class ChangePasswordForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblOldPwd = new Sunny.UI.UILabel();
            this.txtOldPassword = new Sunny.UI.UITextBox();
            this.lblNewPwd = new Sunny.UI.UILabel();
            this.txtNewPassword = new Sunny.UI.UITextBox();
            this.lblConfirm = new Sunny.UI.UILabel();
            this.txtConfirm = new Sunny.UI.UITextBox();
            this.btnConfirm = new Sunny.UI.UIButton();
            this.lblError = new Sunny.UI.UILabel();
            this.SuspendLayout();

            // lblOldPwd
            this.lblOldPwd.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.lblOldPwd.Location = new System.Drawing.Point(30, 30);
            this.lblOldPwd.Size = new System.Drawing.Size(100, 23);
            this.lblOldPwd.Text = "原密码：";

            // txtOldPassword
            this.txtOldPassword.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.txtOldPassword.Location = new System.Drawing.Point(130, 27);
            this.txtOldPassword.Size = new System.Drawing.Size(250, 29);

            // lblNewPwd
            this.lblNewPwd.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.lblNewPwd.Location = new System.Drawing.Point(30, 80);
            this.lblNewPwd.Size = new System.Drawing.Size(100, 23);
            this.lblNewPwd.Text = "新密码：";

            // txtNewPassword
            this.txtNewPassword.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.txtNewPassword.Location = new System.Drawing.Point(130, 77);
            this.txtNewPassword.Size = new System.Drawing.Size(250, 29);

            // lblConfirm
            this.lblConfirm.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.lblConfirm.Location = new System.Drawing.Point(30, 130);
            this.lblConfirm.Size = new System.Drawing.Size(100, 23);
            this.lblConfirm.Text = "确认密码：";

            // txtConfirm
            this.txtConfirm.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.txtConfirm.Location = new System.Drawing.Point(130, 127);
            this.txtConfirm.Size = new System.Drawing.Size(250, 29);

            // btnConfirm
            this.btnConfirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirm.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnConfirm.Location = new System.Drawing.Point(150, 180);
            this.btnConfirm.Size = new System.Drawing.Size(100, 35);
            this.btnConfirm.Text = "确认";
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);

            // lblError
            this.lblError.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(30, 160);
            this.lblError.Size = new System.Drawing.Size(350, 20);
            this.lblError.Visible = false;

            // ChangePasswordForm
            this.ClientSize = new System.Drawing.Size(400, 240);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.txtConfirm);
            this.Controls.Add(this.lblConfirm);
            this.Controls.Add(this.txtNewPassword);
            this.Controls.Add(this.lblNewPwd);
            this.Controls.Add(this.txtOldPassword);
            this.Controls.Add(this.lblOldPwd);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangePasswordForm";
            this.Text = "修改密码";
            this.ResumeLayout(false);
        }

        #endregion

        private UILabel lblOldPwd;
        private UITextBox txtOldPassword;
        private UILabel lblNewPwd;
        private UITextBox txtNewPassword;
        private UILabel lblConfirm;
        private UITextBox txtConfirm;
        private UIButton btnConfirm;
        private UILabel lblError;
    }
}