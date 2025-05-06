using System;
using System.Threading.Tasks;
using System.Text;
using Byte_Harmonic.Models;
using Byte_Harmonic.Database;
using Byte_Harmonic.Utils;


namespace Byte_Harmonic.Services
{
    /// <summary>
    /// 提供用户相关的业务逻辑，如登录、注册、修改信息等。
    /// </summary>
    public class UserService
    {
        private readonly UserRepository _userRepository;
        private User? _currentUser;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        /// <summary>
        /// 登录用户，如果成功则设置为当前用户。
        /// </summary>
        public async Task<User> Login(string account, string password)
        {
            if (string.IsNullOrWhiteSpace(account) || string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("账号和密码不能为空");

            var user = await _userRepository.GetUserByAccountAsync(account);
            if (user == null || !await _userRepository.VerifyPasswordAsync(account, password))
                throw new UnauthorizedAccessException("账号或密码错误");

            _currentUser = user;
            return user;
        }

        /// <summary>
        /// 登出
        /// </summary>
        public void Logout()
        {
            _currentUser = null;
        }

        /// <summary>
        /// 获取当前登录用户。
        /// </summary>
        public User? GetCurrentUser() => _currentUser;

        /// <summary>
        /// 是否已登录。
        /// </summary>
        public bool IsLoggedIn => _currentUser != null;

        /// <summary>
        /// 是否为管理员。
        /// </summary>
        public bool IsAdmin => _currentUser?.IsAdmin == true;

        /// <summary>
        /// 注册新用户；仅允许管理员添加管理员
        /// </summary>
        public async Task Register(string account, string password, string? username = null, bool isAdmin = false)
        {
            if (string.IsNullOrWhiteSpace(account))
                throw new ArgumentException("账号不能为空");
            if (string.IsNullOrWhiteSpace(password) || password.Length < 8)
                throw new ArgumentException("密码长度至少8位");

            if (await _userRepository.GetUserByAccountAsync(account) != null)
                throw new InvalidOperationException("账号已存在");

           /* if (isAdmin && !IsAdmin)
                throw new UnauthorizedAccessException("仅管理员可以注册管理员账号");*/

            var user = new User
            {
                Account = account.Trim(),
                Username = string.IsNullOrWhiteSpace(username) ? account.Trim() : username.Trim(),
                Password = password,
                IsAdmin = isAdmin
            };

            var success = await _userRepository.AddUserAsync(user);
            if (!success)
                throw new Exception("注册失败，请稍后重试");
        }

        /// <summary>
        /// 修改用户名
        /// </summary>
        public async Task UpdateUsername(string newUsername)
        {
            if (_currentUser == null)
                throw new InvalidOperationException("当前未登录");

            if (string.IsNullOrWhiteSpace(newUsername))
                throw new ArgumentException("新用户名不能为空");

            _currentUser.Username = newUsername.Trim();

            var success = await _userRepository.UpdateUserInfoAsync(_currentUser);
            if (!success)
                throw new Exception("更新用户信息失败");
        }

        /// <summary>
        /// 修改当前用户密码。
        /// </summary>
        public async Task ChangePassword(string currentPassword, string newPassword)
        {
            if (_currentUser == null)
                throw new InvalidOperationException("当前未登录");

            if (string.IsNullOrWhiteSpace(newPassword) || newPassword.Length < 8)
                throw new ArgumentException("新密码长度至少8位");

            if (!await _userRepository.VerifyPasswordAsync(_currentUser.Account, currentPassword))
                throw new UnauthorizedAccessException("当前密码错误");

            var success = await _userRepository.UpdatePasswordAsync(_currentUser.Account, newPassword);
            if (!success)
                throw new Exception("密码更新失败");
        }

        /// <summary>
        /// 删除当前用户账号（需要确认密码）。
        /// </summary>
        public async Task DeleteAccount(string confirmPassword)
        {
            if (_currentUser == null)
                throw new InvalidOperationException("当前未登录");

            if (!await _userRepository.VerifyPasswordAsync(_currentUser.Account, confirmPassword))
                throw new UnauthorizedAccessException("密码验证失败");

            var success = await _userRepository.DeleteUserAsync(_currentUser.Account);
            if (!success)
                throw new Exception("删除账户失败");

            _currentUser = null;
        }
    }
}
