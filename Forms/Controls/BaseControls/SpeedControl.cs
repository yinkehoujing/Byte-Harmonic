using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Byte_Harmonic.Forms.Controls.BaseControls
{
    public partial class SpeedControl : UserControl
    {
        public SpeedControl(Point ButtonLocation)
        {
            InitializeComponent();
            this.Location = new Point(ButtonLocation.X - 25, ButtonLocation.Y - 150);
        }
    }
}
