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

        public event Func<string, Task> PlaylistClicked;

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

        public PlaylistCardControl(string titleText, string imageText)
        {
            InitializeComponent();
            SetupLayout(titleText, imageText);
        }

        private void SetupLayout(string titleText, string imageText)
        {
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
                SizeMode = PictureBoxSizeMode.StretchImage,
                //ZoomScaleRect = new Rectangle(0, 0, 100, 100),
                Cursor = Cursors.Hand
            };

            imageButton.Click += async (s, e) =>
            {
               PlaylistClicked?.Invoke(titleText);
            };

            titleLabel = new Label
            {
                Dock = DockStyle.Bottom,
                Height = 30,
                Text = titleText,
                Font = new Font("Microsoft YaHei", 10F),
                TextAlign = ContentAlignment.MiddleCenter
            };

            this.Controls.Add(imageButton);
            this.Controls.Add(titleLabel);
        }
    }
}
