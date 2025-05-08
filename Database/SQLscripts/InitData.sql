SET NAMES utf8mb4;

-- 插入歌曲
INSERT INTO Songs (Title, Artist, MusicFilePath, LrcFilePath, Downloaded, Duration)
VALUES 
('天外来物', '薛之谦','Musics/tianwailaiwu.mp3','Lyrics/tianwailaiwu.lrc',1, 240+17),
('传奇', '王菲','Musics/chuanqi_wangfei.mp3','Lyrics/chuanqi_wangfei.lrc',1, 240+56),
('海阔天空', 'Beyond','Musics/haikuotiankong.mp3','Lyrics/haikuotiankong.lrc',1, 300+7),
('最炫民族风', '凤凰传奇','Musics/zuixuanminzufeng.mp3','Lyrics/zuixuanminzufeng.lrc',1, 240+44),
('公子向北走', '花僮', 'Musics/example.mp3', 'Lyrics/example.lrc', 1, 244),
('一笑江湖', '闻人听书', 'Musics/example2.mp3', 'Lyrics/example2.lrc', 1, 120+46),
('探故知', '浅影阿', 'Musics/example3.mp3', 'Lyrics/example3.lrc', 1, 180+4),
('如愿', '王菲','Musics/ruyuan_wangfei.mp3','Lyrics/ruyuan_wangfei.lrc',1, 240+25),
('传奇', '李健','Musics/chuanqi_lijian.mp3','Lyrics/chuanqi_lijian.lrc',1, 240+54);

-- 插入初始管理员
-- 管理员密码为123456789
INSERT INTO Users (Account, Username, Password, IsAdmin)
VALUES 
('admin', '管理员', 'argon2id:4:4:65536:S3N1vILMxrTJYeKF17oXxQ==:xiLKTDg0oQ+fImOudiK9dXOAOX9dKA/T7KIsi6PVDa0=', 1);

-- 插入歌单：流行精选
INSERT INTO Playlists (Name, Owner)
VALUES ('流行精选', 'admin');

INSERT INTO Playlists (Name, Owner)
VALUES ('华语金曲', 'admin');

INSERT INTO Playlists (Name, Owner)
VALUES ('摇滚年代', 'admin');

INSERT INTO Playlists (Name, Owner)
VALUES ('古风系列', 'admin');

INSERT INTO Playlists (Name, Owner)
VALUES ('本周最热', 'admin');


INSERT INTO SonglistSongs (SonglistId, SongId)
VALUES
(1, 1),  -- 天外来物
(1, 2),  -- 传奇（王菲）
(1, 8);  -- 如愿

INSERT INTO SonglistSongs (SonglistId, SongId)
VALUES
(2, 3),  
(2, 4),  
(2, 8);  

INSERT INTO SonglistSongs (SonglistId, SongId)
VALUES
(3, 4),  
(3, 6),  
(3, 7);  

INSERT INTO SonglistSongs (SonglistId, SongId)
VALUES
(4, 5),  
(4, 6),  
(4, 7);  

INSERT INTO SonglistSongs (SonglistId, SongId)
VALUES
(5, 1),  
(5, 8),  
(5, 9);  

