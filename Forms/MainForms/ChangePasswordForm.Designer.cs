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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangePasswordForm));
            lblOldPwd = new UILabel();
            txtOldPassword = new UITextBox();
            lblNewPwd = new UILabel();
            txtNewPassword = new UITextBox();
            lblConfirm = new UILabel();
            txtConfirm = new UITextBox();
            btnConfirm = new UIButton();
            lblError = new UILabel();
            SuspendLayout();
            // 
            // lblOldPwd
            // 
            lblOldPwd.Font = new Font("黑体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            lblOldPwd.ForeColor = Color.FromArgb(48, 48, 48);
            lblOldPwd.Location = new Point(28, 69);
            lblOldPwd.Name = "lblOldPwd";
            lblOldPwd.Size = new Size(100, 23);
            lblOldPwd.TabIndex = 7;
            lblOldPwd.Text = "原密码：";
            // 
            // txtOldPassword
            // 
            txtOldPassword.Font = new Font("微软雅黑", 12F);
            txtOldPassword.Location = new Point(128, 63);
            txtOldPassword.Margin = new Padding(4, 5, 4, 5);
            txtOldPassword.MinimumSize = new Size(1, 16);
            txtOldPassword.Name = "txtOldPassword";
            txtOldPassword.Padding = new Padding(5);
            txtOldPassword.RectColor = Color.FromArgb(163, 199, 224);
            txtOldPassword.RectDisableColor = Color.FromArgb(163, 199, 224);
            txtOldPassword.RectReadOnlyColor = Color.FromArgb(163, 199, 224);
            txtOldPassword.ShowText = false;
            txtOldPassword.Size = new Size(250, 29);
            txtOldPassword.TabIndex = 6;
            txtOldPassword.TextAlignment = ContentAlignment.MiddleLeft;
            txtOldPassword.Watermark = "";
            // 
            // lblNewPwd
            // 
            lblNewPwd.Font = new Font("黑体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            lblNewPwd.ForeColor = Color.FromArgb(48, 48, 48);
            lblNewPwd.Location = new Point(28, 114);
            lblNewPwd.Name = "lblNewPwd";
            lblNewPwd.Size = new Size(100, 23);
            lblNewPwd.TabIndex = 5;
            lblNewPwd.Text = "新密码：";
            // 
            // txtNewPassword
            // 
            txtNewPassword.Font = new Font("微软雅黑", 12F);
            txtNewPassword.Location = new Point(128, 108);
            txtNewPassword.Margin = new Padding(4, 5, 4, 5);
            txtNewPassword.MinimumSize = new Size(1, 16);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.Padding = new Padding(5);
            txtNewPassword.RectColor = Color.FromArgb(163, 199, 224);
            txtNewPassword.ShowText = false;
            txtNewPassword.Size = new Size(250, 29);
            txtNewPassword.TabIndex = 4;
            txtNewPassword.TextAlignment = ContentAlignment.MiddleLeft;
            txtNewPassword.Watermark = "";
            txtNewPassword.TextChanged += txtNewPassword_TextChanged;
            // 
            // lblConfirm
            // 
            lblConfirm.Font = new Font("黑体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            lblConfirm.ForeColor = Color.FromArgb(48, 48, 48);
            lblConfirm.Location = new Point(28, 163);
            lblConfirm.Name = "lblConfirm";
            lblConfirm.Size = new Size(100, 21);
            lblConfirm.TabIndex = 3;
            lblConfirm.Text = "确认密码：";
            // 
            // txtConfirm
            // 
            txtConfirm.Font = new Font("微软雅黑", 12F);
            txtConfirm.Location = new Point(128, 155);
            txtConfirm.Margin = new Padding(4, 5, 4, 5);
            txtConfirm.MinimumSize = new Size(1, 16);
            txtConfirm.Name = "txtConfirm";
            txtConfirm.Padding = new Padding(5);
            txtConfirm.RectColor = Color.FromArgb(163, 199, 224);
            txtConfirm.ShowText = false;
            txtConfirm.Size = new Size(250, 29);
            txtConfirm.TabIndex = 2;
            txtConfirm.TextAlignment = ContentAlignment.MiddleLeft;
            txtConfirm.Watermark = "";
            // 
            // btnConfirm
            // 
            btnConfirm.Cursor = Cursors.Hand;
            btnConfirm.FillColor = Color.FromArgb(163, 199, 224);
            btnConfirm.FillHoverColor = Color.FromArgb(166, 215, 231);
            btnConfirm.Font = new Font("黑体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnConfirm.Location = new Point(146, 218);
            btnConfirm.MinimumSize = new Size(1, 1);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.RectColor = Color.FromArgb(163, 199, 224);
            btnConfirm.RectHoverColor = Color.FromArgb(166, 215, 231);
            btnConfirm.RectPressColor = Color.FromArgb(166, 215, 231);
            btnConfirm.Size = new Size(100, 35);
            btnConfirm.TabIndex = 1;
            btnConfirm.Text = "确认";
            btnConfirm.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnConfirm.Click += btnConfirm_Click;
            // 
            // lblError
            // 
            lblError.Font = new Font("微软雅黑", 10F);
            lblError.ForeColor = Color.Red;
            lblError.Location = new Point(28, 188);
            lblError.Name = "lblError";
            lblError.Size = new Size(350, 20);
            lblError.TabIndex = 0;
            lblError.Visible = false;
            // 
            // ChangePasswordForm
            // 
            BackColor = Color.White;
            ClientSize = new Size(400, 267);
            ControlBoxFillHoverColor = Color.White;
            Controls.Add(lblError);
            Controls.Add(btnConfirm);
            Controls.Add(txtConfirm);
            Controls.Add(lblConfirm);
            Controls.Add(txtNewPassword);
            Controls.Add(lblNewPwd);
            Controls.Add(txtOldPassword);
            Controls.Add(lblOldPwd);
            Font = new Font("黑体", 12F, FontStyle.Bold, GraphicsUnit.Point, 134);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ChangePasswordForm";
            RectColor = Color.Black;
            Text = "修改密码";
            TitleColor = Color.FromArgb(163, 199, 224);
            TitleFont = new Font("黑体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            ZoomScaleRect = new Rectangle(15, 15, 400, 240);
            ResumeLayout(false);
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