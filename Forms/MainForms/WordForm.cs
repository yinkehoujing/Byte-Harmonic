using Byte_Harmonic.Forms.FormUtils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Byte_Harmonic.Forms
{
    public partial class WordForm : Form
    {
        private readonly MouseMove _mouseHandler;//用于鼠标控制窗口
        private readonly FormStyle _styleHandler;//用于更改窗口样式
        public WordForm()
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);//双缓冲减少闪烁
            InitializeComponent();
            _mouseHandler = new MouseMove(this);
            _styleHandler = new FormStyle(this);
        }

        private void uiImageButton2_Click(object sender, EventArgs e)
        {
            this.TopMost = !this.TopMost;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void uiImageButton1_Click(object sender, EventArgs e)
        {
            this.WindowState= FormWindowState.Minimized;
        }
    }
}
