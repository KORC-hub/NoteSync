CREATE DATABASE NoteSyncDB;

USE NoteSyncDB

-- Membership Table

CREATE TABLE [Membership] (
	[MembershipId] TINYINT IDENTITY(1,1) PRIMARY KEY,
	[MembershipName] VARCHAR(15) NOT NULL,
	[Price] MONEY NOT NULL
)

INSERT INTO [Membership] ([MembershipName], [Price]) 
VALUES ('Basic', 0), 
       ('Premium', 19.99), 
       ('Student', 9.99) 

-- User Table

CREATE TABLE [User] (
	[UserId] INT IDENTITY (1,1) PRIMARY KEY,
	[Nickname] NVARCHAR(15) NOT NULL,
	[Email] NVARCHAR(100) NOT NULL UNIQUE,
	[Password] NVARCHAR(MAX) NOT NULL, -- para bcrypt
	[CreatedAt] DATETIME NOT NULL DEFAULT GETDATE(),
	[ProfilePictureUrl] NVARCHAR(255),
	[MembershipId] TINYINT NOT NULL DEFAULT 1,
	CONSTRAINT user_plan_fk FOREIGN KEY ([MembershipId]) REFERENCES [Membership]([MembershipId])
)

-- File Table

CREATE TABLE [Folder] (
    [FolderId] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [FolderName] VARCHAR(50) NOT NULL,
    [CreatedAt] DATETIME NOT NULL DEFAULT GETDATE(),
    [LastModifiedDate] DATETIME NOT NULL DEFAULT GETDATE(),
	[IsPinned] BIT NOT NULL DEFAULT 0,
    [UserId] INT NOT NULL,
    CONSTRAINT userid_fk FOREIGN KEY ([UserId]) REFERENCES [User]([UserId])
)

-- Tag Table

CREATE TABLE [Tag](
	[TagId] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
	[UserId] INT NOT NULL,
	[TagContent] NVARCHAR(20) NOT NULL,
	[Color] VARCHAR(7) NOT NULL,
    CONSTRAINT userid2_fk FOREIGN KEY ([UserId]) REFERENCES [User]([UserId])
)

-- FileTag Table

CREATE TABLE [FolderTag](
	[FolderTagId] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
	[FolderId] INT NOT NULL,
	[TagId] INT NOT NULL,
	CONSTRAINT folderid_fk FOREIGN KEY ([FolderId]) REFERENCES [Folder]([FolderId]),
	CONSTRAINT tagid_fk FOREIGN KEY ([TagId]) REFERENCES [Tag]([TagId])
)

-- Page Table

CREATE TABLE [Page](
	[PageId] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
	[Title] VARCHAR(45),
	[Content] VARCHAR(MAX),
	[CreatedAt] DATETIME NOT NULL DEFAULT GETDATE(),
	[FolderId] INT NOT NULL,
	CONSTRAINT folderid2_fk FOREIGN KEY ([FolderId]) REFERENCES [Folder]([FolderId])
)
