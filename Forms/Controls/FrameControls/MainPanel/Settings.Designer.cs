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
            this.lblDownloadDir = new Sunny.UI.UILabel();
            this.txtDownloadPath = new Sunny.UI.UITextBox();
            this.btnBrowse = new Sunny.UI.UIButton();
            this.lblNaming = new Sunny.UI.UILabel();
            this.radioFileNameOnly = new Sunny.UI.UIRadioButton();
            this.radioSongArtist = new Sunny.UI.UIRadioButton();
            this.radioArtistSong = new Sunny.UI.UIRadioButton();
            this.btnSave = new Sunny.UI.UIButton();
            this.SuspendLayout();

            // lblDownloadDir
            this.lblDownloadDir.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.lblDownloadDir.Location = new System.Drawing.Point(20, 20);
            this.lblDownloadDir.Name = "lblDownloadDir";
            this.lblDownloadDir.Size = new System.Drawing.Size(100, 23);
            this.lblDownloadDir.Text = "下载目录";

            // txtDownloadPath
            this.txtDownloadPath.ButtonSymbolOffset = new System.Drawing.Point(0, 0);
            this.txtDownloadPath.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtDownloadPath.Location = new System.Drawing.Point(20, 50);
            this.txtDownloadPath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDownloadPath.Maximum = 2147483647D;
            this.txtDownloadPath.Minimum = -2147483648D;
            this.txtDownloadPath.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtDownloadPath.Name = "txtDownloadPath";
            this.txtDownloadPath.ShowText = false;
            this.txtDownloadPath.Size = new System.Drawing.Size(300, 29);
            this.txtDownloadPath.TextChanged += new System.EventHandler(this.txtDownloadPath_TextChanged);

            // btnBrowse
            this.btnBrowse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBrowse.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnBrowse.Location = new System.Drawing.Point(330, 50);
            this.btnBrowse.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(100, 29);
            this.btnBrowse.Text = "浏览目录";
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);

            // lblNaming
            this.lblNaming.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.lblNaming.Location = new System.Drawing.Point(20, 100);
            this.lblNaming.Name = "lblNaming";
            this.lblNaming.Size = new System.Drawing.Size(100, 23);
            this.lblNaming.Text = "文件命名";

            // radioFileNameOnly
            this.radioFileNameOnly.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.radioFileNameOnly.Location = new System.Drawing.Point(40, 130);
            this.radioFileNameOnly.Name = "radioFileNameOnly";
            this.radioFileNameOnly.Size = new System.Drawing.Size(100, 23);
            this.radioFileNameOnly.Text = "歌曲名";

            // radioSongArtist
            this.radioSongArtist.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.radioSongArtist.Location = new System.Drawing.Point(40, 160);
            this.radioSongArtist.Name = "radioSongArtist";
            this.radioSongArtist.Size = new System.Drawing.Size(150, 23);
            this.radioSongArtist.Text = "歌曲名——歌手名";

            // radioArtistSong
            this.radioArtistSong.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.radioArtistSong.Location = new System.Drawing.Point(40, 190);
            this.radioArtistSong.Name = "radioArtistSong";
            this.radioArtistSong.Size = new System.Drawing.Size(150, 23);
            this.radioArtistSong.Text = "歌手名——歌曲名";

            // btnSave
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnSave.Location = new System.Drawing.Point(330, 240);
            this.btnSave.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 35);
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // Settings
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.ClientSize = new System.Drawing.Size(450, 300);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.radioArtistSong);
            this.Controls.Add(this.radioSongArtist);
            this.Controls.Add(this.radioFileNameOnly);
            this.Controls.Add(this.lblNaming);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtDownloadPath);
            this.Controls.Add(this.lblDownloadDir);
            //this.MaximizeBox = false;
            //this.MinimizeBox = true;
            this.Name = "Settings";
            this.Text = "下载设置";
            this.ResumeLayout(false);
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
    }
}
