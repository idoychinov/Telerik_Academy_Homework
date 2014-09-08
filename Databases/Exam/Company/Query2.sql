USE [Company]
GO
SELECT d.Id as DepartmentId, d.Name as DepartmentName, COUNT (e.Id) as NumberOfEmployees FROM Employees e
INNER JOIN Departments d on e.DepartmentId = d.Id
GROUP BY d.Id, d.Name
ORDER BY COUNT(e.Id) DESC