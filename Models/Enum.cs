using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byte_Harmonic.Models
{
    /// <summary>
    /// 播放模式。
    /// </summary>
    public enum PlaybackMode
    {
        Sequential, // 顺序播放
        Shuffle,    // 随机播放
        RepeatOne   // 单曲循环
    }

    /// <summary>
    /// 歌词显示模式。
    /// </summary>
    public enum LyricsMode
    {
        Normal,    // 普通模式
        PureText   // 纯净文本模式
    }
}
