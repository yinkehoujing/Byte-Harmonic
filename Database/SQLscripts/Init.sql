-- �������ݿ⣨��������ڣ�
CREATE DATABASE IF NOT EXISTS `Byte_Harmonic` CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
USE `Byte_Harmonic`;


-- ɾ���ɱ�
DROP TABLE IF EXISTS `SonglistSongs`;
DROP TABLE IF EXISTS `SearchHistory`;
DROP TABLE IF EXISTS `Playlists`;
DROP TABLE IF EXISTS `Favorites`;
DROP TABLE IF EXISTS `Lyrics`;
DROP TABLE IF EXISTS `SongTags`;
DROP TABLE IF EXISTS `Tags`;
DROP TABLE IF EXISTS `Songs`;
DROP TABLE IF EXISTS `Users`;

-- ���� Songs��������
CREATE TABLE IF NOT EXISTS `Songs` (
    `Id` INTEGER AUTO_INCREMENT PRIMARY KEY,  -- ���� ID������
    `Title` TEXT NOT NULL,  -- ��������
    `Artist` TEXT NOT NULL, -- ����
    `MusicFilePath` TEXT NOT NULL, -- �����ļ�·��
    `LrcFilePath` TEXT,  -- ����ļ�·��
    `Downloaded` BOOLEAN,  -- �Ƿ񱾵�����
    `Duration` INTEGER  -- ����ʱ�����룩
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- ���� Tags����ǩ��
CREATE TABLE IF NOT EXISTS `Tags` (
    `Id` INTEGER AUTO_INCREMENT PRIMARY KEY,  -- ��ǩ ID������
    `Name` VARCHAR(255) NOT NULL  -- ��ǩ���ƣ�ʹ�� VARCHAR ���Ƴ���
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- ���� SongTags������-��ǩ��Զ��ϵ��
CREATE TABLE IF NOT EXISTS `SongTags` (
    `SongId` INTEGER,  -- �����Songs.Id
    `TagId` INTEGER,  -- �����Tags.Id
    PRIMARY KEY (`SongId`, `TagId`),
    FOREIGN KEY (`SongId`) REFERENCES `Songs`(`Id`) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (`TagId`) REFERENCES `Tags`(`Id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- ���� Lyrics����ʱ�
CREATE TABLE IF NOT EXISTS `Lyrics` (
    `SongId` INTEGER PRIMARY KEY,  -- ���� ID�����������
    `Content` TEXT,  -- �������
    FOREIGN KEY (`SongId`) REFERENCES `Songs`(`Id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- ���� Users���û���
CREATE TABLE IF NOT EXISTS `Users` (
    `Account` VARCHAR(255) PRIMARY KEY,  -- �û��˻���ʹ�� VARCHAR ���Ƴ��ȣ�
    `Username` VARCHAR(255) NOT NULL,  -- �û�����ʹ�� VARCHAR ���Ƴ��ȣ�
    `Password` TEXT NOT NULL,  -- ���루��ϣֵ��
    `IsAdmin` BOOLEAN  -- �Ƿ����Ա
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- ���� Favorites���û��ղظ�����
CREATE TABLE IF NOT EXISTS `Favorites` (
    `Username` VARCHAR(255),  -- �����Users.Account��ʹ�� VARCHAR ���Ƴ���
    `SongId` INTEGER,  -- �����Songs.Id
    PRIMARY KEY (`Username`, `SongId`),
    FOREIGN KEY (`Username`) REFERENCES `Users`(`Account`) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (`SongId`) REFERENCES `Songs`(`Id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- ���� Playlists���赥��
CREATE TABLE IF NOT EXISTS `Playlists` (
    `Id` INTEGER AUTO_INCREMENT PRIMARY KEY,  -- �赥 ID������
    `Name` VARCHAR(255) NOT NULL,  -- �赥���ƣ�ʹ�� VARCHAR ���Ƴ���
    `Owner` VARCHAR(255),  -- �������˻���ʹ�� VARCHAR ���Ƴ���
    FOREIGN KEY (`Owner`) REFERENCES `Users`(`Account`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- ���� SonglistSongs���赥-������Զ��ϵ��
CREATE TABLE IF NOT EXISTS `SonglistSongs` (
    `SonglistId` INTEGER,  -- �����Playlists.Id
    `SongId` INTEGER,  -- �����Songs.Id
    PRIMARY KEY (`SonglistId`, `SongId`),
    FOREIGN KEY (`SonglistId`) REFERENCES `Playlists`(`Id`) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (`SongId`) REFERENCES `Songs`(`Id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- ���� SearchHistory��������ʷ��
CREATE TABLE IF NOT EXISTS `SearchHistory` (
    `Username` VARCHAR(255),  -- �����Users.Account��ʹ�� VARCHAR ���Ƴ���
    `Keyword` TEXT,  -- �����ؼ���
    `Time` DATETIME,  -- ����ʱ��
    FOREIGN KEY (`Username`) REFERENCES `Users`(`Account`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
