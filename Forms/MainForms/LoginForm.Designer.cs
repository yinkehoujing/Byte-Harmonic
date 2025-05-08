using Byte_Harmonic.Forms.FormUtils;

namespace Byte_Harmonic.Forms.MainForms
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            loginButton1 = new Sunny.UI.UIImageButton();
            usernameBox = new Sunny.UI.UITextBox();
            logoBox = new PictureBox();
            uiLabel1 = new Sunny.UI.UILabel();
            uiLabel2 = new Sunny.UI.UILabel();
            passwordBox = new Sunny.UI.UITextBox();
            uiImageButton3 = new Sunny.UI.UIImageButton();
            uiCheckBox1 = new Sunny.UI.UICheckBox();
            ExitButton = new Sunny.UI.UIImageButton();
            uiImageButton1 = new Sunny.UI.UIImageButton();
            uiImageButton2 = new Sunny.UI.UIImageButton();
            uiLabel3 = new Sunny.UI.UILabel();
            ((System.ComponentModel.ISupportInitialize)loginButton1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)logoBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)uiImageButton3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ExitButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)uiImageButton1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)uiImageButton2).BeginInit();
            SuspendLayout();
            // 
            // loginButton1
            // 
            loginButton1.BackColor = Color.Transparent;
            loginButton1.BackgroundImageLayout = ImageLayout.Stretch;
            loginButton1.Cursor = Cursors.Hand;
            loginButton1.Font = new Font("黑体", 18F, FontStyle.Regular, GraphicsUnit.Point, 134);
            loginButton1.ForeColor = Color.White;
            loginButton1.ImageHover = (Image)resources.GetObject("loginButton1.ImageHover");
            loginButton1.Location = new Point(133, 385);
            loginButton1.Margin = new Padding(2, 3, 2, 3);
            loginButton1.Name = "loginButton1";
            loginButton1.Size = new Size(97, 42);
            loginButton1.SizeMode = PictureBoxSizeMode.StretchImage;
            loginButton1.TabIndex = 3;
            loginButton1.TabStop = false;
            loginButton1.Text = "登录";
            loginButton1.Click += uiImageButton1_Click;
            // 
            // usernameBox
            // 
            usernameBox.BackColor = Color.Transparent;
            usernameBox.ButtonFillColor = Color.White;
            usernameBox.ButtonStyleInherited = false;
            usernameBox.FillColor = Color.WhiteSmoke;
            usernameBox.FillColor2 = Color.Transparent;
            usernameBox.Font = new Font("黑体", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 134);
            usernameBox.Location = new Point(102, 180);
            usernameBox.Margin = new Padding(3, 4, 3, 4);
            usernameBox.MinimumSize = new Size(1, 14);
            usernameBox.Name = "usernameBox";
            usernameBox.Padding = new Padding(4);
            usernameBox.Radius = 10;
            usernameBox.RectSides = ToolStripStatusLabelBorderSides.None;
            usernameBox.ScrollBarBackColor = SystemColors.ActiveCaption;
            usernameBox.ScrollBarStyleInherited = false;
            usernameBox.ShowText = false;
            usernameBox.Size = new Size(210, 32);
            usernameBox.TabIndex = 5;
            usernameBox.TextAlignment = ContentAlignment.MiddleLeft;
            usernameBox.Watermark = "";
            usernameBox.TextChanged += uiTextBox1_TextChanged;
            // 
            // logoBox
            // 
            logoBox.BackColor = Color.Transparent;
            logoBox.BackgroundImage = (Image)resources.GetObject("logoBox.BackgroundImage");
            logoBox.BackgroundImageLayout = ImageLayout.Stretch;
            logoBox.Location = new Point(153, 75);
            logoBox.Margin = new Padding(2, 3, 2, 3);
            logoBox.Name = "logoBox";
            logoBox.Size = new Size(61, 60);
            logoBox.TabIndex = 6;
            logoBox.TabStop = false;
            // 
            // uiLabel1
            // 
            uiLabel1.BackColor = Color.Transparent;
            uiLabel1.Font = new Font("黑体", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLabel1.ForeColor = Color.White;
            uiLabel1.Location = new Point(23, 182);
            uiLabel1.Margin = new Padding(2, 0, 2, 0);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new Size(74, 30);
            uiLabel1.TabIndex = 8;
            uiLabel1.Text = "账户名";
            uiLabel1.Click += uiLabel1_Click;
            // 
            // uiLabel2
            // 
            uiLabel2.BackColor = Color.Transparent;
            uiLabel2.Font = new Font("黑体", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLabel2.ForeColor = Color.White;
            uiLabel2.Location = new Point(23, 247);
            uiLabel2.Margin = new Padding(2, 0, 2, 0);
            uiLabel2.Name = "uiLabel2";
            uiLabel2.Size = new Size(52, 31);
            uiLabel2.TabIndex = 9;
            uiLabel2.Text = "密码";
            // 
            // passwordBox
            // 
            passwordBox.BackColor = Color.Transparent;
            passwordBox.ButtonFillColor = Color.White;
            passwordBox.ButtonStyleInherited = false;
            passwordBox.FillColor = Color.WhiteSmoke;
            passwordBox.FillColor2 = Color.Transparent;
            passwordBox.Font = new Font("黑体", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 134);
            passwordBox.Location = new Point(102, 246);
            passwordBox.Margin = new Padding(3, 4, 3, 4);
            passwordBox.MinimumSize = new Size(1, 14);
            passwordBox.Name = "passwordBox";
            passwordBox.Padding = new Padding(4);
            passwordBox.PasswordChar = '*';
            passwordBox.Radius = 10;
            passwordBox.RectSides = ToolStripStatusLabelBorderSides.None;
            passwordBox.ScrollBarBackColor = SystemColors.ActiveCaption;
            passwordBox.ScrollBarStyleInherited = false;
            passwordBox.ShowText = false;
            passwordBox.Size = new Size(210, 32);
            passwordBox.TabIndex = 10;
            passwordBox.TextAlignment = ContentAlignment.MiddleLeft;
            passwordBox.Watermark = "";
            // 
            // uiImageButton3
            // 
            uiImageButton3.BackColor = Color.Transparent;
            uiImageButton3.BackgroundImageLayout = ImageLayout.Stretch;
            uiImageButton3.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiImageButton3.Image = (Image)resources.GetObject("uiImageButton3.Image");
            uiImageButton3.ImageHover = (Image)resources.GetObject("uiImageButton3.ImageHover");
            uiImageButton3.Location = new Point(68, 246);
            uiImageButton3.Margin = new Padding(2, 3, 2, 3);
            uiImageButton3.Name = "uiImageButton3";
            uiImageButton3.Size = new Size(19, 20);
            uiImageButton3.SizeMode = PictureBoxSizeMode.StretchImage;
            uiImageButton3.TabIndex = 15;
            uiImageButton3.TabStop = false;
            uiImageButton3.Text = null;
            uiImageButton3.Click += uiImageButton3_Click;
            // 
            // uiCheckBox1
            // 
            uiCheckBox1.BackColor = Color.Transparent;
            uiCheckBox1.CheckBoxColor = Color.FromArgb(166, 215, 231);
            uiCheckBox1.Font = new Font("黑体", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiCheckBox1.ForeColor = Color.White;
            uiCheckBox1.Location = new Point(87, 304);
            uiCheckBox1.Margin = new Padding(2, 3, 2, 3);
            uiCheckBox1.MinimumSize = new Size(1, 1);
            uiCheckBox1.Name = "uiCheckBox1";
            uiCheckBox1.Size = new Size(185, 31);
            uiCheckBox1.TabIndex = 11;
            uiCheckBox1.Text = "已阅读并同意服务协议";
            uiCheckBox1.CheckedChanged += uiCheckBox1_CheckedChanged;
            // 
            // ExitButton
            // 
            ExitButton.BackColor = Color.Transparent;
            ExitButton.BackgroundImageLayout = ImageLayout.Stretch;
            ExitButton.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            ExitButton.Image = (Image)resources.GetObject("ExitButton.Image");
            ExitButton.ImageHover = (Image)resources.GetObject("ExitButton.ImageHover");
            ExitButton.Location = new Point(330, 10);
            ExitButton.Margin = new Padding(2, 3, 2, 3);
            ExitButton.Name = "ExitButton";
            ExitButton.Size = new Size(19, 20);
            ExitButton.SizeMode = PictureBoxSizeMode.StretchImage;
            ExitButton.TabIndex = 12;
            ExitButton.TabStop = false;
            ExitButton.Text = null;
            ExitButton.Click += ExitButton_Click;
            // 
            // uiImageButton1
            // 
            uiImageButton1.BackColor = Color.Transparent;
            uiImageButton1.BackgroundImageLayout = ImageLayout.Stretch;
            uiImageButton1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiImageButton1.Image = (Image)resources.GetObject("uiImageButton1.Image");
            uiImageButton1.ImageHover = (Image)resources.GetObject("uiImageButton1.ImageHover");
            uiImageButton1.Location = new Point(297, 10);
            uiImageButton1.Margin = new Padding(2, 3, 2, 3);
            uiImageButton1.Name = "uiImageButton1";
            uiImageButton1.Size = new Size(19, 20);
            uiImageButton1.SizeMode = PictureBoxSizeMode.StretchImage;
            uiImageButton1.TabIndex = 13;
            uiImageButton1.TabStop = false;
            uiImageButton1.Text = null;
            uiImageButton1.Click += uiImageButton1_Click_1;
            // 
            // uiImageButton2
            // 
            uiImageButton2.BackColor = Color.Transparent;
            uiImageButton2.BackgroundImageLayout = ImageLayout.Stretch;
            uiImageButton2.Cursor = Cursors.Hand;
            uiImageButton2.Font = new Font("黑体", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiImageButton2.ForeColor = Color.White;
            uiImageButton2.ImageHover = (Image)resources.GetObject("uiImageButton2.ImageHover");
            uiImageButton2.Location = new Point(297, 45);
            uiImageButton2.Margin = new Padding(2, 3, 2, 3);
            uiImageButton2.Name = "uiImageButton2";
            uiImageButton2.Size = new Size(52, 26);
            uiImageButton2.SizeMode = PictureBoxSizeMode.StretchImage;
            uiImageButton2.TabIndex = 14;
            uiImageButton2.TabStop = false;
            uiImageButton2.Text = "注册";
            uiImageButton2.Click += uiImageButton2_Click;
            // 
            // uiLabel3
            // 
            uiLabel3.BackColor = Color.Transparent;
            uiLabel3.Font = new Font("黑体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLabel3.ForeColor = Color.PeachPuff;
            uiLabel3.Location = new Point(23, 338);
            uiLabel3.Margin = new Padding(2, 0, 2, 0);
            uiLabel3.Name = "uiLabel3";
            uiLabel3.Size = new Size(326, 30);
            uiLabel3.TabIndex = 16;
            uiLabel3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(360, 480);
            Controls.Add(uiLabel3);
            Controls.Add(uiImageButton2);
            Controls.Add(uiImageButton1);
            Controls.Add(ExitButton);
            Controls.Add(uiImageButton3);
            Controls.Add(uiCheckBox1);
            Controls.Add(passwordBox);
            Controls.Add(uiLabel2);
            Controls.Add(uiLabel1);
            Controls.Add(logoBox);
            Controls.Add(usernameBox);
            Controls.Add(loginButton1);
            DoubleBuffered = true;
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2, 3, 2, 3);
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoginForm";
            Load += LoginForm_Load;
            ((System.ComponentModel.ISupportInitialize)loginButton1).EndInit();
            ((System.ComponentModel.ISupportInitialize)logoBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)uiImageButton3).EndInit();
            ((System.ComponentModel.ISupportInitialize)ExitButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)uiImageButton1).EndInit();
            ((System.ComponentModel.ISupportInitialize)uiImageButton2).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Sunny.UI.UIImageButton loginButton1;
        private Sunny.UI.UITextBox usernameBox;
        private PictureBox logoBox;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UITextBox passwordBox;
        private Sunny.UI.UICheckBox uiCheckBox1;
        private Sunny.UI.UIImageButton ExitButton;
        private Sunny.UI.UIImageButton uiImageButton1;
        private Sunny.UI.UIImageButton uiImageButton2;
        private Sunny.UI.UIImageButton uiImageButton3;
        private Sunny.UI.UILabel uiLabel3;
    }
}