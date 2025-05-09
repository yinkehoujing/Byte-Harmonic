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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateSongListForm));
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
            lblTitle.Location = new Point(33, 81);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(100, 23);
            lblTitle.Style = UIStyle.Custom;
            lblTitle.TabIndex = 0;
            lblTitle.Text = "名称：";
            // 
            // txtName
            // 
            txtName.ButtonRectColor = Color.FromArgb(166, 215, 231);
            txtName.ButtonStyleInherited = false;
            txtName.ButtonSymbolOffset = new Point(0, 0);
            txtName.Cursor = Cursors.IBeam;
            txtName.FillColor = Color.WhiteSmoke;
            txtName.FillColor2 = Color.White;
            txtName.Font = new Font("微软雅黑", 12F);
            txtName.Location = new Point(103, 81);
            txtName.Margin = new Padding(4, 5, 4, 5);
            txtName.MinimumSize = new Size(1, 1);
            txtName.Name = "txtName";
            txtName.Padding = new Padding(5);
            txtName.RectColor = Color.Black;
            txtName.ScrollBarColor = Color.Silver;
            txtName.ScrollBarStyleInherited = false;
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
            btnConfirm.FillColor = Color.FromArgb(163, 199, 224);
            btnConfirm.FillHoverColor = Color.FromArgb(166, 215, 231);
            btnConfirm.FillPressColor = Color.FromArgb(166, 215, 231);
            btnConfirm.FillSelectedColor = Color.FromArgb(166, 215, 231);
            btnConfirm.Font = new Font("黑体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnConfirm.Location = new Point(118, 162);
            btnConfirm.MinimumSize = new Size(1, 1);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.RectColor = Color.FromArgb(163, 199, 224);
            btnConfirm.Size = new Size(100, 35);
            btnConfirm.TabIndex = 2;
            btnConfirm.Text = "确认";
            btnConfirm.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnConfirm.Click += btnConfirm_Click;
            // 
            // lblError
            // 
            lblError.Font = new Font("黑体", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 134);
            lblError.ForeColor = Color.Black;
            lblError.Location = new Point(33, 125);
            lblError.Name = "lblError";
            lblError.Size = new Size(282, 23);
            lblError.Style = UIStyle.Custom;
            lblError.TabIndex = 3;
            lblError.TextAlign = ContentAlignment.MiddleCenter;
            lblError.Visible = false;
            // 
            // CreateSongListForm
            // 
            AcceptButton = btnConfirm;
            BackColor = Color.White;
            ClientSize = new Size(340, 204);
            Controls.Add(lblError);
            Controls.Add(btnConfirm);
            Controls.Add(txtName);
            Controls.Add(lblTitle);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "CreateSongListForm";
            RectColor = Color.Black;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "新建歌单";
            TitleColor = Color.FromArgb(163, 199, 224);
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