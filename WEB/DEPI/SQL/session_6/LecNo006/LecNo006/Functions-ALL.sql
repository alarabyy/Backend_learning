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
	4- charindex(char,string) === search for a Character in string
	5- Len(string) == String Length
	6- Upper(string) == Capital Letters
	7- Lower(string) == Small Letters
	8- Replace(string,find,replace) 
	9- Trim(String) --> Remove Extra Spaces
	10-Concat (string1,string2) --> Concatenate Text (Ignore Null Values)
*/*/

------CREATE Function Example
GO
Create Function AddNumbers(@first INT,@Second INT)
RETURNS INT --Define Return Type
AS
	Begin
		Declare @Result INT=@first+@Second
		RETURN @Result
	END
GO
	Select DBO.AddNumbers(50,88)
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
					replace(companyname,' ',' // ') As [Replace Values],
					len(companyname) As [Text Length]
from Customers

---------EX002-----Advanced------
select CompanyName, left(companyname,charindex(' ',companyname)) as firstname,
				    substring(companyname,
					charindex(' ',companyname)+1,
					len(companyname)-charindex(' ',companyname)) as LastName
from Customers

----------Date Time Functions---------
/*
	-Year(Date) --> Return Year As DIGIT 
	-Month(Date) --> Return Month Number from  1-12
	-Day(Date)--> return Day Number 1-31
	-SysDateTime()
	-GetDate()
	-DateDiff(Date1,Date2,Interval) --> return different between 2 date using Interval
	-Format(datetime,FormatString [dd/MM/yyyy])
*/
select sysdatetime(),GetDate()
-- Examples================
--Ex001
Select OrderDate,RequiredDate From Orders
SELECT OrderDate,Format(orderdate,'dd/MM/yyyy'), 
				  Year(orderdate)As OrderYear, 
				  Month(OrderDate)as "order Month", 
				  Day(orderDate) As OrderDay,
				  Cast(cast(sysdateTime()as datetime)-OrderDate as int )/360 as Period	,
				  DateDiff(Day,OrderDate,RequiredDate),
				  DATEDIFF(Hour,OrderDate,RequiredDate)
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
------------Convertion Functions----------
----------Convert From Type to Another TYPE		
		/* Impicit Conversion */
		
		select 1+'2' as Total ---------Converting sting to Int
		Select 1+'ABC' As result ---- Error Can Not Convert

		/* Expicit Conversion */
		------------------------
/*-- Syntax
	-Cast(Col as DataType) ---> ANSI Standard
	-Convert(Target DataType,Col, StyleNo)
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
				cast(OrderDate as int) As DateSerial,
				Cast(OrderDate as VarChar(20)) As DateInCharacters
FROM Orders
------EX002
select sysdatetime()
Select cast(SysDatetime() as datetime)
Select cast(SysDatetime() as Varchar(50))
Select cast(SysDatetime() as int) -- Error Can NOT CONVERT

--EX01 --- Convert MICROSOFT

Select OrderDate,CONVERT(Nvarchar(20),orderDate,130)
from Orders
--EX01 --- Parse Converting From String
Select parse('1/10/2019' as Datetime2 using 'En-US')
Select parse('1/10/2019' as Datetime2 using 'Ar-EG')
Select PARSE('31/12/2020' As Date Using 'ar-EG')
SELECT PARSE('2/30/2020' As Date Using 'en-US')
SELECT TRY_PARSE('2/30/2020' As Date Using 'en-US')

--============================================================

-- Logical Function
/*ISNumeric , IIF,Choose
			1- ISNumeric(Col) -----> Return 1 if true Or 0 if False
			2- IIF(Condition,True,False) Nested to 10 Levels

*/
Select ProductName,UnitsinStock,IIF(UnitsinSTock<50,'Low Stock','Good Stock')
From Products
--=============================
-----------------------ISNumeric
SELECT  CustomerID,CompanyName,PostalCode,ISNUmeric(PostalCode)
FROM	Customers
WHERE	IsNumeric(PostalCode)=1

-----------------------IIF
SELECT	ProductName,UnitPrice,IIF(UnitPrice<50,'Low','High') as RankPrice
FROM	Products


Go
Declare @NID Varchar(20)='29910112345A67'
SELECT @NID,ISNumeric(@NID),LEN(@NID),IIF(ISNumeric(@NID)=1 AND LEN(@NID)=14,'Valid','NOT')
Go
---Working With NUll Functions:
----------------------------
/*
ISNull(Column,Value) -->ANSI Standand Replace Null With 1 Value
Coalesce(Column,Value|Col,Value|col,....)
NullIF(Column,Value) Set Value by NULL
*/
Select * from Customers
SELECT	CustomerID,CompanyName,Region,Fax,Phone,
		ISNULL(Region,'No-Region')AS [IsNull],
		Coalesce(Region,Fax,Phone) AS [Coalesce],
		NullIF(Region,'BC')
FROM	Customers
/*
====================GROUP AGGRIGATE FUNCTIONS================
- Take one or more input To return a single summarizing value.
- Run Over Multiple Rows ===> Return Single Value
- WORKS WIth---> SELECT,  HAVING, ORDER BY
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

Select	ProductName,Year(OrderDate),
		SUM(OD.UnitPrice*Quantity) AS Total
		,AVG(OD.UnitPrice) AS [Price Average],MAX(Quantity) As [Max Qty] ,
		Count(OD.ProductID) As "Number Of Orders"
From [Order Details] As OD JOIN Products As P ON P.ProductID=OD.ProductID
			JOIN Orders As O On O.OrderID=Od.OrderID
GROUP BY ProductName,Year(OrderDate)

---USE AGGRIGATE WITH SCALAR

---USE AGGRIGATE WITH DISTINCT

---Handle NULL to Avoid Wrong Values

/*
=============GROUP BY & HAVING BY CLauses=========
*/


