using Byte_Harmonic.Forms.Controls.BaseControls;
using Byte_Harmonic.Models;
using Org.BouncyCastle.Utilities;
using TagLib.Matroska;

namespace Byte_Harmonic.Forms.Controls.FrameControls.MainPanel
{
    public partial class SearchResult: UserControl
    {
        private SongList songlist;
        private List<Song> songs;
        private List<Song> tempsongs;
        public SearchResult(List<Song> _songs)
        {
            InitializeComponent();
            uiCheckBox1.Tag = "动感";
            uiCheckBox2.Tag = "抒情"; 
            uiCheckBox3.Tag = "浪漫"; 
            uiCheckBox4.Tag = "电子"; 
            uiCheckBox5.Tag = "古风";
            uiCheckBox6.Tag = "摇滚";

            songs = _songs;
            
            var checkBoxes = checkPanel.Controls
                     .OfType<Sunny.UI.UICheckBox>()
                     .ToList();

            checkBoxes.ForEach(cb => cb.CheckedChanged += CheckBox_CheckedChanged);
           

            songlist = new SongList();
            songlist.LoadSongs(songs);
            this.Controls.Add(songlist);
        }

        private async void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            List<string> tags = new List<string> { };
            foreach (Sunny.UI.UICheckBox item in checkPanel.Controls)
            {
                tags.Add(item.Tag.ToString());
            }
            //TODO:更改使用新的后端函数
            
            tempsongs = await AppContext.searchService.SearchSongsByTagsAsync(songs,tags);
            foreach (var tagID in tags)
            {
                Console.WriteLine($"{tagID}");
            }
            foreach (var song in songs)
            {
                Console.WriteLine($"ID: {song.Id}, Title: {song.Title}, Artist: {song.Artist}, Duration: {song.Duration} seconds");
            }
            songlist.LoadSongs(tempsongs);
            this.Controls.Add(songlist);

        }
    }
}
