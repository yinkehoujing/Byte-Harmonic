using Byte_Harmonic.Forms.Controls.BaseControls;
using Byte_Harmonic.Models;

namespace Byte_Harmonic.Forms.MainForms
{
    public partial class AddSongToListForm : Form
    {
        private int songID;
        public AddSongToListForm(int _songID)
        {
            InitializeComponent();
            uiImageButton2.Visible = false;
            label1.Visible = false;
            songID = _songID;
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

            //TODO:调用后端函数获取所有歌单
            List<Songlist> songlists = new List<Songlist> { };

            foreach (Songlist list in songlists)
            {
                // 创建Item（交替颜色）
                LibraryItem item = new LibraryItem(
                    color: colors[isWhite ? 0 : 1],
                    listID: list.Id,
                    listName: list.Name
                );

                // 添加到FlowLayoutPanel
                flowLayoutPanel.Controls.Add(item);
                item.BringToFront();
                isWhite = !isWhite; // 切换颜色标记
            }
        }

        public void changeToSongView(int listID,string listName)//变为歌单内部页
        {
            //TODO:获取歌单内的所有歌
            List<Song> songs = new List<Song> { };

            uiImageButton2.Visible = true;
            label1.Visible = true;
            label1.Text = listName;

            flowLayoutPanel.Visible = false; // 切换页面
            flowLayoutSongsPanel.Visible = true;

            bool isWhite = false; // 初始颜色标记
            Color[] colors = { Color.White, Color.FromArgb(240, 240, 240) }; // 黑白交替色

            foreach (Song song in songs)
            {
                // 创建SongItem（交替颜色）
                SongItem item = new SongItem(
                    color: colors[isWhite ? 0 : 1],
                    songID: song.Id,
                    songName: song.Title + " —— " + song.Artist
                );
                item.Width = 484;
                // 添加到FlowLayoutPanel
                flowLayoutPanel.Controls.Add(item);
                item.BringToFront();
                isWhite = !isWhite; // 切换颜色标记
            }
        }

        private void uiImageButton2_Click(object sender, EventArgs e)//转回列表页
        {
            this.uiImageButton2.Visible = false;
            this.label1.Visible = false;
            flowLayoutPanel.Visible = true; // 切换页面
            flowLayoutSongsPanel.Visible = false;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            foreach (LibraryItem item in flowLayoutPanel.Controls)
            {
                if (item.Selected)
                {
                    //TODO:调用后端函数加入歌单中

                }
            }

            new Byte_Harmonic.Forms.MainForms.MessageForm("添加成功").ShowDialog();
            Byte_Harmonic.Forms.MainForms.AddSongToListForm addform = this.FindForm() as AddSongToListForm;
            if (addform != null)
            {
                addform.Close();
            }
        }

        private void BulkOperateButton_Click(object sender, EventArgs e)
        {
            new Byte_Harmonic.Forms.CreateSongListForm().ShowDialog();
            LoadLists();
        }
    }
}
