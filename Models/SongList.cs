using System;
using System.Collections.Generic;

namespace Byte_Harmonic.Models
{
    /// <summary>
    /// 表示一个歌单实体，对应数据库中的 Playlists 表
    /// </summary>
    public class Songlist
    {
        /// <summary>
        /// 歌单的唯一标识（对应数据库自增主键）
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 歌单名称（最大长度255字符）
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 歌单包含的歌曲集合
        /// </summary>
        public List<Song> Songs { get; set; }

        /// <summary>
        /// 歌单是否公开可见
        /// </summary>
        public bool IsPublic { get; set; }

        /// <summary>
        /// 歌单所有者账户（关联 Users 表）
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        /// 歌单分享链接（关联 Users 表）
        /// </summary>
        public string ShareLink { get; private set; }

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public Songlist()
        {
            Id = 0;                // 新增记录时由数据库自增生成
            Name = string.Empty;
            Songs = new List<Song>();
            IsPublic = false;
            Owner = string.Empty;
        }

        /// <summary>
        /// 带参数的构造函数（用于快速创建对象）
        /// </summary>
        public Songlist(string name, string owner, bool isPublic = false)
        {
            Name = name;
            Owner = owner;
            IsPublic = isPublic;
            Songs = new List<Song>();
        }

        /// <summary>
        /// 生成分享链接
        /// </summary>
        public void GenerateShareLink()
        {
            if (!IsPublic) throw new InvalidOperationException("私有歌单不可分享");
            ShareLink = $"https://app.com/share/{Guid.NewGuid():N}";
        }
    }
}