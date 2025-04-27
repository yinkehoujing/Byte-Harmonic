using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;

namespace ByteHarmonic.Models
{
    /// <summary>
    /// 表示一首歌曲的信息。
    /// </summary>
    public class Song
    {
        /// <summary>
        /// 唯一标识符。
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 歌曲标题。
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 歌手名。
        /// </summary>
        public string Artist { get; set; }

        /// <summary>
        /// 是否已下载到本地。
        /// </summary>
        public bool Downloaded { get; set; }

        /// <summary>
        /// 本地文件路径（如果已下载）。
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// 歌曲时长。
        /// </summary>
        public int Duration { get; set; }

        /// <summary>
        /// 歌曲的标签列表。
        /// </summary>
        public List<string> Tags { get; set; }

        /// <summary>
        /// 默认构造函数。
        /// </summary>
        public Song()
        {
            Id = Guid.NewGuid().ToString();
            Title = string.Empty;
            Artist = string.Empty;
            Downloaded = false;
            FilePath = string.Empty;
            Duration = 0;
            Tags = new List<string>();
        }

        /// <summary>
        /// 带参数的构造函数。
        /// </summary>
        public Song(string title, string artist, int duration)
        {
            Id = Guid.NewGuid().ToString();
            Title = title;
            Artist = artist;
            Downloaded = false;
            FilePath = string.Empty;
            Duration = duration;
            Tags = new List<string>();
        }

       
    }
}
