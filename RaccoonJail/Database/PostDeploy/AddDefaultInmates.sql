INSERT INTO [Jail].[Inmate]
SELECT NewInmates.[Name], NewInmates.[SizeInOz], NewInmates.[TimeServedInMonths], NewInmates.[ArrestLocationId], NewInmates.[HappinessLevelId], NewInmates.[HungerLevelId]
FROM (
	VALUES 
	(N'Dan Fields', 454, 12, 1, 1, 1)
	,(N'Matt Wagner', 562, 36, 2, 1, 1)
	)
	AS NewInmates ([Name],[SizeInOz], [TimeServedInMonths], [ArrestLocationId], [HappinessLevelId], [HungerLevelId])
WHERE NOT EXISTS (SELECT 1 FROM [Jail].[Inmate] AS TARGET WHERE TARGET.[Name] = NewInmates.[Name])
		