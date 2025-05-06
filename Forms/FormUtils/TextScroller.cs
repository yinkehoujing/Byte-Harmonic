using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byte_Harmonic.Forms.FormUtils
{

    public static class InfiniteTextScroller
    {
        private static readonly Dictionary<Control, ScrollerInfo> _scrollers = new Dictionary<Control, ScrollerInfo>();

        public static void EnableAutoScroll(this Control control,
         int scrollSpeed = 1,
         int scrollInterval = 50,
         int pauseDuration = 3000,
         int startDelay = 1500)
        {
            if (_scrollers.ContainsKey(control)) return;

            // 预先测量文本宽度
            int textWidth = TextRenderer.MeasureText(control.Text, control.Font).Width;

            var info = new ScrollerInfo
            {
                Control = control,
                OriginalText = control.Text,
                ScrollSpeed = scrollSpeed,
                ScrollInterval = scrollInterval,
                PauseDuration = pauseDuration,
                StartDelay = startDelay,
                CurrentOffset = 0,
                TextWidth = textWidth,
                State = ScrollState.WaitingToStart
            };

            // 安全设置双缓冲
            SafeSetDoubleBuffered(control);

            // 初始化定时器
            info.ScrollTimer = new System.Windows.Forms.Timer { Interval = startDelay };
            info.ScrollTimer.Tick += (sender, e) => ScrollTimerTick(info);

            control.TextChanged += (s, e) =>
            {
                info.OriginalText = control.Text;
                ResetScrollState(info);
            };

            control.SizeChanged += (s, e) => ResetScrollState(info);
            control.Paint += (s, e) => ControlPaint(info, e.Graphics);
            control.Disposed += (s, e) => DisableInfiniteScroll(control);
            control.HandleCreated += (s, e) => OnHandleCreated(info);

            _scrollers.Add(control, info);

            // 如果句柄已创建，直接启动
            if (control.IsHandleCreated)
            {
                info.ScrollTimer.Start();
                control.Invalidate();
            }
        }

        private static void OnHandleCreated(ScrollerInfo info)
        {
            // 句柄创建后启动定时器
            info.ScrollTimer.Start();
            info.Control.Invalidate();
        }

        private static void SafeSetDoubleBuffered(Control control)
        {
            // 安全设置双缓冲
            if (control.IsHandleCreated)
            {
                SetDoubleBuffered(control);
            }
            else
            {
                control.HandleCreated += (s, e) => SetDoubleBuffered(control);
            }
        }

        private static void SetDoubleBuffered(Control control)
        {
            // 使用更安全的方式设置双缓冲
            if (control.GetType().GetProperty("DoubleBuffered",
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic) != null)
            {
                control.GetType().GetProperty("DoubleBuffered",
                    System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                    .SetValue(control, true, null);
            }
        }


        public static void DisableInfiniteScroll(this Control control)
        {
            if (!_scrollers.TryGetValue(control, out var info)) return;

            info.ScrollTimer.Stop();
            info.ScrollTimer.Dispose();
            control.Paint -= (s, e) => ControlPaint(info, e.Graphics);
            _scrollers.Remove(control);
            control.Invalidate();
        }

        private static void ScrollTimerTick(ScrollerInfo info)
        {
            switch (info.State)
            {
                case ScrollState.WaitingToStart:
                    // 初始延迟结束，开始滚动
                    info.State = ScrollState.Scrolling;
                    info.ScrollTimer.Interval = info.ScrollInterval;
                    info.TextWidth = TextRenderer.MeasureText(info.OriginalText, info.Control.Font).Width;
                    info.Control.Invalidate();
                    break;

                case ScrollState.Scrolling:
                    // 执行滚动
                    info.CurrentOffset += info.ScrollSpeed;

                    // 检查是否滚动到末尾
                    if (info.CurrentOffset >= info.TextWidth - info.Control.Width)
                    {
                        info.State = ScrollState.Pausing;
                        info.ScrollTimer.Interval = info.PauseDuration;
                        info.CurrentOffset = info.TextWidth - info.Control.Width; // 确保完全显示末尾
                    }
                    info.Control.Invalidate();
                    break;

                case ScrollState.Pausing:
                    // 暂停结束，重置并重新开始滚动
                    info.State = ScrollState.Scrolling;
                    info.ScrollTimer.Interval = info.ScrollInterval;
                    info.CurrentOffset = 0;
                    info.Control.Invalidate();
                    break;
            }
        }

        private static void ControlPaint(ScrollerInfo info, Graphics g)
        {
            if (info.TextWidth <= info.Control.Width)
            {
                // 文本不超长，正常显示
                TextRenderer.DrawText(g, info.OriginalText, info.Control.Font,
                    new Rectangle(0, 0, info.Control.Width, info.Control.Height),
                    info.Control.ForeColor, info.Control.BackColor);
                return;
            }

            // 绘制滚动文本
            using (var brush = new SolidBrush(info.Control.ForeColor))
            {
                var rect = new RectangleF(-info.CurrentOffset, 0, info.TextWidth, info.Control.Height);
                g.Clear(info.Control.BackColor);
                g.DrawString(info.OriginalText, info.Control.Font, brush, rect);
            }
        }

        private static void ResetScrollState(ScrollerInfo info)
        {
            info.State = ScrollState.WaitingToStart;
            info.CurrentOffset = 0;
            info.ScrollTimer.Interval = info.StartDelay;
            info.TextWidth = TextRenderer.MeasureText(info.OriginalText, info.Control.Font).Width;
            info.Control.Invalidate();
        }


        private class ScrollerInfo
        {
            public Control Control { get; set; }
            public string OriginalText { get; set; }
            public System.Windows.Forms.Timer ScrollTimer { get; set; }
            public int ScrollSpeed { get; set; }
            public int ScrollInterval { get; set; }
            public int PauseDuration { get; set; }
            public int StartDelay { get; set; }
            public int CurrentOffset { get; set; }
            public int TextWidth { get; set; }
            public ScrollState State { get; set; }
            public bool IsFirstRun { get; set; } 
        }

        private enum ScrollState
        {
            WaitingToStart,
            Scrolling,
            Pausing
        }
    }
}

