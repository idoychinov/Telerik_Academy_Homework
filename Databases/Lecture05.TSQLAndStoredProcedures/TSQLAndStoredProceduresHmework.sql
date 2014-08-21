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
	[id] [int] IDENTITY(1,1) NOT NULL,
	[balance] [decimal](18, 0) NOT NULL,
	[person_id] [int] NOT NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Persons]    Script Date: 21.8.2014 ã. 15:00:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persons](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[SSN] [nvarchar](9) NOT NULL,
 CONSTRAINT [PK_Persons] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Accounts] ON 

GO
INSERT [dbo].[Accounts] ([id], [balance], [person_id]) VALUES (1, CAST(123 AS Decimal(18, 0)), 1)
GO
INSERT [dbo].[Accounts] ([id], [balance], [person_id]) VALUES (2, CAST(0 AS Decimal(18, 0)), 2)
GO
INSERT [dbo].[Accounts] ([id], [balance], [person_id]) VALUES (3, CAST(1000 AS Decimal(18, 0)), 3)
GO
SET IDENTITY_INSERT [dbo].[Accounts] OFF
GO
SET IDENTITY_INSERT [dbo].[Persons] ON 

GO
INSERT [dbo].[Persons] ([id], [FirstName], [LastName], [SSN]) VALUES (1, N'John', N'Doe', N'123456789')
GO
INSERT [dbo].[Persons] ([id], [FirstName], [LastName], [SSN]) VALUES (2, N'Peter', N'Griffin', N'000000000')
GO
INSERT [dbo].[Persons] ([id], [FirstName], [LastName], [SSN]) VALUES (3, N'Aeryn', N'Sun', N'344522345')
GO
SET IDENTITY_INSERT [dbo].[Persons] OFF
GO
ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD  CONSTRAINT [FK_Accounts_Persons] FOREIGN KEY([person_id])
REFERENCES [dbo].[Persons] ([id])
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
	SELECT p.id, a.TotalBalance as money
	FROM Persons p INNER JOIN 
	(SELECT acc.person_id, SUM (acc.balance) as TotalBalance
	FROM Accounts acc 
	GROUP BY acc.person_id
	) as a on p.id=a.person_id
	where a.TotalBalance >= @money
GO

EXEC dbo.ups_SelectPersonsWithMoneyMoreThan 100
GO

------------------------------------------------------------------------------------------
-- Task 3. Create a function that accepts as parameters – sum, yearly interest rate		--
-- and number of months. It should calculate and return the new sum. Write a SELECT to	--
-- test whether the function works as expected.											--
------------------------------------------------------------------------------------------

CREATE FUNCTION dbo.ufn_CalcInterest(@sum money, @interest_rate int, @months int)
  RETURNS money
AS
BEGIN
  RETURN @sum--*((@interest_rate*@months/12)/100)
END
GO

SELECT dbo.ufn_CalcInterest(100, 20, 6) as NewSum
GO
