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
    public partial class Favorite: UserControl
    {
        private SongList songlist;
        public Favorite()
        {
            if (AppContext.currentViewingSonglist != null)
            {
                Console.WriteLine($"{AppContext.currentViewingSonglist.Name} and has {AppContext.currentViewingSonglist.Songs.Count} songs");
            }
            InitializeComponent();
            songlist = new SongList();
            _ = InitializeAsync();
            this.Controls.Add(songlist);
        }

        private async Task InitializeAsync()
        {
            if (AppContext.currentViewingSonglist != null)
            {
                Console.WriteLine($"{AppContext.currentViewingSonglist.Name} and has {AppContext.currentViewingSonglist.Songs.Count} songs");
            }

            var songs = await AppContext.userRepository.GetFavoriteSongsAsync(AppContext.currentUser.Account);
            songlist.LoadSongs(songs);
        }
    }
}
