USE NoteSyncDB

CREATE TABLE [Membership] (
	[MembershipId] TINYINT IDENTITY(1,1) PRIMARY KEY,
	[MembershipName] VARCHAR(15) NOT NULL,
	[Price] MONEY NOT NULL
)

--CREATE TABLE [Status] (
--	[StatusId] TINYINT IDENTITY(1,1) PRIMARY KEY,
--	[StatusName] VARCHAR(15) NOT NULL
--)

CREATE TABLE [User] (
	[UserId] INT IDENTITY (1,1) PRIMARY KEY,
	[UserNickname] NVARCHAR(15) NOT NULL,
	[Email] NVARCHAR(100) NOT NULL UNIQUE,
	[Password] NVARCHAR(MAX) NOT NULL, -- para bcrypt
	[CreatedAt] DATETIME NOT NULL DEFAULT GETDATE(),
	[ProfilePictureUrl] NVARCHAR(255),
	[MembershipId] TINYINT NOT NULL DEFAULT 1,
	--[StartMembershipDate] DATETIME,
	--[EndMembershipDate] DATETIME, 
	--[MembershipStatusId] TINYINT,
	CONSTRAINT user_plan_fk FOREIGN KEY ([MembershipId]) REFERENCES [Membership]([MembershipId])
	--CONSTRAINT user_status_fk FOREIGN KEY ([MembershipStatusId]) REFERENCES [Status]([StatusId])
)

-- Insert for membership table

INSERT INTO [Membership] ([MembershipName], [Price]) 
VALUES ('Basic', 0), 
       ('Premium', 19.99), 
       ('Student', 9.99) 

--INSERT INTO [Status] ([StatusName]) 
--VALUES ('Active'),
--       ('Expired'), 
--       ('Suspended'),
--       ('Cancelled')


SELECT * FROM [Membership]
SELECT * FROM [User]
