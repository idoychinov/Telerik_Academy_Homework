------------------------------------------------------------------------------------------
-- Create database HWPerformanceDB														--
------------------------------------------------------------------------------------------

USE master
GO

CREATE DATABASE HWPerformanceDB
GO

USE HWPerformanceDB
GO

------------------------------------------------------------------------------------------
-- Task 1. Create a table in SQL Server with 10 000 000 log entries (date + text).		--
-- Search in the table by date range. Check the speed (without caching).				--
------------------------------------------------------------------------------------------
CREATE TABLE Logs(
  LogId int NOT NULL IDENTITY,
  LogText varchar(100),
  LogDateTime datetime
)

ALTER TABLE Logs ADD 
CONSTRAINT PK_LogId PRIMARY KEY CLUSTERED (LogId)
GO

INSERT INTO Logs(LogText) VALUES ('Day 1 : Where am I?')
INSERT INTO Logs(LogText,LogDateTime) VALUES ('Day 2 : Can any body here me.', DATEADD(dd,-4,GETDATE()))
INSERT INTO Logs(LogText,LogDateTime) VALUES ('Day 3 : What is this sound?', DATEADD(dd,-3,GETDATE()))
INSERT INTO Logs(LogText,LogDateTime) VALUES ('Day 4 : They are comming!', DATEADD(dd,-2,GETDATE()))
INSERT INTO Logs(LogText,LogDateTime) VALUES ('Day 5 : What is this light!', DATEADD(dd,-1,GETDATE()))
GO

DECLARE @Counter int = 0
WHILE (SELECT COUNT(*) FROM Logs) < 10000000 -- it creates 10 000 000 for around 2 minutes. If you dont want to wait make them less
BEGIN
  INSERT INTO Logs(LogText,LogDateTime)
  SELECT LogText + CONVERT(varchar, @Counter), LogDateTime FROM Logs
  SET @Counter = @Counter + 1
END

CHECKPOINT; DBCC DROPCLEANBUFFERS; -- Empty the SQL Server cache
GO

SELECT * FROM Logs WHERE LogDateTime BETWEEN  DATEADD(dd,-3,GETDATE()) AND  DATEADD(dd,-1,GETDATE()) -- select two days or 2/5 of the tabe rows
GO

-- create Index on date
IF EXISTS (SELECT name FROM sys.indexes
            WHERE name = N'IX_LogDateTime')
    DROP INDEX IX_LogDateTime ON Logs;
GO
CREATE INDEX IX_LogDateTime ON Logs(LogDateTime)
GO
-- check performance with index and without cache

CHECKPOINT; DBCC DROPCLEANBUFFERS; -- Empty the SQL Server cache
GO

SELECT * FROM Logs WHERE LogDateTime BETWEEN  DATEADD(dd,-3,GETDATE()) AND  DATEADD(dd,-1,GETDATE()) -- select two days or 2/5 of the tabe rows
GO

-- Full-text index 

-- Check performance before
CHECKPOINT; DBCC DROPCLEANBUFFERS; -- Empty the SQL Server cache
GO

SELECT LogText FROM Logs
WHERE LogText LIKE '%Day%'
GO

-- Create Index
CREATE FULLTEXT CATALOG ft AS DEFAULT
CREATE FULLTEXT INDEX ON Logs(LogText)
KEY INDEX PK_LogId
GO

-- Check performance after
CHECKPOINT; DBCC DROPCLEANBUFFERS; -- Empty the SQL Server cache
GO

SELECT LogText FROM Logs
WHERE CONTAINS(LogText, 'Day')