using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml;
using Byte_Harmonic.Database;
using Byte_Harmonic.Models;
using MySql.Data.MySqlClient;
using Newtonsoft.Json; 
using TagLib;         


namespace Byte_Harmonic.Services
{
    //User无抽象类，只有isAdmin
    public class SonglistService
    {
        private readonly SonglistRepository _repository;
        private readonly UserService _userService;
        public SonglistService(SonglistRepository repository, UserService userService)
        {
            _repository = repository;
            _userService = userService;
        }

        #region 歌曲管理
        //导入歌曲
        //创新点：异步操作（以保证对曲库进行操作时的原子性）
        public async Task<bool> ImportSongsAsync(string folderPath)
        {
            // 权限校验
            if (!_userService.GetCurrentUser().IsAdmin)
                throw new UnauthorizedAccessException("只有管理员可以导入歌曲");

            try
            {
                var audioFiles = Directory.EnumerateFiles(folderPath, "*.mp3", SearchOption.AllDirectories);
                var existingPaths = (await _repository.GetAllSongsAsync()).Select(s => s.MusicFilePath).ToHashSet();

                var tasks = audioFiles.Select(async file =>
                {
                    if (existingPaths.Contains(file)) return; // 增量跳过

                    using var tagFile = await Task.Run(() => TagLib.File.Create(file));
                    var song = new Song {  };  //元数据解析 
                    await _repository.AddSongAsync(song);
                });

                await Task.WhenAll(tasks);
                return true;
            }
            catch (Exception ex)
            {
                // 记录日志
                Console.WriteLine($"歌曲导入失败: {ex.Message}");
                return false;
            }
        }

        //导入歌曲（根据歌曲名）
        public async Task<bool> ImportSongsAsync(Song song)
        {
            if (!_userService.GetCurrentUser().IsAdmin)
                throw new UnauthorizedAccessException("只有管理员可以添加歌曲");

            try
            {
                await _repository.AddSongAsync(song); // 调用仓库层方法
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"添加失败: {ex.Message}");
                return false;
            }
        }

        //获取所有歌曲
        public Task<List<Song>> GetAllSongsAsync() => _repository.GetAllSongsAsync();

        //导出歌曲
        public async Task<bool> ExportSongsAsync(string exportPath)
        {
            if (!Directory.Exists(exportPath))
                Directory.CreateDirectory(exportPath);

            foreach (var song in (await GetAllSongsAsync()).Where(s => s.Downloaded))
            {
                try
                {
                    var destPath = Path.Combine(exportPath, Path.GetFileName(song.MusicFilePath));
                    System.IO.File.Copy(song.MusicFilePath, destPath, overwrite: true);
                }
                catch (Exception ex)
                {
                    // 记录错误日志
                    Console.WriteLine($"导出失败: {song.Title} | 错误: {ex.Message}");
                    return false;
                }
            }
            return true;
        }

        //删除歌曲
        public async Task<bool> DeleteSongAsync(int songId)
        {
            // 权限校验：仅管理员可删除歌曲
            if (!_userService.GetCurrentUser().IsAdmin)
            {
                throw new UnauthorizedAccessException("管理员权限不足");
            }

            try
            {
                await _repository.DeleteSongAsync(songId);
                return true;
            }
            catch (MySqlException ex)
            {
                //记录日志
                Console.WriteLine($"异步删除失败: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"系统异常: {ex.Message}");
                return false;
            }
        }

        //通过Id获取对应歌曲
        public Song GetSongById(int songId)
        {
            return _repository.GetSongById(songId);
        }
        #endregion

        #region 标签管理
        //根据标签筛选出所有歌曲
        public List<Song> FilterSongsByTag(string tag)
        {
            var tagId = _repository.EnsureTagExists(tag);
            return _repository.GetSongsByTag(tagId);
        }

        //函数重载：根据多个标签筛选歌曲（求交集）
        public List<Song> FilterSongsByTag(List<string> tags)
        {
            var tagIds = tags.Select(t => _repository.EnsureTagExists(t)).ToList();
            return _repository.GetSongsByTags(tagIds);
        }

        //给歌曲增加标签
        public bool AssignTagToSong(Song song, string tag)
        {
            try
            {
                var tagId = _repository.EnsureTagExists(tag);
                _repository.AssignTagToSong(song.Id, tagId);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region 歌单管理
        //创建歌单
        public void CreateSonglist(string name)
        {
            var currentUser = _userService.GetCurrentUser();
            var songlist = new Songlist(name, currentUser.Account);
            _repository.CreatePlaylist(songlist);
        }

        //导入歌单
        public bool ImportSonglist(string filePath)
        {
            try
            {
                var json = System.IO.File.ReadAllText(filePath);
                var songlist = JsonConvert.DeserializeObject<Songlist>(json);
                songlist.Owner = _userService.GetCurrentUser().Account;
                _repository.CreatePlaylist(songlist);
                return true;
            }
            catch
            {
                return false;
            }
        }
        //导出歌单
        public bool ExportSonglist(Songlist songlist, string filePath)
        {
            try
            {
                var json = JsonConvert.SerializeObject(
                    songlist,
                    Newtonsoft.Json.Formatting.Indented  // 完整命名空间
                );
                System.IO.File.WriteAllText(filePath, json);
                return true;
            }
            catch
            {
                return false;
            }
        }

        //歌单中添加歌曲
        public bool AddSongToSonglist(Song song, Songlist songlist)
        {
            try
            {
                _repository.AddSongsToPlaylist(songlist.Id, new[] { song.Id });
                return true;
            }
            catch
            {
                return false;
            }
        }

        //歌单中移除歌曲
        public bool RemoveSongFromSonglist(Song song, Songlist songlist)
        {
            try
            {
                _repository.RemoveSongFromPlaylist(songlist.Id, song.Id);
                return true;
            }
            catch
            {
                return false;
            }
        }

        //歌单中获取歌曲列表
        public List<Song> GetSongsInSonglist(Songlist songlist)
        {
            return _repository.GetSongsInPlaylist(songlist.Id);
        }

        /*
        //分享歌单链接
        public string GetShareLink(Songlist songlist)
        {
            if (!songlist.IsPublic) return "此歌单未公开";
            if (string.IsNullOrEmpty(songlist.ShareLink))
                songlist.GenerateShareLink();
            return songlist.ShareLink;
        }
        */

        //获取所有歌单（异步操作）
        public async Task<List<Songlist>> GetAllPlaylistsAsync()
        {
            var currentUser = _userService.GetCurrentUser();
            if (currentUser == null)
                throw new UnauthorizedAccessException("用户未登录");

            // 传递当前用户账号给Repository
            return await _repository.GetAllPlaylistsAsync(currentUser.Account);
        }


        // 检查给定的歌单名是否已存在（防止重复创建）
        public bool CheckIfSonglistExists(string songlistName)
        {
            if (string.IsNullOrWhiteSpace(songlistName))
                throw new ArgumentException("歌单名称不能为空", nameof(songlistName));

            return _repository.CheckIfSonglistExists(songlistName);
        }

        // 根据歌单名获取当前用户的歌单
        public async Task<Songlist> GetSonglistByName(string name)
        {
            var currentUser = _userService.GetCurrentUser();
            if (currentUser == null)
                throw new UnauthorizedAccessException("用户未登录");

            // 传递当前用户账号给Repository
            return await _repository.GetSonglistByNameAndOwner(name, currentUser.Account);
        }
        #endregion
    }
}