USE `Byte_Harmonic`;

-- ������Թ���Ա�˻�
INSERT IGNORE INTO Users (Account, Username, Password, IsAdmin)
VALUES ('admin', 'admin', 'e10adc3949ba59abbe56e057f20f883e', TRUE);
-- �����������"123456"��md5��ϣ���������Կ�����ô��

-- ������Ը���
INSERT IGNORE INTO Songs (Id, Title, Artist, FilePath, Downloaded, Duration)
VALUES ('test_song_1', 'Test Song', 'Test Artist', '/music/test_song.mp3', TRUE, 210);

-- ������Ը��
INSERT IGNORE INTO Lyrics (SongId, Content)
VALUES ('test_song_1', '[00:00.00] ���Ը�ʵ�һ��\n[00:15.00] ���Ը�ʵڶ���');

-- ������Ա�ǩ
INSERT IGNORE INTO Tags (Name)
VALUES ('����');

-- ����ǩ���������Ը���
INSERT IGNORE INTO SongTags (SongId, TagId)
VALUES ('test_song_1', 1);  -- ע����������������ı�ǩID��1����ΪAUTO_INCREMENT��1��ʼ��

-- ������Ը赥
INSERT IGNORE INTO Playlists (Name, Owner)
VALUES ('�ҵ��ղ�', 'admin');

-- �����Ը������뵽���Ը赥
INSERT IGNORE INTO SonglistSongs (SonglistId, SongId)
VALUES (1, 'test_song_1'); -- ͬ������赥IDҲ��1
