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
            this.lyricsLabel = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lyricsLabel
            // 
            this.lyricsLabel.AutoSize = true;
            this.lyricsLabel.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.lyricsLabel.Location = new System.Drawing.Point(30, 50);
            this.lyricsLabel.Name = "lyricsLabel";
            this.lyricsLabel.Size = new System.Drawing.Size(100, 30);
            this.lyricsLabel.TabIndex = 0;
            this.lyricsLabel.Text = "歌词同步";
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(30, 150);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(120, 40);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "停止播放";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // TestLyricsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 250);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.lyricsLabel);
            this.Name = "TestLyricsForm";
            this.Text = "歌词同步测试";
            this.Load += new System.EventHandler(this.TestLyricsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
