namespace Byte_Harmonic.Forms.Controls.FrameControls.MainPanel
{
    partial class SearchResult
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

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            uiLabel5 = new Sunny.UI.UILabel();
            uiCheckBox1 = new Sunny.UI.UICheckBox();
            uiCheckBox2 = new Sunny.UI.UICheckBox();
            uiCheckBox3 = new Sunny.UI.UICheckBox();
            uiCheckBox4 = new Sunny.UI.UICheckBox();
            uiCheckBox5 = new Sunny.UI.UICheckBox();
            uiCheckBox6 = new Sunny.UI.UICheckBox();
            checkPanel = new Panel();
            checkPanel.SuspendLayout();
            SuspendLayout();
            // 
            // uiLabel5
            // 
            uiLabel5.Font = new Font("黑体", 18F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLabel5.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel5.Location = new Point(18, 10);
            uiLabel5.Name = "uiLabel5";
            uiLabel5.Size = new Size(128, 23);
            uiLabel5.TabIndex = 33;
            uiLabel5.Text = "搜索结果";
            // 
            // uiCheckBox1
            // 
            uiCheckBox1.CheckBoxColor = Color.FromArgb(166, 215, 231);
            uiCheckBox1.Font = new Font("黑体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiCheckBox1.ForeColor = Color.FromArgb(48, 48, 48);
            uiCheckBox1.Location = new Point(0, 3);
            uiCheckBox1.MinimumSize = new Size(1, 1);
            uiCheckBox1.Name = "uiCheckBox1";
            uiCheckBox1.Size = new Size(64, 29);
            uiCheckBox1.TabIndex = 35;
            uiCheckBox1.Text = "动感";
            // 
            // uiCheckBox2
            // 
            uiCheckBox2.CheckBoxColor = Color.FromArgb(166, 215, 231);
            uiCheckBox2.Font = new Font("黑体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiCheckBox2.ForeColor = Color.FromArgb(48, 48, 48);
            uiCheckBox2.Location = new Point(70, 3);
            uiCheckBox2.MinimumSize = new Size(1, 1);
            uiCheckBox2.Name = "uiCheckBox2";
            uiCheckBox2.Size = new Size(64, 29);
            uiCheckBox2.TabIndex = 36;
            uiCheckBox2.Text = "抒情";
            // 
            // uiCheckBox3
            // 
            uiCheckBox3.CheckBoxColor = Color.FromArgb(166, 215, 231);
            uiCheckBox3.Font = new Font("黑体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiCheckBox3.ForeColor = Color.FromArgb(48, 48, 48);
            uiCheckBox3.Location = new Point(140, 3);
            uiCheckBox3.MinimumSize = new Size(1, 1);
            uiCheckBox3.Name = "uiCheckBox3";
            uiCheckBox3.Size = new Size(64, 29);
            uiCheckBox3.TabIndex = 37;
            uiCheckBox3.Text = "浪漫";
            // 
            // uiCheckBox4
            // 
            uiCheckBox4.CheckBoxColor = Color.FromArgb(166, 215, 231);
            uiCheckBox4.Font = new Font("黑体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiCheckBox4.ForeColor = Color.FromArgb(48, 48, 48);
            uiCheckBox4.Location = new Point(210, 3);
            uiCheckBox4.MinimumSize = new Size(1, 1);
            uiCheckBox4.Name = "uiCheckBox4";
            uiCheckBox4.Size = new Size(64, 29);
            uiCheckBox4.TabIndex = 38;
            uiCheckBox4.Text = "电子";
            // 
            // uiCheckBox5
            // 
            uiCheckBox5.CheckBoxColor = Color.FromArgb(166, 215, 231);
            uiCheckBox5.Font = new Font("黑体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiCheckBox5.ForeColor = Color.FromArgb(48, 48, 48);
            uiCheckBox5.Location = new Point(280, 3);
            uiCheckBox5.MinimumSize = new Size(1, 1);
            uiCheckBox5.Name = "uiCheckBox5";
            uiCheckBox5.Size = new Size(64, 29);
            uiCheckBox5.TabIndex = 39;
            uiCheckBox5.Text = "古风";
            // 
            // uiCheckBox6
            // 
            uiCheckBox6.CheckBoxColor = Color.FromArgb(166, 215, 231);
            uiCheckBox6.Font = new Font("黑体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiCheckBox6.ForeColor = Color.FromArgb(48, 48, 48);
            uiCheckBox6.Location = new Point(350, 3);
            uiCheckBox6.MinimumSize = new Size(1, 1);
            uiCheckBox6.Name = "uiCheckBox6";
            uiCheckBox6.Size = new Size(64, 29);
            uiCheckBox6.TabIndex = 40;
            uiCheckBox6.Text = "摇滚";
            // 
            // checkPanel
            // 
            checkPanel.Controls.Add(uiCheckBox1);
            checkPanel.Controls.Add(uiCheckBox6);
            checkPanel.Controls.Add(uiCheckBox2);
            checkPanel.Controls.Add(uiCheckBox5);
            checkPanel.Controls.Add(uiCheckBox3);
            checkPanel.Controls.Add(uiCheckBox4);
            checkPanel.Location = new Point(20, 50);
            checkPanel.Name = "checkPanel";
            checkPanel.Size = new Size(434, 45);
            checkPanel.TabIndex = 41;
            // 
            // SearchResult
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(checkPanel);
            Controls.Add(uiLabel5);
            Name = "SearchResult";
            Size = new Size(824, 512);
            checkPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UILabel uiLabel5;
        private Sunny.UI.UICheckBox uiCheckBox1;
        private Sunny.UI.UICheckBox uiCheckBox2;
        private Sunny.UI.UICheckBox uiCheckBox3;
        private Sunny.UI.UICheckBox uiCheckBox4;
        private Sunny.UI.UICheckBox uiCheckBox5;
        private Sunny.UI.UICheckBox uiCheckBox6;
        private Panel checkPanel;
    }
}
