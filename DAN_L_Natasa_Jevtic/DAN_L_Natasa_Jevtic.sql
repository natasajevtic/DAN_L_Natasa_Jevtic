IF DB_ID('AudioPlayer') IS NULL
    create database AudioPlayer;
GO	
use AudioPlayer
--Deleting tables and views, if they exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tblUser')
	drop table tblUser;
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tblSong')
	drop table tblSong;
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tblPlayedSong')
	drop table tblPlayedSong;
IF EXISTS(select * FROM sys.views where name = 'vwUser')
	drop view vwUser;
IF EXISTS(select * FROM sys.views where name = 'vwSong')
	drop view vwSong;
IF EXISTS(select * FROM sys.views where name = 'vwPlayedSong')
	drop view vwPlayedSong;
GO
create table tblUser(
UserId int identity(1,1) PRIMARY KEY,
Username varchar(40) UNIQUE NOT NULL,
Password varchar(255) NOT NULL
);
create table tblSong(
SongId int identity(1,1) PRIMARY KEY,
Name varchar(60) NOT NULL,
Author varchar(60) NOT NULL,
Duration time NOT NULL,
UserId int FOREIGN KEY REFERENCES tblUser(UserId) NOT NULL
);
create table tblPlayedSong(
PlayedSongId int identity(1,1) PRIMARY KEY,
SongId int FOREIGN KEY REFERENCES tblSong(SongId) NOT NULL
);
GO
create view vwUser as
select *
from tblUser;
GO
create view vwSong as
select s.* , u.Username, u.Password
from tblSong s
INNER JOIN tblUser u
ON u.UserId = s.UserId;
GO
create view vwPlayedSong as
select s.* , p.PlayedSongId, u.Username, u.Password
from tblPlayedSong p
INNER JOIN tblSong s
ON p.SongId = s.SongId
INNER JOIN tblUser u
ON u.UserId = s.UserId;
