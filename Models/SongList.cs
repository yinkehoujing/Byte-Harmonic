using System;
using System.Collections.Generic;

namespace Byte_Harmonic.Models
{
    public class Songlist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Song> Songs { get; set; }
        public bool IsPublic { get; set; }
        public string Owner { get; set; }
        public string ShareLink { get; private set; }

        public Songlist()
        {
            Id = 0;                // 新增记录时由数据库自增生成
            Name = string.Empty;
            Songs = new List<Song>();
            IsPublic = false;
            Owner = string.Empty;
        }

        public Songlist(string name, string owner, bool isPublic = false)
        {
            Name = name;
            Owner = owner;
            IsPublic = isPublic;
            Songs = new List<Song>();
        }

        /*
        public void GenerateShareLink()
        {
            if (!IsPublic) throw new InvalidOperationException("私有歌单不可分享");
            ShareLink = $"https://app.com/share/{Guid.NewGuid():N}";
        }
        */
    }
}