using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteHarmonic.Utils
{

    public static class FileHelper
    {
        private static readonly string ProjectRoot = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"../../../"));
        private static readonly string AssetRoot = Path.Combine(ProjectRoot, "Assets");

        public static string GetAssetPath(string relativePath)
        {
            return Path.Combine(AssetRoot, relativePath);
        }
    }
}
