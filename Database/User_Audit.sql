CREATE TABLE [dbo].[User_Audit]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY,
	[UserId] BIGINT NOT NULL,
    [UserName] VARCHAR(100) NOT NULL, 
    [Password] VARCHAR(255) NOT NULL, 
    [Salt] VARCHAR(172) NOT NULL, 
    [EMail] VARCHAR(100) NOT NULL, 
    [FirstName] VARCHAR(50) NOT NULL, 
    [LastName] VARCHAR(50) NOT NULL, 
	[AuditAction] CHAR(1) NOT NULL, 
    [AuditUser] VARCHAR(50) NOT NULL DEFAULT suser_sname(), 
    [AuditDate] DATETIME2 NOT NULL DEFAULT getdate(), 
    [AuditApplication] VARCHAR(50) NOT NULL DEFAULT rtrim(isnull(app_name(),''))
    
)
