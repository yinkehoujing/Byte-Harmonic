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
using Byte_Harmonic.Forms.FormUtils;

namespace Byte_Harmonic.Forms.Controls.BaseControls
{
    public partial class MusicExplorerControl : UserControl
    {
        public MusicExplorerControl()
        {
            var songlistRepo = new SonglistRepository();
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


            var panel1 = new Panel
            {
                Height = 40,
                Dock = DockStyle.Top
            };

            var label1 = new Label
            {
                Text = "歌曲探索",
                Dock = DockStyle.Left,
                Font = new System.Drawing.Font("Microsoft YaHei", 13F),
                AutoSize = true,
                Padding = new Padding(10, 10, 0, 0)
            };
            panel1.Controls.Add(label1);


            var panel2 = new Panel
            {
                Height = 40,
                Dock = DockStyle.Top
            };

            var label2 = new Label
            {
                Text = "歌单探索",
                Dock = DockStyle.Left,
                Font = new System.Drawing.Font("Microsoft YaHei", 13F),
                AutoSize = true,
                Padding = new Padding(10, 10, 0, 0)
            };
            panel2.Controls.Add(label2);

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
            card2.PlaylistClicked += LoadSonglistDetails;
            card3.PlaylistClicked += LoadSonglistDetails;
            card4.PlaylistClicked += LoadSonglistDetails;
            card5.PlaylistClicked += LoadSonglistDetails;



            if (playlistPanel != null)
            {
                playlistPanel.Controls.Add(card1);
                playlistPanel.Controls.Add(card2);
                playlistPanel.Controls.Add(card3);
                playlistPanel.Controls.Add(card4);
                playlistPanel.Controls.Add(card5);
            }

            // 歌曲流式面板
            // 主容器：横向排列两个列
            FlowLayoutPanel songPanel = new FlowLayoutPanel
            {
                Name = "songPanel",
                Dock = DockStyle.Fill,
                AutoScroll = true,
                WrapContents = false,
                Padding = new Padding(10),
                FlowDirection = FlowDirection.LeftToRight // 横向放两个列容器
            };

            // 每列：纵向排列 4 个歌曲项
            FlowLayoutPanel column1 = new FlowLayoutPanel
            {
                Width = 360, // 自定义列宽
                Height = 200, // 限制高度让每列只显示 4 项 (每项约高 45)
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                AutoScroll = false,
                ForeColor = Color.Yellow
            };

            FlowLayoutPanel column2 = new FlowLayoutPanel
            {
                Width = 360,
                Height = 200,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                AutoScroll = false,
                ForeColor = Color.Yellow
            };

            // 添加歌曲项（写死的8项）
            column1.Controls.Add(new SongItemControl(Color.White, 0, "晴天——周杰伦"));
            column1.Controls.Add(new SongItemControl(Color.White, 0, "七里香——周杰伦"));
            column1.Controls.Add(new SongItemControl(Color.White, 0, "稻香——周杰伦"));
            column1.Controls.Add(new SongItemControl(Color.White, 0, "简单爱——周杰伦"));

            column2.Controls.Add(new SongItemControl(Color.White, 0, "夜曲——周杰伦"));
            column2.Controls.Add(new SongItemControl(Color.White, 0, "搁浅——周杰伦"));
            column2.Controls.Add(new SongItemControl(Color.White, 0, "东风破——周杰伦"));
            column2.Controls.Add(new SongItemControl(Color.White, 0, "彩虹——周杰伦"));

            // 添加两个列到主容器
            songPanel.Controls.Add(column1);
            songPanel.Controls.Add(column2);




            // 添加控件
            this.Controls.Add(songPanel);
            this.Controls.Add(panel2);
            this.Controls.Add(playlistPanel);
            this.Controls.Add(panel1);
            this.Controls.Add(greetingPanel);
        }

        private async Task LoadSonglistDetails(string songlistName)
        {

            // 主动捕获异常
            try
            {
                //AppContext.currentViewingSonglist = await songlistservice.GetSonglistByName(songlistName);
                Console.WriteLine($"{AppContext.userService.GetCurrentUser()} 's things");
                if(AppContext.songlistService == null)
                {
                    Console.WriteLine("nanbeng");
                    throw new ArgumentNullException(nameof (AppContext.songlistService));
                }
                AppContext.currentViewingSonglist = await AppContext.songlistService.GetSonglistByName(songlistName);

                if(AppContext.currentViewingSonglist == null)
                {
                    throw new ArgumentNullException(nameof (AppContext.currentViewingSonglist));
                }

                Console.WriteLine("Songlist loaded successfully");

                AppContext.TriggerSonglistLoaded(); // 确认是否能执行到这里
            }
            catch (Exception ex)
            {
                Console.WriteLine($"LoadSonglistDetails 出错: {ex.Message}");
            }
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
