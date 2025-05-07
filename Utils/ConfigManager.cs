using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byte_Harmonic.Utils
{
    // [[maybe unused]]
    public class ConfigManager
    {
        #region 连接数据库
        public static string GetConnectionString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
        #endregion

        #region 下载
        public string DownloadPath { get; set; }
        public int NamingStyle { get; set; }

        public void Save()
        {
            // 实现配置保存逻辑
        }

        public static ConfigManager Instance => _instance ??= LoadConfig();

        private static ConfigManager _instance;

        private static ConfigManager LoadConfig()
        {
            // 实现配置加载逻辑
            return new ConfigManager();
        }
        #endregion

    }
}
