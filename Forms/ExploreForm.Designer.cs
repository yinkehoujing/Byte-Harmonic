namespace Byte_Harmonic.Forms
{
    partial class ExploreForm
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExploreForm));
            uiImageButton1 = new Sunny.UI.UIImageButton();
            Back = new Sunny.UI.UIImageButton();
            pictureBox2 = new PictureBox();
            uiImageButton2 = new Sunny.UI.UIImageButton();
            ((System.ComponentModel.ISupportInitialize)uiImageButton1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Back).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)uiImageButton2).BeginInit();
            SuspendLayout();
            // 
            // uiImageButton1
            // 
            uiImageButton1.Anchor = AnchorStyles.None;
            uiImageButton1.BackColor = Color.Transparent;
            uiImageButton1.Cursor = Cursors.Hand;
            uiImageButton1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiImageButton1.Image = (Image)resources.GetObject("uiImageButton1.Image");
            uiImageButton1.ImageHover = (Image)resources.GetObject("uiImageButton1.ImageHover");
            uiImageButton1.Location = new Point(986, 29);
            uiImageButton1.Name = "uiImageButton1";
            uiImageButton1.Size = new Size(33, 33);
            uiImageButton1.SizeMode = PictureBoxSizeMode.StretchImage;
            uiImageButton1.TabIndex = 5;
            uiImageButton1.TabStop = false;
            uiImageButton1.Text = null;
            uiImageButton1.ZoomScaleDisabled = true;
            // 
            // Back
            // 
            Back.Anchor = AnchorStyles.None;
            Back.BackColor = Color.Transparent;
            Back.Cursor = Cursors.Hand;
            Back.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            Back.Image = (Image)resources.GetObject("Back.Image");
            Back.ImageHover = (Image)resources.GetObject("Back.ImageHover");
            Back.Location = new Point(6, 661);
            Back.Name = "Back";
            Back.Size = new Size(33, 33);
            Back.SizeMode = PictureBoxSizeMode.StretchImage;
            Back.TabIndex = 3;
            Back.TabStop = false;
            Back.Text = null;
            Back.ZoomScaleDisabled = true;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.White;
            pictureBox2.Location = new Point(194, 6);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(860, 580);
            pictureBox2.TabIndex = 4;
            pictureBox2.TabStop = false;
            // 
            // uiImageButton2
            // 
            uiImageButton2.Anchor = AnchorStyles.None;
            uiImageButton2.BackColor = Color.Transparent;
            uiImageButton2.Cursor = Cursors.Hand;
            uiImageButton2.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiImageButton2.Image = (Image)resources.GetObject("uiImageButton2.Image");
            uiImageButton2.ImageHover = (Image)resources.GetObject("uiImageButton2.ImageHover");
            uiImageButton2.Location = new Point(967, 626);
            uiImageButton2.Name = "uiImageButton2";
            uiImageButton2.Size = new Size(33, 33);
            uiImageButton2.SizeMode = PictureBoxSizeMode.StretchImage;
            uiImageButton2.TabIndex = 6;
            uiImageButton2.TabStop = false;
            uiImageButton2.Text = null;
            uiImageButton2.ZoomScaleDisabled = true;
            uiImageButton2.Click += uiImageButton2_Click_1;
            // 
            // ExploreForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(uiImageButton2);
            Controls.Add(uiImageButton1);
            Controls.Add(Back);
            Controls.Add(pictureBox2);
            Name = "ExploreForm";
            Size = new Size(1060, 700);
            ((System.ComponentModel.ISupportInitialize)uiImageButton1).EndInit();
            ((System.ComponentModel.ISupportInitialize)Back).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)uiImageButton2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UIImageButton uiImageButton1;
        private Sunny.UI.UIImageButton Back;
        private PictureBox pictureBox2;
        private Sunny.UI.UIImageButton uiImageButton2;
    }
}
