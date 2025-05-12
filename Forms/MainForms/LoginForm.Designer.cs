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
            loadingBox = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)loginButton1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)logoBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)uiImageButton3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ExitButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)uiImageButton1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)uiImageButton2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)loadingBox).BeginInit();
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
            loginButton1.Location = new Point(171, 453);
            loginButton1.Margin = new Padding(3, 4, 3, 4);
            loginButton1.Name = "loginButton1";
            loginButton1.Size = new Size(125, 49);
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
            usernameBox.Location = new Point(131, 212);
            usernameBox.Margin = new Padding(4, 5, 4, 5);
            usernameBox.MinimumSize = new Size(1, 16);
            usernameBox.Name = "usernameBox";
            usernameBox.Padding = new Padding(5);
            usernameBox.Radius = 10;
            usernameBox.RectSides = ToolStripStatusLabelBorderSides.None;
            usernameBox.ScrollBarBackColor = SystemColors.ActiveCaption;
            usernameBox.ScrollBarStyleInherited = false;
            usernameBox.ShowText = false;
            usernameBox.Size = new Size(270, 38);
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
            logoBox.Location = new Point(197, 88);
            logoBox.Margin = new Padding(3, 4, 3, 4);
            logoBox.Name = "logoBox";
            logoBox.Size = new Size(78, 71);
            logoBox.TabIndex = 6;
            logoBox.TabStop = false;
            // 
            // uiLabel1
            // 
            uiLabel1.BackColor = Color.Transparent;
            uiLabel1.Font = new Font("黑体", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLabel1.ForeColor = Color.White;
            uiLabel1.Location = new Point(30, 214);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new Size(95, 35);
            uiLabel1.TabIndex = 8;
            uiLabel1.Text = "账户名";
            uiLabel1.Click += uiLabel1_Click;
            // 
            // uiLabel2
            // 
            uiLabel2.BackColor = Color.Transparent;
            uiLabel2.Font = new Font("黑体", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLabel2.ForeColor = Color.White;
            uiLabel2.Location = new Point(30, 291);
            uiLabel2.Name = "uiLabel2";
            uiLabel2.Size = new Size(67, 36);
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
            passwordBox.ImeMode = ImeMode.On;
            passwordBox.Location = new Point(131, 289);
            passwordBox.Margin = new Padding(4, 5, 4, 5);
            passwordBox.MinimumSize = new Size(1, 16);
            passwordBox.Name = "passwordBox";
            passwordBox.Padding = new Padding(5);
            passwordBox.PasswordChar = '*';
            passwordBox.Radius = 10;
            passwordBox.RectSides = ToolStripStatusLabelBorderSides.None;
            passwordBox.ScrollBarBackColor = SystemColors.ActiveCaption;
            passwordBox.ScrollBarStyleInherited = false;
            passwordBox.ShowText = false;
            passwordBox.Size = new Size(270, 38);
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
            uiImageButton3.Location = new Point(87, 289);
            uiImageButton3.Margin = new Padding(3, 4, 3, 4);
            uiImageButton3.Name = "uiImageButton3";
            uiImageButton3.Size = new Size(24, 24);
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
            uiCheckBox1.Location = new Point(112, 358);
            uiCheckBox1.Margin = new Padding(3, 4, 3, 4);
            uiCheckBox1.MinimumSize = new Size(1, 1);
            uiCheckBox1.Name = "uiCheckBox1";
            uiCheckBox1.Size = new Size(238, 36);
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
            ExitButton.Location = new Point(424, 12);
            ExitButton.Margin = new Padding(3, 4, 3, 4);
            ExitButton.Name = "ExitButton";
            ExitButton.Size = new Size(24, 24);
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
            uiImageButton1.Location = new Point(382, 12);
            uiImageButton1.Margin = new Padding(3, 4, 3, 4);
            uiImageButton1.Name = "uiImageButton1";
            uiImageButton1.Size = new Size(24, 24);
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
            uiImageButton2.Location = new Point(382, 53);
            uiImageButton2.Margin = new Padding(3, 4, 3, 4);
            uiImageButton2.Name = "uiImageButton2";
            uiImageButton2.Size = new Size(67, 31);
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
            uiLabel3.Location = new Point(30, 398);
            uiLabel3.MaximumSize = new Size(419, 60);
            uiLabel3.Name = "uiLabel3";
            uiLabel3.Size = new Size(419, 35);
            uiLabel3.TabIndex = 16;
            uiLabel3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // loadingBox
            // 
            loadingBox.BackColor = Color.Transparent;
            loadingBox.BackgroundImageLayout = ImageLayout.Stretch;
            loadingBox.Image = (Image)resources.GetObject("loadingBox.Image");
            loadingBox.Location = new Point(213, 462);
            loadingBox.Margin = new Padding(3, 4, 3, 4);
            loadingBox.Name = "loadingBox";
            loadingBox.Size = new Size(45, 40);
            loadingBox.SizeMode = PictureBoxSizeMode.StretchImage;
            loadingBox.TabIndex = 17;
            loadingBox.TabStop = false;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(463, 565);
            Controls.Add(loadingBox);
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
            Margin = new Padding(3, 4, 3, 4);
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
            ((System.ComponentModel.ISupportInitialize)loadingBox).EndInit();
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
        private PictureBox loadingBox;
    }
}