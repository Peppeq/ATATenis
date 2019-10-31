-- ****************** SqlDBM: Microsoft SQL Server ******************
-- ******************************************************************


SELECT *
FROM sys.foreign_keys
WHERE referenced_object_id = object_id('Player')


drop table Match;
drop table Draw;
drop table Player;

drop table Tournament;


-- ************************************** [dbo].[Tournament]

-- ****************** SqlDBM: Microsoft SQL Server ******************
-- ******************************************************************

-- ************************************** [dbo].[Tournament]

CREATE TABLE [dbo].[Tournament]
(
 [Id]            int IDENTITY (1, 1) NOT NULL ,
 [Name]          nvarchar(50) NOT NULL ,
 [Year]          int NOT NULL ,
 [Place]         nvarchar(100) NOT NULL ,
 [Category]      int NOT NULL ,
 [PlayingSystem] int NOT NULL ,
 [BallsType]     int NULL ,
 [Description]   nvarchar(max) NULL ,


 CONSTRAINT [PK_Tournament] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO
















-- ************************************** [dbo].[Draw]

CREATE TABLE [dbo].[Draw]
(
 [Id]             int IDENTITY (1, 1) NOT NULL ,
 [Type]           int NOT NULL ,
 [CountOfPlayers] int NOT NULL ,
 [TournamentId]   int NOT NULL ,
 [Round]          int NOT NULL ,


 CONSTRAINT [PK_Draw] PRIMARY KEY CLUSTERED ([Id] ASC),
 CONSTRAINT [FK_Draw_Tournament] FOREIGN KEY ([TournamentId])  REFERENCES [dbo].[Tournament]([Id]) ON DELETE CASCADE
);
GO


CREATE NONCLUSTERED INDEX [FK_Draw_Tournament] ON [dbo].[Draw]
 (
  [TournamentId] ASC
 )

GO


-- ****************** SqlDBM: Microsoft SQL Server ******************
-- ******************************************************************

-- ************************************** [dbo].[Match]

-- ****************** SqlDBM: Microsoft SQL Server ******************
-- ******************************************************************

-- ************************************** [dbo].[Match]

CREATE TABLE [dbo].[Match]
(
 [Id]           int IDENTITY (1, 1) NOT NULL ,
 [TournamentId] int NOT NULL ,
 [Score]        int NOT NULL ,
 [Retired]      bit NOT NULL ,


 CONSTRAINT [PK_Match] PRIMARY KEY CLUSTERED ([Id] ASC),
 CONSTRAINT [FK_Match_Tournament] FOREIGN KEY ([TournamentId])  REFERENCES [dbo].[Tournament]([Id]) ON DELETE CASCADE
);
GO


CREATE NONCLUSTERED INDEX [fkIdx_Match_Tournament] ON [dbo].[Match]
 (
  [TournamentId] ASC
 )

GO















-- ************************************** [dbo].[DrawMatch]

CREATE TABLE [dbo].[DrawMatch]
(

 [DrawId]       int NOT NULL ,
 [MatchId]      int NOT NULL ,
 primary key ( [DrawId], [MatchId] ),

 CONSTRAINT [FK_DrawMatch_Draw] FOREIGN KEY ([DrawId])  REFERENCES [dbo].[Draw]([Id]),
 CONSTRAINT [FK_DrawMatch_Match] FOREIGN KEY ([MatchId])  REFERENCES [dbo].[Match]([Id])
);

--GO


--CREATE UNIQUE CLUSTERED INDEX [PK_DrawMatch] ON [dbo].[DrawMatch]
-- (
--  [PK_DrawMatch] ASC
-- )
-- INCLUDE (
--  [DrawId],
--  [MatchId]
-- )

--GO

--CREATE NONCLUSTERED INDEX [fkIdx_DrawMatch_Draw] ON [dbo].[DrawMatch]
-- (
--  [DrawId] ASC
-- )

--GO

--CREATE NONCLUSTERED INDEX [fkIdx_DrawMatch_Match] ON [dbo].[DrawMatch]
-- (
--  [MatchId] ASC
-- )

--GO


-- ****************** SqlDBM: Microsoft SQL Server ******************
-- ******************************************************************

-- ************************************** [dbo].[Player]

-- ****************** SqlDBM: Microsoft SQL Server ******************
-- ******************************************************************

-- ************************************** [dbo].[Player]

CREATE TABLE [dbo].[Player]
(
 [Id]              int IDENTITY (1, 1) NOT NULL ,
 [Name]            nvarchar(50) NOT NULL ,
 [Surname]         nvarchar(50) NOT NULL ,
 [Age]             int NULL ,
 [Height]          int NULL ,
 [Residence]       nvarchar(50) NULL ,
 [Forehand]        bit NULL ,
 [Backhand]        bit NULL ,
 [Racquet]         nvarchar(30) NULL ,
 [Surface]         int NULL ,
 [FavouritePlayer] nvarchar(30) NULL ,
 [TitlesCount]     int NULL ,
 [FinalistCount]   int NULL ,
 [TournamentCount] int NULL ,
 [Member]          bit NULL ,


 CONSTRAINT [PK_Player] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO

















-- ************************************** [dbo].[MatchPlayer]

CREATE TABLE [dbo].[MatchPlayer]
(
 [Id]       int IDENTITY (1, 1) NOT NULL ,
 [MatchId]  int NOT NULL ,
 [PlayerId] int NOT NULL ,


 CONSTRAINT [PK_Match_Player] PRIMARY KEY CLUSTERED ([Id] ASC),
 CONSTRAINT [FK_MatchPlayer_Match] FOREIGN KEY ([MatchId])  REFERENCES [dbo].[Match]([Id]),
 CONSTRAINT [FK_MatchPlayer_Player] FOREIGN KEY ([PlayerId])  REFERENCES [dbo].[Player]([Id])
);
GO


CREATE NONCLUSTERED INDEX [fkIdx_MatchPlayer_Match] ON [dbo].[MatchPlayer]
 (
  [MatchId] ASC
 )

GO

CREATE NONCLUSTERED INDEX [fkIdx_MatchPlayer_Player] ON [dbo].[MatchPlayer]
 (
  [PlayerId] ASC
 )

GO


Alter table [tournament] add Points int not null;
Alter table Player add Points int not null;

Alter table Tournament alter column Year datetime not null
Alter table Tournament alter column TournamentType int not null
EXEC sp_rename 'Tournament.Year', 'StartTime'
alter table tournament alter column  EndTime datetime null


Alter table [tournament] alter column Surface int not null;
update Tournament set Surface = 0
select * FROM [AtaTennis].[dbo].[Tournament]

delete from [AtaTennis].[dbo].[Tournament]



















USE [AtaTennis]
GO
SET IDENTITY_INSERT [dbo].[Player] ON

GO
INSERT [dbo].[Player] ([Id], [Name], [Surname], [Age]) VALUES (1, N'Peter', N'Sveter', 33)
GO
INSERT [dbo].[Player] ([Id], [Name], [Surname], [Age]) VALUES (2, N'Jano', N'Slany', 33)
GO
INSERT [dbo].[Player] ([Id], [Name], [Surname], [Age]) VALUES (3, N'Miso', N'Sef', 39)
GO
INSERT [dbo].[Player] ([Id], [Name], [Surname], [Age]) VALUES (4, N'Jozo', N'Suly', 55)
GO
SET IDENTITY_INSERT [dbo].[Player] OFF
GO


ALTER TABLE [AtaTennis].[dbo].[Player] ALTER COLUMN Forehand int;
ALTER TABLE [AtaTennis].[dbo].[Player] ALTER COLUMN Backhand int;
ALTER TABLE [AtaTennis].[dbo].[Player] Add Weight int null;

  ALTER TABLE [AtaTennis].[dbo].[Player] ALTER COLUMN Backhand int;

EXEC sp_rename 'Player.Age', 'BirthDate', 'COLUMN';
  ALTER TABLE Player drop column BirthDate
ALTER Table player add BirthDate date;