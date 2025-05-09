using System;
using System.Collections.Generic;
using System.IO;
using Byte_Harmonic.Models;
using NAudio.Wave;
using VarispeedDemo.SoundTouch;
using NAudio.Wave.SampleProviders;
using Byte_Harmonic.Database;
using Byte_Harmonic.Forms;
using Byte_Harmonic.Forms.MainForms;


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
        private VarispeedSampleProvider? _speedControl;

        //public event Action<Song> PlaybackStopped; // 更新 songName, aritist, duration 
        public event Action<Song> CurrentSongChanged; // the same as PlaybackStopped
        public event Action<bool> PlaybackPaused; // 更新图标
        public event Action<TimeSpan> PositionChanged; // 更新 label2, 进度条


        public bool IsPaused => _isPaused;

        public PlaybackMode PlaybackMode => _playlist.PlaybackMode;

        public AudioFileReader? audioFileReader => _audioReader;

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
            _currentSong = _playlist.PlaySongs[_currentIndex];
            PlaySong(_playlist.PlaySongs[_currentIndex]);
        }

        // playlist 选择一个 song, 交给 PlaySong 去 play
        public void PlaySong(Song song)
        {
            if (song == null) throw new ArgumentNullException(nameof(song));

            if (song.Lyrics == null)
            {
                throw new InvalidOperationException("歌词未加载");
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

            // 设置变速模式：true 为 Tempo（节奏不变，仅速度），false 为 Speed（连节奏一起变）
            bool useTempo = true;
            _speedControl = new VarispeedSampleProvider(_audioReader, 100, new SoundTouchProfile(useTempo, false));
            _speedControl.PlaybackRate = (float)_playbackSpeed;

            _outputDevice = new WaveOutEvent();
            _outputDevice.PlaybackStopped -= OnPlaybackStopped;
            _outputDevice.PlaybackStopped += OnPlaybackStopped;
            _outputDevice.Init(_speedControl);
            _outputDevice.Play();
        }

        /// <summary>
        /// 当播放结束时回调，若不是暂停，自动播放下一首
        /// </summary>
        private void OnPlaybackStopped(object? sender, StoppedEventArgs e)
        {

            Console.WriteLine($"PlaybackStopped: paused={_isPaused}, stopping={_isStopping}, error={e?.Exception?.Message}");

            // playSong 会调用 device 的 playbackStopped
            if (!_isPaused && !_isStopping)
            {

                PlayNext();

                var currentSong = _currentSong;

                // [[ maybe unused]]
                CurrentSongChanged?.Invoke(currentSong); // OnPlaySttoped 由 device 触发，此时主动触发委托(UI层已注册事件）
                Byte_Harmonic.Forms.AppContext.TriggerupdateSongUI(currentSong);
            }
        }

        public void Pause()
        {
            _outputDevice?.Pause();
            _isPaused = true;
            PlaybackPaused?.Invoke(true);
        }

        public void Resume()
        {
            _outputDevice?.Play();
            _isPaused = false;
            PlaybackPaused?.Invoke(false);
        }

        // [[maybe unused]]
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
                _speedControl?.Reposition(); // 通知 SoundTouch 重建缓冲
            }
            PositionChanged?.Invoke(position);
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
            Console.WriteLine($"Playback mode {mode} now");
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
            Console.WriteLine($"set playbackSpeed to {speed}.x");
            if (speed <= 0)
                throw new ArgumentException("播放速度必须大于 0");
            _playbackSpeed = speed;
            if (_speedControl != null)
            {
                _speedControl.PlaybackRate = (float)speed;
            }
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
            // 列表循环 和 顺序播放
            else
            {
                _currentIndex = (_currentIndex + 1) % _playlist.PlaySongs.Count;
            }

            PlaySong(_playlist.PlaySongs[_currentIndex]);
            CurrentSongChanged?.Invoke(GetCurrentSong()); // 通知所有订阅者 UI
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
            CurrentSongChanged?.Invoke(GetCurrentSong()); // 通知所有订阅者 UI

        }

        public LyricsLine? GetCurrentLyricsLine()
        {
            if (_currentSong?.Lyrics == null)
                return null;

            return _currentSong.Lyrics.GetCurrentLine(GetCurrentPosition());
        }

        public int GetCurrentIndex(TimeSpan ts)
        {
            if(_currentSong == null)
            {
                throw new ArgumentNullException(nameof(_currentSong));
            }
            return _currentSong.Lyrics.GetCurrentIndex(GetCurrentPosition());
        }

        public string GetLyricsTextByIndex(int index)
        {
            if (_currentSong == null)
            {
                throw new ArgumentNullException(nameof(_currentSong));
            }

            return _currentSong.Lyrics.GetLyricText(index);
        }

        public int GetCurrentLyricsCount()
        {
            if (_currentSong == null)
            {
                throw new ArgumentNullException(nameof(_currentSong));
            }
            return _currentSong.Lyrics.Count;

        }

        public void SetVolume(float volume)
        {
            Console.WriteLine($"set volume {volume}");
            if (volume < 0.0f || volume > 1f)
                throw new ArgumentOutOfRangeException(nameof(volume), "音量必须在 0.0 到 1.0 之间");


            if (_audioReader != null)
            {
                _audioReader.Volume = volume;
            }
            else
            {
              throw new ArgumentNullException(nameof(_audioReader));
            }
        }

        public float GetVolume()
        {
            if(_audioReader == null)
            {
                Console.WriteLine("not playing yet");
                return 1f;
            }
            if(_audioReader.Volume == 0f)
            {
                Console.WriteLine("0f ???"); return 0f;
            }
            return _audioReader.Volume;
        }


        public void Dispose()
        {
            StopInternal();

            _speedControl?.Dispose();
            _speedControl = null;

        }


    }
}
