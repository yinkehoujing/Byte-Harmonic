using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteHarmonic.Utils
{
using System;
using System.Windows.Forms;

public static class TimerHelper
{
    /// <summary>
    /// 初始化并启动一个 Windows Forms Timer。
    /// </summary>
    /// <param name="timer">Timer对象的引用。</param>
    /// <param name="interval">时间间隔（毫秒）。</param>
    /// <param name="tickAction">每次Tick时要执行的委托。</param>
    public static void SetupTimer(ref Timer timer, int interval, EventHandler tickAction)
    {
        if (timer == null)
        {
            timer = new Timer();
        }

        timer.Interval = interval;
        
        // 先清除以前绑定的事件，避免重复绑定
        timer.Tick -= tickAction;
        timer.Tick += tickAction;
        
        timer.Start();
    }


        /// <summary>
        /// 停止一个 Windows Forms Timer。
        /// </summary>
        /// <param name="timer">Timer对象的引用。</param>
        public static void StopTimer(ref Timer? timer)
        {
            timer?.Stop();
        }


        /// <summary>
        /// restart 一个 Windows Forms Timer。
        /// </summary>
        /// <param name="timer">Timer对象的引用。</param>
        public static void RestartTimer(ref Timer? timer)
        {
            timer?.Start();
        }

        /// <summary>
        /// 停止并释放一个 Windows Forms Timer。
        /// </summary>
        /// <param name="timer">Timer对象的引用。</param>
        public static void StopAndDisposeTimer(ref Timer timer)
        {
            timer?.Stop();
            timer?.Dispose();
        }
    }
}
