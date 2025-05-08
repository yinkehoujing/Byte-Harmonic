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
            uiButton1 = new Sunny.UI.UIButton();
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
            BulkOperateButton.Location = new Point(419, 22);
            BulkOperateButton.MinimumSize = new Size(1, 1);
            BulkOperateButton.Name = "BulkOperateButton";
            BulkOperateButton.Radius = 10;
            BulkOperateButton.RectColor = Color.FromArgb(189, 189, 189);
            BulkOperateButton.RectHoverColor = Color.Transparent;
            BulkOperateButton.Size = new Size(87, 25);
            BulkOperateButton.TabIndex = 2;
            BulkOperateButton.Text = "新建歌单";
            BulkOperateButton.TipsFont = new Font("黑体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("黑体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label1.Location = new Point(48, 26);
            label1.Name = "label1";
            label1.Size = new Size(167, 16);
            label1.TabIndex = 3;
            label1.Text = "歌单名，初始时不可见";
            label1.Click += label1_Click;
            // 
            // uiImageButton2
            // 
            uiImageButton2.Anchor = AnchorStyles.None;
            uiImageButton2.BackColor = Color.Transparent;
            uiImageButton2.Cursor = Cursors.Hand;
            uiImageButton2.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiImageButton2.Image = Properties.Resources.icons8_less_than_100;
            uiImageButton2.ImageHover = (Image)resources.GetObject("uiImageButton2.ImageHover");
            uiImageButton2.Location = new Point(12, 22);
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
            flowLayoutPanel.Location = new Point(12, 68);
            flowLayoutPanel.Name = "flowLayoutPanel";
            flowLayoutPanel.Size = new Size(494, 310);
            flowLayoutPanel.TabIndex = 10;
            // 
            // uiButton1
            // 
            uiButton1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            uiButton1.FillColor = Color.White;
            uiButton1.FillColor2 = Color.Transparent;
            uiButton1.FillHoverColor = Color.Silver;
            uiButton1.FillPressColor = Color.FromArgb(166, 215, 231);
            uiButton1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiButton1.ForeColor = Color.Black;
            uiButton1.Location = new Point(214, 384);
            uiButton1.MinimumSize = new Size(1, 1);
            uiButton1.Name = "uiButton1";
            uiButton1.Radius = 10;
            uiButton1.RectColor = Color.FromArgb(189, 189, 189);
            uiButton1.RectHoverColor = Color.Transparent;
            uiButton1.Size = new Size(87, 25);
            uiButton1.TabIndex = 11;
            uiButton1.Text = "确认";
            uiButton1.TipsFont = new Font("黑体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            // 
            // AddSongToListForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(520, 417);
            Controls.Add(uiButton1);
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
        private Sunny.UI.UIButton uiButton1;
    }
}