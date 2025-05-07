using Byte_Harmonic.Forms.FormUtils;

namespace Byte_Harmonic.Forms.Controls.BaseControls
{
    partial class SpeedControl
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
            uiTrackBar1 = new Sunny.UI.UITrackBar();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // uiTrackBar1
            // 
            uiTrackBar1.Direction = Sunny.UI.UITrackBar.BarDirection.Vertical;
            uiTrackBar1.FillColor = Color.FromArgb(250, 250, 250);
            uiTrackBar1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiTrackBar1.ForeColor = Color.FromArgb(177, 229, 242);
            uiTrackBar1.Location = new Point(0, 6);
            uiTrackBar1.MinimumSize = new Size(1, 1);
            uiTrackBar1.Name = "uiTrackBar1";
            uiTrackBar1.Radius = 10;
            uiTrackBar1.RectColor = Color.FromArgb(166, 215, 231);
            uiTrackBar1.Size = new Size(40, 120);
            uiTrackBar1.TabIndex = 1;
            uiTrackBar1.Text = "uiTrackBar1";
            uiTrackBar1.Value = 25;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("黑体", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 134);
            label1.Location = new Point(40, 15);
            label1.Name = "label1";
            label1.Size = new Size(31, 14);
            label1.TabIndex = 2;
            label1.Text = "1.5";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("黑体", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 134);
            label2.Location = new Point(40, 49);
            label2.Name = "label2";
            label2.Size = new Size(39, 14);
            label2.TabIndex = 3;
            label2.Text = "1.25";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("黑体", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 134);
            label3.Location = new Point(40, 83);
            label3.Name = "label3";
            label3.Size = new Size(31, 14);
            label3.TabIndex = 4;
            label3.Text = "1.0";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("黑体", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 134);
            label4.Location = new Point(40, 112);
            label4.Name = "label4";
            label4.Size = new Size(39, 14);
            label4.TabIndex = 5;
            label4.Text = "0.75";
            // 
            // SpeedControl
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(250, 250, 250);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(uiTrackBar1);
            Name = "SpeedControl";
            Size = new Size(92, 136);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Sunny.UI.UITrackBar uiTrackBar1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}
