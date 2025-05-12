// CreateSongListForm.cs
using Byte_Harmonic.Database;
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

        // 无参构造函数，自动初始化服务
        public CreateSongListForm()
        {
            InitializeComponent();

            // 初始化仓储与服务
            var songRepo = new SonglistRepository();
            var userRepo = new UserRepository();
            var userService = new UserService(userRepo);
            _songlistService =AppContext.songlistService;

            // SunnyUI样式配置
            StyleCustomMode = true;
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
                AppContext.TriggerReloadSideSonglist();
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
                new Byte_Harmonic.Forms.MainForms.MessageForm($"创建失败：{ex.Message}").ShowDialog();
            }
        }
    }
}