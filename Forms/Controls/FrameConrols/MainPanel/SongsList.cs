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
        private string _songlistName;

        public SongsList(string songlistName)
        {
            if (AppContext.currentViewingSonglist != null)
            {
                Console.WriteLine($"{AppContext.currentViewingSonglist.Name} and has {AppContext.currentViewingSonglist.Songs.Count} songs");
            }
            InitializeComponent();
            InitUI(songlistName);
            _songlistName = songlistName;

            AppContext.SonglistDetailUpdated += LoadSongsFromSonglistAsync;

            songlist = new SongList();
            //var songs = AppContext.currentViewingSonglist.Songs;
            // 直接从数据库查询对应名字的歌单，避免旧缓存
            try
            {
                LoadSongsFromSonglistAsync(AppContext.currentViewingSonglist.Name);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"加载歌曲出错：{ex.Message}");
            }
            //while (songlist == null) ; // 防止未加载好
            this.Controls.Add(songlist);
        }

        public async Task LoadSongsFromSonglistAsync(string songlistName)
        {
            if (songlistName != _songlistName) return; // 不是本歌单需要响应的
            var songlistResult = await AppContext.songlistService.GetSonglistByName(songlistName);
            if (songlistResult?.Songs != null)
            {
                songlist.LoadSongs(songlistResult.Songs);
            }

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
                    _songlistName = uiTextBox1.Text;
                    // TODO 修改歌单名
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
            // TODO : 歌单删除逻辑
            Console.WriteLine("歌单删除成功");
            new MainForms.MessageForm("删除歌单成功!").ShowDialog();

            AppContext.songlistRepository.DeleteSonglist(AppContext.currentViewingSonglist.Id, AppContext.currentUser.Account);

            AppContext.currentViewingSonglist = null;

            SongListDeleted?.Invoke(this, EventArgs.Empty);

            AppContext.TriggerReloadSideSonglist();
        }


    }
}
