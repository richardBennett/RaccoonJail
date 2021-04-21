MERGE INTO [Info].[ArrestLocation] AS [Target]
USING (VALUES
  (0,N'Dumpster behind Domino''s')
 ,(1,N'Kitchen of Tupelo Honey')
 ,(3,N'Spartanburg Dump')
 ,(4,N'Easley Town Hall')
) AS [Source] ([Id],[Location])
ON ([Target].[Id] = [Source].[Id])
WHEN MATCHED THEN 
	UPDATE SET [Target].[Location] = [Source].[Location]
WHEN NOT MATCHED BY TARGET THEN
	INSERT([Id],[Location])
	VALUES([Source].[Id],[Source].[Location])
WHEN NOT MATCHED BY SOURCE THEN 
	DELETE;