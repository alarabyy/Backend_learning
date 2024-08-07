
/*			  ================================
             |     Task Quering T-SQL 2019    |
=================================================================
1)Simple Select
================
	A- Selet All  [Employees] Data With Employee FirstName Start with (A)
	B- Select All [Orders] Rows in the Second Quarter in 1997 --> from 1-April to 30-June
	C- Select ALL [Order details] with Quantity Between 100 And 200
	D- Select All Customers Have Fax Is Null

=================================================================
2)Use Distinct-Top -Case - Functions | 
=====================================

	A- Select DISTINCT [Country] Only From Customers
	B- Select highest 5  [UnitPrice] from Products
	C- Select Highest 10% Order [Quantity] From Order Details
	D- Use (With ties)  with Task B & C
	--------------------------------------
	E-Use Searched Case Expression To Handle This
		Select ProductID,Name,UnitPrice,
		SalesTAX_Value (10% Then  when Price <50)
					   (12% Then  when Price <100)
					   (14% Then  when Price <150)
					   ( Else 15%				 )
=================================================================
3) Slecting from Multiple Tables [ Use Join ]
=============================================|

	A- Select (ProductID,Productname,CategoryName,Description)
		From Appropriate DataSourses
	---------------------------
	B- Select OrderID,Customers.Companyname,Employees.FirstName,OrderDate
		From Appropriate DataSourses
	---------------------------
	C- Select OrderID,
			  CustomerName,
			  Employee Full Name,
			  Order Total (Calculated),
			  OrderDate,
			  Year(Orderdate)
		From Appropriate Tables
	
=================================================================
Using DML:
--------------
please Run the following code before using Task
*/
Create Database DMLDemo
Go
Use DMLDemo;
Go
Create Table Products (
			ProductID INT Identity(100,1) Constraint Pk_Pro Primary Key,
			ProductName Nvarchar(50) Not NULL,
			UnitPrice Decimal(7,2) NOT Null,
			Stock Int
						)
/*
TASK:
----------
	A) Please Manually  Insert the follwoing Rows into Products Table
		ID		Name	Price	Stock
		100		Coffee	150		500
		101		Tea		50		1000
		103		Sugar	25		1400
	B) Select appropriate Columns from Northwind.DBO.Products Where UnitPrice >50
		And Insert all into DMLDemo.DBO.Products
		NOTE: Skip  ProductID From Insert Statement
	C) Update  All Products price --> Increasing then by 20%
	D) Delete All Products With Stock =0

*/

=================================================================
=================================================================
=================================================================
--1=
=================================================================
SELECT *
FROM Employees
WHERE FirstName LIKE 'A%';
=================================================================
SELECT *
FROM Orders
WHERE OrderDate BETWEEN '1997-04-01' AND '1997-06-30';
=================================================================
SELECT *
FROM OrderDetails
WHERE Quantity BETWEEN 100 AND 200;
=================================================================
SELECT *
FROM Customers
WHERE Fax IS NULL;
=================================================================
=================================================================
=================================================================
--2=
=================================================================
SELECT DISTINCT Country
FROM Customers;
=================================================================
SELECT TOP 5 UnitPrice
FROM Products
ORDER BY UnitPrice DESC;
=================================================================
SELECT TOP 10 PERCENT Quantity
FROM OrderDetails
ORDER BY Quantity DESC;
=================================================================
SELECT TOP 5 WITH TIES UnitPrice
FROM Products
ORDER BY UnitPrice DESC;
=================================================================
SELECT TOP 10 PERCENT WITH TIES Quantity
FROM OrderDetails
ORDER BY Quantity DESC;
=================================================================
SELECT 
    ProductID,
    Name,
    UnitPrice,
    CASE 
        WHEN UnitPrice < 50 THEN UnitPrice * 0.10
        WHEN UnitPrice < 100 THEN UnitPrice * 0.12
        WHEN UnitPrice < 150 THEN UnitPrice * 0.14
        ELSE UnitPrice * 0.15
    END AS SalesTAX_Value
FROM Products;
=================================================================
=================================================================
=================================================================
--3=
=================================================================
SELECT 
    p.ProductID, 
    p.ProductName, 
    c.CategoryName, 
    c.Description
FROM 
    Products p
JOIN 
    Categories c ON p.CategoryID = c.CategoryID;
=================================================================
SELECT 
    o.OrderID, 
    c.CompanyName, 
    e.FirstName, 
    o.OrderDate
FROM 
    Orders o
JOIN 
    Customers c ON o.CustomerID = c.CustomerID
JOIN 
    Employees e ON o.EmployeeID = e.EmployeeID;
=================================================================
SELECT 
    o.OrderID, 
    c.CompanyName AS CustomerName,
    CONCAT(e.FirstName, ' ', e.LastName) AS EmployeeFullName,
    SUM(od.UnitPrice * od.Quantity) AS OrderTotal,
    o.OrderDate,
    YEAR(o.OrderDate) AS OrderYear
FROM 
    Orders o
JOIN 
    Customers c ON o.CustomerID = c.CustomerID
JOIN 
    Employees e ON o.EmployeeID = e.EmployeeID
JOIN 
    OrderDetails od ON o.OrderID = od.OrderID
GROUP BY 
    o.OrderID, 
    c.CompanyName, 
    e.FirstName, 
    e.LastName, 
    o.OrderDate;

=================================================================
=================================================================
=================================================================
--4=
-- Step 1: Create Database and Table
CREATE DATABASE DMLDemo;
GO

USE DMLDemo;
GO

CREATE TABLE Products (
    ProductID INT IDENTITY(100,1) CONSTRAINT PK_Pro PRIMARY KEY,
    ProductName NVARCHAR(50) NOT NULL,
    UnitPrice DECIMAL(7,2) NOT NULL,
    Stock INT
);

-- Task A: Insert Rows into Products Table
INSERT INTO Products (ProductName, UnitPrice, Stock) VALUES ('Coffee', 150, 500);
INSERT INTO Products (ProductName, UnitPrice, Stock) VALUES ('Tea', 50, 1000);
INSERT INTO Products (ProductName, UnitPrice, Stock) VALUES ('Sugar', 25, 1400);

-- Task B: Select and Insert from Northwind.DBO.Products
USE Northwind;
GO

INSERT INTO DMLDemo.DBO.Products (ProductName, UnitPrice, Stock)
SELECT ProductName, UnitPrice, Stock
FROM Northwind.DBO.Products
WHERE UnitPrice > 50;

-- Task C: Update All Products Price by Increasing Them by 20%
USE DMLDemo;
GO

UPDATE Products
SET UnitPrice = UnitPrice * 1.20;

-- Task D: Delete All Products With Stock = 0
DELETE FROM Products
WHERE Stock = 0;

=================================================================
