CREATE TABLE [dbo].[Users]
(
	[userId] INT NOT NULL PRIMARY KEY, 
    [username] NVARCHAR(50) NOT NULL, 
    [userpass] NVARCHAR(50) NOT NULL, 
    [groupId] INT NULL, 
    CONSTRAINT [username] UNIQUE (username)
)
