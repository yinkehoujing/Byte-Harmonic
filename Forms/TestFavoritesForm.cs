using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using Byte_Harmonic.Database;
using Byte_Harmonic.Models;
using Byte_Harmonic.Services;

namespace Byte_Harmonic.Forms
{
    public partial class TestFavoritesService : Form
    {
        private readonly UserRepository _userRepo;
        private readonly UserService _userService;
        private readonly FavoritesService _favoritesService;
        private readonly string _connectionString =
            "server=localhost;user=root;database=Byte_Harmonic;port=3306;password=595129854";

        public TestFavoritesService()
        {
            InitializeComponent();
            _userRepo = new UserRepository();
            _userService = new UserService(_userRepo);
            _favoritesService = new FavoritesService(_userRepo);
        }

        private async void btnRunTests_Click(object sender, EventArgs e)
        {
            listBoxResults.Items.Clear();
            await RunAllFavoritesTests();
            MessageBox.Show("收藏测试完成！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async Task RunAllFavoritesTests()
        {
            await TestAddFavoriteSong();
            //await TestRemoveFavoriteSong();
            await TestGetFavoriteSongs();
            //await TestGetFavoriteSongsCount();
            //await TestAddFavoriteSongs();
            //await TestClearAllFavorites();
        }

        // 测试1: 添加收藏歌曲
        private async Task TestAddFavoriteSong()
        {
            try
            {
                await _userService.Login("admin", "123456789");
                bool result = await _favoritesService.AddFavoriteSongAsync("admin", 3);
                listBoxResults.Items.Add($"1. 添加收藏歌曲测试: {(result ? "✓ 通过" : "✗ 失败")}");
            }
            catch (Exception ex)
            {
                listBoxResults.Items.Add($"1. 添加收藏歌曲测试: ✗ 异常 - {ex.Message}");
            }
            finally
            {
                _userService.Logout();
            }
        }

        // 测试2: 取消收藏歌曲
        private async Task TestRemoveFavoriteSong()
        {
            try
            {
                await _userService.Login("admin", "123456789");
                bool result = await _favoritesService.RemoveFavoriteSongAsync("admin", 1);
                listBoxResults.Items.Add($"2. 取消收藏歌曲测试: {(result ? "✓ 通过" : "✗ 失败")}");
            }
            catch (Exception ex)
            {
                listBoxResults.Items.Add($"2. 取消收藏歌曲测试: ✗ 异常 - {ex.Message}");
            }
            finally
            {
                _userService.Logout();
            }
        }

        // 测试3: 获取用户收藏的所有歌曲
        private async Task TestGetFavoriteSongs()
        {
            try
            {
                await _userService.Login("admin", "123456789");
                var songs = await _favoritesService.GetFavoriteSongsAsync("admin");
                listBoxResults.Items.Add($"3. 获取用户收藏的所有歌曲测试: ✓ 完成");
                listBoxResults.Items.Add($"   找到 {songs.Count} 条收藏歌曲");
                foreach (var song in songs)
                {
                    listBoxResults.Items.Add($"   - {song.Title} - {song.Artist}");
                }
            }
            catch (Exception ex)
            {
                listBoxResults.Items.Add($"3. 获取用户收藏的所有歌曲测试: ✗ 异常 - {ex.Message}");
            }
            finally
            {
                _userService.Logout();
            }
        }

        // 测试4: 获取用户收藏歌曲的数量
        private async Task TestGetFavoriteSongsCount()
        {
            try
            {
                await _userService.Login("admin", "123456789");
                int count = await _favoritesService.GetFavoriteSongsCountAsync("admin");
                listBoxResults.Items.Add($"4. 获取用户收藏歌曲的数量测试: ✓ 完成");
                listBoxResults.Items.Add($"   收藏歌曲数量: {count}");
            }
            catch (Exception ex)
            {
                listBoxResults.Items.Add($"4. 获取用户收藏歌曲的数量测试: ✗ 异常 - {ex.Message}");
            }
            finally
            {
                _userService.Logout();
            }
        }

        // 测试5: 批量添加收藏歌曲
        private async Task TestAddFavoriteSongs()
        {
            try
            {
                await _userService.Login("admin", "123456789");
                bool result = await _favoritesService.AddFavoriteSongsAsync("admin", new List<int> { 1, 2, 3 });
                listBoxResults.Items.Add($"5. 批量添加收藏歌曲测试: {(result ? "✓ 通过" : "✗ 失败")}");
            }
            catch (Exception ex)
            {
                listBoxResults.Items.Add($"5. 批量添加收藏歌曲测试: ✗ 异常 - {ex.Message}");
            }
            finally
            {
                _userService.Logout();
            }
        }

        // 测试6: 清空用户的所有收藏
        private async Task TestClearAllFavorites()
        {
            try
            {
                await _userService.Login("admin", "123456789");
                bool result = await _favoritesService.ClearAllFavoritesAsync("admin");
                listBoxResults.Items.Add($"6. 清空用户的所有收藏测试: {(result ? "✓ 通过" : "✗ 失败")}");
            }
            catch (Exception ex)
            {
                listBoxResults.Items.Add($"6. 清空用户的所有收藏测试: ✗ 异常 - {ex.Message}");
            }
            finally
            {
                _userService.Logout();
            }
        }
    }
}