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
            this.tabControl = new Sunny.UI.UITabControl();
            this.tabPage1 = new TabPage();
            this.tabPage2 = new TabPage();

            // 主窗体设置
            this.SuspendLayout();
            this.ClientSize = new Size(800, 600);
            this.Text = "管理员面板";
            this.Style = UIStyle.Blue;
            this.TitleColor = UIColor.Blue;

            // TabControl设置
            this.tabControl.Dock = DockStyle.Fill;
            this.tabControl.Font = new Font("微软雅黑", 12F);
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);

            // =========== 第一个Tab页（新建歌曲） ===========
            this.tabPage1.Text = "新建歌曲";
            this.tabPage1.BackColor = Color.White;

            // 标签 和 文本框 布局
            // 歌曲名称
            this.lblTitle = new UILabel();
            this.lblTitle.Text = "歌曲名称";
            this.lblTitle.Location = new Point(30, 10);
            this.lblTitle.Size = new Size(80, 25);

            this.txtTitle = new UITextBox();
            this.txtTitle.Location = new Point(30, 40);
            this.txtTitle.Size = new Size(400, 35);

            // 歌手名称
            this.lblArtist = new UILabel();
            this.lblArtist.Text = "歌手名称";
            this.lblArtist.Location = new Point(30, 80);
            this.lblArtist.Size = new Size(80, 25);

            this.txtArtist = new UITextBox();
            this.txtArtist.Location = new Point(30, 110);
            this.txtArtist.Size = new Size(400, 35);

            // MP3文件
            this.lblMp3 = new UILabel();
            this.lblMp3.Text = "MP3文件";
            this.lblMp3.Location = new Point(30, 150);
            this.lblMp3.Size = new Size(80, 25);

            this.txtMp3Path = new UITextBox();
            this.txtMp3Path.Location = new Point(30, 180);
            this.txtMp3Path.Size = new Size(300, 35);

            this.btnSelectMp3 = new UIButton();
            this.btnSelectMp3.Text = "浏览";
            this.btnSelectMp3.Location = new Point(350, 180);
            this.btnSelectMp3.Size = new Size(80, 35);
            this.btnSelectMp3.Style = UIStyle.Blue;

            // LRC文件
            this.lblLrc = new UILabel();
            this.lblLrc.Text = "歌词文件";
            this.lblLrc.Location = new Point(30, 225);
            this.lblLrc.Size = new Size(80, 25);

            this.txtLrcPath = new UITextBox();
            this.txtLrcPath.Location = new Point(30, 255);
            this.txtLrcPath.Size = new Size(300, 35);

            this.btnSelectLrc = new UIButton();
            this.btnSelectLrc.Text = "浏览";
            this.btnSelectLrc.Location = new Point(350, 255);
            this.btnSelectLrc.Size = new Size(80, 35);
            this.btnSelectLrc.Style = UIStyle.Blue;

            // 标签输入
            this.lblTags = new UILabel();
            this.lblTags.Text = "标签（逗号分隔）";
            this.lblTags.Location = new Point(30, 300);
            this.lblTags.Size = new Size(120, 25);

            this.txtTags = new UITextBox();
            this.txtTags.Location = new Point(30, 330);
            this.txtTags.Size = new Size(400, 35);

            // “新建”按钮（自定义绿色）
            this.btnCreate = new UIButton();
            this.btnCreate.Text = "新建";
            this.btnCreate.Location = new Point(30, 380);
            this.btnCreate.Size = new Size(100, 40);
            this.btnCreate.Style = UIStyle.Custom;
            this.btnCreate.StyleCustomMode = true;
            this.btnCreate.FillColor = Color.FromArgb(40, 167, 69);
            this.btnCreate.RectColor = Color.FromArgb(40, 167, 69);

            // 添加控件到 TabPage1
            this.tabPage1.Controls.Add(this.lblTitle);
            this.tabPage1.Controls.Add(this.txtTitle);
            this.tabPage1.Controls.Add(this.lblArtist);
            this.tabPage1.Controls.Add(this.txtArtist);
            this.tabPage1.Controls.Add(this.lblMp3);
            this.tabPage1.Controls.Add(this.txtMp3Path);
            this.tabPage1.Controls.Add(this.btnSelectMp3);
            this.tabPage1.Controls.Add(this.lblLrc);
            this.tabPage1.Controls.Add(this.txtLrcPath);
            this.tabPage1.Controls.Add(this.btnSelectLrc);
            this.tabPage1.Controls.Add(this.lblTags);
            this.tabPage1.Controls.Add(this.txtTags);
            this.tabPage1.Controls.Add(this.btnCreate);

            // =========== 第二个Tab页（歌曲管理） ===========
            this.tabPage2.Text = "歌曲管理";

            this.dgvSongs = new UIDataGridView();
            this.dgvSongs.Dock = DockStyle.Fill;
            this.dgvSongs.ReadOnly = true;
            this.dgvSongs.AllowUserToAddRows = false;
            this.dgvSongs.AllowUserToDeleteRows = false;
            this.dgvSongs.RowHeadersVisible = false;

            this.colId = new DataGridViewTextBoxColumn { HeaderText = "ID", Name = "colId", Width = 50 };
            this.colTitle = new DataGridViewTextBoxColumn { HeaderText = "歌曲名称", Name = "colTitle", Width = 200 };
            this.colArtist = new DataGridViewTextBoxColumn { HeaderText = "歌手", Name = "colArtist", Width = 150 };
            this.colEdit = new DataGridViewButtonColumn { HeaderText = "操作", Name = "colEdit", Text = "编辑", UseColumnTextForButtonValue = true, Width = 80 };
            this.colDelete = new DataGridViewButtonColumn { HeaderText = "", Name = "colDelete", Text = "删除", UseColumnTextForButtonValue = true, Width = 80 };

            this.dgvSongs.Columns.AddRange(new DataGridViewColumn[] {
                this.colId, this.colTitle, this.colArtist, this.colEdit, this.colDelete
            });

            this.tabPage2.Controls.Add(this.dgvSongs);

            // 将 TabControl 添加到窗体
            this.Controls.Add(this.tabControl);
            this.ResumeLayout(false);

            // 自定义窗体主题色
            this.StyleCustomMode = true;
            this.Style = UIStyle.Custom;
            this.TitleColor = Color.FromArgb(0, 150, 136);
            this.RectColor = Color.FromArgb(0, 150, 136);
        }
        #endregion
    }
}