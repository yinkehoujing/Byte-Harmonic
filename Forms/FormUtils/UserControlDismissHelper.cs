using Byte_Harmonic.Forms.Controls.BaseControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byte_Harmonic.Forms.FormUtils
{
    public static class UserControlDismissHelper
    {
        public static void AttachDismissOnClickOutside(this UserControl control, ExploreForm parentContainer)
        {
            if (control == null || parentContainer == null) return;

            // 记录点击是否发生在目标控件内
            bool clickedInside = false;

            // 处理目标控件的鼠标事件
            control.MouseDown += (s, e) => clickedInside = true;
            control.MouseLeave += (s, e) => clickedInside = false;

            // 处理父容器的点击事件
            void ParentMouseClickHandler(object sender, MouseEventArgs e)
            {
                if (!clickedInside && !IsChildControlClicked(control, e.Location))
                {
                    parentContainer.Controls.Remove(control);
                    parentContainer.MouseClick -= ParentMouseClickHandler;
                    control.Dispose();
                    parentContainer.moreControl = null;
                }
                clickedInside = false;
            }

            parentContainer.MouseClick += ParentMouseClickHandler;
        }

        private static bool IsChildControlClicked(Control control, Point clickLocation)
        {
            // 检查点击位置是否在控件的任何子控件内
            foreach (Control child in control.Controls)
            {
                if (child.Bounds.Contains(child.PointToClient(clickLocation)))
                    return true;
            }
            return false;
        }
    }
}
