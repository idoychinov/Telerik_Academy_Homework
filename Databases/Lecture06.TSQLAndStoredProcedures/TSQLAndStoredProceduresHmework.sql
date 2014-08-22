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

CREATE FUNCTION dbo.ufn_CalcInterest(@sum money, @interestRate decimal, @months decimal)
  RETURNS money
AS
BEGIN
  RETURN @sum+@sum*((@interestRate*@months/12)/100)
END
GO

SELECT dbo.ufn_CalcInterest(100, 30, 6) as NewSum
GO

------------------------------------------------------------------------------------------
-- Task 4. Create a stored procedure that uses the function from the previous example	--
-- to give an interest to a person's account for one month. It should take the AccountId--
-- and the interest rate as parameters.													--
------------------------------------------------------------------------------------------

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
*/
GO

------------------------------------------------------------------------------------------
-- Task 7. Define a function in the database TelerikAcademy that returns all Employee's	--
-- names (first or middle or last name) and all town's names that are comprised of		--
-- given set of letters. Example 'oistmiahf' will return 'Sofia', 'Smith',				--
-- … but not 'Rob' and 'Guy'.															--
------------------------------------------------------------------------------------------

USE [TelerikAcademy]
GO
-- Not sure if i understood the Task right but here is my take on it

CREATE FUNCTION dbo.ufn_EmployeesAndTownsNameComprisedOf(@letterSet nvarchar(100))
  RETURNS @reulst_table TABLE (name varchar(50))
AS
BEGIN

DECLARE empCursor CURSOR READ_ONLY FOR
  SELECT FirstName, MiddleName, LastName FROM Employees

OPEN empCursor
DECLARE @firstName char(50), @middleName char(50), @lastName char(50)
FETCH NEXT FROM empCursor INTO @firstName, @middleName, @lastName

DECLARE @nameLen int, @currentIndex int

WHILE @@FETCH_STATUS = 0
  BEGIN
	SET @nameLen = LEN(@firstName)
	SET @currentIndex = 0

	WHILE @currentIndex < @nameLen
	  BEGIN
		--todo
		SET @currentIndex = @currentIndex +1
	  END

    FETCH NEXT FROM empCursor 
    INTO @firstName, @middleName, @lastName
  END

CLOSE empCursor
DEALLOCATE empCursor


  RETURN
END
GO


SELECT dbo.ufn_EmployeesAndTownsNameComprisedOf('oistmiahf') as Names
GO
------------------------------------------------------------------------------------------
-- Task 8. Using database cursor write a T-SQL script that scans all employees and		-- 
-- their addresses and prints all pairs of employees that live in the same town.		--
------------------------------------------------------------------------------------------

DECLARE empCursor CURSOR READ_ONLY FOR
  SELECT e.FirstName + ISNULL(' '+ e.MiddleName, '') + ' ' + e.LastName AS EmployeeName, 
  t.Name AS TownName
  FROM Employees e
  INNER JOIN Addresses a ON e.AddressID = a.AddressID
  INNER JOIN Towns t ON t.TownID = a.TownID

OPEN empCursor
DECLARE @employeeName char(150), @townName char(50)
FETCH NEXT FROM empCursor INTO @employeeName, @townName

WHILE @@FETCH_STATUS = 0
  BEGIN
    PRINT @firstName + ' ' + @lastName
    FETCH NEXT FROM empCursor 
    INTO @firstName, @lastName
  END

CLOSE empCursor
DEALLOCATE empCursor

------------------------------------------------------------------------------------------
-- Task 9. Write a T-SQL script that shows for each town a list of all employees		--
-- that live in it. Sample output: Sofia -> Svetlin Nakov, Martin Kulov, George Denchev	--
-- Ottawa -> Jose Saraiva																--
------------------------------------------------------------------------------------------


------------------------------------------------------------------------------------------
-- Task 10. Define a .NET aggregate function StrConcat that takes as input a sequence of--
-- strings and return a single string that consists of the input strings separated by	--
-- ','. For example the following SQL statement should return a single string:			--
------------------------------------------------------------------------------------------