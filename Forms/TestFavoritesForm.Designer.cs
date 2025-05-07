namespace Byte_Harmonic.Forms
{
    partial class TestFavoritesService
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.listBoxResults = new System.Windows.Forms.ListBox();
            this.btnRunTests = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxResults
            // 
            this.listBoxResults.FormattingEnabled = true;
            this.listBoxResults.ItemHeight = 15;
            this.listBoxResults.Location = new System.Drawing.Point(12, 12);
            this.listBoxResults.Name = "listBoxResults";
            this.listBoxResults.Size = new System.Drawing.Size(560, 379);
            this.listBoxResults.TabIndex = 0;
            // 
            // btnRunTests
            // 
            this.btnRunTests.Location = new System.Drawing.Point(12, 406);
            this.btnRunTests.Name = "btnRunTests";
            this.btnRunTests.Size = new System.Drawing.Size(560, 37);
            this.btnRunTests.TabIndex = 1;
            this.btnRunTests.Text = "运行测试";
            this.btnRunTests.UseVisualStyleBackColor = true;
            this.btnRunTests.Click += new System.EventHandler(this.btnRunTests_Click);
            // 
            // TestFavoritesServiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 455);
            this.Controls.Add(this.btnRunTests);
            this.Controls.Add(this.listBoxResults);
            this.Name = "TestFavoritesServiceForm";
            this.Text = "测试收藏服务";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxResults;
        private System.Windows.Forms.Button btnRunTests;
    }
}