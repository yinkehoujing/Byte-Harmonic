# Playback Control System

## 功能概览

- **播放**：点击可播放单曲、歌单、专辑中的音频文件。
- **暂停**：用户可在任意时间暂停当前播放音乐。
- **跳转（进度控制）**：通过拖动进度条或点击进度条区域实现跳播。
- **播放模式**：支持顺序播放、随机播放、单曲循环三种模式。
- **倍速播放**：支持选择播放速度（如 1.0x、1.25x、1.5x、2.0x）。
- **显示歌词**：歌词与当前播放歌曲同步显示，逐行滚动并高亮当前句。
- **歌词模式切换**：
  - 普通模式（显示界面+歌词）
  - 纯净模式（仅显示歌词）



## 业务逻辑简介

需要对应 **播放业务** 的 **表单** 可以按照下面的工作流程使用 播放控制系统 的业务功能：

- 注册 `playbackService` 对象和 `Timer` 对象，`PlaybackService` 对象用于播放逻辑， `Timer` 对象用于计时并更新歌词显示:

```csharp
	private System.Windows.Forms.Timer _timer;
	private System.Windows.Forms.Timer _log_timer;
	private PlaybackService _playbackService;

```

- 数据库准备好要播放的歌曲：(暂时从本地获取, 先获取 mp3, 再获取 lrc)

```csharp
var song = new Song
            {
                Title = "公子向北走",
                Artist = "花僮",
                MusicFilePath = FileHelper.GetAssetPath("Musics/example.mp3")
            };
song.LoadLyrics(FileHelper.GetAssetPath("Lyrics/example.lrc"));

```

- 注册 `PlaybackService` 对象的事件并启动计数器：

```csharp

	_playbackService.PlaySong(song);

```

- 通过 TimerHelper 工具类进行定时器的注册、暂停和取消：
```csharp

TimerHelper.SetupTimer(ref _timer, 100, (s, e) => UpdateLyrics());
```

- 在 `UpdateLyrics` 方法中更新歌词显示：
```csharp
var line = _playbackService.GetCurrentLyricsLine();
```
其中 `line.Text` 即是歌词文本。

## 相关实体类

`Song`:

```csharp
 public int Id { get; set; }
 public string Title { get; set; }
 public string Artist { get; set; }
 public bool Downloaded { get; set; }
 public string MusicFilePath { get; set; }
 public string LrcFilePath { get; set; }
 public int Duration { get; set; }
 public List<string> Tags { get; set; }
 public Lyrics Lyrics { get; private set; }

```

`Lyrics`:

```c#
public class LyricsLine
{
    public TimeSpan Time { get; set; }  // 歌词出现的时间点
    public string Text { get; set; }    // 歌词文本
}
// 仅有这一个成员:
private List<LyricsLine> _lines = new List<LyricsLine>();
```

## 相应数据访问层接口

### SongRepository 方法列表

- `bool AddSong(Song song)`
- `Song GetSongById(int id)`
- `Song GetSongByTitle(string title)`
- `bool UpdateSong(Song song)`
- `bool DeleteSong(int id)`
- 仍需补充，如 `GetAllSongs()` 等方法。



## 相关数据库表

### `Lyrics` 表

已废弃！！！

### `Songs` 表结构

| 字段名          | 类型    | 约束       | 描述                       |
| --------------- | ------- | ---------- | -------------------------- |
| `Id`            | INTEGER | 主键，自增 | 歌曲 ID，唯一标识每首歌曲  |
| `Title`         | TEXT    | NOT NULL   | 歌曲标题                   |
| `Artist`        | TEXT    | NOT NULL   | 歌手名                     |
| `MusicFilePath` | TEXT    | NOT NULL   | 音乐文件在本地或远程的路径 |
| `LrcFilePath`   | TEXT    | 可为 NULL  | 歌词文件路径（.lrc）       |
| `Downloaded`    | BOOLEAN |            | 是否已经下载到本地         |
| `Duration`      | INTEGER |            | 歌曲时长（单位：秒）       |

------

#### 说明

- 所有文本字段采用 `utf8mb4` 编码，支持中文与表情。
- `Id` 为自增主键，确保每首歌曲的唯一性。
- 歌词可选（`LrcFilePath` 可为 null），以支持纯音乐或未获取歌词的情况。
- `Downloaded` 字段可用于区分在线歌曲和本地缓存。
- `Duration` 使用整数存储秒数，便于播放时处理。实际上未使用

## PlaybackService 相关 API 介绍

### `GetCurrentPosition()`

**获取当前歌曲的播放位置。**

#### 参数

- 无

#### 返回值

- `TimeSpan`：当前播放的时间点，如果没有歌曲播放，则为 `00:00:00`。

------

### `PlayPlaylist(int start_index = 0)`

**从指定索引开始播放播放列表中的歌曲。**

#### 参数

- `start_index` (`int`)：播放的起始索引，默认为 0。

#### 返回值

- 无

------

### `PlaySong(Song song)`

**播放指定的歌曲。**

#### 参数

- `song` (`Song`)：要播放的歌曲对象，不能为空。

#### 返回值

- 无

------

### `Pause()`

**暂停当前播放。**

#### 参数

- 无

#### 返回值

- 无

------

### `Resume()`

**恢复播放被暂停的歌曲。**

#### 参数

- 无

#### 返回值

- 无

------

### `Stop()`

**停止当前播放并释放相关资源。**

#### 参数

- 无

#### 返回值

- 无

------

### `SeekTo(TimeSpan position)`

**跳转到指定的时间点播放。**

#### 参数

- `position` (`TimeSpan`)：目标时间点。

#### 返回值

- 无

------

### `GetCurrentSong()`

**获取当前正在播放的歌曲对象。**

#### 参数

- 无

#### 返回值

- `Song?`：当前播放的歌曲，如果没有播放则为 `null`。

------

### `SetPlaylist(Playlist playlist)`

**设置当前播放的播放列表。**

#### 参数

- `playlist` (`Playlist`)：新的播放列表对象。

#### 返回值

- 无

------

### `GetPlaylist()`

**获取当前播放的播放列表。**

#### 参数

- 无

#### 返回值

- `Playlist`：当前播放列表对象。

------

### `AddSong(Song song)`

**向播放列表添加一首歌曲。**

#### 参数

- `song` (`Song`)：要添加的歌曲对象。

#### 返回值

- 无

------

### `RemoveSong(Song song)`

**从播放列表中移除一首歌曲。**

#### 参数

- `song` (`Song`)：要移除的歌曲对象。

#### 返回值

- 无

------

### `SetPlaybackMode(PlaybackMode mode)`

**设置播放模式。**

#### 参数

- `mode` (`PlaybackMode`)：播放模式（如顺序播放、单曲循环、随机播放等）。

#### 返回值

- 无

------

### `GetPlaybackMode()`

**获取当前的播放模式。**

#### 参数

- 无

#### 返回值

- `PlaybackMode`：当前播放模式。

------

### `SetLyricsMode(LyricsMode mode)`

**设置歌词显示模式。**

#### 参数

- `mode` (`LyricsMode`)：歌词模式。

#### 返回值

- 无

------

### `GetLyricsMode()`

**获取当前歌词显示模式。**

#### 参数

- 无

#### 返回值

- `LyricsMode`：当前歌词模式。

------

### `SetPlaybackSpeed(double speed)`

**设置播放速度。**

#### 参数

- `speed` (`double`)：播放速度，必须大于 0。

#### 返回值

- 无

------

### `GetPlaybackSpeed()`

**获取当前播放速度。**

#### 参数

- 无

#### 返回值

- `double`：当前播放速度。

------

### `PlayNext()`

**播放下一首歌曲。根据当前播放模式自动选择下一首。**

#### 参数

- 无

#### 返回值

- 无

------

### `PlayPrevious()`

**播放上一首歌曲。根据当前播放模式自动选择上一首。**

#### 参数

- 无

#### 返回值

- 无

------

### `GetCurrentLyricsLine()`

**获取当前时间点对应的歌词行。**

#### 参数

- 无

#### 返回值

- `LyricsLine?`：当前时间点的歌词行，如果没有歌词或没有匹配的行则为 `null`。

------

### `Dispose()`

**释放播放资源。**

#### 参数

- 无

#### 返回值

- 无
