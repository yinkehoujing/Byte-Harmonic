using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byte_Harmonic.Utils
{

    public static class FileHelper
    {
        private static readonly string ProjectRoot = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"../../../"));
        private static readonly string AssetRoot = Path.Combine(ProjectRoot, "Assets");
        private static readonly string SqlScriptRoot = Path.Combine(ProjectRoot, "Database/SQLscripts");

        public static string GetAssetPath(string relativePath)

        {
            return Path.Combine(AssetRoot, relativePath);
        }

        public static string GetSqlScriptPath(string relativePath)
        {
            return Path.Combine(SqlScriptRoot, relativePath);
        }
    }
}
