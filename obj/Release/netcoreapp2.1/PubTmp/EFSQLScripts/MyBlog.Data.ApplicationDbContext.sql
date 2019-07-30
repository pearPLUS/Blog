IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE TABLE [AspNetUsers] (
        [Id] nvarchar(450) NOT NULL,
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'00000000000000_CreateIdentitySchema', N'2.1.11-servicing-32099');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190628200326_CategoryModel')
BEGIN
    ALTER TABLE [Blog] ADD [CategoryId] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190628200326_CategoryModel')
BEGIN
    ALTER TABLE [Blog] ADD [CatergoryId] int NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190628200326_CategoryModel')
BEGIN
    CREATE TABLE [Catergory] (
        [catergory_id] int NOT NULL IDENTITY,
        [catergory_name] nvarchar(max) NOT NULL,
        [catergory_description] nvarchar(max) NULL,
        CONSTRAINT [PK_Catergory] PRIMARY KEY ([catergory_id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190628200326_CategoryModel')
BEGIN
    CREATE INDEX [IX_Blog_CatergoryId] ON [Blog] ([CatergoryId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190628200326_CategoryModel')
BEGIN
    ALTER TABLE [Blog] ADD CONSTRAINT [FK_Blog_Catergory_CatergoryId] FOREIGN KEY ([CatergoryId]) REFERENCES [Catergory] ([catergory_id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190628200326_CategoryModel')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190628200326_CategoryModel', N'2.1.11-servicing-32099');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190628200653_catergoryModel2')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Catergory]') AND [c].[name] = N'catergory_name');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Catergory] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [Catergory] ALTER COLUMN [catergory_name] nvarchar(10) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190628200653_catergoryModel2')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190628200653_catergoryModel2', N'2.1.11-servicing-32099');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190702145128_BlogModle')
BEGIN
    CREATE TABLE [Blog] (
        [Blog_id] int NOT NULL IDENTITY,
        [user_name] nvarchar(max) NOT NULL,
        [FkCatergory] int NOT NULL,
        [Blog_title] nvarchar(max) NOT NULL,
        [Blog_brief] nvarchar(max) NOT NULL,
        [Blog_content] nvarchar(max) NOT NULL,
        [Blog_tabs] nvarchar(max) NULL,
        [Blog_date] datetime2 NOT NULL,
        [Blog_like_count] int NOT NULL,
        [Blog_comment_count] int NOT NULL,
        [Blog_views] int NOT NULL,
        CONSTRAINT [PK_Blog] PRIMARY KEY ([Blog_id]),
        CONSTRAINT [FK_Blog_Catergory_FkCatergory] FOREIGN KEY ([FkCatergory]) REFERENCES [Catergory] ([catergory_id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190702145128_BlogModle')
BEGIN
    CREATE INDEX [IX_Blog_FkCatergory] ON [Blog] ([FkCatergory]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190702145128_BlogModle')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190702145128_BlogModle', N'2.1.11-servicing-32099');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190702202014_BlogModel1')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Blog]') AND [c].[name] = N'blog_tabs');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Blog] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [Blog] DROP COLUMN [blog_tabs];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190702202014_BlogModel1')
BEGIN
    CREATE TABLE [label] (
        [label_id] int NOT NULL IDENTITY,
        [label_name] nvarchar(max) NOT NULL,
        [label_description] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_label] PRIMARY KEY ([label_id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190702202014_BlogModel1')
BEGIN
    CREATE TABLE [BlogLabel] (
        [BlogId] int NOT NULL,
        [LabelId] int NOT NULL,
        CONSTRAINT [PK_BlogLabel] PRIMARY KEY ([BlogId], [LabelId]),
        CONSTRAINT [FK_BlogLabel_Blog_BlogId] FOREIGN KEY ([BlogId]) REFERENCES [Blog] ([blog_id]) ON DELETE CASCADE,
        CONSTRAINT [FK_BlogLabel_label_LabelId] FOREIGN KEY ([LabelId]) REFERENCES [label] ([label_id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190702202014_BlogModel1')
BEGIN
    CREATE INDEX [IX_BlogLabel_LabelId] ON [BlogLabel] ([LabelId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190702202014_BlogModel1')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190702202014_BlogModel1', N'2.1.11-servicing-32099');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190705132458_ApplicationUser')
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AspNetUserTokens]') AND [c].[name] = N'Name');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [AspNetUserTokens] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [AspNetUserTokens] ALTER COLUMN [Name] nvarchar(450) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190705132458_ApplicationUser')
BEGIN
    DECLARE @var3 sysname;
    SELECT @var3 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AspNetUserTokens]') AND [c].[name] = N'LoginProvider');
    IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [AspNetUserTokens] DROP CONSTRAINT [' + @var3 + '];');
    ALTER TABLE [AspNetUserTokens] ALTER COLUMN [LoginProvider] nvarchar(450) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190705132458_ApplicationUser')
BEGIN
    DECLARE @var4 sysname;
    SELECT @var4 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AspNetUserLogins]') AND [c].[name] = N'ProviderKey');
    IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [AspNetUserLogins] DROP CONSTRAINT [' + @var4 + '];');
    ALTER TABLE [AspNetUserLogins] ALTER COLUMN [ProviderKey] nvarchar(450) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190705132458_ApplicationUser')
BEGIN
    DECLARE @var5 sysname;
    SELECT @var5 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AspNetUserLogins]') AND [c].[name] = N'LoginProvider');
    IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [AspNetUserLogins] DROP CONSTRAINT [' + @var5 + '];');
    ALTER TABLE [AspNetUserLogins] ALTER COLUMN [LoginProvider] nvarchar(450) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190705132458_ApplicationUser')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190705132458_ApplicationUser', N'2.1.11-servicing-32099');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190705142947_IdentityUserCustome')
BEGIN
    DROP TABLE [User];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190705142947_IdentityUserCustome')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [user_birthday] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190705142947_IdentityUserCustome')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [user_name] nvarchar(max) NOT NULL DEFAULT N'';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190705142947_IdentityUserCustome')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [user_profile_photo] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190705142947_IdentityUserCustome')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [user_regisration_time] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190705142947_IdentityUserCustome')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [user_age] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190705142947_IdentityUserCustome')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190705142947_IdentityUserCustome', N'2.1.11-servicing-32099');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190705192147_ApplicationRecovery')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190705192147_ApplicationRecovery', N'2.1.11-servicing-32099');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190705192628_ApplicationBlog')
BEGIN
    ALTER TABLE [Blog] ADD [FKApplicationUser] nvarchar(450) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190705192628_ApplicationBlog')
BEGIN
    CREATE INDEX [IX_Blog_FKApplicationUser] ON [Blog] ([FKApplicationUser]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190705192628_ApplicationBlog')
BEGIN
    ALTER TABLE [Blog] ADD CONSTRAINT [FK_Blog_AspNetUsers_FKApplicationUser] FOREIGN KEY ([FKApplicationUser]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190705192628_ApplicationBlog')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190705192628_ApplicationBlog', N'2.1.11-servicing-32099');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190705192847_BlogUser')
BEGIN
    ALTER TABLE [Blog] DROP CONSTRAINT [FK_Blog_AspNetUsers_FKApplicationUser];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190705192847_BlogUser')
BEGIN
    DROP INDEX [IX_Blog_FKApplicationUser] ON [Blog];
    DECLARE @var6 sysname;
    SELECT @var6 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Blog]') AND [c].[name] = N'FKApplicationUser');
    IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [Blog] DROP CONSTRAINT [' + @var6 + '];');
    ALTER TABLE [Blog] ALTER COLUMN [FKApplicationUser] nvarchar(450) NOT NULL;
    CREATE INDEX [IX_Blog_FKApplicationUser] ON [Blog] ([FKApplicationUser]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190705192847_BlogUser')
BEGIN
    ALTER TABLE [Blog] ADD CONSTRAINT [FK_Blog_AspNetUsers_FKApplicationUser] FOREIGN KEY ([FKApplicationUser]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190705192847_BlogUser')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190705192847_BlogUser', N'2.1.11-servicing-32099');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190705195053_UserArticleCount')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [article_count] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190705195053_UserArticleCount')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190705195053_UserArticleCount', N'2.1.11-servicing-32099');
END;

GO

