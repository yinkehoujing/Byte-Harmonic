namespace Byte_Harmonic.Forms.MainForms
{
    partial class LibraryItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LibraryItem));
            viewButton = new Sunny.UI.UIImageButton();
            uiLabel1 = new Sunny.UI.UILabel();
            uiCheckBox = new Sunny.UI.UICheckBox();
            ((System.ComponentModel.ISupportInitialize)viewButton).BeginInit();
            SuspendLayout();
            // 
            // viewButton
            // 
            viewButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            viewButton.BackColor = Color.Transparent;
            viewButton.Cursor = Cursors.Hand;
            viewButton.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            viewButton.Image = (Image)resources.GetObject("viewButton.Image");
            viewButton.ImageHover = (Image)resources.GetObject("viewButton.ImageHover");
            viewButton.Location = new Point(426, 10);
            viewButton.Name = "viewButton";
            viewButton.Size = new Size(24, 24);
            viewButton.SizeMode = PictureBoxSizeMode.StretchImage;
            viewButton.TabIndex = 10;
            viewButton.TabStop = false;
            viewButton.Text = null;
            viewButton.ZoomScaleDisabled = true;
            viewButton.Click += viewButton_Click;
            // 
            // uiLabel1
            // 
            uiLabel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            uiLabel1.Font = new Font("黑体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLabel1.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel1.Location = new Point(45, 13);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new Size(374, 19);
            uiLabel1.TabIndex = 11;
            // 
            // uiCheckBox
            // 
            uiCheckBox.CheckBoxColor = Color.FromArgb(166, 215, 231);
            uiCheckBox.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiCheckBox.ForeColor = Color.FromArgb(48, 48, 48);
            uiCheckBox.Location = new Point(5, 8);
            uiCheckBox.MinimumSize = new Size(1, 1);
            uiCheckBox.Name = "uiCheckBox";
            uiCheckBox.Size = new Size(24, 29);
            uiCheckBox.TabIndex = 12;
            // 
            // LibraryItem
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(uiCheckBox);
            Controls.Add(uiLabel1);
            Controls.Add(viewButton);
            Name = "LibraryItem";
            Size = new Size(470, 45);
            ((System.ComponentModel.ISupportInitialize)viewButton).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UIImageButton viewButton;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UICheckBox uiCheckBox;
    }
}
