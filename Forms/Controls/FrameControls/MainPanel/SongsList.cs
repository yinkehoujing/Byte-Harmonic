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
            if(AppContext.currentViewingSonglist != null)
            {
                Console.WriteLine($"{AppContext.currentViewingSonglist.Name} and has {AppContext.currentViewingSonglist.Songs.Count} songs");
            }
            InitializeComponent();
            songlist = new SongList();
            songlist.LoadSongs();
            this.Controls.Add(songlist);
        }
    }
}
