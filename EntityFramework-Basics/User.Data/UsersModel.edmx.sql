
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/28/2014 21:32:30
-- Generated from EDMX file: C:\Users\Dimitar\Documents\Visual Studio 2013\Projects\DataStructuresAndAlgorithms\EntityFramework-Basics\User.Data\UsersModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Users];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_UsersGroups_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsersGroups] DROP CONSTRAINT [FK_UsersGroups_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_UsersGroups_Groups]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsersGroups] DROP CONSTRAINT [FK_UsersGroups_Groups];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[UsersSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UsersSet];
GO
IF OBJECT_ID(N'[dbo].[GroupsSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GroupsSet];
GO
IF OBJECT_ID(N'[dbo].[UsersGroups]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UsersGroups];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'UsersSet'
CREATE TABLE [dbo].[UsersSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'GroupsSet'
CREATE TABLE [dbo].[GroupsSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'UsersGroups'
CREATE TABLE [dbo].[UsersGroups] (
    [Users_Id] int  NOT NULL,
    [Groups_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'UsersSet'
ALTER TABLE [dbo].[UsersSet]
ADD CONSTRAINT [PK_UsersSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'GroupsSet'
ALTER TABLE [dbo].[GroupsSet]
ADD CONSTRAINT [PK_GroupsSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Users_Id], [Groups_Id] in table 'UsersGroups'
ALTER TABLE [dbo].[UsersGroups]
ADD CONSTRAINT [PK_UsersGroups]
    PRIMARY KEY CLUSTERED ([Users_Id], [Groups_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Users_Id] in table 'UsersGroups'
ALTER TABLE [dbo].[UsersGroups]
ADD CONSTRAINT [FK_UsersGroups_Users]
    FOREIGN KEY ([Users_Id])
    REFERENCES [dbo].[UsersSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Groups_Id] in table 'UsersGroups'
ALTER TABLE [dbo].[UsersGroups]
ADD CONSTRAINT [FK_UsersGroups_Groups]
    FOREIGN KEY ([Groups_Id])
    REFERENCES [dbo].[GroupsSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsersGroups_Groups'
CREATE INDEX [IX_FK_UsersGroups_Groups]
ON [dbo].[UsersGroups]
    ([Groups_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------