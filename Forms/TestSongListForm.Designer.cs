namespace Byte_Harmonic.Forms
{
    partial class TestSongListForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.listBoxResults = new System.Windows.Forms.ListBox();
            this.btnRunTests = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxResults
            // 
            this.listBoxResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.listBoxResults.FormattingEnabled = true;
            this.listBoxResults.ItemHeight = 15;
            this.listBoxResults.Location = new System.Drawing.Point(12, 12);
            this.listBoxResults.Name = "listBoxResults";
            this.listBoxResults.Size = new System.Drawing.Size(560, 409);
            this.listBoxResults.TabIndex = 0;
            // 
            // btnRunTests
            // 
            this.btnRunTests.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRunTests.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnRunTests.Location = new System.Drawing.Point(12, 430);
            this.btnRunTests.Name = "btnRunTests";
            this.btnRunTests.Size = new System.Drawing.Size(560, 40);
            this.btnRunTests.TabIndex = 1;
            this.btnRunTests.Text = "执行曲库管理测试";
            this.btnRunTests.UseVisualStyleBackColor = true;
            this.btnRunTests.Click += new System.EventHandler(this.btnRunTests_Click);
            // 
            // TestSongListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 482);
            this.Controls.Add(this.btnRunTests);
            this.Controls.Add(this.listBoxResults);
            this.MinimumSize = new System.Drawing.Size(600, 520);
            this.Name = "TestSongListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "曲库管理功能测试";
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.ListBox listBoxResults;
        private System.Windows.Forms.Button btnRunTests;
    }
}