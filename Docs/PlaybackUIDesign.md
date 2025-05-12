## 文档说明：`AppContext` 类

### 所在模块

命名空间：`Byte_Harmonic.Forms`
功能范围：贯穿整个音乐播放器的核心运行状态与事件处理。

---

## 核心职责

### 1. **服务和资源的初始化与持有**

`AppContext` 实例化并持有了应用程序的多个关键服务与仓储，包括：

* `PlaybackService`: 播放控制服务，负责播放、暂停、跳转等行为。
* `SongRepository`, `UserRepository`: 歌曲与用户的数据仓库。
* `UserService`, `SonglistService`, `SearchService`: 处理业务逻辑的服务。
* `SonglistRepository`: 管理歌单数据。

这些对象在用户登录后被统一管理，供全局使用。

---

### 2. **应用状态维护**

AppContext 维护了当前的应用状态，例如：

* `currentUser`: 当前登录用户
* `currentViewingSonglist`: 当前查看的歌单
* 下载设置（路径和命名方式）

---

### 3. **UI 更新事件发布中心**

`AppContext` 使用大量的 `static event` 定义 UI 更新的广播机制，例如：

| 事件名称                  | 描述              |
| --------------------- | --------------- |
| `updateSongUI`        | 更新当前播放歌曲的基本信息显示 |
| `LyricsUpdated`       | 歌词内容与当前播放时间     |
| `PositionChanged`     | 进度条位置更新         |
| `VolumeChanged`       | 音量变化            |
| `SonglistLoaded`      | 播放列表加载完成        |
| `PlaybackModeChanged` | 播放模式图标更新        |
| `ReloadSideSonglist`  | 重新加载侧边栏歌单列表     |

这些事件以 **发布-订阅模式** 连接 UI 层和逻辑层，避免强耦合。

---

### 4. **播放控制逻辑封装**

`AppContext` 提供了如下播放控制的封装方法：

* `TogglePlayPause()`：播放 / 暂停切换（自动管理 Timer）
* `TogglePlayPauseSong(Song)`：指定歌曲的播放 / 暂停
* `TriggerPlaybackSpeedChanged(double)`：响应播放速度变化

---

### 5. **定时器管理**

内置两个定时器：

* `_timer`: 每 500ms 更新歌词信息
* `_log_timer`: 每秒打印播放状态日志（调试用）

通过 `StartTimer()`、`StopTimer()`、`RestartTimer()` 控制启动与关闭。

