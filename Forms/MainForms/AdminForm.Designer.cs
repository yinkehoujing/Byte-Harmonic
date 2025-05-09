using System;
using System.Drawing;
using System.Windows.Forms;
using Sunny.UI;
using Sunny.UI.Win32;

namespace Byte_Harmonic.Forms
{
    partial class AdminForm
    {
        private System.ComponentModel.IContainer components = null;

        // 新增的 Label 字段
        private Sunny.UI.UILabel lblTitle;
        private Sunny.UI.UILabel lblArtist;
        private Sunny.UI.UILabel lblMp3;
        private Sunny.UI.UILabel lblLrc;
        private Sunny.UI.UILabel lblTags;

        private Sunny.UI.UITabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;

        private Sunny.UI.UITextBox txtTitle;
        private Sunny.UI.UITextBox txtArtist;
        private Sunny.UI.UITextBox txtMp3Path;
        private Sunny.UI.UITextBox txtLrcPath;
        private Sunny.UI.UITextBox txtTags;

        private Sunny.UI.UIButton btnSelectMp3;
        private Sunny.UI.UIButton btnSelectLrc;
        private Sunny.UI.UIButton btnCreate;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminForm));
            tabControl = new UITabControl();
            tabPage1 = new TabPage();
            lblTitle = new UILabel();
            txtTitle = new UITextBox();
            lblArtist = new UILabel();
            txtArtist = new UITextBox();
            lblMp3 = new UILabel();
            txtMp3Path = new UITextBox();
            btnSelectMp3 = new UIButton();
            lblLrc = new UILabel();
            txtLrcPath = new UITextBox();
            btnSelectLrc = new UIButton();
            lblTags = new UILabel();
            txtTags = new UITextBox();
            btnCreate = new UIButton();
            tabControl.SuspendLayout();
            tabPage1.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabPage1);
            tabControl.Dock = DockStyle.Fill;
            tabControl.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControl.Font = new Font("黑体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            tabControl.ItemSize = new Size(150, 40);
            tabControl.Location = new Point(0, 35);
            tabControl.MainPage = "";
            tabControl.MenuStyle = UIMenuStyle.Custom;
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(800, 565);
            tabControl.SizeMode = TabSizeMode.Fixed;
            tabControl.TabBackColor = Color.White;
            tabControl.TabIndex = 0;
            tabControl.TabSelectedColor = Color.White;
            tabControl.TabSelectedForeColor = Color.FromArgb(163, 199, 224);
            tabControl.TabSelectedHighColor = Color.FromArgb(163, 199, 224);
            tabControl.TabUnSelectedColor = Color.FromArgb(163, 199, 224);
            tabControl.TabUnSelectedForeColor = Color.FromArgb(240, 240, 240);
            tabControl.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.White;
            tabPage1.Controls.Add(lblTitle);
            tabPage1.Controls.Add(txtTitle);
            tabPage1.Controls.Add(lblArtist);
            tabPage1.Controls.Add(txtArtist);
            tabPage1.Controls.Add(lblMp3);
            tabPage1.Controls.Add(txtMp3Path);
            tabPage1.Controls.Add(btnSelectMp3);
            tabPage1.Controls.Add(lblLrc);
            tabPage1.Controls.Add(txtLrcPath);
            tabPage1.Controls.Add(btnSelectLrc);
            tabPage1.Controls.Add(lblTags);
            tabPage1.Controls.Add(txtTags);
            tabPage1.Controls.Add(btnCreate);
            tabPage1.Location = new Point(0, 40);
            tabPage1.Name = "tabPage1";
            tabPage1.Size = new Size(800, 525);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "新建歌曲";
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("黑体", 14.25F);
            lblTitle.ForeColor = Color.FromArgb(48, 48, 48);
            lblTitle.Location = new Point(82, 81);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(92, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "歌曲名称";
            // 
            // txtTitle
            // 
            txtTitle.Font = new Font("黑体", 12F);
            txtTitle.Location = new Point(269, 71);
            txtTitle.Margin = new Padding(4, 5, 4, 5);
            txtTitle.MinimumSize = new Size(1, 16);
            txtTitle.Name = "txtTitle";
            txtTitle.Padding = new Padding(5);
            txtTitle.RectColor = Color.FromArgb(163, 199, 224);
            txtTitle.ShowText = false;
            txtTitle.Size = new Size(400, 35);
            txtTitle.TabIndex = 1;
            txtTitle.TextAlignment = ContentAlignment.MiddleLeft;
            txtTitle.Watermark = "";
            // 
            // lblArtist
            // 
            lblArtist.Font = new Font("黑体", 14.25F);
            lblArtist.ForeColor = Color.FromArgb(48, 48, 48);
            lblArtist.Location = new Point(82, 151);
            lblArtist.Name = "lblArtist";
            lblArtist.Size = new Size(92, 25);
            lblArtist.TabIndex = 2;
            lblArtist.Text = "歌手名称";
            // 
            // txtArtist
            // 
            txtArtist.Font = new Font("黑体", 12F);
            txtArtist.Location = new Point(269, 141);
            txtArtist.Margin = new Padding(4, 5, 4, 5);
            txtArtist.MinimumSize = new Size(1, 16);
            txtArtist.Name = "txtArtist";
            txtArtist.Padding = new Padding(5);
            txtArtist.RectColor = Color.FromArgb(163, 199, 224);
            txtArtist.ShowText = false;
            txtArtist.Size = new Size(400, 35);
            txtArtist.TabIndex = 3;
            txtArtist.TextAlignment = ContentAlignment.MiddleLeft;
            txtArtist.Watermark = "";
            // 
            // lblMp3
            // 
            lblMp3.Font = new Font("黑体", 14.25F);
            lblMp3.ForeColor = Color.FromArgb(48, 48, 48);
            lblMp3.Location = new Point(82, 221);
            lblMp3.Name = "lblMp3";
            lblMp3.Size = new Size(92, 25);
            lblMp3.TabIndex = 4;
            lblMp3.Text = "MP3文件";
            // 
            // txtMp3Path
            // 
            txtMp3Path.Font = new Font("黑体", 12F);
            txtMp3Path.Location = new Point(269, 211);
            txtMp3Path.Margin = new Padding(4, 5, 4, 5);
            txtMp3Path.MinimumSize = new Size(1, 16);
            txtMp3Path.Name = "txtMp3Path";
            txtMp3Path.Padding = new Padding(5);
            txtMp3Path.RectColor = Color.FromArgb(163, 199, 224);
            txtMp3Path.ShowText = false;
            txtMp3Path.Size = new Size(300, 35);
            txtMp3Path.TabIndex = 5;
            txtMp3Path.TextAlignment = ContentAlignment.MiddleLeft;
            txtMp3Path.Watermark = "";
            // 
            // btnSelectMp3
            // 
            btnSelectMp3.FillColor = Color.FromArgb(163, 199, 224);
            btnSelectMp3.FillHoverColor = Color.FromArgb(166, 215, 231);
            btnSelectMp3.FillPressColor = Color.FromArgb(166, 215, 231);
            btnSelectMp3.Font = new Font("黑体", 12F);
            btnSelectMp3.Location = new Point(589, 211);
            btnSelectMp3.MinimumSize = new Size(1, 1);
            btnSelectMp3.Name = "btnSelectMp3";
            btnSelectMp3.RectColor = Color.FromArgb(163, 199, 224);
            btnSelectMp3.RectHoverColor = Color.FromArgb(166, 215, 231);
            btnSelectMp3.RectPressColor = Color.FromArgb(166, 215, 231);
            btnSelectMp3.Size = new Size(80, 35);
            btnSelectMp3.Style = UIStyle.Custom;
            btnSelectMp3.TabIndex = 6;
            btnSelectMp3.Text = "浏览";
            btnSelectMp3.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            // 
            // lblLrc
            // 
            lblLrc.Font = new Font("黑体", 14.25F);
            lblLrc.ForeColor = Color.FromArgb(48, 48, 48);
            lblLrc.Location = new Point(82, 296);
            lblLrc.Name = "lblLrc";
            lblLrc.Size = new Size(92, 25);
            lblLrc.TabIndex = 7;
            lblLrc.Text = "歌词文件";
            // 
            // txtLrcPath
            // 
            txtLrcPath.Font = new Font("黑体", 12F);
            txtLrcPath.Location = new Point(269, 286);
            txtLrcPath.Margin = new Padding(4, 5, 4, 5);
            txtLrcPath.MinimumSize = new Size(1, 16);
            txtLrcPath.Name = "txtLrcPath";
            txtLrcPath.Padding = new Padding(5);
            txtLrcPath.RectColor = Color.FromArgb(163, 199, 224);
            txtLrcPath.ShowText = false;
            txtLrcPath.Size = new Size(300, 35);
            txtLrcPath.TabIndex = 8;
            txtLrcPath.TextAlignment = ContentAlignment.MiddleLeft;
            txtLrcPath.Watermark = "";
            // 
            // btnSelectLrc
            // 
            btnSelectLrc.FillColor = Color.FromArgb(163, 199, 224);
            btnSelectLrc.FillHoverColor = Color.FromArgb(166, 215, 231);
            btnSelectLrc.FillPressColor = Color.FromArgb(166, 215, 231);
            btnSelectLrc.Font = new Font("黑体", 12F);
            btnSelectLrc.Location = new Point(589, 286);
            btnSelectLrc.MinimumSize = new Size(1, 1);
            btnSelectLrc.Name = "btnSelectLrc";
            btnSelectLrc.RectColor = Color.FromArgb(163, 199, 224);
            btnSelectLrc.RectHoverColor = Color.FromArgb(166, 215, 231);
            btnSelectLrc.RectPressColor = Color.FromArgb(166, 215, 231);
            btnSelectLrc.Size = new Size(80, 35);
            btnSelectLrc.Style = UIStyle.Custom;
            btnSelectLrc.TabIndex = 9;
            btnSelectLrc.Text = "浏览";
            btnSelectLrc.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            // 
            // lblTags
            // 
            lblTags.Font = new Font("黑体", 14.25F);
            lblTags.ForeColor = Color.FromArgb(48, 48, 48);
            lblTags.Location = new Point(82, 371);
            lblTags.Name = "lblTags";
            lblTags.Size = new Size(180, 25);
            lblTags.TabIndex = 10;
            lblTags.Text = "标签（逗号分隔）";
            // 
            // txtTags
            // 
            txtTags.Font = new Font("黑体", 12F);
            txtTags.Location = new Point(269, 361);
            txtTags.Margin = new Padding(4, 5, 4, 5);
            txtTags.MinimumSize = new Size(1, 16);
            txtTags.Name = "txtTags";
            txtTags.Padding = new Padding(5);
            txtTags.RectColor = Color.FromArgb(163, 199, 224);
            txtTags.ShowText = false;
            txtTags.Size = new Size(400, 35);
            txtTags.TabIndex = 11;
            txtTags.TextAlignment = ContentAlignment.MiddleLeft;
            txtTags.Watermark = "";
            // 
            // btnCreate
            // 
            btnCreate.FillColor = Color.FromArgb(160, 210, 180);
            btnCreate.FillHoverColor = Color.FromArgb(120, 180, 170);
            btnCreate.FillPressColor = Color.FromArgb(120, 180, 170);
            btnCreate.FillSelectedColor = Color.FromArgb(120, 180, 170);
            btnCreate.Font = new Font("黑体", 12F);
            btnCreate.Location = new Point(342, 438);
            btnCreate.MinimumSize = new Size(1, 1);
            btnCreate.Name = "btnCreate";
            btnCreate.RectColor = Color.FromArgb(160, 210, 180);
            btnCreate.RectHoverColor = Color.FromArgb(120, 180, 170);
            btnCreate.RectPressColor = Color.FromArgb(120, 180, 170);
            btnCreate.Size = new Size(100, 40);
            btnCreate.Style = UIStyle.Custom;
            btnCreate.StyleCustomMode = true;
            btnCreate.TabIndex = 12;
            btnCreate.Text = "新建";
            btnCreate.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            // 
            // AdminForm
            // 
            ClientSize = new Size(800, 600);
            Controls.Add(tabControl);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AdminForm";
            RectColor = Color.Black;
            Style = UIStyle.Custom;
            StyleCustomMode = true;
            Text = "管理员面板";
            TitleColor = Color.FromArgb(163, 199, 224);
            TitleFont = new Font("黑体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            ZoomScaleRect = new Rectangle(22, 22, 800, 600);
            tabControl.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ResumeLayout(false);
        }
        #endregion
    }
}