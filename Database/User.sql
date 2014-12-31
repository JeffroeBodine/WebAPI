CREATE TABLE [dbo].[User]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [UserName] VARCHAR(100) NOT NULL, 
    [Password] VARCHAR(255) NOT NULL, 
    [Salt] VARCHAR(172) NOT NULL, 
    [EMail] VARCHAR(100) NOT NULL, 
    [FirstName] VARCHAR(50) NOT NULL, 
    [LastName] VARCHAR(50) NOT NULL, 
    [AuditUser] VARCHAR(50) NULL, 
    [AuditApplication] VARCHAR(50) NULL 
)

GO

CREATE TRIGGER [dbo].[tr_User_Insert]
    ON [dbo].[User]
    FOR INSERT
    AS
    BEGIN
        SET NoCount ON
		INSERT INTO User_Audit(UserId, UserName, Password, Salt, EMail, FirstName, LastName, AuditAction, AuditUser, AuditApplication)
			Select Id, UserName, Password, Salt, EMail, FirstName, LastName, 'U'
				,ISNULL(AuditUser, suser_sname()), ISNULL(AuditApplication, rtrim(isnull(app_name(),''))) 
			from inserted i
    END

GO

CREATE TRIGGER [dbo].[tr_User_Update]
    ON [dbo].[User]
    FOR Update
    AS
    BEGIN
        SET NoCount ON
		INSERT INTO User_Audit(UserId, UserName, Password, Salt, EMail, FirstName, LastName, AuditAction, AuditUser, AuditApplication)
			Select Id, UserName, Password, Salt, EMail, FirstName, LastName, 'U' 
			,ISNULL(AuditUser, suser_sname()), ISNULL(AuditApplication, rtrim(isnull(app_name(),''))) 
			from inserted
    END

GO

CREATE TRIGGER [dbo].[tr_User_Delete]
    ON [dbo].[User]
    FOR Delete
    AS
    BEGIN
        SET NoCount ON
		INSERT INTO User_Audit(UserId, UserName, Password, Salt, EMail, FirstName, LastName, AuditAction, AuditUser, AuditApplication)
			Select Id, UserName, Password, Salt, EMail, FirstName, LastName, 'D'
			,ISNULL(AuditUser, suser_sname()), ISNULL(AuditApplication, rtrim(isnull(app_name(),''))) 
			from deleted
    END

GO
