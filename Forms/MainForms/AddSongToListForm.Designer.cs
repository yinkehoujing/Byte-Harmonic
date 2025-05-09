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
            CreatListButton = new Sunny.UI.UIButton();
            label1 = new Label();
            uiImageButton2 = new Sunny.UI.UIImageButton();
            flowLayoutPanel = new FlowLayoutPanel();
            addButton = new Sunny.UI.UIButton();
            flowLayoutSongsPanel = new FlowLayoutPanel();
            uiImageButton3 = new Sunny.UI.UIImageButton();
            uiImageButton1 = new Sunny.UI.UIImageButton();
            ((System.ComponentModel.ISupportInitialize)uiImageButton2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)uiImageButton3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)uiImageButton1).BeginInit();
            SuspendLayout();
            // 
            // CreatListButton
            // 
            CreatListButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            CreatListButton.FillColor = Color.FromArgb(163, 199, 224);
            CreatListButton.FillColor2 = Color.Transparent;
            CreatListButton.FillHoverColor = Color.Silver;
            CreatListButton.FillPressColor = Color.FromArgb(166, 215, 231);
            CreatListButton.Font = new Font("黑体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            CreatListButton.Location = new Point(419, 41);
            CreatListButton.MinimumSize = new Size(1, 1);
            CreatListButton.Name = "CreatListButton";
            CreatListButton.Radius = 10;
            CreatListButton.RectColor = Color.FromArgb(163, 199, 224);
            CreatListButton.RectHoverColor = Color.Transparent;
            CreatListButton.Size = new Size(87, 25);
            CreatListButton.TabIndex = 2;
            CreatListButton.Text = "新建歌单";
            CreatListButton.TipsFont = new Font("黑体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            CreatListButton.Click += CreateListButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("黑体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label1.Location = new Point(51, 46);
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
            uiImageButton2.Location = new Point(12, 42);
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
            addButton.FillColor = Color.FromArgb(163, 199, 224);
            addButton.FillColor2 = Color.Transparent;
            addButton.FillHoverColor = Color.Silver;
            addButton.FillPressColor = Color.FromArgb(166, 215, 231);
            addButton.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            addButton.Location = new Point(214, 384);
            addButton.MinimumSize = new Size(1, 1);
            addButton.Name = "addButton";
            addButton.Radius = 10;
            addButton.RectColor = Color.FromArgb(163, 199, 224);
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
            // uiImageButton3
            // 
            uiImageButton3.Anchor = AnchorStyles.None;
            uiImageButton3.BackColor = Color.Transparent;
            uiImageButton3.Cursor = Cursors.Hand;
            uiImageButton3.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiImageButton3.Image = (Image)resources.GetObject("uiImageButton3.Image");
            uiImageButton3.ImageHover = (Image)resources.GetObject("uiImageButton3.ImageHover");
            uiImageButton3.Location = new Point(435, 7);
            uiImageButton3.Name = "uiImageButton3";
            uiImageButton3.Size = new Size(24, 24);
            uiImageButton3.SizeMode = PictureBoxSizeMode.StretchImage;
            uiImageButton3.TabIndex = 14;
            uiImageButton3.TabStop = false;
            uiImageButton3.Text = null;
            uiImageButton3.ZoomScaleDisabled = true;
            // 
            // uiImageButton1
            // 
            uiImageButton1.Anchor = AnchorStyles.None;
            uiImageButton1.BackColor = Color.Transparent;
            uiImageButton1.Cursor = Cursors.Hand;
            uiImageButton1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiImageButton1.Image = (Image)resources.GetObject("uiImageButton1.Image");
            uiImageButton1.ImageHover = (Image)resources.GetObject("uiImageButton1.ImageHover");
            uiImageButton1.Location = new Point(482, 7);
            uiImageButton1.Name = "uiImageButton1";
            uiImageButton1.Size = new Size(24, 24);
            uiImageButton1.SizeMode = PictureBoxSizeMode.StretchImage;
            uiImageButton1.TabIndex = 13;
            uiImageButton1.TabStop = false;
            uiImageButton1.Text = null;
            uiImageButton1.ZoomScaleDisabled = true;
            // 
            // AddSongToListForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(250, 250, 250);
            ClientSize = new Size(520, 417);
            Controls.Add(uiImageButton3);
            Controls.Add(uiImageButton1);
            Controls.Add(flowLayoutSongsPanel);
            Controls.Add(addButton);
            Controls.Add(flowLayoutPanel);
            Controls.Add(uiImageButton2);
            Controls.Add(label1);
            Controls.Add(CreatListButton);
            ForeColor = SystemColors.ControlText;
            FormBorderStyle = FormBorderStyle.None;
            Name = "AddSongToListForm";
            Text = "AddSongToListForm";
            Load += AddSongToListForm_Load;
            ((System.ComponentModel.ISupportInitialize)uiImageButton2).EndInit();
            ((System.ComponentModel.ISupportInitialize)uiImageButton3).EndInit();
            ((System.ComponentModel.ISupportInitialize)uiImageButton1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Sunny.UI.UIButton CreatListButton;
        private Label label1;
        private Sunny.UI.UIImageButton uiImageButton2;
        private FlowLayoutPanel flowLayoutPanel;
        private Sunny.UI.UIButton addButton;
        private FlowLayoutPanel flowLayoutSongsPanel;
        private Sunny.UI.UIImageButton uiImageButton3;
        private Sunny.UI.UIImageButton uiImageButton1;
    }
}