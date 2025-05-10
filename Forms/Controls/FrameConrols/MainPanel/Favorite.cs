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
    public partial class Favorite : UserControl
    {
        private SongList songlist;
        public Favorite()
        {
            if (AppContext.currentViewingSonglist != null)
            {
                Console.WriteLine($"{AppContext.currentViewingSonglist.Name} and has {AppContext.currentViewingSonglist.Songs.Count} songs");
            }
            InitializeComponent();
            AppContext.FavoriteUpdated += AppContext_FavoriteUpdated;
            songlist = new SongList();
            AppContext_FavoriteUpdated();
            this.Controls.Add(songlist);
        }

        private void AppContext_FavoriteUpdated()
        {
            if (AppContext.currentViewingSonglist != null)
            {
                Console.WriteLine($"{AppContext.currentViewingSonglist.Name} and has {AppContext.currentViewingSonglist.Songs.Count} songs");
            }

            var songs = AppContext.userRepository.GetFavoriteSongs(AppContext.currentUser.Account);
            songlist.LoadSongs(songs);
        }

        private async Task InitializeAsync()
        {
          
        }

        private void Favorite_Load(object sender, EventArgs e)
        {

        }
    }
}
