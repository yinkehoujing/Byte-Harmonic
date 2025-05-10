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
using Byte_Harmonic.Models;

namespace Byte_Harmonic.Forms.Controls.FrameControls.MainPanel
{
    public partial class PlayList : UserControl
    {
        private SongList songlist;
        public PlayList()
        {
            if (AppContext.currentViewingSonglist != null)
            {
                Console.WriteLine($"{AppContext.currentViewingSonglist.Name} and has {AppContext.currentViewingSonglist.Songs.Count} songs");
            }
            AppContext.PlaylistUpdated += AppContext_PlaylistUpdated;
            InitializeComponent();
            songlist = new SongList();
            var songs = AppContext._playbackService.GetPlaylist().PlaySongs;
            songlist.LoadSongs(songs);
            this.Controls.Add(songlist);
        }

        private void AppContext_PlaylistUpdated()
        {
            songlist.LoadSongs(AppContext._playbackService.GetPlaylist().PlaySongs);
            songlist.BulkOperateChange();
        }
    }
}
