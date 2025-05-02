using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byte_Harmonic.Utils
{
    public class DatabaseInitializer
    {
        private readonly string _connectionString;

        public DatabaseInitializer(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void ExecuteSqlFile(string filePath)
        {
            string sql = File.ReadAllText(FileHelper.GetSqlScriptPath(filePath));

            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                foreach (string commandText in SplitSqlStatements(sql))
                {
                    if (string.IsNullOrWhiteSpace(commandText))
                        continue;

                    using (var command = new MySqlCommand(commandText, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        private IEnumerable<string> SplitSqlStatements(string sql)
        {
            return sql.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                      .Select(s => s.Trim())
                      .Where(s => !string.IsNullOrWhiteSpace(s));
        }
    }
}
