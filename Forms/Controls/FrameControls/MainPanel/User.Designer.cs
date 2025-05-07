using Sunny.UI;

namespace Byte_Harmonic.Forms.Controls.FrameControls.MainPanel
{
    partial class UserForm
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
            this.lblAccount = new Sunny.UI.UILabel();
            this.txtUsername = new Sunny.UI.UITextBox();
            this.btnLogout = new Sunny.UI.UIButton();
            this.btnChangePwd = new Sunny.UI.UIButton();
            this.songlistPanel = new Sunny.UI.UIPanel();
            this.lblMySonglists = new Sunny.UI.UILabel();
            this.SuspendLayout();

            // lblAccount
            this.lblAccount.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.lblAccount.Location = new System.Drawing.Point(30, 30);
            this.lblAccount.Size = new System.Drawing.Size(300, 30);
            this.lblAccount.Text = "账号：";

            // txtUsername
            this.txtUsername.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.txtUsername.Location = new System.Drawing.Point(30, 70);
            this.txtUsername.Size = new System.Drawing.Size(200, 35);
            this.txtUsername.TextChanged += new System.EventHandler(this.txtUsername_TextChanged);

            // btnLogout
            this.btnLogout.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnLogout.Location = new System.Drawing.Point(400, 30);
            this.btnLogout.Size = new System.Drawing.Size(120, 40);
            this.btnLogout.Text = "退出登录";
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

            // btnChangePwd
            this.btnChangePwd.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnChangePwd.Location = new System.Drawing.Point(400, 90);
            this.btnChangePwd.Size = new System.Drawing.Size(120, 40);
            this.btnChangePwd.Text = "修改密码";
            this.btnChangePwd.Click += new System.EventHandler(this.btnChangePwd_Click);

            // songlistPanel
            this.songlistPanel.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.songlistPanel.Location = new System.Drawing.Point(30, 150);
            this.songlistPanel.Size = new System.Drawing.Size(500, 400);
            this.songlistPanel.AutoScroll = true;

            // lblMySonglists
            this.lblMySonglists.Font = new System.Drawing.Font("微软雅黑", 14F, FontStyle.Bold);
            this.lblMySonglists.Location = new System.Drawing.Point(30, 120);
            this.lblMySonglists.Text = "我的歌单";

            // UserForm
            this.ClientSize = new System.Drawing.Size(600, 600);
            this.Controls.Add(this.lblMySonglists);
            this.Controls.Add(this.songlistPanel);
            this.Controls.Add(this.btnChangePwd);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblAccount);
            this.Text = "个人主页";
            this.ResumeLayout(false);
        }

        #endregion

        private UILabel lblAccount;
        private UITextBox txtUsername;
        private UIButton btnLogout;
        private UIButton btnChangePwd;
        private UIPanel songlistPanel;
        private UILabel lblMySonglists;
    }
}
