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
CREATE TABLE [EquipmentType] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(max) NOT NULL,
    [Description] nvarchar(max) NULL,
    CONSTRAINT [PK_EquipmentType] PRIMARY KEY ([Id])
);

CREATE TABLE [Equipment] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(max) NOT NULL,
    [EquipmentTypeId] uniqueidentifier NOT NULL,
    [IsEnabled] bit NOT NULL,
    CONSTRAINT [PK_Equipment] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Equipment_EquipmentType_EquipmentTypeId] FOREIGN KEY ([EquipmentTypeId]) REFERENCES [EquipmentType] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [EquipmentReading] (
    [Id] uniqueidentifier NOT NULL,
    [EquipmentId] uniqueidentifier NOT NULL,
    [Status] int NOT NULL,
    [PowerValue] decimal(18,2) NOT NULL,
    [PowerUnit] int NOT NULL,
    [ObservedAtUtc] datetime2 NOT NULL,
    CONSTRAINT [PK_EquipmentReading] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_EquipmentReading_Equipment_EquipmentId] FOREIGN KEY ([EquipmentId]) REFERENCES [Equipment] ([Id]) ON DELETE CASCADE
);

CREATE INDEX [IX_Equipment_EquipmentTypeId] ON [Equipment] ([EquipmentTypeId]);

CREATE INDEX [IX_EquipmentReading_EquipmentId] ON [EquipmentReading] ([EquipmentId]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20261125073221_InitialCreate', N'10.0.15');

COMMIT;
GO

BEGIN TRANSACTION;
DECLARE @var nvarchar(max);
SELECT @var = QUOTENAME([d].[name])
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[EquipmentReading]') AND [c].[name] = N'PowerValue');
IF @var IS NOT NULL EXEC(N'ALTER TABLE [EquipmentReading] DROP CONSTRAINT ' + @var + ';');
ALTER TABLE [EquipmentReading] ALTER COLUMN [PowerValue] decimal(18,4) NOT NULL;

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20261125075157_ModifiedV01', N'10.0.15');

COMMIT;
GO

