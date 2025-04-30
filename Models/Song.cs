using System.Collections.Generic;

namespace Byte_Harmonic.Models
{
    /// <summary>
    /// 表示一首歌曲的信息。
    /// </summary>
    public class Song
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public bool Downloaded { get; set; }
        public string MusicFilePath { get; set; }
        public string LrcFilePath { get; set; }
        public int Duration { get; set; }
        public List<string> Tags { get; set; }
        public Lyrics Lyrics { get; private set; }

        /// <summary>
        /// 默认构造函数。
        /// </summary>
        public Song()
        {
            Title = string.Empty;
            Artist = string.Empty;
            Downloaded = false;
            MusicFilePath = string.Empty;
            LrcFilePath = string.Empty;
            Duration = 0;
            Tags = new List<string>();
        }

        /// <summary>
        /// 带参数的构造函数。
        /// </summary>
        public Song(string title, string artist, int duration)
        {
            Title = title;
            Artist = artist;
            Downloaded = false;
            MusicFilePath = string.Empty;
            LrcFilePath = string.Empty;
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
