using System;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using Byte_Harmonic.Properties;
using Sunny.UI;

namespace Byte_Harmonic.Forms.Controls.BaseControls
{
    // 外部响应 PlaylistClicked 事件
    public partial class PlaylistCardControl : UserControl
    {
        private UIImageButton imageButton;
        private string imageText;
        private Label titleLabel;

        public event Action<string> PlaylistClicked;


        public string CoverImageText
        {
            get => imageText;
            set => imageText = value;
        }

        public string PlaylistName
        {
            get => titleLabel.Text;
            set => titleLabel.Text = value;
        }

        public PlaylistCardControl()
        {
            InitializeComponent();
            SetupLayout();
        }

        private void SetupLayout()
        {
            imageText = "1 (10)"; // default image seed
            this.Width = 100;
            this.Height = 130;
            this.Margin = new Padding(10);

            var resourceManager = new ResourceManager("Byte_Harmonic.Properties.Resources", typeof(Resources).Assembly);
            var img = (Image)(resourceManager.GetObject(imageText));

            imageButton = new UIImageButton
            {
                Size = new Size(100, 100),
                Dock = DockStyle.Top,
                Image = img,
                ZoomScaleRect = new Rectangle(0, 0, 100, 100),
                Cursor = Cursors.Hand
            };

            imageButton.Click += async (s, e) =>
            {
               PlaylistClicked?.Invoke(PlaylistName);
            };

            titleLabel = new Label
            {
                Dock = DockStyle.Bottom,
                Height = 30,
                Text = "歌单",
                Font = new Font("Microsoft YaHei", 10F),
                TextAlign = ContentAlignment.MiddleCenter
            };

            this.Controls.Add(imageButton);
            this.Controls.Add(titleLabel);
        }
    }
}
