using Byte_Harmonic.Forms.FormUtils;
using Sunny.UI;

namespace Byte_Harmonic.Forms.Controls.BaseControls
{
    partial class VolumeControl
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
            uiTrackBar1 = new UITrackBar();
            SuspendLayout();
            // 
            // uiTrackBar1
            // 
            uiTrackBar1.Direction = UITrackBar.BarDirection.Vertical;
            uiTrackBar1.FillColor = MPColor.Grey1;
            uiTrackBar1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiTrackBar1.ForeColor = MPColor.Blue2;
            uiTrackBar1.Location = new Point(0, 0);
            uiTrackBar1.MinimumSize = new Size(1, 1);
            uiTrackBar1.Name = "uiTrackBar1";
            uiTrackBar1.Radius = 10;
            uiTrackBar1.RectColor = MPColor.Blue3;
            uiTrackBar1.Size = new Size(40, 120);
            uiTrackBar1.TabIndex = 0;
            uiTrackBar1.Text = "uiTrackBar1";
            uiTrackBar1.Value = 50;
            // 
            // VolumeControl
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.Transparent;
            Controls.Add(uiTrackBar1);
            Name = "VolumeControl";
            Size = new Size(42, 122);
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UITrackBar uiTrackBar1;
    }
}
