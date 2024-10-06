/*
T-SQL Syntax:
--------------
1-Not A Case Senstive
2- Use Single Quote With String --> 'Text'
3- Use [Name Here] With Naming have Spaces or KeyWord --> Microsoft
	Or Use "Name Here" --> ANSI Standard


T-SQL Elements:
---------------
1- Predicates : IN , Between .. AND .. , Like ,IS ,NOT
2- Operators
	-Arithmetic Operator	+	-	*	/
	-Comparison
		>
		>=
		<
		<=
		=
		!= Not Equal
	-Logical
	-Concatenation	+
	-Assignment		=
3- Functions
4- Expressions
5- Batch Sprator
6- Control Flow
7- Comments
8- Variables
-------------
Select Satatement:
---------------------
User										Server Execution
-----										-----
Select <Column List>						FROM
From   <Object Name>						Where
Where	Rows Filter<Boolean Expression>		Group By
Group By									Having
Having <Group Filter>						Select
Order By									Order By
*/
--Write Simple Select Query:
/*
1- Select All Column 
2- Use Some Column
3- Use Calculation
4- Table | Column Alias
5- Use DISTINCT 
6- Use Expression CASE
Working With Null
--
Filter Rows:
------------
Use Where Clause
Use TOP
Use Offset Fetch
*/
Select * -- Mean All Table Column
From Northwind.dbo.Employees --Qualified Name
GO
Use Northwind;
GO
--Select All Products Data
Select * From Products;
Select * From Customers

--Use Column List
Select ProductID,ProductName,UnitPrice,UnitsInStock
From Products
Select * From [Order Details]

Select OrderID,ProductID,UnitPrice,Quantity
From "Order Details"
--Use Calculation:& Use Column Alias
Select OrderID,ProductID,UnitPrice,Quantity,
		UnitPrice*Quantity AS [Order Total] --Calculation & Alias
From [Order Details]
--Use Concatenation
Select * From Employees

Select EmployeeID,
		TitleOfCourtesy+FirstName+' '+LastName AS "Full Name", --Naming ANSI
		Address+', '+City+', '+Country+'.' AS [Full Address] -- Naming Microsoft
From Employees

/*
USE Column Or Table Alias:
1- ColumnName  Alias --> NOT RECOMMENDED
2- ColumnName AS Alias
3- Alias=ColumnName
*/
Select * From Customers
Select CustomerID, CompanyName ContactName,Country
From Customers

Select CustomerID AS [Client Code],
		CompanyName As Client,
		[Contact Person]=ContactName,
		City Town,
		[Location] =Country
From Customers

Select * From Orders
Select OrderID,OrderDate As [FROM] , --Use Keyword As Alias
			RequiredDate As [To]
From Orders

--Get List Of ShipCountry 
/*
DISTINCT:
-------------
--USE Distinct Keyword return Unique Values
-- All Column After Distinct is Unique TOGTHER
-- Select DICTINCT <ColumnList>
From ...

*/
SELECT DISTINCT ShipCountry
From Orders
Order By ShipCountry 

Select DISTINCT ShipCity,ShipCountry
From Orders

Select FirstName,Lastname,FirstName+' '+LastName As Long
From Employees
Where FirstName+' '+LastName='Andrew Fuller'


--Use Expression CASE
/*
CASE EXPRESSION  : Work With Select & DML
1- Simple Case -Work With FACTS
	Select Col1,Col2,
	CASE ColumnName
	When value  Then ... value|ColumnName | Expression
	When Value2 Then ... 
	Else ...
	END As Alias
2- Searched Case --Works With Comparison
SELECT Col1,Col2,
	CASE 
	When Col>.. Then ...
	When Col>.. Then ...
	Else ...
	END
*/
Select CustomerID,Companyname,ContactName,Country
From Customers

Select CustomerID,Companyname,ContactName,Country,
CASE Country
WHen 'UK'  Then 'United Kingdom'
When 'USA' Then 'United States'
Else Country
END As Country
From Customers
--Ex002
Select * From Products
Select ProductID,ProductName,CategoryID,
CASE CategoryID
	When 1  Then 'Drinks'
	When 2  Then 'Food'
	Else 'Other'
	End As category
From Products
----------USE Searched Case

Select * From Products
Select ProductID,ProductName,UnitPrice,UnitsInStock,
CASE
WHen UnitsinStock <20 Then 'Please Re-Order'
When UnitsInStock <30 Then 'Low Stock'
When UnitsInStock <50 Then 'Normal Stock'
When UnitsInStock <100 Then 'Good Stock'
Else 'Excellent Stock'
END AS [Stock Rank]
From Products
Order By [Stock Rank] Desc

------TASK:
/*
Please Select ProductName,UnitPrice From Products
AND RANK PRICE As Following:
If Price is Less than 20 then Low Price
If Price is Less Than 50 then Normal Price
Otherwise High Price
*/

--FILTER ROWS:
-----------------
/*
Where  
Top (n)
Offset Fetch
*/
----------USE Where
/*
Where Col Boolean Expression | Predicates
*/
--Use Comparison
--Number
Select ProductID,ProductName,UnitPrice
From Products
Where UnitPrice>90
--Text --> Use = | !=
Select FirstName,lastName
From Employees
Where LastName='King' -- Employee With Last name is KING

Select Firstname,Lastname
From Employees
Where Lastname!='King' -- All Employees Except King

--With Dates
Select *
From Orders
Where OrderDate >'12/31/1997' --After NOTE : write Date As your Machine

Select *
From Orders
Where OrderDate >'19971231' --Use Default Date String 'YYYYMMDD'

Select *
From Orders
Where OrderDate >='19970101' AND OrderDate <='19971231'

-- Use Between --> Works With NUMBERS & Dates & Time --Can Not work With Text
Select *
From Orders
Where OrderDate Between '1/1/1997' AND '12/31/1997'

--USE OR - IN
Select *
From Orders
Where (ShipCountry='Italy'
		OR ShipCountry='Germany' 
		OR ShipCountry='France')
		AND OrderDate >'1/1/1998'


Select *
From Orders
Where ShipCountry IN('Germany','Italy','France') 
			AND OrderDate >'1/1/1998'
