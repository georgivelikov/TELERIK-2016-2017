--Write a SQL query to find all information about all departments (use "TelerikAcademy" database).
SELECT * FROM Departments

--Write a SQL query to find all department names.
SELECT d.Name
FROM Departments d

--Write a SQL query to find the salary of each employee.
SELECT e.Salary
FROM Employees e

--Write a SQL to find the full name of each employee.
SELECT e.FirstName + ' ' + e.LastName AS [Full Name]
FROM Employees e

--Write a SQL query to find the email addresses of each employee (by his first and last name). Consider that the mail 
SELECT e.FirstName + '.' + e.LastName + '@telerik.com' AS [Full Email Address]
FROM Employees e

--Write a SQL query to find all different employee salaries.
SELECT DISTINCT e.Salary
FROM Employees e

--Write a SQL query to find all information about the employees whose job title is “Sales Representative“.
SELECT *
FROM Employees e
WHERE e.JobTitle = 'Sales Representative'

--Write a SQL query to find the names of all employees whose first name starts with "SA".
SELECT *
FROM Employees e
WHERE e.FirstName LIKE 'SA%'

--Write a SQL query to find the names of all employees whose last name contains "ei".
SELECT *
FROM Employees e
WHERE e.LastName LIKE '%ei%'

--Write a SQL query to find the salary of all employees whose salary is in the range [20000…30000].
SELECT *
FROM Employees e
WHERE e.Salary >= 20000 AND e.Salary <= 30000

--Write a SQL query to find the names of all employees whose salary is 25000, 14000, 12500 or 23600.
SELECT *
FROM Employees e
WHERE e.Salary = 25000 OR e.Salary = 14000 OR e.Salary = 12500 OR e.Salary = 23600

--Write a SQL query to find all employees that do not have manager.
SELECT *
FROM Employees e
WHERE e.ManagerID IS NULL

--Write a SQL query to find all employees that have salary more than 50000. Order them in decreasing order by salary.
SELECT *
FROM Employees e
WHERE e.Salary > 50000
ORDER BY e.Salary DESC

--Write a SQL query to find the top 5 best paid employees.
SELECT TOP 5 e.FirstName + ' ' + e.LastName AS [Full Name], e.Salary
FROM Employees e
ORDER BY e.Salary DESC

--Write a SQL query to find all employees along with their address. Use inner join with ON clause.
SELECT e.FirstName, e.LastName as [Full name], a.AddressText + ', ' + t.Name as [Full Address]
FROM Employees e
INNER JOIN Addresses a
ON e.AddressID = a.AddressID
INNER JOIN Towns t
ON a.TownID = t.TownID

--Write a SQL query to find all employees and their address. Use equijoins (conditions in the WHERE clause).
SELECT e.FirstName, e.LastName, a.AddressText + ', ' + t.Name as [Full Address]
FROM Employees e, Addresses a, Towns t
WHERE e.AddressID = a.AddressID AND a.TownID = t.TownID

--Write a SQL query to find all employees along with their manager.
SELECT e.FirstName + ' ' + e.LastName as [Full Name], m.FirstName + ' ' + m.LastName as [Manager]
FROM Employees e
	JOIN Employees m
		ON e.ManagerID = m.EmployeeID

--Write a SQL query to find all employees, along with their manager and their address. Join the 3 tables: 
--Employees e, Employees m and Addresses a
SELECT e.FirstName + ' ' + e.LastName as [Full Name], m.FirstName + ' ' + m.LastName as [Manager], a.AddressText as [Employee Adress], am.AddressText as [Manager Address]
FROM Employees e
	JOIN Employees m
		ON e.ManagerID = m.EmployeeID
	JOIN Addresses a
		ON e.AddressID = a.AddressID
	JOIN Addresses am
		ON m.EmployeeID = am.AddressID

--Write a SQL query to find all departments and all town names as a single list. Use UNION.
SELECT d.Name
FROM Departments d
	LEFT JOIN Towns t
	ON d.DepartmentID = t.TownID
UNION
SELECT t.Name
FROM Towns t
	RIGHT JOIN Departments d
	ON d.DepartmentID = t.TownID

--Write a SQL query to find all the employees and the manager for each of them along with the employees that do not have manager. 
--Use right outer join. 
SELECT e.FirstName + ' ' + e.LastName as [Full Name], m.FirstName + ' ' + m.LastName as [Manager]
FROM Employees e
RIGHT OUTER JOIN Employees m
ON e.ManagerID = m.EmployeeID

--Rewrite the query to use left outer join.
SELECT e.FirstName + ' ' + e.LastName as [Full Name], m.FirstName + ' ' + m.LastName as [Manager]
FROM Employees e
LEFT OUTER JOIN Employees m
ON e.ManagerID = m.EmployeeID

--Write a SQL query to find the names of all employees from the departments "Sales" and "Finance" whose hire year is between 1995 and 2005.
SELECT e.FirstName + ' ' + e.LastName as [Full Name]
FROM Employees e
LEFT JOIN Departments d
ON e.DepartmentID = d.DepartmentID
WHERE (d.Name = 'Sales' OR d.Name = 'Finance') AND (e.HireDate > 1996 OR e.HireDate < 2005)