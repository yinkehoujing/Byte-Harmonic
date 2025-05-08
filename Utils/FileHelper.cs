using Byte_Harmonic.Models;
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
        public static string GetProjectRootPath(string relativePath)
        {
            return Path.Combine(ProjectRoot, relativePath);
        }

        //用于生成文件名
        public static string SanitizeFileName(string fileName)
        {
            var invalidChars = Path.GetInvalidFileNameChars();
            return string.Join("_", fileName.Split(invalidChars));
        }

        public static string GenerateFileName(Song song, int namingStyle)
        {
            var baseName = namingStyle switch
            {
                0 => song.Title,
                1 => $"{song.Title} - {song.Artist}",
                2 => $"{song.Artist} - {song.Title}",
                _ => song.Title
            };

            return FileHelper.SanitizeFileName(baseName);
        }
    }
}
