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