﻿using Sunny.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Configuration;
using Byte_Harmonic.Services;
using Byte_Harmonic.Models;
//using Byte_Harmonic.Repositories;
using Byte_Harmonic.Database;
using System.Text.RegularExpressions;

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
           
            try
            {
                if (string.IsNullOrWhiteSpace(txtTitle.Text))
                {
                    throw new Exception("歌曲名不能为空！");
                }
                if(string.IsNullOrWhiteSpace(txtArtist.Text))
                {
                    throw new Exception("歌手名不能为空！");
                }
                if (!IsValidMp3Path(txtMp3Path.Text))
                {
                    throw new Exception("请提供正确的 MP3 文件路径!");
                }
                if (!IsValidLrcPath(txtLrcPath.Text))
                {
                    throw new Exception("请提供正确的 LRC 文件路径!");
                }
                if (!isValidSeconds(uiTextBox1.Text.Trim()))
                {
                    throw new Exception("请提供合法的歌曲播放时长!");
                }

                var newSong = new Song
                {
                    Title = txtTitle.Text.Trim(),
                    Artist = txtArtist.Text.Trim(),
                    MusicFilePath = txtMp3Path.Text,
                    LrcFilePath = txtLrcPath.Text,
                    Downloaded = true,
                    Tags = new List<string>(txtTags.Text.Split(',')),
                    Duration = int.Parse(uiTextBox1.Text.Trim()),
                };

                await _songService.ImportSongsAsync(newSong);
                new Byte_Harmonic.Forms.MainForms.MessageForm("歌曲添加成功！").ShowDialog();
                InitSongList(); // 刷新列表
            }
            catch (Exception ex)
            {
                new Byte_Harmonic.Forms.MainForms.MessageForm($"添加失败：{ex.Message}").ShowDialog();
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

        private bool IsValidMp3Path(string path)
        {
            var pattern = @"^[a-zA-Z]:\\(?:[^\\/:*?""<>|\r\n]+\\)*[^\\/:*?""<>|\r\n]+\.mp3$";
            return Regex.IsMatch(path, pattern, RegexOptions.IgnoreCase);
        }

        private bool isValidSeconds(string str)
        {

            var pattern = @"^\d+$";
            return Regex.IsMatch(str, pattern, RegexOptions.IgnoreCase);
        }

        private bool IsValidLrcPath(string path)
        {
            var pattern = @"^[a-zA-Z]:\\(?:[^\\/:*?""<>|\r\n]+\\)*[^\\/:*?""<>|\r\n]+\.lrc$";
            return Regex.IsMatch(path, pattern, RegexOptions.IgnoreCase);
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
