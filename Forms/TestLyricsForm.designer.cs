namespace ByteHarmonic.Forms
{
    partial class TestLyricsForm:Form
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lyricsLabel;
        private System.Windows.Forms.Button btnStop;

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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            lyricsLabel = new Label();
            btnStop = new Button();
            seekToBtn = new Button();
            uiipTextBox1 = new TextBox();
            SuspendLayout();
            // 
            // lyricsLabel
            // 
            lyricsLabel.AutoSize = true;
            lyricsLabel.Font = new Font("微软雅黑", 16F);
            lyricsLabel.Location = new Point(34, 50);
            lyricsLabel.Name = "lyricsLabel";
            lyricsLabel.Size = new Size(123, 35);
            lyricsLabel.TabIndex = 0;
            lyricsLabel.Text = "歌词同步";
            // 
            // btnStop
            // 
            btnStop.Location = new Point(34, 150);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(135, 40);
            btnStop.TabIndex = 1;
            btnStop.Text = "播放/暂停";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // seekToBtn
            // 
            seekToBtn.Location = new Point(290, 139);
            seekToBtn.Name = "seekToBtn";
            seekToBtn.Size = new Size(94, 29);
            seekToBtn.TabIndex = 2;
            seekToBtn.Text = "跳转";
            seekToBtn.UseVisualStyleBackColor = true;
            seekToBtn.Click += seekToBtn_Click;
            // 
            // uiipTextBox1
            // 
            uiipTextBox1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiipTextBox1.Location = new Point(281, 67);
            uiipTextBox1.Margin = new Padding(4, 5, 4, 5);
            uiipTextBox1.MinimumSize = new Size(1, 1);
            uiipTextBox1.Name = "uiipTextBox1";
            uiipTextBox1.Padding = new Padding(1);
            uiipTextBox1.Size = new Size(123, 37);
            uiipTextBox1.TabIndex = 3;
            uiipTextBox1.Click += UiipTextBox1_Click;
            // 
            // TestLyricsForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(450, 250);
            Controls.Add(uiipTextBox1);
            Controls.Add(seekToBtn);
            Controls.Add(btnStop);
            Controls.Add(lyricsLabel);
            Name = "TestLyricsForm";
            Text = "歌词同步测试";
            Load += TestLyricsForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private void UiipTextBox1_Click(object sender, EventArgs e)
        {
        }

        #endregion

        private Button seekToBtn;
        private TextBox uiipTextBox1;
    }
}
