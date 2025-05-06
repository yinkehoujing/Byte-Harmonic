using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Byte_Harmonic.Database;
using Byte_Harmonic.Models;

namespace Byte_Harmonic.Services
{
    public class SearchService
    {
        private readonly SonglistRepository _repository;

        public SearchService(SonglistRepository repository)
        {
            _repository = repository;
        }

        // 按关键字搜索歌曲（标题、歌手）
        public async Task<List<Song>> SearchSongsAsync(string keyword)
        {
            var allSongs = await _repository.GetAllSongsAsync();
            keyword = keyword.ToLower();
            return allSongs.Where(s =>
                (!string.IsNullOrEmpty(s.Title) && s.Title.ToLower().Contains(keyword)) ||
                (!string.IsNullOrEmpty(s.Artist) && s.Artist.ToLower().Contains(keyword))
            ).ToList();
        }

        /*// 按关键字搜索歌单（歌单名）
        public async Task<List<Songlist>> SearchSonglistsAsync(string keyword)
        {
            var allSonglists = await _repository.GetAllSongsAsync();
            keyword = keyword.ToLower();
            return allSonglists.Where(sl =>
                !string.IsNullOrEmpty(sl.Name) && sl.Name.ToLower().Contains(keyword)
            ).ToList();
        }*/

        // 获取某歌单中的歌曲
        public List<Song> GetSongsInSonglist(int songlistId)
        {
            return _repository.GetSongsInPlaylist(songlistId);
        }

        // 按单个标签筛选歌曲
        public async Task<List<Song>> SearchSongsByTagAsync(string tag)
        {
            int tagId = _repository.EnsureTagExists(tag);
            return await Task.Run(() => _repository.GetSongsByTag(tagId));
        }

        // 按多个标签（交集）筛选歌曲
        public async Task<List<Song>> SearchSongsByTagsAsync(List<string> tags)
        {
            var tagIds = tags.Select(t => _repository.EnsureTagExists(t)).ToList();
            return await Task.Run(() => _repository.GetSongsByTags(tagIds));
        }

        
        // 在歌单中按标签筛歌（单个标签）
        public List<Song> SearchSongsInSonglistByTag(int songlistId, string tag)
        {
            var allSongs = _repository.GetSongsInPlaylist(songlistId);
            int tagId = _repository.EnsureTagExists(tag);
            var taggedSongs = _repository.GetSongsByTag(tagId);

            var result = allSongs.Where(s => taggedSongs.Any(ts => ts.Id == s.Id)).ToList();
            return result;
        }

        // 在歌单中按多标签筛歌（交集）
        public List<Song> SearchSongsInSonglistByTags(int songlistId, List<string> tags)
        {
            var allSongs = _repository.GetSongsInPlaylist(songlistId);
            var tagFilteredSongs = _repository.GetSongsByTags(tags.Select(t => _repository.EnsureTagExists(t)).ToList());

            var result = allSongs.Where(s => tagFilteredSongs.Any(ts => ts.Id == s.Id)).ToList();
            return result;
        }
    }
}
