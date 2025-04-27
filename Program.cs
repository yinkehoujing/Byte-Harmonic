using MySql.Data.MySqlClient;

namespace Byte_Harmonic;

public class MainForm : Form
    {
        private Button connectButton;

        private MainForm()
        {
            connectButton = new Button
            {
                Text = "连接数据库",
                Dock = DockStyle.Fill
            };
            connectButton.Click += ConnectButton_Click;
            Controls.Add(connectButton);
        }

private void ConnectButton_Click(object sender, EventArgs e)
{
    string connectionString = "Server=localhost;Database=shoppingsystem;User ID=root;Password=gan2023302;";

    using (MySqlConnection connection = new MySqlConnection(connectionString))
    {
        try
        {
            connection.Open();
            MessageBox.Show("连接成功！");

            string sql = "SELECT * FROM category LIMIT 10;"; // 把 your_table_name 改成你的表名
            using (MySqlCommand command = new MySqlCommand(sql, connection))
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                string result = "";
                while (reader.Read())
                {
                    // 取出第一个字段
                    result += reader[0].ToString();

                    // 如果有第二个字段也可以取
                    if (reader.FieldCount > 1)
                        result += " - " + reader[1].ToString();

                    result += "\n";
                }

                MessageBox.Show(result == "" ? "没有查询到数据" : result);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"连接或查询失败: {ex.Message}");
        }
    }
}

        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
