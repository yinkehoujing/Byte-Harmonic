using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using Byte_Harmonic.Models;
using Byte_Harmonic.Utils;


//新操作
namespace Byte_Harmonic.Database
{
    public class UserRepository
    {
        private readonly string _connectionString =
            "server=localhost;user=root;database=Byte_Harmonic;port=3306;password=595129854";

        // 无参构造：从 ConfigManager 里拿连接串
        public UserRepository()
        {
            _connectionString = ConfigManager.GetConnectionString("DefaultConnection");
        }

        // 保留一个注入构造，方便测试
        public UserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }


        #region 用户系统
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
        // 删除用户（用户收藏表操作未加）
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
        #endregion



        #region 收藏歌曲功能

        // 检查歌曲是否已被收藏
        public async Task<bool> IsSongFavoriteAsync(string username, int songId)
        {
            using var connection = new MySqlConnection(_connectionString);
            await connection.OpenAsync();

            const string sql = "SELECT COUNT(*) FROM Favorites WHERE Username = @Username AND SongId = @SongId";
            using var cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@SongId", songId);

            var count = (long)await cmd.ExecuteScalarAsync();
            return count > 0;
        }

        // 收藏歌曲
        public async Task<bool> AddFavoriteSongAsync(string username, int songId)
        {
            using var connection = new MySqlConnection(_connectionString);
            await connection.OpenAsync();

            // 先检查是否已收藏
            if (await IsSongFavoriteAsync(username, songId))
            {
                return false;
            }

            const string sql = "INSERT INTO Favorites (Username, SongId) VALUES (@Username, @SongId)";
            using var cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@SongId", songId);

            return await cmd.ExecuteNonQueryAsync() > 0;
        }

        // 取消收藏
        public async Task<bool> RemoveFavoriteSongAsync(string username, int songId)
        {
            using var connection = new MySqlConnection(_connectionString);
            await connection.OpenAsync();

            const string sql = "DELETE FROM Favorites WHERE Username = @Username AND SongId = @SongId";
            using var cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@SongId", songId);

            return await cmd.ExecuteNonQueryAsync() > 0;
        }

        // 获取用户收藏的所有歌曲
        public async Task<List<Song>> GetFavoriteSongsAsync(string username)
        {
            var songs = new List<Song>();
            using var connection = new MySqlConnection(_connectionString);
            await connection.OpenAsync();

            const string sql = @"
        SELECT s.Id, s.Title, s.Artist, s.MusicFilePath, s.LrcFilePath, s.Downloaded, s.Duration
        FROM Favorites f
        JOIN Songs s ON f.SongId = s.Id
        WHERE f.Username = @Username
        ORDER BY s.Title";

            using var cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@Username", username);

            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                songs.Add(new Song
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    Title = reader.GetString(reader.GetOrdinal("Title")),
                    Artist = reader.GetString(reader.GetOrdinal("Artist")),
                    MusicFilePath = reader.GetString(reader.GetOrdinal("MusicFilePath")),
                    LrcFilePath = reader.IsDBNull(reader.GetOrdinal("LrcFilePath")) ? null : reader.GetString(reader.GetOrdinal("LrcFilePath")),
                    Downloaded = reader.GetBoolean(reader.GetOrdinal("Downloaded")),
                    Duration = reader.GetInt32(reader.GetOrdinal("Duration"))
                });
            }

            return songs;
        }

        // 获取用户收藏歌曲的数量
        public async Task<int> GetFavoriteSongsCountAsync(string username)
        {
            using var connection = new MySqlConnection(_connectionString);
            await connection.OpenAsync();

            const string sql = "SELECT COUNT(*) FROM Favorites WHERE Username = @Username";
            using var cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@Username", username);

            return Convert.ToInt32(await cmd.ExecuteScalarAsync());
        }

        // 批量添加收藏歌曲
        public async Task<bool> AddFavoriteSongsAsync(string username, IEnumerable<int> songIds)
        {
            using var connection = new MySqlConnection(_connectionString);
            await connection.OpenAsync();
            using var transaction = await connection.BeginTransactionAsync();

            try
            {
                foreach (var songId in songIds)
                {
                    if (!await IsSongFavoriteAsync(username, songId))
                    {
                        const string sql = "INSERT INTO Favorites (Username, SongId) VALUES (@Username, @SongId)";
                        using var cmd = new MySqlCommand(sql, connection, transaction);
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@SongId", songId);
                        await cmd.ExecuteNonQueryAsync();
                    }
                }

                await transaction.CommitAsync();
                return true;
            }
            catch
            {
                await transaction.RollbackAsync();
                return false;
            }
        }

        // 清空用户的所有收藏
        public async Task<bool> ClearAllFavoritesAsync(string username)
        {
            using var connection = new MySqlConnection(_connectionString);
            await connection.OpenAsync();

            const string sql = "DELETE FROM Favorites WHERE Username = @Username";
            using var cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@Username", username);

            return await cmd.ExecuteNonQueryAsync() > 0;
        }

        #endregion

        #region 搜索历史功能
        //添加搜索记录
        public async Task<bool> AddSearchHistoryAsync(string username, string keyword)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(keyword))
            {
                return false;
            }

            keyword = keyword.Trim();

            using var connection = new MySqlConnection(_connectionString);
            await connection.OpenAsync();

            // 首先检查是否已存在相同的搜索记录
            const string checkSql = @"
        SELECT COUNT(*) FROM SearchHistory 
        WHERE Username = @Username AND Keyword = @Keyword";

            using var checkCmd = new MySqlCommand(checkSql, connection);
            checkCmd.Parameters.AddWithValue("@Username", username);
            checkCmd.Parameters.AddWithValue("@Keyword", keyword);

            var exists = (long)await checkCmd.ExecuteScalarAsync() > 0;

            // 如果已存在，则只更新时间
            if (exists)
            {
                const string updateSql = @"
            UPDATE SearchHistory 
            SET Time = UTC_TIMESTAMP()
            WHERE Username = @Username AND Keyword = @Keyword";

                using var updateCmd = new MySqlCommand(updateSql, connection);
                updateCmd.Parameters.AddWithValue("@Username", username);
                updateCmd.Parameters.AddWithValue("@Keyword", keyword);

                return await updateCmd.ExecuteNonQueryAsync() > 0;
            }
            // 如果不存在，则插入新记录
            else
            {
                const string insertSql = @"
            INSERT INTO SearchHistory (Username, Keyword, Time)
            VALUES (@Username, @Keyword, UTC_TIMESTAMP())";

                using var insertCmd = new MySqlCommand(insertSql, connection);
                insertCmd.Parameters.AddWithValue("@Username", username);
                insertCmd.Parameters.AddWithValue("@Keyword", keyword);

                return await insertCmd.ExecuteNonQueryAsync() > 0;
            }
        }
        //返回搜索记录
        public async Task<List<string>> GetSearchHistoryAsync(string username, int limit = 10)
        {
            var keywords = new List<string>();
            using var connection = new MySqlConnection(_connectionString);
            await connection.OpenAsync();

            const string sql = @"
                SELECT Keyword 
                FROM SearchHistory 
                WHERE Username = @Username 
                ORDER BY Time DESC 
                LIMIT @Limit";

            using var cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@Limit", Math.Clamp(limit, 1, 50));

            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                keywords.Add(reader.GetString(reader.GetOrdinal("Keyword")));
            }
            return keywords;
        }
        //清空搜索记录
        public async Task<bool> ClearSearchHistoryAsync(string username)
        {
            using var connection = new MySqlConnection(_connectionString);
            await connection.OpenAsync();

            const string sql = "DELETE FROM SearchHistory WHERE Username = @Username";
            using var cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@Username", username);

            return await cmd.ExecuteNonQueryAsync() > 0;
        }
        #endregion

    }
}
