MERGE INTO [Info].[HappinessLevel] AS [Target]
USING (VALUES
  (0,N'Salty')
 ,(1,N'Okay')
 ,(3,N'Happy')
 ,(4,N'Ecstatic')
) AS [Source] ([Id],[Description])
ON ([Target].[Id] = [Source].[Id])
WHEN MATCHED THEN 
	UPDATE SET [Target].[Description] = [Source].[Description]
WHEN NOT MATCHED BY TARGET THEN
	INSERT([Id],[Description])
	VALUES([Source].[Id],[Source].[Description])
WHEN NOT MATCHED BY SOURCE THEN 
	DELETE;