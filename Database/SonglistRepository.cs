using System;
using System.Collections.Generic;
using System.Data;
using Byte_Harmonic.Models;
using MySql.Data.MySqlClient; // 根据实际数据库类型调整
using Dapper;
using System.Data.SqlClient;
using Byte_Harmonic.Utils;
using System.Data.Common;

namespace Byte_Harmonic.Database
{
    /// <summary>
    /// 曲库数据仓库 - 处理歌曲、标签、歌单的数据库操作
    /// </summary>
    public class SonglistRepository
    {
        private readonly string _connectionString;
        private string connectionString = "server=localhost;user=root;database=Byte_Harmonic;port=3306;password=";

        public SonglistRepository()
        {
            if (!File.Exists(FileHelper.GetProjectRootPath("passwd.txt")))
            {
                Console.WriteLine("未找到本地根目录下 passwd.txt, 使用默认的连接字符串");
                _connectionString = connectionString;
            }
            else
            {
                // 不要修改下面内容！！！
                connectionString = "server=localhost;user=root;database=Byte_Harmonic;port=3306;password=";
                var firstNonEmptyLine = File.ReadLines(FileHelper.GetProjectRootPath("passwd.txt"))
                                            .Select(line => line.Trim())
                                            .FirstOrDefault(line => !string.IsNullOrEmpty(line));

                connectionString += firstNonEmptyLine;
                _connectionString = connectionString;

            }
        }

        public SonglistRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        #region 歌曲管理
        //往曲库中添加歌曲
        //创新点：异步操作（以保证对曲库进行操作时的原子性）
        public async Task<int> AddSongAsync(Song song)
        {
            using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync();

            const string sql = @"INSERT INTO Songs 
                (Title, Artist, MusicFilePath, LrcFilePath, Downloaded, Duration)
                VALUES (@title, @artist, @musicPath, @lrcPath, @downloaded, @duration);
                SELECT LAST_INSERT_ID();";

            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@title", song.Title);
            cmd.Parameters.AddWithValue("@artist", song.Artist);
            cmd.Parameters.AddWithValue("@musicPath", song.MusicFilePath);
            cmd.Parameters.AddWithValue("@lrcPath", song.LrcFilePath);
            cmd.Parameters.AddWithValue("@downloaded", song.Downloaded);
            cmd.Parameters.AddWithValue("@duration", song.Duration);

            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        //获取曲库中所有歌曲（用于增量导入优化）
        public async Task<List<Song>> GetAllSongsAsync()
        {
            try
            {
                using var conn = new MySqlConnection(_connectionString);
                await conn.OpenAsync();

                const string sql = @"SELECT 
                        Id,
                        Title,
                        Artist,
                        MusicFilePath,
                        LrcFilePath,
                        Downloaded,
                        Duration
                        FROM Songs";

                return (await conn.QueryAsync<Song>(sql)).ToList();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"数据库查询失败: {ex.Message}");
                return new List<Song>();
            }
        }

        //从曲库中删除歌曲
        public async Task DeleteSongAsync(int songId)
        {
            using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync();

            using var transaction = await conn.BeginTransactionAsync();
            try
            {
                // 删除关联标签
                await conn.ExecuteAsync("DELETE FROM SongTags WHERE SongId = @songId",
                    new { songId }, transaction);

                // 删除歌单关联
                await conn.ExecuteAsync("DELETE FROM SonglistSongs WHERE SongId = @songId",
                    new { songId }, transaction);

                // 删除歌曲
                await conn.ExecuteAsync("DELETE FROM Songs WHERE Id = @songId",
                    new { songId }, transaction);

                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        //通过Id获取对应歌曲
        public Song GetSongById(int songId)
        {
            using var conn = new MySqlConnection(_connectionString);
            const string sql = @"SELECT * FROM Songs WHERE Id = @songId";
            return conn.QueryFirstOrDefault<Song>(sql, new { songId });
        }

        #endregion

        #region 标签管理
        //添加新标签（如果标签已在数据库存在则返回Id号）
        public int EnsureTagExists(string tagName)
        {
            using var conn = new MySqlConnection(_connectionString);
            conn.Open();

            // 查询现有标签
            var findSql = "SELECT Id FROM Tags WHERE Name = @name";
            using var findCmd = new MySqlCommand(findSql, conn);
            findCmd.Parameters.AddWithValue("@name", tagName);

            if (findCmd.ExecuteScalar() is int existingId)
                return existingId;

            // 插入新标签
            const string insertSql = @"INSERT INTO Tags (Name) VALUES (@name);
                                    SELECT LAST_INSERT_ID();";
            using var insertCmd = new MySqlCommand(insertSql, conn);
            insertCmd.Parameters.AddWithValue("@name", tagName);
            return Convert.ToInt32(insertCmd.ExecuteScalar());
        }

        //往歌曲添加标签
        public void AssignTagToSong(int songId, int tagId)
        {
            using var conn = new MySqlConnection(_connectionString);
            conn.Open();

            const string sql = @"INSERT IGNORE INTO SongTags (SongId, TagId)
                                VALUES (@songId, @tagId)";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@songId", songId);
            cmd.Parameters.AddWithValue("@tagId", tagId);
            cmd.ExecuteNonQuery();
        }

        //根据单个标签筛选歌曲
        public List<Song> GetSongsByTag(int tagId)
        {
            using var conn = new MySqlConnection(_connectionString);
            conn.Open();

            const string sql = @"SELECT s.* FROM Songs s
                        JOIN SongTags st ON s.Id = st.SongId
                        WHERE st.TagId = @tagId";

            return conn.Query<Song>(sql, new { tagId }).ToList();
        }

        //根据多个标签筛选歌曲（求交集）
        public List<Song> GetSongsByTags(IEnumerable<int> tagIds)
        {
            using var conn = new MySqlConnection(_connectionString);
            conn.Open();

            const string sql = @"SELECT s.* FROM Songs s
                        JOIN SongTags st ON s.Id = st.SongId
                        WHERE st.TagId IN @tagIds
                        GROUP BY s.Id
                        HAVING COUNT(DISTINCT st.TagId) = @tagCount";

            return conn.Query<Song>(sql, new
            {
                tagIds = tagIds.Distinct(),
                tagCount = tagIds.Count()
            }).ToList();
        }
        #endregion

        #region 歌单管理
        //创建新歌单
        public int CreatePlaylist(Songlist playlist)
        {
            using var conn = new MySqlConnection(_connectionString);
            conn.Open();

            const string sql = @"INSERT INTO Playlists 
                (Name, Owner) VALUES (@name, @owner);
                SELECT LAST_INSERT_ID();";

            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@name", playlist.Name);
            cmd.Parameters.AddWithValue("@owner", playlist.Owner);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        //歌单中添加歌曲
        public void AddSongsToPlaylist(int playlistId, IEnumerable<int> songIds)
        {
            using var conn = new MySqlConnection(_connectionString);
            conn.Open();

            const string sql = @"INSERT IGNORE INTO SonglistSongs 
                                (SonglistId, SongId) VALUES (@playlistId, @songId)";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.Add("@playlistId", MySqlDbType.Int32).Value = playlistId;
            cmd.Parameters.Add("@songId", MySqlDbType.Int32);

            foreach (var songId in songIds)
            {
                cmd.Parameters["@songId"].Value = songId;
                cmd.ExecuteNonQuery();
            }
        }

        //获取歌单中的所有歌曲
        public List<Song> GetSongsInPlaylist(int playlistId)
        {
            using var conn = new MySqlConnection(_connectionString);
            conn.Open();

            const string sql = @"SELECT s.* FROM Songs s
                               JOIN SonglistSongs ss ON s.Id = ss.SongId
                               WHERE ss.SonglistId = @playlistId";

            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@playlistId", playlistId);

            using var reader = cmd.ExecuteReader();
            var songs = new List<Song>();

            while (reader.Read())
            {
                songs.Add(new Song
                {
                    Id = reader.GetInt32("Id"),
                    Title = reader.GetString("Title"),
                    Artist = reader.GetString("Artist"),
                    MusicFilePath = reader.GetString("MusicFilePath"),
                    Duration = reader.GetInt32("Duration")
                });
            }
            return songs;
        }

        //从歌单中移除歌曲
        public bool RemoveSongFromPlaylist(int playlistId, int songId)
        {
            using var conn = new MySqlConnection(_connectionString);
            conn.Open();

            const string sql = @"DELETE FROM SonglistSongs 
                        WHERE SonglistId = @playlistId 
                        AND SongId = @songId";

            int affectedRows = conn.Execute(sql, new
            {
                playlistId,
                songId
            });

            return affectedRows > 0;
        }

        //获取所有歌单（异步操作）
        public async Task<List<Songlist>> GetAllPlaylistsAsync(string currentAccount)
        {
            using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync();

            // 步骤1：获取所有歌单基础信息
            const string baseSql = @"SELECT 
                  Id,
                  Name,
                  Owner
                  FROM Playlists
                  WHERE Owner = @currentAccount   
                     OR Owner = 'Admin'"; // 返回当前用户和Admin的歌单

            var playlists = (await conn.QueryAsync<Songlist>(baseSql, new { currentAccount })).ToList();

            // 步骤2：为每个歌单填充歌曲列表
            const string songsSql = @"SELECT s.* 
                            FROM Songs s
                            JOIN SonglistSongs ss ON s.Id = ss.SongId
                            WHERE ss.SonglistId = @playlistId";

            foreach (var playlist in playlists)
            {
                var songs = await conn.QueryAsync<Song>(songsSql, new { playlistId = playlist.Id });
                playlist.Songs = songs.ToList();
            }

            return playlists;
        }

        
        // 检查指定名称的歌单是否存在
        public bool CheckIfSonglistExists(string songlistName)
        {
            const string sql = @"
            SELECT COUNT(1)
            FROM Playlists
            WHERE Name = @Name;
        ";

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                // ExecuteScalar 返回第一行第一列的值；>0 则表示存在
                var count = conn.ExecuteScalar<int>(sql, new { Name = songlistName });
                return count > 0;
            }
        }

        // 根据歌单名和所有者获取歌单
        public async Task<Songlist> GetSonglistByNameAndOwner(string name, string currentAccount)
        {
            using var conn = new MySqlConnection(_connectionString);
            conn.Open();

            // 步骤1：获取歌单基本信息
            const string baseSql = @"SELECT 
                Id,
                Name,
                Owner
                FROM Playlists
                WHERE Name = @name 
                  AND (Owner = @currentAccount OR Owner = 'Admin')
                ORDER BY Owner = @currentAccount DESC 
                LIMIT 1";     // 优先返回用户自己的歌单

            var songlist = await conn.QueryFirstOrDefaultAsync<Songlist>(baseSql, new
            {
                name,
                currentAccount
            });


            if (songlist == null) return null;

            // 步骤2：获取关联的歌曲列表
            const string songsSql = @"SELECT s.* 
            FROM Songs s
            JOIN SonglistSongs ss ON s.Id = ss.SongId
            WHERE ss.SonglistId = @songlistId";

            songlist.Songs = conn.Query<Song>(songsSql, new { songlistId = songlist.Id }).ToList();

            return songlist;
        }

        // 获取用户的所有歌单
        public List<Songlist> GetUserOwnPlaylists(string account)
        {
            using var conn = new MySqlConnection(_connectionString);
            conn.Open();

            // 步骤1：获取歌单基础信息
            const string baseSql = @"SELECT 
            Id,
            Name,
            Owner
            FROM Playlists
            WHERE Owner = @account"; 

            var playlists = conn.Query<Songlist>(baseSql, new { account }).ToList();

            // 步骤2：为每个歌单填充歌曲列表
            const string songsSql = @"SELECT s.* 
            FROM Songs s
            JOIN SonglistSongs ss ON s.Id = ss.SongId
            WHERE ss.SonglistId = @songlistId";

            foreach (var playlist in playlists)
            {
                playlist.Songs = conn.Query<Song>(songsSql, new { songlistId = playlist.Id }).ToList();
            }

            return playlists;
        }

        //根据ID获取对应的歌单对象
        public Songlist GetSonglistById(int songlistId)
        {
            using var conn = new MySqlConnection(_connectionString);
            conn.Open();

            // 获取歌单基础信息
            const string baseSql = @"SELECT 
            Id,
            Name,
            Owner,
            FROM Playlists
            WHERE Id = @songlistId";

            var songlist = conn.QueryFirstOrDefault<Songlist>(baseSql, new { songlistId });

            if (songlist == null) return null;

            // 获取关联歌曲
            const string songsSql = @"SELECT s.* 
            FROM Songs s
            JOIN SonglistSongs ss ON s.Id = ss.SongId
            WHERE ss.SonglistId = @songlistId";

            songlist.Songs = conn.Query<Song>(songsSql, new { songlistId }).ToList();

            return songlist;
        }

        // 修改歌单名
        public bool UpdateSonglistName(int songlistId, string newName, string ownerAccount)
        {
            using var conn = new MySqlConnection(_connectionString);
            const string sql = @"UPDATE Playlists 
                           SET Name = @newName
                           WHERE Id = @songlistId 
                             AND Owner = @ownerAccount";

            return conn.Execute(sql, new
            {
                newName,
                songlistId,
                ownerAccount
            }) > 0;
        }

        // 删除歌单
        public bool DeleteSonglist(int songlistId, string ownerAccount)
        {
            using var conn = new MySqlConnection(_connectionString);
            conn.Open();

            using var transaction = conn.BeginTransaction();
            try
            {
                // 1. 删除关联歌曲记录
                const string deleteSongsSql = @"DELETE FROM SonglistSongs 
                                          WHERE SonglistId = @songlistId";
                conn.Execute(deleteSongsSql, new { songlistId }, transaction);

                // 2. 删除歌单本体
                const string deleteSonglistSql = @"DELETE FROM Playlists 
                                             WHERE Id = @songlistId 
                                               AND Owner = @ownerAccount";
                var affected = conn.Execute(deleteSonglistSql, new
                {
                    songlistId,
                    ownerAccount
                }, transaction);

                transaction.Commit();
                return affected > 0;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        #endregion
    }
}