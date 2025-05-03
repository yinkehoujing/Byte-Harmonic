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

        public static event Action<Song> updateSongUI;
        public static event Action<string, TimeSpan> LyricsUpdated; // 参数：歌词文本、当前时间位置


        // 只更新 UI 的事件
        public static event Action<double>? PlaybackSpeedChanged;
        public static event Action<TimeSpan> SeekRequested;
        public static event Action<List<Song>> PlaylistSetRequested;
        public static event Action<TimeSpan> PositionChanged; // 更新 label2, 进度条

        public static void TriggerPositionChanged(TimeSpan ts)
        {
            Console.WriteLine("TriggerPositionChanged");
            PositionChanged?.Invoke(ts);
        }

        public static void TriggerupdateSongUI(Song song)
        {
            Console.WriteLine("TriggerupdateSongUI");
            updateSongUI?.Invoke(song);
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


        // 触发 SeekRequested 事件
        public static void TriggerSeekRequested(TimeSpan position)
        {
            Console.WriteLine("触发 SeekRequested 事件");
            SeekRequested?.Invoke(position);
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
            // 注册 PlaybackSpeedChanged 事件处理函数
            PlaybackSpeedChanged += OnPlaybackSpeedChanged;

            // 注册 SeekRequested 事件处理函数
            SeekRequested += OnSeekRequested;

            // 注册 PlaylistSetRequested 事件处理函数
            PlaylistSetRequested += OnPlaylistSetRequested;

            // 注册 LyricsUpdated 事件处理函数
            LyricsUpdated += OnLyricsUpdated;
        }

        // 事件处理函数
        public static void OnPlaybackSpeedChanged(double speed)
        {
            Console.WriteLine($"Playback speed changed to {speed}");
        }

        public static void OnPlayNextRequested()
        {
            Console.WriteLine("Play next requested");
        }

        public static void OnPlayPreviousRequested()
        {
            Console.WriteLine("Play previous requested");
        }


        public static void StartTimer()
        {
            TimerHelper.SetupTimer(ref _timer, 500, (s, e) =>
            {
                if (AppContext._playbackService.GetCurrentSong() == null)
                {
                    Console.WriteLine("it's normal to touch here...But why?");
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
            }
            else if (AppContext._playbackService.IsPaused)
            {
                AppContext._playbackService.Resume();
                TimerHelper.RestartTimer(ref AppContext._timer);
                TimerHelper.RestartTimer(ref AppContext._log_timer);
            }
            else
            {
                AppContext._playbackService.Pause();
                TimerHelper.StopTimer(ref AppContext._timer);
                TimerHelper.StopTimer(ref AppContext._log_timer);

            }
        }
    }
}
