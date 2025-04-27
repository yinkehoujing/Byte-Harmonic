using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byte_Harmonic.Forms.FormUtils
{
    /// <summary>
    /// 处理通用情况下鼠标控制窗口行为
    /// </summary>    
    class MouseMove
    {
        private readonly Form _targetForm;//目标窗体
        private const int EdgeThreshold = 5;//鼠标起作用的边缘范围
        private bool _isDragging;//拖动状态
        private Point _dragStartPosition;//记录起始点用于计算
        private const int DragAreaHeight = 30; // 顶部可触发区域高度
        private readonly FormStyle _styleHandler;//用于更改窗口样式

        public MouseMove(Form form)
        {
            _styleHandler = new FormStyle(form);
            _targetForm = form;
            AttachEvents();
        }

        private void AttachEvents()
        {
            //调整位置
            _targetForm.MouseDown += TopMouseDown;
            _targetForm.MouseMove += TopMouseMove;
            _targetForm.MouseUp += (s, e) => _isDragging = false;
        }

        private void TopMouseDown(object sender, MouseEventArgs e)
        {
            //仅当在顶部30像素内按下左键时激活拖动
            if (e.Button == MouseButtons.Left && e.Y <= DragAreaHeight)
            {
                _isDragging = true;
                _dragStartPosition = new Point(e.X, e.Y);
            }
        }

        private void TopMouseMove(object sender, MouseEventArgs e)
        {
            //处理窗口拖动
            if (_isDragging && e.Button == MouseButtons.Left)
            {
                Point newPos = _targetForm.PointToScreen(new Point(e.X, e.Y));
                _targetForm.Location = new Point(
                    newPos.X - _dragStartPosition.X,
                    newPos.Y - _dragStartPosition.Y);
            }
        }
    }
}

