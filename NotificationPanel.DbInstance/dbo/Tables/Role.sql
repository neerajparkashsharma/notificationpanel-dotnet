CREATE TABLE [dbo].[Role] (
    [Id]        BIGINT         IDENTITY (1, 1) NOT NULL,
    [Name]      NVARCHAR (MAX) NULL,
    [IsActive]  BIT            NULL,
    [CreatedBy] BIGINT         NULL,
    [CreatedOn] DATETIME       NULL,
    [UpdatedBy] BIGINT         NULL,
    [UpdatedOn] DATETIME       NULL,
    CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED ([Id] ASC)
);

