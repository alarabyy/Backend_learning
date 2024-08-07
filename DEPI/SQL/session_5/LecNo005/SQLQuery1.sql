
--USE JOIN
/*
JOIN Work With FROM Clause = Best performane
JOIN TYPE:
	INNER JOIN - JOIN
	OUTER JOIN
		LEFT OUTER JOIN - LEFT JOIN
		RIGHT OUTER JOIN - RIGHT JOIN
		FULL OUTER JOIN - FULL JOIN
	SELF JOIN
	CROSS JOIN

*/
Select OrderID,ProductName,Od.UnitPrice,Quantity
FROM [Order Details] As OD 
	INNER JOIN PRODUCTS AS P ON p.ProductID=OD.ProductID
Where OD.UnitPrice>100

Select * From Orders
Select * from Employees
--USE Inner JOIN
Select OrderID,FirstName+' '+Lastname As [Sales Person],Orderdate,ShipCountry
From Orders As O JOIN Employees AS E ON E.EmployeeID=O.EmployeeID

--Chain Of INNER JOIN
/*
EMployees
Cutomers
Orders
Order Details --> UnitPrice - Quntity
*/
Select OD.OrderID As InvoiceNo,CompanyName As Client,
	FirstName +' '+Lastname As [Sales Person],
	ShipCountry,
	UnitPrice*Quantity As Total
FROM Orders AS O 
	JOIN Customers AS C ON O.CustomerID=C.CustomerID
	JOIN  Employees AS E ON O.EmployeeID=E.EmployeeID
	JOIN [Order Details] AS OD ON OD.OrderID=O.OrderID
-----------USE GROUP BY & Aggrigate Function
Select OD.OrderID As InvoiceNo,CompanyName As Client,
	FirstName +' '+Lastname As [Sales Person],
	ShipCountry,
	SUM(UnitPrice*Quantity) As Total
FROM Orders AS O 
	JOIN Customers AS C ON O.CustomerID=C.CustomerID
	JOIN  Employees AS E ON O.EmployeeID=E.EmployeeID
	JOIN [Order Details] AS OD ON OD.OrderID=O.OrderID
GROUP BY OD.OrderID,CompanyName,FirstName +' '+Lastname,ShipCountry
---JOIN TASk
Create Database JOINTest
GO
Use JOINTest
Go
Create Table Departments (DepartmentID INT Primary Key,
		DepartmentName NvarChar(20))
Create Table Employees (EmployeeID INT Primary Key,Name Nvarchar(50), 
			Salary Decimal(10,2),DepartmentNo INT)
--INSERT SMPLE DATA
INSERT INTO Departments Values(101,'IT'),(102,'HR'),(103,'Sales'),(104,'Finance')

INSERT INTO Employees
		Values (1,'Mohamed',6000,101),
				(2,'Ahmed',7000,101),
				(3,'Sarah',4000,102),
				(4,'Ayman',6500,103),
				(5,'Mai',null,null),
				(6,'Esraa',Null,Null)

Select * From Departments
Select * from Employees
-----------Use INNER JOIN
Select EmployeeID,Name,Salary,DepartmentName
From Employees As E 
INNER JOIN Departments AS D ON D.DepartmentID=E.DepartmentNo


-----------Use LEFT JOIN
Select EmployeeID,Name,Salary,DepartmentName
From Employees As E 
LEFT JOIN Departments AS D ON D.DepartmentID=E.DepartmentNo

-----------Use RIGHT JOIN
Select EmployeeID,Name,Salary,DepartmentName
From Employees As E 
RIGHT JOIN Departments AS D ON D.DepartmentID=E.DepartmentNo

-----------Use FULL JOIN
Select EmployeeID,Name,Salary,DepartmentName
From Employees As E 
FULL JOIN Departments AS D ON D.DepartmentID=E.DepartmentNo

Use Northwind
Select OrderID,CompanyName
From Orders AS O RIGHT JOIN Customers As C ON C.CustomerID =O.CustomerID
Where OrderID IS NULL

-------------SELF JOIN
Select * From Employees
Select EMployeeID,FirstName,ReportsTo
From Employees
---SELF JOIN MUST USE TABLE ALIAS
Select Emp.EmployeeID,Emp.FirstName+' '+Emp.LastName As Employee,
	Emp.Title,
	ISNULL(MGR.FirstName,Emp.Title) As Manager
FROM Employees As EMP 
LEFT JOIN Employees As MGR ON MGR.EmployeeID=EMP.ReportsTo
---------------------------------------------------------------
/*
SQL System DATATYPES:
1-Numeric DataTypes
	Exact Numbers
		TYPE			RANGE		SIZE
		------			-----		-----
		TinyINT			+0-255		1 BYTE
		SmallNT			+- 2^15		2 BYTES
		INT				+- 2^31		4 Bytes
		BigINT			+- 2^63		8 Bytes

		Decimal(s,p) -------> 38 DIGIT 5-17 Bytes
		Numeric(s,p)
			s= Total Number of Digits
			p= Number of digit after decimal point
			Decimal(5,2)------>365.33
			SIZE
				Decimal(1-9) ---> 5 Bytes
				10-19		 ---> 9 Bytes
				20-28		 ---> 13 Bytes
				29-38		 --->17 Bytes
		Ex:
			Decimal(8,1)--> 5 Bytes
			Decimal(20,1)--> 13 Bytes
	Approximate Numbers
		Real 24 digit
		Float 53 digit
2-Character String DataTypes
	Non-Unicode Charchters			Unicode Charcter
	Single Byte Chracters			Multiple Bytes
	--------------------			----------------
	Each Character=1Byte			Each CHaracter=2 Bytes (1-Letter + 1 Unicode)
Fixed With
	CHAR(n)	1-8000					NChar(n) 1-4000
Variable Width
	VarChar(n)	1-8000				NVarChar(n) 1-4000
	Varchar(MAX) 2GB				NVarChar(MAX)
	Text							NText

	NOTE: n Maximum number of Characters
3-DateTime DataTypes
	DATE------------> dd/MM/YYYY
	TIME------------> hh:mm:ss.nnnnnnn 
	SmallDateTime 
	DateTime	1/1/1735------> 31/12/9999  00:00:01 -23:59:59.999
	DateTime2	1/1/0001------> 31/12/9999  00:00:01 -23:59:59.9999999
	DateTimeOffset + GMT
	Date 1/1/0001------> 31/12/9999
	Time 00:00:01 -23:59:59.9999999
4-Binary DataTypes
5- Other
*/