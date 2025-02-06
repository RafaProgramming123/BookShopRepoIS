IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240821180015_ahah'
)
BEGIN
    CREATE TABLE [AspNetRoles] (
        [Id] nvarchar(450) NOT NULL,
        [Name] nvarchar(256) NULL,
        [NormalizedName] nvarchar(256) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240821180015_ahah'
)
BEGIN
    CREATE TABLE [AspNetUsers] (
        [Id] nvarchar(450) NOT NULL,
        [FirstName] nvarchar(max) NULL,
        [LastName] nvarchar(max) NULL,
        [Address] nvarchar(max) NULL,
        [UserName] nvarchar(256) NULL,
        [NormalizedUserName] nvarchar(256) NULL,
        [Email] nvarchar(256) NULL,
        [NormalizedEmail] nvarchar(256) NULL,
        [EmailConfirmed] bit NOT NULL,
        [PasswordHash] nvarchar(max) NULL,
        [SecurityStamp] nvarchar(max) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [PhoneNumberConfirmed] bit NOT NULL,
        [TwoFactorEnabled] bit NOT NULL,
        [LockoutEnd] datetimeoffset NULL,
        [LockoutEnabled] bit NOT NULL,
        [AccessFailedCount] int NOT NULL,
        CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240821180015_ahah'
)
BEGIN
    CREATE TABLE [Authors] (
        [Id] uniqueidentifier NOT NULL,
        [Name] nvarchar(max) NULL,
        [Surname] nvarchar(max) NULL,
        [YearBorn] date NULL,
        CONSTRAINT [PK_Authors] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240821180015_ahah'
)
BEGIN
    CREATE TABLE [Publishers] (
        [Id] uniqueidentifier NOT NULL,
        [Name] nvarchar(max) NULL,
        [Location] nvarchar(max) NULL,
        CONSTRAINT [PK_Publishers] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240821180015_ahah'
)
BEGIN
    CREATE TABLE [AspNetRoleClaims] (
        [Id] int NOT NULL IDENTITY,
        [RoleId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240821180015_ahah'
)
BEGIN
    CREATE TABLE [AspNetUserClaims] (
        [Id] int NOT NULL IDENTITY,
        [UserId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240821180015_ahah'
)
BEGIN
    CREATE TABLE [AspNetUserLogins] (
        [LoginProvider] nvarchar(128) NOT NULL,
        [ProviderKey] nvarchar(128) NOT NULL,
        [ProviderDisplayName] nvarchar(max) NULL,
        [UserId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
        CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240821180015_ahah'
)
BEGIN
    CREATE TABLE [AspNetUserRoles] (
        [UserId] nvarchar(450) NOT NULL,
        [RoleId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
        CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240821180015_ahah'
)
BEGIN
    CREATE TABLE [AspNetUserTokens] (
        [UserId] nvarchar(450) NOT NULL,
        [LoginProvider] nvarchar(128) NOT NULL,
        [Name] nvarchar(128) NOT NULL,
        [Value] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
        CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240821180015_ahah'
)
BEGIN
    CREATE TABLE [Books] (
        [Id] uniqueidentifier NOT NULL,
        [Title] nvarchar(max) NULL,
        [Description] nvarchar(max) NULL,
        [Price] float NULL,
        [Rating] float NULL,
        [Genre] nvarchar(max) NULL,
        [Image] nvarchar(max) NULL,
        [AuthorId] uniqueidentifier NULL,
        CONSTRAINT [PK_Books] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Books_Authors_AuthorId] FOREIGN KEY ([AuthorId]) REFERENCES [Authors] ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240821180015_ahah'
)
BEGIN
    CREATE TABLE [BooksPublisher] (
        [Id] uniqueidentifier NOT NULL,
        [BookId] uniqueidentifier NULL,
        [PublisherId] uniqueidentifier NULL,
        CONSTRAINT [PK_BooksPublisher] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_BooksPublisher_Books_BookId] FOREIGN KEY ([BookId]) REFERENCES [Books] ([Id]),
        CONSTRAINT [FK_BooksPublisher_Publishers_PublisherId] FOREIGN KEY ([PublisherId]) REFERENCES [Publishers] ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240821180015_ahah'
)
BEGIN
    CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240821180015_ahah'
)
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240821180015_ahah'
)
BEGIN
    CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240821180015_ahah'
)
BEGIN
    CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240821180015_ahah'
)
BEGIN
    CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240821180015_ahah'
)
BEGIN
    CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240821180015_ahah'
)
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240821180015_ahah'
)
BEGIN
    CREATE INDEX [IX_Books_AuthorId] ON [Books] ([AuthorId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240821180015_ahah'
)
BEGIN
    CREATE INDEX [IX_BooksPublisher_BookId] ON [BooksPublisher] ([BookId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240821180015_ahah'
)
BEGIN
    CREATE INDEX [IX_BooksPublisher_PublisherId] ON [BooksPublisher] ([PublisherId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240821180015_ahah'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240821180015_ahah', N'8.0.3');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240826170132_ashoppingcartbrale'
)
BEGIN
    CREATE TABLE [ShoppingCart] (
        [Id] uniqueidentifier NOT NULL,
        [OwnerId] nvarchar(450) NULL,
        CONSTRAINT [PK_ShoppingCart] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_ShoppingCart_AspNetUsers_OwnerId] FOREIGN KEY ([OwnerId]) REFERENCES [AspNetUsers] ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240826170132_ashoppingcartbrale'
)
BEGIN
    CREATE TABLE [BookInShoppingCart] (
        [Id] uniqueidentifier NOT NULL,
        [BookId] uniqueidentifier NOT NULL,
        [ShoppingCartId] uniqueidentifier NOT NULL,
        [Quantity] int NOT NULL,
        CONSTRAINT [PK_BookInShoppingCart] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_BookInShoppingCart_Books_BookId] FOREIGN KEY ([BookId]) REFERENCES [Books] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_BookInShoppingCart_ShoppingCart_ShoppingCartId] FOREIGN KEY ([ShoppingCartId]) REFERENCES [ShoppingCart] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240826170132_ashoppingcartbrale'
)
BEGIN
    CREATE INDEX [IX_BookInShoppingCart_BookId] ON [BookInShoppingCart] ([BookId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240826170132_ashoppingcartbrale'
)
BEGIN
    CREATE INDEX [IX_BookInShoppingCart_ShoppingCartId] ON [BookInShoppingCart] ([ShoppingCartId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240826170132_ashoppingcartbrale'
)
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [IX_ShoppingCart_OwnerId] ON [ShoppingCart] ([OwnerId]) WHERE [OwnerId] IS NOT NULL');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240826170132_ashoppingcartbrale'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240826170132_ashoppingcartbrale', N'8.0.3');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240827171331_order'
)
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Books]') AND [c].[name] = N'Price');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Books] DROP CONSTRAINT [' + @var0 + '];');
    EXEC(N'UPDATE [Books] SET [Price] = 0.0E0 WHERE [Price] IS NULL');
    ALTER TABLE [Books] ALTER COLUMN [Price] float NOT NULL;
    ALTER TABLE [Books] ADD DEFAULT 0.0E0 FOR [Price];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240827171331_order'
)
BEGIN
    CREATE TABLE [Order] (
        [Id] uniqueidentifier NOT NULL,
        [userId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_Order] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Order_AspNetUsers_userId] FOREIGN KEY ([userId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240827171331_order'
)
BEGIN
    CREATE TABLE [BookInOrder] (
        [Id] uniqueidentifier NOT NULL,
        [BookId] uniqueidentifier NOT NULL,
        [OrderId] uniqueidentifier NOT NULL,
        [Quantity] int NOT NULL,
        CONSTRAINT [PK_BookInOrder] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_BookInOrder_Books_BookId] FOREIGN KEY ([BookId]) REFERENCES [Books] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_BookInOrder_Order_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [Order] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240827171331_order'
)
BEGIN
    CREATE INDEX [IX_BookInOrder_BookId] ON [BookInOrder] ([BookId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240827171331_order'
)
BEGIN
    CREATE INDEX [IX_BookInOrder_OrderId] ON [BookInOrder] ([OrderId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240827171331_order'
)
BEGIN
    CREATE INDEX [IX_Order_userId] ON [Order] ([userId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240827171331_order'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240827171331_order', N'8.0.3');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240827172047_ordergg'
)
BEGIN
    ALTER TABLE [BookInOrder] DROP CONSTRAINT [FK_BookInOrder_Order_OrderId];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240827172047_ordergg'
)
BEGIN
    ALTER TABLE [BookInShoppingCart] DROP CONSTRAINT [FK_BookInShoppingCart_Books_BookId];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240827172047_ordergg'
)
BEGIN
    ALTER TABLE [BookInShoppingCart] DROP CONSTRAINT [FK_BookInShoppingCart_ShoppingCart_ShoppingCartId];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240827172047_ordergg'
)
BEGIN
    ALTER TABLE [Order] DROP CONSTRAINT [FK_Order_AspNetUsers_userId];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240827172047_ordergg'
)
BEGIN
    ALTER TABLE [ShoppingCart] DROP CONSTRAINT [FK_ShoppingCart_AspNetUsers_OwnerId];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240827172047_ordergg'
)
BEGIN
    ALTER TABLE [ShoppingCart] DROP CONSTRAINT [PK_ShoppingCart];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240827172047_ordergg'
)
BEGIN
    ALTER TABLE [Order] DROP CONSTRAINT [PK_Order];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240827172047_ordergg'
)
BEGIN
    ALTER TABLE [BookInShoppingCart] DROP CONSTRAINT [PK_BookInShoppingCart];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240827172047_ordergg'
)
BEGIN
    EXEC sp_rename N'[ShoppingCart]', N'ShoppingCarts';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240827172047_ordergg'
)
BEGIN
    EXEC sp_rename N'[Order]', N'Orders';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240827172047_ordergg'
)
BEGIN
    EXEC sp_rename N'[BookInShoppingCart]', N'BookInShoppingCarts';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240827172047_ordergg'
)
BEGIN
    EXEC sp_rename N'[ShoppingCarts].[IX_ShoppingCart_OwnerId]', N'IX_ShoppingCarts_OwnerId', N'INDEX';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240827172047_ordergg'
)
BEGIN
    EXEC sp_rename N'[Orders].[IX_Order_userId]', N'IX_Orders_userId', N'INDEX';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240827172047_ordergg'
)
BEGIN
    EXEC sp_rename N'[BookInShoppingCarts].[IX_BookInShoppingCart_ShoppingCartId]', N'IX_BookInShoppingCarts_ShoppingCartId', N'INDEX';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240827172047_ordergg'
)
BEGIN
    EXEC sp_rename N'[BookInShoppingCarts].[IX_BookInShoppingCart_BookId]', N'IX_BookInShoppingCarts_BookId', N'INDEX';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240827172047_ordergg'
)
BEGIN
    ALTER TABLE [ShoppingCarts] ADD CONSTRAINT [PK_ShoppingCarts] PRIMARY KEY ([Id]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240827172047_ordergg'
)
BEGIN
    ALTER TABLE [Orders] ADD CONSTRAINT [PK_Orders] PRIMARY KEY ([Id]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240827172047_ordergg'
)
BEGIN
    ALTER TABLE [BookInShoppingCarts] ADD CONSTRAINT [PK_BookInShoppingCarts] PRIMARY KEY ([Id]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240827172047_ordergg'
)
BEGIN
    ALTER TABLE [BookInOrder] ADD CONSTRAINT [FK_BookInOrder_Orders_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [Orders] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240827172047_ordergg'
)
BEGIN
    ALTER TABLE [BookInShoppingCarts] ADD CONSTRAINT [FK_BookInShoppingCarts_Books_BookId] FOREIGN KEY ([BookId]) REFERENCES [Books] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240827172047_ordergg'
)
BEGIN
    ALTER TABLE [BookInShoppingCarts] ADD CONSTRAINT [FK_BookInShoppingCarts_ShoppingCarts_ShoppingCartId] FOREIGN KEY ([ShoppingCartId]) REFERENCES [ShoppingCarts] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240827172047_ordergg'
)
BEGIN
    ALTER TABLE [Orders] ADD CONSTRAINT [FK_Orders_AspNetUsers_userId] FOREIGN KEY ([userId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240827172047_ordergg'
)
BEGIN
    ALTER TABLE [ShoppingCarts] ADD CONSTRAINT [FK_ShoppingCarts_AspNetUsers_OwnerId] FOREIGN KEY ([OwnerId]) REFERENCES [AspNetUsers] ([Id]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240827172047_ordergg'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240827172047_ordergg', N'8.0.3');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240827172856_orderggf'
)
BEGIN
    ALTER TABLE [BookInOrder] DROP CONSTRAINT [FK_BookInOrder_Orders_OrderId];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240827172856_orderggf'
)
BEGIN
    ALTER TABLE [BookInShoppingCarts] DROP CONSTRAINT [FK_BookInShoppingCarts_Books_BookId];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240827172856_orderggf'
)
BEGIN
    ALTER TABLE [BookInShoppingCarts] DROP CONSTRAINT [FK_BookInShoppingCarts_ShoppingCarts_ShoppingCartId];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240827172856_orderggf'
)
BEGIN
    ALTER TABLE [Orders] DROP CONSTRAINT [FK_Orders_AspNetUsers_userId];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240827172856_orderggf'
)
BEGIN
    ALTER TABLE [ShoppingCarts] DROP CONSTRAINT [FK_ShoppingCarts_AspNetUsers_OwnerId];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240827172856_orderggf'
)
BEGIN
    ALTER TABLE [ShoppingCarts] DROP CONSTRAINT [PK_ShoppingCarts];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240827172856_orderggf'
)
BEGIN
    ALTER TABLE [Orders] DROP CONSTRAINT [PK_Orders];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240827172856_orderggf'
)
BEGIN
    ALTER TABLE [BookInShoppingCarts] DROP CONSTRAINT [PK_BookInShoppingCarts];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240827172856_orderggf'
)
BEGIN
    EXEC sp_rename N'[ShoppingCarts]', N'ShoppingCart';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240827172856_orderggf'
)
BEGIN
    EXEC sp_rename N'[Orders]', N'Order';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240827172856_orderggf'
)
BEGIN
    EXEC sp_rename N'[BookInShoppingCarts]', N'BookInShoppingCart';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240827172856_orderggf'
)
BEGIN
    EXEC sp_rename N'[ShoppingCart].[IX_ShoppingCarts_OwnerId]', N'IX_ShoppingCart_OwnerId', N'INDEX';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240827172856_orderggf'
)
BEGIN
    EXEC sp_rename N'[Order].[IX_Orders_userId]', N'IX_Order_userId', N'INDEX';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240827172856_orderggf'
)
BEGIN
    EXEC sp_rename N'[BookInShoppingCart].[IX_BookInShoppingCarts_ShoppingCartId]', N'IX_BookInShoppingCart_ShoppingCartId', N'INDEX';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240827172856_orderggf'
)
BEGIN
    EXEC sp_rename N'[BookInShoppingCart].[IX_BookInShoppingCarts_BookId]', N'IX_BookInShoppingCart_BookId', N'INDEX';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240827172856_orderggf'
)
BEGIN
    ALTER TABLE [ShoppingCart] ADD CONSTRAINT [PK_ShoppingCart] PRIMARY KEY ([Id]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240827172856_orderggf'
)
BEGIN
    ALTER TABLE [Order] ADD CONSTRAINT [PK_Order] PRIMARY KEY ([Id]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240827172856_orderggf'
)
BEGIN
    ALTER TABLE [BookInShoppingCart] ADD CONSTRAINT [PK_BookInShoppingCart] PRIMARY KEY ([Id]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240827172856_orderggf'
)
BEGIN
    ALTER TABLE [BookInOrder] ADD CONSTRAINT [FK_BookInOrder_Order_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [Order] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240827172856_orderggf'
)
BEGIN
    ALTER TABLE [BookInShoppingCart] ADD CONSTRAINT [FK_BookInShoppingCart_Books_BookId] FOREIGN KEY ([BookId]) REFERENCES [Books] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240827172856_orderggf'
)
BEGIN
    ALTER TABLE [BookInShoppingCart] ADD CONSTRAINT [FK_BookInShoppingCart_ShoppingCart_ShoppingCartId] FOREIGN KEY ([ShoppingCartId]) REFERENCES [ShoppingCart] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240827172856_orderggf'
)
BEGIN
    ALTER TABLE [Order] ADD CONSTRAINT [FK_Order_AspNetUsers_userId] FOREIGN KEY ([userId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240827172856_orderggf'
)
BEGIN
    ALTER TABLE [ShoppingCart] ADD CONSTRAINT [FK_ShoppingCart_AspNetUsers_OwnerId] FOREIGN KEY ([OwnerId]) REFERENCES [AspNetUsers] ([Id]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240827172856_orderggf'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240827172856_orderggf', N'8.0.3');
END;
GO

COMMIT;
GO

