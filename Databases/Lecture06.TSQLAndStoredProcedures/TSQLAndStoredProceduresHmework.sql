------------------------------------------------------------------------------------------
-- Task 1. Create a database with two tables: Persons(Id(PK), FirstName, LastName, SSN)	--
-- and Accounts(Id(PK), PersonId(FK), Balance). Insert few records for testing.			--
-- Write a stored procedure that selects the full names of all persons.					--
------------------------------------------------------------------------------------------

------------------------------------------------------------------------------------------
-- Create table																			--
------------------------------------------------------------------------------------------

USE [master]
GO
CREATE DATABASE [PersonsAccounts]
 CONTAINMENT = NONE
GO
ALTER DATABASE [PersonsAccounts] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PersonsAccounts].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PersonsAccounts] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PersonsAccounts] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PersonsAccounts] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PersonsAccounts] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PersonsAccounts] SET ARITHABORT OFF 
GO
ALTER DATABASE [PersonsAccounts] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PersonsAccounts] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PersonsAccounts] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PersonsAccounts] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PersonsAccounts] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PersonsAccounts] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PersonsAccounts] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PersonsAccounts] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PersonsAccounts] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PersonsAccounts] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PersonsAccounts] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PersonsAccounts] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PersonsAccounts] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PersonsAccounts] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PersonsAccounts] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PersonsAccounts] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PersonsAccounts] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PersonsAccounts] SET RECOVERY FULL 
GO
ALTER DATABASE [PersonsAccounts] SET  MULTI_USER 
GO
ALTER DATABASE [PersonsAccounts] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PersonsAccounts] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PersonsAccounts] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PersonsAccounts] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [PersonsAccounts] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'PersonsAccounts', N'ON'
GO
USE [PersonsAccounts]
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 21.8.2014 ã. 15:00:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[AccountID] [int] IDENTITY(1,1) NOT NULL,
	[Balance] [money] NOT NULL,
	[PersonID] [int] NOT NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[AccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Persons]    Script Date: 21.8.2014 ã. 15:00:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persons](
	[PersonID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[SSN] [nvarchar](9) NOT NULL,
 CONSTRAINT [PK_Persons] PRIMARY KEY CLUSTERED 
(
	[PersonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Accounts] ON 

GO
INSERT [dbo].[Accounts] ([AccountID], [balance], [PersonID]) VALUES (1, CAST(123 AS Decimal(18, 0)), 1)
GO
INSERT [dbo].[Accounts] ([AccountID], [balance], [PersonID]) VALUES (2, CAST(0 AS Decimal(18, 0)), 2)
GO
INSERT [dbo].[Accounts] ([AccountID], [balance], [PersonID]) VALUES (3, CAST(1000 AS Decimal(18, 0)), 3)
GO
SET IDENTITY_INSERT [dbo].[Accounts] OFF
GO
SET IDENTITY_INSERT [dbo].[Persons] ON 

GO
INSERT [dbo].[Persons] ([PersonID], [FirstName], [LastName], [SSN]) VALUES (1, N'John', N'Doe', N'123456789')
GO
INSERT [dbo].[Persons] ([PersonID], [FirstName], [LastName], [SSN]) VALUES (2, N'Peter', N'Griffin', N'000000000')
GO
INSERT [dbo].[Persons] ([PersonID], [FirstName], [LastName], [SSN]) VALUES (3, N'Aeryn', N'Sun', N'344522345')
GO
SET IDENTITY_INSERT [dbo].[Persons] OFF
GO
ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD  CONSTRAINT [FK_Accounts_Persons] FOREIGN KEY([PersonID])
REFERENCES [dbo].[Persons] ([PersonID])
GO
ALTER TABLE [dbo].[Accounts] CHECK CONSTRAINT [FK_Accounts_Persons]
GO

------------------------------------------------------------------------------------------
-- Create procedure																		--
------------------------------------------------------------------------------------------
use [PersonsAccounts]
GO

CREATE PROC dbo.ups_SelectPersonsFullName
AS
	SELECT FirstName +' '+ LastName as FullName
	FROM Persons
GO

EXEC dbo.ups_SelectPersonsFullName
GO

------------------------------------------------------------------------------------------
-- Task 2. Create a stored procedure that accepts a number as a parameter and returns	--
-- all persons who have more money in their accounts than the supplied number.			--
------------------------------------------------------------------------------------------
use [PersonsAccounts]
GO

CREATE PROC dbo.ups_SelectPersonsWithMoneyMoreThan(@money int = 0)
AS
	SELECT p.PersonID, a.TotalBalance as money
	FROM Persons p INNER JOIN 
	(SELECT acc.PersonID, SUM (acc.Balance) as TotalBalance
	FROM Accounts acc 
	GROUP BY acc.PersonID
	) as a on p.PersonID=a.PersonID
	where a.TotalBalance >= @money
GO

EXEC dbo.ups_SelectPersonsWithMoneyMoreThan 100
GO

------------------------------------------------------------------------------------------
-- Task 3. Create a function that accepts as parameters – sum, yearly interest rate		--
-- and number of months. It should calculate and return the new sum. Write a SELECT to	--
-- test whether the function works as expected.											--
------------------------------------------------------------------------------------------
use [PersonsAccounts]
GO

CREATE FUNCTION [dbo].ufn_CalcInterest(@sum money, @interestRate decimal, @months decimal)
  RETURNS money
AS
BEGIN
  RETURN @sum + @sum*((@interestRate*@months/12)/100)
END
GO

SELECT dbo.ufn_CalcInterest(100, 30, 6) as NewSum
GO

------------------------------------------------------------------------------------------
-- Task 4. Create a stored procedure that uses the function from the previous example	--
-- to give an interest to a person's account for one month. It should take the AccountId--
-- and the interest rate as parameters.													--
------------------------------------------------------------------------------------------
use [PersonsAccounts]
GO

CREATE PROC dbo.ups_OneMonthInterest(@AccountID int, @interestRate decimal)
AS
	UPDATE Accounts
	SET Balance = dbo.ufn_CalcInterest(Balance, @interestRate, 1)
	WHERE AccountID=@AccountID
GO

EXEC dbo.ups_OneMonthInterest 1, 20.00; 
GO

------------------------------------------------------------------------------------------
-- Task 5. Add two more stored procedures WithdrawMoney( AccountId, money) and			--
-- DepositMoney (AccountId, money) that operate in transactions.						--
------------------------------------------------------------------------------------------
use [PersonsAccounts]
GO

CREATE PROC dbo.ups_WithdrawMoney(@AccountID int, @money decimal)
AS
	BEGIN TRAN
	DECLARE @newBalance money

	IF NOT EXISTS(SELECT 1 FROM Accounts WHERE AccountID = @AccountID)
		BEGIN
			ROLLBACK TRAN
			RAISERROR('Incorrect AccountID', 16, 1)
		END
	ELSE
		BEGIN 
		SELECT @newBalance = Balance - @money
		FROM Accounts 
		WHERE AccountID=@AccountID
		IF(@newBalance<0)
			BEGIN
				ROLLBACK TRAN
				RAISERROR('Not enough money in account', 16, 1)
			END
		ELSE
			BEGIN
				UPDATE Accounts
				SET Balance = @newBalance
				WHERE AccountID=@AccountID
				COMMIT
			END
		END
GO

CREATE PROC dbo.ups_DepositMoney(@AccountID int, @money decimal)
AS
	BEGIN TRAN
	DECLARE @newBalance money

	IF NOT EXISTS(SELECT 1 FROM Accounts WHERE AccountID = @AccountID)
		BEGIN
			ROLLBACK TRAN
			RAISERROR('Incorrect AccountID', 16, 1)
		END
	ELSE
		BEGIN 
		SELECT @newBalance = Balance + @money
		FROM Accounts 
		WHERE AccountID=@AccountID
			UPDATE Accounts
			SET Balance = @newBalance
			WHERE AccountID=@AccountID
			COMMIT
		END
GO

-- This statment producess error
/*
EXEC dbo.ups_WithdrawMoney 12, 100.00; 
GO
*/

EXEC dbo.ups_WithdrawMoney 1, 100.00; 
GO

-- This statment producess error
/*
EXEC dbo.ups_WithdrawMoney 1, 200.00; 
GO
*/

EXEC dbo.ups_DepositMoney 1, 100.00; 
GO


------------------------------------------------------------------------------------------
-- Task 6. Create another table – Logs(LogID, AccountID, OldSum, NewSum).				--
-- Add a trigger to the Accounts table that enters a new entry into the Logs table every--
-- time the sum on an account changes.													--
------------------------------------------------------------------------------------------
use [PersonsAccounts]
GO

CREATE TABLE Logs
(
  LogID int IDENTITY,
  AccountID int NOT NULL,
  OldSum money,
  NewSum money,
  ChangeDate datetime,
  CONSTRAINT PK_LogID PRIMARY KEY(LogID)
)
GO

ALTER TABLE [dbo].[Logs]  WITH CHECK ADD  CONSTRAINT [FK_Logs_Accounts] FOREIGN KEY([AccountID])
REFERENCES [dbo].[Accounts] ([AccountID])
GO

CREATE TRIGGER tr_AccountsUpdate ON Accounts FOR UPDATE
AS
  INSERT INTO Logs (AccountID, OldSum, NewSum, ChangeDate)
  SELECT d.AccountID, d.Balance, i.Balance, GETDATE()
  FROM deleted d INNER JOIN inserted i on d.AccountID = i.AccountID
GO

CREATE TRIGGER tr_AccountsInsert ON Accounts FOR INSERT
AS
  INSERT INTO Logs (AccountID, OldSum, NewSum, ChangeDate)
  SELECT i.AccountID, NULL, i.Balance, GETDATE()
  FROM inserted i 
GO

CREATE TRIGGER tr_AccountsDelete ON Accounts FOR DELETE
AS
  INSERT INTO Logs (AccountID, OldSum, NewSum, ChangeDate)
  SELECT d.AccountID, d.Balance, NULL, GETDATE()
  FROM deleted d 
GO

-- Test account update
EXEC dbo.ups_DepositMoney 3, 100.00; 
GO

-- Test account insert
INSERT INTO Accounts 
VALUES (2000, 1)
GO

-- Test account delete. It doesn't work because of the FK constraint for logs.
-- It should be done with deletedFlag in accounts and using insted of Trigger
/*
DELETE FROM Accounts 
WHERE AccountID = 
(SELECT AccountID FROM Logs
WHERE ChangeDate = 
(SELECT MAX(ChangeDate) FROM Logs))
GO
*/

------------------------------------------------------------------------------------------
-- Task 7. Define a function in the database TelerikAcademy that returns all Employee's	--
-- names (first or middle or last name) and all town's names that are comprised of		--
-- given set of letters. Example 'oistmiahf' will return 'Sofia', 'Smith',				--
-- … but not 'Rob' and 'Guy'.															--
------------------------------------------------------------------------------------------

USE [TelerikAcademy]
GO

-- Using helper function that finds if a string consists of other string

IF OBJECT_ID('dbo.ufn_StringComprisedOf') IS NOT NULL DROP FUNCTION ufn_StringComprisedOf 
GO 

CREATE FUNCTION [dbo].ufn_StringComprisedOf(@inputString nvarchar(50), @letterSet nvarchar(100))
  RETURNS BIT
AS
  BEGIN
	DECLARE @inputStringLenght int
	DECLARE @currentIndex int
	DECLARE @input nvarchar(50)
	DECLARE @pattern nvarchar(100)
	SET @inputStringLenght = LEN(@inputString)
	SET @currentIndex = 1
	SET @input = LOWER(@inputString)
	SET @pattern = LOWER(@letterSet)

	WHILE @currentIndex <= @inputStringLenght
	  BEGIN
		IF(CHARINDEX(SUBSTRING(@input,@currentindex,1),@pattern)=0)
		  BEGIN
			RETURN 0
		  END
		SET @currentIndex = @currentIndex +1
	  END
	RETURN 1
  END
GO


IF OBJECT_ID('dbo.ufn_EmployeesAndTownsNameComprisedOf') IS NOT NULL DROP FUNCTION ufn_EmployeesAndTownsNameComprisedOf 
GO 

CREATE FUNCTION [dbo].ufn_EmployeesAndTownsNameComprisedOf(@letterSet nvarchar(100))
  RETURNS @reulst_table TABLE (name nvarchar(50))
AS
BEGIN

DECLARE empCursor CURSOR READ_ONLY FOR
  SELECT Name FROM (
  SELECT FirstName AS Name FROM Employees
  UNION
  SELECT MiddleName AS Name FROM Employees
  UNION
  SELECT LastName AS Name FROM Employees
  UNION
  SELECT Name AS Name FROM Towns
  ) AS Names
  WHERE Name IS NOT NULL

OPEN empCursor
DECLARE @name nvarchar(50)
FETCH NEXT FROM empCursor INTO @name

DECLARE @nameLen int, @currentIndex int

WHILE @@FETCH_STATUS = 0
  BEGIN
	IF(dbo.ufn_StringComprisedOf(@name,@letterSet)=1)
	  BEGIN
	    INSERT INTO @reulst_table
		VALUES (@name)
	  END
    FETCH NEXT FROM empCursor 
    INTO @name
  END

CLOSE empCursor
DEALLOCATE empCursor
  RETURN
END
GO

SELECT * FROM [dbo].ufn_EmployeesAndTownsNameComprisedOf('oistmiahf')
GO

------------------------------------------------------------------------------------------
-- Task 8. Using database cursor write a T-SQL script that scans all employees and		-- 
-- their addresses and prints all pairs of employees that live in the same town.		--
------------------------------------------------------------------------------------------

USE [TelerikAcademy]
GO

SELECT e.EmployeeID ,e.FirstName + ISNULL(' '+ e.MiddleName, '') + ' ' + e.LastName AS EmployeeName, t.TownID, t.Name as TownName
INTO #TempEmployeesWithTowns
FROM Employees e INNER JOIN Addresses a on e.AddressID = a.AddressID
INNER JOIN Towns t on a.TownID = t.TownID 
CREATE UNIQUE CLUSTERED INDEX Idx_TemEmp ON #TempEmployeesWithTowns(EmployeeID)

DECLARE empCursor CURSOR READ_ONLY FOR
SELECT EmployeeID, EmployeeName, TownID,TownName
FROM #TempEmployeesWithTowns

OPEN empCursor
DECLARE @employeeID int, @employeeName varchar(150), @townID int,  @townName varchar(50)
FETCH NEXT FROM empCursor INTO @employeeID, @employeeName, @townID, @townName

CREATE TABLE #TempEmployeeFromSameTownPairs (FirstEmployeeName varchar(150), SecondEmployeeName varchar(150), TownName varchar(50))
WHILE @@FETCH_STATUS = 0
  BEGIN
	INSERT INTO #TempEmployeeFromSameTownPairs (FirstEmployeeName, SecondEmployeeName, TownName)
	SELECT @employeeName, EmployeeName, @townName FROM #TempEmployeesWithTowns e
	WHERE e.TownID = @townID AND e.EmployeeID <> @employeeID
    FETCH NEXT FROM empCursor INTO @employeeID, @employeeName, @townID, @townName           
  END
CLOSE empCursor
DEALLOCATE empCursor

SELECT TownName, FirstEmployeeName, SecondEmployeeName FROM #TempEmployeeFromSameTownPairs
ORDER BY TownName, FirstEmployeeName, SecondEmployeeName
DROP TABLE #TempEmployeeFromSameTownPairs
DROP TABLE #TempEmployeesWithTowns
GO

-- This is the outer join way to do it without a db cursor

SELECT t1.Name, e1.FirstName + ISNULL(' '+ e1.MiddleName, '') + ' ' + e1.LastName AS FirstEmployeeName,
e2.FirstName + ISNULL(' '+ e2.MiddleName, '') + ' ' + e2.LastName AS SecondEmployeeName
FROM Employees e1 JOIN Addresses a1 ON e1.AddressID = a1.AddressID
JOIN Towns t1 ON a1.TownID = t1.TownID,
Employees e2 JOIN Addresses a2 ON e2.AddressID = a2.AddressID
JOIN Towns t2 ON a2.TownID = t2.TownID
WHERE t1.Name = t2.Name
AND e1.EmployeeID <> e2.EmployeeID
ORDER BY t1.Name, FirstEmployeeName, SecondEmployeeName

------------------------------------------------------------------------------------------
-- Task 9. Write a T-SQL script that shows for each town a list of all employees		--
-- that live in it. Sample output: Sofia -> Svetlin Nakov, Martin Kulov, George Denchev	--
-- Ottawa -> Jose Saraiva																--
------------------------------------------------------------------------------------------

-- Solution with nested Cursors. Prints in Messages Window

USE [TelerikAcademy]
GO

SELECT e.FirstName + ISNULL(' '+ e.MiddleName, '') + ' ' + e.LastName AS EmployeeName, t.TownID
INTO #TempEmployeesWithTowns
FROM Employees e INNER JOIN Addresses a on e.AddressID = a.AddressID
INNER JOIN Towns t on a.TownID = t.TownID 
CREATE INDEX Idx_TemTown ON #TempEmployeesWithTowns(TownID)


DECLARE townCursor CURSOR READ_ONLY FOR
SELECT TownID, Name FROM Towns
OPEN townCursor
DECLARE @townID int, @townName varchar(50)
FETCH NEXT FROM townCursor INTO @townID, @townName
WHILE @@FETCH_STATUS = 0
  BEGIN
    DECLARE empCursor CURSOR READ_ONLY FOR
	SELECT EmployeeName FROM #TempEmployeesWithTowns
	WHERE TownID = @townID

	OPEN empCursor
	DECLARE @employeeName varchar(150), @employeesList varchar(MAX)
	SET @employeesList = ''
	FETCH NEXT FROM empCursor INTO @employeeName

	WHILE @@FETCH_STATUS = 0	
	  BEGIN
		SET @employeesList = CONCAT(@employeesList, @employeeName, ', ')
		FETCH NEXT FROM empCursor INTO @employeeName
	  END  
	CLOSE empCursor
	DEALLOCATE empCursor
	SET @employeesList = LEFT(@employeesList, LEN(@employeesList) - 1)
	PRINT @townName + ' -> ' + @employeesList
	FETCH NEXT FROM townCursor INTO @townID, @townName         
  END
CLOSE townCursor
DEALLOCATE townCursor
DROP TABLE #TempEmployeesWithTowns
GO

------------------------------------------------------------------------------------------
-- Task 10. Define a .NET aggregate function StrConcat that takes as input a sequence of--
-- strings and return a single string that consists of the input strings separated by	--
-- ','. For example the following SQL statement should return a single string:			--
-- SELECT StrConcat(FirstName + ' ' + LastName) FROM Employees							--
------------------------------------------------------------------------------------------

USE [TelerikAcademy]
GO

IF OBJECT_ID('dbo.StrConcat') IS NOT NULL DROP Aggregate StrConcat 
GO 

IF EXISTS (SELECT * FROM sys.assemblies WHERE name = 'concat_assembly') 
       DROP assembly concat_assembly; 
GO      

DECLARE @path nvarchar(256)
-- You must change this path to the folder where the .dll with the CLR function is.
SET @path = 'C:\PathToFile'

CREATE Assembly concat_assembly 
   AUTHORIZATION dbo 
   FROM @path+'\ConcatAggregateSqlFunction.dll' 
   WITH PERMISSION_SET = SAFE; 
GO 

CREATE AGGREGATE dbo.StrConcat ( 

    @Value NVARCHAR(MAX),
	@Delimiter NVARCHAR(4000) 

) RETURNS NVARCHAR(MAX) 
EXTERNAL Name concat_assembly.Concat; 
GO

-- Enable execution of CLR code 
sp_configure 'clr enabled',1
GO
RECONFIGURE
GO
--sp_configure 'clr enabled'  -- make sure it took
--GO

SELECT [dbo].StrConcat(FirstName + ' ' + LastName, ', ') as Names
FROM Employees

------------------------------------------------------------------------------------------
-- Solution to Task 9 with StrConcat from Task10										--
------------------------------------------------------------------------------------------

USE [TelerikAcademy]
GO

SELECT t.Name AS Town, [dbo].StrConcat(FirstName + ' ' + LastName, ', ') AS Employees
FROM Employees e INNER JOIN Addresses a ON e.AddressID = a.AddressID
INNER JOIN Towns t ON t.TownID = a.TownID
GROUP BY t.Name
ORDER BY t.Name

-- You might want to disable CLR execution afterwords
/*
sp_configure 'clr enabled',0
GO
RECONFIGURE
GO
sp_configure 'clr enabled'  -- make sure it took
GO
*/  
