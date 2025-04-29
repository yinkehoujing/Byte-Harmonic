using System;
using System.Windows.Forms;
using ByteHarmonic.Database;
using ByteHarmonic.Models;

namespace ByteHarmonic.Forms
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
}