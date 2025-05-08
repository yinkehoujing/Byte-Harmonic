using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byte_Harmonic.Utils
{
    public class ConfigManager
    {

        #region 连接数据库
        public static string GetConnectionString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
        #endregion


        #region 下载设置持久化
        private const string KeyDownloadPath = "DownloadPath";
        private const string KeyNamingStyle = "NamingStyle";

        public string DownloadPath { get; set; }
        public int NamingStyle { get; set; }

        // 保存到 App.config 的 appSettings 区
        public void Save()
        {
            var cfg = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var app = cfg.AppSettings.Settings;

            if (app[KeyDownloadPath] == null)
                app.Add(KeyDownloadPath, DownloadPath);
            else
                app[KeyDownloadPath].Value = DownloadPath;

            var style = NamingStyle.ToString();
            if (app[KeyNamingStyle] == null)
                app.Add(KeyNamingStyle, style);
            else
                app[KeyNamingStyle].Value = style;

            cfg.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        // 单例入口：从 appSettings 读取初始值
        public static ConfigManager Instance => _instance ??= LoadConfig();
        private static ConfigManager _instance;

        private static ConfigManager LoadConfig()
        {
            var mgr = new ConfigManager();
            var app = ConfigurationManager.AppSettings;

            mgr.DownloadPath = app[KeyDownloadPath] ?? Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
            // 名称格式，默认 0
            mgr.NamingStyle = int.TryParse(app[KeyNamingStyle], out var s) ? s : 0;

            return mgr;
        }
        #endregion

    }
}
