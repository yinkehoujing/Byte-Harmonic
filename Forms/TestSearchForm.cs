using System;
using System.Windows.Forms;
using Byte_Harmonic.Database;
using Byte_Harmonic.Models;
using Byte_Harmonic.Services;
using System.Threading.Tasks;

namespace Byte_Harmonic.Forms
{
    public partial class TestSearchForm : Form
    {
        private readonly SonglistRepository _songlistRepo;
        private readonly UserRepository _userRepo;
        private readonly UserService _userService;
        private readonly SearchService _searchService;
        private readonly string _connectionString =
            "server=localhost;user=root;database=Byte_Harmonic;port=3306;password=595129854";
        public TestSearchForm()
        {
            InitializeComponent();
            _songlistRepo = new SonglistRepository(_connectionString);
            _userRepo = new UserRepository();
            _userService = new UserService(_userRepo);
            _searchService = new SearchService(_songlistRepo, _userRepo, _userService);
        }

        private async void btnRunTests_Click(object sender, EventArgs e)
        {
            listBoxResults.Items.Clear();
            await RunAllSearchTests();
            MessageBox.Show("搜索测试完成！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async Task RunAllSearchTests()
        {
           // await TestEmptyKeywordSearch();
           // await TestWhitespaceKeywordSearch();
            await TestLoggedInUserSearch();
            await DisplaySampleResults();
        }

        // 测试1: 空关键字搜索
        private async Task TestEmptyKeywordSearch()
        {
            try
            {
                var result = await _searchService.SearchSongs("");
                listBoxResults.Items.Add($"1. 空关键字测试: {(result.Count == 0 ? "✓ 通过" : "✗ 失败")}");
                listBoxResults.Items.Add($"   预期: 0 条结果, 实际: {result.Count} 条结果");
            }
            catch (Exception ex)
            {
                listBoxResults.Items.Add($"1. 空关键字测试: ✗ 异常 - {ex.Message}");
            }
        }

        // 测试2: 空格关键字搜索
        private async Task TestWhitespaceKeywordSearch()
        {
            try
            {
                var result = await _searchService.SearchSongs("   ");
                listBoxResults.Items.Add($"2. 空格关键字测试: {(result.Count == 0 ? "✓ 通过" : "✗ 失败")}");
                listBoxResults.Items.Add($"   预期: 0 条结果, 实际: {result.Count} 条结果");
            }
            catch (Exception ex)
            {
                listBoxResults.Items.Add($"2. 空格关键字测试: ✗ 异常 - {ex.Message}");
            }
        }

        // 测试3: 登录用户搜索
        private async Task TestLoggedInUserSearch()
        {
            try
            {
                await _userService.Login("admin", "123456789");
                var result = await _searchService.SearchSongs("天外来物");

                listBoxResults.Items.Add($"3. 登录用户搜索测试: ✓ 完成");
                listBoxResults.Items.Add($"   找到 {result.Count} 条匹配结果");

                // 验证搜索历史
                var user = _userService.GetCurrentUser();
                var history = await _userRepo.GetSearchHistoryAsync(user.Account);
                bool historyRecorded = history.Contains("天外来物");

                listBoxResults.Items.Add($"   搜索历史记录: {(historyRecorded ? "✓ 已记录" : "✗ 未记录")}");
            }
            catch (Exception ex)
            {
                listBoxResults.Items.Add($"3. 登录用户搜索测试: ✗ 异常 - {ex.Message}");
            }
            finally
            {
                _userService.Logout();
            }
        }

  
        // 测试4: 显示示例结果
        private async Task DisplaySampleResults()
        {
            try
            {
                var result = await _searchService.SearchSongs("传奇");

                if (result.Count > 0)
                {
                    listBoxResults.Items.Add("5. 搜索结果示例:");
                    foreach (var song in result.Take(3))
                    {
                        listBoxResults.Items.Add($"   - {song.Title} - {song.Artist}");
                    }
                }
                else
                {
                    listBoxResults.Items.Add("5. 搜索结果示例: 无匹配结果");
                }
            }
            catch (Exception ex)
            {
                listBoxResults.Items.Add($"5. 结果显示测试: ✗ 异常 - {ex.Message}");
            }
        }
    }
}