USE [Company]
GO

CREATE PROC dbo.ups_CreateCacheTable
AS
	CREATE TABLE [dbo].[ReportCashe]
	(
	[EmployeeId] [int] NOT NULL,
	[ProjectId] [int] NOT NULL,
	[EmployeeName] [nvarchar](41) NOT NULL,
	[ProjectName] [nvarchar](50) NOT NULL,
	[DepartmentName] [nvarchar](50) NOT NULL,
	[ProjectStartDate] [date] NOT NULL,
	[ProjectEndDate] [date] NOT NULL,
	[NumberOfReports] [int] NOT NULL
	)
GO

EXEC dbo.ups_CreateCacheTable
GO

CREATE PROC dbo.ups_UpdateReportCashe
AS 
INSERT INTO [dbo].[ReportCashe] 
SELECT g.EmployeeId, g.ProjectId, g.EmployeeName, g.ProjectName, g.DepartmentName,
g.ProjectStartDate, g.ProjectEndDate, COUNT (r.Time) as NumberOfReports FROM 
(SELECT e.Id as EmployeeId, e.FirstName + ' ' + e.LastName as EmployeeName,p.Id as ProjectId, 
p.Name as ProjectName, ep.StartDate as ProjectStartDate, ep.EndDate as ProjectEndDate,  
d.Name as DepartmentName  FROM Employees e
INNER JOIN Departments d on d.Id = e.DepartmentId
INNER JOIN EmployeesProjects ep on ep.EmployeeId = e.Id
INNER JOIN Projects p on ep.ProjectId = p.Id
) g
INNER JOIN Reports r on g.EmployeeId = r.EmployeeId
WHERE r.Time BETWEEN g.ProjectStartDate AND g.ProjectEndDate
GROUP BY g.EmployeeId, g.ProjectId, g.EmployeeName, g.ProjectName, g.DepartmentName,
g.ProjectStartDate, g.ProjectEndDate
ORDER BY g.EmployeeId, g.ProjectId
GO

EXEC dbo.ups_UpdateReportCashe
GO