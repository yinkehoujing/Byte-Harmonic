using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ByteHarmonic.Models;

namespace Byte_Harmonic.Database
{
    public class SongRepository
    {
        private readonly string _connectionString;

        public SongRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        // 根据歌曲 ID 获取歌曲信息
        public Song GetSongById(string songId)
        {
            Song song = null;
            string query = "SELECT * FROM Songs WHERE Id = @songId";

            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@songId", songId);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                song = new Song
                                {
                                    Id = reader["Id"].ToString(),
                                    Title = reader["Title"].ToString(),
                                    Artist = reader["Artist"].ToString(),
                                    FilePath = reader["FilePath"].ToString(),
                                    Downloaded = Convert.ToBoolean(reader["Downloaded"]),
                                };
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }

            return song;
        }

        // 根据歌曲名称查询歌曲信息
        public List<Song> GetSongsByTitle(string title)
        {
            List<Song> songs = new List<Song>();
            string query = "SELECT * FROM Songs WHERE Title LIKE @title";

            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@title", "%" + title + "%");

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                songs.Add(new Song
                                {
                                    Id = reader["Id"].ToString(),
                                    Title = reader["Title"].ToString(),
                                    Artist = reader["Artist"].ToString(),
                                    FilePath = reader["FilePath"].ToString(),
                                    Downloaded = Convert.ToBoolean(reader["Downloaded"]),
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }

            return songs;
        }

        // 添加新歌曲
        public bool AddSong(Song song)
        {
            string query = "INSERT INTO Songs (Id, Title, Artist, FilePath, Downloaded, Duration) " +
                           "VALUES (@Id, @Title, @Artist, @FilePath, @Downloaded, @Duration)";

            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", song.Id);
                        cmd.Parameters.AddWithValue("@Title", song.Title);
                        cmd.Parameters.AddWithValue("@Artist", song.Artist);
                        cmd.Parameters.AddWithValue("@FilePath", song.FilePath);
                        cmd.Parameters.AddWithValue("@Downloaded", song.Downloaded);
                        cmd.Parameters.AddWithValue("@Duration", song.Duration);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    return false;
                }
            }
        }

        // 更新歌曲信息
        public bool UpdateSong(Song song)
        {
            string query = "UPDATE Songs SET Title = @Title, Artist = @Artist, FilePath = @FilePath, " +
                           "Downloaded = @Downloaded, Duration = @Duration WHERE Id = @Id";

            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", song.Id);
                        cmd.Parameters.AddWithValue("@Title", song.Title);
                        cmd.Parameters.AddWithValue("@Artist", song.Artist);
                        cmd.Parameters.AddWithValue("@FilePath", song.FilePath);
                        cmd.Parameters.AddWithValue("@Downloaded", song.Downloaded);
                        cmd.Parameters.AddWithValue("@Duration", song.Duration);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    return false;
                }
            }
        }

        // 删除歌曲
        public bool DeleteSong(string songId)
        {
            string query = "DELETE FROM Songs WHERE Id = @songId";

            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@songId", songId);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    return false;
                }
            }
        }
    }
}
