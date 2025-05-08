using System;
using System.Drawing;
using System.Windows.Forms;
using Byte_Harmonic.Forms.FormUtils;
using Sunny.UI;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Byte_Harmonic.Forms.Controls.BaseControls
{
    public partial class SongItemControl : UserControl
    {
        private Color color;
        public int songID;
        private string songName;


        public SongItemControl(Color color, int songID, string songNameAndArtistName)
        {
            InitializeComponent();
            this.songID = songID;
            this.songName = songNameAndArtistName;
            this.color = color;
            InitializeUI();
        }

        private void InitializeUI()
        {

            //uiLabel1.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            //uiLabel1.AutoSize = false;

            //int buttonSpacing = 5;
            //int buttonRightMargin = 10;

            //playButton.Anchor = AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            //playButton.Location = new Point(Width - buttonRightMargin - 24, 10);

         
            //this.Resize += (sender, e) =>
            //{
            //    uiLabel1.Width = playButton.Left - uiLabel1.Left - buttonSpacing;

            //    playButton.Left = Width - buttonRightMargin - 24;
            //};

            this.BackColor = color;

            uiLabel1.Text = songName;
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            // TODO: 播放逻辑
        }

        private void downloadButton_Click(object sender, EventArgs e)
        {
            // TODO: 下载逻辑
        }

        private void favoriteButton_Click(object sender, EventArgs e)
        {
            // TODO: 收藏逻辑
        }

        public void BulkActions()
        {
        }

        public void CancelBulkActions()
        {
        }

    }
}
