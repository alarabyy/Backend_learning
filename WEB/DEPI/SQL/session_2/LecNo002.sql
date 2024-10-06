/*
T-SQL Statements
----------------
DML: SELECT	INSERT	UPDATE	DELETE -->user
DDL: CREATE	ALTER	DROP --> Database Developer
DCL: Allow Deny			--> Database Administrator

T-SQL Elements:
--------------
- Predicates
- Operators
- Functions
- Expressions
- Batch Seprator
- Control of Flow
		IF
		While
		Begin	END
		Transaction
		Error Handling
-Comments
-variables
SELECT Statement:
-----------------
SELECT
FROM 
WHERE
Group By
HAVING
ORDER BY
*/
Use Northwind;
Go
Select * From Employees
Select * from Products
Go
Select *
From Products

Select ProductID AS Code,ProductName,
			UnitPrice AS Price,
			UnitsinStock As Stock
From Products
Where UnitsInStock<20 -- Can NOT Use Alias
Order By Stock
