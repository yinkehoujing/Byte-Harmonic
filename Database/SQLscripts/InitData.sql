-- 插入测试管理员账户
INSERT IGNORE INTO `Users` (`Account`, `Username`, `Password`, `IsAdmin`)
VALUES ('admin', 'admin', 'e10adc3949ba59abbe56e057f20f883e', TRUE);  -- 密码是 "123456" 的 MD5 哈希值

-- 插入测试歌曲
INSERT IGNORE INTO `Songs` (`Title`, `Artist`, `MusicFilePath`, `LrcFilePath`, `Downloaded`, `Duration`)
VALUES ('test-title', 'test-singer', '/music/test_song.mp3', '/lyrics/test_song.lrc', TRUE, 210);

-- 插入测试歌词
INSERT IGNORE INTO `Lyrics` (`SongId`, `Content`)
VALUES (1, '[00:00.00] 测试歌词第一行\n[00:15.00] 测试歌词第二行');  -- 假设歌ID为1

-- 插入测试标签
INSERT IGNORE INTO `Tags` (`Name`)
VALUES ('流行');

-- 将标签关联到测试歌曲
INSERT IGNORE INTO `SongTags` (`SongId`, `TagId`)
VALUES (1, 1);  -- 假设歌曲 ID 为 1，标签 ID 为 1

-- 插入测试歌单
INSERT IGNORE INTO `Playlists` (`Name`, `Owner`)
VALUES ('我的收藏', 'admin');

-- 将测试歌曲加入到测试歌单
INSERT IGNORE INTO `SonglistSongs` (`SonglistId`, `SongId`)
VALUES (1, 1);  -- 假设歌单 ID 为 1，歌曲 ID 为 1
