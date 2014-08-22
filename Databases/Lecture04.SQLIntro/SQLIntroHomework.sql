use [TelerikAcademy]

------------------------------------------------------------------------------------------
-- Task 4. Write a SQL query to find all information about all departments				--
--(use "TelerikAcademy" database).														--
------------------------------------------------------------------------------------------

SELECT * from Departments

------------------------------------------------------------------------------------------
-- Task 5. Write a SQL query to find all department names.								--
------------------------------------------------------------------------------------------

SELECT Name from Departments

------------------------------------------------------------------------------------------
-- Task 6. Write a SQL query to find the salary of each employee.						--
------------------------------------------------------------------------------------------

SELECT EmployeeID, FirstName, MiddleName, LastName,Salary from Employees

------------------------------------------------------------------------------------------
-- Task 7. Write a SQL to find the full name of each employee.							--
------------------------------------------------------------------------------------------

SELECT EmployeeID, FirstName + ' ' + ISNULL(MiddleName,'') + ' ' + LastName as FullName from Employees

-- Fixed unnecessery interval when middle name is missing

SELECT EmployeeID, FirstName + ' ' + LastName as FullName from Employees
WHERE MiddleName IS NULL
UNION
SELECT EmployeeID, FirstName + ' ' + MiddleName + ' ' + LastName as FullName from Employees
WHERE MiddleName IS NOT NULL

-- Fixed with ISNULL statment change

SELECT EmployeeID, FirstName + ISNULL(' '+MiddleName,'') + ' ' + LastName as FullName from Employees

------------------------------------------------------------------------------------------
-- Task 8. Write a SQL query to find the email addresses of each employee				--
-- (by his first and last name). Consider that the mail domain is telerik.com.			--
-- Emails should look like “John.Doe@telerik.com". The produced column should be		--
-- named "Full Email Addresses".														--
------------------------------------------------------------------------------------------

SELECT EmployeeID,FirstName+'.'+LastName+'@telerik.com' as FullEmailAddresses from Employees

------------------------------------------------------------------------------------------
-- Task 9. Write a SQL query to find all different employee salaries.					--
------------------------------------------------------------------------------------------

SELECT DISTINCT Salary from Employees

------------------------------------------------------------------------------------------
-- Task 10. Write a SQL query to find all information about the employees whose			--
-- job title is “Sales Representative“.													--
------------------------------------------------------------------------------------------

SELECT * from Employees
WHERE JobTitle = 'Sales Representative'

------------------------------------------------------------------------------------------
-- Task 11. Write a SQL query to find the names of all employees whose first name		--
-- starts with "SA".																	--
------------------------------------------------------------------------------------------

SELECT EmployeeID, FirstName, LastName, MiddleName from Employees
WHERE FirstName LIKE 'SA%'


------------------------------------------------------------------------------------------
-- Task 12. Write a SQL query to find the names of all employees whose last name		--
-- contains "ei".																		--
------------------------------------------------------------------------------------------

SELECT EmployeeID, FirstName, LastName, MiddleName from Employees
WHERE LastName like '%ei%'


------------------------------------------------------------------------------------------
-- Task 13. Write a SQL query to find the salary of all employees whose salary			--
-- is in the range [20000…30000].														--
------------------------------------------------------------------------------------------

SELECT EmployeeID, FirstName, LastName, MiddleName, Salary from Employees
WHERE Salary BETWEEN 20000 AND 30000
ORDER BY Salary ASC 

------------------------------------------------------------------------------------------
-- Task 14. Write a SQL query to find the names of all employees whose salary is		--
-- 25000, 14000, 12500 or 23600.														--
------------------------------------------------------------------------------------------

SELECT EmployeeID, FirstName, LastName, MiddleName, Salary from Employees
WHERE Salary in (25000, 14000, 12500, 23600)
ORDER BY Salary ASC 

------------------------------------------------------------------------------------------
-- Task 15. Write a SQL query to find all employees that do not have manager.			--
------------------------------------------------------------------------------------------

SELECT * from Employees
WHERE ManagerID IS NULL

------------------------------------------------------------------------------------------
-- Task 16. Write a SQL query to find all employees that have salary more than 50000.	--
-- Order them in decreasing order by salary.											--
------------------------------------------------------------------------------------------

SELECT EmployeeID, FirstName, LastName, MiddleName, Salary from Employees
WHERE Salary > 50000
ORDER BY Salary DESC

------------------------------------------------------------------------------------------
-- Task 17. Write a SQL query to find the top 5 best paid employees.					--
------------------------------------------------------------------------------------------

SELECT TOP 5 EmployeeID, FirstName, LastName, MiddleName, Salary from Employees
ORDER BY Salary DESC

------------------------------------------------------------------------------------------
-- Task 18. Write a SQL query to find all employees along with their address.			-- 
-- Use inner join with ON clause.														--
------------------------------------------------------------------------------------------

SELECT e.EmployeeID, e.FirstName, e.LastName, e.MiddleName, a.AddressText
FROM Employees e INNER JOIN Addresses a on e.AddressID = a.AddressID 

------------------------------------------------------------------------------------------
-- Task 19. Write a SQL query to find all employees and their address. 
-- Use equijoins (conditions in the WHERE clause).										--
------------------------------------------------------------------------------------------

SELECT e.EmployeeID, e.FirstName, e.LastName, e.MiddleName, a.AddressText
FROM Employees e, Addresses a
WHERE e.AddressID = a.AddressID

------------------------------------------------------------------------------------------
-- Task 20. Write a SQL query to find all employees along with their manager.			--
------------------------------------------------------------------------------------------

SELECT e.EmployeeID, e.FirstName + ' '+ e.LastName as EmployeeName,
m.EmployeeID as ManagerID, m.FirstName + ' ' + m.LastName as ManagerName
FROM Employees e INNER JOIN Employees m ON e.ManagerID = m.EmployeeID

------------------------------------------------------------------------------------------
-- Task 21. Write a SQL query to find all employees, along with their manager			--
-- and their address. Join the 3 tables: Employees e, Employees m and Addresses a.		--
------------------------------------------------------------------------------------------

SELECT e.EmployeeID, e.FirstName + ' '+ e.LastName as EmployeeName, a.AddressText as EmployeeAddress,
m.EmployeeID as ManagerID, m.FirstName + ' ' + m.LastName as ManagerName
FROM Employees e INNER JOIN Employees m ON e.ManagerID = m.EmployeeID
INNER JOIN Addresses a on e.AddressID = a.AddressID


------------------------------------------------------------------------------------------
-- Task 22. Write a SQL query to find all departments and all town names				--
-- as a single list. Use UNION.															--
------------------------------------------------------------------------------------------

SELECT Name from Departments
UNION
SELECT Name from Towns

------------------------------------------------------------------------------------------
-- Task 23. Write a SQL query to find all the employees and the manager for each of		--
-- them along with the employees that do not have manager. Use right outer join.		--
-- Rewrite the query to use left outer join.											--
------------------------------------------------------------------------------------------

-- RIGHT OUTER JOIN
SELECT e.EmployeeID, e.FirstName + ' '+ e.LastName as EmployeeName,
m.EmployeeID as ManagerID, m.FirstName + ' ' + m.LastName as ManagerName
FROM Employees m RIGHT OUTER JOIN Employees e ON e.ManagerID = m.EmployeeID

-- LEFT OUTER JOIN

SELECT e.EmployeeID, e.FirstName + ' '+ e.LastName as EmployeeName,
m.EmployeeID as ManagerID, m.FirstName + ' ' + m.LastName as ManagerName
FROM Employees e LEFT OUTER JOIN Employees m ON e.ManagerID = m.EmployeeID

------------------------------------------------------------------------------------------
-- Task 24. Write a SQL query to find the names of all employees from the departments	--
-- "Sales" and "Finance" whose hire year is between 1995 and 2005.						--
------------------------------------------------------------------------------------------

SELECT e.EmployeeID, e.FirstName + ' '+ e.LastName as EmployeeName, YEAR(e.HireDate) as HireYear, d.Name
FROM Employees e INNER JOIN Departments d ON e.DepartmentID = d.DepartmentID
WHERE d.Name in ('Sales','Finance') 
AND YEAR(e.HireDate) BETWEEN 1995 AND 2005
ORDER BY YEAR(e.HireDate)