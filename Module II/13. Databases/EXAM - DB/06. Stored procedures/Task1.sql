USE [ComputersDb]
GO
	CREATE PROC	usp_GetComputersWithRamBetween(@minVal int, @maxVal int)
	AS
	SELECT c.Id, c.Memory
	From Computers c
	WHERE c.Memory >= @minVal AND c.Memory <= @maxVal
GO
DECLARE @min int = 1;
DECLARE @max int = 4;

EXEC usp_GetComputersWithRamBetween @min, @max