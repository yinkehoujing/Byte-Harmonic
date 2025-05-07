using Sunny.UI;

namespace Byte_Harmonic.Forms.MainForms
{
    partial class MessageForm
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
            this.lblMessage = new Sunny.UI.UILabel();
            this.btnConfirm = new Sunny.UI.UIButton();
            this.SuspendLayout();

            // lblMessage
            this.lblMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMessage.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.lblMessage.Location = new System.Drawing.Point(10, 10);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Padding = new System.Windows.Forms.Padding(10);
            this.lblMessage.Size = new System.Drawing.Size(280, 100);

            // 正确设置文本对齐和换行
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter; // 对齐方式
            this.lblMessage.AutoSize = false;        // 禁用自动尺寸
            //this.lblMessage.WordWrap = true;         // 启用自动换行（SunnyUI特有属性）

            // btnConfirm
            this.btnConfirm.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnConfirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirm.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnConfirm.Location = new System.Drawing.Point(105, 150);
            this.btnConfirm.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(90, 35);
            this.btnConfirm.Text = "确认";
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);

            // MessageForm
            this.ClientSize = new System.Drawing.Size(300, 200);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.lblMessage);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MessageForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "提示";
            this.ResumeLayout(false);
        }

        #endregion

        private UILabel lblMessage;
        private UIButton btnConfirm;
    }
}