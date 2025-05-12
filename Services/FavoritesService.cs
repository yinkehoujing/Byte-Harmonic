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

        public bool RemoveFavoriteSong(string username, int songId)
        {
            return _userRepository.RemoveFavoriteSong(username, songId);
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
        public async Task<bool> AddFavoriteSongsAsync(string username, IEnumerable<int> SongIds)
        {
            foreach (var songId in SongIds)
            {
                if (!await AddFavoriteSongAsync(username, songId))
                {
                    // 如果添加失败，返回 false
                    return false;
                }
            }
            return true;
        }


        // 清空用户的所有收藏
        public async Task<bool> ClearAllFavoritesAsync(string username)
        {
            return await _userRepository.ClearAllFavoritesAsync(username);
        }
    }
}