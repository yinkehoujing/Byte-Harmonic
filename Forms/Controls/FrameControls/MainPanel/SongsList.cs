using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Byte_Harmonic.Forms.Controls.BaseControls;

namespace Byte_Harmonic.Forms.Controls.FrameControls.MainPanel
{
    public partial class SongsList: UserControl
    {
        private SongList songlist;

        public SongsList()
        {
            InitializeComponent();
            songlist = new SongList();
            this.Controls.Add(songlist);
        }
    }
}
