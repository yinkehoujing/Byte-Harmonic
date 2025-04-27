using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;

namespace ByteHarmonic.Models
{
    public class LyricsLine
    {
        public TimeSpan Timestamp { get; set; }   // 这行歌词的时间戳
        public string Text { get; set; }           // 这行歌词内容
    }

    public class Lyrics
    {
        public List<LyricsLine> Lines { get; set; } = new List<LyricsLine>();   // 每行歌词
        public string RawContent { get; set; }                                  // 原始LRC文本（可选，看你要不要保留）

        // 解析LRC文件，生成 Lyrics 对象
        public static Lyrics ParseFromLRC(string lrcContent)
        {
            var lyrics = new Lyrics
            {
                RawContent = lrcContent
            };

            var lines = lrcContent.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var line in lines)
            {
                // 示例：[00:12.34]Hello World
                if (line.StartsWith("["))
                {
                    var closingBracketIndex = line.IndexOf(']');
                    if (closingBracketIndex > 0)
                    {
                        var timePart = line.Substring(1, closingBracketIndex - 1);
                        var textPart = line.Substring(closingBracketIndex + 1);

                        if (TimeSpan.TryParseExact(timePart, @"mm\:ss\.ff", null, out var timestamp))
                        {
                            lyrics.Lines.Add(new LyricsLine
                            {
                                Timestamp = timestamp,
                                Text = textPart
                            });
                        }
                        else if (TimeSpan.TryParseExact(timePart, @"mm\:ss", null, out timestamp))
                        {
                            // 有些LRC文件是没有小数秒的
                            lyrics.Lines.Add(new LyricsLine
                            {
                                Timestamp = timestamp,
                                Text = textPart
                            });
                        }
                    }
                }
            }

            return lyrics;
        }
    }
}
