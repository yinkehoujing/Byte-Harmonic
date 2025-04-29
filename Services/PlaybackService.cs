using System;
using System.Collections.Generic;
using System.IO;
using ByteHarmonic.Models;
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

        public bool IsPaused => _isPaused;

        public PlaybackService()
        {
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
            if (song.Lyrics == null)
            {
                // 从数据库或路径加载歌词
                string path = "hhh";
                song.LoadLyrics(path);
            }

            Console.WriteLine($"Playing {song.Title}, Author is {song.Artist}");

            StopInternal();
            _currentSong = song;
            _currentIndex = _playlist.PlaySongs.IndexOf(song);
            _isPaused = false;

            if (string.IsNullOrEmpty(song.MusicFilePath) || !File.Exists(song.MusicFilePath))
            {
                throw new FileNotFoundException("歌曲文件未找到", song.MusicFilePath);
            }

            _audioReader = new AudioFileReader(song.MusicFilePath);
            _outputDevice = new WaveOutEvent();
            _outputDevice.Init(_audioReader);
            _outputDevice.PlaybackStopped += (sender, e) =>
            {
                if (!_isPaused)
                {
                    PlayNext();
                }
            };
            _outputDevice.Play();
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

        public void Stop()
        {
            StopInternal();
        }

        private void StopInternal()
        {
            _outputDevice?.Stop();
            _outputDevice?.Dispose();
            _outputDevice = null;

            _audioReader?.Dispose();
            _audioReader = null;
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
            if (_playlist.PlaySongs.Count == 0) return;

            if (_playlist.PlaybackMode == PlaybackMode.Shuffle)
            {
                var rand = new Random();
                _currentIndex = rand.Next(_playlist.PlaySongs.Count);
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
