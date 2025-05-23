# 🎶 Byte-Harmonic — 让音乐更纯粹 🎵

------

> 一个基于 C# WinForms + SunnyUI 的本地音乐播放器，轻量、优雅，专为 Windows 桌面端打造。

## 📚 核心模块概览

- **播放控制系统**：播放、暂停、进度跳转、模式切换
- **搜索系统**：关键字检索，历史记录管理
- **用户系统**：登录注册，收藏功能
- **曲库管理**：本地导入导出，标签管理
- **界面系统**：基于 SunnyUI 的统一设计

------

## 🌟 特色功能 Features

- 🎵 本地音乐播放（支持顺序播放、随机播放、单曲循环）
- 📝 歌词同步滚动显示，支持纯净模式
- 🔍 按歌曲名/歌手搜索，记录搜索历史
- 📚 歌曲与歌单管理（导入/导出，标签分类）
- 💾 收藏歌曲、收藏歌单
- 🧩 简洁美观的 UI，基于 `SunnyUI`

------

## 📦 技术栈 Tech Stack

- **语言**：C#
- **框架**：.NET Framework / WinForms
- **UI**：SunnyUI
- **数据库**：MySQL

## 🛠️ 环境搭建与运行

1. **确保本地环境具备 MySQL 数据库**：

   * 请确保你已经安装并配置好 MySQL 服务，且能够成功连接。

2. **配置数据库凭据**：

   * 在项目根目录下，创建一个 `passwd.txt` 文件，内容为 MySQL 的数据库密码。如果没有设置数据库密码，请跳过此步骤。

3. **项目运行**：

   * 使用 Visual Studio 2022 打开项目。
   * 在 Debug 模式下运行，Visual Studio 控制台将输出调试信息，帮助你监控程序状态。

