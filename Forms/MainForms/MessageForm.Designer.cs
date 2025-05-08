using Byte_Harmonic.Forms.FormUtils;
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
            lblMessage = new UILabel();
            btnConfirm = new UIButton();
            SuspendLayout();
            // 
            // lblMessage
            // 
            lblMessage.BackColor = Color.White;
            lblMessage.Font = new Font("黑体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            lblMessage.ForeColor = Color.FromArgb(48, 48, 48);
            lblMessage.Location = new Point(0, 35);
            lblMessage.Name = "lblMessage";
            lblMessage.Padding = new Padding(10);
            lblMessage.Size = new Size(300, 167);
            lblMessage.TabIndex = 1;
            lblMessage.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnConfirm
            // 
            btnConfirm.Anchor = AnchorStyles.Bottom;
            btnConfirm.Cursor = Cursors.Hand;
            btnConfirm.FillColor = Color.FromArgb(166, 215, 231);
            btnConfirm.FillHoverColor = MPColor.Blue4;
            btnConfirm.FillPressColor = MPColor.Blue4;
            btnConfirm.Font = new Font("黑体", 12F);
            btnConfirm.Location = new Point(105, 150);
            btnConfirm.MinimumSize = new Size(1, 1);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.RectColor = Color.FromArgb(166, 215, 231);
            btnConfirm.Size = new Size(90, 35);
            btnConfirm.TabIndex = 0;
            btnConfirm.Text = "确认";
            btnConfirm.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnConfirm.Click += btnConfirm_Click;
            // 
            // MessageForm
            // 
            BackColor = Color.White;
            ClientSize = new Size(300, 200);
            ControlBoxFillHoverColor = Color.White;
            Controls.Add(btnConfirm);
            Controls.Add(lblMessage);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MessageForm";
            Padding = new Padding(10);
            RectColor = Color.Black;
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "提示";
            TitleColor = MPColor.Blue3;
            ZoomScaleRect = new Rectangle(15, 15, 300, 200);
            ResumeLayout(false);
        }

        #endregion

        private UILabel lblMessage;
        private UIButton btnConfirm;
    }
}