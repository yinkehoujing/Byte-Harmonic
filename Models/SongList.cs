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
    /// 表示一个歌单。
    /// </summary>
    public class Songlist
    {
        /// <summary>
        /// 歌单名称。
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 歌单中的歌曲列表。
        /// </summary>
        public List<Song> Songs { get; set; }

        /// <summary>
        /// 是否公开歌单。
        /// </summary>
        public bool IsPublic { get; set; }

        /// <summary>
        /// 拥有者用户名。
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        /// 构造函数。
        /// </summary>
        public Songlist()
        {
            Name = string.Empty;
            Songs = new List<Song>();
            IsPublic = false;
            Owner = string.Empty;
        }
    }
}
