using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Byte_Harmonic.Database;
using Byte_Harmonic.Models;

namespace Byte_Harmonic.Services
{
    public class FavoritesService
    {
        private readonly UserRepository _userRepository;

        public FavoritesService(UserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        // 添加收藏歌曲
        public async Task<bool> AddFavoriteSongAsync(string username, int songId)
        {
            return await _userRepository.AddFavoriteSongAsync(username, songId);
        }
        //判断是否收藏
        public bool IsSongFavorite(string username, int songId)
        {
            return  _userRepository.IsSongFavorite(username, songId);
        }
        // 取消收藏歌曲
        public async Task<bool> RemoveFavoriteSongAsync(string username, int songId)
        {
            return await _userRepository.RemoveFavoriteSongAsync(username, songId);
        }

        // 获取用户收藏的所有歌曲
        public async Task<List<Song>> GetFavoriteSongsAsync(string username)
        {
            return await _userRepository.GetFavoriteSongsAsync(username);
        }

        // 获取用户收藏歌曲的数量
        public async Task<int> GetFavoriteSongsCountAsync(string username)
        {
            return await _userRepository.GetFavoriteSongsCountAsync(username);
        }
        //批量收藏
        // 批量收藏
        public async Task<bool> AddManyFavoriteSongs(string username, List<int> songIds)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentException("用户名不能为空", nameof(username));
            }

            if (songIds == null || songIds.Count == 0)
            {
                throw new ArgumentException("歌曲ID列表不能为空", nameof(songIds));
            }

            // 检查歌曲ID列表中是否有重复的歌曲ID
            var uniqueSongIds = new HashSet<int>(songIds);
            if (uniqueSongIds.Count != songIds.Count)
            {
                throw new ArgumentException("歌曲ID列表中存在重复项", nameof(songIds));
            }

            // 检查用户是否已经收藏了这些歌曲
            var existingFavorites = await _userRepository.GetFavoriteSongsAsync(username);
            var existingSongIds = new HashSet<int>(existingFavorites.Select(song => song.SongId));
            var newSongIds = uniqueSongIds.Except(existingSongIds).ToList();

            if (newSongIds.Count == 0)
            {
                // 如果所有歌曲都已收藏，直接返回 false
                return false;
            }

            // 调用 UserRepository 的方法批量添加收藏歌曲
            return await _userRepository.AddManyFavoriteSongsAsync(username, newSongIds);
        }

        // 清空用户的所有收藏
        public async Task<bool> ClearAllFavoritesAsync(string username)
        {
            return await _userRepository.ClearAllFavoritesAsync(username);
        }
    }
}