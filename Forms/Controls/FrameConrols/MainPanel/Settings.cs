using Byte_Harmonic.Utils;
using Sunny.UI;
using System;
using System.IO;
using System.Windows.Forms;
using Byte_Harmonic.Forms;    // 使用 AppContext


//备注：执行“下载”逻辑时，统一从 AppContext.DownloadPath 和 AppContext.NamingStyle 中读取

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

        //初始化窗体
        private void InitializeSettings()
        {
            // 根据 AppContext 中的全局设置来初始化控件
            txtDownloadPath.Text = AppContext.DownloadPath;
            radioFileNameOnly.Checked = AppContext.NamingStyle == 0;
            radioSongArtist.Checked = AppContext.NamingStyle == 1;
            radioArtistSong.Checked = AppContext.NamingStyle == 2;
        }

        //选择下载路径
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using var dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
                txtDownloadPath.Text = dlg.SelectedPath;
        }

        //保存下载设置
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Directory.Exists(txtDownloadPath.Text))
                {
                    new Byte_Harmonic.Forms.MainForms.MessageForm("路径不存在").ShowDialog();
                }
                else
                {
                    // 写入 ConfigManager，并持久化
                    _configManager.DownloadPath = txtDownloadPath.Text;
                    _configManager.NamingStyle = radioFileNameOnly.Checked ? 0
                                                : radioSongArtist.Checked ? 1
                                                : 2;
                    _configManager.Save();

                    // 通知 AppContext 刷新全局设置
                    AppContext.LoadSettings();

                    new Byte_Harmonic.Forms.MainForms.MessageForm("保存成功").ShowDialog();
                }
            }
            catch (Exception ex)
            {
                new Byte_Harmonic.Forms.MainForms.MessageForm("保存失败").ShowDialog();
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