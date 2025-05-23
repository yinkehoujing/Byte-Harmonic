﻿using System;
using System.Windows.Forms;
using Byte_Harmonic.Database;
using Byte_Harmonic.Models;

namespace Byte_Harmonic.Forms
{
    public partial class TestSongRepoForm : Form
    {
        private readonly SongRepository _songRepo;

        public TestSongRepoForm()
        {
            InitializeComponent();
            _songRepo = new SongRepository();
        }

        private void btnRunTests_Click(object sender, EventArgs e)
        {
            listBoxResults.Items.Clear();
            RunTests();
            MessageBox.Show("测试完成！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void RunTests()
        {
            TestAddSong();
            TestGetSongByTitle();
            TestUpdateSong();
            TestDeleteSong();
        }

        private void TestAddSong()
        {
            Console.WriteLine("Test Add Song");
            var song = new Song
            {
                Title = "TestSong",
                Artist = "Tester",
                MusicFilePath = @"C:\Music\TestSong.mp3",
                LrcFilePath = @"C:\Lyrics\TestSong.lrc",
                Downloaded = false,
                Duration = 300
            };

            bool result = _songRepo.AddSong(song);
            listBoxResults.Items.Add($"AddSong: {(result ? "通过" : "失败")} (新Id: {song.Id})");
        }

        private void TestGetSongByTitle()
        {
            var song = _songRepo.GetSongByTitle("TestSong");
            bool result = song != null;
            Console.WriteLine("Test Get Song By Title :");
            Console.WriteLine($"song.id: {song.Id}, song.artist:{song.Artist}");
            listBoxResults.Items.Add($"GetSongById: {(result ? "通过" : "失败")}");
        }

        private void TestUpdateSong()
        {
            var song = _songRepo.GetSongByTitle("TestSong");
            if (song != null)
            {
                song.Title = "TestSongUpdated";
                bool result = _songRepo.UpdateSong(song);
                listBoxResults.Items.Add($"UpdateSong: {(result ? "通过" : "失败")}");
            }
            else
            {
                listBoxResults.Items.Add("UpdateSong: 未找到歌曲，跳过测试");
            }
            song = _songRepo.GetSongById(song.Id);
            Console.WriteLine($"updated as {song.Title}");
        }

        private void TestDeleteSong()
        {
            var song = _songRepo.GetSongByTitle("TestSongUpdated");
            if (song != null)
            {
                bool result = _songRepo.DeleteSong(song.Id);
                listBoxResults.Items.Add($"DeleteSong: {(result ? "通过" : "失败")}");
            }
            else
            {
                listBoxResults.Items.Add("DeleteSong: 未找到歌曲，跳过测试");
            }
        }
    }
}
