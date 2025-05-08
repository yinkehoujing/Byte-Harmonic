using Byte_Harmonic.Forms.FormUtils;

namespace Byte_Harmonic.Forms.Controls.BaseControls
{
    partial class SongItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SongItem));
            uiCheckBox = new Sunny.UI.UICheckBox();
            uiLabel1 = new Sunny.UI.UILabel();
            deleteButton = new Sunny.UI.UIImageButton();
            addButton = new Sunny.UI.UIImageButton();
            downloadButton = new Sunny.UI.UIImageButton();
            playButton = new Sunny.UI.UIImageButton();
            ((System.ComponentModel.ISupportInitialize)deleteButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)addButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)downloadButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)playButton).BeginInit();
            SuspendLayout();
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
            uiCheckBox.TabIndex = 0;
            // 
            // uiLabel1
            // 
            uiLabel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            uiLabel1.Font = new Font("黑体", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLabel1.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel1.Location = new Point(40, 13);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new Size(601, 19);
            uiLabel1.TabIndex = 1;
            uiLabel1.Click += uiLabel1_Click;
            // 
            // deleteButton
            // 
            deleteButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            deleteButton.BackColor = Color.Transparent;
            deleteButton.Cursor = Cursors.Hand;
            deleteButton.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            deleteButton.Image = (Image)resources.GetObject("deleteButton.Image");
            deleteButton.ImageHover = (Image)resources.GetObject("deleteButton.ImageHover");
            deleteButton.Location = new Point(776, 10);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(24, 24);
            deleteButton.SizeMode = PictureBoxSizeMode.StretchImage;
            deleteButton.TabIndex = 6;
            deleteButton.TabStop = false;
            deleteButton.Text = null;
            deleteButton.ZoomScaleDisabled = true;
            deleteButton.Click += deleteButton1_Click;
            // 
            // addButton
            // 
            addButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            addButton.BackColor = Color.Transparent;
            addButton.Cursor = Cursors.Hand;
            addButton.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            addButton.Image = (Image)resources.GetObject("addButton.Image");
            addButton.ImageHover = (Image)resources.GetObject("addButton.ImageHover");
            addButton.Location = new Point(737, 10);
            addButton.Name = "addButton";
            addButton.Size = new Size(24, 24);
            addButton.SizeMode = PictureBoxSizeMode.StretchImage;
            addButton.TabIndex = 7;
            addButton.TabStop = false;
            addButton.Text = null;
            addButton.ZoomScaleDisabled = true;
            addButton.Click += addButton_Click;
            // 
            // downloadButton
            // 
            downloadButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            downloadButton.BackColor = Color.Transparent;
            downloadButton.Cursor = Cursors.Hand;
            downloadButton.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            downloadButton.Image = (Image)resources.GetObject("downloadButton.Image");
            downloadButton.ImageHover = (Image)resources.GetObject("downloadButton.ImageHover");
            downloadButton.Location = new Point(699, 10);
            downloadButton.Name = "downloadButton";
            downloadButton.Size = new Size(24, 24);
            downloadButton.SizeMode = PictureBoxSizeMode.StretchImage;
            downloadButton.TabIndex = 8;
            downloadButton.TabStop = false;
            downloadButton.Text = null;
            downloadButton.ZoomScaleDisabled = true;
            downloadButton.Click += downloadButton_Click;
            // 
            // playButton
            // 
            playButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            playButton.BackColor = Color.Transparent;
            playButton.Cursor = Cursors.Hand;
            playButton.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            playButton.Image = (Image)resources.GetObject("playButton.Image");
            playButton.ImageHover = (Image)resources.GetObject("playButton.ImageHover");
            playButton.Location = new Point(661, 10);
            playButton.Name = "playButton";
            playButton.Size = new Size(24, 24);
            playButton.SizeMode = PictureBoxSizeMode.StretchImage;
            playButton.TabIndex = 9;
            playButton.TabStop = false;
            playButton.Text = null;
            playButton.ZoomScaleDisabled = true;
            playButton.Click += playButton_Click;
            // 
            // SongItem
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(playButton);
            Controls.Add(downloadButton);
            Controls.Add(addButton);
            Controls.Add(deleteButton);
            Controls.Add(uiLabel1);
            Controls.Add(uiCheckBox);
            Name = "SongItem";
            Size = new Size(818, 45);
            ((System.ComponentModel.ISupportInitialize)deleteButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)addButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)downloadButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)playButton).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UICheckBox uiCheckBox;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UIImageButton deleteButton;
        private Sunny.UI.UIImageButton addButton;
        private Sunny.UI.UIImageButton downloadButton;
        private Sunny.UI.UIImageButton playButton;
    }
}
