USE NoteSyncDB;
GO

---------------- STORED PROCEDURES FOR USERS --------------------

ALTER PROCEDURE SP_User_Login
    @Email NVARCHAR(100),
    @Password NVARCHAR(MAX)
AS
BEGIN
    SELECT * FROM [User]
    WHERE Email = @Email AND Password = @Password;
END

EXEC SP_User_Login @Email = 'rataEssss222@gmail.com', @Password = 'pepesurxd1'
GO

-- Procedure to consult the table of users
CREATE PROCEDURE SP_User_Index
AS
BEGIN
  SELECT * FROM [User]
END
GO


CREATE PROCEDURE SP_User_Create
	@UserNickname NVARCHAR(15), 
	@Email NVARCHAR(100),
	@Password NVARCHAR(60)
as
BEGIN
	INSERT INTO [User]([UserNickname],[Email],[Password])
	VALUES (@UserNickname, @Email, @Password)
END


---Retorna el identificador de la tabla
SELECT Scope_identity()
GO

CREATE PROCEDURE SP_User_Update
	@UserId INT, 
	@UserNickname NVARCHAR(15), 
	@Email NVARCHAR(100),
	@Password NVARCHAR(60), 
	@ProfilePictureUrl NVARCHAR(255),
	@MembershipId TINYINT
AS
BEGIN
	Update [User] 
	set [UserNickname]=@UserNickname, 
		[Email]=@Email,
		[Password]=@Password,
		[ProfilePictureUrl]=@ProfilePictureUrl,
		[MembershipId]=@MembershipId
	where [UserId]=@UserId
END


---Retorna el identificador de la tabla
Select Scope_identity()
GO

CREATE PROCEDURE SP_User_Delete
	@UserId INT
AS
BEGIN
	DELETE FROM [User] WHERE [UserId]=@UserId
END
---Retorna el identificador de la tabla
SELECT Scope_identity()
GO

CREATE PROCEDURE SP_User_Read
	@UserId INT
AS
BEGIN
	SELECT 
	UserId,
	UserNickname, 
	Email, 
	[Password], 
	CreatedAt, 
	ProfilePictureUrl, 
	(SELECT MembershipName FROM Membership WHERE MembershipId=[User].MembershipId) AS Membership 
	FROM [user] where [UserId]=@UserId
END
---Retorna el identificador de la tabla
SELECT Scope_identity()
GO

CREATE PROCEDURE SP_User_By_Email
	@Email NVARCHAR(100),
	@Password NVARCHAR(MAX)
AS
BEGIN
	SELECT * FROM [user] where [Email]=@Email AND [Password]=@Password
END
---Retorna el identificador de la tabla
SELECT Scope_identity()
GO
-----------------------------------------------------------------

-------------------- STORED PROCEDURES FOR FILES ----------------

CREATE PROCEDURE SP_File_Create
	@UserId INT
AS
BEGIN
	INSERT INTO [File] ([LastModifiedDate], [UserId])
	VALUES (GETDATE(), @UserId)
	SELECT SCOPE_IDENTITY()
END

GO

CREATE PROCEDURE SP_File_Read
	@FileId INT
AS
BEGIN
	SELECT * FROM [File] WHERE [FileId] = @FileId;
END

GO

CREATE PROCEDURE SP_File_Update
	@FileId INT
AS
BEGIN
	Update [File] 
	set [LastModifiedDate] = GETDATE()
	where [FileId]=@FileId		
END

GO

CREATE PROCEDURE SP_File_Delete
	@FileId INT
AS
BEGIN
	DELETE FROM [File] WHERE [FileId] = @FileId
END

-----------------------------------------------------------------


----------------STORED PROCEDURES FOR TAG--------------------

GO

CREATE PROCEDURE SP_Tag_Create
    @TagContent NVARCHAR(10),
    @UserId INT,
	@Color VARCHAR(7)
AS
BEGIN

    INSERT INTO [Tag] (TagContent, UserId, Color)
    VALUES (@TagContent, @UserId, @Color);

    SELECT SCOPE_IDENTITY() AS TagId;
END;

GO

-- Leer Tag
CREATE PROCEDURE SP_Tag_Read
	@UserId INT
AS
BEGIN
    SELECT * FROM [Tag] WHERE [UserId] = @UserId;
END

GO

CREATE PROCEDURE SP_Tag_Update
    @TagId INT,
    @TagContent NVARCHAR(10)
AS
BEGIN
    UPDATE [Tag]
    SET [TagContent] = @TagContent
    WHERE [TagId] = @TagId;
END

GO

-- Eliminar Tag
CREATE PROCEDURE SP_Tag_Delete
    @TagId INT
AS
BEGIN
    DELETE FROM [Tag] WHERE [TagId] = @TagId;
END

---------------- STORED PROCEDURES FOR FILETAG --------------------

GO

CREATE PROCEDURE SP_Filetag_Create 
    @FileId INT,
    @TagId INT
AS
BEGIN
    INSERT INTO [FileTag] (FileId, TagId)
    VALUES (@FileId, @TagId);
END 

GO

CREATE PROCEDURE SP_Filetag_Read
     @FileId INT
AS
BEGIN
    SELECT * FROM FileTag
    WHERE FileId = @FileId;
END 

GO

CREATE PROCEDURE SP_Filetag_Delete
    @FileId INT
AS
BEGIN
    DELETE FROM [FileTag]
    WHERE FileId = @FileId;
END 

-------------------------------------------------------------------

---------------- STORED PROCEDURES FOR PAGE -----------------------

GO
CREATE PROCEDURE SP_Page_Create
    @FileId INT,
    @Content NVARCHAR(MAX)
AS
BEGIN
    INSERT INTO [Page] (FileId, Content)
    VALUES (@FileId, @Content);
    
    SELECT SCOPE_IDENTITY(); 
END

GO

-- Leer Page
CREATE PROCEDURE SP_Page_Read
    @PageId INT
AS
BEGIN
    SELECT * FROM [Page] WHERE PageId = @PageId;
END

GO

-- Actualizar Page
CREATE PROCEDURE SP_Page_Update
    @PageId INT,
    @Content NVARCHAR(MAX)
AS
BEGIN
    UPDATE [Page]
    SET Content = @Content
    WHERE PageId = @PageId;
END

GO

-- Eliminar Page
CREATE PROCEDURE SP_Page_Delete
    @PageId INT
AS
BEGIN
    DELETE FROM [Page] WHERE PageId = @PageId;
END

-------------------------------------------------------------------

SELECT name, object_id, create_date, modify_date
FROM sys.procedures
ORDER BY name;
