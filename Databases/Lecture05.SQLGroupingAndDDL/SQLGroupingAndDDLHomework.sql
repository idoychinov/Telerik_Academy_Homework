use [TelerikAcademy]

------------------------------------------------------------------------------------------
-- Task 1. Write a SQL query to find the names and salaries of the employees that take	--
-- the minimal salary in the company. Use a nested SELECT statement.					--
------------------------------------------------------------------------------------------

SELECT EmployeeID, FirstName, MiddleName, LastName,Salary FROM Employees
WHERE Salary = (SELECT MIN(Salary) FROM Employees)

------------------------------------------------------------------------------------------
-- Task 2. Write a SQL query to find the names and salaries of the employees that		--
-- have a salary that is up to 10% higher than the minimal salary for the company.		--
------------------------------------------------------------------------------------------

SELECT EmployeeID, FirstName, MiddleName, LastName,Salary FROM Employees
WHERE Salary <= (SELECT MIN(Salary) FROM Employees)*1.1

------------------------------------------------------------------------------------------
-- Task 3. Write a SQL query to find the full name, salary and department of the		--
-- employees that take the minimal salary in their department.							--
-- Use a nested SELECT statement.														--
------------------------------------------------------------------------------------------

SELECT e.EmployeeID, e.FirstName + ISNULL(' '+ e.MiddleName,'') + ' ' + e.LastName AS FullName,
e.Salary, d.Name FROM Employees e
INNER JOIN Departments d ON e.DepartmentID=d.DepartmentID
WHERE Salary = (SELECT MIN(Salary) FROM Employees WHERE DepartmentID = e.DepartmentID)

------------------------------------------------------------------------------------------
-- Task 4. Write a SQL query to find the average salary in the department #1.			--
------------------------------------------------------------------------------------------

SELECT AVG (Salary) AS AverageSalary FROM Employees
WHERE DepartmentID = 1

------------------------------------------------------------------------------------------
-- Task 5. Write a SQL query to find the average salary  in the "Sales" department.		--
------------------------------------------------------------------------------------------

SELECT AVG (e.Salary) AS AverageSalary FROM Employees e
INNER JOIN Departments d ON e.DepartmentID=d.DepartmentID
WHERE d.Name = 'Sales'

------------------------------------------------------------------------------------------
-- Task 6. Write a SQL query to find the number of employees in the "Sales" department.	--
------------------------------------------------------------------------------------------

SELECT COUNT (e.EmployeeID) AS NumberOfEmployees FROM Employees e
INNER JOIN Departments d ON e.DepartmentID=d.DepartmentID
WHERE d.Name = 'Sales'

------------------------------------------------------------------------------------------
-- Task 7. Write a SQL query to find the number of all employees that have manager.		--
------------------------------------------------------------------------------------------

SELECT COUNT (e.EmployeeID) AS NumberOfEmployees FROM Employees e
WHERE e.ManagerID IS NOT NULL

------------------------------------------------------------------------------------------
-- Task 8. Write a SQL query to find the number of all employees that have no manager.	--
------------------------------------------------------------------------------------------

SELECT COUNT (e.EmployeeID) AS NumberOfEmployees FROM Employees e
WHERE e.ManagerID IS NULL

------------------------------------------------------------------------------------------
-- Task 9. Write a SQL query to find all departments and the average salary				--
-- for each of them.																	--
------------------------------------------------------------------------------------------

SELECT d.DepartmentID, d.Name, AVG(e.Salary) AS AverageSalary FROM Employees e
INNER JOIN Departments d ON e.DepartmentID=d.DepartmentID
GROUP BY d.DepartmentID, d.Name

------------------------------------------------------------------------------------------
-- Task 10. Write a SQL query to find the count of all employees in each department		--
-- and for each town.																	--
------------------------------------------------------------------------------------------

SELECT d.DepartmentID, d.Name, t.Name, COUNT(e.EmployeeID) AS NumberOfEmployees FROM Employees e
INNER JOIN Departments d ON e.DepartmentID=d.DepartmentID
INNER JOIN Addresses a ON e.AddressID=a.AddressID
INNER JOIN Towns t ON a.TownID = t.TownID
GROUP BY d.DepartmentID, d.Name, t.Name
ORDER BY d.Name, t.Name, NumberOfEmployees


------------------------------------------------------------------------------------------
-- Task 11. Write a SQL query to find all managers that have exactly 5 employees.		--
-- Display their first name and last name.												--
------------------------------------------------------------------------------------------

SELECT m.ManagerID, e.FirstName, e.LastName FROM Employees m
INNER JOIN Employees e ON m.ManagerID = e.EmployeeID
GROUP BY m.ManagerID, e.FirstName, e.LastName
HAVING COUNT(m.EmployeeID)=5

------------------------------------------------------------------------------------------
-- Task 12. Write a SQL query to find all employees along with their managers.			--
-- For employees that do not have manager display the value "(no manager)".				--
------------------------------------------------------------------------------------------

SELECT e.EmployeeID, e.FirstName + ISNULL(' ' + e.MiddleName,'') +' ' + e.LastName AS EmployeeName,
m.EmployeeID as ManagerID, COALESCE(m.FirstName + ISNULL(' ' + m.MiddleName,'') +' ' + m.LastName , 'no manager') AS ManagerName
FROM Employees e
LEFT JOIN Employees m ON e.ManagerID = m.EmployeeID
ORDER BY m.ManagerID

------------------------------------------------------------------------------------------
-- Task 13. Write a SQL query to find the names of all employees whose last name is		--
-- exactly 5 characters long. Use the built-in LEN(str) function.						--
------------------------------------------------------------------------------------------

SELECT e.EmployeeID, e.FirstName, e.LastName FROM Employees e
WHEre  LEN(e.LastName) = 5 

------------------------------------------------------------------------------------------
-- Task 14. Write a SQL query to display the current date and time in the following		--
-- format "day.month.year hour:minutes:seconds:milliseconds".							--
-- Search in  Google to find how to format dates in SQL Server.							--
------------------------------------------------------------------------------------------

SELECT CONVERT(varchar, getdate(), 113) -- Magic numbers FTW...

------------------------------------------------------------------------------------------
-- Task 15. Write a SQL statement to create a table Users. Users should have username,	--
-- password, full name and last login time. Choose appropriate data types for the table	--
-- fields. Define a primary key column with a primary key constraint. Define the primary--
-- key column as identity to facilitate inserting records. Define unique constraint to	--
-- avoid repeating usernames. Define a check constraint to ensure the password is at	--
-- least 5 characters long.																--
------------------------------------------------------------------------------------------

CREATE TABLE Users (
  UserID int IDENTITY,
  UserName nvarchar(20) NOT NULL,
  UserPassword nvarchar(100),
  FullName nvarchar(100) NOT NULL,
  LastLogin datetime,
  CONSTRAINT PK_Persons PRIMARY KEY(UserID),
  CONSTRAINT UC_UserName UNIQUE (UserName),
  CONSTRAINT CC_PASSWORD CHECK (LEN(UserPassword)>=5)
)
GO

-- INSERT data
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([UserID], [UserName], [UserPassword], [FullName], [LastLogin]) VALUES (1, N'pesho', N'asdsdd', N'Pesho Petrov', CAST(N'2014-08-22 14:31:50.473' AS DateTime))
GO
INSERT [dbo].[Users] ([UserID], [UserName], [UserPassword], [FullName], [LastLogin]) VALUES (2, N'gosho', N'3edff', N'Gosho Goshov', CAST(N'2014-08-22 00:12:50.473' AS DateTime))
GO
INSERT [dbo].[Users] ([UserID], [UserName], [UserPassword], [FullName], [LastLogin]) VALUES (3, N'mariq', N'dadkfkw', N'Mariq Petrova', CAST(N'2014-08-22 20:12:50.473' AS DateTime))
GO
INSERT [dbo].[Users] ([UserID], [UserName], [UserPassword], [FullName], [LastLogin]) VALUES (4, N'mitko', N'dsew42', N'Dimitar Dimitrov', CAST(N'2014-08-20 00:12:50.473' AS DateTime))
GO
INSERT [dbo].[Users] ([UserID], [UserName], [UserPassword], [FullName], [LastLogin]) VALUES (5, N'elena', N'lssdfdsf', N'Elena Milanova', CAST(N'2014-05-20 00:12:50.473' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
 
------------------------------------------------------------------------------------------
-- Task 16. Write a SQL statement to create a view that displays the users from			--
-- the Users table that have been in the system today. Test if the view works correctly.--
------------------------------------------------------------------------------------------

CREATE VIEW [UsersLoggedToday] AS
SELECT * FROM Users
WHERE CAST(LastLogin as date) >= CAST(GETDATE() as date)
GO

------------------------------------------------------------------------------------------
-- Task 17. Write a SQL statement to create a table Groups. Groups should have unique	--
-- name (use unique constraint). Define primary key and identity column.				--
------------------------------------------------------------------------------------------

CREATE TABLE Groups (
  GroupID int IDENTITY,
  GroupName nvarchar(50) NOT NULL,
  CONSTRAINT PK_Users PRIMARY KEY(GroupID),
  CONSTRAINT UC_GroupName UNIQUE (GroupName)
)
GO

------------------------------------------------------------------------------------------
-- Task 18. Write a SQL statement to add a column GroupID to the table Users.			--
-- Fill some data in this new column and as well in the Groups table. Write a SQL		--
-- statement to add a foreign key constraint between tables Users and Groups tables.	--
------------------------------------------------------------------------------------------

-- Add GroupID to users
ALTER TABLE Users ADD GroupID int
GO

-- Fill data in Groups
SET IDENTITY_INSERT [dbo].[Groups] ON 
GO
INSERT [dbo].[Groups] ([GroupID],[GroupName]) VALUES (1,'Administrators')
INSERT [dbo].[Groups] ([GroupID],[GroupName]) VALUES (2,'Guests')
INSERT [dbo].[Groups] ([GroupID],[GroupName]) VALUES (3,'StandardUsers')
INSERT [dbo].[Groups] ([GroupID],[GroupName]) VALUES (4,'Ninjas')
GO
SET IDENTITY_INSERT [dbo].[Groups] OFF
GO

-- Fill GroupIDs in Users (the intelisens finds GroupID as invalid for some reason but the script works
UPDATE Users SET GroupID = 1  WHERE UserID = 1 
UPDATE Users SET GroupID = 3  WHERE UserID = 2 
UPDATE Users SET GroupID = 2  WHERE UserID = 3 
UPDATE Users SET GroupID = 1  WHERE UserID = 4 
UPDATE Users SET GroupID = 4  WHERE UserID = 5 
GO

-- Add a foreign key constraint Users --> Groups
ALTER TABLE Users
ADD CONSTRAINT FK_Users_Groups
  FOREIGN KEY (GroupID)
  REFERENCES Groups(GroupID)
GO
------------------------------------------------------------------------------------------
-- Task 19. Write SQL statements to insert several records in the						--
-- Users and Groups tables.																--
------------------------------------------------------------------------------------------

INSERT [dbo].[Groups] ([GroupName]) VALUES ('Super Ninjas')
INSERT [dbo].[Groups] ([GroupName]) VALUES ('Newbs')
GO

INSERT [dbo].[Users] ([UserName], [UserPassword], [FullName], [LastLogin]) VALUES (N'mincho', N'dfsdfg', N'Mincho Praznikov', CAST(N'2013-08-20 00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Users] ([UserName], [UserPassword], [FullName]) VALUES (N'lili', N'sdfwedf', N'Lili Ivanova')
GO

------------------------------------------------------------------------------------------
-- Task 20. Write SQL statements to update some of the records in the					--
-- Users and Groups tables.																--
------------------------------------------------------------------------------------------

UPDATE Users SET GroupID = 
(SELECT GroupID FROM Groups WHERE GroupName ='Super Ninjas')
WHERE UserName = 'mincho' 
UPDATE Users SET GroupID = 
(SELECT GroupID FROM Groups WHERE GroupName ='Newbs')
WHERE UserName = 'lili'
GO

UPDATE Groups SET GroupName = 'Noobs'  WHERE GroupName = 'Newbs' 
GO
------------------------------------------------------------------------------------------
-- Task 21. Write SQL statements to delete some of the records in the					--
-- Users and Groups tables.																--
------------------------------------------------------------------------------------------

DELETE FROM Users 
WHERE UserName = 'lili'
GO

DELETE FROM Groups 
WHERE GroupName = 'Noobs'
GO

------------------------------------------------------------------------------------------
-- Task 22. Write SQL statements to insert in the Users table the names of all employees--
-- from the Employees table. Combine the first and last names as a full name.			-- 
-- For username use the first letter of the first name + the last name (in lowercase).	--
-- Use the same for the password, and NULL for last login time.							--
------------------------------------------------------------------------------------------

INSERT INTO [dbo].[Users] (UserName, FullName, UserPassword, LastLogin)
SELECT LEFT(LOWER(e.FirstName),1) + LOWER(e.LastName) AS UserName,
e.FirstName + ' ' + e.LastName AS FullName,
LEFT(LOWER(e.FirstName),1) + LOWER(e.LastName) AS UserPassword,
NULL -- It's not necessery to explisitly set null in this case, but in case of some other defaullt falue set on for the coulumn it's better 
FROM Employees e
WHERE (1 + LEN(e.LastName)) >=5 -- only users that will pass the password constraint
AND LEFT(LOWER(e.FirstName),1) + LOWER(e.LastName) <> 'ahill' -- fails the unique constraint check
GO

------------------------------------------------------------------------------------------
-- Task 23. Write a SQL statement that changes the password to NULL for all users		--
-- that have not been in the system since 10.03.2010.									--
------------------------------------------------------------------------------------------

-- set one user last login to date before 10.03.2010
UPDATE [dbo].[Users] SET LastLogin = CONVERT(datetime, '10.06.2009',104)
WHERE UserName = 'mincho'
GO

UPDATE [dbo].[Users] SET UserPassword = NULL
WHERE CAST(LastLogin AS date) <= CONVERT(datetime, '10.03.2010',104)
GO

------------------------------------------------------------------------------------------
-- Task 24. Write a SQL statement that deletes all users without passwords				--
-- (NULL password).																		--
------------------------------------------------------------------------------------------

DELETE FROM Users
WHERE UserPassword IS NULL
GO

------------------------------------------------------------------------------------------
-- Task 25. Write a SQL query to display the average employee salary by					--
-- department and job title.															--
------------------------------------------------------------------------------------------

SELECT d.Name, e.JobTitle, AVG(e.Salary) AS AvgSalary FROM Employees e
INNER JOIN Departments d ON d.DepartmentID = e.DepartmentID
GROUP BY d.Name,e.JobTitle

------------------------------------------------------------------------------------------
-- Task 26. Write a SQL query to display the minimal employee salary by department		--
-- and job title along with the name of some of the employees that take it.				--
------------------------------------------------------------------------------------------

--TODO: Maka a better statement

SELECT ms.Name, ms.JobTitle, ms.MinSalary, emp.FirstName + ' ' + emp.LastName as Name FROM 
(SELECT d.Name, d.DepartmentID, e.JobTitle, MIN(e.Salary) AS MinSalary FROM Employees e
INNER JOIN Departments d ON d.DepartmentID = e.DepartmentID
GROUP BY d.Name, d.DepartmentID, e.JobTitle) ms
INNER JOIN Employees emp ON emp.Salary =  ms.MinSalary AND emp.JobTitle = ms.JobTitle AND emp.DepartmentID = ms.DepartmentID

------------------------------------------------------------------------------------------
-- Task 27. Write a SQL query to display the town where maximal number of employees		--
-- work.																				--
------------------------------------------------------------------------------------------

--TODO: Maka a better statement

SELECT t.Name, COUNT(e.EmployeeID) as EmployeeCount FROM Employees e
INNER JOIN Addresses a on e.AddressID = a.AddressID
INNER JOIN Towns t on a.TownID = t.TownID
GROUP BY t.Name
HAVING COUNT(e.EmployeeID) =
(SELECT MAX(c.EmployeeCount) FROM
(SELECT t.Name, COUNT(e.EmployeeID) as EmployeeCount FROM Employees e
INNER JOIN Addresses a on e.AddressID = a.AddressID
INNER JOIN Towns t on a.TownID = t.TownID
GROUP BY t.Name) c)

------------------------------------------------------------------------------------------
-- Task 28. Write a SQL query to display the number of managers from each town.			--
------------------------------------------------------------------------------------------

SELECT t.Name, COUNT(DISTINCT(e.ManagerID)) FROM Employees e
INNER JOIN Employees m ON m.EmployeeID = e.ManagerID
INNER JOIN Addresses a ON m.AddressID = a.AddressID
INNER JOIN Towns t ON a.TownID = t.TownID
GROUP BY t.Name

------------------------------------------------------------------------------------------
-- Task 29. Write a SQL to create table WorkHours to store work reports for each		--
-- employee (employee id, date, task, hours, comments). Don't forget to define			--
-- identity, primary key and appropriate foreign key.									--
-- Issue few SQL statements to insert, update and delete of some data in the table.		--
-- Define a table WorkHoursLogs to track all changes in the WorkHours table				--
-- with triggers. For each change keep the old record data, the new record data and		--
-- the command (insert / update / delete).												--
------------------------------------------------------------------------------------------

CREATE TABLE WorkHours
(
  WorkHourEntryID int IDENTITY,
  EntryDate date NOT NULL,
  Task nvarchar(100) NOT NULL,
  EntryHours int NOT NULL,
  EntryComments nvarchar(200),
  EmployeeID int NOT NULL,
  CONSTRAINT PK_WorkHourEntryID PRIMARY KEY(WorkHourEntryID),
  CONSTRAINT CC_Hours CHECK (EntryHours>0 AND EntryHours<=24)
)
GO

ALTER TABLE [dbo].[WorkHours]  WITH CHECK ADD  CONSTRAINT [FK_WorkHours_Employees] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employees] ([EmployeeID])
GO

-- Work Hours Logs

CREATE TABLE WorkHoursLogs
(
  LogID int IDENTITY,
  WorkHourEntryIDOld int,
  EntryDateOld date,
  TaskOld nvarchar(100),
  EntryHoursOld int,
  EntryCommentsOld nvarchar(200),
  EmployeeIDOld int,
  WorkHourEntryIDNew int,
  EntryDateNew date,
  TaskNew nvarchar(100),
  EntryHoursNew int,
  EntryCommentsNew nvarchar(200),
  EmployeeIDNew int,
  CommandType nvarchar(10),
  CONSTRAINT PK_LogID PRIMARY KEY(LogID),
)
GO

CREATE TRIGGER tr_WorkHoursInsert ON WorkHours FOR INSERT
AS
  INSERT INTO WorkHoursLogs (WorkHourEntryIDOld,EntryDateOld,TaskOld,EntryHoursOld,EntryCommentsOld,
  EmployeeIDOld,WorkHourEntryIDNew,EntryDateNew,TaskNew,EntryHoursNew,EntryCommentsNew,
  EmployeeIDNew,CommandType)
  SELECT NULL, NULL, NULL, NULL, NULL, NULL,
  i.WorkHourEntryID, i.EntryDate, i.Task, i.EntryHours, i.EntryComments, i.EmployeeID,'insert'
  FROM WorkHours w INNER JOIN inserted i on w.WorkHourEntryID = i.WorkHourEntryID
GO

CREATE TRIGGER tr_WorkHoursUpdate ON WorkHours FOR UPDATE
AS
  INSERT INTO WorkHoursLogs (WorkHourEntryIDOld,EntryDateOld,TaskOld,EntryHoursOld,EntryCommentsOld,
  EmployeeIDOld,WorkHourEntryIDNew,EntryDateNew,TaskNew,EntryHoursNew,EntryCommentsNew,
  EmployeeIDNew,CommandType)
  SELECT d.WorkHourEntryID, d.EntryDate, d.Task, d.EntryHours, d.EntryComments, d.EmployeeID,
  i.WorkHourEntryID, i.EntryDate, i.Task, i.EntryHours, i.EntryComments, i.EmployeeID,'update'
  FROM deleted d INNER JOIN inserted i on d.WorkHourEntryID = i.WorkHourEntryID
GO

CREATE TRIGGER tr_WorkHoursDelete ON WorkHours FOR DELETE
AS
  INSERT INTO WorkHoursLogs (WorkHourEntryIDOld,EntryDateOld,TaskOld,EntryHoursOld,EntryCommentsOld,
  EmployeeIDOld,WorkHourEntryIDNew,EntryDateNew,TaskNew,EntryHoursNew,EntryCommentsNew,
  EmployeeIDNew,CommandType)
  SELECT d.WorkHourEntryID, d.EntryDate, d.Task, d.EntryHours, d.EntryComments, d.EmployeeID,
  NULL, NULL, NULL, NULL, NULL, NULL,'delete'
  FROM deleted d
GO

INSERT INTO WorkHours (EntryDate, Task, EntryHours, EntryComments, EmployeeID)
VALUES (CONVERT(date, '20140712', 112), 'Slacking', 8, 'no comment', 1),
(CONVERT(date, '20140511', 112), 'Digging', 4, NULL, 3),
(CONVERT(date, '20140713', 112), 'More Slacking', 4, 'today i had to work :(', 1),
(CONVERT(date, '20140611', 112), 'Working', 12, 'more work', 2),
(CONVERT(date, '20140530', 112), 'Meeting', 5, NULL , 4)
GO

UPDATE WorkHours
SET EntryHours = 8, Task = 'Very important work', EntryComments = 'so busy, much work, wow'
WHERE EmployeeID=1 AND EntryDate = CONVERT(date, '20140713', 112)
GO

DELETE FROM WorkHours
WHERE EmployeeID = 4

------------------------------------------------------------------------------------------
-- Task 30. Start a database transaction, delete all employees from the 'Sales'			--
-- department along with all dependent records from the other tables.					--
-- At the end rollback the transaction.													--
------------------------------------------------------------------------------------------

BEGIN TRAN 
ALTER TABLE Departments DROP [FK_Departments_Employees]
DELETE FROM Employees 
WHERE DepartmentID = (SELECT DepartmentID FROM Departments WHERE Name = 'Sales')
DELETE FROM Departments 
WHERE Name = 'Sales'
ROLLBACK TRAN
GO

------------------------------------------------------------------------------------------
-- Task 31. Start a database transaction and drop the table EmployeesProjects.			--
-- Now how you could restore back the lost table data?									--
------------------------------------------------------------------------------------------

BEGIN TRAN 
DROP TABLE EmployeesProjects
ROLLBACK TRAN
GO

------------------------------------------------------------------------------------------
-- Task 32. Find how to use temporary tables in SQL Server. Using temporary tables		--
-- backup all records from EmployeesProjects and restore them back after dropping		--
-- and re-creating the table.															--
------------------------------------------------------------------------------------------

BEGIN TRAN
SELECT * INTO #TempTable FROM EmployeesProjects
DROP TABLE EmployeesProjects
COMMIT

CREATE TABLE [dbo].[EmployeesProjects](
	[EmployeeID] [int] NOT NULL,
	[ProjectID] [int] NOT NULL,
 CONSTRAINT [PK_EmployeesProjects] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC,
	[ProjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[EmployeesProjects]  WITH CHECK ADD  CONSTRAINT [FK_EmployeesProjects_Employees] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employees] ([EmployeeID])
GO

ALTER TABLE [dbo].[EmployeesProjects] CHECK CONSTRAINT [FK_EmployeesProjects_Employees]
GO

ALTER TABLE [dbo].[EmployeesProjects]  WITH CHECK ADD  CONSTRAINT [FK_EmployeesProjects_Projects] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Projects] ([ProjectID])
GO

ALTER TABLE [dbo].[EmployeesProjects] CHECK CONSTRAINT [FK_EmployeesProjects_Projects]
GO

--Add to EmployeesProjects from backup

INSERT INTO EmployeesProjects
SELECT * FROM #TempTable
GO