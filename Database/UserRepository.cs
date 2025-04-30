using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using Byte_Harmonic.Models;
using Byte_Harmonic.Utils;
using MySql.Data.MySqlClient;


#region 同步操作
/*namespace Byte_Harmonic.Database
{
    public class UserRepository
    {
        private readonly string _connectionString = "server=localhost;user=root;database=Byte_Harmonic;port=3306;password=595129854";

        // 添加用户（返回是否成功）
        public bool AddUser(User user)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string sql = @"INSERT INTO Users (Account, Username, Password, IsAdmin) 
                          VALUES (@Account, @Username, @Password, @IsAdmin)";

            using var cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@Account", user.Account);
            cmd.Parameters.AddWithValue("@Username", user.Username);
            cmd.Parameters.AddWithValue("@Password", PasswordHasher.Hash(user.Password));
            cmd.Parameters.AddWithValue("@IsAdmin", user.IsAdmin ? 1 : 0);

            return cmd.ExecuteNonQuery() > 0;
        }

        // 根据账号获取用户
        public User GetUserByAccount(string account)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string sql = "SELECT * FROM Users WHERE Account = @Account";
            using var cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@Account", account);

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new User
                {
                    Account = reader.GetString("Account"),
                    Username = reader.GetString("Username"),
                    Password = reader.GetString("Password"),
                    IsAdmin = reader.GetBoolean("IsAdmin")
                };
            }
            return null;
        }

        // 验证用户密码
        public bool VerifyPassword(string account, string inputPassword)
        {
            var user = GetUserByAccount(account);
            return user != null && PasswordHasher.Verify(inputPassword, user.Password);
        }

        // 更新用户信息（不包含密码）
        public bool UpdateUserInfo(User user)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string sql = @"UPDATE Users 
                          SET Username = @Username, 
                              IsAdmin = @IsAdmin
                          WHERE Account = @Account";

            using var cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@Username", user.Username);
            cmd.Parameters.AddWithValue("@IsAdmin", user.IsAdmin ? 1 : 0);
            cmd.Parameters.AddWithValue("@Account", user.Account);

            return cmd.ExecuteNonQuery() > 0;
        }

        // 更新密码（单独方法）
        public bool UpdatePassword(string account, string newPassword)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string sql = "UPDATE Users SET Password = @Password WHERE Account = @Account";
            using var cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@Password", PasswordHasher.Hash(newPassword));
            cmd.Parameters.AddWithValue("@Account", account);

            return cmd.ExecuteNonQuery() > 0;
        }

        // 删除用户（需先清理关联数据）
        public bool DeleteUser(string account)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();
            using var transaction = connection.BeginTransaction();

            try
            {
               /* // 1. 删除收藏记录
                var deleteFavoritesCmd = new MySqlCommand(
                    "DELETE FROM Favorites WHERE Username = @Account",
                    connection, transaction
                );
                deleteFavoritesCmd.Parameters.AddWithValue("@Account", account);
                deleteFavoritesCmd.ExecuteNonQuery();

                // 2. 删除用户
                var deleteUserCmd = new MySqlCommand(
                    "DELETE FROM Users WHERE Account = @Account",
                    connection, transaction
                );
                deleteUserCmd.Parameters.AddWithValue("@Account", account);
                deleteUserCmd.ExecuteNonQuery();

                transaction.Commit();
                return true;
            }
            catch
            {
                transaction.Rollback();
                return false;
            }
        }
    }
}*/
#endregion



namespace Byte_Harmonic.Database
{
    public class UserRepository
    {
        private readonly string _connectionString =
            "server=localhost;user=root;database=Byte_Harmonic;port=3306;password=595129854";
        // 添加用户（返回是否成功）
        public async Task<bool> AddUserAsync(User user)
        {
            using var connection = new MySqlConnection(_connectionString);
            await connection.OpenAsync();

            const string sql = @"INSERT INTO Users (Account, Username, Password, IsAdmin)
                                 VALUES (@Account, @Username, @Password, @IsAdmin)";

            using var cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@Account", user.Account);
            cmd.Parameters.AddWithValue("@Username", user.Username);
            cmd.Parameters.AddWithValue("@Password", PasswordHasher.Hash(user.Password));
            cmd.Parameters.AddWithValue("@IsAdmin", user.IsAdmin ? 1 : 0);

            return await cmd.ExecuteNonQueryAsync() > 0;
        }
        // 根据账号获取用户
        public async Task<User?> GetUserByAccountAsync(string account)
        {
            using var connection = new MySqlConnection(_connectionString);
            await connection.OpenAsync();

            const string sql = "SELECT * FROM Users WHERE Account = @Account";
            using var cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@Account", account);

            using var reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                return new User
                {
                    Account = reader.GetString(reader.GetOrdinal("Account")),
                    Username = reader.GetString(reader.GetOrdinal("Username")),
                    Password = reader.GetString(reader.GetOrdinal("Password")),
                    IsAdmin = reader.GetBoolean(reader.GetOrdinal("IsAdmin"))
                };
            }

            return null;
        }
        // 验证用户密码
        public async Task<bool> VerifyPasswordAsync(string account, string inputPassword)
        {
            var user = await GetUserByAccountAsync(account);
            return user != null && PasswordHasher.Verify(inputPassword, user.Password);
        }
        //更新用户信息（不包含密码）
        public async Task<bool> UpdateUserInfoAsync(User user)
        {
            using var connection = new MySqlConnection(_connectionString);
            await connection.OpenAsync();

            const string sql = @"UPDATE Users
                                 SET Username = @Username,
                                     IsAdmin = @IsAdmin
                                 WHERE Account = @Account";

            using var cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@Username", user.Username);
            cmd.Parameters.AddWithValue("@IsAdmin", user.IsAdmin ? 1 : 0);
            cmd.Parameters.AddWithValue("@Account", user.Account);

            return await cmd.ExecuteNonQueryAsync() > 0;
        }
        // 更新密码（单独方法，确保安全性）
        public async Task<bool> UpdatePasswordAsync(string account, string newPassword)
        {
            using var connection = new MySqlConnection(_connectionString);
            await connection.OpenAsync();

            const string sql = "UPDATE Users SET Password = @Password WHERE Account = @Account";
            using var cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@Password", PasswordHasher.Hash(newPassword));
            cmd.Parameters.AddWithValue("@Account", account);

            return await cmd.ExecuteNonQueryAsync() > 0;
        }
        // 删除用户（清理关联数据）
        public async Task<bool> DeleteUserAsync(string account)
        {
            using var connection = new MySqlConnection(_connectionString);
            await connection.OpenAsync();
            using var transaction = await connection.BeginTransactionAsync();

            try
            {
                const string sql = "DELETE FROM Users WHERE Account = @Account";
                using var cmd = new MySqlCommand(sql, connection, transaction);
                cmd.Parameters.AddWithValue("@Account", account);
                await cmd.ExecuteNonQueryAsync();

                await transaction.CommitAsync();
                return true;
            }
            catch
            {
                await transaction.RollbackAsync();
                return false;
            }
        }
    }
}
