using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;

namespace ByteHarmonic.Models
{
    /// <summary>
    /// 表示一个播放列表。
    /// </summary>
    public class Playlist
    {
        /// <summary>
        /// 播放模式（顺序/随机/单曲循环）。
        /// </summary>
        public PlaybackMode PlaybackMode { get; set; }

        /// <summary>
        /// 当前播放的歌曲列表。
        /// </summary>
        // 出于方便原因，使用 public 修饰
        public List<Song> PlaySongs { get; set; }

        public Playlist()
        {
            PlaybackMode = PlaybackMode.Sequential;
            PlaySongs = new List<Song>();
        }

        public Playlist(List<Song> playSongs, PlaybackMode playbackMode = PlaybackMode.Sequential)
        {
            PlaybackMode = playbackMode;
            PlaySongs = playSongs;
        }
    }
}
