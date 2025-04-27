using System;
using System.Windows.Forms;
using ByteHarmonic.Database;
using ByteHarmonic.Models;

namespace ByteHarmonic.Forms
{
    public partial class TestForm : Form
    {
        private readonly SongRepository _songRepo;

        public TestForm()
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
            TestGetSongById();
            TestUpdateSong();
            TestDeleteSong();
        }

        private void TestAddSong()
        {
            var song = new Song
            {
                Id = Guid.NewGuid().ToString(),
                Title = "TestSong",
                Artist = "Tester",
                FilePath = @"C:\Music\TestSong.mp3",
                Downloaded = false,
                Duration = 300
            };

            bool result = _songRepo.AddSong(song);
            listBoxResults.Items.Add($"AddSong: {(result ? "通过" : "失败")}");
        }

        private void TestGetSongById()
        {
            var song = _songRepo.GetSongByTitle("TestSong");
            bool result = song != null;
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
        }

        private void TestDeleteSong()
        {
            var song = _songRepo.GetSongByTitle("TestSongUpdated");
            if (song != null)
            {
                bool result = _songRepo.DeleteSong(song.Id);
                listBoxResults.Items.Add($"DeleteSong: {(result ? "通过" : "失败")}");
            }
        }
    }
}
