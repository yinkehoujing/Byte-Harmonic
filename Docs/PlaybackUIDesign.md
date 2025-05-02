# Playback UI Design

## MainForm

- `MainForm` 自动载入 `ExploreForm`。
- `LoadPage` 会清空之前的页面
- `MainForm` 是一个空框架, 通过 `LoadPage` 来切换显示

## ExploreForm

- 注入 **单例** 的 `MusicForm` 对象 `_musicForm`, 确保只有一个页面能直接获取歌曲的播放资源，其它页面（比如 `ExploreForm`） 只能通过 **委托** 和 **事件** 与 **播放资源** 来交互

- 下面函数均是 `ExploreForm` 去 `invoke`, 而 `MusicForm` 去执行对应的委托，完成 **歌曲播放** 的 **代理**

 ```csharp
  public event Action<List<Song>>? PlaylistSet;
 
  public event Action<double>? PlaybackSpeedChanged;
  public event Action PlayNextRequested;
  public event Action PlayPreviousRequested;
  public event Action PlayPauseRequested;
  public event Action<TimeSpan> SeekRequested; // 以上用于 MusicForm交互
 ```

- 下面函数是 `ExploreForm` 的响应事件，主要是 `MusicForm` 通知去更新 UI 显示

```csharp
// 注册事件函数
_musicForm.LyricsUpdated += OnLyricsUpdated; // 更新进度条
_musicForm.updateSongUI += OnUpdateSongUI; // 更新歌手、曲名、歌曲时长
```

- 通过下面函数来唤起 **纯净模式** 的歌词视图。注意到 `WordForm` 也会通知 `ExploreForm` 去更新 UI;

```csharp
if (secondForm != null && !secondForm.IsDisposed)
{
    secondForm.Close();
    secondForm = null;
}
else
{
   // 获取最新（配套）的 music 句柄，这样UI操作的按钮才会正确响应
    secondForm = new WordForm(MusicForm.Instance(this));

    // 订阅操作请求事件
    var wordForm = (WordForm)secondForm;

    // 也通知 ExploreForm 的 UI
    wordForm.PlayNextRequested += () =>
    {
        PlayPreviousRequested?.Invoke();

    };

    wordForm.PlayPreviousRequested += () =>
    {
        PlayPreviousRequested?.Invoke();
    };

    wordForm.PlayPauseRequested += () => PlayPauseRequested?.Invoke(); // 先假设总是从队首开始播放;

    secondForm.Show();
}
```

## MusicForm

- 如果对应的 `ExploreForm` 没有析构掉，就使用原来的 `MusicForm` 句柄

```csharp
public static MusicForm Instance(ExploreForm exploreForm)
{
    if (_instance == null || _instance.IsDisposed)
        _instance = new MusicForm(exploreForm);
    return _instance;
}
```

- 通过注入 `ExploreForm` 对象，来响应对应发起的事件。

```csharp
// 响应歌曲资源的变化，调整对应的显示UI

 _playbackService.CurrentSongChanged += OnCurrentSongChanged;
 _playbackService.PlaybackPaused += OnPlaybackPaused;
 _playbackService.PositionChanged += UpdatePositionUI;

// 响应 ExploreForm 对象的 设置播放队列请求
 _exploreForm.PlaylistSet += OnPlaylistSet;

// 响应 ExploreForm 对象的 播放控制请求
 _exploreForm.PlayNextRequested += () =>
 {
     _playbackService.PlayNext();
     var current = _playbackService.GetCurrentSong();
     if(current == null)
     {
         Console.WriteLine("current song is null!");
         current = _playbackService.GetPlaylist().PlaySongs[0];
     }
     updateSongUI?.Invoke(current); // 反过来通知所有需要更新 SongUI 的对象
 };

 _exploreForm.PlayPreviousRequested += () =>
 {
     _playbackService.PlayPrevious();
     var current = _playbackService.GetCurrentSong();
     updateSongUI?.Invoke(current); // 反过来通知所有需要更新 SongUI 的对象
 };
 _exploreForm.PlayPauseRequested += TogglePlayPause;
 _exploreForm.SeekRequested += pos => _playbackService.SeekTo(pos);

 _exploreForm.LoadInitialSongs(); // invoke 之前注册的 PlaylistSet 事件(相当于等待注册，再 invoke)
```



## WordForm

- 总是和 最新（配套）的 `_musicForm` 句柄同步（即对应同一个 `ExploreForm`），保证发起事件的 `ExploreForm` 是 `WordForm` 注册的那个 `_exploreForm`
- `MusicForm` 去执行对应的委托

```csharp
public event Action PlayNextRequested;
public event Action PlayPreviousRequested;
public event Action PlayPauseRequested;
public event Action<TimeSpan> SeekRequested; // 以上用于 MusicForm 和 Service 交互
```

- 只需要响应 **歌词更新** 的事件

```csharp
// 订阅歌词更新事件
musicForm.LyricsUpdated += OnLyricsUpdated;

// 窗体关闭时取消订阅
this.FormClosed += (s, e) =>
musicForm.LyricsUpdated -= OnLyricsUpdated;
```

