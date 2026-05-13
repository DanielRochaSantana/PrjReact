CREATE TABLE [dbo].[Usuario] (
    [Id]              UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Nome]            VARCHAR (255)    NULL,
    [Email]           VARCHAR (100)    NULL,
    [Celular]         VARCHAR (30)     NULL,
    [DataCadastro]    DATETIME         NULL,
    [DataModificacao] DATETIME         NULL,
    [IsAtivo]         BIT              DEFAULT ((1)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

