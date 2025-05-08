using Byte_Harmonic.Forms.Controls.BaseControls;
using Byte_Harmonic.Models;

namespace Byte_Harmonic.Forms.Controls.FrameControls.MainPanel
{
    public partial class SearchResult: UserControl
    {
        private SongList songlist;
        public SearchResult(List<Song> songs)
        {
            InitializeComponent();
            songlist.LoadSongs(songs);
            this.Controls.Add(songlist);
        }
    }
}
