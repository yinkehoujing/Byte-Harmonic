using MySql.Data.MySqlClient;
using System;
using Byte_Harmonic.Models;

namespace Byte_Harmonic.Database
{
    public class SongRepository
    {
        private readonly string _connectionString = "server=localhost;user=root;database=Byte_Harmonic;port=3306;password=gan2023302";

        public bool AddSong(Song song)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string sql = "INSERT INTO Songs (Title, Artist, MusicFilePath, LrcFilePath, Downloaded, Duration) " +
                         "VALUES (@Title, @Artist, @MusicFilePath, @LrcFilePath, @Downloaded, @Duration); SELECT LAST_INSERT_ID();";

            using var cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@Title", song.Title);
            cmd.Parameters.AddWithValue("@Artist", song.Artist);
            cmd.Parameters.AddWithValue("@MusicFilePath", song.MusicFilePath ?? string.Empty);
            cmd.Parameters.AddWithValue("@LrcFilePath", song.LrcFilePath ?? string.Empty);
            cmd.Parameters.AddWithValue("@Downloaded", song.Downloaded ? 1 : 0);
            cmd.Parameters.AddWithValue("@Duration", song.Duration);

            object result = cmd.ExecuteScalar();
            if (result != null && int.TryParse(result.ToString(), out int newId))
            {
                song.Id = newId;  // 把自增 Id 写回到对象里
                return true;
            }

            return false;
        }

        public Song GetSongById(int id)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string sql = "SELECT * FROM Songs WHERE Id = @Id";
            using var cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@Id", id);

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new Song(
                    id: reader.GetInt32("Id"),
                    title: reader.GetString("Title"),
                    artist: reader.GetString("Artist"),
                    downloaded: reader.GetBoolean("Downloaded"),
                    musicFilePath: reader.GetString("MusicFilePath"),
                    lrcFilePath: reader.IsDBNull(reader.GetOrdinal("LrcFilePath")) ? string.Empty : reader.GetString("LrcFilePath"),
                    duration: reader.GetInt32("Duration"),
                    tags: new List<string>() // TODO: 从 tag 表中获取
                );
            }

            return null;
        }

        public Song GetSongByTitle(string title)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string sql = "SELECT * FROM Songs WHERE Title = @Title";
            using var cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@Title", title);

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new Song(
                    id: reader.GetInt32("Id"),
                    title: reader.GetString("Title"),
                    artist: reader.GetString("Artist"),
                    downloaded: reader.GetBoolean("Downloaded"),
                    musicFilePath: reader.GetString("MusicFilePath"),
                    lrcFilePath: reader.IsDBNull(reader.GetOrdinal("LrcFilePath")) ? string.Empty : reader.GetString("LrcFilePath"),
                    duration: reader.GetInt32("Duration"),
                    tags: new List<string>() // 同上
                );
            }

            return null;
        }


        public List<Song> GetAllSongs(int maximum)
        {
            var songs = new List<Song>();

            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string sql = "SELECT * FROM Songs LIMIT @Max";
            using var cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@Max", maximum);

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var song = new Song(
                    id: reader.GetInt32("Id"),
                    title: reader.GetString("Title"),
                    artist: reader.GetString("Artist"),
                    downloaded: reader.GetBoolean("Downloaded"),
                    musicFilePath: reader.GetString("MusicFilePath"),
                    lrcFilePath: reader.IsDBNull(reader.GetOrdinal("LrcFilePath")) ? string.Empty : reader.GetString("LrcFilePath"),
                    duration: reader.GetInt32("Duration"),
                    tags: new List<string>() // 因数据库未存储 Tags 字段
                );

                songs.Add(song);
            }

            return songs;
        }


        public bool UpdateSong(Song song)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string sql = "UPDATE Songs SET Title = @Title, Artist = @Artist, MusicFilePath = @MusicFilePath, " +
                         "LrcFilePath = @LrcFilePath, Downloaded = @Downloaded, Duration = @Duration WHERE Id = @Id";

            using var cmd = new MySqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@Title", song.Title);
            cmd.Parameters.AddWithValue("@Artist", song.Artist);
            cmd.Parameters.AddWithValue("@MusicFilePath", song.MusicFilePath ?? string.Empty);
            cmd.Parameters.AddWithValue("@LrcFilePath", song.LrcFilePath ?? string.Empty);
            cmd.Parameters.AddWithValue("@Downloaded", song.Downloaded ? 1 : 0);
            cmd.Parameters.AddWithValue("@Duration", song.Duration);
            cmd.Parameters.AddWithValue("@Id", song.Id);

            return cmd.ExecuteNonQuery() > 0;
        }

        public bool DeleteSong(int id)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string sql = "DELETE FROM Songs WHERE Id = @Id";
            using var cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@Id", id);

            return cmd.ExecuteNonQuery() > 0;
        }
    }
}
