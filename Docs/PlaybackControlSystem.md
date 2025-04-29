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
## 相关数据库表

