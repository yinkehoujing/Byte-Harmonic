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
    using System;
    using System.Collections.Generic;
    using System.IO;
    using ByteHarmonic.Models;
    using NAudio.Wave;
        public class PlaybackService : IDisposable
        {
            private List<Song> _playlist = new List<Song>();
            private Song? _currentSong;
            private int _currentIndex = -1;
            private PlaybackMode _playbackMode = PlaybackMode.Sequential;
            private LyricsMode _lyricsMode = LyricsMode.Normal;
            private double _playbackSpeed = 1.0;
            private IWavePlayer? _outputDevice;
            private AudioFileReader? _audioReader;

            public bool IsPlaying => _outputDevice?.PlaybackState == PlaybackState.Playing;

            public void PlaySong(Song song)
            {
                StopInternal(); // 停止当前歌曲
                _currentSong = song;
                _currentIndex = _playlist.IndexOf(song);

                if (string.IsNullOrEmpty(song.FilePath) || !File.Exists(song.FilePath))
                    throw new FileNotFoundException("歌曲文件未找到", song.FilePath);

                _audioReader = new AudioFileReader(song.FilePath);
                _outputDevice = new WaveOutEvent();
                _outputDevice.Init(_audioReader);
                _outputDevice.PlaybackStopped += (s, e) => { /* 可以处理播放结束，比如自动下一首 */ };
                _outputDevice.Play();
            }

            public void Pause()
            {
                _outputDevice?.Pause();
            }

            public void Resume()
            {
                _outputDevice?.Play();
            }

            public void Stop()
            {
                StopInternal();
            }

            private void StopInternal()
            {
                if (_outputDevice != null)
                {
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

            public void SetPlaylist(List<Song> playlist)
            {
                _playlist = playlist;
                _currentIndex = -1;
                _currentSong = null;
            }

            public List<Song> AddToPlaylist(Song song)
            {
                _playlist.Add(song);
                return _playlist;
            }

            public List<Song> RemoveFromPlaylist(Song song)
            {
                _playlist.Remove(song);
                return _playlist;
            }

            public List<Song> GetCurrentPlaylist()
            {
                return _playlist;
            }

            public void SetPlaybackMode(PlaybackMode mode)
            {
                _playbackMode = mode;
            }

            public PlaybackMode GetPlaybackMode()
            {
                return _playbackMode;
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
                // ⚠️ 注意：NAudio不直接支持变速播放，需要额外处理（可后续扩展）
            }

            public double GetPlaybackSpeed()
            {
                return _playbackSpeed;
            }

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

                PlaySong(_playlist[_currentIndex]);
            }

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

                PlaySong(_playlist[_currentIndex]);
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
