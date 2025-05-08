// CreateSongListForm.Designer.cs
using Sunny.UI;

namespace Byte_Harmonic.Forms
{
    partial class CreateSongListForm
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
            lblTitle = new UILabel();
            txtName = new UITextBox();
            btnConfirm = new UIButton();
            lblError = new UILabel();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("微软雅黑", 12F);
            lblTitle.ForeColor = Color.FromArgb(48, 48, 48);
            lblTitle.Location = new Point(33, 61);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(100, 23);
            lblTitle.Style = UIStyle.Custom;
            lblTitle.TabIndex = 0;
            lblTitle.Text = "名称：";
            // 
            // txtName
            // 
            txtName.ButtonSymbolOffset = new Point(0, 0);
            txtName.Cursor = Cursors.IBeam;
            txtName.Font = new Font("微软雅黑", 12F);
            txtName.Location = new Point(103, 61);
            txtName.Margin = new Padding(4, 5, 4, 5);
            txtName.MinimumSize = new Size(1, 1);
            txtName.Name = "txtName";
            txtName.Padding = new Padding(5);
            txtName.ShowText = false;
            txtName.Size = new Size(200, 29);
            txtName.Style = UIStyle.Custom;
            txtName.TabIndex = 1;
            txtName.TextAlignment = ContentAlignment.MiddleLeft;
            txtName.Watermark = "";
            // 
            // btnConfirm
            // 
            btnConfirm.Cursor = Cursors.Hand;
            btnConfirm.Font = new Font("微软雅黑", 12F);
            btnConfirm.Location = new Point(115, 157);
            btnConfirm.MinimumSize = new Size(1, 1);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(100, 35);
            btnConfirm.TabIndex = 2;
            btnConfirm.Text = "确认";
            btnConfirm.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnConfirm.Click += btnConfirm_Click;
            // 
            // lblError
            // 
            lblError.Font = new Font("微软雅黑", 10F);
            lblError.ForeColor = Color.FromArgb(48, 48, 48);
            lblError.Location = new Point(33, 113);
            lblError.Name = "lblError";
            lblError.Size = new Size(270, 23);
            lblError.Style = UIStyle.Custom;
            lblError.TabIndex = 3;
            lblError.TextAlign = ContentAlignment.MiddleLeft;
            lblError.Visible = false;
            // 
            // CreateSongListForm
            // 
            AcceptButton = btnConfirm;
            ClientSize = new Size(340, 224);
            Controls.Add(lblError);
            Controls.Add(btnConfirm);
            Controls.Add(txtName);
            Controls.Add(lblTitle);
            MaximizeBox = false;
            Name = "CreateSongListForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "新建歌单";
            ZoomScaleRect = new Rectangle(15, 15, 340, 120);
            ResumeLayout(false);
        }

        #endregion

        private UILabel lblTitle;
        private UITextBox txtName;
        private UIButton btnConfirm;
        private UILabel lblError;
    }
}