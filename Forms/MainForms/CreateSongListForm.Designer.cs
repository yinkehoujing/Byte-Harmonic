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
            this.lblTitle = new Sunny.UI.UILabel();
            this.txtName = new Sunny.UI.UITextBox();
            this.btnConfirm = new Sunny.UI.UIButton();
            this.lblError = new Sunny.UI.UILabel();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(100, 23);
            this.lblTitle.Style = Sunny.UI.UIStyle.Blue;
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "名称：";
            // 
            // txtName
            // 
            this.txtName.ButtonSymbolOffset = new System.Drawing.Point(0, 0);
            this.txtName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtName.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.txtName.Location = new System.Drawing.Point(90, 17);
            this.txtName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtName.Maximum = 2147483647D;
            this.txtName.Minimum = -2147483648D;
            this.txtName.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtName.Name = "txtName";
            this.txtName.ShowText = false;
            this.txtName.Size = new System.Drawing.Size(200, 29);
            this.txtName.Style = Sunny.UI.UIStyle.Blue;
            this.txtName.TabIndex = 1;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirm.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnConfirm.Location = new System.Drawing.Point(215, 70);
            this.btnConfirm.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(100, 35);
            this.btnConfirm.TabIndex = 2;
            this.btnConfirm.Text = "确认";
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // lblError
            // 
            this.lblError.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(20, 50);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(270, 23);
            this.lblError.Style = Sunny.UI.UIStyle.Blue;
            this.lblError.TabIndex = 3;
            this.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblError.Visible = false;
            // 
            // CreateSongListForm
            // 
            this.AcceptButton = this.btnConfirm;
            this.ClientSize = new System.Drawing.Size(340, 120);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblTitle);
            this.MaximizeBox = false;
            this.MinimizeBox = true;
            this.Name = "CreateSongListForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "新建歌单";
            this.ResumeLayout(false);
        }

        #endregion

        private UILabel lblTitle;
        private UITextBox txtName;
        private UIButton btnConfirm;
        private UILabel lblError;
    }
}