using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Byte_Harmonic.Forms.FormUtils;

namespace Byte_Harmonic.Forms.Controls.BaseControls
{
    public partial class VolumeControl : UserControl
    {
        public VolumeControl(Point ButtonLocation)
        {
            InitializeComponent();
            this.Location = new Point(ButtonLocation.X-10, ButtonLocation.Y-125);
        }

        private void uiLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
