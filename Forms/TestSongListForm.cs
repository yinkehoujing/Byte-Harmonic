using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Byte_Harmonic.Database;
using Byte_Harmonic.Models;
using Byte_Harmonic.Services;

namespace Byte_Harmonic.Forms
{
    public partial class TestSongListForm : Form
    {
        private readonly SonglistService _songlistService;
        private readonly UserService _userService;

        public TestSongListForm()
        {
            InitializeComponent();

            // 初始化依赖项
            var songlistRepo = new SonglistRepository("YourConnectionString");
            var userRepo = new UserRepository();
            _userService = new UserService(userRepo);
            _songlistService = new SonglistService(songlistRepo, _userService);
        }

        private async void btnRunTests_Click(object sender, EventArgs e)
        {
            listBoxResults.Items.Clear();
            await RunTestsAsync();
            MessageBox.Show("测试完成！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async Task RunTestsAsync()
        {
            await TestAdminLoginAsync();
            await TestImportSongsAsync();
            await TestExportSongsAsync();
            await TestTagOperationsAsync();
            await TestPlaylistOperationsAsync();
            await TestShareLinkAsync();
        }

        #region 核心测试方法
        private async Task TestAdminLoginAsync()
        {
            try
            {
                await _userService.Login("admin@example.com", "adminPassword");
                listBoxResults.Items.Add("管理员登录: 通过");
            }
            catch
            {
                listBoxResults.Items.Add("管理员登录: 失败 (需要管理员权限执行后续测试)");
                throw;
            }
        }

        private async Task TestImportSongsAsync()
        {
            try
            {
                bool result = await _songlistService.ImportSongsAsync(@"D:\Music");
                listBoxResults.Items.Add($"导入歌曲: {(result ? "通过" : "失败")}");

                var songs = await _songlistService.GetAllSongsAsync();
                listBoxResults.Items.Add($"当前曲库歌曲数: {songs.Count}");
            }
            catch (Exception ex)
            {
                listBoxResults.Items.Add($"导入歌曲异常: {ex.Message}");
            }
        }

        private async Task TestExportSongsAsync()
        {
            try
            {
                bool result = await _songlistService.ExportSongsAsync(@"D:\ExportedSongs");
                listBoxResults.Items.Add($"导出歌曲: {(result ? "通过" : "失败")}");

                if (result)
                {
                    int fileCount = Directory.GetFiles(@"D:\ExportedSongs", "*.mp3").Length;
                    listBoxResults.Items.Add($"导出文件数: {fileCount}");
                }
            }
            catch (Exception ex)
            {
                listBoxResults.Items.Add($"导出歌曲异常: {ex.Message}");
            }
        }

        private async Task TestTagOperationsAsync()
        {
            try
            {
                // 测试标签操作
                var song = (await _songlistService.GetAllSongsAsync()).First();
                bool assignResult = _songlistService.AssignTagToSong(song, "流行");
                listBoxResults.Items.Add($"添加标签: {(assignResult ? "通过" : "失败")}");

                // 测试单标签筛选
                var filtered = _songlistService.FilterSongsByTag("流行");
                listBoxResults.Items.Add($"单标签筛选: {(filtered.Any() ? "通过" : "失败")}");

                // 测试多标签筛选
                _songlistService.AssignTagToSong(song, "经典");
                var multiFiltered = _songlistService.FilterSongsByTag(new List<string> { "流行", "经典" });
                listBoxResults.Items.Add($"多标签筛选: {(multiFiltered.Any() ? "通过" : "失败")}");
            }
            catch (Exception ex)
            {
                listBoxResults.Items.Add($"标签操作异常: {ex.Message}");
            }
        }

        private async Task TestPlaylistOperationsAsync()
        {
            try
            {
                // 创建歌单
                _songlistService.CreateSonglist("测试歌单");
                var playlists = await _songlistService.GetAllPlaylistsAsync();
                listBoxResults.Items.Add($"创建歌单: {(playlists.Any() ? "通过" : "失败")}");

                // 添加歌曲
                var song = (await _songlistService.GetAllSongsAsync()).First();
                var playlist = playlists.First();
                bool addResult = _songlistService.AddSongToSonglist(song, playlist);
                listBoxResults.Items.Add($"添加歌曲到歌单: {(addResult ? "通过" : "失败")}");

                // 导出歌单
                bool exportResult = _songlistService.ExportSonglist(playlist, @"D:\playlist.json");
                listBoxResults.Items.Add($"导出歌单: {(exportResult ? "通过" : "失败")}");

                // 导入歌单
                bool importResult = _songlistService.ImportSonglist(@"D:\playlist.json");
                listBoxResults.Items.Add($"导入歌单: {(importResult ? "通过" : "失败")}");
            }
            catch (Exception ex)
            {
                listBoxResults.Items.Add($"歌单操作异常: {ex.Message}");
            }
        }

        private async Task TestShareLinkAsync()
        {
            //try
            //{
            //    var playlist = (await _songlistService.GetAllPlaylistsAsync()).First();
            //    playlist.IsPublic = true;
            //    string link = _songlistService.GetShareLink(playlist);
            //    listBoxResults.Items.Add($"生成分享链接: {(!string.IsNullOrEmpty(link) ? "通过" : "失败")}");
            //    listBoxResults.Items.Add($"链接示例: {link}");
            //}
            //catch (Exception ex)
            //{
            //    listBoxResults.Items.Add($"分享功能异常: {ex.Message}");
            //}
        }
        #endregion
    }
}