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
    public partial class Download: UserControl
    {
        private SongList songlist;
        public Download()
        {
            if (AppContext.currentViewingSonglist != null)
            {
                Console.WriteLine($"{AppContext.currentViewingSonglist.Name} and has {AppContext.currentViewingSonglist.Songs.Count} songs");
            }
            AppContext.DownloadUpdated += AppContext_DownloadUpdated;
            InitializeComponent();
            songlist = new SongList();
            var songs = AppContext._songRepository.GetDownloadedSongs();
            songlist.LoadSongs(songs);
            this.Controls.Add(songlist);
        }

        private void AppContext_DownloadUpdated()
        {
            var songs = AppContext._songRepository.GetDownloadedSongs();
            songlist.LoadSongs(songs);
        }
    }
}
