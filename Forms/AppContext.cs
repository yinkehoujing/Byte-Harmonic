using Byte_Harmonic.Database;
using Byte_Harmonic.Models;
using Byte_Harmonic.Utils;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using Byte_Harmonic.Properties;

namespace Byte_Harmonic.Forms
{
    public class AppContext
    {
        public static System.Windows.Forms.Timer _timer = new System.Windows.Forms.Timer();
        public static System.Windows.Forms.Timer _log_timer = new System.Windows.Forms.Timer();
        public static PlaybackService _playbackService = new PlaybackService();
        public static SongRepository _songRepository = new SongRepository();


        // 只更新 UI 的事件
        public static event Action<Song> updateSongUI; // 更新歌曲显示信息, 歌名、作者
        public static event Action<string, TimeSpan> LyricsUpdated; // 参数：歌词文本、当前时间位置
        public static event Action<TimeSpan> PositionChanged; // 更新 label2, 进度条
        public static event Action<bool> ShowPlayingBtn; // 更新 label2, 进度条
        public static event Action<float> VolumeChanged; // 0 - 1 之间

        // 实际响应，修改 PlaybackService 对象
        public static event Action<double>? PlaybackSpeedChanged;
        public static event Action<List<Song>> PlaylistSetRequested; // 响应，设置初始的 Playlist
        public static event Action<PlaybackMode>? PlaybackModeChanged;



        public static void TriggerPositionChanged(TimeSpan ts)
        {
            Console.WriteLine("TriggerPositionChanged");
            PositionChanged?.Invoke(ts);
        }

        public static void TriggerVolumeChanged(float volumeValue)
        {
            Console.WriteLine("TriggerVolumeChanged");
            VolumeChanged?.Invoke(volumeValue);
        }

        public static void TriggerupdateSongUI(Song song)
        {
            Console.WriteLine("TriggerupdateSongUI");
            updateSongUI?.Invoke(song);
        }

        public static void TriggerShowPlayingBtn(bool showPlaying)
        {
            Console.WriteLine("TriggerShowPlayingBtn");
            ShowPlayingBtn?.Invoke(showPlaying);
        }


        // 触发 PlaybackSpeedChanged 事件
        public static void TriggerPlaybackSpeedChanged(double speed)
        {
            Console.WriteLine("TriggerPlaybackSpeedChanged");
            PlaybackSpeedChanged?.Invoke(speed);
        }

        // 触发 PlayNextRequested 事件
        public static void TriggerPlaylistSetRequested(List<Song> songs)
        {
            Console.WriteLine("TriggerPlaylistSetRequested");

            PlaylistSetRequested?.Invoke(songs);
        }


        public static void TriggerLyricsUpdated(string text, TimeSpan position)
        {
            //Console.WriteLine("触发 TriggerLyricsUpdated 事件");
            LyricsUpdated?.Invoke(text, position);
        }

        public static void OnPlaylistSet(List<Song> songs)
        {

        }


        public static void Initialize()
        {
            // 用于调试
            // 注册 LyricsUpdated 事件处理函数
            LyricsUpdated += OnLyricsUpdated;

            // 注册 PlaybackSpeedChanged 事件处理函数
            PlaybackSpeedChanged += OnPlaybackSpeedChanged;
            // 注册 PlaylistSetRequested 事件处理函数
            PlaylistSetRequested += OnPlaylistSetRequested;

            PlaybackModeChanged += OnPlaybackModeChanged;


        }

        private static void OnPlaybackModeChanged(PlaybackMode mode)
        {
            _playbackService.SetPlaybackMode(mode);
        }

        // 事件处理函数
        public static void OnPlaybackSpeedChanged(double speed)
        {
            Console.WriteLine($"Playback speed changed to {speed}");
            _playbackService.SetPlaybackSpeed(speed);
        }

        public static void StartTimer()
        {
            TimerHelper.SetupTimer(ref _timer, 500, (s, e) =>
            {
                if (AppContext._playbackService.GetCurrentSong() == null)
                {
                    throw new ArgumentNullException(nameof(AppContext._playbackService));
                }
                var lyricsLine = AppContext._playbackService.GetCurrentLyricsLine()?.Text ?? "[No Lyrics]";
                var position = AppContext._playbackService.GetCurrentPosition();

                AppContext.TriggerLyricsUpdated(lyricsLine, position);
            });

            TimerHelper.SetupTimer(ref _log_timer, 1000, (s, e) =>
            {
                var position = AppContext._playbackService.GetCurrentPosition();
                var lyricsLine = AppContext._playbackService.GetCurrentLyricsLine()?.Text ?? "[No Lyrics]";
                Console.WriteLine($"Current Time: {position}: {lyricsLine}");
            });
        }

        public static void OnSeekRequested(TimeSpan position)
        {
            Console.WriteLine($"Seek requested to position {position}");
        }

        public static void OnPlaylistSetRequested(List<Song> songs)
        {
            Console.WriteLine("Response to PlaylistSet");
            AppContext._playbackService.SetPlaylist(new Playlist(songs, PlaybackMode.Sequential));
        }

        public static void OnLyricsUpdated(string text, TimeSpan position)
        {
            //Console.WriteLine($"Lyrics updated: {text} at position {position}");
        }


        public static void TogglePlayPause()
        {

            Console.WriteLine("begin to Toggle PlayPause");
            if (AppContext._playbackService.GetCurrentSong() == null)
            {
                AppContext._playbackService.PlayPlaylist(0); // 假设从队首播放
                StartTimer(); // 没有对应地暂停 log_timer
                TriggerShowPlayingBtn(true);
            }
            else if (AppContext._playbackService.IsPaused)
            {
                AppContext._playbackService.Resume();
                TimerHelper.RestartTimer(ref AppContext._timer);
                TimerHelper.RestartTimer(ref AppContext._log_timer);
                TriggerShowPlayingBtn(true);
            }
            else
            {
                AppContext._playbackService.Pause();
                TimerHelper.StopTimer(ref AppContext._timer);
                TimerHelper.StopTimer(ref AppContext._log_timer);
                TriggerShowPlayingBtn(false);


            }
        }

        internal static void TriggerVolumeChanged(object getVolume)
        {
            throw new NotImplementedException();
        }
    }
}
