using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Byte_Harmonic.Services;
using Byte_Harmonic.Database;
using NAudio.CoreAudioApi;

namespace Byte_Harmonic.Forms.Controls.BaseControls
{
    public partial class MusicExplorerControl : UserControl
    {
        SonglistService songlistservice;
        public MusicExplorerControl()
        {
            var songlistRepo = new SonglistRepository();
            var userRepo = new UserRepository();
            var userService = new UserService(userRepo);
            songlistservice = new SonglistService(songlistRepo, userService);
            InitializeComponent();
            SetupLayout();
        }

        private void SetupLayout()
        {
            this.Dock = DockStyle.Fill;
            this.AutoScroll = true;
            var greetingPanel = new Panel
            {
                Height = 40,
                Dock = DockStyle.Top
            };

            var label = new Label
            {
                Text = "清晨好",
                Dock = DockStyle.Left,
                Font = new System.Drawing.Font("Microsoft YaHei", 18F),
                AutoSize = true,
                Padding = new Padding(10, 10, 0, 0)
            };
            greetingPanel.Controls.Add(label);
            // 歌单探索标题栏
            Panel topHeader = CreateHeader("歌单探索", TopRefresh_Click);
            topHeader.Dock = DockStyle.Top;

            // 歌单流式面板
            FlowLayoutPanel playlistPanel = new FlowLayoutPanel
            {
                Name = "playlistPanel",
                Dock = DockStyle.Top,
                Height = 180,
                AutoScroll = true,
                WrapContents = true,
                Padding = new Padding(10),
                FlowDirection = FlowDirection.LeftToRight
            };

            var card1 = new PlaylistCardControl { PlaylistName = "流行精选" , CoverImageText = "1 (1)" };
            var card2 = new PlaylistCardControl { PlaylistName = "华语金曲", CoverImageText = "1 (1)" };
            var card3 = new PlaylistCardControl { PlaylistName = "摇滚年代" , CoverImageText = "1 (1)" };
            var card4 = new PlaylistCardControl { PlaylistName = "古风系列" , CoverImageText = "1 (1)" };
            var card5 = new PlaylistCardControl { PlaylistName = "本周最热" , CoverImageText = "1 (1)" };

            card1.PlaylistClicked += LoadSonglistDetails;



            if (playlistPanel != null)
            {
                playlistPanel.Controls.Add(card1);
                playlistPanel.Controls.Add(card2);
                playlistPanel.Controls.Add(card3);
                playlistPanel.Controls.Add(card4);
                playlistPanel.Controls.Add(card5);
            }

            // 歌曲探索标题栏
            Panel bottomHeader = CreateHeader("歌曲探索", BottomRefresh_Click);
            bottomHeader.Dock = DockStyle.Top;

            // 歌曲流式面板
            FlowLayoutPanel songPanel = new FlowLayoutPanel
            {
                Name = "songPanel",
                Dock = DockStyle.Fill,
                AutoScroll = true,
                WrapContents = false,
                Padding = new Padding(10),
                FlowDirection = FlowDirection.TopDown
            };

            var songItem = new SongItemControl();
            songItem.SongTitle = "晴天";
            songItem.Artist = "周杰伦";
            songItem.PlayClicked += (s, e) => MessageBox.Show("播放");
            songItem.FavoriteClicked += (s, e) => MessageBox.Show("收藏");
            songItem.DownloadClicked += (s, e) => MessageBox.Show("下载");

            songPanel.BackColor = Color.LightBlue;
            songItem.BackColor = Color.LightYellow;

            songPanel.Controls.Add(songItem);


            // 添加控件
            this.Controls.Add(bottomHeader);
            this.Controls.Add(songPanel);
            this.Controls.Add(playlistPanel);
            this.Controls.Add(topHeader);
            this.Controls.Add(greetingPanel);
        }

        private async Task LoadSonglistDetails(string songlistName)
        {
            AppContext.currentViewingSonglist = await songlistservice.GetSonglistByName(songlistName);

            AppContext.TriggerSonglistLoaded(); // 仍然可以是同步的
        }

        private void GreetingClick(object? sender, EventArgs e)
        {
            Console.WriteLine("hello~");
            throw new NotImplementedException();
        }

        private Panel CreateHeader(string title, EventHandler refreshClick)
        {
            var panel = new Panel
            {
                Height = 40,
                Dock = DockStyle.Top
            };

            var label = new Label
            {
                Text = title,
                Dock = DockStyle.Left,
                Font = new System.Drawing.Font("Microsoft YaHei", 12F),
                AutoSize = true,
                Padding = new Padding(10, 10, 0, 0)
            };

            var refreshIcon = new PictureBox
            {
                Dock = DockStyle.Right,
                Width = 32,
                Height = 32,
                //Image = Properties.Resources.refresh_icon, // 添加刷新图标
                SizeMode = PictureBoxSizeMode.Zoom,
                Cursor = Cursors.Hand
            };

            refreshIcon.Click += refreshClick;

            panel.Controls.Add(label);
            panel.Controls.Add(refreshIcon);

            return panel;
        }

        private void TopRefresh_Click(object sender, EventArgs e)
        {
            // TODO: 重新加载歌单
            MessageBox.Show("刷新歌单探索");
        }

        private void BottomRefresh_Click(object sender, EventArgs e)
        {
            // TODO: 重新加载歌曲
            MessageBox.Show("刷新歌曲探索");
        }
    }
}
