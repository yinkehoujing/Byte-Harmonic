using Sunny.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Configuration;
using Byte_Harmonic.Services;
using Byte_Harmonic.Models;
//using Byte_Harmonic.Repositories;
using Byte_Harmonic.Database;

namespace Byte_Harmonic.Forms
{
    public partial class AdminForm : UIForm
    {
        private SonglistService _songService;
        private List<Song> _currentSongs = new List<Song>();

        // 无参构造函数，负责初始化组件和服务
        public AdminForm()
        {
            InitializeComponent();

            // 仓储自己去拿连接串
            var songRepo = new SonglistRepository();
            var userRepo = new UserRepository();

            // 组装服务
            var userService = new UserService(userRepo);
            _songService = AppContext.songlistService;

            //把“浏览”“新建”“列表操作”等事件都挂上去
            btnSelectMp3.Click += btnSelectMp3_Click;
            btnSelectLrc.Click += btnSelectLrc_Click;
            btnCreate.Click += btnCreate_Click;

            InitSongList();
        }

        private async void InitSongList()
        {
            _currentSongs = await _songService.GetAllSongsAsync();

        }

        // 新建歌曲按钮点击事件
        private async void btnCreate_Click(object sender, EventArgs e)
        {
            var newSong = new Song
            {
                Title = txtTitle.Text.Trim(),
                Artist = txtArtist.Text.Trim(),
                MusicFilePath = txtMp3Path.Text,
                LrcFilePath = txtLrcPath.Text,
                Downloaded = true,
                Tags = new List<string>(txtTags.Text.Split(','))
            };

            try
            {
                await _songService.ImportSongsAsync(newSong);
                UIMessageBox.Show("歌曲添加成功！");
                InitSongList(); // 刷新列表
            }
            catch (Exception ex)
            {
                UIMessageBox.ShowError($"添加失败：{ex.Message}");
            }
        }

        // 文件选择事件
        private void btnSelectMp3_Click(object sender, EventArgs e)
        {
            using var dialog = new OpenFileDialog
            {
                Filter = "MP3文件|*.mp3",
                Title = "选择音乐文件"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
                txtMp3Path.Text = dialog.FileName;
        }

        private void btnSelectLrc_Click(object sender, EventArgs e)
        {
            using var dialog = new OpenFileDialog
            {
                Filter = "LRC文件|*.lrc",
                Title = "选择歌词文件"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
                txtLrcPath.Text = dialog.FileName;
        }

        // 歌曲列表操作
        private async void dgvSongs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex < 0) return;

            //var song = _currentSongs[e.RowIndex];
            //if (dgvSongs.Columns[e.ColumnIndex].Name == "colDelete")
            //{
            //    if (UIMessageBox.ShowAsk("确认删除该歌曲？"))
            //    {
            //        await _songService.DeleteSongAsync(song.Id);
            //        InitSongList();
            //    }
            //}
            ///*
            //else if (dgvSongs.Columns[e.ColumnIndex].Name == "colEdit")
            //{
            //    using var editForm = new EditSongForm(song, _songService);
            //    editForm.ShowDialog();
            //    InitSongList();
            //}
            //*/
        }

    }
}
