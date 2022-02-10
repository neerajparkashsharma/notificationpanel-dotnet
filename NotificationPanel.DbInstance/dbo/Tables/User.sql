CREATE TABLE [dbo].[User] (
    [Id]                 BIGINT         IDENTITY (1, 1) NOT NULL,
    [Name]               NVARCHAR (MAX) NULL,
    [IsActive]           BIT            NULL,
    [CreatedBy]          BIGINT         NULL,
    [CreatedOn]          DATETIME       NULL,
    [UpdatedBy]          BIGINT         NULL,
    [UpdatedOn]          DATETIME       NULL,
    [RoleId]             BIGINT         NULL,
    [Email]              NVARCHAR (MAX) NULL,
    [Password]           NVARCHAR (MAX) NULL,
    [DOB]                DATETIME       NULL,
    [Gender]             NVARCHAR (MAX) NULL,
    [Image]              NVARCHAR (MAX) NULL,
    [Address]            NVARCHAR (MAX) NULL,
    [IsOnline]           BIT            NULL,
    [LastOnlineDateTime] DATETIME       NULL,
    [Phone]              VARCHAR (MAX)  NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_User_Role] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Role] ([Id])
);



