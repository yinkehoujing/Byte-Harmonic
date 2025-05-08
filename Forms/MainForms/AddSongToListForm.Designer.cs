namespace Byte_Harmonic.Forms.MainForms
{
    partial class AddSongToListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddSongToListForm));
            BulkOperateButton = new Sunny.UI.UIButton();
            label1 = new Label();
            uiImageButton2 = new Sunny.UI.UIImageButton();
            flowLayoutPanel = new FlowLayoutPanel();
            addButton = new Sunny.UI.UIButton();
            flowLayoutSongsPanel = new FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)uiImageButton2).BeginInit();
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
            BulkOperateButton.Location = new Point(419, 37);
            BulkOperateButton.MinimumSize = new Size(1, 1);
            BulkOperateButton.Name = "BulkOperateButton";
            BulkOperateButton.Radius = 10;
            BulkOperateButton.RectColor = Color.FromArgb(189, 189, 189);
            BulkOperateButton.RectHoverColor = Color.Transparent;
            BulkOperateButton.Size = new Size(87, 25);
            BulkOperateButton.TabIndex = 2;
            BulkOperateButton.Text = "新建歌单";
            BulkOperateButton.TipsFont = new Font("黑体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            BulkOperateButton.Click += BulkOperateButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("黑体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label1.Location = new Point(48, 41);
            label1.Name = "label1";
            label1.Size = new Size(167, 16);
            label1.TabIndex = 3;
            label1.Text = "歌单名，初始时不可见";
            // 
            // uiImageButton2
            // 
            uiImageButton2.Anchor = AnchorStyles.None;
            uiImageButton2.BackColor = Color.Transparent;
            uiImageButton2.Cursor = Cursors.Hand;
            uiImageButton2.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiImageButton2.Image = Properties.Resources.icons8_less_than_100;
            uiImageButton2.ImageHover = (Image)resources.GetObject("uiImageButton2.ImageHover");
            uiImageButton2.Location = new Point(12, 37);
            uiImageButton2.Name = "uiImageButton2";
            uiImageButton2.Size = new Size(24, 24);
            uiImageButton2.SizeMode = PictureBoxSizeMode.StretchImage;
            uiImageButton2.TabIndex = 9;
            uiImageButton2.TabStop = false;
            uiImageButton2.Text = null;
            uiImageButton2.ZoomScaleDisabled = true;
            uiImageButton2.Click += uiImageButton2_Click;
            // 
            // flowLayoutPanel
            // 
            flowLayoutPanel.Location = new Point(12, 82);
            flowLayoutPanel.Name = "flowLayoutPanel";
            flowLayoutPanel.Size = new Size(494, 296);
            flowLayoutPanel.TabIndex = 10;
            // 
            // addButton
            // 
            addButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            addButton.FillColor = Color.White;
            addButton.FillColor2 = Color.Transparent;
            addButton.FillHoverColor = Color.Silver;
            addButton.FillPressColor = Color.FromArgb(166, 215, 231);
            addButton.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            addButton.ForeColor = Color.Black;
            addButton.Location = new Point(214, 384);
            addButton.MinimumSize = new Size(1, 1);
            addButton.Name = "addButton";
            addButton.Radius = 10;
            addButton.RectColor = Color.FromArgb(189, 189, 189);
            addButton.RectHoverColor = Color.Transparent;
            addButton.Size = new Size(87, 25);
            addButton.TabIndex = 11;
            addButton.Text = "确认";
            addButton.TipsFont = new Font("黑体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            addButton.Click += addButton_Click;
            // 
            // flowLayoutSongsPanel
            // 
            flowLayoutSongsPanel.Location = new Point(12, 82);
            flowLayoutSongsPanel.Name = "flowLayoutSongsPanel";
            flowLayoutSongsPanel.Size = new Size(494, 296);
            flowLayoutSongsPanel.TabIndex = 12;
            // 
            // AddSongToListForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(520, 417);
            Controls.Add(flowLayoutSongsPanel);
            Controls.Add(addButton);
            Controls.Add(flowLayoutPanel);
            Controls.Add(uiImageButton2);
            Controls.Add(label1);
            Controls.Add(BulkOperateButton);
            Name = "AddSongToListForm";
            Text = "AddSongToListForm";
            Load += AddSongToListForm_Load;
            ((System.ComponentModel.ISupportInitialize)uiImageButton2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Sunny.UI.UIButton BulkOperateButton;
        private Label label1;
        private Sunny.UI.UIImageButton uiImageButton2;
        private FlowLayoutPanel flowLayoutPanel;
        private Sunny.UI.UIButton addButton;
        private FlowLayoutPanel flowLayoutSongsPanel;
    }
}