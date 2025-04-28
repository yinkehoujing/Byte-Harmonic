SET NAMES utf8mb4;

-- 创建数据库（如果不存在）
DROP DATABASE IF EXISTS `Byte_Harmonic`;

CREATE DATABASE IF NOT EXISTS `Byte_Harmonic` CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
USE `Byte_Harmonic`;


-- 删除旧表
DROP TABLE IF EXISTS `SonglistSongs`;
DROP TABLE IF EXISTS `SearchHistory`;
DROP TABLE IF EXISTS `Playlists`;
DROP TABLE IF EXISTS `Favorites`;
DROP TABLE IF EXISTS `Lyrics`;
DROP TABLE IF EXISTS `SongTags`;
DROP TABLE IF EXISTS `Tags`;
DROP TABLE IF EXISTS `Songs`;
DROP TABLE IF EXISTS `Users`;

-- 创建 Songs（歌曲表）
CREATE TABLE IF NOT EXISTS `Songs` (
    `Id` INTEGER AUTO_INCREMENT PRIMARY KEY,  -- 歌曲 ID，自增
    `Title` TEXT NOT NULL,  -- 歌曲标题
    `Artist` TEXT NOT NULL, -- 歌手
    `MusicFilePath` TEXT NOT NULL, -- 音乐文件路径
    `LrcFilePath` TEXT,  -- 歌词文件路径
    `Downloaded` BOOLEAN,  -- 是否本地下载
    `Duration` INTEGER  -- 歌曲时长（秒）
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- 创建 Tags（标签表）
CREATE TABLE IF NOT EXISTS `Tags` (
    `Id` INTEGER AUTO_INCREMENT PRIMARY KEY,  -- 标签 ID，自增
    `Name` VARCHAR(255) NOT NULL  -- 标签名称，使用 VARCHAR 限制长度
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- 创建 SongTags（歌曲-标签多对多关系表）
CREATE TABLE IF NOT EXISTS `SongTags` (
    `SongId` INTEGER,  -- 外键：Songs.Id
    `TagId` INTEGER,  -- 外键：Tags.Id
    PRIMARY KEY (`SongId`, `TagId`),
    FOREIGN KEY (`SongId`) REFERENCES `Songs`(`Id`) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (`TagId`) REFERENCES `Tags`(`Id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- 创建 Lyrics（歌词表）
CREATE TABLE IF NOT EXISTS `Lyrics` (
    `SongId` INTEGER PRIMARY KEY,  -- 歌曲 ID，自增，外键
    `Content` TEXT,  -- 歌词内容
    FOREIGN KEY (`SongId`) REFERENCES `Songs`(`Id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- 创建 Users（用户表）
CREATE TABLE IF NOT EXISTS `Users` (
    `Account` VARCHAR(255) PRIMARY KEY,  -- 用户账户（使用 VARCHAR 限制长度）
    `Username` VARCHAR(255) NOT NULL,  -- 用户名（使用 VARCHAR 限制长度）
    `Password` TEXT NOT NULL,  -- 密码（哈希值）
    `IsAdmin` BOOLEAN  -- 是否管理员
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- 创建 Favorites（用户收藏歌曲表）
CREATE TABLE IF NOT EXISTS `Favorites` (
    `Username` VARCHAR(255),  -- 外键：Users.Account，使用 VARCHAR 限制长度
    `SongId` INTEGER,  -- 外键：Songs.Id
    PRIMARY KEY (`Username`, `SongId`),
    FOREIGN KEY (`Username`) REFERENCES `Users`(`Account`) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (`SongId`) REFERENCES `Songs`(`Id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- 创建 Playlists（歌单表）
CREATE TABLE IF NOT EXISTS `Playlists` (
    `Id` INTEGER AUTO_INCREMENT PRIMARY KEY,  -- 歌单 ID，自增
    `Name` VARCHAR(255) NOT NULL,  -- 歌单名称，使用 VARCHAR 限制长度
    `Owner` VARCHAR(255),  -- 所有者账户，使用 VARCHAR 限制长度
    FOREIGN KEY (`Owner`) REFERENCES `Users`(`Account`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- 创建 SonglistSongs（歌单-歌曲多对多关系表）
CREATE TABLE IF NOT EXISTS `SonglistSongs` (
    `SonglistId` INTEGER,  -- 外键：Playlists.Id
    `SongId` INTEGER,  -- 外键：Songs.Id
    PRIMARY KEY (`SonglistId`, `SongId`),
    FOREIGN KEY (`SonglistId`) REFERENCES `Playlists`(`Id`) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (`SongId`) REFERENCES `Songs`(`Id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- 创建 SearchHistory（搜索历史表）
CREATE TABLE IF NOT EXISTS `SearchHistory` (
    `Username` VARCHAR(255),  -- 外键：Users.Account，使用 VARCHAR 限制长度
    `Keyword` TEXT,  -- 搜索关键词
    `Time` DATETIME,  -- 搜索时间
    FOREIGN KEY (`Username`) REFERENCES `Users`(`Account`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
