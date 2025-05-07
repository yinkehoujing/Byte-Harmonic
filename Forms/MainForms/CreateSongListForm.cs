// CreateSongListForm.cs
using Byte_Harmonic.Services;
using Sunny.UI;
using System;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace Byte_Harmonic.Forms
{
    public partial class CreateSongListForm : UIForm
    {
        private readonly SonglistService _songlistService;

        public CreateSongListForm(SonglistService songlistService)
        {
            InitializeComponent();
            _songlistService = songlistService;

            // SunnyUI样式配置
            StyleCustomMode = true;
            Style = UIStyle.Blue;
            btnConfirm.Style = UIStyle.Blue;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Visible = false;
                var songlistName = txtName.Text.Trim();

                if (string.IsNullOrEmpty(songlistName))
                    throw new ArgumentException("请输入歌单名");

                if (_songlistService.CheckIfSonglistExists(songlistName))
                    throw new ArgumentException("歌单名已存在");

                _songlistService.CreateSonglist(songlistName);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (ArgumentException ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
                txtName.Focus();
            }
            catch (Exception ex)
            {
                UIMessageBox.ShowError($"创建失败：{ex.Message}");
            }
        }
    }
}