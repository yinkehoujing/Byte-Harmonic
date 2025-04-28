using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using Sunny.UI;
using NAudio.Wave;

namespace ByteHarmonic.Models
{
        /// <summary>
        /// 表示一首歌曲的信息。
        /// </summary>
        public class Song
        {
            public string Id { get; set; }
            public string Title { get; set; }
            public string Artist { get; set; }
            public bool Downloaded { get; set; }
            public string FilePath { get; set; }
            public int Duration { get; set; }
            public List<string> Tags { get; set; }
            public Lyrics Lyrics { get; private set; }

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

            /// <summary>
            /// 加载歌词文件（LRC）。
            /// </summary>
            public void LoadLyrics(string lrcPath)
            {
                Lyrics = new Lyrics();
                Lyrics.Load(lrcPath);
            }
        }
}
