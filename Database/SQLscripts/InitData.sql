USE `Byte_Harmonic`;

-- 插入测试管理员账户
INSERT IGNORE INTO Users (Account, Username, Password, IsAdmin)
VALUES ('admin', 'admin', 'e10adc3949ba59abbe56e057f20f883e', TRUE);
-- 这里的密码是"123456"的md5哈希，开发测试可以这么用

-- 插入测试歌曲
INSERT IGNORE INTO Songs (Id, Title, Artist, FilePath, Downloaded, Duration)
VALUES ('test_song_1', 'Test Song', 'Test Artist', '/music/test_song.mp3', TRUE, 210);

-- 插入测试歌词
INSERT IGNORE INTO Lyrics (SongId, Content)
VALUES ('test_song_1', '[00:00.00] 测试歌词第一行\n[00:15.00] 测试歌词第二行');

-- 插入测试标签
INSERT IGNORE INTO Tags (Name)
VALUES ('流行');

-- 将标签关联到测试歌曲
INSERT IGNORE INTO SongTags (SongId, TagId)
VALUES ('test_song_1', 1);  -- 注意这里假设上面插入的标签ID是1（因为AUTO_INCREMENT从1开始）

-- 插入测试歌单
INSERT IGNORE INTO Playlists (Name, Owner)
VALUES ('我的收藏', 'admin');

-- 将测试歌曲加入到测试歌单
INSERT IGNORE INTO SonglistSongs (SonglistId, SongId)
VALUES (1, 'test_song_1'); -- 同理，假设歌单ID也是1
