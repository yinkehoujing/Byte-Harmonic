using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Byte_Harmonic.Database;
using Byte_Harmonic.Models;
using Byte_Harmonic.Services;
using AppContext = Byte_Harmonic.Forms.AppContext;

namespace Byte_Harmonic.Services
{
    public class SearchService
    {
        private readonly SonglistRepository _repository;
        private readonly UserRepository _userRepo;
        private readonly UserService _userService;

        public SearchService(SonglistRepository repository, UserRepository userRepo, UserService userService)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _userRepo = userRepo ?? throw new ArgumentNullException(nameof(userRepo));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        // 按关键字搜索歌曲（标题、歌手）
        public async Task<List<Song>> SearchSongs(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return new List<Song>();

            // 记录搜索历史
            var currentUser = AppContext.currentUser;
            if (currentUser != null)
            {
                await _userRepo.AddSearchHistoryAsync(currentUser.Account, keyword);
            }

            var allSongs = await _repository.GetAllSongsAsync();
            keyword = keyword.ToLower();
            return allSongs.Where(s =>
                (!string.IsNullOrEmpty(s.Title) && s.Title.ToLower().Contains(keyword)) ||
                (!string.IsNullOrEmpty(s.Artist) && s.Artist.ToLower().Contains(keyword))
            ).ToList();
        }
        //只是用于推荐
        public async Task<List<Song>> JustSearchSong(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return new List<Song>();
            var allSongs = await _repository.GetAllSongsAsync();
            keyword = keyword.ToLower();
            return allSongs.Where(s =>
                (!string.IsNullOrEmpty(s.Title) && s.Title.ToLower().Contains(keyword)) ||
                (!string.IsNullOrEmpty(s.Artist) && s.Artist.ToLower().Contains(keyword))
            ).ToList();
        }

        //更新搜索记录
        public async Task<bool> UpdateSearchHistory(string username, List<string> history)
        {
            if (string.IsNullOrWhiteSpace(username) || history == null || history.Count == 0)
            {
                throw new ArgumentException("用户名或历史记录无效");
            }

            return await _userRepo.UpdateSearchHistoryAsync(username, history);
        }
        // 按关键字搜索歌单（歌单名）
        /* public async Task<List<Songlist>> SearchSonglistsAsync(string keyword)
         {
             if (string.IsNullOrWhiteSpace(keyword))
                 return new List<Songlist>();

             // 记录搜索历史
             var currentUser = _userService.GetCurrentUser();
             if (currentUser != null)
             {
                 await _userRepo.AddSearchHistoryAsync(currentUser.Account, keyword);
             }

             var allSonglists = await _repository.GetAllPlaylistsAsync();
             keyword = keyword.ToLower();
             return allSonglists.Where(sl =>
                 !string.IsNullOrEmpty(sl.Name) && sl.Name.ToLower().Contains(keyword)
             ).ToList();
         }*/

        // 按单个标签筛选歌曲
        public async Task<List<Song>> SearchSongsByTagAsync(string tag)
        {
            if (string.IsNullOrWhiteSpace(tag))
                return new List<Song>();

            // 记录搜索历史
            var currentUser = AppContext.currentUser;
            if (currentUser != null)
            {
                await _userRepo.AddSearchHistoryAsync(currentUser.Account, tag);
            }

            int tagId = _repository.EnsureTagExists(tag);
            return _repository.GetSongsByTag(tagId);
        }

        // 按多个标签（交集）筛选歌曲
        public async Task<List<Song>> SearchSongsByTagsAsync(List<string> tags)
        {
            if (tags == null || !tags.Any())
                return new List<Song>();

            // 记录搜索历史
            var currentUser = _userService.GetCurrentUser();
            if (currentUser != null)
            {
                await _userRepo.AddSearchHistoryAsync(currentUser.Account, string.Join(" ", tags));
            }

            var tagIds = tags.Select(t => _repository.EnsureTagExists(t)).ToList();
            return _repository.GetSongsByTags(tagIds);
        }
        //在指定歌曲中按标签刷选歌曲
        public async Task<List<Song>> SearchSongsByTagsAsync(List<Song> songs, List<string> tags)
        {
            if (songs == null || !songs.Any())
            {
                throw new ArgumentException("歌曲列表不能为空", nameof(songs));
            }

            // 获取所有标签的ID
            var tagIds = new List<int>();
            foreach (var tag in tags)
            {
                var tagId = _repository.EnsureTagExists(tag);
                if (tagId == 0)
                {
                    throw new ArgumentException($"标签 '{tag}' 不存在", nameof(tags));
                }
                tagIds.Add(tagId);
            }
            /*foreach (var tagID in tagIds)
            {
                Console.WriteLine($"{tagID}");
            }*/
            // 筛选出包含所有指定标签的歌曲
            var result = songs.Where(song =>
            {
                var songTags = _repository.GetTagsBySongId(song.Id);
                return tagIds.All(tagId => songTags.Contains(tagId));
            }).ToList();

            return result;
        }

        // 获取某歌单中的歌曲
        public List<Song> GetSongsInSonglist(int songlistId)
        {
            return _repository.GetSongsInPlaylist(songlistId);
        }

        // 在歌单中按标签筛歌（单个标签）
        public List<Song> SearchSongsInSonglistByTag(int songlistId, string tag)
        {
            if (string.IsNullOrWhiteSpace(tag))
                return new List<Song>();

            var allSongs = _repository.GetSongsInPlaylist(songlistId);
            int tagId = _repository.EnsureTagExists(tag);
            var taggedSongs = _repository.GetSongsByTag(tagId);

            var result = allSongs.Where(s => taggedSongs.Any(ts => ts.Id == s.Id)).ToList();
            return result;
        }

        // 在歌单中按多标签筛歌（交集）
        /* public List<Song> SearchSongsInSonglistByTags(int songlistId, List<string> tags)
         {
             if (tags == null || !tags.Any())
                 return new List<Song>();

             var allSongs = _repository.GetSongsInPlaylist(songlistId);
             var tagFilteredSongs = _repository.GetSongsByTags(tags.Select(t => _repository.EnsureTagExists(t)).ToList());

             var result = allSongs.Where(s => tagFilteredSongs.Any(ts => ts.Id == s.Id)).ToList();
             return result;
         }*/
        

    }
}
