--Create a database with two tables: Persons(Id(PK), FirstName, LastName, SSN) and Accounts(Id(PK), PersonId(FK), Balance).
--Insert few records for testing.
--Write a stored procedure that selects the full names of all persons.
CREATE DATABASE [Persons_Data] ON  PRIMARY 
( NAME = N'Persons_Data', FILENAME = N'D:\TELERIK\15. Databases\Homework 9\Persons_Data.mdf' , SIZE = 167872KB , MAXSIZE = UNLIMITED, FILEGROWTH = 16384KB )
    LOG ON 
( NAME = N'Persons_Logs', FILENAME = N'D:\TELERIK\15. Databases\Homework 9\Persons_Data.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 16384KB )
GO

USE [Persons_Data]

CREATE TABLE Persons(
	Id INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	FirstName nvarchar(50) NOT NULL,
	LastName nvarchar(50) NOT NULL,
	SSN char(10) NOT NULL,
)

CREATE TABLE Accounts(
	Id INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	PersonId INT FOREIGN KEY REFERENCES Persons(Id),
	Balance MONEY CHECK(Balance > 0)
)

INSERT INTO Persons
VALUES
('Petar', 'Petrov', '1238493754'),
('Ivan', 'Georgiev', '1435345345'),
('Maria', 'Ivanova', '5452345325')

INSERT INTO Accounts
VALUES
(3, 20000),
(1, 65000),
(2, 100000)

USE [Persons_Data]
GO
	CREATE PROC	SelectFullPersonName
	AS
	SELECT p.FirstName + ' ' + p.LastName as [Full Name]
	FROM Persons p 
GO

EXEC SelectFullPersonName

--Create a stored procedure that accepts a number as a parameter and returns all persons who have more money in 
--their accounts than the supplied number.
GO
	CREATE PROC	SelectPersonsWithMoreMoneyThan(@money MONEY)
	AS
	SELECT p.FirstName + ' ' + p.LastName as [Full Name], a.Balance
	FROM Persons p
	JOIN Accounts a
		ON a.PersonId = p.Id
	WHERE a.Balance > @money
GO

DECLARE @minAmountOfMoney MONEY = 80000
EXEC SelectPersonsWithMoreMoneyThan @minAmountOfMoney

--Create a function that accepts as parameters – sum, yearly interest rate and number of months.
--It should calculate and return the new sum.
--Write a SELECT to test whether the function works as expected.
GO
	CREATE PROC CalculateMoneyWithInterest(@sum INT, @yearlyRate FLOAT, @months INT)
	AS
	SELECT @sum + @sum * (((@yearlyRate / 12)/ 100) * @months)
GO

EXEC CalculateMoneyWithInterest 50000, 3.5, 18

--Create a stored procedure that uses the function from the previous example to give an interest to a person's account for one month.
--It should take the AccountId and the interest rate as parameters.
GO
	CREATE PROC AddInterestForOneMonth(@yearlyRate FLOAT, @accountId INT)
	AS
	DECLARE @newAmmount MONEY
	SET @newAmmount = 
	(SELECT a.Balance + a.Balance * (((@yearlyRate / 12)/ 100) * 1)
	FROM Accounts a
	WHERE a.Balance = 
		(SELECT ac.Balance 
		 FROM Accounts ac
		 WHERE ac.Id = @accountId))
	
	UPDATE Accounts
	SET Balance = @newAmmount
	FROM Accounts a
	WHERE a.Id = @accountId
GO

EXEC AddInterestForOneMonth 12, 3

SELECT Balance
FROM Accounts a
WHERE a.Id = 3

--Add two more stored procedures WithdrawMoney(AccountId, money) and DepositMoney(AccountId, money) that operate in transactions.
GO
	CREATE PROC DepositMoney(@accountId INT, @ammount MONEY)
	AS
	DECLARE @newAmmount MONEY
	SET @newAmmount = @ammount +
	(SELECT a.Balance
		FROM Accounts a
		WHERE a.Id = @accountId)
	
	BEGIN TRAN
		UPDATE Accounts
		SET Balance = @newAmmount
		FROM Accounts a
		WHERE a.Id = @accountId
	COMMIT TRAN
GO

EXEC DepositMoney 1, 300000

GO
	CREATE PROC WithdrawMoney(@accountId INT, @ammount MONEY)
	AS
	DECLARE @newAmmount MONEY
	SET @newAmmount = 
	(SELECT a.Balance
		FROM Accounts a
		WHERE a.Id = @accountId) - @ammount

	BEGIN TRAN
		UPDATE Accounts
		SET Balance = @newAmmount
		FROM Accounts a
		WHERE a.Id = @accountId
	COMMIT TRAN
GO

EXEC WithdrawMoney 2, 50000

--Create another table – Logs(LogID, AccountID, OldSum, NewSum).
--Add a trigger to the Accounts table that enters a new entry into the Logs table every time the sum on an account changes.
CREATE TABLE Logs(
	Id INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	AccountId INT FOREIGN KEY REFERENCES Accounts(Id),
	OldSum MONEY,
	NewSum MONEY
)

GO
CREATE TRIGGER AccountUpdate ON Accounts FOR UPDATE
AS
BEGIN
	INSERT INTO Logs(AccountId, OldSum, NewSum)
	SELECT inserted.Id, deleted.Balance, inserted.Balance
	FROM inserted, deleted
END
GO
EXEC DepositMoney 2, 10000

--Define a function in the database TelerikAcademy that returns all Employee's names (first or middle or last name) and all town's 
--names that are comprised of given set of letters. Example: 'oistmiahf' will return 'Sofia', 'Smith', … but not 'Rob' and 'Guy'

USE TelerikAcademy
GO
	CREATE PROC SearchForMatch(@pattern INT, @len INT, @counter INT)
	AS 





DECLARE @currentPattern NVARCHAR = 'oistmiahf'
DECLARE @currentLen INT = LEN(@currentPattern)
DECLARE @currentCounter INT = 0

