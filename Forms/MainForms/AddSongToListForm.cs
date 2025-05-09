using Byte_Harmonic.Forms.Controls.BaseControls;
using Byte_Harmonic.Forms.FormUtils;
using Byte_Harmonic.Models;
using Byte_Harmonic.Services;
using Org.BouncyCastle.Utilities;

namespace Byte_Harmonic.Forms.MainForms
{
    public partial class AddSongToListForm : Form
    {
        private Song song;
        private List<Song> songs;
        private readonly MouseMove _mouseHandler;//用于鼠标控制窗口
        private readonly FormStyle _styleHandler;//用于更改窗口样式
        private int cornerRadius = 18;//通用设置圆角
        private SonglistService songlistService;
        public AddSongToListForm(Song _song)
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);//双缓冲减少闪烁
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            _mouseHandler = new MouseMove(this);
            _styleHandler = new FormStyle(this);
            Init();

            song = _song;
            this.Load += AddSongToListForm_Load;
            addButton.Click += oneSongAdd;
        }

        //
        //批量处理情况
        //
        public AddSongToListForm(List<Song> _songs)
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);//双缓冲减少闪烁
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            _mouseHandler = new MouseMove(this);
            _styleHandler = new FormStyle(this);
            Init();

            songs = _songs;
            this.Load += AddSongToListForm_Load;
            addButton.Click += songsAdd;
        }

        private void Init()
        {
            songlistService = AppContext.songlistService;

            uiImageButton2.Visible = false;
            label1.Visible = false;
            flowLayoutPanel.Visible = true;
            flowLayoutSongsPanel.Visible = false;
        }

        private void AddSongToListForm_Load(object sender, EventArgs e)
        {
            LoadLists();
        }

        private void LoadLists()//加载歌单列表
        {
            flowLayoutPanel.Controls.Clear(); // 清空现有项

            bool isWhite = false; // 初始颜色标记
            Color[] colors = { Color.White, Color.FromArgb(240, 240, 240) }; // 黑白交替色

            //调用后端函数获取所有歌单
            List<Songlist> songlists = songlistService.GetCurrentUserSonglists();

            foreach (Songlist list in songlists)
            {
                // 创建Item（交替颜色）
                LibraryItem item = new LibraryItem(
                    color: colors[isWhite ? 0 : 1],
                    _ID: list.Id,
                    _Name: list.Name
                );

                // 添加到FlowLayoutPanel
                flowLayoutPanel.Controls.Add(item);
                item.BringToFront();
                isWhite = !isWhite; // 切换颜色标记
            }
        }

        public void changeToSongView(int listID, string listName)//变为歌单内部页
        {
            //获取歌单内的所有歌
            List<Song> songs;
            flowLayoutSongsPanel.Controls.Clear();

            try
            {
                songs = songlistService.GetSongsInSonglist(songlistService.GetSonglistById(listID));

            }
            catch(Exception ex)
            {
                new Byte_Harmonic.Forms.MainForms.MessageForm("获取歌单中歌曲失败").ShowDialog();
                return;
            }

            uiImageButton2.Visible = true;
            label1.Visible = true;
            label1.Text = listName;

            flowLayoutPanel.Visible = false; // 切换页面
            flowLayoutSongsPanel.Visible = true;

            bool isWhite = false; // 初始颜色标记
            Color[] colors = { Color.White, Color.FromArgb(240, 240, 240) }; // 黑白交替色

            try
            {
                foreach (Song song in songs)
                {
                    // 创建SongItem（交替颜色）
                    LibraryItem item = new LibraryItem(
                        color: colors[isWhite ? 0 : 1],
                        _ID: song.Id,
                        _Name: song.Title + " —— " + song.Artist
                    );
                    item.ChangetoSongStyle();//更换为展示歌曲样式
                    // 添加到flowLayoutSongsPanel
                    flowLayoutSongsPanel.Controls.Add(item);
                    item.BringToFront();
                    isWhite = !isWhite; // 切换颜色标记
                }
            }
            catch(Exception ex)
            {
                new Byte_Harmonic.Forms.MainForms.MessageForm(ex.Message).ShowDialog();
            }
        }

        private void uiImageButton2_Click(object sender, EventArgs e)//转回列表页
        {
            this.uiImageButton2.Visible = false;
            this.label1.Visible = false;
            flowLayoutPanel.Visible = true; // 切换页面
            flowLayoutSongsPanel.Visible = false;
        }

        private void oneSongAdd(object sender, EventArgs e)
        {
            
            foreach (LibraryItem item in flowLayoutPanel.Controls)
            {
                if (item.Selected)
                {
                    try
                    {
                        songlistService.AddSongToSonglist(song, songlistService.GetSonglistById(item.ID));
                        AppContext.TriggerSonglistDetailUpdated(songlistService.GetSonglistById(item.ID).Name);
                    }
                    catch(Exception ex)
                    {
                        new Byte_Harmonic.Forms.MainForms.MessageForm(ex.Message).ShowDialog();
                        return;
                    }
                }
            }

            new Byte_Harmonic.Forms.MainForms.MessageForm("添加成功").ShowDialog();

            try
            {
                Byte_Harmonic.Forms.MainForms.AddSongToListForm addform = this.FindForm() as AddSongToListForm;
                if (addform != null)
                {
                    addform.Close();
                }
            }
            catch (Exception ex)
            {
                new Byte_Harmonic.Forms.MainForms.MessageForm(ex.Message).ShowDialog();
                return;
            }
        }

        private void songsAdd(object sender, EventArgs e)
        {
            foreach(Song oneSong in songs)
            {
                foreach (LibraryItem item in flowLayoutPanel.Controls)
                {
                    if (item.Selected)
                    {
                        try
                        {
                            songlistService.AddSongToSonglist(oneSong, songlistService.GetSonglistById(item.ID));
                            AppContext.TriggerSonglistDetailUpdated(songlistService.GetSonglistById(item.ID).Name);
                        }
                        catch (Exception ex)
                        {
                            new Byte_Harmonic.Forms.MainForms.MessageForm(ex.Message).ShowDialog();
                            return;
                        }
                    }
                }
            }

            new Byte_Harmonic.Forms.MainForms.MessageForm("添加成功").ShowDialog();

            try
            {
                Byte_Harmonic.Forms.MainForms.AddSongToListForm addform = this.FindForm() as AddSongToListForm;
                if (addform != null)
                {
                    addform.Close();
                }
            }
            catch (Exception ex)
            {
                new Byte_Harmonic.Forms.MainForms.MessageForm(ex.Message).ShowDialog();
                return;
            }
        }

        private void CreateListButton_Click(object sender, EventArgs e)
        {
            new Byte_Harmonic.Forms.CreateSongListForm().ShowDialog();
            LoadLists();
        }

        private void uiImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void uiImageButton3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
