using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byte_Harmonic.Forms.FormUtils
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;

    public static class TextScroller
    {
        private static readonly Dictionary<Control, ScrollerInfo> _scrollers = new Dictionary<Control, ScrollerInfo>();

        public static void EnableAutoScroll(this Control control,
            int scrollSpeed = 1,
            int scrollInterval = 16,
            int pauseDuration = 2000)
        {
            if (_scrollers.ContainsKey(control)) return;

            var info = new ScrollerInfo
            {
                Control = control,
                OriginalText = control.Text,
                ScrollSpeed = scrollSpeed,
                ScrollInterval = scrollInterval,
                PauseDuration = pauseDuration,
                LastFrameTime = DateTime.Now
            };

            if (control.IsHandleCreated)
            {
                InitializeScroller(info);
            }
            else
            {
                control.HandleCreated += (s, e) => InitializeScroller(info);
            }
        }

        private static void InitializeScroller(ScrollerInfo info)
        {
            SetDoubleBuffered(info.Control);

            info.Timer = new Timer { Interval = 1 };
            info.Timer.Tick += (sender, e) => ScrollTimerTick(info);

            info.Control.TextChanged += (s, e) =>
            {
                // 文本变化时重新检测是否需要滚动
                bool previousState = info.NeedsScroll;
                UpdateTextInfo(info);

                // 状态变化时重绘
                if (previousState != info.NeedsScroll)
                {
                    info.Control.Invalidate();
                }
            };

            info.Control.SizeChanged += (s, e) => UpdateTextInfo(info);
            info.Control.Paint += (s, e) =>
            {
                // 只有需要滚动时才接管绘制
                if (info.NeedsScroll)
                {
                    PaintScrollingText(info, e.Graphics);
                }
                else
                {
                    // 不接管绘制，使用控件原生绘制
                    return;
                }
            };
            info.Control.Disposed += (s, e) => DisableAutoScroll(info.Control);

            _scrollers[info.Control] = info;
            UpdateTextInfo(info);

            // 50ms后恢复正常间隔
            var timer = new Timer { Interval = 50 };
            timer.Tick += (s, e) =>
            {
                info.Timer.Interval = info.ScrollInterval;
                timer.Stop();
                timer.Dispose();
            };
            timer.Start();
        }

        private static void ScrollTimerTick(ScrollerInfo info)
        {
            if (!info.Control.IsHandleCreated || !info.NeedsScroll) return;

            var now = DateTime.Now;
            double elapsedMs = (now - info.LastFrameTime).TotalMilliseconds;
            info.LastFrameTime = now;

            if (info.IsPausing)
            {
                info.PauseElapsed += elapsedMs;
                if (info.PauseElapsed >= info.PauseDuration)
                {
                    info.IsPausing = false;
                    info.CurrentOffset = 0;
                }
                return;
            }

            float pixelsToMove = (float)(info.ScrollSpeed * elapsedMs / info.ScrollInterval);
            info.CurrentOffset += pixelsToMove;

            int maxOffset = Math.Max(0, info.TextWidth - info.Control.ClientSize.Width);
            if (info.CurrentOffset >= maxOffset)
            {
                info.CurrentOffset = maxOffset;
                info.IsPausing = true;
                info.PauseElapsed = 0;
            }

            info.Control.Invalidate();
        }

        private static void PaintScrollingText(ScrollerInfo info, Graphics g)
        {
            using (var brush = new SolidBrush(info.Control.ForeColor))
            {
                g.Clear(info.Control.BackColor);
                g.DrawString(info.OriginalText, info.Control.Font, brush,
                    new Point(-(int)info.CurrentOffset, 0));
            }
        }

        private static void UpdateTextInfo(ScrollerInfo info)
        {
            info.OriginalText = info.Control.Text;
            info.TextWidth = TextRenderer.MeasureText(info.OriginalText, info.Control.Font).Width;

            // 只有当文本确实超出可见区域时才启用滚动
            info.NeedsScroll = info.TextWidth > info.Control.ClientSize.Width;

            info.CurrentOffset = 0;
            info.IsPausing = false;

            if (info.NeedsScroll)
            {
                info.Timer.Start();
            }
            else
            {
                info.Timer.Stop();
            }
        }

        public static void DisableAutoScroll(this Control control)
        {
            if (!_scrollers.TryGetValue(control, out var info)) return;

            info.Timer?.Stop();
            info.Timer?.Dispose();
            _scrollers.Remove(control);
            control.Invalidate();
        }

        private static void SetDoubleBuffered(Control control)
        {
            if (control.GetType().GetProperty("DoubleBuffered",
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic) != null)
            {
                control.GetType().GetProperty("DoubleBuffered",
                    System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                    .SetValue(control, true, null);
            }
        }

        private class ScrollerInfo
        {
            public Control Control { get; set; }
            public string OriginalText { get; set; }
            public Timer Timer { get; set; }
            public int ScrollSpeed { get; set; }
            public int ScrollInterval { get; set; }
            public int PauseDuration { get; set; }
            public float CurrentOffset { get; set; }
            public int TextWidth { get; set; }
            public bool NeedsScroll { get; set; }
            public bool IsPausing { get; set; }
            public double PauseElapsed { get; set; }
            public DateTime LastFrameTime { get; set; }
        }
    }
}

