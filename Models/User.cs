using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;
using System.Security.Principal;

namespace Byte_Harmonic.Models
{
    /// <summary>
    /// 
    /// </summary>
    public  class User
    {
        public string Account { get; set; }
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
        public bool IsAdmin { get; set; }

        public User()
        {
            Account = string.Empty;
            Username = string.Empty;
            Password = string.Empty;
           // Songlists = new List<Songlist>();
            IsAdmin = false;
        }
    }
}
