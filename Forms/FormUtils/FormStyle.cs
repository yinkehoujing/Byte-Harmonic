using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Byte_Harmonic.Forms.FormUtils
{
    /// <summary>
    ///通用更改窗口样式
    /// </summary>
    class FormStyle
    {
        private readonly Form _targetForm;//目标窗体

        public FormStyle(Form form)
        {
            _targetForm = form;
            ShadowForm();
        }

        /// <summary>
        /// 设置边框与阴影
        /// </summary>
        [DllImport("dwmapi.dll")]
        private static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);

        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        private struct MARGINS
        {
            public int leftWidth;
            public int rightWidth;
            public int topHeight;
            public int bottomHeight;
        }

        public void ShadowForm()
        {
            _targetForm.Padding = new Padding(10); // 阴影区域大小

            //启用现代窗口阴影（Win10+）
            if (Environment.OSVersion.Version.Major >= 6)
            {
                int attrValue = 2; //DWMWCP_ROUND
                DwmSetWindowAttribute(_targetForm.Handle, 33 /*DWMWA_WINDOW_CORNER_PREFERENCE*/, ref attrValue, sizeof(int));

                var margins = new MARGINS()
                {
                    leftWidth = 1,
                    rightWidth = 1,
                    topHeight = 1,
                    bottomHeight = 1
                };
                DwmExtendFrameIntoClientArea(_targetForm.Handle, ref margins);
            }
        }

        /// <summary>
        /// 设置picturebox的圆角
        /// </summary>
        /// <param name="picBox"></param>
        /// <param name="cornerRadius"></param>
        public void SetPictureBoxRoundCorners(PictureBox picBox, int cornerRadius)
        {
            Rectangle bounds = new Rectangle(0, 0, picBox.Width, picBox.Height);
            GraphicsPath path = new GraphicsPath();

            int diameter = cornerRadius * 2;
            path.StartFigure();
            path.AddArc(bounds.X, bounds.Y, diameter, diameter, 180, 90); // 左上角
            path.AddArc(bounds.Right - diameter, bounds.Y, diameter, diameter, 270, 90); // 右上角
            path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90); // 右下角
            path.AddArc(bounds.X, bounds.Bottom - diameter, diameter, diameter, 90, 90); // 左下角
            path.CloseFigure();

            picBox.Region = new Region(path);
        }
    }
}
