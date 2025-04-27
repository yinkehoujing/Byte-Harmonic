using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;

namespace ByteHarmonic.Models
{
    /// <summary>
    /// 抽象的用户类。
    /// </summary>
    public abstract class AbstractUser
    {
        /// <summary>
        /// 用户名。
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// 加密后的密码。
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 用户拥有的歌单列表。
        /// </summary>
        public List<Songlist> Songlists { get; set; }

        /// <summary>
        /// 是否为管理员。
        /// </summary>
        public bool IsAdmin { get; protected set; }

        public AbstractUser()
        {
            Username = string.Empty;
            Password = string.Empty;
            Songlists = new List<Songlist>();
            IsAdmin = false;
        }
    }
}
