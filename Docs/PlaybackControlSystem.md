# Playback Control System

## 功能概览

- **播放**：点击可播放单曲、歌单、专辑中的音频文件。
- **暂停**：用户可在任意时间暂停当前播放音乐。
- **跳转（进度控制）**：通过拖动进度条或点击进度条区域实现跳播。
- **播放模式**：支持顺序播放、随机播放、单曲循环三种模式。
- **倍速播放**：支持选择播放速度（如 1.0x、1.25x、1.5x、2.0x）。 --> 可能废弃
- **显示歌词**：歌词与当前播放歌曲同步显示，逐行滚动并高亮当前句。
- **歌词模式切换**： --> 可能废弃
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
- `Duration` 使用整数存储秒数，便于播放时处理

## PlaybackService 相关 API 介绍


### `PlaySong(Song song)`

**播放指定的歌曲。**

#### 参数
- `song` (`Song`)：要播放的歌曲对象。如果该歌曲没有歌词信息，会尝试加载。

#### 返回值
- 无

---

### `Pause()`

**暂停当前正在播放的歌曲。**

#### 参数
- 无

#### 返回值
- 无

---

### `Resume()`

**继续播放已暂停的歌曲。**

#### 参数
- 无

#### 返回值
- 无

---

### `Stop()`

**停止当前歌曲的播放，并释放相关资源。**

#### 参数
- 无

#### 返回值
- 无

---

### `SeekTo(TimeSpan position)`

**跳转到歌曲的指定播放时间位置。**

#### 参数
- `position` (`TimeSpan`)：需要跳转到的时间位置。

#### 返回值
- 无

---

### `GetCurrentPosition()`

**获取当前歌曲的播放位置。**

#### 参数
- 无

#### 返回值
- `TimeSpan`：当前播放的时间点，如果没有歌曲播放，则为`00:00:00`。

---

### `GetCurrentSong()`

**获取当前正在播放的歌曲对象。**

#### 参数
- 无

#### 返回值
- `Song?`：当前播放的歌曲对象，如果没有正在播放的歌曲，返回 `null`。

---

### `SetPlaylist(List<Song> playlist)`

**设置新的播放列表，并清空当前播放状态。**

#### 参数
- `playlist` (`List<Song>`)：要设置的新播放列表。

#### 返回值
- 无

---

### `AddToPlaylist(Song song)`

**向播放列表中添加一首歌曲。**

#### 参数
- `song` (`Song`)：要添加到播放列表的歌曲对象。

#### 返回值
- `List<Song>`：添加后的播放列表。

---

### `RemoveFromPlaylist(Song song)`

**从播放列表中移除一首歌曲。**

#### 参数
- `song` (`Song`)：要从播放列表中移除的歌曲对象。

#### 返回值
- `List<Song>`：移除后的播放列表。

---

### `GetCurrentPlaylist()`

**获取当前播放列表。**

#### 参数
- 无

#### 返回值
- `List<Song>`：当前播放列表。

---

### `SetPlaybackMode(PlaybackMode mode)`

**设置播放模式（如顺序播放、随机播放等）。**

#### 参数
- `mode` (`PlaybackMode`)：要设置的播放模式。

#### 返回值
- 无

---

### `GetPlaybackMode()`

**获取当前的播放模式。**

#### 参数
- 无

#### 返回值
- `PlaybackMode`：当前的播放模式。

---

### `SetLyricsMode(LyricsMode mode)`

**设置歌词模式（如普通歌词、逐字歌词等）。**

#### 参数
- `mode` (`LyricsMode`)：要设置的歌词模式。

#### 返回值
- 无

---

### `GetLyricsMode()`

**获取当前的歌词模式。**

#### 参数
- 无

#### 返回值
- `LyricsMode`：当前歌词模式。

---

### `SetPlaybackSpeed(double speed)`

**设置播放速度。**

#### 参数
- `speed` (`double`)：播放速度倍数，必须大于 0。

#### 返回值
- 无

---

### `GetPlaybackSpeed()`

**获取当前设置的播放速度。**

#### 参数
- 无

#### 返回值
- `double`：当前播放速度。

---

### `PlayNext()`

**播放下一首歌曲。根据播放模式决定顺序或随机。**

#### 参数
- 无

#### 返回值
- 无

---

### `PlayPrevious()`

**播放上一首歌曲。根据播放模式决定顺序或随机。**

#### 参数
- 无

#### 返回值
- 无

---

### `GetCurrentLyricsLine()`

**获取当前时间对应的歌词行。**

#### 参数
- 无

#### 返回值
- `LyricsLine?`：当前对应的歌词行，如果没有歌词或未播放则返回 `null`。

---

### `Dispose()`

**释放播放资源，停止播放。**

#### 参数
- 无

#### 返回值
- 无
