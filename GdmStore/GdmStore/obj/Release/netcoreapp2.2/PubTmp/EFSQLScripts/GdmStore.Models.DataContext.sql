IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627210713_InitialCreate')
BEGIN
    CREATE TABLE [Orders] (
        [Id] int NOT NULL IDENTITY,
        [NameCompany] nvarchar(max) NULL,
        [Price] float NOT NULL,
        [DateTime] datetime2 NOT NULL,
        CONSTRAINT [PK_Orders] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627210713_InitialCreate')
BEGIN
    CREATE TABLE [ProductTypes] (
        [Id] int NOT NULL IDENTITY,
        [NameType] nvarchar(max) NULL,
        CONSTRAINT [PK_ProductTypes] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627210713_InitialCreate')
BEGIN
    CREATE TABLE [Roles] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        CONSTRAINT [PK_Roles] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627210713_InitialCreate')
BEGIN
    CREATE TABLE [Parameters] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [ProductTypeId] int NOT NULL,
        CONSTRAINT [PK_Parameters] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Parameters_ProductTypes_ProductTypeId] FOREIGN KEY ([ProductTypeId]) REFERENCES [ProductTypes] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627210713_InitialCreate')
BEGIN
    CREATE TABLE [Products] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [Number] nvarchar(max) NULL,
        [Amount] float NOT NULL,
        [PrimeCostEUR] float NOT NULL,
        [Manufacturer] nvarchar(max) NULL,
        [ProductTypeId] int NOT NULL,
        CONSTRAINT [PK_Products] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Products_ProductTypes_ProductTypeId] FOREIGN KEY ([ProductTypeId]) REFERENCES [ProductTypes] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627210713_InitialCreate')
BEGIN
    CREATE TABLE [Users] (
        [Id] int NOT NULL IDENTITY,
        [Email] nvarchar(max) NULL,
        [Password] nvarchar(max) NULL,
        [RoleId] int NOT NULL,
        CONSTRAINT [PK_Users] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Users_Roles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [Roles] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627210713_InitialCreate')
BEGIN
    CREATE TABLE [OrderProducts] (
        [Id] int NOT NULL IDENTITY,
        [ProductId] int NOT NULL,
        [OrderId] int NOT NULL,
        [Amount] float NOT NULL,
        CONSTRAINT [PK_OrderProducts] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_OrderProducts_Orders_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [Orders] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_OrderProducts_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627210713_InitialCreate')
BEGIN
    CREATE TABLE [ProductParameters] (
        [Id] int NOT NULL IDENTITY,
        [ProductId] int NOT NULL,
        [ParameterId] int NOT NULL,
        [Value] nvarchar(max) NULL,
        CONSTRAINT [PK_ProductParameters] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_ProductParameters_Parameters_ParameterId] FOREIGN KEY ([ParameterId]) REFERENCES [Parameters] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_ProductParameters_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627210713_InitialCreate')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Roles]'))
        SET IDENTITY_INSERT [Roles] ON;
    INSERT INTO [Roles] ([Id], [Name])
    VALUES (1, N'admin');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Roles]'))
        SET IDENTITY_INSERT [Roles] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627210713_InitialCreate')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Roles]'))
        SET IDENTITY_INSERT [Roles] ON;
    INSERT INTO [Roles] ([Id], [Name])
    VALUES (2, N'user');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Roles]'))
        SET IDENTITY_INSERT [Roles] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627210713_InitialCreate')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Email', N'Password', N'RoleId') AND [object_id] = OBJECT_ID(N'[Users]'))
        SET IDENTITY_INSERT [Users] ON;
    INSERT INTO [Users] ([Id], [Email], [Password], [RoleId])
    VALUES (1, N'admin@gmail.com', N'12345', 1);
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Email', N'Password', N'RoleId') AND [object_id] = OBJECT_ID(N'[Users]'))
        SET IDENTITY_INSERT [Users] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627210713_InitialCreate')
BEGIN
    CREATE INDEX [IX_OrderProducts_OrderId] ON [OrderProducts] ([OrderId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627210713_InitialCreate')
BEGIN
    CREATE INDEX [IX_OrderProducts_ProductId] ON [OrderProducts] ([ProductId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627210713_InitialCreate')
BEGIN
    CREATE INDEX [IX_Parameters_ProductTypeId] ON [Parameters] ([ProductTypeId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627210713_InitialCreate')
BEGIN
    CREATE INDEX [IX_ProductParameters_ParameterId] ON [ProductParameters] ([ParameterId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627210713_InitialCreate')
BEGIN
    CREATE INDEX [IX_ProductParameters_ProductId] ON [ProductParameters] ([ProductId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627210713_InitialCreate')
BEGIN
    CREATE INDEX [IX_Products_ProductTypeId] ON [Products] ([ProductTypeId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627210713_InitialCreate')
BEGIN
    CREATE INDEX [IX_Users_RoleId] ON [Users] ([RoleId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627210713_InitialCreate')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190627210713_InitialCreate', N'2.2.4-servicing-10062');
END;

GO

