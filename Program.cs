using System;
using System.Windows.Forms;
using ByteHarmonic.Forms;

namespace ByteHarmonic
{
    public class Program
    {
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
            //Application.Run(new TestForm());
        }
    }
}
