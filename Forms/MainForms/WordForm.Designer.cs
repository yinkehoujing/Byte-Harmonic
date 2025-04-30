namespace Byte_Harmonic.Forms
{
    partial class WordForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WordForm));
            uiImageButton1 = new Sunny.UI.UIImageButton();
            ExitButton = new Sunny.UI.UIImageButton();
            uiImageButton2 = new Sunny.UI.UIImageButton();
            ((System.ComponentModel.ISupportInitialize)uiImageButton1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ExitButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)uiImageButton2).BeginInit();
            SuspendLayout();
            // 
            // uiImageButton1
            // 
            uiImageButton1.BackColor = Color.Transparent;
            uiImageButton1.BackgroundImageLayout = ImageLayout.Stretch;
            uiImageButton1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiImageButton1.Image = (Image)resources.GetObject("uiImageButton1.Image");
            uiImageButton1.ImageHover = (Image)resources.GetObject("uiImageButton1.ImageHover");
            uiImageButton1.Location = new Point(657, 3);
            uiImageButton1.Margin = new Padding(2, 3, 2, 3);
            uiImageButton1.Name = "uiImageButton1";
            uiImageButton1.Size = new Size(19, 20);
            uiImageButton1.SizeMode = PictureBoxSizeMode.StretchImage;
            uiImageButton1.TabIndex = 15;
            uiImageButton1.TabStop = false;
            uiImageButton1.Text = null;
            // 
            // ExitButton
            // 
            ExitButton.BackColor = Color.Transparent;
            ExitButton.BackgroundImageLayout = ImageLayout.Stretch;
            ExitButton.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            ExitButton.Image = (Image)resources.GetObject("ExitButton.Image");
            ExitButton.ImageHover = (Image)resources.GetObject("ExitButton.ImageHover");
            ExitButton.Location = new Point(690, 3);
            ExitButton.Margin = new Padding(2, 3, 2, 3);
            ExitButton.Name = "ExitButton";
            ExitButton.Size = new Size(19, 20);
            ExitButton.SizeMode = PictureBoxSizeMode.StretchImage;
            ExitButton.TabIndex = 14;
            ExitButton.TabStop = false;
            ExitButton.Text = null;
            // 
            // uiImageButton2
            // 
            uiImageButton2.BackColor = Color.Transparent;
            uiImageButton2.BackgroundImageLayout = ImageLayout.Stretch;
            uiImageButton2.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiImageButton2.Image = (Image)resources.GetObject("uiImageButton2.Image");
            uiImageButton2.ImageHover = (Image)resources.GetObject("uiImageButton2.ImageHover");
            uiImageButton2.Location = new Point(621, 3);
            uiImageButton2.Margin = new Padding(2, 3, 2, 3);
            uiImageButton2.Name = "uiImageButton2";
            uiImageButton2.Size = new Size(19, 20);
            uiImageButton2.SizeMode = PictureBoxSizeMode.StretchImage;
            uiImageButton2.TabIndex = 16;
            uiImageButton2.TabStop = false;
            uiImageButton2.Text = null;
            uiImageButton2.Click += uiImageButton2_Click;
            // 
            // WordForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(720, 100);
            Controls.Add(uiImageButton2);
            Controls.Add(uiImageButton1);
            Controls.Add(ExitButton);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "WordForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "WordForm";
            ((System.ComponentModel.ISupportInitialize)uiImageButton1).EndInit();
            ((System.ComponentModel.ISupportInitialize)ExitButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)uiImageButton2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UIImageButton uiImageButton1;
        private Sunny.UI.UIImageButton ExitButton;
        private Sunny.UI.UIImageButton uiImageButton2;
    }
}