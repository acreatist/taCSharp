-- 1: Create a database with two tables: Persons(Id(PK), FirstName, LastName, SSN) and Accounts(Id(PK), PersonId(FK), Balance). 
--	Insert few records for testing. Write a stored procedure that selects the full names of all persons.

CREATE DATABASE Account
GO
 
USE Account
CREATE TABLE Persons (
	PersonID INT IDENTITY,
	FirstName nvarchar(100) NOT NULL,
	LastName nvarchar(100) NOT NULL,
	SSN nvarchar(50) NOT NULL
	CONSTRAINT PK_PersonID PRIMARY KEY(PersonID),
)

GO
CREATE TABLE Accounts (
	AccountID INT IDENTITY,
	Balance money DEFAULT 0,
	PersonId INT NULL
	CONSTRAINT PK_AccountID PRIMARY KEY(AccountID),
	CONSTRAINT FK_Accounts_Persons FOREIGN KEY (PersonId)
	REFERENCES Persons(PersonId)
)
GO
 
INSERT INTO Persons(FirstName, LastName, SSN)
VALUES ('Genady', 'Ivanov', '041223234')
INSERT INTO Persons(FirstName, LastName, SSN)
VALUES ('Sotir', 'Cacarov', '42342345')
INSERT INTO Persons(FirstName, LastName, SSN)
VALUES ('Anton', 'Antonov', '36346456')

INSERT INTO Accounts(Balance, PersonId)
VALUES (500.00, 1)
INSERT INTO Accounts(Balance, PersonId)
VALUES (300.00, 2)
INSERT INTO Accounts(Balance, PersonId)
VALUES (50.00, 3)
GO
 
CREATE PROC dbo.usp_GetFullName
AS
	SELECT FirstName + ' ' + LastName AS [FULL Name]
	FROM Persons
GO
 
EXEC usp_GetFullName
GO

-- 2: Create a stored procedure that accepts a number as a parameter and returns all persons who have more money in their accounts than the supplied number.
CREATE PROC dbo.usp_GetHigherBalanceAccounts (@money money)
AS
	SELECT  FirstName + ' ' + LastName AS [FULL Name], a.Balance
	FROM Persons p JOIN Accounts a
	ON a.PersonId = p.PersonID
	WHERE a.Balance > @money
	ORDER BY a.Balance
GO

EXEC usp_GetHigherBalanceAccounts 200.00
GO

-- 3:Create a function that accepts as parameters – sum, yearly interest rate and number of months. 
--	It should calculate and return the new sum. Write a SELECT to test whether the function works as expected.
CREATE FUNCTION ufn_CalcInterest(@sum money, @interest money, @months INT)
RETURNS money
AS
BEGIN
	RETURN (@interest / 12) * @months * @sum + @sum
END
GO

SELECT dbo.ufn_CalcInterest(400, 0.5, 12)
GO

-- 4: Create a stored procedure that uses the function from the previous example to give an interest 
--	to a person's account for one month. It should take the AccountId and the interest rate as parameters.
CREATE PROC dbo.usp_SetAccountInterest (@accountID INT, @yearlyInterest money)
AS
	UPDATE Accounts
	SET Balance = dbo.ufn_CalcInterest(Balance, @yearlyInterest, 1)
	WHERE AccountID = @accountID
GO
 
EXEC dbo.usp_SetAccountInterest 1, 0.5
GO

-- 5: Add two more stored procedures WithdrawMoney( AccountId, money) 
--	and DepositMoney (AccountId, money) that operate in transactions.
CREATE PROC dbo.usp_WithdrawMoney (@accountId INT, @money money)
AS
BEGIN TRAN
	UPDATE Accounts
	SET Balance = Balance - @money
	WHERE AccountID = @accountId
COMMIT TRAN
GO

CREATE PROC dbo.usp_DepositMoney (@accountId INT, @money money)
AS
BEGIN TRAN
	UPDATE Accounts
	SET Balance = Balance + @money
	WHERE AccountID = @accountId
	COMMIT TRAN
GO
 
EXEC dbo.usp_WithdrawMoney 1, 100
EXEC dbo.usp_DepositMoney 1, 100
GO

-- 6: Create another table – Logs(LogID, AccountID, OldSum, NewSum). 
--	Add a trigger to the Accounts table that enters a new entry into the Logs table 
--	every time the sum on an account changes.
CREATE TABLE Logs(
	LogId int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	AccountID int NOT NULL FOREIGN KEY REFERENCES Accounts(AccountID),
	OldSum money NOT NULL,
	NewSum money NOT NULL,
);
GO

CREATE TRIGGER tr_AccountsUpdate ON Accounts FOR UPDATE
AS
BEGIN
	DECLARE @oldSum money;
	DECLARE @newSum money;
	DECLARE @accountID int;

    SELECT @oldSum = deleted.Balance FROM deleted
    SELECT @newSum = inserted.Balance FROM inserted
	SELECT @accountID = inserted.AccountID FROM inserted

	INSERT INTO Logs(AccountID, oldSum, newSum) VALUES(@accountID, @oldSum, @newSum)
END 
GO

-- Test:
UPDATE Accounts SET Balance = 100.00 WHERE AccountID = 1
SELECT * FROM Logs