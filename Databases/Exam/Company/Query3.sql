USE [Company]
GO
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