USE Northwind;
Go
/*
WORKS WITH : SELECT	| HAVING	| ORDER BY
----------IGNORE NULL Values
SUM()
MAX()
MIN
AVG()
COUNT()
----------Does NOT Ignore NULL
COUNT(*)
*/
SELECT SUM(Quantity),MAX(UnitPrice),Min(UnitPrice),AVG(UnitPrice),Count(ProductID)
From [Order Details]
--MAX & MIN With DateTime Values
SELECT MAX(OrderDate) As Newest,MIN(OrderDate) As Latest
From Orders
	Select OrderDate From Orders Where OrderDate IS NULL

---USE AGGRIGATE WITH SCALAR
SELECT Month(OrderDate) From Orders
SELECT Count(Month(OrderDate))
FROM Orders

SELECT MAX(Year(OrderDate))
From Orders
---USE AGGRIGATE WITH DISTINCT

Select Count(CustomerID) From Orders
SELECT COUNT(CustomerID),COUNT(DISTINCT CustomerID),Count(*) As CountALL
From Orders
GO
--INSERT NULL Orders
SET Identity_Insert Orders ON
INSERT INTO Orders (OrderID) Values (12000),(12001),(12002)
SET Identity_Insert Orders OFF
Select CustomerID,OrderDate From Orders Where OrderDate IS NULL

GO
----------Now Run Query Agian
SELECT COUNT(CustomerID)AS[Ignore Null],
		COUNT(ISNULL(CustomerID,''))AS[Handle Null]
	,COUNT(DISTINCT CustomerID) [DISTINCT],
	Count(*) AS[Work With Null]
From Orders

SELECT COUNT(ShipCountry),COUNT(DISTINCT ShipCountry)
FROM Orders
GO

---Handle NULL to Avoid Wrong Values
--TASK:
	
	CREATE TABLE USERS(UserID INT IDENTITY Primary Key,UserName Nvarchar(10),LoginTimes INT)
	INSERT INTO USERS Values ('Ahmed',10),('Mohamed',Null),('Sayed',20),('Amir',30)
	SELECT * From Users
----------HANDLE NULL	
	SELECT AVG(LoginTimes) AS[Without Handle Null],
		AVG(ISNUll(LoginTimes,0)) AS [With Null Handle]
	FROM USERS
/*
=============GROUP BY & HAVING BY CLauses=========
*/
Select ProductID,SUM(UnitPrice*Quantity) As Total
From [Order Details]
---Note:
--Column ProductID' is invalid in the select list because it is not contained in either an aggregate function or the GROUP BY clause.
-------------CREATE Products Groups
Select ProductID,SUM(UnitPrice*Quantity) As Total,SUM(Quantity) As TotalQTY
From [Order Details]
GROUP BY ProductID
Order By ProductID

SELECT  ProductName,Year(OrderDate) As OrderYear,
		SUM(OD.UnitPrice*Quantity) As Total,
		AVG(OD.UnitPrice) As PriceAVG,
		Max(Quantity) As Quantity
FROM [Order Details] AS OD 
		INNER JOIN Orders AS O ON O.OrderID=OD.OrderID
		INNER JOIN Products As P ON P.ProductID=OD.ProductID
		----Where Clause Will Filter Rows before grouping
GROUP BY ProductName,Year(OrderDate)
HAVING SUM(OD.UnitPrice*Quantity)>50000 --GROUP Filter
Order By Total Desc
------------------------------

SELECT  ProductName,Year(OrderDate) As OrderYear,
		SUM(OD.UnitPrice*Quantity) As Total,
		AVG(OD.UnitPrice) As PriceAVG,
		Max(Quantity) As Quantity
FROM [Order Details] AS OD 
		INNER JOIN Orders AS O ON O.OrderID=OD.OrderID
		INNER JOIN Products As P ON P.ProductID=OD.ProductID
Where ProductName Like N'%S%'
GROUP BY ProductName,Year(OrderDate)
HAVING SUM(OD.UnitPrice*Quantity)>5000 --GROUP Filter
Go
SELECT  CONCAT(FirstName,' ',LastName) As SalesPerosn,
		Year(OrderDate) As [Year],Month(OrderDate) as [MOnth],
		SUM(OD.UnitPrice*Quantity) As Total,
		AVG(OD.UnitPrice) As PriceAVG,
		Max(Quantity) As Quantity
From [Order Details] As OD 
		JOIN Orders As O ON O.OrderID=OD.OrderID
		JOIN Employees As E ON E.EmployeeID=O.EmployeeID
WHERE FirstName Like 'a%'
--Where AVG(UnitPrice)>30 --> Can NOT use Aggrigate function with where Clause
GROUP BY CONCAT(FirstName,' ',LastName),Year(OrderDate),Month(OrderDate)
HAVING AVG(UnitPrice)>30

Select Max(Orderdate) from Orders

Select * From Orders
Where OrderDate='5/6/1998'
--	Where OrderDate=Max(OrderDate)
/*
===============================================================================
					Using SubQueries
===============================================================================
 1) Writing Basic Subqueries
 -each query that you have written has been a single self-contained statement.
 -SQL Server also provides the ability to nest one query within another—in other words, to form subqueries. 
 -In a subquery, the results of 
the inner query (subquery) are returned to the outer query. 
 -A subquery is a query that is nested inside a SELECT, INSERT, UPDATE, 
   or DELETE statement, or inside another subquery that can be used 
   anywhere an expression is allowed ===>( Up to 23 Nested Queries).
  
2) Why to Use Subqueries?
   - To break down a complex query into a series of logical steps
   - To answer a query that relies on the results of another query

3) Why to Use Joins Rather Than Subqueries?
   - SQL Server executes joins faster than subqueries


 -- Subqueries can be (self-contained)  or (correlated) 
       1-Self-contained subqueries have no dependency on outer query
       2-Correlated subqueries depend on values from outer query
*/
--========================{EXAMPLES}===========================

--1)SELF contained query
USE Northwind;
GO
-- inner with SELECT clause // compare between prices in products & orders
SELECT OrderID,UnitPrice,
	UnitPrice-(select AVG(unitprice)  
	from Products )as diff_price
FROM  [Order Details]
Select AVG(UnitPrice) from [Order Details]
Select ProductName,UnitPrice,
	UnitPrice-(Select AVG(UnitPrice) from [Order Details])
From Products
--- SELF Contained with FROM clause ALSO Called Derived Table


SELECT ProductID,ProductName,Tax,UnitPrice
FROM (	select ProductID,ProductName,unitprice,UnitPrice*.1 as tax 
		from Products) as mypro;
--Example 002
SELECT Cat,SUM(Total),Max(Price),Sum(Qty)
FROM
		(Select CategoryName Cat,
			OD.UnitPrice*Quantity As Total,
			OD.UnitPrice As Price
			,Quantity As Qty
		From Categories as C JOIN Products As P ON P.CategoryID=C.CategoryID
		JOIN [Order Details] As OD ON OD.ProductID=P.ProductID) As MyTb
Group By Cat
--- inner with Where clause
select * from [order details]
select * from orders

select MAX(orderdate) from orders
Select *
From Orders
WHERE OrderDate=(Select MAX(Orderdate) from Orders)

-- scalar// (query returns single value)
SELECT OrderId,ProductId,Quantity
FROM [order details]
WHERE OrderID=(select MAX(orderid) from orders) --Because Can not Use Aggigate with Where

---multi-Rows
SELECT CustomerId,OrderID,Year(OrderDate) 
FROM Orders
WHERE CustomerID in ( select  CustomerID 
					  from Customers as cs 
					  where City=N'london') And year(Orderdate) >1997
-------- CoRelated Sub Queruy--------------------
--Inner & Outer Queries Work togther

SELECT OrderID,EmployeeID,OrderDate
FROM orders as o1
WHERE OrderDate=(select MAX(orderdate) from orders as o2 -- till this max all dates
				 where o1.EmployeeID=o2.EmployeeID) -- max date to each emp

SELECT ProductName,UnitPrice, UnitPrice -(
		Select AVG(UnitPrice) from [Order Details] As od Where P.ProductID=Od.ProductID )
From Products As P
Select AVG(UnitPrice) From [Order Details] Where ProductID=1
------using EXISTS/Not Exists KEYWords------

SELECT CustomerID,CompanyName,Country
FROM Customers as C
where EXISTS (select * from orders as o where o.CustomerID=C.CustomerID )

SELECT CustomerID,CompanyName
FROM Customers as C
where NOT EXISTS (select * from orders as o where o.CustomerID=C.CustomerID )
----------NOTE JOIN Here is best Performance
Select DISTINCT CompanyName
From Orders As O RIGHT JOIN Customers As C ON C.CustomerID=O.CustomerID
Where OrderID IS NULL
GO
/*
=========================================================================
		TABLE EXPRESSIONS
		----------------
-Table Expression the means expression Returns Table or Virtual Table
=========================================================================
Type OF Table Expressions:
	1) VIEWS --Developer Or Administrator
	2) Inline-TVF (Table Valued Function) --Developer Or Administrator
	3) Derived Tables
	4) CTE (Common Table Expression)
*/

--(1)Views
--Views are saved queries created in a database by administrators and developers
--Views are defined with a ===> single SELECT statement
--ORDER BY is not permitted in a view definition ===> without the use of TOP, OFFSET/FETCH, or FOR XML
--To sort the output, use ORDER BY in the outer query

--------------CREATING VIEW
/*
SYNTAX:
	CREATE View ViewName
	AS
		(SELECT Statement)
*/
--Example 001
Create VIEW ShowProducts
AS
Select ProductID AS Code,ProductName name,UnitPrice As Price
From Products
Where UnitsInStock>0
Order By UnitPrice
GO
Select * From ShowProducts
GO
CREATE View ShowEmployees
AS
	SELECT Concat(TitleOfCourtesy,FirstName,' ',LastName) As [Full Name],
	Title AS [Job],CAST(GETDATE()-BirthDate AS INT)/365 AS AGE,
	City,Country
	FROM Employees
	-- ORDER BY AGE DESC --> Can Not USe order by Here
GO
--USE VIEW = SELECT From View
SELECT * 
	FROM ShowEmployees  --View name
Order By AGE Desc
GO
--Example 002 --> Use ORDER BY
CREATE View TopTenOrders
AS
	SELECT TOP(10)	OD.OrderID,
					FORMAT(OrderDate,'dd/MM/yyyy') As OrderDate,--NOTE: MUST Use Alias
					ShipCountry,
					UnitPrice*Quantity As Total --NOTE: MUST Use Alias
	FROM Orders AS O INNER JOIN [Order Details] AS OD ON OD.OrderID=O.OrderID
	ORDER BY Total DESC
GO
SELECT * FROM TopTenOrders
GO
/*=====================================================
(2) InLine TVFs (Table Valued Functions)
--=======================
--TVF is a Parameterized View
--TVFs  are named Table Expression that Stored In Database
--TVFs are created by administrators and developers
--Create and name function and optional parameters with CREATE FUNCTION
--Declare return type as TABLE
--Define inline SELECT statement following RETURN
SYNTAX:
	CREATE Function FunctionName (Paramters)
	RETURNS Table
	AS
		RETURN (SELECT Statement)
*/
CREATE FUNCTION My_TVF (@x as Int)
	RETURNS TABLE
AS 
	Return 
	(SELECT OrderID,UnitPrice,Quantity,
		cast(unitprice*quantity as decimal(8,2)) as [total sales]
	 FROM  [Order Details]
	 WHERE OrderID = @x);
go
Select * From My_TVF(10250)
Select * From My_TVF(10255)
Select * From My_TVF(11000)

GO
--Ex 002
CREATE FUNCTION SalesMonthlyReport(@Month INT,@Year INT)
	RETURNS TABLE
	AS
		RETURN(	SELECT ProductName,OD.UnitPrice*Quantity As Total,OrderDate 
				FROM [Order Details] AS OD JOIN Products As P ON P.ProductID=OD.ProductID
				JOIN Orders As O ON O.OrderID=OD.OrderID
				WHERE Month(OrderDate)=@month AND Year(OrderDate)=@year
				)
GO
Select * From SalesMonthlyReport(5,1997)
Select * From SalesMonthlyReport(11,1997)
Go
CREATE Function AnnualReport(@year INT,@month int)
RETURNS Table
AS
	Return(SELECT FirstName,Month(OrderDate) As Months,
		SUM(UnitPrice*Quantity) As Total,
		AVG(Quantity) As QtyAVG,
		Count(OD.OrderID) As NoOfOrders
		From [Order Details] As OD JOIN Orders As O On O.OrderID=OD.OrderID
			JOIN Employees As E ON E.EmployeeID=O.EmployeeID
			Where Year(OrderDate)=@year AND Month(OrderDate)=@month
		GROUP By FirstName,Month(OrderDate))
Go
Select * From AnnualReport(1997,11)
UNION
Select * From AnnualReport(1997,12)

/* ===================================================
derived Table:
----------------------
Not stored in database—represents a virtual relational table
--When processed, unpacked into query against underlying referenced objects
--Allow you to write more modular queries

SYNTAX:
SELECT <column_list>
FROM	(
		  SELECT Statement
		) AS <derived_table_alias>;

--Scope of a derived table is the query in which it is defined

--Notes 
-------
--Derived Tables Must:-
------------------------
1-Have an alias
2-Have names for all columns
3-Have unique names for all columns
4-Not use an ORDER BY clause (without TOP or OFFSET/FETCH)
5-Not be referred to multiple times in the same query
*/
SELECT	OrderYear,count(csid) as CsNo
FROM    (select year(orderdate) as OrderYear, customerid as CsId
		 from Orders) as Oyears
GROUP BY orderyear
HAVING orderyear>=1997

--(4)create a CTE:-
-----------------
--------CTE is a temp Table But with a (Batch scope)
--Define the table expression in a WITH clause
--Assign column aliases (inline or external)
--Pass arguments if desired
--Reference the CTE in the outer query


select * from orders
GO
-------------Run ALL as Single Batch
WITH Ctp_year
AS
	(select year(orderDate) as OrderYear ,customerID from orders)

SELECT orderyear,count(distinct customerid)as CustCount
FROM Ctp_year 
Group By orderyear
GO

/*
====================================================================
--Using Set Operators { UNION - UNION ALL} - {EXCEPT} - {INTERSECT}
====================================================================
*/

--Considrations when using set Operators:
--Each Query Must Have:
--------------------
--* Similar data types
--* Same number of columns 
--* Same column order in select list
--* Can NOT use order By in the input Query

--* NOTE: ((Final Set Have Col Name As First Query col name))
--=============================================
--Using Union & Union All

---------------------------Union is Distinct ===>( Filter Duplicates)---
---------------------------Union ALL ===>( Does NOT Filter Duplicates)---

select country,city from Customers

union --All

select country,city from Employees

-- Wrong Example
/*
select country,customerid,city from Customers
union 
select country,city,EmployeeID from Employees
 */
--==> using Conversion
select customerid,country,city from Customers
union 
select cast(EmployeeID as nvarchar(20)),country,city from Employees
order by City -- order the final set

--==> using CALCULATED Coloumn & Where Clause
Select Firstname+' ' + Lastname as [Full name] from Employees 
	where Title='Sales Representative'
union
Select contactname from Customers 
	where ContactTitle='Sales Representative'

--===> With New Tables
Create table TBL1(id  int);
Create table TBL2(id2 int);

Insert into TBL1 values(1),(2),(10),(20),(NULL);
Insert into TBL2 values(10),(10),(20),(30),(NULL);


Select * From tbl1
UNION                -- All
Select * From tbl2;
--===============================
--Using EXCEPT & INTERSECT
------
/*--EXCEPT returns any distinct values from the left query that are not 
   also found on the right query
-- INTERSECT returns any distinct values that are returned by both 
   the query on the left and right sides of the INTERSECT operand
   -- REMEMBER :
     --1.The number and the order of the columns must be the 
			same in all queries.
     --2.The data types must be compatible.
     --3.The column names of the result set that are returned by EXCEPT or 
         INTERSECT are the same names as those returned by the 
         query on the left side of the operand.*/
Select * From tbl1
EXCEPT
Select * From tbl2;

Select * From tbl1
INTERSECT 
Select * From tbl2;
---------------------
/*
 -- The Difference Between {SET Operators}  and {JOIN} :-
 -----------------------------------------------------
  UNION combines rows. In comparison, JOIN combines columns from different sources. 

        -------------------------------------------------------------------
		|		  ( Joins )              |        ( Set operators )       |
		|		 ===========             |       ===================      |
		-------------------------------------------------------------------
	    | A) Combine multiple tables     |  A) Combine multiple SELECTs   |
		-------------------------------------------------------------------
		| B) Performs a horizontal join  |  B) Performs a vertical  join   |                       
		-------------------------------------------------------------------
*/
----------------Lagest & Lowest At Same Time USE[Derived Table, Top +With Ties, Union]
SELECT *
FROM
(
	(Select TOp(1) With Ties * From [Order Details] Order By UnitPrice DESC) 
UNION 
	(Select TOp(1) With Ties * From [Order Details] Order By UnitPrice )
) AS T

SELECT *
FROM [Order Details]
WHERE 
	UnitPrice=(Select Max(UnitPrice) From [Order Details])
	OR 
	UnitPrice=(Select MIN(UnitPrice) From [Order Details])
