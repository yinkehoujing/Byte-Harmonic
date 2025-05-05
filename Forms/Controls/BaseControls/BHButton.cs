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
using Byte_Harmonic.Forms.FormUtils;

namespace Byte_Harmonic.Forms.Controls.BaseControls
{
    public partial class BHButton : UserControl
    {
        private string _image = "icons8-加载圆";
        private string _nextImage = "icons8-加载圆";
        private string _realText = "     加载中";
        private ResourceManager resourceManager;

        public BHButton()
        {
            InitializeComponent();
            resourceManager = new ResourceManager("Byte_Harmonic.Properties.Resources", typeof(Resources).Assembly);//获取全局资源
            uiButton1.Text = _realText;
            pictureBox1.Image = ((Image)(resourceManager.GetObject(_image)));

        }

        public BHButton(string im, string nIm, string tx)
        {
            InitializeComponent();
            _image = im;
            _nextImage = nIm;
            _realText = "     " + tx;

            resourceManager = new ResourceManager("Byte_Harmonic.Properties.Resources", typeof(Resources).Assembly);//获取全局资源
            uiButton1.Text = _realText;
            pictureBox1.Image = ((Image)(resourceManager.GetObject(_image)));

        }

        private void BHButton_Enter(object sender, EventArgs e)
        {
            pictureBox1.Image = ((Image)(resourceManager.GetObject(_nextImage)));
            uiButton1.FillColor = MPColor.Grey2;
        }
        private void BHButton_Leave(object sender, EventArgs e)
        {
            pictureBox1.Image = ((Image)(resourceManager.GetObject(_image)));
            uiButton1.FillColor = MPColor.Grey1;
        }
        //example
        //private BHButton button1;
        //private void InitializeBHButton()
        //{
        //    button1 = new BHButton("icons8-倒带-96", "icons8-中等音量-96", "t");
        //    button1.Click += Back_Click_1;
        //    button1.Location = new Point(1, 1);
        //    this.Controls.Add(button1);
        //}
    }
}
