MERGE INTO [Jail].[Inmate] AS [Target]
USING (VALUES
	(N'Dan Fields', 454, 12, 1, 1, 1)
	,(N'Matt Wagner', 562, 36, 2, 1, 1)
) AS [Source] ([Name],[SizeInOz], [TimeServedInMonths], [ArrestLocationId], [HappinessLevelId], [HungerLevelId])
ON ([Target].[Name] = [Source].[Name])
WHEN MATCHED THEN 
	UPDATE SET 
	[Target].[SizeInOz] = [Source].[SizeInOz]
	,[Target].[TimeServedInMonths] = [Source].[TimeServedInMonths]
	,[Target].[ArrestLocation] = [Source].[ArrestLocation]
	,[Target].[HappinessLevelId] = [Source].[HappinessLevelId]
	,[Target].[HungerLevelId] = [Source].[HungerLevelId]
WHEN NOT MATCHED BY TARGET THEN
	INSERT([Name],[SizeInOz], [TimeServedInMonths], [ArrestLocation], [HappinessLevelId], [HungerLevelId])
	VALUES([Source].[Name], [Source].[SizeInOz], [Source].[TimeServedInMonths], [Source].[ArrestLocation], [Source].[HappinessLevelId], [Source].[HungerLevelId])
WHEN NOT MATCHED BY SOURCE THEN 
	DELETE;