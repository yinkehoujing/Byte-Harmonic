using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ByteHarmonic.Models;

namespace ByteHarmonic.Database
{
    public class SongRepository
    {
        private readonly string _connectionString = "server=localhost;user=root;database=Byte_Harmonic;port=3306;password=your password";

        public bool AddSong(Song song)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string sql = "INSERT INTO Songs (Id, Title, Artist, FilePath, Downloaded, Duration) VALUES (@Id, @Title, @Artist, @FilePath, @Downloaded, @Duration)";
            using var cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@Id", song.Id);
            cmd.Parameters.AddWithValue("@Title", song.Title);
            cmd.Parameters.AddWithValue("@Artist", song.Artist);
            cmd.Parameters.AddWithValue("@FilePath", song.FilePath);
            cmd.Parameters.AddWithValue("@Downloaded", song.Downloaded);
            cmd.Parameters.AddWithValue("@Duration", song.Duration);

            return cmd.ExecuteNonQuery() > 0;
        }

        public Song GetSongById(string id)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string sql = "SELECT * FROM Songs WHERE Id = @Id";
            using var cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@Id", id);

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new Song
                {
                    Id = reader.GetString("Id"),
                    Title = reader.GetString("Title"),
                    Artist = reader.GetString("Artist"),
                    FilePath = reader.GetString("FilePath"),
                    Downloaded = reader.GetBoolean("Downloaded"),
                    Duration = reader.GetInt32("Duration")
                };
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
                return new Song
                {
                    Id = reader.GetString("Id"),
                    Title = reader.GetString("Title"),
                    Artist = reader.GetString("Artist"),
                    FilePath = reader.GetString("FilePath"),
                    Downloaded = reader.GetBoolean("Downloaded"),
                    Duration = reader.GetInt32("Duration")
                };
            }

            return null;
        }

        public bool UpdateSong(Song song)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string sql = "UPDATE Songs SET Title=@Title, Artist=@Artist, FilePath=@FilePath, Downloaded=@Downloaded, Duration=@Duration WHERE Id=@Id";
            using var cmd = new MySqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@Title", song.Title);
            cmd.Parameters.AddWithValue("@Artist", song.Artist);
            cmd.Parameters.AddWithValue("@FilePath", song.FilePath);
            cmd.Parameters.AddWithValue("@Downloaded", song.Downloaded);
            cmd.Parameters.AddWithValue("@Duration", song.Duration);
            cmd.Parameters.AddWithValue("@Id", song.Id);

            return cmd.ExecuteNonQuery() > 0;
        }

        public bool DeleteSong(string id)
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
