USE [Company]
GO
SELECT e.FirstName + ' ' + e.LastName as Name, e.YearSalary as Salary FROM Employees e
WHERE e.YearSalary BETWEEN 100000 and 150000
ORDER BY e.YearSalary ASC