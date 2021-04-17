CREATE TABLE [dbo].[tblUser] (
    [UserId]            INT           IDENTITY (1, 1) NOT NULL,
    [UserName]          VARCHAR (100) NOT NULL,
    [Password]          VARCHAR (100) NOT NULL,
    [EmailAddress]      VARCHAR (100) NOT NULL,
    [MobileNumber]      VARCHAR (100) NOT NULL,
    [RoleId]            INT           NOT NULL,
    [IsProfileComplete] BIT           NOT NULL,
    [IsActive]          BIT           NOT NULL,
    [CreatedBy]         INT           NULL,
    [CreatedDate]       DATETIME      NOT NULL,
    [ModifiedBy]        INT           NULL,
    [ModifiedDate]      DATETIME      NOT NULL,
    FOREIGN KEY ([RoleId]) REFERENCES [dbo].[tblRole] ([RoleId]),
    UNIQUE NONCLUSTERED ([EmailAddress] ASC)
);



