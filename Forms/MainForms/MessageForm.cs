using Sunny.UI;
using System.Drawing;
using System.Windows.Forms;

namespace Byte_Harmonic.Forms.MainForms
{
    public partial class MessageForm : UIForm
    {
        //构造函数
        public MessageForm(string message)
        {
            InitializeComponent();
            InitializeMessage(message);
        }

        //显示消息
        private void InitializeMessage(string message)
        {
            lblMessage.Text = message;
            lblMessage.TextAlign = ContentAlignment.MiddleCenter;
            lblMessage.AutoSize = false;
            lblMessage.Dock = DockStyle.Fill;
        }

        //点击确认
        private void btnConfirm_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
