
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/05/2016 15:22:23
-- Generated from EDMX file: D:\Leva\Work\Informatika\CSharp\My OPENSOURCE projects\OnlineShop\OnlineShop\Models\Goods.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [GoodsList];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_SubCategoryCategory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SubCategorySet] DROP CONSTRAINT [FK_SubCategoryCategory];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductSubCategory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductSet] DROP CONSTRAINT [FK_ProductSubCategory];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[CategorySet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CategorySet];
GO
IF OBJECT_ID(N'[dbo].[ProductSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductSet];
GO
IF OBJECT_ID(N'[dbo].[SubCategorySet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SubCategorySet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'CategorySet'
CREATE TABLE [dbo].[CategorySet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [category] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ProductSet'
CREATE TABLE [dbo].[ProductSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Article] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Price] decimal(18,0)  NOT NULL,
    [Picture] varbinary(max)  NOT NULL,
    [DateAdded] datetime  NOT NULL,
    [SubCategoryId] int  NOT NULL
);
GO

-- Creating table 'SubCategorySet'
CREATE TABLE [dbo].[SubCategorySet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Subcategory] nvarchar(max)  NOT NULL,
    [Category_Id] int  NOT NULL
);
GO

-- Creating table 'DiscriptionParameters'
CREATE TABLE [dbo].[DiscriptionParameters] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DescriptionParametr] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [ProductId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'CategorySet'
ALTER TABLE [dbo].[CategorySet]
ADD CONSTRAINT [PK_CategorySet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProductSet'
ALTER TABLE [dbo].[ProductSet]
ADD CONSTRAINT [PK_ProductSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SubCategorySet'
ALTER TABLE [dbo].[SubCategorySet]
ADD CONSTRAINT [PK_SubCategorySet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DiscriptionParameters'
ALTER TABLE [dbo].[DiscriptionParameters]
ADD CONSTRAINT [PK_DiscriptionParameters]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Category_Id] in table 'SubCategorySet'
ALTER TABLE [dbo].[SubCategorySet]
ADD CONSTRAINT [FK_SubCategoryCategory]
    FOREIGN KEY ([Category_Id])
    REFERENCES [dbo].[CategorySet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SubCategoryCategory'
CREATE INDEX [IX_FK_SubCategoryCategory]
ON [dbo].[SubCategorySet]
    ([Category_Id]);
GO

-- Creating foreign key on [ProductId] in table 'DiscriptionParameters'
ALTER TABLE [dbo].[DiscriptionParameters]
ADD CONSTRAINT [FK_ProductDescriptionParametrs]
    FOREIGN KEY ([ProductId])
    REFERENCES [dbo].[ProductSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductDescriptionParametrs'
CREATE INDEX [IX_FK_ProductDescriptionParametrs]
ON [dbo].[DiscriptionParameters]
    ([ProductId]);
GO

-- Creating foreign key on [SubCategoryId] in table 'ProductSet'
ALTER TABLE [dbo].[ProductSet]
ADD CONSTRAINT [FK_SubCategoryProduct]
    FOREIGN KEY ([SubCategoryId])
    REFERENCES [dbo].[SubCategorySet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SubCategoryProduct'
CREATE INDEX [IX_FK_SubCategoryProduct]
ON [dbo].[ProductSet]
    ([SubCategoryId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------