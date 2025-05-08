using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sunny.UI;
using Byte_Harmonic.Forms.FormUtils;

namespace Byte_Harmonic.Forms.Controls.BaseControls
{
    public partial class SongItem : UserControl
    {
        private Color color;//背景色
        public int songID;//歌的ID
        private string songName;//歌名
        public bool Selected//被选
        {
            get => uiCheckBox.Checked;
        }

        public SongItem(Color color, int songID, string songName)
        {

            InitializeComponent();

            this.songID = songID;
            this.songName = songName;
            this.color = color;

            InitializeUI();
        }

        private void InitializeUI()
        {
            //// 1. 设置 uiCheckBox (左侧固定位置)
            //uiCheckBox.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom;
            //uiCheckBox.Location = new Point(10, 8);  // 左边距10px

            //// 2. 设置 uiLabel1 (中间拉伸部分)
            //uiLabel1.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            //uiLabel1.Location = new Point(40, 10);  // 从checkbox右侧开始
            //uiLabel1.AutoSize = false;  // 禁止自动调整大小

            //// 3. 设置右侧按钮组 (保持右对齐)
            //int buttonSpacing = 5;  // 按钮间距
            //int buttonRightMargin = 10;  // 右边距

            //playButton.Anchor = AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            //playButton.Location = new Point(Width - buttonRightMargin - 24, 10);

            //downloadButton.Anchor = AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            //downloadButton.Location = new Point(playButton.Left - buttonSpacing - 24, 10);

            //addButton.Anchor = AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            //addButton.Location = new Point(downloadButton.Left - buttonSpacing - 24, 10);

            //deleteButton.Anchor = AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            //deleteButton.Location = new Point(addButton.Left - buttonSpacing - 24, 10);

            //// 4. 处理容器大小变化
            //this.Resize += (sender, e) =>
            //{
            //    // 动态调整标签宽度
            //    uiLabel1.Width = deleteButton.Left - uiLabel1.Left - buttonSpacing;

            //    // 重新定位右侧按钮
            //    playButton.Left = Width - buttonRightMargin - 24;
            //    downloadButton.Left = playButton.Left - buttonSpacing - 24;
            //    addButton.Left = downloadButton.Left - buttonSpacing - 24;
            //    deleteButton.Left = addButton.Left - buttonSpacing - 24;
            //};

            this.BackColor = color;
            uiCheckBox.CheckBoxColor = color;
            uiCheckBox.ReadOnly = true;

            uiLabel1.Text = songName;
        }

        private void deleteButton1_Click(object sender, EventArgs e)
        {
            //TODO：调用删除的后端程序

            //TODO:前端更新
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            //TODO:调用添加到页面
        }

        private void downloadButton_Click(object sender, EventArgs e)
        {
            //TODO:调用下载

            
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("playButton clicked!!");
            AppContext.TogglePlayPauseSong(AppContext._songRepository.GetSongById(songID));
            AppContext.TriggerupdateSongUI(AppContext._playbackService.GetCurrentSong());
        }

        //让多选框显示
        public void BulkActions()
        {
            uiCheckBox.CheckBoxColor = MPColor.Blue3;
            uiCheckBox.ReadOnly = false;
            uiCheckBox.Visible = true;
            uiCheckBox.BringToFront();
            Console.WriteLine("bulk");
        }

        //让多选框消失
        public void CancelBulkActions()
        {
            uiCheckBox.CheckBoxColor = color;
            uiCheckBox.ReadOnly = true;
            uiCheckBox.Visible = false;
            Console.WriteLine("notbulk");
        }

        public void ChooseAction()
        {
            uiCheckBox.Checked = true;
        }

        public void NotChooseAction()
        {
            uiCheckBox.Checked = false;
        }

        private void uiLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
