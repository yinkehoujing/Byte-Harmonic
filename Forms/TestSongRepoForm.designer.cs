namespace Byte_Harmonic.Forms
{
    partial class TestSongRepoForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnRunTests;
        private System.Windows.Forms.ListBox listBoxResults;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnRunTests = new System.Windows.Forms.Button();
            this.listBoxResults = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnRunTests
            // 
            this.btnRunTests.Location = new System.Drawing.Point(12, 12);
            this.btnRunTests.Name = "btnRunTests";
            this.btnRunTests.Size = new System.Drawing.Size(120, 30);
            this.btnRunTests.TabIndex = 0;
            this.btnRunTests.Text = "运行所有测试";
            this.btnRunTests.UseVisualStyleBackColor = true;
            this.btnRunTests.Click += new System.EventHandler(this.btnRunTests_Click);
            // 
            // listBoxResults
            // 
            this.listBoxResults.FormattingEnabled = true;
            this.listBoxResults.ItemHeight = 15;
            this.listBoxResults.Location = new System.Drawing.Point(12, 60);
            this.listBoxResults.Name = "listBoxResults";
            this.listBoxResults.Size = new System.Drawing.Size(360, 200);
            this.listBoxResults.TabIndex = 1;
            // 
            // TestForm
            // 
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.Controls.Add(this.btnRunTests);
            this.Controls.Add(this.listBoxResults);
            this.Name = "TestForm";
            this.Text = "测试 - SongRepository";
            this.ResumeLayout(false);
        }
    }
}
