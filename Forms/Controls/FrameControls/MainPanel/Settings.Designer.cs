using Sunny.UI;

namespace Byte_Harmonic.Forms.Controls.FrameControls.MainPanel
{
    partial class Settings
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblDownloadDir = new UILabel();
            txtDownloadPath = new UITextBox();
            btnBrowse = new UIButton();
            lblNaming = new UILabel();
            radioFileNameOnly = new UIRadioButton();
            radioSongArtist = new UIRadioButton();
            radioArtistSong = new UIRadioButton();
            btnSave = new UIButton();
            uiLabel1 = new UILabel();
            SuspendLayout();
            // 
            // lblDownloadDir
            // 
            lblDownloadDir.Font = new Font("黑体", 14.25F);
            lblDownloadDir.ForeColor = Color.FromArgb(48, 48, 48);
            lblDownloadDir.Location = new Point(73, 116);
            lblDownloadDir.Name = "lblDownloadDir";
            lblDownloadDir.Size = new Size(100, 23);
            lblDownloadDir.TabIndex = 7;
            lblDownloadDir.Text = "下载目录";
            // 
            // txtDownloadPath
            // 
            txtDownloadPath.ButtonSymbolOffset = new Point(0, 0);
            txtDownloadPath.Font = new Font("黑体", 12F);
            txtDownloadPath.Location = new Point(73, 146);
            txtDownloadPath.Margin = new Padding(4, 5, 4, 5);
            txtDownloadPath.MinimumSize = new Size(1, 1);
            txtDownloadPath.Name = "txtDownloadPath";
            txtDownloadPath.Padding = new Padding(5);
            txtDownloadPath.RectColor = Color.FromArgb(163, 199, 224);
            txtDownloadPath.ScrollBarColor = Color.FromArgb(163, 199, 224);
            txtDownloadPath.ScrollBarStyleInherited = false;
            txtDownloadPath.ShowText = false;
            txtDownloadPath.Size = new Size(300, 29);
            txtDownloadPath.TabIndex = 6;
            txtDownloadPath.TextAlignment = ContentAlignment.MiddleLeft;
            txtDownloadPath.Watermark = "";
            txtDownloadPath.TextChanged += txtDownloadPath_TextChanged;
            // 
            // btnBrowse
            // 
            btnBrowse.Cursor = Cursors.Hand;
            btnBrowse.FillColor = Color.FromArgb(163, 199, 224);
            btnBrowse.FillHoverColor = Color.FromArgb(166, 215, 231);
            btnBrowse.FillPressColor = Color.FromArgb(166, 215, 231);
            btnBrowse.FillSelectedColor = Color.FromArgb(166, 215, 231);
            btnBrowse.Font = new Font("黑体", 12F);
            btnBrowse.Location = new Point(383, 146);
            btnBrowse.MinimumSize = new Size(1, 1);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.RectColor = Color.FromArgb(163, 199, 224);
            btnBrowse.RectHoverColor = Color.FromArgb(166, 215, 231);
            btnBrowse.RectPressColor = Color.FromArgb(166, 215, 231);
            btnBrowse.Size = new Size(100, 29);
            btnBrowse.TabIndex = 5;
            btnBrowse.Text = "浏览目录";
            btnBrowse.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnBrowse.Click += btnBrowse_Click;
            // 
            // lblNaming
            // 
            lblNaming.Font = new Font("黑体", 14.25F);
            lblNaming.ForeColor = Color.FromArgb(48, 48, 48);
            lblNaming.Location = new Point(73, 216);
            lblNaming.Name = "lblNaming";
            lblNaming.Size = new Size(100, 23);
            lblNaming.TabIndex = 4;
            lblNaming.Text = "文件命名";
            // 
            // radioFileNameOnly
            // 
            radioFileNameOnly.Font = new Font("黑体", 12F);
            radioFileNameOnly.Location = new Point(93, 246);
            radioFileNameOnly.MinimumSize = new Size(1, 1);
            radioFileNameOnly.Name = "radioFileNameOnly";
            radioFileNameOnly.RadioButtonColor = Color.FromArgb(163, 199, 224);
            radioFileNameOnly.Size = new Size(100, 23);
            radioFileNameOnly.TabIndex = 3;
            radioFileNameOnly.Text = "歌曲名";
            // 
            // radioSongArtist
            // 
            radioSongArtist.Font = new Font("黑体", 12F);
            radioSongArtist.Location = new Point(93, 276);
            radioSongArtist.MinimumSize = new Size(1, 1);
            radioSongArtist.Name = "radioSongArtist";
            radioSongArtist.RadioButtonColor = Color.FromArgb(163, 199, 224);
            radioSongArtist.Size = new Size(186, 23);
            radioSongArtist.TabIndex = 2;
            radioSongArtist.Text = "歌曲名——歌手名";
            // 
            // radioArtistSong
            // 
            radioArtistSong.Font = new Font("黑体", 12F);
            radioArtistSong.Location = new Point(93, 306);
            radioArtistSong.MinimumSize = new Size(1, 1);
            radioArtistSong.Name = "radioArtistSong";
            radioArtistSong.RadioButtonColor = Color.FromArgb(163, 199, 224);
            radioArtistSong.Size = new Size(177, 23);
            radioArtistSong.TabIndex = 1;
            radioArtistSong.Text = "歌手名——歌曲名";
            // 
            // btnSave
            // 
            btnSave.Cursor = Cursors.Hand;
            btnSave.FillColor = Color.FromArgb(163, 199, 224);
            btnSave.FillHoverColor = Color.FromArgb(166, 215, 231);
            btnSave.FillPressColor = Color.FromArgb(166, 215, 231);
            btnSave.FillSelectedColor = Color.FromArgb(166, 215, 231);
            btnSave.Font = new Font("黑体", 12F);
            btnSave.Location = new Point(383, 419);
            btnSave.MinimumSize = new Size(1, 1);
            btnSave.Name = "btnSave";
            btnSave.RectColor = Color.FromArgb(163, 199, 224);
            btnSave.RectHoverColor = Color.FromArgb(166, 215, 231);
            btnSave.RectPressColor = Color.FromArgb(166, 215, 231);
            btnSave.Size = new Size(100, 35);
            btnSave.TabIndex = 0;
            btnSave.Text = "保存";
            btnSave.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnSave.Click += btnSave_Click;
            // 
            // uiLabel1
            // 
            uiLabel1.Font = new Font("黑体", 18F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLabel1.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel1.Location = new Point(32, 31);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new Size(116, 30);
            uiLabel1.TabIndex = 8;
            uiLabel1.Text = "设置";
            // 
            // Settings
            // 
            Controls.Add(uiLabel1);
            Controls.Add(btnSave);
            Controls.Add(radioArtistSong);
            Controls.Add(radioSongArtist);
            Controls.Add(radioFileNameOnly);
            Controls.Add(lblNaming);
            Controls.Add(btnBrowse);
            Controls.Add(txtDownloadPath);
            Controls.Add(lblDownloadDir);
            Name = "Settings";
            Size = new Size(824, 512);
            ResumeLayout(false);
        }

        #endregion

        private UILabel lblDownloadDir;
        private UITextBox txtDownloadPath;
        private UIButton btnBrowse;
        private UILabel lblNaming;
        private UIRadioButton radioFileNameOnly;
        private UIRadioButton radioSongArtist;
        private UIRadioButton radioArtistSong;
        private UIButton btnSave;
        private UILabel uiLabel1;
    }
}
