
-- Lesson 1) PIVOT & UNPIVOT :- 
---------------------------------
 /* -- PIVOT :-
  ------------
    - Pivoting data is rotating data from a rows-based orientation to a columns-based orientation.
	- It does this by consolidating values in a column to a list of distinct values then retun them as columns.
	- Pivoting includes three phases :-
                1) Grouping    :- Determines from FROM clause which element gets a row in the result set 
                2) Spreading   :- Provides the distinct values to be pivoted across
                3) Aggregation :- Performs an aggregation function (such as SUM,Count,etc..)
  -- UNPIVOT :-
  -------------
			- Unpivoting data is the logical reverse of pivoting data
			- Instead of turning rows into columns, unpivot turns columns into rows.
			- This is a technique useful in taking data that has already been pivoted.
			- Unpivoting includes three elements :-
                          1) Source columns to be unpivoted
                          2) Name to be assigned to new values column
                          3) Name to be assigned to names columns
			- Unpivoting does not restore the original data. 
			- Detail-level data was lost during the aggregation process in the original pivot.
			- UNPIVOT has no ability to allocate values to return to original detail values. 
 PIVOT Syntax
 ------------
select col1,[x],[y],[z]
from ( select col1,col2,col3 from table) as derived_Table_Name
pivot(AggFunc(col) for Col in ([x],[y],[z]) ) as alise
*/
-- Example1 


USE Northwind;
----------Preparing Data:
/*
VIEW
TVF

Derived Table
CTE
*/
Go
SELECT SalesPerson,SUM(Total),OrderYer
FROM	(SELECT CONCAT(FIRSTNAME,' ',Lastname) As SalesPerson,
		Year(OrderDate) As OrderYer,UnitPrice*Quantity As Total
	    FROM Employees As E JOIN ORders as o On O.EmployeeID=E.EmployeeID
		JOIN [Order Details] As OD ON OD.OrderID=O.OrderID) As Tb
GROUP BY SalesPerson,OrderYer

----PIVOT
SELECT SalesPerson,[1996] As FirstYear,[1997],[1998],[1999]
FROM	(SELECT CONCAT(FIRSTNAME,' ',Lastname) As SalesPerson,
		Year(OrderDate) As OrderYear,UnitPrice*Quantity As Total
	    FROM Employees As E JOIN ORders as o On O.EmployeeID=E.EmployeeID
		JOIN [Order Details] As OD ON OD.OrderID=O.OrderID) As Tb
PIVOT(SUM(Total)for OrderYear in([1996],[1997],[1998],[1999]) ) As piv


GO
-- create table, query,view or stored pro -->  with data suitable to be PIVOTed
SELECT CategoryName,Quantity,year(OrderDate) as OrderYear  
	into TB1 -- //COPING  table to use with PIVOTING 
FROM [Order Details] as od 
	 join Products as p	 on p.ProductID=od.ProductID
	 join Orders as o     on o.orderid=od.OrderID
	 join Categories as c on p.CategoryID=c.CategoryID

--> retrive all data
SELECT * from TB1
--> retrive summarized data
select orderyear,count(*) from TB1
group by orderyear

----> pivoting Data
SELECT CategoryName,[1996],[1997],[1998]  
FROM  (select categoryname,quantity,orderyear from TB1) as Piv
Pivot(sum(quantity) for orderyear in ([1996],[1997],[1998]) ) as Data1
ORDER BY CategoryName

GO
---------------------
-- Example 2 ( Pivot)
-------------------------------
-- For Each Year ( Count Orders For Each Employee)

CREATE Function MonthlyReport(@year INT)
RETURNS Table
AS
	Return (SELECT Concat(FirstName,' ',LastName) As SalesPerson,
			Year(OrderDate) As OrderYear, Month(OrderDate) As OrderMonth,
			UnitPrice*Quantity As Total
			FROM Employees AS E JOIN Orders As O On O.EmployeeID=E.EmployeeID
								JOIN [Order Details] As OD ON OD.OrderID=O.OrderID
			WHERE Year(OrderDate)=@year
			)
GO
Select * From MonthlyReport(1996)
-----------Now Create PIVOT Employees By Month
SELECT SalesPerson,ISNULL([1],0)AS JAN,[2]AS FEB,[3] AS MARCH,[4],[5],[6],[7],[8],[9],[10],[11],[12]
FROM MonthlyReport(1997)
PIVOT(SUM(Total) FOR OrderMonth IN([1],[2],[3],[4],[5],[6],[7],[8],[9],[10],[11],[12])) As PIV

SELECT SalesPerson,ISNULL([1],0) AS Jan,[2]As Feb,[3],[4],[5],[6],[7],[8],[9],[10],[11],[12]
FROM MonthlyReport(1996)
PIVOT(SUM(Total) for OrderMonth IN([1],[2],[3],[4],[5],[6],[7],[8],[9],[10],[11],[12])) As PIV 
-----------------Example 3 Use CTE
use Northwind;
--In Case you can not use CREATE
WITH CTE1
AS 
(SELECT OrderID,EmployeeID,YEAR(OrderDate) AS OrderYear FROM  Orders)
SELECT OrderYear ,[1],[2],[3],[4],[5],[6],[7],[8],[9] FROM CTE1
PIVOT ( COUNT(OrderID) FOR EmployeeID IN ([1],[2],[3],[4],[5],[6],[7],[8],[9]) ) AS PIV
GO
-- Example ( unPivot) Use Pivoted Table TB2
------------------Save Pivot ONTO TABLE
SELECT CategoryName,[1996],[1997],[1998] 
INTO UnPiv
FROM  (select categoryname,quantity,orderyear from TB1) as Piv
Pivot(sum(quantity) for orderyear in ([1996],[1997],[1998]) ) as Data1
ORDER BY CategoryName

Select * From UnPiv
--UNPIVOT
select  categoryname,orderyear,qty -- note ( pivot col have new Name)
from  UnPIV
UNPIVOT(qty for orderyear in ([1996],[1997],[1998]) ) as Up --( pivot col have with no aggrigation)
order by CategoryName

---------------------------------------------------------------------------------------------
/*
Executing Stored Procedures
------------------------------

				Querying Data with Stored Procedures
				Passing Parameters to Stored Procedures
				Creating Simple Stored Procedures
				Working with Dynamic SQL


Lesson 1: Querying Data with Stored Procedures
-----------------------------------------------
			Examining Stored Procedures
			Executing Stored Procedures


Examining Stored Procedures
	- Stored procedures are collections of T-SQL statements stored in a database
	- Procedures can return results, manipulate data, and perform administrative actions on the server
	- With other objects, procedures can provide a trusted application programming interface to a database, insulating applications from database structure changes
			* Use views, functions, and procedures to return data
			* Use procedures to modify and add new data
			* Alter procedure definition in one place, rather than update application code

Executing Stored Procedures
      -Invoke a stored procedure using EXECUTE or EXEC
      -Call procedure with two-part name
      -Pass parameters in @name=value form, using appropriate data type
*/
Go
CREATE PROC MyPro
AS
 BEGIN --Optional
	SELECT employeeId , FirstName,Lastname,
	concat(firstname,' ' ,lastname) as Fullname,Country from employees
 END --Optional
 --call Procedure 
exec MyPro

------------------------------------------------------------------------------------------------
--Lesson 2: Passing Parameters to Stored Procedures
-------------------------------------------------------
			--Passing Input Parameters to Stored Procedures

/*
Parameters are defined in the header of the procedure code, including name, data type and direction (input is default)
Parameters are discoverable using SQL Server Management Studio and the sys.parameters view
To pass parameters in an EXEC statement, use names defined in procedure

*/
go
CREATE PROCEDURE Mypro2 @city nvarchar(50)
AS
BEGIN
	select employeeId , FirstName,Lastname,country,city
	from Employees
	where city=@city
END
exec Mypro2 'london'

-------------------------------------------------------------------------------
/*
Writing Queries with Dynamic SQL

 - Using sp_executesql ( System built-in  Stored Proc)
			- Accepts string as code to be run
			- Supports input, output parameters for query
			- Allows parameterized code while minimizing risk of SQL injection
			- Can perform better than EXEC due to query plan reuse

Syntax:-
--------
DECLARE @sqlcode AS NVARCHAR(256) = 	N'<code_to_run>';
EXEC sys.sp_executesql @statement = @sqlcode;

DECLARE @sqlcode AS NVARCHAR(256) = N'SELECT GETDATE() AS dt';
EXEC sys.sp_executesql @statement = @sqlcode;

*/
declare @c nvarchar(255)=N'Select Getdate() as dt'
exec sys.sp_executesql @c
Go
--Example-02 -- using Space In variable or concat it in the last vaiable
declare @d as nvarchar(50)=' Northwind';
declare @t nvarchar(50)='Employees';
Declare @Col nvarchar(200)=' EmployeeID,Firstname,Lastname,City';
declare @w nvarchar(200)='country=''usa''';

declare @co nvarchar(max)='use'+@d+';'+'select'+' '+@col+' From '+@t+' where '+@w ;
exec sys.sp_executesql @co
Exec Sys.sp_ExecuteSQL 'Select * from Employees'
GO
CREATE PROC Sp_ConvertTOSQL
@table Nvarchar(100),@column Nvarchar(500),@Where Nvarchar(100)
AS
	Declare @select Nvarchar(MAX)='SELECT '+@column+ ' FROM ' +@table+ ' Where '+@where
	EXEC SYS.SP_ExecuTeSQL @Select
GO
EXEC Sp_ConvertTOSQL 'Products','*','1=1'
EXEC Sp_ConvertTOSQL 'Orders','OrderID,OrderDate,EmployeeID','EmployeeID>5'

-----------------------------------------------------------
/*
Handle TRANSACTION:
Transaction Means: Do All Or Do Nothing
Syntax:
Begin Try
	Begin Tranaction
		<DML>
	Commit Transaction
End Try

Begin Catch
	Select Error_Number()
	RollBack TranAction
End Catch
*/
SELECT * FROM Products
SELECT * FROM [Order Details]
-- Example Inserting Order in order Details And Updating Stock In Products
SELECT * INTO OD
FROM [Order Details]

SELECT * INTO PRO
FROM Products
ALter Table PRO Add Constraint Pk_Pro Primary Key (ProductID)
Alter Table od add constraint PK1 Primary Key (OrderID,ProductID)

Select * from pro
select * from Od 

GO
Create Proc Check_Trans 
@od int, @Pid Int, @price decimal(7,2),@Quant Int, @dis Decimal (5,2)
As
BEGIN
	Begin Try
		Begin TRANSACTION
			Update pro Set unitsInstock=unitsInstock-@quant where ProductID=@Pid
			Insert into od Values(@od,@Pid,@price,@Quant,@dis)
			
		Commit TRANSACTION
	End Try

	Begin Catch
		select error_number()
		throw;   
		RollBack TRANSACTION
	End Catch
End

-- Call
Exec Check_Trans 10248,1,18,10,0
Select * from OD
Exec Check_Trans 10248,1,18,5,0
Insert into od Values	(10255,1,20,30,0)

select * from pro

select * from od where orderid=10255

-- drop table od
 --drop table pro
 --select * into od from Northwind.dbo. [Order Details]
 --select * into pro from Northwind.dbo. products
