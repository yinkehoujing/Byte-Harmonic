using Byte_Harmonic.Forms.Controls.BaseControls;
using Byte_Harmonic.Models;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Byte_Harmonic.Forms.MainForms
{
    public partial class AddSongToListForm : Form
    {
        private bool islist = true;//是否在展示歌单页
        public AddSongToListForm()
        {
            InitializeComponent();
            uiImageButton2.Visible = false;
            label1.Visible = false;
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

        public void changeToSongView(int listID)//变为歌单内部页
        {
            //TODO:获取歌单内的所有歌
            List<Song> songs = new List<Song> { };

            this.uiImageButton2.Visible = true;
            this.label1.Visible = true;

            flowLayoutPanel.Controls.Clear(); // 清空现有项

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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void uiImageButton2_Click(object sender, EventArgs e)//转回列表页
        {
            this.uiImageButton2.Visible = false;
            this.label1.Visible = false;

            LoadLists();
        }
    }
}
