using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteHarmonic.Models
{
    /// <summary>
    /// 管理员用户，继承自 AbstractUser。
    /// </summary>
    public class User : AbstractUser
    {
        public User()
        {
            IsAdmin = false;
        }
    }
}
