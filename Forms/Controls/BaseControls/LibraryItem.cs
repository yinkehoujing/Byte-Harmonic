using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sunny.UI;
using System.Security.Policy;

namespace Byte_Harmonic.Forms.MainForms
{
    public partial class LibraryItem : UserControl
    {
        private Color color;//背景色
        public int ID;//ID
        private string Name;//名
        public bool Selected//被选
        {
            get => uiCheckBox.Checked;
        }
        public LibraryItem(Color color, int _ID, string _Name)
        {
            InitializeComponent();
            this.color = color;
            this.ID = _ID;
            this.Name = _Name;
            this.BackColor = color;
            uiLabel1.Text = Name;
        }

        private void viewButton_Click(object sender, EventArgs e)
        {
            //更改视图
            Byte_Harmonic.Forms.MainForms.AddSongToListForm addForm = this.FindForm() as AddSongToListForm;
            if (addForm != null)
            {
                addForm.changeToSongView(ID, Name);
            }
        }

        public void ChangetoSongStyle()
        {
            this.uiCheckBox.Visible = false;
            this.uiCheckBox.ReadOnly = true;
            this.viewButton.Visible = false;
            this.viewButton.Enabled = false;
        }
    }
}
