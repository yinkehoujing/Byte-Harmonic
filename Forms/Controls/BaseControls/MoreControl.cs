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
using Byte_Harmonic.Models;

namespace Byte_Harmonic.Forms.Controls.BaseControls
{
    public partial class MoreControl : UserControl
    {
        private BHButton bHButton1;
        private BHButton bHButton2;
        public MoreControl(Point ButtonLocation)
        {
            InitializeComponent();
            InitializeButton();
            this.Location = new Point(ButtonLocation.X - 60, ButtonLocation.Y - 110);
        }
        public void InitializeButton()
        {
            bHButton1 = new BHButton("icons8-scroll-down-96", "icons8-scroll-down-96 (1)", "下载");
            bHButton2 = new BHButton("icons8-圆-96 (2)", "icons8-圆-96 (1)", "添加到");
            bHButton1.Location = new Point(0, 0);
            bHButton2.Location = new Point(0, 51);
            this.Controls.Add(bHButton1);
            this.Controls.Add(bHButton2);

            bHButton2.Click += bHButton2_Click;
        }

        private void bHButton2_Click (object sender, EventArgs e)
        {
            try
            {
                Song song = AppContext._playbackService.GetCurrentSong();
                if (song == null)
                    throw new Exception("当前没有歌曲");

                new Byte_Harmonic.Forms.MainForms.AddSongToListForm(song).ShowDialog();
            }
            catch (Exception ex)
            {
                new Byte_Harmonic.Forms.MainForms.MessageForm(ex.Message).ShowDialog();
            }
            
        }
    }
}
