CREATE DATABASE NoteSyncDB;

USE NoteSyncDB

CREATE TABLE [Membership] (
	[MembershipId] TINYINT IDENTITY(1,1) PRIMARY KEY,
	[MembershipName] VARCHAR(15) NOT NULL,
	[Price] MONEY NOT NULL
)

CREATE TABLE [User] (
	[UserId] INT IDENTITY (1,1) PRIMARY KEY,
	[UserNickname] NVARCHAR(15) NOT NULL,
	[Email] NVARCHAR(100) NOT NULL UNIQUE,
	[Password] NVARCHAR(MAX) NOT NULL, -- para bcrypt
	[CreatedAt] DATETIME NOT NULL DEFAULT GETDATE(),
	[ProfilePictureUrl] NVARCHAR(255),
	[MembershipId] TINYINT NOT NULL DEFAULT 1,
	CONSTRAINT user_plan_fk FOREIGN KEY ([MembershipId]) REFERENCES [Membership]([MembershipId])
)

CREATE TABLE [File] (
    [FileId] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [CreatedAt] DATETIME NOT NULL DEFAULT GETDATE(),
    [LastModifiedDate] DATETIME NOT NULL,
    [UserId] INT NOT NULL,
    CONSTRAINT userid_fk FOREIGN KEY ([UserId]) REFERENCES [User]([UserId])
)


CREATE TABLE [Tag](
	[TagId] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
	[UserId] INT NOT NULL,
	[TagContent] NVARCHAR(10) NOT NULL,
	[Color] VARCHAR(7) NOT NULL,
    CONSTRAINT userid2_fk FOREIGN KEY ([UserId]) REFERENCES [User]([UserId])
)
	SELECT * FROM [User]
	SELECT * FROM [Tag] WHERE [UserId] = 4
    INSERT INTO [Tag] (TagContent, UserId, Color)
    VALUES ('SAMP',4, 'asdasda'), ('SAMPSS',4, 'awdwa'), ('SASSSSMP',6, 'awdwww')

CREATE TABLE [FileTag](
	[FileId] INT NOT NULL,
	[TagId] INT NOT NULL,
	CONSTRAINT fileid_fk FOREIGN KEY ([FileId]) REFERENCES [File]([FileId]),
	CONSTRAINT tagid_fk FOREIGN KEY ([TagId]) REFERENCES [Tag]([TagId])
)

CREATE TABLE [Page](
	[PageId] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
	[Content] VARCHAR(MAX),
	[FileId] INT NOT NULL,
	[Title] VARCHAR(45) NOT NULL,
	CONSTRAINT fileid2_fk FOREIGN KEY ([FileId]) REFERENCES [File]([FileId])
)

SELECT * FROM [User]

INSERT INTO [File] ([LastModifiedDate], [UserId])
VALUES (GETDATE(), 4)

SELECT * FROM [File]
SELECT * FROM [FileTag]
SELECT * FROM [Page]







INSERT INTO [User] ([UserNickname], [Email], [Password])
VALUES 
	   ('KeviWR','rataEssss222@gmail.com','pepesurxd1')

-- Insert for membership table

INSERT INTO [Membership] ([MembershipName], [Price]) 
VALUES ('Basic', 0), 
       ('Premium', 19.99), 
       ('Student', 9.99) 


SELECT * FROM [Membership]
SELECT * FROM [User]
