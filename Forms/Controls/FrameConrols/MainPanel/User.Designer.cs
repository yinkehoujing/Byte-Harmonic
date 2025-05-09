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
            lblAccount = new UILabel();
            txtUsername = new UITextBox();
            btnLogout = new UIButton();
            btnChangePwd = new UIButton();
            lblMySonglists = new UILabel();
            uiLabel1 = new UILabel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            uiLabel2 = new UILabel();
            SuspendLayout();
            // 
            // lblAccount
            // 
            lblAccount.Font = new Font("黑体", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 134);
            lblAccount.ForeColor = Color.FromArgb(48, 48, 48);
            lblAccount.Location = new Point(30, 71);
            lblAccount.Name = "lblAccount";
            lblAccount.Size = new Size(300, 30);
            lblAccount.TabIndex = 5;
            lblAccount.Text = "账号：";
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("黑体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtUsername.Location = new Point(137, 106);
            txtUsername.Margin = new Padding(4, 5, 4, 5);
            txtUsername.MinimumSize = new Size(1, 16);
            txtUsername.Name = "txtUsername";
            txtUsername.Padding = new Padding(5);
            txtUsername.RectColor = Color.FromArgb(163, 199, 224);
            txtUsername.ScrollBarColor = Color.FromArgb(163, 199, 224);
            txtUsername.ScrollBarStyleInherited = false;
            txtUsername.ShowText = false;
            txtUsername.Size = new Size(215, 35);
            txtUsername.TabIndex = 4;
            txtUsername.TextAlignment = ContentAlignment.MiddleLeft;
            txtUsername.Watermark = "";
            txtUsername.TextChanged += txtUsername_TextChanged;
            // 
            // btnLogout
            // 
            btnLogout.FillColor = Color.FromArgb(163, 199, 224);
            btnLogout.FillColor2 = Color.FromArgb(163, 199, 224);
            btnLogout.FillHoverColor = Color.FromArgb(166, 215, 231);
            btnLogout.FillPressColor = Color.FromArgb(166, 215, 231);
            btnLogout.FillSelectedColor = Color.FromArgb(166, 215, 231);
            btnLogout.Font = new Font("黑体", 12F);
            btnLogout.Location = new Point(471, 109);
            btnLogout.MinimumSize = new Size(1, 1);
            btnLogout.Name = "btnLogout";
            btnLogout.RectColor = Color.FromArgb(163, 199, 224);
            btnLogout.RectHoverColor = Color.FromArgb(166, 215, 231);
            btnLogout.Size = new Size(84, 32);
            btnLogout.TabIndex = 3;
            btnLogout.Text = "退出登录";
            btnLogout.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnLogout.Click += btnLogout_Click;
            // 
            // btnChangePwd
            // 
            btnChangePwd.FillColor = Color.FromArgb(163, 199, 224);
            btnChangePwd.FillColor2 = Color.FromArgb(163, 199, 224);
            btnChangePwd.FillHoverColor = Color.FromArgb(166, 215, 231);
            btnChangePwd.FillPressColor = Color.FromArgb(166, 215, 231);
            btnChangePwd.FillSelectedColor = Color.FromArgb(166, 215, 231);
            btnChangePwd.Font = new Font("黑体", 12F);
            btnChangePwd.Location = new Point(381, 111);
            btnChangePwd.MinimumSize = new Size(1, 1);
            btnChangePwd.Name = "btnChangePwd";
            btnChangePwd.RectColor = Color.FromArgb(163, 199, 224);
            btnChangePwd.RectHoverColor = Color.FromArgb(166, 215, 231);
            btnChangePwd.Size = new Size(84, 30);
            btnChangePwd.TabIndex = 2;
            btnChangePwd.Text = "修改密码";
            btnChangePwd.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnChangePwd.Click += btnChangePwd_Click;
            // 
            // lblMySonglists
            // 
            lblMySonglists.Font = new Font("黑体", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 134);
            lblMySonglists.ForeColor = Color.FromArgb(48, 48, 48);
            lblMySonglists.Location = new Point(30, 156);
            lblMySonglists.Name = "lblMySonglists";
            lblMySonglists.Size = new Size(100, 23);
            lblMySonglists.TabIndex = 0;
            lblMySonglists.Text = "我的歌单";
            // 
            // uiLabel1
            // 
            uiLabel1.Font = new Font("黑体", 18F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLabel1.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel1.Location = new Point(30, 24);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new Size(116, 30);
            uiLabel1.TabIndex = 6;
            uiLabel1.Text = "个人主页";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(30, 182);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(657, 313);
            flowLayoutPanel1.TabIndex = 7;
            // 
            // uiLabel2
            // 
            uiLabel2.Font = new Font("黑体", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLabel2.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel2.Location = new Point(30, 111);
            uiLabel2.Name = "uiLabel2";
            uiLabel2.Size = new Size(100, 26);
            uiLabel2.TabIndex = 8;
            uiLabel2.Text = "用户名：";
            // 
            // UserForm
            // 
            Controls.Add(uiLabel2);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(uiLabel1);
            Controls.Add(lblMySonglists);
            Controls.Add(btnChangePwd);
            Controls.Add(btnLogout);
            Controls.Add(txtUsername);
            Controls.Add(lblAccount);
            Name = "UserForm";
            Size = new Size(824, 512);
            ResumeLayout(false);
        }

        #endregion

        private UILabel lblAccount;
        private UITextBox txtUsername;
        private UIButton btnLogout;
        private UIButton btnChangePwd;
        private UILabel lblMySonglists;
        private UILabel uiLabel1;
        private FlowLayoutPanel flowLayoutPanel1;
        private UILabel uiLabel2;
    }
}
