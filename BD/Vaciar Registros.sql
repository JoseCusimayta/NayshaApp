EXEC sp_MSForEachTable 'ALTER TABLE ? NOCHECK CONSTRAINT ALL'
GO
EXEC sp_MSForEachTable 'ALTER TABLE ? DISABLE TRIGGER ALL'
GO
 
EXEC sp_MSForEachTable
    'BEGIN TRY
        TRUNCATE TABLE ?
    END TRY
    BEGIN CATCH
        DELETE FROM ?
    END CATCH;'
EXEC sp_MSForEachTable 'ALTER TABLE ? CHECK CONSTRAINT ALL'
GO
EXEC sp_MSForEachTable 'ALTER TABLE ? ENABLE TRIGGER ALL'
GO