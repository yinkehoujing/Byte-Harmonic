using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Byte_Harmonic.Models;

namespace Byte_Harmonic.Forms.Controls.BaseControls
{
    public partial class SongList : UserControl
    {
        private bool selectAll = false;
        private bool enableBulkOp = false;
        public SongList()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.Margin = new Padding(10);
            this.LoadSongs();
        }

        public void LoadSongs()
        {
            flowLayoutSongs.Controls.Clear(); // 清空现有项

            bool isWhite = false; // 初始颜色标记
            Color[] colors = { Color.White, Color.FromArgb(240, 240, 240) }; // 黑白交替色
            List<Song> songs = AppContext.currentViewingSonglist.Songs;

            foreach (var song in songs)
            {
                // 创建SongItem（交替颜色）
                var item = new SongItem(
                    color: colors[isWhite ? 0 : 1],
                    songID: song.Id,
                    songName: song.Title
                );

                // 设置统一尺寸
                item.Width = flowLayoutSongs.ClientSize.Width - 2; // 留出边距
                item.Height = 40; // 固定高度

                // 添加到FlowLayoutPanel
                flowLayoutSongs.Controls.Add(item);

                isWhite = !isWhite; // 切换颜色标记
            }
        }

        private void SelectAllButton_Click(object sender, EventArgs e)
        {
            selectAll = !selectAll;
            if (selectAll)
            {
                foreach (SongItem item in flowLayoutSongs.Controls)
                {
                    item.ChooseAction();
                }
                
            }
            else
            {
                foreach (SongItem item in flowLayoutSongs.Controls)
                {
                    item.NotChooseAction();
                }
            }
        }

        private void PlayAllButton_Click(object sender, EventArgs e)
        {
            //TODO:播放被选中的第一首歌，item.Selected表示被选中
            foreach (SongItem item in flowLayoutSongs.Controls)
            {
                if (item.Selected)
                {
                    //TODO:后端：加入播放队列
                }
            }
        }

        private void StarAllButton_Click(object sender, EventArgs e)
        {
            foreach (SongItem item in flowLayoutSongs.Controls)
            {
                if (item.Selected)
                {
                    //TODO:后端：收藏
                    //TODO:收藏成功后弹窗
                }
            }
        }

        private void DownloadAllButton_Click(object sender, EventArgs e)
        {
            foreach (SongItem item in flowLayoutSongs.Controls)
            {
                if (item.Selected)
                {
                    //TODO:下载
                    //TODO:下载成功后弹窗
                }
            }
        }

        private void AddAllButton_Click(object sender, EventArgs e)
        {
            //TODO:显示添加到的窗口
        }

        private void DeleteAllButton_Click(object sender, EventArgs e)
        {
            //TODO:后端删除
            //TODO:显示信息面：删除成功
            this.LoadSongs();//更新数据
        }

        private void BulkOperateButton_Click(object sender, EventArgs e)
        {
            enableBulkOp = !enableBulkOp;
            if(enableBulkOp)
            {
                SelectAllButton.Visible = true;
                SelectAllButton.Enabled = true;
                DeleteAllButton.Visible = true;
                DeleteAllButton.Enabled = true;
                AddAllButton.Visible = true;
                AddAllButton.Enabled = true;
                DownloadAllButton.Visible = true;
                DownloadAllButton.Enabled = true;
                StarAllButton.Visible = true;
                StarAllButton.Enabled = true;
                PlayAllButton.Visible = true;
                PlayAllButton.Enabled = true;
            }
            else
            {
                SelectAllButton.Visible = false;
                SelectAllButton.Enabled = false;
                DeleteAllButton.Visible = false;
                DeleteAllButton.Enabled = false;
                AddAllButton.Visible = false;
                AddAllButton.Enabled = false;
                DownloadAllButton.Visible = false;
                DownloadAllButton.Enabled = false;
                StarAllButton.Visible = false;
                StarAllButton.Enabled = false;
                PlayAllButton.Visible = false;
                PlayAllButton.Enabled = false;
            }
        }
    }
}
