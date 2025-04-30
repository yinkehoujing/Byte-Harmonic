using System;
using System.Collections.Generic;
using System.IO;
using Byte_Harmonic.Models;
using NAudio.Wave;

namespace Services
{
    public class PlaybackService : IDisposable
    {
        private Playlist _playlist;
        private Song? _currentSong;
        private int _currentIndex = -1;
        private LyricsMode _lyricsMode = LyricsMode.Normal;
        private double _playbackSpeed = 1.0;
        private IWavePlayer? _outputDevice;
        private AudioFileReader? _audioReader;
        private bool _isPaused = false;
        private bool _isStopping = false;

        public bool IsPaused => _isPaused;

        public PlaybackService()
        {
            Console.WriteLine("PlaybackService().....");
            _playlist = new Playlist();
        }

        public void PlayPlaylist(int start_index = 0)
        {
            if (_playlist.PlaySongs.Count == 0)
                return;

            _currentIndex = start_index;
            PlaySong(_playlist.PlaySongs[_currentIndex]);
        }

        // playlist 选择一个 song, 交给 PlaySong 去 play
        public void PlaySong(Song song)
        {
            if (song == null) throw new ArgumentNullException(nameof(song));

            if (song.Lyrics == null)
            {
                // 从数据库或路径加载歌词
                string path = "hhh"; // TODO: 替换为真实路径
                song.LoadLyrics(path);
            }

            Console.WriteLine($"Playing {song.Title}, Author is {song.Artist}");

            // 先停止并清理当前播放
            StopInternal(); // Stop 函数绑定到 pick_next 上

            _currentSong = song;
            _currentIndex = _playlist.PlaySongs.IndexOf(song);
            _isPaused = false;

            if (string.IsNullOrEmpty(song.MusicFilePath) || !File.Exists(song.MusicFilePath))
            {
                throw new FileNotFoundException("歌曲文件未找到", song.MusicFilePath);
            }

            _audioReader = new AudioFileReader(song.MusicFilePath);
            _outputDevice = new WaveOutEvent();

            // 绑定事件前，先解绑一次，确保没有重复绑定
            _outputDevice.PlaybackStopped -= OnPlaybackStopped;
            // 这里先绑定事件, StopInternal 再解绑事件
            _outputDevice.PlaybackStopped += OnPlaybackStopped;

            _outputDevice.Init(_audioReader);
            _outputDevice.Play();
        }

        /// <summary>
        /// 当播放结束时回调，若不是暂停，自动播放下一首
        /// </summary>
        private void OnPlaybackStopped(object? sender, StoppedEventArgs e)
        {
            // playSong 会调用 device 的 playbackStopped
            if (!_isPaused && !_isStopping)
            {
                PlayNext();
            }
        }


        public void Pause()
        {
            _outputDevice?.Pause();
            _isPaused = true;
        }

        public void Resume()
        {
            _outputDevice?.Play();
            _isPaused = false;
        }

        // [[maybe used]], if used, should be changed
        public void Stop()
        {
            if (_outputDevice != null)
            {
                _outputDevice.PlaybackStopped -= OnPlaybackStopped;
                _outputDevice.Stop();
                _outputDevice.Dispose();
                _outputDevice = null;
            }

            if (_audioReader != null)
            {
                _audioReader.Dispose();
                _audioReader = null;
            }
        }

        private void StopInternal()
        {
            _isStopping = true; // 这是主动停止

            if (_outputDevice != null)
            {
                _outputDevice.PlaybackStopped -= OnPlaybackStopped;
                _outputDevice.Stop();
                _outputDevice.Dispose();
                _outputDevice = null;
            }

            if (_audioReader != null)
            {
                _audioReader.Dispose();
                _audioReader = null;
            }

            _isStopping = false; // 恢复标志
        }


        public void SeekTo(TimeSpan position)
        {
            if (_audioReader != null)
            {
                _audioReader.CurrentTime = position;
            }
        }

        public TimeSpan GetCurrentPosition()
        {
            return _audioReader?.CurrentTime ?? TimeSpan.Zero;
        }

        public Song? GetCurrentSong()
        {
            return _currentSong;
        }

        public void SetPlaylist(Playlist playlist)
        {
            Console.WriteLine("reached SetPlaylist....");
            Console.WriteLine($"{playlist.PlaybackMode}");
            _playlist = playlist;
            _currentIndex = -1;
            _currentSong = null;
        }

        public Playlist GetPlaylist()
        {
            return _playlist;
        }

        public void AddSong(Song song)
        {
            _playlist.PlaySongs.Add(song);
        }

        public void RemoveSong(Song song)
        {
            _playlist.PlaySongs.Remove(song);
        }

        public void SetPlaybackMode(PlaybackMode mode)
        {
            _playlist.PlaybackMode = mode;
        }

        public PlaybackMode GetPlaybackMode()
        {
            return _playlist.PlaybackMode;
        }

        public void SetLyricsMode(LyricsMode mode)
        {
            _lyricsMode = mode;
        }

        public LyricsMode GetLyricsMode()
        {
            return _lyricsMode;
        }

        public void SetPlaybackSpeed(double speed)
        {
            if (speed <= 0)
                throw new ArgumentException("播放速度必须大于 0");
            _playbackSpeed = speed;
        }

        public double GetPlaybackSpeed()
        {
            return _playbackSpeed;
        }

        public void PlayNext()
        {
            Console.WriteLine("touched here!");
            Console.WriteLine($"{_playlist.PlaybackMode}");
            if (_playlist.PlaySongs.Count == 0) return;

            if (_playlist.PlaybackMode == PlaybackMode.Shuffle)
            {
                var rand = new Random();
                _currentIndex = rand.Next(_playlist.PlaySongs.Count);
            }
            else if(_playlist.PlaybackMode == PlaybackMode.RepeatOne)
            {
                // 不变
            } 
            else
            {
                _currentIndex = (_currentIndex + 1) % _playlist.PlaySongs.Count;
            }

            PlaySong(_playlist.PlaySongs[_currentIndex]);
        }

        public void PlayPrevious()
        {
            if (_playlist.PlaySongs.Count == 0) return;

            if (_playlist.PlaybackMode == PlaybackMode.Shuffle)
            {
                var rand = new Random();
                _currentIndex = rand.Next(_playlist.PlaySongs.Count);
            }
            else if(_playlist.PlaybackMode == PlaybackMode.RepeatOne)
            {
                // 不变
            }
            else
            {
                _currentIndex = (_currentIndex - 1 + _playlist.PlaySongs.Count) % _playlist.PlaySongs.Count;
            }

            PlaySong(_playlist.PlaySongs[_currentIndex]);
        }

        public LyricsLine? GetCurrentLyricsLine()
        {
            if (_currentSong?.Lyrics == null)
                return null;

            return _currentSong.Lyrics.GetCurrentLine(GetCurrentPosition());
        }

        public void Dispose()
        {
            StopInternal();
        }
    }
}
