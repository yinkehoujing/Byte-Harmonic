using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Byte_Harmonic.Properties;
using System.Resources;

namespace Byte_Harmonic.Forms.Controls.BaseControls
{
    public partial class BHButton : UserControl
    {
        private string _image;
        private string _text;
        private string _realText;
        private ResourceManager resourceManager;

        public BHButton()
        {
            _realText = "         " + _text;
            InitializeComponent();

            resourceManager = new ResourceManager("Byte_Harmonic.Properties.Resources", typeof(Resources).Assembly);//获取全局资源
            uiButton1.Text = _realText;
            pictureBox1.Image = ((Image)(resourceManager.GetObject(_image)));
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
