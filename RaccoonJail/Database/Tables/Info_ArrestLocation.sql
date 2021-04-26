CREATE TABLE [Info].[ArrestLocation]
(
	[Id] INT NOT NULL, 
    [Location] NVARCHAR(100) NOT NULL,
	CONSTRAINT [PK_Info_ArrestLocation] PRIMARY KEY CLUSTERED ([Id] ASC),
)
