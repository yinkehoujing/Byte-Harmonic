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
        private System.Windows.Forms.TabPage tabPage2;

        private Sunny.UI.UITextBox txtTitle;
        private Sunny.UI.UITextBox txtArtist;
        private Sunny.UI.UITextBox txtMp3Path;
        private Sunny.UI.UITextBox txtLrcPath;
        private Sunny.UI.UITextBox txtTags;

        private Sunny.UI.UIButton btnSelectMp3;
        private Sunny.UI.UIButton btnSelectLrc;
        private Sunny.UI.UIButton btnCreate;

        private Sunny.UI.UIDataGridView dgvSongs;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colArtist;
        private System.Windows.Forms.DataGridViewButtonColumn colEdit;
        private System.Windows.Forms.DataGridViewButtonColumn colDelete;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
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
            tabPage2 = new TabPage();
            dgvSongs = new UIDataGridView();
            colId = new DataGridViewTextBoxColumn();
            colTitle = new DataGridViewTextBoxColumn();
            colArtist = new DataGridViewTextBoxColumn();
            colEdit = new DataGridViewButtonColumn();
            colDelete = new DataGridViewButtonColumn();
            tabControl.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSongs).BeginInit();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabPage1);
            tabControl.Controls.Add(tabPage2);
            tabControl.Dock = DockStyle.Fill;
            tabControl.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControl.Font = new Font("微软雅黑", 12F);
            tabControl.ItemSize = new Size(150, 40);
            tabControl.Location = new Point(0, 35);
            tabControl.MainPage = "";
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(800, 565);
            tabControl.SizeMode = TabSizeMode.Fixed;
            tabControl.TabIndex = 0;
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
            lblTitle.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            lblTitle.ForeColor = Color.FromArgb(48, 48, 48);
            lblTitle.Location = new Point(30, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(80, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "歌曲名称";
            // 
            // txtTitle
            // 
            txtTitle.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtTitle.Location = new Point(30, 40);
            txtTitle.Margin = new Padding(4, 5, 4, 5);
            txtTitle.MinimumSize = new Size(1, 16);
            txtTitle.Name = "txtTitle";
            txtTitle.Padding = new Padding(5);
            txtTitle.ShowText = false;
            txtTitle.Size = new Size(400, 35);
            txtTitle.TabIndex = 1;
            txtTitle.TextAlignment = ContentAlignment.MiddleLeft;
            txtTitle.Watermark = "";
            // 
            // lblArtist
            // 
            lblArtist.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            lblArtist.ForeColor = Color.FromArgb(48, 48, 48);
            lblArtist.Location = new Point(30, 80);
            lblArtist.Name = "lblArtist";
            lblArtist.Size = new Size(80, 25);
            lblArtist.TabIndex = 2;
            lblArtist.Text = "歌手名称";
            // 
            // txtArtist
            // 
            txtArtist.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtArtist.Location = new Point(30, 110);
            txtArtist.Margin = new Padding(4, 5, 4, 5);
            txtArtist.MinimumSize = new Size(1, 16);
            txtArtist.Name = "txtArtist";
            txtArtist.Padding = new Padding(5);
            txtArtist.ShowText = false;
            txtArtist.Size = new Size(400, 35);
            txtArtist.TabIndex = 3;
            txtArtist.TextAlignment = ContentAlignment.MiddleLeft;
            txtArtist.Watermark = "";
            // 
            // lblMp3
            // 
            lblMp3.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            lblMp3.ForeColor = Color.FromArgb(48, 48, 48);
            lblMp3.Location = new Point(30, 150);
            lblMp3.Name = "lblMp3";
            lblMp3.Size = new Size(80, 25);
            lblMp3.TabIndex = 4;
            lblMp3.Text = "MP3文件";
            // 
            // txtMp3Path
            // 
            txtMp3Path.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtMp3Path.Location = new Point(30, 180);
            txtMp3Path.Margin = new Padding(4, 5, 4, 5);
            txtMp3Path.MinimumSize = new Size(1, 16);
            txtMp3Path.Name = "txtMp3Path";
            txtMp3Path.Padding = new Padding(5);
            txtMp3Path.ShowText = false;
            txtMp3Path.Size = new Size(300, 35);
            txtMp3Path.TabIndex = 5;
            txtMp3Path.TextAlignment = ContentAlignment.MiddleLeft;
            txtMp3Path.Watermark = "";
            // 
            // btnSelectMp3
            // 
            btnSelectMp3.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnSelectMp3.Location = new Point(350, 180);
            btnSelectMp3.MinimumSize = new Size(1, 1);
            btnSelectMp3.Name = "btnSelectMp3";
            btnSelectMp3.Size = new Size(80, 35);
            btnSelectMp3.Style = UIStyle.Custom;
            btnSelectMp3.TabIndex = 6;
            btnSelectMp3.Text = "浏览";
            btnSelectMp3.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            // 
            // lblLrc
            // 
            lblLrc.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            lblLrc.ForeColor = Color.FromArgb(48, 48, 48);
            lblLrc.Location = new Point(30, 225);
            lblLrc.Name = "lblLrc";
            lblLrc.Size = new Size(80, 25);
            lblLrc.TabIndex = 7;
            lblLrc.Text = "歌词文件";
            // 
            // txtLrcPath
            // 
            txtLrcPath.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtLrcPath.Location = new Point(30, 255);
            txtLrcPath.Margin = new Padding(4, 5, 4, 5);
            txtLrcPath.MinimumSize = new Size(1, 16);
            txtLrcPath.Name = "txtLrcPath";
            txtLrcPath.Padding = new Padding(5);
            txtLrcPath.ShowText = false;
            txtLrcPath.Size = new Size(300, 35);
            txtLrcPath.TabIndex = 8;
            txtLrcPath.TextAlignment = ContentAlignment.MiddleLeft;
            txtLrcPath.Watermark = "";
            // 
            // btnSelectLrc
            // 
            btnSelectLrc.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnSelectLrc.Location = new Point(350, 255);
            btnSelectLrc.MinimumSize = new Size(1, 1);
            btnSelectLrc.Name = "btnSelectLrc";
            btnSelectLrc.Size = new Size(80, 35);
            btnSelectLrc.Style = UIStyle.Custom;
            btnSelectLrc.TabIndex = 9;
            btnSelectLrc.Text = "浏览";
            btnSelectLrc.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            // 
            // lblTags
            // 
            lblTags.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            lblTags.ForeColor = Color.FromArgb(48, 48, 48);
            lblTags.Location = new Point(30, 300);
            lblTags.Name = "lblTags";
            lblTags.Size = new Size(120, 25);
            lblTags.TabIndex = 10;
            lblTags.Text = "标签（逗号分隔）";
            // 
            // txtTags
            // 
            txtTags.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtTags.Location = new Point(30, 330);
            txtTags.Margin = new Padding(4, 5, 4, 5);
            txtTags.MinimumSize = new Size(1, 16);
            txtTags.Name = "txtTags";
            txtTags.Padding = new Padding(5);
            txtTags.ShowText = false;
            txtTags.Size = new Size(400, 35);
            txtTags.TabIndex = 11;
            txtTags.TextAlignment = ContentAlignment.MiddleLeft;
            txtTags.Watermark = "";
            // 
            // btnCreate
            // 
            btnCreate.FillColor = Color.FromArgb(40, 167, 69);
            btnCreate.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnCreate.Location = new Point(30, 380);
            btnCreate.MinimumSize = new Size(1, 1);
            btnCreate.Name = "btnCreate";
            btnCreate.RectColor = Color.FromArgb(40, 167, 69);
            btnCreate.Size = new Size(100, 40);
            btnCreate.Style = UIStyle.Custom;
            btnCreate.StyleCustomMode = true;
            btnCreate.TabIndex = 12;
            btnCreate.Text = "新建";
            btnCreate.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(dgvSongs);
            tabPage2.Location = new Point(0, 40);
            tabPage2.Name = "tabPage2";
            tabPage2.Size = new Size(800, 525);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "歌曲管理";
            // 
            // dgvSongs
            // 
            dgvSongs.AllowUserToAddRows = false;
            dgvSongs.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(235, 243, 255);
            dgvSongs.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvSongs.BackgroundColor = Color.White;
            dgvSongs.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle2.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvSongs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvSongs.ColumnHeadersHeight = 32;
            dgvSongs.Columns.AddRange(new DataGridViewColumn[] { colId, colTitle, colArtist, colEdit, colDelete });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvSongs.DefaultCellStyle = dataGridViewCellStyle3;
            dgvSongs.Dock = DockStyle.Fill;
            dgvSongs.EnableHeadersVisualStyles = false;
            dgvSongs.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dgvSongs.GridColor = Color.FromArgb(80, 160, 255);
            dgvSongs.Location = new Point(0, 0);
            dgvSongs.Name = "dgvSongs";
            dgvSongs.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(235, 243, 255);
            dataGridViewCellStyle4.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvSongs.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvSongs.RowHeadersVisible = false;
            dgvSongs.RowHeadersWidth = 62;
            dataGridViewCellStyle5.BackColor = Color.White;
            dataGridViewCellStyle5.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dgvSongs.RowsDefaultCellStyle = dataGridViewCellStyle5;
            dgvSongs.SelectedIndex = -1;
            dgvSongs.Size = new Size(800, 525);
            dgvSongs.StripeOddColor = Color.FromArgb(235, 243, 255);
            dgvSongs.TabIndex = 0;
            // 
            // colId
            // 
            colId.MinimumWidth = 8;
            colId.Name = "colId";
            colId.ReadOnly = true;
            colId.Width = 150;
            // 
            // colTitle
            // 
            colTitle.MinimumWidth = 8;
            colTitle.Name = "colTitle";
            colTitle.ReadOnly = true;
            colTitle.Width = 150;
            // 
            // colArtist
            // 
            colArtist.MinimumWidth = 8;
            colArtist.Name = "colArtist";
            colArtist.ReadOnly = true;
            colArtist.Width = 150;
            // 
            // colEdit
            // 
            colEdit.MinimumWidth = 8;
            colEdit.Name = "colEdit";
            colEdit.ReadOnly = true;
            colEdit.Width = 150;
            // 
            // colDelete
            // 
            colDelete.MinimumWidth = 8;
            colDelete.Name = "colDelete";
            colDelete.ReadOnly = true;
            colDelete.Width = 150;
            // 
            // AdminForm
            // 
            ClientSize = new Size(800, 600);
            Controls.Add(tabControl);
            Name = "AdminForm";
            RectColor = Color.FromArgb(0, 150, 136);
            Style = UIStyle.Custom;
            StyleCustomMode = true;
            Text = "管理员面板";
            TitleColor = Color.FromArgb(0, 150, 136);
            ZoomScaleRect = new Rectangle(22, 22, 800, 600);
            tabControl.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSongs).EndInit();
            ResumeLayout(false);
        }
        #endregion
    }
}