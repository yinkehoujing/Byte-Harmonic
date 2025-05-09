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
    public partial class SongsList : UserControl
    {
        private SongList songlist;
        public event EventHandler SongListDeleted;

        public SongsList(string songlistName)
        {
            if (AppContext.currentViewingSonglist != null)
            {
                Console.WriteLine($"{AppContext.currentViewingSonglist.Name} and has {AppContext.currentViewingSonglist.Songs.Count} songs");
            }
            InitializeComponent();
            InitUI(songlistName);
            songlist = new SongList();
            var songs = AppContext.currentViewingSonglist.Songs;
            songlist.LoadSongs(songs);
            this.Controls.Add(songlist);
        }

        private void InitUI(string songlistName)
        {
            uiTextBox1.Text = songlistName;

            // 按回车键退出编辑
            uiTextBox1.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    Console.WriteLine($"修改后内容: {uiTextBox1.Text}");
                    new MainForms.MessageForm("修改歌单名成功!").ShowDialog();
                    // 修改歌单名
                    AppContext.songlistRepository.UpdateSonglistName(AppContext.currentViewingSonglist.Id, uiTextBox1.Text, AppContext.currentUser.Account);
                    AppContext.TriggerReloadSideSonglist();

                }
            };

            //// 失去焦点也退出编辑
            //uiTextBox1.Leave += (s, e) =>
            //{
            //    Console.WriteLine($"修改后内容: {uiTextBox1.Text}");
            //    new MainForms.MessageForm("修改歌单名成功!").ShowDialog();
            //    // TODO 修改歌单名
            //    AppContext.songlistRepository.UpdateSonglistName(AppContext.currentViewingSonglist.Id, uiTextBox1.Text, AppContext.currentUser.Account);
            //    AppContext.TriggerReloadSideSonglist();

            //};
        }

        private void uiImageButton1_Click(object sender, EventArgs e)
        {
            // 歌单删除逻辑
            
            AppContext.songlistRepository.DeleteSonglist(AppContext.currentViewingSonglist.Id, AppContext.currentUser.Account);

            AppContext.currentViewingSonglist = null;

            SongListDeleted?.Invoke(this, EventArgs.Empty);

            Console.WriteLine("歌单删除成功");
            new MainForms.MessageForm("删除歌单成功!").ShowDialog();

            AppContext.TriggerReloadSideSonglist();
        }


    }
}
