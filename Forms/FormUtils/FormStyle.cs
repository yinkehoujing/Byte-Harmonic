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
        ///设置圆角 
        /// </summary>
        public void SetWindowRegion()
        {
            System.Drawing.Drawing2D.GraphicsPath FormPath;
            FormPath = new System.Drawing.Drawing2D.GraphicsPath();
            Rectangle rect = new Rectangle(0, 0, _targetForm.Width, _targetForm.Height);
            FormPath = GetRoundedRectPath(rect, 20);
            _targetForm.Region = new Region(FormPath);

        }
        private GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {
            int diameter = radius;
            Rectangle arcRect = new Rectangle(rect.Location, new Size(diameter, diameter));
            GraphicsPath path = new GraphicsPath();

            // 左上角
            path.AddArc(arcRect, 180, 90);

            // 右上角
            arcRect.X = rect.Right - diameter;
            path.AddArc(arcRect, 270, 90);

            // 右下角
            arcRect.Y = rect.Bottom - diameter;
            path.AddArc(arcRect, 0, 90);

            // 左下角
            arcRect.X = rect.Left;
            path.AddArc(arcRect, 90, 90);
            path.CloseFigure();//闭合曲线
            return path;
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
    }
}
