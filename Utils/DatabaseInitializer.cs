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
        private readonly string _connectionString = "server=localhost;user=root;database=Byte_Harmonic;port=3306;password=";
        private static string connectionString = "";

        public DatabaseInitializer()
        {
            if (!File.Exists(FileHelper.GetProjectRootPath("passwd.txt")))
            {
                Console.WriteLine("未找到本地根目录下 passwd.txt, 使用默认的连接字符串");
                connectionString = _connectionString;
            }
            else
            {
                // 不要修改下面内容！！！
                connectionString = "server=localhost;user=root;database=Byte_Harmonic;port=3306;password=";
                var firstNonEmptyLine = File.ReadLines(FileHelper.GetProjectRootPath("passwd.txt"))
                                            .Select(line => line.Trim())
                                            .FirstOrDefault(line => !string.IsNullOrEmpty(line));

                connectionString += firstNonEmptyLine;
            }
        }

        public void ExecuteSqlFile(string filePath)
        {
            string sql = File.ReadAllText(FileHelper.GetSqlScriptPath(filePath));

            using (var connection = new MySqlConnection(connectionString))
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
