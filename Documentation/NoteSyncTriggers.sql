USE NoteSyncDB

GO
CREATE TRIGGER trg_InsertUser
ON [User]
AFTER INSERT
AS
BEGIN
    INSERT INTO [Tag] (UserId, TagContent, Color)
    SELECT UserId, 'To do', '#84b6f4' 
    FROM inserted;

	INSERT INTO [Tag] (UserId, TagContent, Color)
    SELECT UserId, 'In progress', '#fdfd96' 
    FROM inserted;

	INSERT INTO [Tag] (UserId, TagContent, Color)
    SELECT UserId, 'Finish', '#77dd77' 
    FROM inserted;
END;

GO
CREATE TRIGGER trg_InsertFolder
ON [Folder]
AFTER INSERT
AS
BEGIN
    INSERT INTO [Page] (FolderId)
    SELECT FolderId
    FROM inserted;
END;

SELECT 
    name AS TriggerName,
    OBJECT_NAME(parent_id) AS TableName,
    type_desc AS TriggerType
FROM 
    sys.triggers;