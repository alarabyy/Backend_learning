/*
Built-in Functions
---------------------
Scalar
Group Aggrigate

GROUP BY
HAVING
Sub Queries:
	Self-Containted
	Co-Related
Table Expressions:
-----------------
VIEWS
TVF
Derived Table
CTE


PIVOT & UnPIVOT
SET Operators:
	UNION
	UNION-ALL
	INTERCT
	EXCEPT

Stored Procedure

*/

/*
VIEWS: 
	-Database Object = Saved nto Database
	-Security Layer
	-Need developer or Administrator Permission
Syntax
CREATE VIEW ViewName
AS
	SELECT STATEMENT
*/
Use Northwind;
GO
CREATE VIEW MyView
AS
	SELECT EmployeeID As Code,FirstName+' '+LastName AS SalesPerosn,
		CAST(HireDate As DATE)As Hire
	From Employees

Go
--SELECT FROM VIEW
Select * From MyView
GO
---------ExAMPLE 2
CREATE VIEW SalesReport
AS
	SELECT OD.OrderID,Companyname,FirstName,
	Month(OrderDate) As [MOnth],
		SUM(UnitPrice*Quantity) AS Total -- MUST USE Alias
	FROM Orders As O JOIN Customers As C ON C.CustomerID=O.CustomerID
		JOIN Employees AS E ON E.EmployeeID=O.EmployeeID
		JOIN [Order Details] As OD ON O.OrderID=OD.OrderID
	Where Year(OrderDate)=1997
	GROUP BY OD.OrderID,Companyname,FirstName,Month(OrderDate)
GO
-----------
SELECT * FROM SalesReport
GO
------------------------------USE TVF
/*
Also Caled Pramterized View
-Need developer or Administrator Permission
SYNTAX:
	CREATE FUNCTiON FunctonName (@par type)
	RETURNs TABLES
	AS
		RETURN(Select Statement)
*/
CREATE Function AnnualReport(@year int)
RETURNS Table
AS
	RETURN (
			SELECT OD.OrderID,Companyname,FirstName,
			Month(OrderDate) As [MOnth],
				SUM(UnitPrice*Quantity) AS Total -- MUST USE Alias
			FROM Orders As O JOIN Customers As C ON C.CustomerID=O.CustomerID
				JOIN Employees AS E ON E.EmployeeID=O.EmployeeID
				JOIN [Order Details] As OD ON O.OrderID=OD.OrderID
	Where Year(OrderDate)=@year
	GROUP BY OD.OrderID,Companyname,FirstName,Month(OrderDate)
			)
Go
Select * From AnnualReport(1998)
Select * From AnnualReport(1996)

--Derived table -- subquery from

SELECT SUM(Total),Month,Firstname
FROM (SELECT OD.OrderID,Companyname,FirstName,
		Month(OrderDate) As [MOnth],
		SUM(UnitPrice*Quantity) AS Total -- MUST USE Alias
		FROM Orders As O JOIN Customers As C ON C.CustomerID=O.CustomerID
		JOIN Employees AS E ON E.EmployeeID=O.EmployeeID
		JOIN [Order Details] As OD ON O.OrderID=OD.OrderID
		Where Year(OrderDate)=1997
		GROUP BY OD.OrderID,Companyname,FirstName,Month(OrderDate)) AS Tb
GROUP BY Month,Firstname
GO
--CTE COMMON Table Exression
With MyCTE
AS
(SELECT OD.OrderID,Companyname,FirstName,
		Month(OrderDate) As [MOnth],
		SUM(UnitPrice*Quantity) AS Total -- MUST USE Alias
		FROM Orders As O JOIN Customers As C ON C.CustomerID=O.CustomerID
		JOIN Employees AS E ON E.EmployeeID=O.EmployeeID
		JOIN [Order Details] As OD ON O.OrderID=OD.OrderID
		Where Year(OrderDate)=1997
		GROUP BY OD.OrderID,Companyname,FirstName,Month(OrderDate))
Select *From MyCTE
Go
-----------------------------------------------
--SET OPERATORS
/*
UNION
UNION ALL
EXCEPT
INTERSCT

SETS MUST Have:
--------------
Same Number Of Column
Similar DatTypes
Same Column Orders
Column Name from First Select 

*/
Select * From AnnualReport (1997)
UNION
Select * 
From AnnualReport (1998) 

----------
SELECT FIRSTName As Names,Country As Countries FROM Employees
UNION
SELECT Companyname,COuntry   From Customers
UNION
Select CompanyName,Country From Suppliers
/*
SYNTAX
CREATE PROC | PROCEDURE Name 
AS
	DML - SELECT , INSERT , UPDATE, DELETE
	DDL - CREATE , ULTER , DROP
	DCL - GRANT , DENY, REVOKE
	IF STATEMENT
	Varibles
	Function
Go
EXECUTE ProcedureName
EXEC PROCEDURENAME
*/
Go
CREATE PROCEDURE Sp_DoActions
@username Nvarchar(20),@email Nvarchar(50)
AS
	BEGIN
			--DO STEPS
			
			CREATE TABLE USERS(UserID INT Identity Primary Key,
					UserName Nvarchar(20),EMail NvarChar(50))
			INSERT INTO USERS Values(@username,@email) 
			
			Select UserID As Code, UserName As Name, EMail As Mail
			From Users
	END

Select * From Sys.Tables Where Name='USERS'
Go
Exec Sp_DoActions 'Mohamed','Mohmed@mm.com'

Exec Sp_DoActions 'Ahmed','Ahmed@mm.com'

GO
DROP Table Users
GO
ALTER PROCEDURE Sp_DoActions
@username Nvarchar(20),@email Nvarchar(50)
AS
	BEGIN
			--DO STEPS
			IF NOT EXISTS (Select * From Sys.Tables Where Name='USERS')
			CREATE TABLE USERS(UserID INT Identity Primary Key,
					UserName Nvarchar(20),EMail NvarChar(50))

			INSERT INTO USERS Values(@username,@email) 
			
			Select UserID As Code, UserName As Name, EMail As Mail
			From Users
	END
Exec Sp_DoActions 'Mohamed','Mohmed@mm.com'

Exec Sp_DoActions 'Ahmed','Ahmed@mm.com'

GO
Declare @x INT =10
SELECT @X
GO

CREATE PROC SP_RunSQL
@table Nvarchar(200),@column Nvarchar(200),@where Nvarchar(20)
AS
	Declare @select NvarChar(1000) ='Select ' +@Column +' From '+@table +' Where ' +@where
	Exec Sp_ExecuteSQL @select
Go

EXECUTE SP_RunSQL 'EMployees','*','1=1'
EXECUTE SP_RunSQL 'PRODUCTS','ProductID,ProductName,UnitPrice','UnitsinStock>50'
EXECUTE SP_RunSQL 'PRODUCTS','ProductID,ProductName,UnitPrice','Productname =''Chai''  '
EXECUTE SP_RunSQL 'PRODUCTS','ProductID,ProductName,UnitPrice','ProductName Like N''C%''' --For review



