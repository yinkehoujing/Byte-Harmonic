SET NAMES utf8mb4;

-- 插入歌曲
INSERT INTO Songs (Title, Artist, MusicFilePath, LrcFilePath, Downloaded, Duration)
VALUES 
('天外来物', '薛之谦','Musics/tianwailaiwu.mp3','Lyrics/tianwailaiwu.lrc',1, 240+17), 
('传奇', '王菲','Musics/chuanqi_wangfei.mp3','Lyrics/chuanqi_wangfei.lrc',1, 240+56),
('海阔天空', 'Beyond','Musics/haikuotiankong.mp3','Lyrics/haikuotiankong.lrc',1, 300+7),
('最炫民族风', '凤凰传奇','Musics/zuixuanminzufeng.mp3','Lyrics/zuixuanminzufeng.lrc',1, 240+44),
('霜雪千年', '双笙', 'Musics/shuangxueqiannian.mp3', 'Lyrics/shuangxueqiannian.lrc', 1, 246),
('美人画卷', '闻人听书', 'Musics/meirenhuajuan.mp3', 'Lyrics/meirenhuajuan.lrc', 1, 180+28),
('探故知', '浅影阿', 'Musics/example3.mp3', 'Lyrics/example3.lrc', 1, 180+21),
('如愿', '王菲','Musics/ruyuan_wangfei.mp3','Lyrics/ruyuan_wangfei.lrc',1, 240+25),
('传奇', '李健','Musics/chuanqi_lijian.mp3','Lyrics/chuanqi_lijian.lrc',1, 240+54),
('国王与乞丐', '华晨宇','Musics/guowangyuqigai.mp3','Lyrics/guowangyuqigai.lrc',1, 120+58),
('素颜', '许嵩','Musics/suyan.mp3','Lyrics/suyan.lrc',1, 180+57),
('唯一', '邓紫棋','Musics/weiyi_dengziqi.mp3','Lyrics/weiyi_dengziqi.lrc',1, 240+12),
('意外', '薛之谦','Musics/yiwai_xuezhiqian.mp3','Lyrics/yiwai_xuezhiqian.lrc',1, 240+51),
('Faded', 'Alan Walker','Musics/Faded.mp3','Lyrics/Faded.lrc',1, 180+31),
('Just Like This', 'Deepmaniak','Musics/justlikethis.mp3','Lyrics/justlikethis.lrc',1, 240+50);

-- 插入初始管理员
-- 管理员密码为123456789
INSERT INTO Users (Account, Username, Password, IsAdmin)
VALUES 
('admin', '管理员', 'argon2id:4:4:65536:S3N1vILMxrTJYeKF17oXxQ==:xiLKTDg0oQ+fImOudiK9dXOAOX9dKA/T7KIsi6PVDa0=', 1);

-- 插入初始用户
-- 管理员密码为123456789
INSERT INTO Users (Account, Username, Password, IsAdmin)
VALUES 
('user', '未命名', 'argon2id:4:4:65536:S3N1vILMxrTJYeKF17oXxQ==:xiLKTDg0oQ+fImOudiK9dXOAOX9dKA/T7KIsi6PVDa0=', 0);

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

INSERT INTO Playlists (Name, Owner)
VALUES ('欧美金曲', 'admin');

INSERT INTO Playlists (Name, Owner)
VALUES ('自建歌单1', 'user');

INSERT INTO Playlists (Name, Owner)
VALUES ('自建歌单2', 'user');

INSERT INTO Playlists (Name, Owner)
VALUES ('自建歌单3', 'user');



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

INSERT INTO SonglistSongs (SonglistId, SongId)
VALUES
(6, 14),  
(6, 15);

-- 用户歌单

INSERT INTO SonglistSongs (SonglistId, SongId)
VALUES
(7, 1),  
(7, 2),  
(7, 3);  

INSERT INTO SonglistSongs (SonglistId, SongId)
VALUES
(8, 4),  
(8, 5),  
(8, 6);  

INSERT INTO SonglistSongs (SonglistId, SongId)
VALUES
(9, 1),  
(9, 7),  
(9, 8);  



-- 插入一些标签

INSERT INTO Tags (Name) VALUES 
('动感'),
('抒情'),
('浪漫'),
('电子'),
('古风'),
('摇滚');

-- 假设标签的 ID 按插入顺序是 1-6

-- 天外来物（动感）
INSERT INTO SongTags (SongId, TagId) VALUES (1, 1);

-- 传奇（王菲） 抒情、浪漫
INSERT INTO SongTags (SongId, TagId) VALUES 
(2, 2),
(2, 3);

-- 海阔天空（摇滚）
INSERT INTO SongTags (SongId, TagId) VALUES (3, 6);

-- 最炫民族风（动感、电子）
INSERT INTO SongTags (SongId, TagId) VALUES 
(4, 1),
(4, 4);

-- 公子向北走（一点古风、抒情）
INSERT INTO SongTags (SongId, TagId) VALUES 
(5, 2),
(5, 5);

-- 一笑江湖（古风、动感）
INSERT INTO SongTags (SongId, TagId) VALUES 
(6, 1),
(6, 5);

-- 探故知（古风、抒情）
INSERT INTO SongTags (SongId, TagId) VALUES 
(7, 2),
(7, 5);

-- 如愿（王菲）浪漫、抒情
INSERT INTO SongTags (SongId, TagId) VALUES 
(8, 2),
(8, 3);

-- 传奇（李健） 抒情
INSERT INTO SongTags (SongId, TagId) VALUES (9, 2);

-- 插入 Favorites（用户收藏歌曲）
INSERT INTO Favorites (Username, SongId) VALUES
('admin', 1),  -- 天外来物
('admin', 2);  -- 传奇（王菲）

INSERT INTO Favorites (Username, SongId) VALUES
('user', 1),  -- 天外来物
('user', 2),  -- 传奇（王菲）
('user', 12),  
('user', 13); 

-- 国王与乞丐（抒情、浪漫）
INSERT INTO SongTags (SongId, TagId) VALUES 
(10, 2),  -- 抒情
(10, 3);  -- 浪漫

-- 素颜（抒情）
INSERT INTO SongTags (SongId, TagId) VALUES 
(11, 2);  -- 抒情

-- 唯一（抒情、浪漫）
INSERT INTO SongTags (SongId, TagId) VALUES 
(12, 2),  -- 抒情
(12, 3);  -- 浪漫

-- 意外（抒情）
INSERT INTO SongTags (SongId, TagId) VALUES 
(13, 2);  -- 抒情

-- Faded（电子、动感）
INSERT INTO SongTags (SongId, TagId) VALUES 
(14, 4),  -- 电子
(14, 1);  -- 动感

-- Just Like This（电子、动感）
INSERT INTO SongTags (SongId, TagId) VALUES 
(15, 4),  -- 电子
(15, 1);  -- 动感
