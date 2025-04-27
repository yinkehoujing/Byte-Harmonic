using System;
using System.Windows.Forms;
using Byte_Harmonic.Forms;

namespace Byte_Harmonic
{
    public class Program
    {
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
