CREATE TABLE [dbo].[Food] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [TenFood]    NVARCHAR (MAX) NULL,
    [NguyenLieu] NVARCHAR (MAX) NULL,
    [Calories] INT NOT NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

