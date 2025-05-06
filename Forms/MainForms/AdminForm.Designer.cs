namespace Byte_Harmonic.Forms
{
    partial class AdminForm
    {
        private System.ComponentModel.IContainer components = null;

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
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();

            // 主窗体设置
            this.SuspendLayout();
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Text = "管理员面板";
            this.Style = Sunny.UI.UIStyle.Blue;
            this.TitleColor = Sunny.UI.UIColor.Blue;

            // TabControl设置
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Font = new System.Drawing.Font("微软雅黑", 12F);

            // 第一个Tab页（新建歌曲）
            this.tabPage1.Text = "新建歌曲";
            this.tabPage1.BackColor = System.Drawing.Color.White;

            // 歌曲名称输入框
            this.txtTitle = new Sunny.UI.UITextBox();
            this.txtTitle.Location = new System.Drawing.Point(30, 30);
            this.txtTitle.Size = new System.Drawing.Size(400, 35);
            this.txtTitle.LabelText = "歌曲名称";
            this.txtTitle.LabelWidth = 80;

            // 歌手名称输入框
            this.txtArtist = new Sunny.UI.UITextBox();
            this.txtArtist.Location = new System.Drawing.Point(30, 90);
            this.txtArtist.Size = new System.Drawing.Size(400, 35);
            this.txtArtist.LabelText = "歌手名称";
            this.txtArtist.LabelWidth = 80;

            // MP3文件路径
            this.txtMp3Path = new Sunny.UI.UITextBox();
            this.txtMp3Path.Location = new System.Drawing.Point(30, 150);
            this.txtMp3Path.Size = new System.Drawing.Size(300, 35);
            this.txtMp3Path.LabelText = "MP3文件";
            this.txtMp3Path.LabelWidth = 80;

            // LRC文件路径
            this.txtLrcPath = new Sunny.UI.UITextBox();
            this.txtLrcPath.Location = new System.Drawing.Point(30, 210);
            this.txtLrcPath.Size = new System.Drawing.Size(300, 35);
            this.txtLrcPath.LabelText = "歌词文件";
            this.txtLrcPath.LabelWidth = 80;

            // 标签输入
            this.txtTags = new Sunny.UI.UITextBox();
            this.txtTags.Location = new System.Drawing.Point(30, 270);
            this.txtTags.Size = new System.Drawing.Size(400, 35);
            this.txtTags.LabelText = "标签（逗号分隔）";
            this.txtTags.LabelWidth = 120;

            // 文件选择按钮
            this.btnSelectMp3 = new Sunny.UI.UIButton();
            this.btnSelectMp3.Location = new System.Drawing.Point(350, 150);
            this.btnSelectMp3.Size = new System.Drawing.Size(80, 35);
            this.btnSelectMp3.Text = "浏览";
            this.btnSelectMp3.Style = Sunny.UI.UIStyle.Blue;

            this.btnSelectLrc = new Sunny.UI.UIButton();
            this.btnSelectLrc.Location = new System.Drawing.Point(350, 210);
            this.btnSelectLrc.Size = new System.Drawing.Size(80, 35);
            this.btnSelectLrc.Text = "浏览";
            this.btnSelectLrc.Style = Sunny.UI.UIStyle.Blue;

            // 提交按钮
            this.btnCreate = new Sunny.UI.UIButton();
            this.btnCreate.Location = new System.Drawing.Point(30, 330);
            this.btnCreate.Size = new System.Drawing.Size(100, 40);
            this.btnCreate.Text = "新建";
            this.btnCreate.Style = Sunny.UI.UIStyle.Success;

            // 添加控件到TabPage1
            this.tabPage1.Controls.Add(this.txtTitle);
            this.tabPage1.Controls.Add(this.txtArtist);
            this.tabPage1.Controls.Add(this.txtMp3Path);
            this.tabPage1.Controls.Add(this.txtLrcPath);
            this.tabPage1.Controls.Add(this.txtTags);
            this.tabPage1.Controls.Add(this.btnSelectMp3);
            this.tabPage1.Controls.Add(this.btnSelectLrc);
            this.tabPage1.Controls.Add(this.btnCreate);

            // 第二个Tab页（歌曲管理）
            this.tabPage2.Text = "歌曲管理";

            // 数据表格
            this.dgvSongs = new Sunny.UI.UIDataGridView();
            this.dgvSongs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSongs.ReadOnly = true;
            this.dgvSongs.AllowUserToAddRows = false;
            this.dgvSongs.AllowUserToDeleteRows = false;
            this.dgvSongs.RowHeadersVisible = false;

            // 表格列设置
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colId.HeaderText = "ID";
            this.colId.Name = "colId";
            this.colId.Width = 50;

            this.colTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTitle.HeaderText = "歌曲名称";
            this.colTitle.Name = "colTitle";
            this.colTitle.Width = 200;

            this.colArtist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colArtist.HeaderText = "歌手";
            this.colArtist.Name = "colArtist";
            this.colArtist.Width = 150;

            this.colEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colEdit.HeaderText = "操作";
            this.colEdit.Name = "colEdit";
            this.colEdit.Text = "编辑";
            this.colEdit.UseColumnTextForButtonValue = true;
            this.colEdit.Width = 80;

            this.colDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colDelete.HeaderText = "";
            this.colDelete.Name = "colDelete";
            this.colDelete.Text = "删除";
            this.colDelete.UseColumnTextForButtonValue = true;
            this.colDelete.Width = 80;

            this.dgvSongs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
        this.colId,
        this.colTitle,
        this.colArtist,
        this.colEdit,
        this.colDelete
    });

            this.tabPage2.Controls.Add(this.dgvSongs);

            // 添加到窗体
            this.Controls.Add(this.tabControl);
            this.ResumeLayout(false);
        }

        private Sunny.UI.UITabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UITextBox txtTitle;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UITextBox txtArtist;
        private Sunny.UI.UIButton btnSelectMp3;
        private Sunny.UI.UITextBox txtMp3Path;
        private Sunny.UI.UIButton btnSelectLrc;
        private Sunny.UI.UITextBox txtLrcPath;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UITextBox txtTags;
        private Sunny.UI.UIButton btnCreate;
        private System.Windows.Forms.TabPage tabPage2;
        private Sunny.UI.UIDataGridView dgvSongs;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colArtist;
        private System.Windows.Forms.DataGridViewButtonColumn colEdit;
        private System.Windows.Forms.DataGridViewButtonColumn colDelete;

        #endregion
    }
}