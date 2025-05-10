using Byte_Harmonic.Database;
using Byte_Harmonic.Models;
using Byte_Harmonic.Utils;
using Byte_Harmonic.Services;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using Byte_Harmonic.Properties;
using static Sunny.UI.SnowFlakeId;

namespace Byte_Harmonic.Forms
{
    public class AppContext
    {
        public static System.Windows.Forms.Timer _timer = new System.Windows.Forms.Timer();
        public static System.Windows.Forms.Timer _log_timer = new System.Windows.Forms.Timer();
        public static PlaybackService _playbackService = new PlaybackService();
        public static SongRepository _songRepository = new SongRepository();
        public static UserRepository userRepository = new UserRepository();

        // 登录后获得以下信息
        public static SonglistRepository songlistRepository = new SonglistRepository();
        public static UserService userService = new UserService(userRepository);
        public static SonglistService songlistService = new SonglistService(songlistRepository, userService);
        public static SearchService searchService = new SearchService(songlistRepository, userRepository, userService);
        public static User currentUser = null;
        public static Songlist currentViewingSonglist = null;


        // 只更新 UI 的事件
        public static event Action<Song> updateSongUI; // 更新歌曲显示信息, 歌名、作者
        public static event Action<string, TimeSpan> LyricsUpdated; // 参数：歌词文本、当前时间位置
        public static event Action<TimeSpan> PositionChanged; // 更新 label2, 进度条
        public static event Action<bool> ShowPlayingBtn; // 更新 label2, 进度条
        public static event Action<float> VolumeChanged; // 0 - 1 之间
        public static event Action SonglistLoaded; // 更新 panel2
        public static event Action<PlaybackMode> PlaybackModeChanged; // 更新 playbackMode 显示图标
        public static event Action ReloadSideSonglist;
        public static event Action ChangeSearchBox;// 更新搜索框是否显示与旁边按钮
        public static event Func<string, Task> SonglistDetailUpdated; // 更新歌单页详情
        public static event Action PlaylistUpdated;// 更新播放列表显示

        public static event Action DownloadUpdated;// 更新下载列表显示
        public static event Action StarUpdated; // 其它页面更新图标，探索页面更新图标
        public static event Action FavoriteUpdated; // 更新播放页显示


        // 实际响应，修改 PlaybackService 对象
        public static event Action<double>? PlaybackSpeedChanged;
        public static event Action<List<Song>> PlaylistSetRequested; // 响应，设置初始的 Playlist

        // 下载设置（下载路径和命名方式）
        public static string DownloadPath { get; private set; }
        public static int NamingStyle { get; private set; }

        //载入下载设置
        public static void LoadSettings()
        {
            var cfg = ConfigManager.Instance;
            DownloadPath = cfg.DownloadPath;
            NamingStyle = cfg.NamingStyle;
        }

        public static async Task TriggerSonglistDetailUpdated(string songlistName)
        {
            Console.WriteLine("TriggerSonglistDetailUpdated");

            if (SonglistDetailUpdated != null)
            {
                var handlers = SonglistDetailUpdated.GetInvocationList();
                foreach (Func<string, Task> handler in handlers)
                {
                    await handler.Invoke(songlistName);
                }
            }
        }

        public static void TriggerPositionChanged(TimeSpan ts)
        {
            Console.WriteLine("TriggerPositionChanged");
            PositionChanged?.Invoke(ts);
        }

        public static void TriggerPlaylistUpdated()
        {
            Console.WriteLine("TriggerPlaylistUpdated");
            PlaylistUpdated?.Invoke();
        }

        public static void TriggerDownloadUpdated()
        {
            Console.WriteLine("TriggerDownloadUpdated");
            DownloadUpdated?.Invoke();
        }

        public static void TriggerFavoriteUpdated()
        {
            Console.WriteLine("TriggerFavoriteUpdated");
            FavoriteUpdated?.Invoke();
        }

        public static void TriggerReloadSideSonglist()
        {
            Console.WriteLine("TriggerReloadSideSonglist");
            ReloadSideSonglist?.Invoke();
        }


        public static void TriggerPlaybackModeChanged(PlaybackMode playbackMode)
        {
            Console.WriteLine("TriggerPlaybackModeChanged");
            PlaybackModeChanged?.Invoke(playbackMode);
        }

        public static void TriggerSearchBoxChange()
        {
            ChangeSearchBox?.Invoke();
        }

        public static void TriggerVolumeChanged(float volumeValue)
        {
            Console.WriteLine("TriggerVolumeChanged");
            VolumeChanged?.Invoke(volumeValue);
        }

        public static void TriggerSonglistLoaded()
        {
            Console.WriteLine("TriggerSonglistLoaded");
            SonglistLoaded?.Invoke();
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
            //载入下载设置
            LoadSettings();
            // 用于调试
            // 注册 LyricsUpdated 事件处理函数
            LyricsUpdated += OnLyricsUpdated;

            // 注册 PlaybackSpeedChanged 事件处理函数
            PlaybackSpeedChanged += OnPlaybackSpeedChanged;
            // 注册 PlaylistSetRequested 事件处理函数
            PlaylistSetRequested += OnPlaylistSetRequested;



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
                // 刚好关中断时响应
                if (AppContext._playbackService.GetCurrentSong() == null)
                {
                    Console.WriteLine("currentsong is null");
                    //throw new ArgumentNullException(nameof(AppContext._playbackService));
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

        public static void TogglePlayPauseSong(Song song)
        {

            Console.WriteLine("begin to Toggle PlayPause");
            if (AppContext._playbackService.GetCurrentSong() == null || AppContext._playbackService.GetCurrentSong().Id != song.Id)
            {
                AppContext._playbackService.PlaySong(song); 
                StartTimer(); // 没有对应地暂停 log_timer, 重新计时
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


        public static void TriggerStarUpdated()
        {
            StarUpdated?.Invoke();
        }
    }
}
