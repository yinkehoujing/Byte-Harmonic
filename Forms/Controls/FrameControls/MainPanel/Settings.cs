using Byte_Harmonic.Utils;
using Sunny.UI;
using System;
using System.IO;
using System.Windows.Forms;

namespace Byte_Harmonic.Forms.Controls.FrameControls.MainPanel
{
    public partial class Settings : UserControl
    {
        private readonly ConfigManager _configManager;

        public Settings()
        {
            InitializeComponent();
            _configManager = ConfigManager.Instance;
            InitializeSettings();
        }

        private void InitializeSettings()
        {
            // 从单例里读取
            txtDownloadPath.Text = _configManager.DownloadPath;
            radioFileNameOnly.Checked = _configManager.NamingStyle == 0;
            radioSongArtist.Checked = _configManager.NamingStyle == 1;
            radioArtistSong.Checked = _configManager.NamingStyle == 2;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using var folderDialog = new FolderBrowserDialog();
            if (folderDialog.ShowDialog() == DialogResult.OK)
                txtDownloadPath.Text = folderDialog.SelectedPath;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Directory.Exists(txtDownloadPath.Text))
                    throw new ArgumentException("路径不存在，请选择有效目录");

                // 保存到单例中
                _configManager.DownloadPath = txtDownloadPath.Text;
                _configManager.NamingStyle = radioFileNameOnly.Checked ? 0
                                            : radioSongArtist.Checked ? 1
                                            : 2;
                _configManager.Save();

                // 如果这个 UserControl 托管在一个对话框里，就关闭它
                var parentForm = this.FindForm();
                if (parentForm != null)
                {
                    parentForm.DialogResult = DialogResult.OK;
                    parentForm.Close();
                }
            }
            catch (Exception ex)
            {
                UIMessageBox.ShowError($"保存失败：{ex.Message}");
            }
        }

        private void txtDownloadPath_TextChanged(object sender, EventArgs e)
        {
            txtDownloadPath.BackColor = Directory.Exists(txtDownloadPath.Text)
                ? System.Drawing.Color.White
                : System.Drawing.Color.LightPink;
        }
    }
}