using Byte_Harmonic.Forms.FormUtils;

namespace Byte_Harmonic.Forms.Controls.BaseControls
{
    partial class BHButton
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
            uiButton1 = new Sunny.UI.UIButton();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // uiButton1
            // 
            uiButton1.FillColor = Color.FromArgb(250, 250, 250);
            uiButton1.FillHoverColor = Color.FromArgb(238, 238, 238);
            uiButton1.FillPressColor = Color.FromArgb(238, 238, 238);
            uiButton1.Font = new Font("黑体", 15F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiButton1.ForeColor = Color.Black;
            uiButton1.ForeHoverColor = Color.Black;
            uiButton1.Location = new Point(0, 0);
            uiButton1.MinimumSize = new Size(1, 1);
            uiButton1.Name = "uiButton1";
            uiButton1.RectColor = Color.FromArgb(250, 250, 250);
            uiButton1.RectHoverColor = Color.FromArgb(250, 250, 250);
            uiButton1.RectPressColor = Color.FromArgb(250, 250, 250);
            uiButton1.RectSelectedColor = Color.FromArgb(250, 250, 250);
            uiButton1.RectSides = ToolStripStatusLabelBorderSides.None;
            uiButton1.Size = new Size(170, 51);
            uiButton1.TabIndex = 0;
            uiButton1.Text = "     text";
            uiButton1.TextAlign = ContentAlignment.MiddleLeft;
            uiButton1.TipsFont = new Font("黑体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiButton1.MouseEnter += BHButton_Enter;
            uiButton1.MouseLeave += BHButton_Leave;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Cursor = Cursors.Hand;
            pictureBox1.Location = new Point(15, 9);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(35, 35);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            pictureBox1.MouseEnter += BHButton_Enter;
            pictureBox1.MouseLeave += BHButton_Leave;
            // 
            // BHButton
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pictureBox1);
            Controls.Add(uiButton1);
            Name = "BHButton";
            Size = new Size(170, 54);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UIButton uiButton1;
        private PictureBox pictureBox1;
    }
}
