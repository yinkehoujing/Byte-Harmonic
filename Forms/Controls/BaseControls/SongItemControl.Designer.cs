using System.Xml.Linq;

namespace Byte_Harmonic.Forms.Controls.BaseControls
{
    partial class SongItemControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UIImageButton playButton;

        private void InitializeComponent()
        {
            uiLabel1 = new Sunny.UI.UILabel();
            playButton = new Sunny.UI.UIImageButton();
            ((System.ComponentModel.ISupportInitialize)playButton).BeginInit();
            SuspendLayout();
            // 
            // uiLabel1
            // 
            uiLabel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            uiLabel1.Font = new Font("黑体", 12F);
            uiLabel1.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel1.Location = new Point(20, 12);
            uiLabel1.Margin = new Padding(4, 0, 4, 0);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new Size(236, 31);
            uiLabel1.TabIndex = 1;
            uiLabel1.Text = "长长歌曲名——长长歌手";
            // 
            // playButton
            // 
            playButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            playButton.BackColor = Color.White;
            playButton.Cursor = Cursors.Hand;
            playButton.Font = new Font("宋体", 12F);
            playButton.Image = Properties.Resources.icons8_播放_961;
            playButton.ImageHover = Properties.Resources.icons8_播放_96__1_1;
            playButton.Location = new Point(397, 12);
            playButton.Margin = new Padding(4);
            playButton.Name = "playButton";
            playButton.Size = new Size(31, 28);
            playButton.SizeMode = PictureBoxSizeMode.StretchImage;
            playButton.TabIndex = 4;
            playButton.TabStop = false;
            playButton.Text = null;
            playButton.ZoomScaleDisabled = true;
            playButton.Click += playButton_Click;
            // 
            // SongItemControl
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(playButton);
            Controls.Add(uiLabel1);
            Margin = new Padding(4);
            MaximumSize = new Size(445, 53);
            Name = "SongItemControl";
            Size = new Size(445, 53);
            ((System.ComponentModel.ISupportInitialize)playButton).EndInit();
            ResumeLayout(false);
        }
    }

    #endregion
}
