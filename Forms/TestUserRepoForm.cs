using System;
using System.Windows.Forms;
using Byte_Harmonic.Database;
using Byte_Harmonic.Models;
using Byte_Harmonic.Services;
#region 初始测试
/* Byte_Harmonic.Forms
{
    public partial class TestUserRepoForm : Form
    {
        private readonly UserRepository _userRepo;

        public TestUserRepoForm()
        {
            InitializeComponent();
            _userRepo = new UserRepository();
        }

        private void btnRunTests_Click(object sender, EventArgs e)
        {
            listBoxResults.Items.Clear();
            RunTests();
            MessageBox.Show("测试完成！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void RunTests()
        {
            TestAddUser();
            TestGetUserByAccount();
            TestVerifyPassword();
            TestUpdateUserInfo();
            TestUpdatePassword();
            TestDeleteUser();
        }

        private void TestAddUser()
        {
            var user = new User
            {
                Account = "test@example.com",
                Username = "TestUser",
                Password = "testPassword123", // 会被自动哈希
                IsAdmin = false
            };

            bool result = _userRepo.AddUser(user);
            listBoxResults.Items.Add($"AddUser: {(result ? "通过" : "失败")}");
        }

        private void TestGetUserByAccount()
        {
            var user = _userRepo.GetUserByAccount("test@example.com");
            bool result = user != null;
            listBoxResults.Items.Add($"GetUserByAccount: {(result ? "通过" : "失败")}");
            if (result)
            {
                Console.WriteLine($"User Info - Account: {user.Account}, Username: {user.Username}");
            }
        }

        private void TestVerifyPassword()
        {
            bool result = _userRepo.VerifyPassword("test@example.com", "testPassword123");
            listBoxResults.Items.Add($"VerifyPassword(正确密码): {(result ? "通过" : "失败")}");

            bool invalidResult = _userRepo.VerifyPassword("test@example.com", "wrongPassword");
            listBoxResults.Items.Add($"VerifyPassword(错误密码): {(invalidResult ? "异常-错误通过" : "通过")}");
        }

        private void TestUpdateUserInfo()
        {
            var user = _userRepo.GetUserByAccount("test@example.com");
            if (user != null)
            {
                user.Username = "UpdatedUser";
                bool result = _userRepo.UpdateUserInfo(user);
                listBoxResults.Items.Add($"UpdateUserInfo: {(result ? "通过" : "失败")}");
                Console.WriteLine($"更新后用户名: {user.Username}");
            }
            else
            {
                listBoxResults.Items.Add("UpdateUserInfo: 未找到用户，跳过测试");
            }
        }

        private void TestUpdatePassword()
        {
            bool result = _userRepo.UpdatePassword("test@example.com", "newPassword123");
            listBoxResults.Items.Add($"UpdatePassword: {(result ? "通过" : "失败")}");

            // 验证新密码是否生效
            bool verifyResult = _userRepo.VerifyPassword("test@example.com", "newPassword123");
            listBoxResults.Items.Add($"验证新密码: {(verifyResult ? "通过" : "失败")}");
        }

        private void TestDeleteUser()
        {
            

            bool result = _userRepo.DeleteUser("test@example.com");
            listBoxResults.Items.Add($"DeleteUser: {(result ? "通过" : "失败")}");

            // 验证是否已删除
            var deletedUser = _userRepo.GetUserByAccount("test@example.com");
            listBoxResults.Items.Add($"验证删除结果: {(deletedUser == null ? "通过" : "失败")}");
        }
    }
}*/
#endregion

#region 异步数据库测试
/*namespace Byte_Harmonic.Forms
{
    public partial class TestUserRepoForm : Form
    {
        private readonly UserRepository _userRepo;

        public TestUserRepoForm()
        {
            InitializeComponent();
            _userRepo = new UserRepository();
        }

        private async void btnRunTests_Click(object sender, EventArgs e)
        {
            listBoxResults.Items.Clear();
            await RunTestsAsync();
            MessageBox.Show("测试完成！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async Task RunTestsAsync()
        {
            await TestAddUserAsync();
            await TestGetUserByAccountAsync();
            await TestVerifyPasswordAsync();
            await TestUpdateUserInfoAsync();
            await TestUpdatePasswordAsync();
            // await TestDeleteUserAsync();
        }

        private async Task TestAddUserAsync()
        {
            var user = new User
            {
                Account = "test@example.com",
                Username = "TestUser",
                Password = "testPassword123", // 会被哈希
                IsAdmin = false
            };

            bool result = await _userRepo.AddUserAsync(user);
            listBoxResults.Items.Add($"AddUser: {(result ? "通过" : "失败")}");
        }

        private async Task TestGetUserByAccountAsync()
        {
            var user = await _userRepo.GetUserByAccountAsync("test@example.com");
            bool result = user != null;
            listBoxResults.Items.Add($"GetUserByAccount: {(result ? "通过" : "失败")}");
            if (result)
            {
                Console.WriteLine($"用户信息 - Account: {user.Account}, Username: {user.Username}");
            }
        }

        private async Task TestVerifyPasswordAsync()
        {
            bool result = await _userRepo.VerifyPasswordAsync("test@example.com", "testPassword123");
            listBoxResults.Items.Add($"VerifyPassword(正确密码): {(result ? "通过" : "失败")}");

            bool invalidResult = await _userRepo.VerifyPasswordAsync("test@example.com", "wrongPassword");
            listBoxResults.Items.Add($"VerifyPassword(错误密码): {(invalidResult ? "异常-错误通过" : "通过")}");
        }

        private async Task TestUpdateUserInfoAsync()
        {
            var user = await _userRepo.GetUserByAccountAsync("test@example.com");
            if (user != null)
            {
                user.Username = "张三";
                bool result = await _userRepo.UpdateUserInfoAsync(user);
                listBoxResults.Items.Add($"UpdateUserInfo: {(result ? "通过" : "失败")}");
                Console.WriteLine($"更新后用户名: {user.Username}");
            }
            else
            {
                listBoxResults.Items.Add("UpdateUserInfo: 未找到用户，跳过测试");
            }
        }

        private async Task TestUpdatePasswordAsync()
        {
            bool result = await _userRepo.UpdatePasswordAsync("test@example.com", "newPassword123");
            listBoxResults.Items.Add($"UpdatePassword: {(result ? "通过" : "失败")}");

            // 验证新密码是否生效
            bool verifyResult = await _userRepo.VerifyPasswordAsync("test@example.com", "newPassword123");
            listBoxResults.Items.Add($"验证新密码: {(verifyResult ? "通过" : "失败")}");
        }

        private async Task TestDeleteUserAsync()
        {
            bool result = await _userRepo.DeleteUserAsync("test@example.com");
            listBoxResults.Items.Add($"DeleteUser: {(result ? "通过" : "失败")}");

            // 验证是否已删除
            var deletedUser = await _userRepo.GetUserByAccountAsync("test@example.com");
            listBoxResults.Items.Add($"验证删除结果: {(deletedUser == null ? "通过" : "失败")}");
        }
    }
}*/
#endregion

//services测试
namespace Byte_Harmonic.Forms
{
    public partial class TestUserRepoForm : Form
    {
        private readonly UserRepository _userRepo;
        private readonly UserService _userService;

        public TestUserRepoForm()
        {
            InitializeComponent();
            _userRepo = new UserRepository();
            _userService = new UserService(_userRepo);
        }

        private async void btnRunTests_Click(object sender, EventArgs e)
        {
            listBoxResults.Items.Clear();
            await RunTestsAsync();
            MessageBox.Show("测试完成！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async Task RunTestsAsync()
        {
            await TestLogin();
            //await TestRegister();
            //await TestUpdateUsername();
           // await TestChangePassword();
            //await TestDeleteAccount();
        }
        //测试登录
        private async Task TestLogin()
        {
            try
            {
                await _userService.Login("admin", "123456789");
                 var user= _userService.GetCurrentUser();
                listBoxResults.Items.Add($"LoginAsync: 通过 (用户: {user.Username})");
            }
            catch (Exception ex)
            {
                listBoxResults.Items.Add($"LoginAsync: 失败 ({ex.Message})");
            }
        }
        //测试注册
        private async Task TestRegister()
        {
            try
            {
                await _userService.Register("newuser@", "123456789", "NewUser");
                listBoxResults.Items.Add("RegisterAsync: 通过");
            }
            catch (Exception ex)
            {
                listBoxResults.Items.Add($"RegisterAsync: 失败 ({ex.Message})");
            }
        }
        //测试改名
        private async Task TestUpdateUsername()
        {
            try
            {
                await _userService.Login("newuser@", "123456789");
                await _userService.UpdateUsername("李四");
                listBoxResults.Items.Add("UpdateUsernameAsync: 通过");
            }
            catch (Exception ex)
            {
                listBoxResults.Items.Add($"UpdateUsernameAsync: 失败 ({ex.Message})");
            }
        }
        //测试改密码
        private async Task TestChangePassword()
        {
            try
            {
                await _userService.Login("test@", "123456789");
                await _userService.ChangePassword("123456789", "abcdef123");
                listBoxResults.Items.Add("ChangePasswordAsync: 通过");
            }
            catch (Exception ex)
            {
                listBoxResults.Items.Add($"ChangePasswordAsync: 失败 ({ex.Message})");
            }
        }
        //测试删除用户
        private async Task TestDeleteAccount()
        {
            try
            {
                await _userService.Login("newuser@", "123456789");
                await _userService.DeleteAccount("123456789");
                listBoxResults.Items.Add("DeleteAccountAsync: 通过");
            }
            catch (Exception ex)
            {
                listBoxResults.Items.Add($"DeleteAccountAsync: 失败 ({ex.Message})");
            }
        }
    }
}