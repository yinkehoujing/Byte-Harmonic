using System;
using System.Windows.Forms;
using Byte_Harmonic.Forms;
using ByteHarmonic.Forms;

namespace ByteHarmonic
{
    public class Program
    {
        [STAThread]
        public static void Main()
        {
            AllocConsole();
            Console.WriteLine("start debugging����");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new TestLyricsForm());
            Application.Run(new TestSongRepoForm());
        }

        // Windows API ���ã�����һ������̨����
        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        static extern bool AllocConsole();
    }
}
