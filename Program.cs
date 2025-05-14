using System;
using System.Windows.Forms;
using Byte_Harmonic.Forms;
using Byte_Harmonic.Forms.MainForms;
using Byte_Harmonic.Utils;

namespace Byte_Harmonic
{
    public class Program
    {
        [STAThread]
        public static void Main()
        {
#if DEBUG
            AllocConsole();
#endif 

            var initializer = new DatabaseInitializer();

            try
            {
                initializer.ExecuteSqlFile("Init.sql");
                initializer.ExecuteSqlFile("InitData.sql");

                Console.WriteLine("数据库初始化成功！");
            }
            catch (Exception ex)
            {
                Console.WriteLine("执行 SQL 脚本失败：" + ex.Message);
            }




            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }

        // Windows API 调用：分配一个控制台窗口
        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        static extern bool AllocConsole();
    }
}
