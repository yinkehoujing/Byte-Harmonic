using System;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using Byte_Harmonic.Forms.FormUtils;
using Byte_Harmonic.Properties;
using Byte_Harmonic.Utils;
using Sunny.UI;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Byte_Harmonic.Forms.Controls.BaseControls
{
    public partial class SongItemControl : UserControl
    {
        private Color color;
        public int songID;
        private string songName;
        private string artistName;
        private ResourceManager resourceManager;

        public SongItemControl(Color color, int songID, string songName, string artistName)
        {
            InitializeComponent();
            this.songID = songID;
            this.songName = songName;
            this.artistName = artistName;
            this.color = color;
            InitializeUI();
            this.artistName = artistName;

            AppContext.ShowPlayingBtn += OnShowPlayingBtn;
        }

        private void OnShowPlayingBtn(bool isPaused)
        {

            resourceManager = new ResourceManager("Byte_Harmonic.Properties.Resources", typeof(Resources).Assembly);//获取全局资源
            if(AppContext._playbackService == null || AppContext._playbackService.GetCurrentSong().Id != songID)
            {
                // 暂停了显示下面图标
                playButton.Image = ((Image)(resourceManager.GetObject("icons8-播放-96")));
                playButton.ImageHover = ((Image)(resourceManager.GetObject("icons8-播放-96 (1)")));
                return;
            }

            if (isPaused)
            {
                playButton.Image = ((Image)(resourceManager.GetObject("icons8-pause-96")));
                playButton.ImageHover = ((Image)(resourceManager.GetObject("icons8-pause-96 (1)")));
            }
            else
            {
                // 暂停了显示下面图标
                playButton.Image = ((Image)(resourceManager.GetObject("icons8-播放-96")));
                playButton.ImageHover = ((Image)(resourceManager.GetObject("icons8-播放-96 (1)")));

            }
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

            uiLabel1.Text = songName + "——" + artistName;
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            // TODO: 播放逻辑
            Console.WriteLine("playButton clicked!!");
            AppContext.TogglePlayPauseSong(AppContext._songRepository.GetSongById(songID));
            AppContext.TriggerupdateSongUI(AppContext._playbackService.GetCurrentSong());
            var lyricsLine = AppContext._playbackService.GetCurrentLyricsLine()?.Text ?? "[No Lyrics]";
            var position = AppContext._playbackService.GetCurrentPosition();

            AppContext.TriggerLyricsUpdated(lyricsLine, position);            // 更新进度条


        }

        public void BulkActions()
        {
        }

        public void CancelBulkActions()
        {
        }

    }
}
