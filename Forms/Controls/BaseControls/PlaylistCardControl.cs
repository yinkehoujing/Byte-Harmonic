using System;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using Byte_Harmonic.Properties;
using Sunny.UI;

namespace Byte_Harmonic.Forms.Controls.BaseControls
{
    public partial class PlaylistCardControl : UserControl
    {
        private UIImageButton imageButton;
        private Label titleLabel;

        public event EventHandler PlaylistClicked;

        public Image CoverImage
        {
            get => imageButton.Image;
            set => imageButton.Image = value;
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
            this.Width = 100;
            this.Height = 130;
            this.Margin = new Padding(10);

            var resourceManager = new ResourceManager("Byte_Harmonic.Properties.Resources", typeof(Resources).Assembly);
            var img = (Image)(resourceManager.GetObject("20180317200156_qpcds"));

            imageButton = new UIImageButton
            {
                Size = new Size(100, 100),
                Dock = DockStyle.Top,
                Image = img,
                ZoomScaleRect = new Rectangle(0, 0, 100, 100),
                Cursor = Cursors.Hand
            };

            imageButton.Click += (s, e) => PlaylistClicked?.Invoke(this, EventArgs.Empty);

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
