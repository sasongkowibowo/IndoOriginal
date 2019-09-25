
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/23/2019 22:56:33
-- Generated from EDMX file: E:\STUDY\3. Semester 2 2019\FIT5032_Internet_Applications_Development\source\repos\IndoOriginal\Models\IndoOriginal_Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [IndoOriginalDb];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_BranchEmployee]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employees] DROP CONSTRAINT [FK_BranchEmployee];
GO
IF OBJECT_ID(N'[dbo].[FK_BranchBranchTable]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BranchTables] DROP CONSTRAINT [FK_BranchBranchTable];
GO
IF OBJECT_ID(N'[dbo].[FK_BranchTableBookingSchedule]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BookingSchedules] DROP CONSTRAINT [FK_BranchTableBookingSchedule];
GO
IF OBJECT_ID(N'[dbo].[FK_BranchBookingRequest]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BookingRequests] DROP CONSTRAINT [FK_BranchBookingRequest];
GO
IF OBJECT_ID(N'[dbo].[FK_BranchBookingSchedule]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BookingSchedules] DROP CONSTRAINT [FK_BranchBookingSchedule];
GO
IF OBJECT_ID(N'[dbo].[FK_BranchReview]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Reviews] DROP CONSTRAINT [FK_BranchReview];
GO
IF OBJECT_ID(N'[dbo].[FK_BookingRequestReview]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Reviews] DROP CONSTRAINT [FK_BookingRequestReview];
GO
IF OBJECT_ID(N'[dbo].[FK_BookingRequestBookingSchedule]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BookingSchedules] DROP CONSTRAINT [FK_BookingRequestBookingSchedule];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Branches]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Branches];
GO
IF OBJECT_ID(N'[dbo].[Employees]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employees];
GO
IF OBJECT_ID(N'[dbo].[BranchTables]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BranchTables];
GO
IF OBJECT_ID(N'[dbo].[BookingRequests]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BookingRequests];
GO
IF OBJECT_ID(N'[dbo].[BookingSchedules]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BookingSchedules];
GO
IF OBJECT_ID(N'[dbo].[Menus]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Menus];
GO
IF OBJECT_ID(N'[dbo].[Reviews]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Reviews];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Branches'
CREATE TABLE [dbo].[Branches] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Address] nvarchar(max)  NOT NULL,
    [State] nvarchar(max)  NOT NULL,
    [Telephone] nvarchar(max)  NOT NULL,
    [Coordinate] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Employees'
CREATE TABLE [dbo].[Employees] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FullName] nvarchar(max)  NOT NULL,
    [Telephone] nvarchar(max)  NOT NULL,
    [BranchId] int  NOT NULL,
    [LoginId] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'BranchTables'
CREATE TABLE [dbo].[BranchTables] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TableNo] nvarchar(max)  NOT NULL,
    [Capacity] int  NOT NULL,
    [BranchId] int  NOT NULL
);
GO

-- Creating table 'BookingRequests'
CREATE TABLE [dbo].[BookingRequests] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [BranchId] int  NOT NULL,
    [FullName] nvarchar(max)  NOT NULL,
    [Date] datetime  NOT NULL,
    [Time] int  NOT NULL,
    [Persons] int  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Telephone] nvarchar(max)  NOT NULL,
    [Note] nvarchar(max)  NULL,
    [WaitingList] int  NULL,
    [TransactionDate] datetime  NOT NULL
);
GO

-- Creating table 'BookingSchedules'
CREATE TABLE [dbo].[BookingSchedules] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Date] datetime  NOT NULL,
    [Time] int  NOT NULL,
    [EndTime] int  NOT NULL,
    [BranchTableId] int  NOT NULL,
    [BranchId] int  NOT NULL,
    [BookingRequest_Id] int  NOT NULL
);
GO

-- Creating table 'Menus'
CREATE TABLE [dbo].[Menus] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Type] nvarchar(max)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Calories] int  NOT NULL,
    [Picture] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Reviews'
CREATE TABLE [dbo].[Reviews] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Menu] int  NOT NULL,
    [Place] int  NOT NULL,
    [Service] int  NOT NULL,
    [BookingProcess] int  NOT NULL,
    [Comment] nvarchar(max)  NOT NULL,
    [ReviewDate] datetime  NOT NULL,
    [BranchId] int  NOT NULL,
    [BookingRequestId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Branches'
ALTER TABLE [dbo].[Branches]
ADD CONSTRAINT [PK_Branches]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [PK_Employees]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BranchTables'
ALTER TABLE [dbo].[BranchTables]
ADD CONSTRAINT [PK_BranchTables]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BookingRequests'
ALTER TABLE [dbo].[BookingRequests]
ADD CONSTRAINT [PK_BookingRequests]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BookingSchedules'
ALTER TABLE [dbo].[BookingSchedules]
ADD CONSTRAINT [PK_BookingSchedules]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Menus'
ALTER TABLE [dbo].[Menus]
ADD CONSTRAINT [PK_Menus]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Reviews'
ALTER TABLE [dbo].[Reviews]
ADD CONSTRAINT [PK_Reviews]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [BranchId] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [FK_BranchEmployee]
    FOREIGN KEY ([BranchId])
    REFERENCES [dbo].[Branches]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BranchEmployee'
CREATE INDEX [IX_FK_BranchEmployee]
ON [dbo].[Employees]
    ([BranchId]);
GO

-- Creating foreign key on [BranchId] in table 'BranchTables'
ALTER TABLE [dbo].[BranchTables]
ADD CONSTRAINT [FK_BranchBranchTable]
    FOREIGN KEY ([BranchId])
    REFERENCES [dbo].[Branches]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BranchBranchTable'
CREATE INDEX [IX_FK_BranchBranchTable]
ON [dbo].[BranchTables]
    ([BranchId]);
GO

-- Creating foreign key on [BranchTableId] in table 'BookingSchedules'
ALTER TABLE [dbo].[BookingSchedules]
ADD CONSTRAINT [FK_BranchTableBookingSchedule]
    FOREIGN KEY ([BranchTableId])
    REFERENCES [dbo].[BranchTables]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BranchTableBookingSchedule'
CREATE INDEX [IX_FK_BranchTableBookingSchedule]
ON [dbo].[BookingSchedules]
    ([BranchTableId]);
GO

-- Creating foreign key on [BranchId] in table 'BookingRequests'
ALTER TABLE [dbo].[BookingRequests]
ADD CONSTRAINT [FK_BranchBookingRequest]
    FOREIGN KEY ([BranchId])
    REFERENCES [dbo].[Branches]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BranchBookingRequest'
CREATE INDEX [IX_FK_BranchBookingRequest]
ON [dbo].[BookingRequests]
    ([BranchId]);
GO

-- Creating foreign key on [BranchId] in table 'BookingSchedules'
ALTER TABLE [dbo].[BookingSchedules]
ADD CONSTRAINT [FK_BranchBookingSchedule]
    FOREIGN KEY ([BranchId])
    REFERENCES [dbo].[Branches]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BranchBookingSchedule'
CREATE INDEX [IX_FK_BranchBookingSchedule]
ON [dbo].[BookingSchedules]
    ([BranchId]);
GO

-- Creating foreign key on [BranchId] in table 'Reviews'
ALTER TABLE [dbo].[Reviews]
ADD CONSTRAINT [FK_BranchReview]
    FOREIGN KEY ([BranchId])
    REFERENCES [dbo].[Branches]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BranchReview'
CREATE INDEX [IX_FK_BranchReview]
ON [dbo].[Reviews]
    ([BranchId]);
GO

-- Creating foreign key on [BookingRequestId] in table 'Reviews'
ALTER TABLE [dbo].[Reviews]
ADD CONSTRAINT [FK_BookingRequestReview]
    FOREIGN KEY ([BookingRequestId])
    REFERENCES [dbo].[BookingRequests]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BookingRequestReview'
CREATE INDEX [IX_FK_BookingRequestReview]
ON [dbo].[Reviews]
    ([BookingRequestId]);
GO

-- Creating foreign key on [BookingRequest_Id] in table 'BookingSchedules'
ALTER TABLE [dbo].[BookingSchedules]
ADD CONSTRAINT [FK_BookingRequestBookingSchedule]
    FOREIGN KEY ([BookingRequest_Id])
    REFERENCES [dbo].[BookingRequests]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BookingRequestBookingSchedule'
CREATE INDEX [IX_FK_BookingRequestBookingSchedule]
ON [dbo].[BookingSchedules]
    ([BookingRequest_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------