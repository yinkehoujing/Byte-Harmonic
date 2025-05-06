using System;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using Sunny.UI;
using Byte_Harmonic.Properties;

namespace Byte_Harmonic.Forms.Controls.BaseControls
{
    public partial class SongItemControl : UserControl
    {
        private UILabel titleLabel;
        private UILabel artistLabel;
        private UIImageButton playButton;
        private UIImageButton favButton;
        private UIImageButton downloadButton;

        public event EventHandler PlayClicked;
        public event EventHandler FavoriteClicked;
        public event EventHandler DownloadClicked;

        public string SongTitle
        {
            get => titleLabel.Text;
            set => titleLabel.Text = value;
        }

        public string Artist
        {
            get => artistLabel.Text;
            set => artistLabel.Text = value;
        }

        public SongItemControl()
        {
            InitializeComponent();
            SetupLayout();
        }
        private void SetupLayout()
        {
            this.Height = 60;  // 适当增加高度
            this.Width = 1000;
            this.Margin = new Padding(5);

            var resourceManager = new ResourceManager("Byte_Harmonic.Properties.Resources", typeof(Resources).Assembly);

            titleLabel = new UILabel
            {
                Text = "歌曲名称",
                Font = new Font("Microsoft YaHei", 10F, FontStyle.Bold),
                Location = new Point(10, 5),
                AutoSize = true
            };

            artistLabel = new UILabel
            {
                Text = "演唱者",
                Font = new Font("Microsoft YaHei", 9F),
                Location = new Point(10, 25),
                AutoSize = true
            };

            //playButton = CreateIconButton(resourceManager.GetObject("icons8-播放-96") as Image, PlayClicked);
            //favButton = CreateIconButton(resourceManager.GetObject("icons8-christmas-star-100") as Image, FavoriteClicked);
            //downloadButton = CreateIconButton(resourceManager.GetObject("icons8-scroll-down-96") as Image, DownloadClicked);

            //int buttonStartX = 800;
            //playButton.Location = new Point(buttonStartX, 10);
            //favButton.Location = new Point(buttonStartX + 40, 10);
            //downloadButton.Location = new Point(buttonStartX + 80, 10);

            this.Controls.Add(titleLabel);
            this.Controls.Add(artistLabel);
            //this.Controls.Add(playButton);
            //this.Controls.Add(favButton);
            //this.Controls.Add(downloadButton);
        }

        private UIImageButton CreateIconButton(Image img, EventHandler clickEvent)
        {
            var btn = new UIImageButton
            {
                Size = new Size(24, 24),
                Image = img,
                Cursor = Cursors.Hand
            };
            if (clickEvent != null)
                btn.Click += (s, e) => clickEvent?.Invoke(this, EventArgs.Empty);

            return btn;
        }
    }
}
