MERGE INTO [Info].[HungerLevel] AS [Target]
USING (VALUES
	(0,N'Undefined')
	,(1,N'Starving')
	,(2,N'Hungry')
	,(3,N'Full')
	,(4,N'Stuffed')
) AS [Source] ([Id],[Description])
ON ([Target].[Id] = [Source].[Id])
WHEN MATCHED THEN 
	UPDATE SET [Target].[Description] = [Source].[Description]
WHEN NOT MATCHED BY TARGET THEN
	INSERT([Id],[Description])
	VALUES([Source].[Id],[Source].[Description])
WHEN NOT MATCHED BY SOURCE THEN 
	DELETE;