using Byte_Harmonic.Database;
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

namespace Byte_Harmonic.Forms
{
    public partial class ExploreForm : UserControl
    {
        private ResourceManager resourceManager;
        private StarControl starControl;
        public ExploreForm()
        {
            InitializeComponent();
            InitializeMenu();//初始化菜单三个按钮
            InitializeSongsList();//初始化侧边歌单
            InitializeSearchBox();//初始化搜索框
            resourceManager = new ResourceManager("Byte_Harmonic.Properties.Resources", typeof(Resources).Assembly);//获取全局资源
            starControl = new StarControl(uiImageButton8);
            starControl.InitStarButton(false);//初始化收藏按钮 //TODO传入是否被收藏
            uiImageButton8.Click += starControl.StarButtonClick;

           // LoadMusicExplorerControl(); // 装入初始探索页面
            LoadPage(page: new SongsList());
            uiLabel3.EnableAutoScroll();//支持文字过长时滚动
            uiLabel4.EnableAutoScroll();

            // 使用 AppContext 注册事件
            AppContext.LyricsUpdated += OnLyricsUpdated;
            AppContext.updateSongUI += OnUpdateSongUI;
            AppContext.ShowPlayingBtn += OnShowPlayingBtn;
            AppContext.SonglistLoaded += LoadSonglistToPanel;
            var songlist = AppContext._songRepository.GetAllSongs();

            if (songlist.Count <= 0)
            {
                throw new ArgumentException("songlist 为空!!!");
            }

            var song = AppContext._playbackService.GetCurrentSong();
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
        private void LoadSonglistToPanel()
        {
            Console.WriteLine("load a new panel");
            panel2.Controls.Clear();
            panel2.Controls.Add(new Controls.FrameControls.MainPanel.PlayList());
        }
        public void LoadPage(UserControl page)
        {
            panel2.Controls.Clear();    // 清空之前的页面
            page.Dock = DockStyle.Fill;        // 填满容器
            panel2.Controls.Add(page);   // 添加新页面
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
                searchBox.Location = new Point(173, 28);

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
                uiImageButton2.Location = new Point(97, 28);
                uiImageButton4.Location = new Point(133, 28);

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
                searchBox.Location = new Point(285, 28);

                // 恢复pictureBox2
                pictureBox2.Location = new Point(190, 10);
                pictureBox2.Size = new Size(860, 580);

                // 恢复panel2
                panel2.Location = new Point(209, 65);
                panel2.Size = new Size(824, 512);

                //调整uiFlowLayoutPanel1
                flowLayoutPanel1.SendToBack();
                flowLayoutPanel1.Width = 170;

                // 恢复pictureBox1
                pictureBox1.Location = new Point(190, 593);
                pictureBox1.Size = new Size(860, 100);

                // 恢复按钮位置
                uiImageButton1.Location = new Point(1003, 29);
                uiImageButton3.Location = new Point(956, 29);
                uiImageButton2.Location = new Point(209, 29);
                uiImageButton4.Location = new Point(245, 29);

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

        private void uiTrackBar1_ValueChanged(object sender, EventArgs e)
        {

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
        }

        private void uiImageButton7_Click(object sender, EventArgs e)
        {
            AppContext._playbackService.PlayNext();
            var current = AppContext._playbackService.GetCurrentSong();
            if (current == null)
            {
                Console.WriteLine("current song is null!");
                current = AppContext._playbackService.GetPlaylist().PlaySongs[0];
            }
            AppContext.TriggerupdateSongUI(current);

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

            //TODO
            //MenuButton1.Click += MenuButton1_Click;
            //MenuButton2.Click += MenuButton2_Click;
            //MenuButton3.Click += MenuButton3_Click;

            MenuButton1.Location = new Point(6, 91);
            MenuButton2.Location = new Point(6, 148);
            MenuButton3.Location = new Point(6, 205);

            this.Controls.Add(MenuButton1);
            this.Controls.Add(MenuButton2);
            this.Controls.Add(MenuButton3);

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
        private MoreControl moreControl = null;
        private void uiImageButton13_Click(object sender, EventArgs e)
        {
            if (moreControl == null)
            {
                moreControl = new MoreControl(uiImageButton13.Location);
                this.Controls.Add(moreControl);
                moreControl.BringToFront();
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
        //初始化侧边歌单
        //
        private void InitializeSongsList()
        {
            //TODO:调用后端获取歌单
            List<string> dataList;
            dataList = ["1", "2", "3", "4", "5", "6", "7"];

            foreach (string item in dataList)
            {
                // 创建控件
                Random random = new Random();
                int randomNumber = random.Next(1, 11);
                string num = randomNumber.ToString();
                Control control = new BHButton("1 (" + num + ")", "1 (" + num + ")", item);
                control.Tag = item; // 将数据对象存储在Tag中
                control.Width = 155;
                // 添加到父容器
                flowLayoutPanel1.Controls.Add(control);
            }
        }

        //
        // 装入 MusicExplorerControl
        //
        private void LoadMusicExplorerControl()
        {
            LoadPage(page:new MusicExplorerControl());
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
            searchBox.Location = new Point(285, 29);
            searchBox.Width = 300;
            this.Controls.Add(searchBox);
            searchBox.BringToFront();

            // 绑定事件等
            searchBox.SearchTriggered += OnSearchTriggered;
            searchBox.GetSuggestions += GetSearchSuggestions;
            searchBox.GetHistoryTags += GetSearchHistory;
            searchBox.HistoryChanged += ChangeHistory;
        }

        private void OnSearchTriggered(string searchText)
        {
            // 处理搜索逻辑
            UIMessageBox.Show($"执行搜索: {searchText}", "搜索", UIStyle.Custom);

            // 这里可以添加搜索历史记录
            // AddToSearchHistory(searchText);
        }

        private List<string> GetSearchSuggestions(string input)
        {
            // 模拟后端获取建议项
            var allItems = new List<string>
        {
            "周杰伦 七里香",
            "周杰伦 晴天",
            "周杰伦 夜曲",
            "周杰伦 七里香",
            "周杰伦 晴天",
            "周杰伦 夜曲",
            "林俊杰 江南",
            "林俊杰 修炼爱情",
            "林俊杰 她说",
            "五月天 倔强",
            "五月天 突然好想你",
            "五月天 温柔",
            "陈奕迅 十年",
            "陈奕迅 浮夸",
            "陈奕迅 富士山下",
            "邓紫棋 光年之外",
            "邓紫棋 泡沫",
            "邓紫棋 喜欢你",
            "薛之谦 演员",
            "薛之谦 丑八怪",
            "薛之谦 认真的雪",
            "张惠妹 听海",
            "张惠妹 记得"
        };

            return allItems.FindAll(x => x.Contains(input));
        }

        private List<string> GetSearchHistory()
        {
            // 模拟获取历史记录
            return new List<string>
        {
            "周杰伦",
            "林俊杰",
            "韩红",
            "七里香",
            "周杰伦 七里香",
            "周杰伦 晴天",
            "杰伦 夜曲",
        };
        }

        private void ChangeHistory(List<string> list)
        {

        }
    }
}
