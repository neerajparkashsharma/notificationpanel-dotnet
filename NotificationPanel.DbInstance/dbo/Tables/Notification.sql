CREATE TABLE [dbo].[Notification] (
    [Id]               BIGINT         IDENTITY (1, 1) NOT NULL,
    [NotificationText] NVARCHAR (MAX) NULL,
    [IsActive]         BIT            NULL,
    [CreatedBy]        BIGINT         NULL,
    [CreatedOn]        DATETIME       NULL,
    [UpdatedBy]        BIGINT         NULL,
    [UpdatedOn]        DATETIME       NULL,
    [Image]            NVARCHAR (MAX) NULL,
    [Subject]          NVARCHAR (MAX) NULL,
    [SenderId]         BIGINT         NULL,
    [ReceiverId]       BIGINT         NULL,
    [IsRead]           BIT            NULL,
    CONSTRAINT [PK_Notification] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Notification_User] FOREIGN KEY ([SenderId]) REFERENCES [dbo].[User] ([Id]),
    CONSTRAINT [FK_Notification_User1] FOREIGN KEY ([ReceiverId]) REFERENCES [dbo].[User] ([Id])
);



