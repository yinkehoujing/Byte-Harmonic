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
    public partial class SongList: UserControl
    {
        public SongList()
        {
            InitializeComponent();
        }

        public void LoadSongs(List<Song> songs)
        {
            flowLayoutSongs.Controls.Clear(); // 清空现有项

            bool isWhite = false; // 初始颜色标记
            Color[] colors = { Color.White, Color.FromArgb(240, 240, 240) }; // 黑白交替色

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

    }
}
