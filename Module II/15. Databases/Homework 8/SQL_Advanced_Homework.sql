--Write a SQL query to find the names and salaries of the employees that take the minimal salary in the company.
SELECT e.FirstName + ' ' + e.LastName as [Full Name], e.Salary
FROM Employees e
WHERE e.Salary = 
	(SELECT MIN(em.Salary) 
	 FROM Employees em)

--Write a SQL query to find the names and salaries of the employees that have a salary 
--that is up to 10% higher than the minimal salary for the company.
SELECT e.FirstName + ' ' + e.LastName as [Full Name], e.Salary
FROM Employees e
WHERE e.Salary <= 
	(SELECT MIN(em.Salary) * 1.1
	 FROM Employees em)

--Write a SQL query to find the full name, salary and department of the employees that take the minimal 
--salary in their department.
SELECT e.FirstName + ' ' + e.LastName as [Full Name], e.Salary, d.Name
FROM Employees e
JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
WHERE e.Salary = 
	(SELECT MIN(em.Salary)
	 FROM Employees em
	 WHERE em.DepartmentID = e.DepartmentID)
ORDER BY e.Salary

--Write a SQL query to find the average salary in the department #1.
SELECT AVG(e.Salary) as [Average Salary]
FROM Employees e
WHERE e.DepartmentID = 1

--Write a SQL query to find the average salary in the department #1.
SELECT AVG(e.Salary) as [Average Salary]
FROM Employees e
	JOIN Departments d
		ON d.DepartmentID = e.DepartmentID
		WHERE d.Name = 'Sales'

--Write a SQL query to find the number of employees in the "Sales" department.
SELECT COUNT(*) Ctn
FROM Employees e
	JOIN Departments d
	ON d.DepartmentID = e.DepartmentID
    WHERE d.Name = 'Sales'

--Write a SQL query to find the number of all employees that have manager.
SELECT COUNT(*) Ctn
FROM Employees e
WHERE e.ManagerID IS NOT NULL

--Write a SQL query to find the number of all employees that have no manager.
SELECT COUNT(*) Ctn
FROM Employees e
WHERE e.ManagerID IS NULL

--Write a SQL query to find all departments and the average salary for each of them.
SELECT d.Name, AVG(e.Salary)
FROM Employees e
	JOIN Departments d
	ON d.DepartmentID = e.DepartmentID
GROUP BY d.Name, e.DepartmentID

--Write a SQL query to find the count of all employees in each department and for each town.
SELECT d.Name as [Department Name], t.Name as [Town Name], COUNT(*) as [ctn]
FROM Employees e
	JOIN Departments d
		ON d.DepartmentID = e.DepartmentID
	JOIN Addresses a
		ON e.AddressID = a.AddressID
	JOIN Towns t
		ON t.TownID = a.TownID
GROUP BY d.Name, t.Name

--Write a SQL query to find all managers that have exactly 5 employees. Display their first name and last name.
SELECT m.FirstName + ' ' + m.LastName as [Full Name]
FROM Employees m
	JOIN Employees e
		ON m.EmployeeID = e.ManagerID
GROUP BY m.FirstName, m.LastName
HAVING COUNT(*) = 5

--Write a SQL query to find all employees along with their managers.For employees that do not have manager 
--display the value "(no manager)".
SELECT e.FirstName + ' ' + e.LastName as [Employee Name], ISNULL(m.FirstName + ' ' + m.LastName, 'no manager') as [Manager Name]
FROM Employees e
	LEFT JOIN Employees m
		ON m.EmployeeID = e.ManagerID

--Write a SQL query to find the names of all employees whose last name is exactly 5 characters long. Use the 
--built-in LEN(str) function.
SELECT e.FirstName + ' ' + e.LastName
FROM Employees e
WHERE LEN(e.LastName) = 5

--Write a SQL query to display the current date and time in the following format 
--"day.month.year hour:minutes:seconds:milliseconds".
SELECT FORMAT(GETDATE(),'dd/MM/yyyy hh:mm:ss.fff')

--Write a SQL statement to create a table Users. Users should have username, password, full name and last login time.
CREATE TABLE Users(
	Id INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	Username nvarchar(50) UNIQUE NOT NULL,
	UserPassword nvarchar(50) CHECK(LEN(UserPassword)> 4) NOT NULL,
	FullName nvarchar(100) NOT NULL,
	LastLogin smalldatetime
)

--Write a SQL statement to create a view that displays the users from the Users table that have been in the system today.
--GO
--CREATE VIEW [First 1 Persons] AS
--SELECT TOP 5 u.Username
--FROM Users u

--Write a SQL statement to create a table Groups. Groups should have unique name (use unique constraint).
CREATE TABLE Groups(
	Id int PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	GroupName nvarchar(50) UNIQUE NOT NULL,
)

--Write a SQL statement to add a column GroupID to the table Users.
ALTER TABLE Users
ADD GroupId INT
ALTER TABLE Users
ADD CONSTRAINT FK_Users_Groups
  FOREIGN KEY (GroupId)
  REFERENCES Groups(Id)

--Write SQL statements to insert several records in the Users and Groups tables.
INSERT INTO Groups
VALUES
('Group 2'),
('Group 3'),
('Group 4')

INSERT INTO Users
VALUES
('User 2','123456','Petar Petrov',GETDATE(), 1),
('User 3','123456','Ivan Ivanov',GETDATE(), 1),
('User 4','123456','Ivan Petorv',GETDATE(), 3),
('User 5','123456','Georgi Georgiev',GETDATE(), 1),
('User 6','123456','Hristo Hristov',GETDATE(), 2)

--Write SQL statements to update some of the records in the Users and Groups tables.
UPDATE Users
SET Username = 'newUsername'
FROM Users u
WHERE u.Username = 'User 3'

UPDATE Groups
SET GroupName = 'newGroupName'
FROM Groups g
WHERE g.Id = 3

--Write SQL statements to delete some of the records from the Users and Groups tables.
DELETE FROM Users
WHERE Username = 'User 4'

DELETE FROM Groups
WHERE GroupName = 'newGroupName'

--Write SQL statements to insert in the Users table the names of all employees from the Employees table.
--With one letter from first name there are duplicate usernames, that are not allowed when table was created. I will use 5 letters instead
INSERT INTO Users(Username, UserPassword, FullName, LastLogin, GroupId)
	SELECT SUBSTRING(FirstName, 0, 5) + LOWER(LastName),
		   SUBSTRING(FirstName, 0, 5) + LOWER(LastName) + 'pass',
			FirstName + ' ' + LastName,
			NULL,
			1
	FROM Employees

--Write a SQL statement that changes the password to NULL for all users that have not been in the system since 10.03.2010.
--I will rename UserPassword to "OutdatedPass", beacause NULL is not allowed when table is created!
UPDATE Users
SET UserPassword = 'OutdatedPass'
FROM Users
WHERE LastLogin<CONVERT(smalldatetime, '10-03-2010')

--Write a SQL statement that deletes all users without passwords (NULL password).
DELETE FROM Users 
WHERE UserPassword = 'OutdatedPass'

--Write a SQL query to display the average employee salary by department and job title.
SELECT e.JobTitle, d.Name as [Department], AVG(e.Salary) as [Average Salary]
FROM Employees e
	JOIN Departments d
		ON d.DepartmentID = e.DepartmentID
GROUP BY e.JobTitle, d.Name

--Write a SQL query to display the minimal employee salary by department and job title along with the name of some of 
--the employees that take it.
SELECT e.JobTitle, d.Name as [Department], e.Salary as [Minimum Salary], e.FirstName + ' ' + e.LastName as [Full Name]
FROM Employees e
	JOIN Departments d
		ON d.DepartmentID = e.DepartmentID
WHERE e.Salary = 
	(SELECT MIN(em.Salary)
	 FROM Employees em
	 WHERE e.JobTitle = em.JobTitle AND e.DepartmentID = em.DepartmentID)
GROUP BY e.JobTitle, d.Name, e.Salary, e.FirstName + ' ' + e.LastName

--Write a SQL query to display the town where maximal number of employees work.
SELECT TOP(1) t.Name as [Town Name], COUNT(*) as [ctn]
FROM Employees e
	JOIN Addresses a
		ON e.AddressID = a.AddressID
	JOIN Towns t
		ON t.TownID = a.TownID
GROUP BY t.Name
ORDER BY [ctn] DESC

--Write a SQL query to display the number of managers from each town.
SELECT t.Name, COUNT(DISTINCT m.EmployeeID) as [Managers Count]
FROM Employees e
	JOIN Employees m
	ON m.EmployeeID = e.ManagerID
	JOIN Addresses a
		ON m.AddressID = a.AddressID
	JOIN Towns t
		ON t.TownID = a.TownID
GROUP BY t.Name

--Write a SQL to create table WorkHours to store work reports for each employee (employee id, date, task, hours, comments).
--Don't forget to define identity, primary key and appropriate foreign key.
--Issue few SQL statements to insert, update and delete of some data in the table.
--Define a table WorkHoursLogs to track all changes in the WorkHours table with triggers.
--For each change keep the old record data, the new record data and the command (insert / update / delete).
CREATE TABLE WorkHours
(
	Id INT IDENTITY(1, 1) PRIMARY KEY,
	EmployeeId INT FOREIGN KEY(EmployeeID) REFERENCES Employees(EmployeeID) NOT NULL,
	Date smalldatetime NOT NULL,
	Task ntext,
	Hours INT, 
	Comments ntext,
)

INSERT INTO WorkHours
VALUES
(1, '2016-10-20', 'Some task 1', 3, 'My Comment1'),
(3, '2016-10-20', 'Some task 2', 2, 'My Comment2'),
(1, '2016-10-20', 'Some task 3', 1, 'My Comment3'),
(2, '2016-10-20', 'Some task 4', 3, 'My Comment4'),
(1, '2016-10-20', 'Some task 5', 3, 'My Comment5')

UPDATE WorkHours
SET Hours = 13
FROM WorkHours w
WHERE w.Id= 3;

DELETE FROM WorkHours
WHERE Id = 5

CREATE TABLE WorkHoursLog
(
	Id INT IDENTITY(1, 1) PRIMARY KEY,
	Command varchar NOT NULL,
	OldEmployeeId INT,
	OldWorkHours INT,
	OldDate smalldatetime,
	OldTask ntext,
	OldHours INT,
	OldComments ntext,
	NewEmployeeId INT,
	NewWorkHours INT,
	NewDate smalldatetime,
	NewTask ntext,
	NewHours INT,
	NewComments ntext,
)


