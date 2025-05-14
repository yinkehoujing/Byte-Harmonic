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

                Console.WriteLine("���ݿ��ʼ���ɹ���");
            }
            catch (Exception ex)
            {
                Console.WriteLine("ִ�� SQL �ű�ʧ�ܣ�" + ex.Message);
            }




            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }

        // Windows API ���ã�����һ������̨����
        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        static extern bool AllocConsole();
    }
}
