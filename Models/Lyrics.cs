using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ByteHarmonic.Models
{
    /// <summary>
    /// 表示一行歌词（带时间戳）。
    /// </summary>
    public class LyricsLine
    {
        public TimeSpan Time { get; set; }  // 歌词出现的时间点
        public string Text { get; set; }    // 歌词文本
    }

    /// <summary>
    /// 解析并存储 LRC 歌词，用于实时同步查询。
    /// </summary>
    public class Lyrics
    {
        // 按时间排序的歌词行列表
        private List<LyricsLine> _lines = new List<LyricsLine>();

        /// <summary>
        /// 读取并解析 LRC 文件。
        /// </summary>
        /// <param name="filePath">LRC 文件路径。</param>
        public void Load(string filePath)
        {
            // 读取文件所有行（假设 UTF-8 编码，可根据需要更改）
            var lines = File.ReadAllLines(filePath, Encoding.UTF8);
            int offsetMs = 0;  // 时间偏移（毫秒）
            var regex = new Regex(@"\[(\d{2}):(\d{2})\.(\d{2})\](.*)");

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                // 解析偏移标签 [offset:毫秒]
                if (line.StartsWith("[offset:", StringComparison.OrdinalIgnoreCase))
                {
                    var val = line.Substring(8).TrimEnd(']');
                    int.TryParse(val, out offsetMs);
                }
                // 忽略其他元信息标签，如 [ti:], [ar:] 等
                else if (line.StartsWith("[ti:") || line.StartsWith("[ar:") ||
                         line.StartsWith("[al:") || line.StartsWith("[by:"))
                {
                    continue;
                }
                else
                {
                    // 匹配时间戳和文本
                    var match = regex.Match(line);
                    if (match.Success)
                    {
                        int min = int.Parse(match.Groups[1].Value);
                        int sec = int.Parse(match.Groups[2].Value);
                        int cs = int.Parse(match.Groups[3].Value); // 百分秒（1/100秒）
                        string text = match.Groups[4].Value.Trim();

                        // 计算原始时间，格式 [MM:SS.CC]
                        var time = new TimeSpan(0, 0, min, sec, cs * 10);
                        // 应用 offset：正值提前，负值延后
                        time = time - TimeSpan.FromMilliseconds(offsetMs);

                        _lines.Add(new LyricsLine { Time = time, Text = text });
                    }
                }
            }
            // 按时间排序（防止 LRC 文件中时间戳乱序）
            _lines.Sort((a, b) => a.Time.CompareTo(b.Time));
        }

        /// <summary>
        /// 根据播放时间查找当前歌词所在的索引（返回时间 <= currentTime 的最后一行）。
        /// </summary>
        public int GetCurrentIndex(TimeSpan currentTime)
        {
            if (_lines.Count == 0) return -1;
            int low = 0, high = _lines.Count - 1;
            int mid;
            while (low <= high)
            {
                mid = (low + high) / 2;
                if (_lines[mid].Time == currentTime)
                    return mid;
                else if (_lines[mid].Time < currentTime)
                    low = mid + 1;
                else
                    high = mid - 1;
            }
            // 当没有精确匹配时，high 指向小于 currentTime 的位置
            return Math.Max(high, 0);
        }

        /// <summary>
        /// 获取指定索引的歌词文本。
        /// </summary>
        public string GetLyricText(int index)
        {
            if (index >= 0 && index < _lines.Count)
                return _lines[index].Text;
            return string.Empty;
        }

        public LyricsLine? GetCurrentLine(TimeSpan timeSpan)
        {
            int index = GetCurrentIndex(timeSpan);
            if (index >= 0 && index < _lines.Count)
                return _lines[index];
            return null;
        }


        /// <summary>
        /// 返回歌词总行数。
        /// </summary>
        public int Count => _lines.Count;
    }
}
