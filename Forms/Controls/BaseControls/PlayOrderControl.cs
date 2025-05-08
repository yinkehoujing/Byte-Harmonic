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
    public partial class PlayOrderControl: UserControl
    {
        private BHButton bHButton1;
        private BHButton bHButton2;
        private BHButton bHButton3;
        private BHButton bHButton4;

        public event Action? RequestClose;

        private void RaiseClose()
        {
            RequestClose?.Invoke();
        }

        public PlayOrderControl(Point ButtonLocation)
        {
            InitializeComponent();
            InitializeButton();
            this.Location = new Point(ButtonLocation.X - 25, ButtonLocation.Y - 210);
        }

        public void InitializeButton()
        {
            bHButton1 = new BHButton("icons8-定期约会-96", "icons8-定期约会-96 (1)", "顺序播放");
            bHButton2 = new BHButton("icons8-定期约会-96 (2)", "icons8-定期约会-96 (3)", "单曲循环");
            bHButton3 = new BHButton("icons8-repeat-96", "icons8-repeat-96 (1)", "列表循环");
            bHButton4 = new BHButton("icons8-随机-96 (1)", "icons8-随机-96", "随机播放");
            bHButton1.Location = new Point(0, 0);
            bHButton2.Location = new Point(0, 51);
            bHButton3.Location = new Point(0, 102);
            bHButton4.Location = new Point(0, 153);

            bHButton1.Click += (s, e) =>
            {
                AppContext._playbackService.SetPlaybackMode(PlaybackMode.Sequential);
                // 通知 UI 更改
                RaiseClose();
                AppContext.TriggerPlaybackModeChanged(PlaybackMode.Sequential);
            };

            bHButton2.Click += (s, e) =>
            {
                AppContext._playbackService.SetPlaybackMode(PlaybackMode.RepeatOne);
                RaiseClose();
                AppContext.TriggerPlaybackModeChanged(PlaybackMode.RepeatOne);
            };


            bHButton3.Click += (s, e) =>
            {
                AppContext._playbackService.SetPlaybackMode(PlaybackMode.ListLooping);
                RaiseClose();
                AppContext.TriggerPlaybackModeChanged(PlaybackMode.ListLooping);
            };


            bHButton4.Click += (s, e) =>
            {
                AppContext._playbackService.SetPlaybackMode(PlaybackMode.Shuffle);
                RaiseClose();
                AppContext.TriggerPlaybackModeChanged(PlaybackMode.Shuffle);
            };



            this.Controls.Add(bHButton1);
            this.Controls.Add(bHButton2);
            this.Controls.Add(bHButton3);
            this.Controls.Add(bHButton4);
        }
    }
}
