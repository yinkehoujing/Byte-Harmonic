-- ������Թ���Ա�˻�
INSERT IGNORE INTO `Users` (`Account`, `Username`, `Password`, `IsAdmin`)
VALUES ('admin', 'admin', 'e10adc3949ba59abbe56e057f20f883e', TRUE);  -- ������ "123456" �� MD5 ��ϣֵ

-- ������Ը���
INSERT IGNORE INTO `Songs` (`Title`, `Artist`, `MusicFilePath`, `LrcFilePath`, `Downloaded`, `Duration`)
VALUES ('test-title', 'test-singer', '/music/test_song.mp3', '/lyrics/test_song.lrc', TRUE, 210);

-- ������Ը��
INSERT IGNORE INTO `Lyrics` (`SongId`, `Content`)
VALUES (1, '[00:00.00] ���Ը�ʵ�һ��\n[00:15.00] ���Ը�ʵڶ���');  -- �����IDΪ1

-- ������Ա�ǩ
INSERT IGNORE INTO `Tags` (`Name`)
VALUES ('����');

-- ����ǩ���������Ը���
INSERT IGNORE INTO `SongTags` (`SongId`, `TagId`)
VALUES (1, 1);  -- ������� ID Ϊ 1����ǩ ID Ϊ 1

-- ������Ը赥
INSERT IGNORE INTO `Playlists` (`Name`, `Owner`)
VALUES ('�ҵ��ղ�', 'admin');

-- �����Ը������뵽���Ը赥
INSERT IGNORE INTO `SonglistSongs` (`SonglistId`, `SongId`)
VALUES (1, 1);  -- ����赥 ID Ϊ 1������ ID Ϊ 1
