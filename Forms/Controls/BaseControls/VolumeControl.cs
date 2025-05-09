using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Byte_Harmonic.Forms.FormUtils;
using Byte_Harmonic.Forms.MainForms;

namespace Byte_Harmonic.Forms.Controls.BaseControls
{
    public partial class VolumeControl : UserControl
    {
        public VolumeControl(Point ButtonLocation, int initial_volume)
        {
            InitializeComponent();
            uiTrackBar1.Value = initial_volume;
            Console.WriteLine($"init value {initial_volume}");
            this.Location = new Point(ButtonLocation.X-10, ButtonLocation.Y-125);

            // 监听子控件事件(自己的改变）
            uiTrackBar1.ValueChanged += UiTrackBar1_ValueChanged;

        }

        private void UiTrackBar1_ValueChanged(object sender, EventArgs e)
        {
            // 向外触发 VolumeControl 的 VolumeChanged 事件更新 UI
            Console.WriteLine("UiTrackBar1_ValueChanged to, then volume is changed ");
            if(AppContext._playbackService.audioFileReader == null)
            {
                new MainForms.MessageForm("请先播放一首歌曲再调整音量！").ShowDialog();
                return;
            }
            AppContext._playbackService.SetVolume((float)uiTrackBar1.Value / 100);
        }

        private void uiLabel1_Click(object sender, EventArgs e)
        {

        }


    }
}
