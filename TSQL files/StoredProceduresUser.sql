-- Procedure to consult the table of users
CREATE PROCEDURE SP_User_Index
AS
BEGIN
  SELECT * FROM [User]
END
GO

--Procedimiento para insertar socios
CREATE PROCEDURE SP_User_Create
(
@UserNickname NVARCHAR(15), 
@Email NVARCHAR(100),
@Password NVARCHAR(60), 
@MembershipId TINYINT
)
as
BEGIN
	INSERT INTO [User]([UserNickname],[Email],[Password],[MembershipId])
	VALUES (@UserNickname, @Email, @Password,@MembershipId)
END


---Retorna el identificador de la tabla
SELECT Scope_identity()
GO

CREATE PROCEDURE SP_User_Update
(
@UserId INT, 
@UserNickname NVARCHAR(15), 
@Email NVARCHAR(100),
@Password NVARCHAR(60), 
@ProfilePictureUrl NVARCHAR(255),
@MembershipId TINYINT
)
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
(
@UserId INT
)
AS
BEGIN
	DELETE FROM [User] WHERE [UserId]=@UserId
END
---Retorna el identificador de la tabla
SELECT Scope_identity()
GO

CREATE PROCEDURE SP_User_Read
(
@UserId INT
)
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
(
@Email NVARCHAR(100),
@Password NVARCHAR(MAX)
)
AS
BEGIN
	SELECT * FROM [user] where [Email]=@Email AND [Password]=@Password
END
---Retorna el identificador de la tabla
SELECT Scope_identity()
GO

SELECT name, object_id, create_date, modify_date
FROM sys.procedures
ORDER BY name;
