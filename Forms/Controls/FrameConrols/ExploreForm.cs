﻿using Byte_Harmonic.Database;
using Byte_Harmonic.Forms.Controls.BaseControls;
using Byte_Harmonic.Forms.FormUtils;
using Byte_Harmonic.Forms.MainForms;
using Byte_Harmonic.Models;
using Byte_Harmonic.Properties;
using Byte_Harmonic.Services;
using Google.Protobuf.WellKnownTypes;
using NAudio.Gui;
using Org.BouncyCastle.Utilities;
using Services;
using Sunny.UI;
using System.Resources;
using System.Windows.Forms;
using Byte_Harmonic.Forms.Controls.BaseControls;
using Byte_Harmonic.Forms.Controls.FrameControls;
using Byte_Harmonic.Forms.Controls.FrameControls.MainPanel;
using Org.BouncyCastle.Utilities.Collections;
using static Sunny.UI.SnowFlakeId;

namespace Byte_Harmonic.Forms
{
    public partial class ExploreForm : UserControl
    {
        private ResourceManager resourceManager;
        private StarControl starControl;
        private SearchService _searchService;
        private FavoritesService _favoritesService;
        public ExploreForm()
        {
            InitializeComponent();
            InitializeMenu();//初始化菜单三个按钮
            InitializeSongsList();//初始化侧边歌单
            InitializeSearchBox();//初始化搜索框
            resourceManager = new ResourceManager("Byte_Harmonic.Properties.Resources", typeof(Resources).Assembly);//获取全局资源
            //初始化收藏service                                                                                                    //初始化
            _favoritesService = new FavoritesService(AppContext.userRepository);
            //初始化用户和歌曲
            var song = AppContext._playbackService.GetCurrentSong();
            starControl = new StarControl(uiImageButton8);
            bool isFavorite = _favoritesService.IsSongFavorite(AppContext.currentUser.Account, 1);
            starControl.InitStarButton(isFavorite);//初始化收藏按钮
            uiImageButton8.Click += starControl.StarButtonClick;

            LoadMusicExplorerControl(); // 装入初始探索页面
            uiLabel3.EnableAutoScroll();//支持文字过长时滚动
            uiLabel4.EnableAutoScroll();

            // 使用 AppContext 注册事件
            AppContext.LyricsUpdated += OnLyricsUpdated;
            AppContext.updateSongUI += OnUpdateSongUI;
            AppContext.ShowPlayingBtn += OnShowPlayingBtn;
            AppContext.SonglistLoaded += LoadSonglistToPanel;
            AppContext.ReloadSideSonglist += InitializeSongsList;
            AppContext.StarUpdated += OnStarUpdated;
            AppContext.ChangeSearchBox += OnChangeSearchBox;
            //初始化searchservice
            _searchService = new SearchService(AppContext.songlistRepository, AppContext.userRepository, AppContext.userService);

            AppContext.PlaybackModeChanged += OnPlaybackModeChanged;
            var songlist = AppContext._songRepository.GetAllSongs(6); // 只准备 6 首歌在播放队列

            if (songlist.Count <= 0)
            {
                throw new ArgumentException("songlist 为空!!!");
            }

            ;
            if (song == null)
            {
                AppContext.TriggerPlaylistSetRequested(songlist);

                // UI 初始化
                uiLabel3.Text = songlist[0].Title;
                uiLabel4.Text = songlist[0].Artist;
                TimeSpan ts = TimeSpan.FromSeconds(songlist[0].Duration);
                uiLabel1.Text = ts.ToString(@"mm\:ss");
                uiTrackBar1.Maximum = songlist[0].Duration;
                uiTrackBar1.Value = 0;

            }
            else
            {
                Console.WriteLine("恢复之前的页面显示——ExploreForm");
                var text = AppContext._playbackService.GetCurrentLyricsLine()?.Text ?? "（无歌词）";
                var position = AppContext._playbackService.GetCurrentPosition();
                AppContext.TriggerupdateSongUI(song);
                AppContext.TriggerLyricsUpdated(text, position);
                AppContext.TriggerShowPlayingBtn(!AppContext._playbackService.IsPaused);
                AppContext.TriggerPlaybackModeChanged(AppContext._playbackService.PlaybackMode);
            }


            uiTrackBar1.MouseDown += (s, e2) => { _isDragging = true; };
            uiTrackBar1.MouseUp += (s, e2) =>
            {
                _isDragging = false;
                TimeSpan seekPosition = TimeSpan.FromSeconds(uiTrackBar1.Value);
                AppContext._playbackService.SeekTo(seekPosition);

                AppContext.TriggerPositionChanged(seekPosition);
                Console.WriteLine($"Explore Form——用户拖动到：{seekPosition}");
                uiLabel2.Text = seekPosition.ToString(@"mm\:ss");
            };
        }

        private void OnStarUpdated()
        {
            //HighlightCurrentLine(position); // 高亮当前行
            Console.WriteLine("触发 OnStarUpdated 事件");
            bool isFavorite = _favoritesService.IsSongFavorite(AppContext.currentUser.Account, AppContext._playbackService.GetCurrentSong().Id);
            starControl.InitStarButton(isFavorite);
        }

        private void OnPlaybackModeChanged(PlaybackMode mode)
        {
            // 更新 uiImageButton9 的图标
            /*
                bHButton1 = new BHButton("icons8-定期约会-96", "icons8-定期约会-96 (1)", "顺序播放");
                bHButton2 = new BHButton("icons8-定期约会-96 (2)", "icons8-定期约会-96 (3)", "单曲循环");
                bHButton3 = new BHButton("icons8-repeat-96", "icons8-repeat-96 (1)", "列表循环");
                bHButton4 = new BHButton("icons8-随机-96 (1)", "icons8-随机-96", "随机播放");
            */
            if (mode == PlaybackMode.Sequential)
            {
                uiImageButton9.Image = ((Image)(resourceManager.GetObject("icons8-定期约会-96")));
                uiImageButton9.ImageHover = ((Image)(resourceManager.GetObject("icons8-定期约会-96 (1)")));
            }
            else if (mode == PlaybackMode.RepeatOne)
            {
                uiImageButton9.Image = ((Image)(resourceManager.GetObject("icons8-定期约会-96 (2)")));
                uiImageButton9.ImageHover = ((Image)(resourceManager.GetObject("icons8-定期约会-96 (3)")));
            }
            else if (mode == PlaybackMode.Shuffle)
            {
                uiImageButton9.Image = ((Image)(resourceManager.GetObject("icons8-随机-96 (1)")));
                uiImageButton9.ImageHover = ((Image)(resourceManager.GetObject("icons8-随机-96")));
            }
            else if (mode == PlaybackMode.ListLooping)
            {
                uiImageButton9.Image = ((Image)(resourceManager.GetObject("icons8-repeat-96")));
                uiImageButton9.ImageHover = ((Image)(resourceManager.GetObject("icons8-repeat-96 (1)")));
            }

        }

        private void LoadSonglistToPanel()
        {
            Console.WriteLine("load a new panel");
            var songsListControl = new SongsList(AppContext.currentViewingSonglist.Name);
            songsListControl.SongListDeleted += SongsListControl_SongListDeleted;
            LoadPage(songsListControl);
        }
        public void LoadPage(UserControl page)
        {
            panel2.Controls.Clear();    // 清空之前的页面
            page.Dock = DockStyle.Fill;        // 填满容器
            panel2.Controls.Add(page);   // 添加新页面
            Console.WriteLine("load a page");
        }
        private void OnShowPlayingBtn(bool isPaused)
        {
            if (isPaused)
            {
                uiImageButton5.Image = ((Image)(resourceManager.GetObject("icons8-pause-96")));
                uiImageButton5.ImageHover = ((Image)(resourceManager.GetObject("icons8-pause-96 (1)")));
            }
            else
            {
                // 暂停了显示下面图标
                uiImageButton5.Image = ((Image)(resourceManager.GetObject("icons8-play-96")));
                uiImageButton5.ImageHover = ((Image)(resourceManager.GetObject("icons8-play-96 (1)")));

            }
        }

        private void OnUpdateSongUI(Song song)
        {
            if (IsDisposed) return;

            RunOnUiThread(() =>
            {
                uiLabel3.Text = song.Title;
                uiLabel4.Text = song.Artist;
                uiTrackBar1.Maximum = song.Duration;
                uiTrackBar1.Value = 0;
                TimeSpan ts = TimeSpan.FromSeconds(song.Duration);

                // 格式化为 mm:ss 并显示到 UI
                uiLabel1.Text = ts.ToString(@"mm\:ss");
                uiLabel2.Text = TimeSpan.Zero.ToString(@"mm\:ss"); // 输出：00:00
                //HighlightCurrentLine(position); // 高亮当前行
                bool isFavorite = _favoritesService.IsSongFavorite(AppContext.currentUser.Account, AppContext._playbackService.GetCurrentSong().Id);
                starControl.InitStarButton(isFavorite);
            });
        }

        private void OnLyricsUpdated(string lyrics, TimeSpan position)
        {
            if (IsDisposed) return;

            RunOnUiThread(() =>
            {
                uiLabel2.Text = position.ToString(@"mm\:ss");
                uiTrackBar1.Value = Math.Min((int)position.TotalSeconds, uiTrackBar1.Maximum);
                //HighlightCurrentLine(position); // 高亮当前行
            });
        }

        private void SongsListControl_SongListDeleted(object sender, EventArgs e)
        {

            Console.WriteLine("SongsListControl_SongListDeleted");
            // 移除当前的 SongsList 控件
            if (sender is SongsList songsList)
            {
                panel2.Controls.Remove(songsList);
                songsList.Dispose();
            }

            var explorerControl = new MusicExplorerControl();
            panel2.Controls.Add(explorerControl);
        }
        private void RunOnUiThread(Action action)
        {
            if (InvokeRequired)
                Invoke(action);
            else
                action();
        }

        private readonly FormStyle _styleHandler;//用于更改窗口样式
        private int cornerRadius = 18;//通用设置圆角
        private Form secondForm;//用于歌词页

        #region 暂时封装
        private void MainForm_Load(object sender, EventArgs e)//窗口加载
        {
            _styleHandler.SetPictureBoxRoundCorners(pictureBox2, cornerRadius);//绘制圆角
        }

        private void uiImageButton5_Click(object sender, EventArgs e)
        {

        }

        private void PictureBox2_SizeChanged(object? sender, EventArgs e)
        {
            _styleHandler.SetPictureBoxRoundCorners(pictureBox2, cornerRadius);
        }

        private void uiImageButton1_Click_1(object sender, EventArgs e)
        {
            // 获取主窗体引用
            Byte_Harmonic.Forms.MainForms.MainForm main = this.FindForm() as MainForm;
            if (main != null)
            {
                main.Close();
            }
        }

        private void MinButton_Click(object sender, EventArgs e)
        {
            // 获取主窗体引用
            Byte_Harmonic.Forms.MainForms.MainForm main = this.FindForm() as MainForm;
            if (main != null)
            {
                main.WindowState = FormWindowState.Minimized;
            }
        }

        private void Back_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Left > 180)
            {
                int panelRight = pictureBox2.Right;
                int panelWidth = pictureBox2.Width;
                pictureBox2.Left = 100;
                pictureBox2.Width = panelRight - pictureBox2.Left;

            }
            else
            {
                int panelRight = pictureBox2.Right;
                int panelWidth = pictureBox2.Width;
                pictureBox2.Left = 200;
                pictureBox2.Width = panelRight - pictureBox2.Left;
            }
        }

        private void uiImageButton1_Click(object sender, EventArgs e)
        {

        }

        private void btnGoToSettings_Click(object sender, EventArgs e)
        {
            // 获取主窗体引用
            MainForm main = this.FindForm() as MainForm;
            if (main != null)
            {
                main.LoadPage(new MusicForm());
            }
        }

        private void uiImageButton2_Click_1(object sender, EventArgs e)
        {
            // 获取主窗体引用
            MainForm main = this.FindForm() as MainForm;
            if (main != null)
            {
                main.LoadPage(new MusicForm());
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void uiImageButton14_Click(object sender, EventArgs e)
        {
            // 获取主窗体引用
            MainForm main = this.FindForm() as MainForm;
            if (main != null)
            {
                main.LoadPage(new MusicForm());

            }
        }

        private void uiImageButton1_Click_2(object sender, EventArgs e)
        {
            MainForm main = this.FindForm() as MainForm;
            if (main != null)
            {
                main.Close();
            }
        }

        private void uiImageButton3_Click(object sender, EventArgs e)
        {
            MainForm main = this.FindForm() as MainForm;
            if (main != null)
            {
                main.WindowState = FormWindowState.Minimized;
            }
        }

        private void uiImageButton12_Click(object sender, EventArgs e)
        {
            if (secondForm != null && !secondForm.IsDisposed)
            {
                secondForm.Close();
                secondForm = null;
            }
            else
            {
                secondForm = new WordForm();
                secondForm.Show();
            }
        }


        //
        //折叠菜单栏
        //
        private bool isFirstForm = true; // 跟踪当前窗体形态
        private void Back_Click_1(object sender, EventArgs e)
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExploreForm));//获取该控件资源


            if (isFirstForm)
            {
                // 切换到第二个窗体形态
                //调整搜索框
                searchBox.Location = new Point(399, 28);

                //调整搜索旁按钮
                closeSearchButton.Location = new Point(674, 31);

                // 调整pictureBox2
                pictureBox2.Location = new Point(72, 9);
                pictureBox2.Size = new Size(978, 580);

                // 调整panel2
                panel2.Location = new Point(95, 64);
                panel2.Size = new Size(940, 512);

                //调整uiFlowLayoutPanel1
                flowLayoutPanel1.SendToBack();
                flowLayoutPanel1.Width = 70;

                // 调整pictureBox1
                pictureBox1.Location = new Point(72, 592);
                pictureBox1.Size = new Size(978, 100);

                // 调整按钮位置
                uiImageButton1.Location = new Point(1005, 28);
                uiImageButton3.Location = new Point(958, 28);

                // 调整标签位置
                uiLabel1.Location = new Point(800, 659);
                uiLabel2.Location = new Point(290, 659);
                uiLabel3.Location = new Point(97, 612);
                uiLabel4.Location = new Point(97, 652);

                // 调整进度条
                uiTrackBar1.Location = new Point(348, 659);
                uiTrackBar1.Size = new Size(448, 15);

                // 调整底部按钮
                uiImageButton5.Location = new Point(552, 606);
                uiImageButton6.Location = new Point(500, 606);
                uiImageButton7.Location = new Point(607, 605);
                uiImageButton8.Location = new Point(295, 612);
                uiImageButton9.Location = new Point(370, 613);
                uiImageButton10.Location = new Point(808, 606);
                uiImageButton11.Location = new Point(727, 607);

                // 调整返回按钮
                Back.Image = ((Image)(resourceManager.GetObject("icons8-slide-up-52")));
                Back.ImageHover = ((Image)(resourceManager.GetObject("icons8-slide-up-52 (1)")));
                if (uiImageButton15 != null && this.Controls.Contains(uiImageButton15))
                {
                    this.Controls.Remove(uiImageButton15);
                    uiImageButton15.Dispose();
                    uiImageButton15 = null;
                }

                if (uiImageButton16 != null && this.Controls.Contains(uiImageButton16))
                {
                    this.Controls.Remove(uiImageButton16);
                    uiImageButton16.Dispose();
                    uiImageButton16 = null;
                }

                //调整添加歌单按钮
                uiImageButton18.Size = new Size(33, 33);
                uiImageButton18.Location = new Point(22, 270);

                //调整歌单label
                uiLabel5.Visible = false;
            }
            else
            {
                // 切换回第一个窗体形态
                //调整搜索框
                searchBox.Location = new Point(449, 28);

                //调整搜索旁按钮
                closeSearchButton.Location = new Point(724, 31);

                // 恢复pictureBox2
                pictureBox2.Location = new Point(190, 10);
                pictureBox2.Size = new Size(860, 580);

                // 恢复panel2
                panel2.Location = new Point(209, 65);
                panel2.Size = new Size(824, 512);

                //调整uiFlowLayoutPanel1
                flowLayoutPanel1.SendToBack();
                flowLayoutPanel1.Width = 179;

                // 恢复pictureBox1
                pictureBox1.Location = new Point(190, 593);
                pictureBox1.Size = new Size(860, 100);

                // 恢复按钮位置
                uiImageButton1.Location = new Point(1003, 29);
                uiImageButton3.Location = new Point(956, 29);

                // 恢复标签位置
                uiLabel1.Location = new Point(798, 660);
                uiLabel2.Location = new Point(400, 660);
                uiLabel3.Location = new Point(209, 613);
                uiLabel4.Location = new Point(209, 646);

                // 恢复进度条
                uiTrackBar1.Location = new Point(460, 660);
                uiTrackBar1.Size = new Size(334, 15);

                // 恢复底部按钮
                uiImageButton5.Location = new Point(611, 607);
                uiImageButton6.Location = new Point(563, 607);
                uiImageButton7.Location = new Point(661, 607);
                uiImageButton8.Location = new Point(407, 613);
                uiImageButton9.Location = new Point(458, 613);
                uiImageButton10.Location = new Point(806, 607);
                uiImageButton11.Location = new Point(756, 607);

                // 恢复返回按钮
                Back.Image = ((Image)(resourceManager.GetObject("icons8-slide-up-52 (3)")));
                Back.ImageHover = ((Image)(resourceManager.GetObject("icons8-slide-up-52 (2)")));
                if (uiImageButton15 == null)
                {
                    uiImageButton15 = new Sunny.UI.UIImageButton();
                    // 初始化 uiImageButton15 的属性
                    uiImageButton15.Anchor = AnchorStyles.None;
                    uiImageButton15.BackColor = Color.Transparent;
                    uiImageButton15.Cursor = Cursors.Hand;
                    uiImageButton15.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
                    uiImageButton15.Image = (Image)resources.GetObject("uiImageButton15.Image");
                    uiImageButton15.ImageHover = (Image)resources.GetObject("uiImageButton15.ImageHover");
                    uiImageButton15.Location = new Point(75, 654);
                    uiImageButton15.Name = "uiImageButton15";
                    uiImageButton15.Size = new Size(35, 35);
                    uiImageButton15.SizeMode = PictureBoxSizeMode.StretchImage;
                    uiImageButton15.TabIndex = 28;
                    uiImageButton15.TabStop = false;
                    uiImageButton15.Text = null;
                    uiImageButton15.ZoomScaleDisabled = true;
                    uiImageButton15.Click += uiImageButton15_Click;
                    this.Controls.Add(uiImageButton15);
                }

                if (uiImageButton16 == null)
                {
                    uiImageButton16 = new Sunny.UI.UIImageButton();
                    // 初始化 uiImageButton16 的属性
                    uiImageButton16.Anchor = AnchorStyles.None;
                    uiImageButton16.BackColor = Color.Transparent;
                    uiImageButton16.Cursor = Cursors.Hand;
                    uiImageButton16.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
                    uiImageButton16.Image = (Image)resources.GetObject("uiImageButton16.Image");
                    uiImageButton16.ImageHover = (Image)resources.GetObject("uiImageButton16.ImageHover");
                    uiImageButton16.Location = new Point(125, 656);
                    uiImageButton16.Name = "uiImageButton16";
                    uiImageButton16.Size = new Size(33, 33);
                    uiImageButton16.SizeMode = PictureBoxSizeMode.StretchImage;
                    uiImageButton16.TabIndex = 29;
                    uiImageButton16.TabStop = false;
                    uiImageButton16.Text = null;
                    uiImageButton16.ZoomScaleDisabled = true;
                    uiImageButton16.Click += uiImageButton16_Click;
                    this.Controls.Add(uiImageButton16);
                }

                //调整添加歌单按钮
                uiImageButton18.Size = new Size(25, 25);
                uiImageButton18.Location = new Point(135, 276);

                //调整歌单label
                uiLabel5.Visible = true;

                
            }
            isFirstForm = !isFirstForm; // 切换状态

        }

        // 事件定义, 通知 MusicForm 执行实际逻辑
        //public event Action<int>? PlaySongRequested;
        public event Action<List<Song>>? PlaylistSet;

        public event Action<double>? PlaybackSpeedChanged;
        public event Action PlayNextRequested;
        public event Action PlayPreviousRequested;
        public event Action PlayPauseRequested;
        public event Action<TimeSpan> SeekRequested; // 以上用于 MusicForm交互

        // 用于响应 MusicForm 的事件
        private MusicForm _musicForm;
        // 默认加载的歌单
        private Songlist _songlist;
        private bool _isDragging;

        // 载入的页面

        // 应该是从 SonglistRepo 里获取，这里做测试使用


        private void uiImageButton5_Click_1(object sender, EventArgs e)
        {
            Console.WriteLine("Invoke PlayPause");
            //AppContext.TriggerPlayPauseRequested();
            AppContext.TogglePlayPause();
        }

        private void uiImageButton6_Click(object sender, EventArgs e)
        {
            //AppContext.TriggerPlayPreviousRequested();
            AppContext._playbackService.PlayPrevious();
            var current = AppContext._playbackService.GetCurrentSong();
            if (current == null)
            {
                Console.WriteLine("current song is null!");
                current = AppContext._playbackService.GetPlaylist().PlaySongs[0];
            }
            AppContext.TriggerupdateSongUI(current);
            AppContext.TriggerShowPlayingBtn(true);
            AppContext.StartTimer();
            var text = AppContext._playbackService.GetCurrentLyricsLine()?.Text ?? "（无歌词）";
            var position = AppContext._playbackService.GetCurrentPosition();
            AppContext.TriggerLyricsUpdated(text, position);
        }

        private void uiImageButton7_Click(object sender, EventArgs e)
        {
            if (AppContext._playbackService.GetCurrentSong() == null)
            {
                new MainForms.MessageForm("请先播放一首歌曲!").ShowDialog();
                return;
            }
            AppContext._playbackService.PlayNext();
            var current = AppContext._playbackService.GetCurrentSong();
            if (current == null)
            {
                Console.WriteLine("current song is null!");
                current = AppContext._playbackService.GetPlaylist().PlaySongs[0];
            }
            AppContext.TriggerupdateSongUI(current);
            AppContext.TriggerShowPlayingBtn(true);
            AppContext.StartTimer();

            var text = AppContext._playbackService.GetCurrentLyricsLine()?.Text ?? "（无歌词）";
            var position = AppContext._playbackService.GetCurrentPosition();
            AppContext.TriggerLyricsUpdated(text, position);

        }


        private void uiImageButton4_Click(object sender, EventArgs e)
        {

        }

        private void ExploreForm_Load(object sender, EventArgs e)
        {

        }

        private void ExploreForm_Load_1(object sender, EventArgs e)
        {

        }

        //
        //UI:菜单栏三个按钮
        //
        private BHButton MenuButton1;
        private BHButton MenuButton2;
        private BHButton MenuButton3;

        private void InitializeMenu()
        {
            MenuButton1 = new BHButton("icons8-christmas-star-100 (2)", "icons8-christmas-star-100 (3)", "收藏");
            MenuButton2 = new BHButton("icons8-scroll-down-96", "icons8-scroll-down-96 (1)", "下载");
            MenuButton3 = new BHButton("icons8-list-96", "icons8-list-96 (1)", "播放队列");

            MenuButton1.Click += MenuButton1_Click;
            MenuButton2.Click += MenuButton2_Click;
            MenuButton3.Click += MenuButton3_Click;

            MenuButton1.Location = new Point(6, 91);
            MenuButton2.Location = new Point(6, 148);
            MenuButton3.Location = new Point(6, 205);

            this.Controls.Add(MenuButton1);
            this.Controls.Add(MenuButton2);
            this.Controls.Add(MenuButton3);

        }

        private void MenuButton1_Click(object? sender, EventArgs e)
        {
            LoadPage(new Favorite());
        }

        private void MenuButton2_Click(object? sender, EventArgs e)
        {
            LoadPage(page: new Download());
        }

        private void MenuButton3_Click(object? sender, EventArgs e)
        {
            LoadPage(page: new PlayList());
        }

        //
        // UI:音量控制
        //
        private VolumeControl volumeControl = null;
        private void uiImageButton11_Click(object sender, EventArgs e)
        {
            if (volumeControl == null)
            {
                //Console.WriteLine($"clicked, {AppContext._playbackService.GetVolume()}");
                volumeControl = new VolumeControl(uiImageButton11.Location, (int)((AppContext._playbackService.GetVolume()) * 100));
                this.Controls.Add(volumeControl);
                volumeControl.BringToFront();
            }
            else
            {
                using (volumeControl) // 自动释放
                {
                    this.Controls.Remove(volumeControl);
                }
                volumeControl = null;
            }

        }

        //
        //UI:倍速控制
        //
        private SpeedControl speedControl = null;
        private void uiImageButton17_Click(object sender, EventArgs e)
        {
            if (speedControl == null)
            {
                if (AppContext._playbackService.audioFileReader == null)
                {
                    new Byte_Harmonic.Forms.MainForms.MessageForm("请先播放一首歌曲!").ShowDialog(); 
                    return;
                }
                speedControl = new SpeedControl(uiImageButton17.Location, AppContext._playbackService.GetPlaybackSpeed());
                this.Controls.Add(speedControl);
                speedControl.BringToFront();
            }
            else
            {
                using (speedControl) // 自动释放
                {
                    this.Controls.Remove(speedControl);
                }
                speedControl = null;
            }

        }

        //
        //UI:播放顺序控制
        //
        private PlayOrderControl playOrderControl = null;
        private void uiImageButton9_Click(object sender, EventArgs e)
        {
            if (playOrderControl == null)
            {
                playOrderControl = new PlayOrderControl(uiImageButton9.Location);
                playOrderControl.RequestClose += () =>
                {
                    Console.WriteLine("closed of playOrderControl ");
                    this.Controls.Remove(playOrderControl);
                    playOrderControl.Dispose();
                    playOrderControl = null;
                };
                this.Controls.Add(playOrderControl);
                playOrderControl.BringToFront();
            }
            else
            {
                using (playOrderControl) // 自动释放
                {
                    this.Controls.Remove(playOrderControl);
                }
                playOrderControl = null;
            }
        }

        //
        //UI:更多
        //
        public MoreControl moreControl = null;
        private void uiImageButton13_Click(object sender, EventArgs e)
        {
            if (moreControl == null)
            {
                moreControl = new MoreControl(uiImageButton13.Location);
                this.Controls.Add(moreControl);
                moreControl.BringToFront();
                moreControl.AttachDismissOnClickOutside(this);
            }
            else
            {
                using (moreControl) // 自动释放
                {
                    this.Controls.Remove(moreControl);
                }
                moreControl = null;
            }
        }

        //
        //初始化侧边歌单 或 重新加载
        //
        private void InitializeSongsList()
        {
            Console.WriteLine("InitializeSongsList");
            // 清空之前的控件
            flowLayoutPanel1.Controls.Clear();
            //调用后端获取歌单
            var songlists = AppContext.songlistRepository.GetUserOwnPlaylists(AppContext.currentUser.Account);

            int num = 1;
            foreach (var item in songlists)
            {
                // 创建控件
                var item_name = item.Name;
                num %= 13;
                num++;
                Control control = new BHButton("2 (" + num + ")", "2 (" + num + ")", item_name);
                control.Click += (s, e) =>
                {
                    AppContext.currentViewingSonglist = item;
                    AppContext.TriggerSonglistLoaded();
                };
                control.Tag = item; // 将数据对象存储在Tag中
                control.Width = 155;
                // 添加到父容器
                flowLayoutPanel1.Controls.Add(control);
            }
        }
        #endregion
        //
        // 装入 MusicExplorerControl
        //
        private void LoadMusicExplorerControl()
        {
            LoadPage(page: new MusicExplorerControl());
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            LoadMusicExplorerControl();
        }
        //
        //搜索栏
        //
        private AdvancedSearchBox searchBox;
        private void InitializeSearchBox()
        {
            searchBox = new AdvancedSearchBox();
            searchBox.Location = new Point(449, 29);
            searchBox.Width = 300;
            this.Controls.Add(searchBox);
            searchBox.BringToFront();

            // 绑定事件等
            searchBox.SearchTriggered += OnSearchTriggered;
            searchBox.GetSuggestions += GetSearchSuggestions;
            searchBox.GetHistoryTags += GetSearchHistory;
            searchBox.HistoryChanged += ChangeHistory;
            closeSearchButton.BringToFront();
        }

        private async void OnSearchTriggered(string searchText)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(searchText))
                {
                    new Byte_Harmonic.Forms.MainForms.MessageForm("请输入搜索内容").ShowDialog(); 
                    return;
                }

                // 显示加载状态
                //var loading = new UILoading(this);
                // loading.Show();

                // 执行搜索
                var results = await _searchService.SearchSongs(searchText);
                /* foreach (var song in results)
                 {
                     Console.WriteLine($"ID: {song.Id}, Title: {song.Title}, Artist: {song.Artist}, Duration: {song.Duration} seconds");
                 }*/
                // 关闭加载状态
                //loading.Hide();

                if (results == null || results.Count == 0)
                {
                    new Byte_Harmonic.Forms.MainForms.MessageForm("未找到匹配的歌曲").ShowDialog();
                    return;
                }

                // 创建并加载搜索结果页面
                LoadPage(new Forms.Controls.FrameControls.MainPanel.SearchResult(results));
            }
            catch (Exception ex)
            {
                new Byte_Harmonic.Forms.MainForms.MessageForm($"搜索出错: {ex.Message}").ShowDialog();
            }
            /*// 处理搜索逻辑
            UIMessageBox.Show($"执行搜索: {searchText}", "搜索", UIStyle.Custom);*/
        }

        private async Task<List<string>> GetSearchSuggestions(string input)
        {
            
            try
            {
                if (string.IsNullOrWhiteSpace(input))
                {
                    return new List<string>();
                }

                var songs = await _searchService.JustSearchSong(input);
                return songs
                    .Select(s => $"{s.Artist} - {s.Title}")
                    .Distinct()
                    .Take(10) // 限制建议数量
                    .ToList();
            }
            catch
            {
                return new List<string>();
            }
        }

        private async Task<List<string>> GetSearchHistory()
        {
            /*// 模拟获取历史记录
            return new List<string>
        {
            "周杰伦",
            "林俊杰",
            "韩红",
            "七里香",
            "周杰伦 七里香",
            "周杰伦 晴天",
            "杰伦 夜曲",
        };*/
            try
            {
                if (AppContext.currentUser == null)
                {
                    return new List<string>();
                }

                return await AppContext.userRepository.GetSearchHistoryAsync(AppContext.currentUser.Account);
            }

            catch
            {
                return new List<string>();
            }

        }

        private async void ChangeHistory(List<string> history)
        {
            try
            {
                if (AppContext.currentUser != null)
                {
                    await _searchService.UpdateSearchHistory(
                        AppContext.currentUser.Account,
                        history
                    );
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"更新搜索历史失败: {ex.Message}");
            }
        }

        private void uiImageButton15_Click(object sender, EventArgs e)
        {
            LoadPage(page: new Settings());
        }

        private void uiImageButton16_Click(object sender, EventArgs e)
        {
            LoadPage(page: new UserForm());
        }
        
        private void uiImageButton8_Click(object sender, EventArgs e)
        {
            if (AppContext._playbackService.GetCurrentSong() == null)
            {
                new MainForms.MessageForm("请先播放歌曲后再收藏!").ShowDialog();
                return;
            }
            if (_favoritesService.IsSongFavorite(AppContext.currentUser.Account, AppContext._playbackService.GetCurrentSong().Id) == true)
            {
                _favoritesService.RemoveFavoriteSongAsync(AppContext.currentUser.Account, AppContext._playbackService.GetCurrentSong().Id);
                // bool isFavorite = _favoritesService.IsSongFavorite(AppContext.currentUser.Account, AppContext._playbackService.GetCurrentSong().Id);
                starControl.InitStarButton(false);
                new MessageForm("取消收藏成功!").ShowDialog();
                AppContext.TriggerFavoriteUpdated();
            }
            else
            {
                int temp = AppContext._playbackService.GetCurrentSong().Id;
                _favoritesService.AddFavoriteSongAsync(AppContext.currentUser.Account, temp);
                bool isFavorite = _favoritesService.IsSongFavorite(AppContext.currentUser.Account, AppContext._playbackService.GetCurrentSong().Id);
                starControl.InitStarButton(true);
                new MessageForm("收藏成功!").ShowDialog();
                AppContext.TriggerFavoriteUpdated();
            }
        }

        private void uiImageButton10_Click(object sender, EventArgs e)
        {
            LoadPage(new Forms.Controls.FrameControls.MainPanel.PlayList());
        }

        private void uiImageButton18_Click(object sender, EventArgs e)
        {

            new Byte_Harmonic.Forms.CreateSongListForm().ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            searchBox.HideDropDown();
        }

        private void Panel2_Click(object sender, EventArgs e)
        {
            searchBox.HideDropDown();
        }

        private bool searchBoxIsHide = true;
        private void closeSearchButton2_Click(object sender, EventArgs e)
        {
            if(searchBoxIsHide)
            {
                searchBox.ShowDropDown();
            }
            else
            {
                searchBox.HideDropDown();
            }
        }

        private void OnChangeSearchBox()
        {
            searchBoxIsHide = !searchBoxIsHide;
            if (searchBoxIsHide)
            {
                closeSearchButton.Image= ((Image)(resourceManager.GetObject("icons8-less-than-100 - 副本")));
                closeSearchButton.ImageHover = ((Image)(resourceManager.GetObject("icons8-less-than-100 (1) - 副本")));
            }
            else
            {
                closeSearchButton.Image = ((Image)(resourceManager.GetObject("icons8-less-than-100")));
                closeSearchButton.ImageHover = ((Image)(resourceManager.GetObject("icons8-less-than-100 (1)")));
            }
        }
    }
}
