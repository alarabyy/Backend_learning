/*
-- Module 8) Using Built-In Functions :- 
 -----------------------------------------
   -- Lessons :-
   -------------
          - Writing Queries with Built-In Functions.
		  - Using Conversion Functions.
		  - Using Logical Functions.
		  - Using Functions to Work with NULL.
-----------------------------------------------
-- What is Functions in T-SQL ?
--------------------------------
 - A T-SQL routine that accepts parameters, performs an action, such as a complex calculation,
     and returns the result of that action as a value.
 - Functions hide the steps and the complexity from other code.
 - Function Operate  
                      A)- (Deterministic = return same result)
                      B)- (Non-Deterministic = may return different result each time) 
					  
-- Why We use Functions ? 
--------------------------
   - Functions can Use & Run almost anywhere .
   - To replace a stored procedure . 
   
   -- Functions Types :-
-------------------------
 1)- User-defined Functions :-       "Developing Course"

                             A) Scalar        :- Return a single value.
							 B) Table-Valued  :- Return a table.

 
 2)- Built-in Function :-   
                             A) Scalar    :- Working on a single row To return a single Value.             Working With (Select,Where,Having)
							 B) Aggregate :- Take one or more input To return a single summarizing value.  
							 C) Window    :- Working on sets of rows.                                      
							 D) Rowset    :- Return a virtual table can be used in a T-SQL statement.      
----------------------------------------------------------------------------------------------------------------------------------
--Scalar Function working on single row to returns single Value

/*
Scalar Functions Categories:
----------------------------
1) String Function : 
2) Date Time Functions
3) Math Functions
4) Convertion Functions
5) Logical Function
6) Working With Null

*/
---------String Functions-------[Substring,Left,Right,Len,CharIndex,Replace,Upper,Lower]
/*
	1- Left(String,No Of char) === Get number of Character from Left
	2- Right(string, # Char) === Get number of Character from Right
	3- SubString(string ,Start position, no Of char) == === Get number of Character from starting position
	4- charindex(text,string) === search for a Character in string
	5- Len(string) == String Length
	6- Upper(string) == Capital Letters
	7- Lower(string) == Small Letters
	8- Replace(string,find,replace) 
	9- Trim(String) --> Remove Extra Spaces
	10-Concat (string1,string2) --> Concatenate Text (Ignore Null Values)
*/*/

------CREATE Function Example
 Use Northwind
 Select OrderID,EmployeeID,OrderDate
 From Orders
 --Where OrderDate >='1/1/1997' ANd OrderDate<='12/31/1997'
 Where Year(Orderdate)=1997
GO
Create Function AddNumbers(@first INT,@Second INT)
RETURNS INT --Define Return Type
AS
	Begin
	--Declaring New Variable = Room into Memory
		Declare @Result INT=@first+@Second
		RETURN @Result
	END
GO
	Select AddNumbers(20,30) --'AddNumbers' is not a recognized built-in function name
	Select DBO.AddNumbers(50,88) --MUST USE SCHEMA Before function Name
	Select UnitPrice,Quantity,DBO.AddNumbers(UnitPrice,Quantity)
	From [Order Details]
GO
CREATE Function Concatenat(@f Nvarchar(20),@s Nvarchar(20))
RETURNS Nvarchar(50)
AS
	BEgin
		Return @f+' '+@s
	ENd
GO
Select FirstName,LastName,DBO.Concatenat(FirstName,LastName) As FullName
From Employees
-- Examples================
Use Northwind
Go
Select *
from Customers
-- :D 
select CompanyName ,left(companyname,3) AS[From Left],
					Right(companyname,3) AS[From Right],
					substring(companyname,3,3) AS [From Middle],
					charindex(' ',companyname) As [Find Text],
					CharINDEX('S',CompanyName) [Return 0 if Not Found],
					replace(companyname,' ',' // ') As [Replace Values],
					len(companyname) As [Text Length]
from Customers

---------EX002-----Advanced------
select CompanyName, left(companyname,charindex(' ',companyname)) as firstname,
				    substring(companyname,
					charindex(' ',companyname)+1,
					len(companyname)-charindex(' ',companyname)) as LastName
from Customers
--CONCAT -Text Concatenation IGNORE NULL
SELECT CompanyName,Region,City,Country,
		Region+' '+City+' '+Country AS [Address],
		CONCAT(Region,' ',City,' ',Country) As [Full Address]
FROM Customers


----------Date Time Functions---------
/*
	-Year(Date) --> Return Year As 4 DIGIT 
	-Month(Date) --> Return Month Number from  1-12
	-Day(Date)--> return Day Number 1-31
	-SysDateTime()
	-GetDate()
	-DateDiff(Date1,Date2,Interval) --> return different between 2 date using Interval
	-Format(datetime,FormatString [dd/MM/yyyy])
*/
select sysdatetime() AS[Server Date],GetDate() AS [Local Date]
-- Examples================
--Ex001
Select OrderDate,RequiredDate From Orders
SELECT OrderDate,RequiredDate,Format(orderdate,'dd/MM/yyyy'), 
				  Year(orderdate)As OrderYear, 
				  Month(OrderDate)as "order Month", 
				  Day(orderDate) As OrderDay,
				  Cast(cast(sysdateTime()as datetime)-OrderDate as int )/360 as Period	,
				  DateDiff(Day,OrderDate,RequiredDate) [Per Day],
				  DateDiff(Month,OrderDate,RequiredDate),
				  DATEDIFF(Hour,OrderDate,RequiredDate)[Per Hour]
FROM Orders
/*
Date Pattern
d  dd --> Day Number
ddd	dddd --Day name
M	MM	--> Month Number
MMM	MMMM -->
*/
Select OrderDate,Format(OrderDate,'dddd d/MMMM/yyyy'),
				Format(OrderDate,'dddd d/MMMM/yyyy','ar-Lb'),
				Format(OrderDate,'dddd d/MMMM/yyyy','zh-ch')
From Orders
---EX002 Format With Currency
/*Format Functions
Format(ColumnName, 'C',[Culuture]) --> Currency
Format(ColumnName, 'P',[Culuture]) --> Percentage
Format(ColumnName, 'D',[Culuture]) --> Date
*/
GO
Declare @x as Money=10.258,@y Decimal(5,2)=.7
SELECT 
		FORMAT(@x,'c','en-us') as USD, 
		FORMAT(@x,'c','ar-eg')as EGP,
		FORMAT(@y,'P') as [%Percentage],
		FORMAT(GETDate(),'D'),FORMAT(GETDate(),'D','fr-FR')
		
GO
Select * From Orders
Where Month(OrderDate)=4

SELECT * FROM ORDERS
WHERE (Month(OrderDate) Between 4 AND 6) AND Year(OrderDate)=1997
------------Convertion Functions----------
----------Convert From Type to Another TYPE		
		/* Impicit Conversion */
		
		select 1+'2' as Total ---------Converting sting to Int
		Select 1+'Three' As result ---- Error Can Not Convert

		/* Expicit Conversion */
		------------------------
/*-- Syntax
	-Cast(Col as DataType) ---> ANSI Standard
	-Convert(Target DataType,Col, StyleNo) --Microsoft
	-Parse(col as Datatype  Using 'Culuture') 
 Note: 
	1- Converting from Higher DataType to Lower DataTypes Make * Error [Truncation]
	2- to Avoiding return errors when can not Convert Types use
		Try_Cast()
		Try_Parse()
		Try_Convert()
*/
Declare @T as Int=10
Select cast(@T as char(1))

--EX01 --- Cast ANSI Standard
SELECT OrderDate,
				cast(OrderDate as date) As OrderDate,
				cast(OrderDate as int) As [Date Serial NUmber],
				Cast(OrderDate as VarChar(20)) As DateInCharacters,
				CAST(GETDate() AS INT)[Today Serial Number]
FROM Orders
------EX002
select sysdatetime()
Select cast(SysDatetime() as datetime)
Select cast(SysDatetime() as Varchar(50))
Select cast(SysDatetime() as int) -- Error Can NOT CONVERT

--EX01 --- Convert MICROSOFT
/*
CONVERT (Target Type, Col,[Style No]
*/
Select OrderDate,CONVERT(varchar(20),orderDate,130)
	,CONVERT(Nvarchar(20),orderDate,130),CONVERT(INT ,Orderdate)
from Orders
/*
Convert From STRING to any Type
PARSE(String_Column As DataType [Using Culture])
*/
--EX01 --- Parse Converting From String
Select parse('1/10/2019' as Datetime2 using 'En-US')
Select parse('1/10/2019' as Datetime2 using 'Ar-EG')
SELECT PARSE('31/12/2020' AS DATETIME) -- Error
Select PARSE('31/12/2020' As Date Using 'ar-EG')
SELECT PARSE('2/30/2020' As Date Using 'ar-EG') --Error 30 Feb??
--Incase You do not Need Convertion Error use Try_Parse() OR Try_Convert() OR TRY_CAST() --> return NUll
SELECT TRY_PARSE('2/30/2020' As Date Using 'en-US')

--============================================================

-- Logical Function
/*ISNumeric , IIF,Choose
			1- ISNumeric(Col) -----> Return 1 if true Or 0 if False
			2- IIF(Condition,True,False) Nested to 10 Levels

IIF(Test<Boolean Expression>,Value When Test is True, value When test is false)
*/
Select * From Products
Select ProductName,UnitsinStock,
	IIF(UnitsinSTock<50,'Low Stock','Good Stock') As StockRank
From Products
Order By StockRank Desc
--=============================
-----------------------ISNumeric
SELECT  CustomerID,CompanyName,PostalCode,ISNUmeric(PostalCode)
FROM	Customers
WHERE	IsNumeric(PostalCode)=0

-----------------------IIF
SELECT	ProductName,UnitPrice,IIF(UnitPrice<50,'Low','High') as RankPrice
FROM	Products


Go
Declare @NID Varchar(20)='29910112345467'
SELECT @NID,ISNumeric(@NID),LEN(@NID),
	IIF(IsNumeric(@NID)=1 AND LEN(@NID)=14,'Valid','NOT Valid')
Go
---Working With NUll Functions:
----------------------------
/*
ISNull(Column,Replace_Value) -->ANSI Standand Replace Null With 1 Value
Coalesce(Column,Value|Col,Value|col,....)
NullIF(Column,Value) Set Value by NULL
*/
Select * from Customers
SELECT	CustomerID,CompanyName,Region,Fax,Phone,Country,
		ISNULL(Region,'No-Region')AS [IsNull],
		Coalesce(Region,Fax,Phone,'No Data') AS [Coalesce],
		NullIF(Country,'UK') [NULL IF],
		Region+','+City,ISNULL(Region,' ')+','+City
FROM	Customers
/*
====================GROUP AGGRIGATE FUNCTIONS================
- Take one or more input To return a single summarizing value.
- Run Over Multiple Rows ===> Return Single Value
- WORKS With---> SELECT,  HAVING, ORDER BY
- Ignore Null Values Except Count(*)
SUM()
MAX()
MIN()
AVG()
COUNT()
COUNT(*)
*/
---USE AGGRIGATE
SELECT * From [Order Details]

SELECT	ProductName,
		SUM(Quantity) As [Total QTY],
		MAX(Quantity) AS [Max Qty],
		AVG(OD.UnitPrice) As [Average price],
		SUM(OD.UnitPrice*Quantity) As TotalSales,
		COUNT(OrderID),
		COUNT(DISTINCT OrderID)
FROM [Order Details] AS OD JOIN Products As P ON P.ProductID=OD.ProductID
GROUP BY ProductName

Select	ProductName,Year(OrderDate),
		SUM(OD.UnitPrice*Quantity) AS Total
		,AVG(OD.UnitPrice) AS [Price Average],MAX(Quantity) As [Max Qty] ,
		Count(OD.ProductID) As "Number Of Orders"
From [Order Details] As OD JOIN Products As P ON P.ProductID=OD.ProductID
			JOIN Orders As O On O.OrderID=Od.OrderID
GROUP BY ProductName,Year(OrderDate)

---USE AGGRIGATE WITH SCALAR & DISTINCT
Select COUNT(DISTINCT Year(OrderDate)),
	Cast(MAX(OrderDate) As DATE )AS [Last Order Date],
	FORMAT(MIN(OrderDate),'dd-MMMM-yyyy' )As[First Order Date]
From Orders

---Handle NULL to Avoid Wrong Values
Create Table EmployeesSalaries 
(EmpID INT Identity,Name Nvarchar(20),Salary Decimal(10,2) )

INSERT INTO EmployeesSalaries Values ('Ahmed',6000),('Ali',8000),('Sayed',4000)
INSERT INTO EmployeesSalaries (Name) Values ('Sarah')
Select * from EmployeesSalaries
-------------------Wrong Results
	Select Count(Salary) As [Number of Emplyees],AVG(Salary)
	FROM EmployeesSalaries
--MUST Handle NULL
Select Count(ISNull(Salary,0)) As [Number of Emplyees],
	AVG(ISNull(Salary,0))
FROM EmployeesSalaries
/*
=============GROUP BY & HAVING BY CLauses=========
*/


