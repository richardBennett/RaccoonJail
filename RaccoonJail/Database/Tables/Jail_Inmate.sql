CREATE TABLE [Jail].[Inmate]
(
	[Id] BIGINT NOT NULL PRIMARY KEY, 
    [Name] NCHAR(100) NOT NULL, 
    [Size] DECIMAL(9, 6) NULL,
    [ArrestLocationId] INT NOT NULL,
    [HappinessLevelId] INT NOT NULL, 
    [HungerLevelId] INT NOT NULL
)
