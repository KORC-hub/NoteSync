USE NoteSyncDB

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
