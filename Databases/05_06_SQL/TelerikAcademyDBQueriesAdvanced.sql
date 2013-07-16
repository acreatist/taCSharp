-- 1: Write a SQL query to find the names and salaries of the employees that take 
--	the minimal salary in the company. Use a nested SELECT statement.
SELECT FirstName, LastName, Salary FROM Employees
WHERE Salary = (SELECT MIN(Salary) FROM Employees)

-- 2: Write a SQL query to find the names and salaries of the employees that have a 
--	salary that is up to 10% higher than the minimal salary for the company.
SELECT FirstName, LastName, Salary FROM Employees
WHERE Salary <
	(SELECT MIN(Salary) + MIN(Salary) * 10 / 100 FROM Employees)

-- 3: Write a SQL query to find the full name, salary and department of the employees 
--	that take the minimal salary in their department. Use a nested SELECT statement.
SELECT e.FirstName, e.LastName, e.Salary, d.Name
	FROM Employees e, Departments d
	WHERE Salary = (SELECT MIN(SALARY) FROM Employees)
	GROUP BY d.Name, e.FirstName, e.LastName, e.Salary

-- 4: Write a SQL query to find the average salary in the department #1.
SELECT d.Name, AVG(e.Salary) as [Average Salary] FROM Employees e, Departments d
WHERE e.DepartmentID IN (SELECT d.DepartmentID FROM Departments WHERE d.DepartmentID = 1)
GROUP BY d.Name

-- 5: Write a SQL query to find the average salary in the "Sales" department.
SELECT d.Name, AVG(e.Salary) as [Average Salary] FROM Employees e, Departments d
WHERE e.DepartmentID IN (SELECT d.DepartmentID FROM Departments WHERE d.Name = 'Sales')
GROUP BY d.Name

-- 6: Write a SQL query to find the number of employees in the "Sales" department.
SELECT d.Name, COUNT(*) as [Employees Count] FROM Employees e, Departments d
WHERE e.DepartmentID IN (SELECT d.DepartmentID FROM Departments WHERE d.Name = 'Sales')
GROUP BY d.Name

-- 7: Write a SQL query to find the number of all employees that have manager.
SELECT COUNT(*) as [Employees Count With Managers] FROM Employees
WHERE ManagerID IS NOT NULL

-- 8: Write a SQL query to find the number of all employees that have no manager.
SELECT COUNT(*) as [Employees Count Without Managers] FROM Employees
WHERE ManagerID IS NULL

-- 9: Write a SQL query to find all departments and the average salary for each of them.
SELECT d.Name, AVG(e.Salary) FROM Departments d JOIN Employees e
ON d.DepartmentID = e.DepartmentID
GROUP BY d.Name

-- 10: Write a SQL query to find the count of all employees in each department and for each town.
SELECT d.Name, t.Name, COUNT(e.EmployeeID)
	FROM Employees e
	JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
	JOIN Addresses a
	ON a.AddressID = e.AddressID
	JOIN Towns t
	ON a.TownID = t.TownID
GROUP BY d.Name, t.Name

-- 11: Write a SQL query to find all managers that have exactly 5 employees. 
--	Display their first name and last name.
SELECT m.FirstName, m.LastName FROM Employees m JOIN Employees e
ON m.EmployeeID = e.ManagerID
GROUP BY m.FirstName, m.LastName
HAVING COUNT(e.EmployeeID) = 5

-- 12: Write a SQL query to find all employees along with their managers. 
--	For employees that do not have manager display the value "(no manager)".
SELECT 
	e.FirstName + ' ' + e.LastName AS Employee,
	ISNULL(m.FirstName + ' ' + m.LastName, '(no manager)') AS Manager
FROM Employees e LEFT OUTER JOIN Employees m
ON e.ManagerID = m.EmployeeID

-- 13: Write a SQL query to find the names of all employees whose last name 
--	is exactly 5 characters long. Use the built-in LEN(str) function.
SELECT FirstName, LastName FROM Employees
WHERE LEN(LastName) = 5

-- 14: Write a SQL query to display the current date and time in the following 
--	format "day.month.year hour:minutes:seconds:milliseconds". Search in  Google 
--	to find how to format dates in SQL Server.
SELECT GETDATE()
-- or
SELECT { fn NOW() }
-- or
SELECT CURRENT_TIMESTAMP

-- 15: Write a SQL statement to create a table Users. 
--	Users should have username, password, full name and last login time. 
--	Choose appropriate data types for the table fields. Define a primary key column 
--	with a primary key constraint. Define the primary key column as identity to facilitate 
--	inserting records. Define unique constraint to avoid repeating usernames. 
--	Define a check constraint to ensure the password is at least 5 characters long.
CREATE TABLE Users (
	userId int IDENTITY,
	username nvarchar(50) NOT NULL,
	userpass nvarchar(50) NOT NULL,
	fullName nvarchar(50),
	lastLogin datetime DEFAULT GETDATE(),
	CONSTRAINT PK_Users PRIMARY KEY(userId),
	UNIQUE(username),
	CONSTRAINT userpass CHECK (LEN(userpass) > 5)
)
GO

-- Write some users to Users table
INSERT INTO Users VALUES ('pesho', 'peshopass', 'Pesho Pesho', GETDATE())
INSERT INTO Users VALUES ('sotir', 'sotirpass', 'Sotir Sotir', GETDATE())
INSERT INTO Users VALUES ('gosho', 'goshopass', 'Gosho Gosho', '2013-07-11')
GO

-- 16: Write a SQL statement to create a view that displays the users from the 
--	Users table that have been in the system today. Test if the view works correctly.
CREATE VIEW [Today Users] AS
SELECT username FROM Users
WHERE lastLogin = GETDATE()
GO

-- 17: Write a SQL statement to create a table Groups. Groups should have unique name (use unique constraint). 
--	Define primary key and identity column.
CREATE TABLE Groups(
	name nvarchar(50) NOT NULL
	UNIQUE(name),
	CONSTRAINT PK_Groups PRIMARY KEY(name)
)
GO

-- 18: Write a SQL statement to add a column GroupID to the table Users. 
--	Fill some data in this new column and as well in the Groups table. 
--	Write a SQL statement to add a foreign key constraint between tables Users and Groups tables.
ALTER TABLE Users
ADD GroupId nvarchar(50)
GO 

ALTER TABLE Users
ADD FOREIGN KEY(GroupId) REFERENCES Groups(name)

-- 19: Write SQL statements to insert several records in the Users and Groups tables. 
-- + 
-- 20: Write SQL statements to update some of the records in the Users and Groups tables.
INSERT INTO Groups VALUES ('Group 1')
INSERT INTO Groups VALUES ('Group 2')
INSERT INTO Groups VALUES ('Group 3')

UPDATE Users SET GroupId = 'Group 1' WHERE userId = 1
UPDATE Users SET GroupId = 'Group 2' WHERE userId = 2
UPDATE Users SET GroupId = 'Group 3' WHERE userId = 3

-- 21: Write SQL statements to delete some of the records from the Users and Groups tables.
DELETE FROM Users WHERE userId = 3
DELETE FROM Groups WHERE name = 'Group 1' -- will throw error, due to FK constraint

-- 22: Write SQL statements to insert in the Users table the names of all employees from the Employees table. 
--	Combine the first and last names as a full name. For username use the first letter of the first name + the last name (in lowercase). 
--	Use the same for the password, and NULL for last login time.

ALTER TABLE Users ALTER COLUMN lastLogin datetime NULL -- Alter the not null constraint in users (just to be sure)

INSERT INTO Users (username, userpass, fullName, lastLogin)
	SELECT 
		LOWER(LEFT(FirstName,1)) + LOWER(LEFT(LastName,1)) + CONVERT(nvarchar(50), EmployeeID), -- we have a uniqueness constraint for the username
		LOWER(LEFT(FirstName,2)) + LOWER(LEFT(LastName,3)) + CONVERT(nvarchar(50), EmployeeID), -- we have a constraint for at least 5 chars for password
		FirstName + ' ' + LastName,
		NULL 
	FROM Employees

-- 23: Write a SQL statement that changes the password to NULL for all users that have not been in the system since 10.03.2010.
INSERT INTO Users VALUES ('gosho1', 'goshopass1', 'Gosho Gosho 1', '2010-02-11', NULL)
INSERT INTO Users VALUES ('gosho2', 'goshopass2', 'Gosho Gosho 2', '2010-02-12', NULL)

UPDATE Users SET userpass = NULL
WHERE lastLogin < '20100310'

-- 24: Write a SQL statement that deletes all users without passwords (NULL password).


-- 25: Write a SQL query to display the average employee salary by department and job title.
SELECT AVG(e.Salary) AS [Average Salary], e.JobTitle, d.Name AS Department, COUNT(e.EmployeeID) AS [Employees Count]
FROM Employees e JOIN Departments d
ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name, e.JobTitle

-- 26: Write a SQL query to display the minimal employee salary by department and job title along with the name 
--	of some of the employees that take it.
SELECT e.JobTitle, d.Name AS Department, MIN(e.Salary) AS [Minimum Salary], MIN(e.FirstName + ' ' + e.LastName) AS [Employee Name]
FROM Employees e JOIN Departments d
ON e.DepartmentID = d.DepartmentID
GROUP BY e.JobTitle, d.Name

-- TEST Select Document Control just to check
SELECT e.Salary, e.FirstName, e.JobTitle FROM Employees e JOIN Departments d
ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Document Control'

-- 27: Write a SQL query to display the town where maximal number of employees work.
SELECT COUNT(e.EmployeeID) AS [Employees Count], t.Name FROM Employees e 
JOIN Addresses a
ON e.AddressID = a.AddressID
JOIN Towns t
ON a.TownID = t.TownID
GROUP BY t.Name

-- JUST a Test:
SELECT e.EmployeeID, t.Name FROM Employees e 
JOIN Addresses a
ON e.AddressID = a.AddressID
JOIN Towns t
ON a.TownID = t.TownID
WHERE t.Name = 'Bothell' -- Change Name for test

