USE [ComputersDb]
GO
	CREATE PROC	usp_GetGpusForComputerType(@type nvarchar)
	AS
	SELECT c.Id, ct.Type
	From Computers c
	Join ComputerTypes ct
	on ct.Id = c.Id
	WHERE ct.Type = @type
GO
DECLARE @currentType nvarchar = 'Ultrabook'

EXEC usp_GetGpusForComputerType @currentType
