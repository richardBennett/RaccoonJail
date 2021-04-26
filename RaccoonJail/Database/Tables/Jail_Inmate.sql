CREATE TABLE [Jail].[Inmate]
(
	[Id] BIGINT NOT NULL IDENTITY(1,1), 
    [Name] NCHAR(100) NOT NULL, 
    [SizeInOz] DECIMAL(9, 6) NOT NULL,
    [TimeServedInMonths] INT NOT NULL,
    [ArrestLocationId] INT NOT NULL,
    [HappinessLevelId] INT NOT NULL, 
    [HungerLevelId] INT NOT NULL,
    CONSTRAINT [PK_Jail_Inmate] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Jail_Inmate_Info_ArrestLocation] FOREIGN KEY ([ArrestLocationId]) REFERENCES [Info].[ArrestLocation] ([Id]),
    CONSTRAINT [FK_Jail_Inmate_Info_HappinessLevel] FOREIGN KEY ([HappinessLevelId]) REFERENCES [Info].[HappinessLevel] ([Id]),
    CONSTRAINT [FK_Jail_Inmate_Info_HungerLevel] FOREIGN KEY ([HungerLevelId]) REFERENCES [Info].[HungerLevel] ([Id])
)
