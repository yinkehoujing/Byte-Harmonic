namespace Byte_Harmonic.Forms.Controls.FrameControls.MainPanel
{
    partial class SongsList
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
            uiTextBox1 = new Sunny.UI.UITextBox();
            uiImageButton1 = new Sunny.UI.UIImageButton();
            ((System.ComponentModel.ISupportInitialize)uiImageButton1).BeginInit();
            SuspendLayout();
            // 
            // uiTextBox1
            // 
            uiTextBox1.ButtonFillColor = Color.Transparent;
            uiTextBox1.ButtonFillHoverColor = Color.FromArgb(224, 224, 224);
            uiTextBox1.ButtonFillPressColor = Color.White;
            uiTextBox1.ButtonForeColor = Color.Black;
            uiTextBox1.ButtonForeHoverColor = SystemColors.ActiveCaption;
            uiTextBox1.ButtonForePressColor = SystemColors.ActiveCaption;
            uiTextBox1.ButtonRectColor = Color.Black;
            uiTextBox1.ButtonRectHoverColor = Color.Black;
            uiTextBox1.ButtonRectPressColor = Color.Black;
            uiTextBox1.ButtonStyleInherited = false;
            uiTextBox1.CanEmpty = true;
            uiTextBox1.Font = new Font("黑体", 15.75F);
            uiTextBox1.ForeColor = Color.Black;
            uiTextBox1.ForeDisableColor = Color.Black;
            uiTextBox1.ForeReadOnlyColor = Color.Black;
            uiTextBox1.Location = new Point(23, 22);
            uiTextBox1.Margin = new Padding(4, 5, 4, 5);
            uiTextBox1.MinimumSize = new Size(1, 16);
            uiTextBox1.Name = "uiTextBox1";
            uiTextBox1.Padding = new Padding(5);
            uiTextBox1.RectColor = Color.Black;
            uiTextBox1.RectDisableColor = Color.Black;
            uiTextBox1.RectReadOnlyColor = Color.Black;
            uiTextBox1.ShowText = false;
            uiTextBox1.Size = new Size(265, 45);
            uiTextBox1.SymbolColor = Color.White;
            uiTextBox1.TabIndex = 0;
            uiTextBox1.Text = "歌单名";
            uiTextBox1.TextAlignment = ContentAlignment.MiddleLeft;
            uiTextBox1.Watermark = "";
            uiTextBox1.WatermarkActiveColor = Color.Transparent;
            uiTextBox1.WatermarkColor = Color.Transparent;
            // 
            // uiImageButton1
            // 
            uiImageButton1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiImageButton1.Image = Properties.Resources.icons8_delete_24;
            uiImageButton1.Location = new Point(308, 35);
            uiImageButton1.Name = "uiImageButton1";
            uiImageButton1.Size = new Size(28, 32);
            uiImageButton1.SizeMode = PictureBoxSizeMode.StretchImage;
            uiImageButton1.TabIndex = 1;
            uiImageButton1.TabStop = false;
            uiImageButton1.Text = null;
            uiImageButton1.Click += uiImageButton1_Click;
            // 
            // SongsList
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(uiImageButton1);
            Controls.Add(uiTextBox1);
            Margin = new Padding(4);
            Name = "SongsList";
            Size = new Size(1059, 602);
            ((System.ComponentModel.ISupportInitialize)uiImageButton1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UITextBox uiTextBox1;
        private Sunny.UI.UIImageButton uiImageButton1;
    }
}
