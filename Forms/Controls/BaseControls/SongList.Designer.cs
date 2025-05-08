using Byte_Harmonic.Forms.FormUtils;

namespace Byte_Harmonic.Forms.Controls.BaseControls
{
    partial class SongList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SongList));
            BulkOperateButton = new Sunny.UI.UIButton();
            DeleteAllButton = new Sunny.UI.UIImageButton();
            AddAllButton = new Sunny.UI.UIImageButton();
            DownloadAllButton = new Sunny.UI.UIImageButton();
            StarAllButton = new Sunny.UI.UIImageButton();
            PlayAllButton = new Sunny.UI.UIImageButton();
            SelectAllButton = new Sunny.UI.UIButton();
            flowLayoutPanel = new FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)DeleteAllButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)AddAllButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DownloadAllButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)StarAllButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PlayAllButton).BeginInit();
            SuspendLayout();
            // 
            // BulkOperateButton
            // 
            BulkOperateButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BulkOperateButton.FillColor = Color.White;
            BulkOperateButton.FillColor2 = Color.Transparent;
            BulkOperateButton.FillHoverColor = Color.Silver;
            BulkOperateButton.FillPressColor = Color.FromArgb(166, 215, 231);
            BulkOperateButton.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            BulkOperateButton.ForeColor = Color.Black;
            BulkOperateButton.Location = new Point(719, 13);
            BulkOperateButton.MinimumSize = new Size(1, 1);
            BulkOperateButton.Name = "BulkOperateButton";
            BulkOperateButton.Radius = 10;
            BulkOperateButton.RectColor = Color.FromArgb(189, 189, 189);
            BulkOperateButton.RectHoverColor = Color.Transparent;
            BulkOperateButton.Size = new Size(87, 25);
            BulkOperateButton.TabIndex = 1;
            BulkOperateButton.Text = "批量处理";
            BulkOperateButton.TipsFont = new Font("黑体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            BulkOperateButton.Click += BulkOperateButton_Click;
            // 
            // DeleteAllButton
            // 
            DeleteAllButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            DeleteAllButton.BackColor = Color.White;
            DeleteAllButton.Cursor = Cursors.Hand;
            DeleteAllButton.Enabled = false;
            DeleteAllButton.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            DeleteAllButton.Image = (Image)resources.GetObject("DeleteAllButton.Image");
            DeleteAllButton.ImageHover = (Image)resources.GetObject("DeleteAllButton.ImageHover");
            DeleteAllButton.Location = new Point(782, 53);
            DeleteAllButton.Name = "DeleteAllButton";
            DeleteAllButton.Size = new Size(24, 24);
            DeleteAllButton.SizeMode = PictureBoxSizeMode.StretchImage;
            DeleteAllButton.TabIndex = 8;
            DeleteAllButton.TabStop = false;
            DeleteAllButton.Text = null;
            DeleteAllButton.Visible = false;
            DeleteAllButton.ZoomScaleDisabled = true;
            DeleteAllButton.Click += DeleteAllButton_Click;
            // 
            // AddAllButton
            // 
            AddAllButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            AddAllButton.BackColor = Color.White;
            AddAllButton.Cursor = Cursors.Hand;
            AddAllButton.Enabled = false;
            AddAllButton.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            AddAllButton.Image = (Image)resources.GetObject("AddAllButton.Image");
            AddAllButton.ImageHover = (Image)resources.GetObject("AddAllButton.ImageHover");
            AddAllButton.Location = new Point(743, 53);
            AddAllButton.Name = "AddAllButton";
            AddAllButton.Size = new Size(24, 24);
            AddAllButton.SizeMode = PictureBoxSizeMode.StretchImage;
            AddAllButton.TabIndex = 9;
            AddAllButton.TabStop = false;
            AddAllButton.Text = null;
            AddAllButton.Visible = false;
            AddAllButton.ZoomScaleDisabled = true;
            AddAllButton.Click += AddAllButton_Click;
            // 
            // DownloadAllButton
            // 
            DownloadAllButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            DownloadAllButton.BackColor = Color.White;
            DownloadAllButton.Cursor = Cursors.Hand;
            DownloadAllButton.Enabled = false;
            DownloadAllButton.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            DownloadAllButton.Image = (Image)resources.GetObject("DownloadAllButton.Image");
            DownloadAllButton.ImageHover = (Image)resources.GetObject("DownloadAllButton.ImageHover");
            DownloadAllButton.Location = new Point(705, 53);
            DownloadAllButton.Name = "DownloadAllButton";
            DownloadAllButton.Size = new Size(24, 24);
            DownloadAllButton.SizeMode = PictureBoxSizeMode.StretchImage;
            DownloadAllButton.TabIndex = 10;
            DownloadAllButton.TabStop = false;
            DownloadAllButton.Text = null;
            DownloadAllButton.Visible = false;
            DownloadAllButton.ZoomScaleDisabled = true;
            DownloadAllButton.Click += DownloadAllButton_Click;
            // 
            // StarAllButton
            // 
            StarAllButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            StarAllButton.BackColor = Color.White;
            StarAllButton.Cursor = Cursors.Hand;
            StarAllButton.Enabled = false;
            StarAllButton.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            StarAllButton.Image = (Image)resources.GetObject("StarAllButton.Image");
            StarAllButton.ImageHover = (Image)resources.GetObject("StarAllButton.ImageHover");
            StarAllButton.Location = new Point(667, 55);
            StarAllButton.Name = "StarAllButton";
            StarAllButton.Size = new Size(20, 20);
            StarAllButton.SizeMode = PictureBoxSizeMode.StretchImage;
            StarAllButton.TabIndex = 11;
            StarAllButton.TabStop = false;
            StarAllButton.Text = null;
            StarAllButton.Visible = false;
            StarAllButton.ZoomScaleDisabled = true;
            StarAllButton.Click += StarAllButton_Click;
            // 
            // PlayAllButton
            // 
            PlayAllButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            PlayAllButton.BackColor = Color.White;
            PlayAllButton.Cursor = Cursors.Hand;
            PlayAllButton.Enabled = false;
            PlayAllButton.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            PlayAllButton.Image = (Image)resources.GetObject("PlayAllButton.Image");
            PlayAllButton.ImageHover = (Image)resources.GetObject("PlayAllButton.ImageHover");
            PlayAllButton.Location = new Point(629, 54);
            PlayAllButton.Name = "PlayAllButton";
            PlayAllButton.Size = new Size(22, 22);
            PlayAllButton.SizeMode = PictureBoxSizeMode.StretchImage;
            PlayAllButton.TabIndex = 12;
            PlayAllButton.TabStop = false;
            PlayAllButton.Text = null;
            PlayAllButton.Visible = false;
            PlayAllButton.ZoomScaleDisabled = true;
            PlayAllButton.Click += PlayAllButton_Click;
            // 
            // SelectAllButton
            // 
            SelectAllButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            SelectAllButton.Enabled = false;
            SelectAllButton.FillColor = Color.White;
            SelectAllButton.FillColor2 = Color.Transparent;
            SelectAllButton.FillHoverColor = Color.Silver;
            SelectAllButton.FillPressColor = Color.FromArgb(166, 215, 231);
            SelectAllButton.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            SelectAllButton.ForeColor = Color.Black;
            SelectAllButton.Location = new Point(560, 53);
            SelectAllButton.MinimumSize = new Size(1, 1);
            SelectAllButton.Name = "SelectAllButton";
            SelectAllButton.Radius = 10;
            SelectAllButton.RectColor = Color.FromArgb(189, 189, 189);
            SelectAllButton.RectHoverColor = Color.Transparent;
            SelectAllButton.Size = new Size(48, 25);
            SelectAllButton.TabIndex = 13;
            SelectAllButton.Text = "全选";
            SelectAllButton.TipsFont = new Font("黑体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            SelectAllButton.Visible = false;
            SelectAllButton.Click += SelectAllButton_Click;
            // 
            // flowLayoutPanel
            // 
            flowLayoutPanel.Location = new Point(3, 104);
            flowLayoutPanel.Name = "flowLayoutPanel";
            flowLayoutPanel.Size = new Size(818, 393);
            flowLayoutPanel.TabIndex = 14;
            // 
            // SongList
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.White;
            Controls.Add(flowLayoutPanel);
            Controls.Add(SelectAllButton);
            Controls.Add(PlayAllButton);
            Controls.Add(StarAllButton);
            Controls.Add(DownloadAllButton);
            Controls.Add(AddAllButton);
            Controls.Add(DeleteAllButton);
            Controls.Add(BulkOperateButton);
            Name = "SongList";
            Size = new Size(824, 512);
            ((System.ComponentModel.ISupportInitialize)DeleteAllButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)AddAllButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)DownloadAllButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)StarAllButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)PlayAllButton).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Sunny.UI.UIButton BulkOperateButton;
        private Sunny.UI.UIImageButton DeleteAllButton;
        private Sunny.UI.UIImageButton AddAllButton;
        private Sunny.UI.UIImageButton DownloadAllButton;
        private Sunny.UI.UIImageButton StarAllButton;
        private Sunny.UI.UIImageButton PlayAllButton;
        private Sunny.UI.UIButton SelectAllButton;
        private FlowLayoutPanel flowLayoutPanel;
    }
}
