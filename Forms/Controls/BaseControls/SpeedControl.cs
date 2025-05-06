using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Byte_Harmonic.Forms.Controls.BaseControls
{
    public partial class SpeedControl : UserControl
    {
        public SpeedControl(Point ButtonLocation, double speed_rate)
        {
            InitializeComponent();
            uiTrackBar1.Value = (int)((speed_rate - 0.75) * 100);
            this.Location = new Point(ButtonLocation.X - 25, ButtonLocation.Y - 150);
            uiTrackBar1.ValueChanged += UiTrackBar1_ValueChanged;
        }

        private void UiTrackBar1_ValueChanged(object sender, EventArgs e)
        {
            // 向外触发 VolumeControl 的 VolumeChanged 事件更新 UI
            AppContext._playbackService.SetPlaybackSpeed(0.75f + ((float)uiTrackBar1.Value / 100));
        }

    }
}
