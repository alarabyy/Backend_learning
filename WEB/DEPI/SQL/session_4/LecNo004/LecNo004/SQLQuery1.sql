/*
T-SQL Elemensts:
------------------
1- Predicates (IN, Between ... AND ..., Like ,IS, NOT)
2- Operators:
	>
	>=
	<
	<=
	=
	!=
Simple Select
--------------------
Use Alias
Use Calculation
Use Distinct
Use Case Expression

Filter Rows:
-----------
1- Where Clause
2- Top
3- Offset Fetch

*/
Use Northwind;
GO
Select * From Orders
--1- WHERE
------------Use Where Clause:
/*
Where Col <Boolean Expression> AND Col <Boolean Expression>
*/
---Comparison With Text
Select *
FROM Orders
Where ShipCountry='France'

Select OrderID,ProductID,UnitPrice,Quantity,
	UnitPrice*Quantity AS [Order Total]
From [Order Details]
Where UnitPrice >100
Order By [Order Total] Desc

Select *
From Orders
--Where OrderDate >'12/31/1997' --> Machine Date
Where OrderDate >'19971231' --> Default date String
--USE AND / OR
Select *
FROM Orders
Where ShipCountry='France' AND OrderDate >'1/1/1997'

Select * From Orders
Where EmployeeID >=3 AND EmployeeID<=7
--Use Between --> Works With NUMBERS & DATETIME
Select *
From Orders
Where OrderDate Between '1/1/1997' AND '12/31/1997'
--Where Year(OrderDate)=1997
Select OrderDate,FORMAT(OrderDate,'dd/MMMM/yyyy','ar-EG')
From Orders

Select *
From Orders
Where ShipCountry ='France'
		OR ShipCountry='Brazil' 
		OR ShipCountry='USA'
-------------USE IN(List of Elements)
Select *
From Orders
Where ShipCountry IN('France','Brazil','USA')

Select *
From Orders
Where OrderID IN(11000,10500,10250)
-------------Working With NULL
Select * From Customers
Where Region IS NULL

Select * From Customers
Where Region IS NOT NULL

/*
USE LIKE:
-------------work With Search Pattern
% --> any Number of Character
_ --> Single Character
[,] --> Group OR
[-] --> Group Range
*/

----------------Start With
Select *
From Customers
Where CompanyName Like 'S%'
--------------End With
Select *
From Customers 
Where CompanyName Like '%s'

--------------Contains
Select *
From Customers 
Where CompanyName Like '%m%'

Select *
From Customers 
Where CompanyName Like '[a,c]%'

Select *
From Customers 
Where CompanyName Like '[a-c]%'

Select *
From Customers 
Where CompanyName Like '__a%'

Select *
From Orders
Where OrderID Like '%50'

Select *
From Orders
Where OrderDate Like '%1997%'

----------------------USE TOP:
/*
Top Use Order By to Determine TOP
Syntax
Select TOP(n) <Column List>
From Table
Order By 
Top(n) --> Number of Rows
Top(n) Percent --> n =Percent of total Rows
Top(n) With Ties --> With All possible Results
*/
Select TOP(10) *
From [Order Details]
Order By UnitPrice Desc

Select TOP(10) With Ties *
From [Order Details]
Order By UnitPrice Desc

Select * from [Order Details]
Select TOP(10) PERCENT *
From [Order Details]
Order By UnitPrice Desc

---Use OFFSET  FETCH
/*
WORK WITH ORDER By
*/
Select *
From [Order Details]
Order By UnitPrice Desc
OFFSET 15 Rows Fetch First 10 Rows Only
-----------------------------
Select * From Products
Select * From [Order Details]

Select OrderID,ProductName,[Order Details].UnitPrice,Quantity
From [Order Details],Products
Where [Order Details].ProductID=Products.ProductID