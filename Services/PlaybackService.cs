using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using ByteHarmonic.Models;

namespace Services
{
    public class PlaybackService
    {
        private List<Song> _playlist = new List<Song>();
        private Song? _currentSong;
        private int _currentIndex = -1;
        private PlaybackMode _playbackMode = PlaybackMode.Sequential;
        private LyricsMode _lyricsMode = LyricsMode.Normal;
        private bool _isPlaying = false;
        private TimeSpan _currentPosition = TimeSpan.Zero;
        private double _playbackSpeed = 1.0;  // 默认播放速度 1.0x

        // 播放指定歌曲
        public void PlaySong(Song song)
        {
            _currentSong = song;
            _currentIndex = _playlist.IndexOf(song);
            _isPlaying = true;
            _currentPosition = TimeSpan.Zero;

            // TODO: 调用底层播放引擎播放歌曲
            Console.WriteLine($"正在播放: {song.Title}");
        }

        // 暂停播放
        public void Pause()
        {
            _isPlaying = false;
            // TODO: 调用底层暂停逻辑
        }

        // 继续播放
        public void Resume()
        {
            _isPlaying = true;
            // TODO: 调用底层继续播放逻辑
        }

        // 跳转到指定位置
        public void SeekTo(TimeSpan position)
        {
            _currentPosition = position;
            // TODO: 调用底层跳转逻辑
        }

        // 设置播放模式
        public void SetPlaybackMode(PlaybackMode mode)
        {
            _playbackMode = mode;
        }

        public PlaybackMode GetPlaybackMode()
        {
            return _playbackMode;
        }

        // 设置播放速度
        public void SetPlaybackSpeed(double speed)
        {
            if (speed <= 0)
                throw new ArgumentException("播放速度必须大于 0");

            _playbackSpeed = speed;

            // TODO: 调用底层播放引擎调整速度
            //Console.WriteLine($"设置播放速度为: {speed}x");
        }

        // 获取当前播放速度
        public double GetPlaybackSpeed()
        {
            return _playbackSpeed;
        }

        // 设置播放列表
        public void SetPlaylist(List<Song> playlist)
        {
            _playlist = playlist;
            _currentIndex = -1;
            _currentSong = null;
        }

        // 添加到播放列表
        public List<Song> AddToPlaylist(Song song)
        {
            _playlist.Add(song);
            return _playlist;
        }

        // 从播放列表移除
        public List<Song> RemoveFromPlaylist(Song song)
        {
            _playlist.Remove(song);
            return _playlist;
        }

        // 获取当前播放列表
        public List<Song> GetCurrentPlaylist()
        {
            return _playlist;
        }

        // 获取指定歌曲歌词
        public Lyrics GetLyricsForSong(Song song)
        {
            // 假设歌词文件是根据歌曲ID或者歌曲名来命名的
            // 这里假设是本地读取，当然也可以从数据库取出歌词文本
            //string lyricsPath = Path.Combine("Assets", "Lyrics", $"{song.Id}.lrc"); // 或者 $"{song.Title}.lrc"
            string lyricsPath = null;
            if(lyricsPath == null)
            {
                // 如果歌词路径为空，返回一个空歌词
                return new Lyrics();
            }

            if (!File.Exists(lyricsPath))
            {
                // 如果歌词文件不存在，可以返回一个空歌词
                return new Lyrics();
            }

            string lrcContent = File.ReadAllText(lyricsPath); // 读取 .lrc 文件内容
            return Lyrics.ParseFromLRC(lrcContent);           // 解析成 Lyrics 对象
        }

        // 显示歌词
        public void DisplayLyrics(Lyrics lyrics)
        {
            // TODO: 更新界面，滚动歌词显示
        }

        // 设置歌词显示模式
        public void SetLyricsMode(LyricsMode mode)
        {
            _lyricsMode = mode;
        }


        // 补充：是否正在播放
        public bool IsPlaying()
        {
            return _isPlaying;
        }

        // 补充：获取当前歌曲
        public Song GetCurrentSong()
        {
            return _currentSong;
        }

        // 补充：获取当前播放进度
        public TimeSpan GetCurrentPosition()
        {
            return _currentPosition;
        }

        public LyricsMode GetLyricsMode()
        {
            return _lyricsMode;
        }

        // 补充：播放下一首
        public void PlayNext()
        {
            if (_playlist.Count == 0) return;

            if (_playbackMode == PlaybackMode.Shuffle)
            {
                var rand = new Random();
                _currentIndex = rand.Next(_playlist.Count);
            }
            else
            {
                _currentIndex = (_currentIndex + 1) % _playlist.Count;
            }

            _currentSong = _playlist[_currentIndex];
            PlaySong(_currentSong);
        }

        // 补充：播放上一首
        public void PlayPrevious()
        {
            if (_playlist.Count == 0) return;

            if (_playbackMode == PlaybackMode.Shuffle)
            {
                var rand = new Random();
                _currentIndex = rand.Next(_playlist.Count);
            }
            else
            {
                _currentIndex = (_currentIndex - 1 + _playlist.Count) % _playlist.Count;
            }

            _currentSong = _playlist[_currentIndex];
            PlaySong(_currentSong);
        }
    }
}
