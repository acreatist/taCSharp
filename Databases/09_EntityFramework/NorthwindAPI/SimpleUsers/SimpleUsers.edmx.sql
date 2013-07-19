
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 07/17/2013 19:23:06
-- Generated from EDMX file: E:\Telerik Academy\Telerik CSharp Track\Repo\Databases\09_EntityFramework\NorthwindAPI\SimpleUsers\SimpleUsers.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [SimpleUsers];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Groups'
CREATE TABLE [dbo].[Groups] (
    [groupId] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [userId] int IDENTITY(1,1) NOT NULL,
    [username] nvarchar(max)  NOT NULL,
    [userpass] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'UsersGroups'
CREATE TABLE [dbo].[UsersGroups] (
    [Users_userId] int  NOT NULL,
    [Groups_groupId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [groupId] in table 'Groups'
ALTER TABLE [dbo].[Groups]
ADD CONSTRAINT [PK_Groups]
    PRIMARY KEY CLUSTERED ([groupId] ASC);
GO

-- Creating primary key on [userId] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([userId] ASC);
GO

-- Creating primary key on [Users_userId], [Groups_groupId] in table 'UsersGroups'
ALTER TABLE [dbo].[UsersGroups]
ADD CONSTRAINT [PK_UsersGroups]
    PRIMARY KEY NONCLUSTERED ([Users_userId], [Groups_groupId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Users_userId] in table 'UsersGroups'
ALTER TABLE [dbo].[UsersGroups]
ADD CONSTRAINT [FK_UsersGroups_Users]
    FOREIGN KEY ([Users_userId])
    REFERENCES [dbo].[Users]
        ([userId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Groups_groupId] in table 'UsersGroups'
ALTER TABLE [dbo].[UsersGroups]
ADD CONSTRAINT [FK_UsersGroups_Groups]
    FOREIGN KEY ([Groups_groupId])
    REFERENCES [dbo].[Groups]
        ([groupId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UsersGroups_Groups'
CREATE INDEX [IX_FK_UsersGroups_Groups]
ON [dbo].[UsersGroups]
    ([Groups_groupId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------