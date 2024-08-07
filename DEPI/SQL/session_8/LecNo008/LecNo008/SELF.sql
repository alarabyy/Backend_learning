

/*ERROR Handling Using TRY / CATCH Blocks :-
--------------------------------------------

-- Try...Catch  it is basically two blocks of code with your stored procedures 
     that lets you execute some code, this is the Try section and if there are errors they are handled in the Catch section. 

   - Structured exception handling allows a centralized response to runtime errors :-
                          A) TRY to run a block of commands and CATCH any errors
						  B) Execution moves to the CATCH block of commands when an error occurs
						  C) No need to check every statement to see if an error occurred
						  D) You decide whether the transaction should be rolled back, errors logged, etc.

   - Not all errors can be caught by TRY / CATCH :- 
                          A) Syntax or compile errors.
						  B) Some name resolution errors.

   - TRY block defined by BEGIN TRY...END TRY statements :-
                          A) Place all code that might raise an error between them
						  B) No code may be placed between END TRY and BEGIN CATCH
						  C) TRY and CATCH blocks may be nested
						  D) CATCH block defined by BEGIN CATCH...END CATCH

   - Execution moves to the CATCH block when catchable errors occur within the TRY block
---------------------------------------------------------------------
--------------------Reading Error Data
1) Message number :- 
               - Each error message has a number. You can find most of the message numbers in the table sysmessages.
			   - (There some special numbers like 0 and 50000 that do not appear there.) 
			   - Message numbers from 50001 and up are user-defined. Lower numbers are system defined.


2) Severity level :-
               - A number from 0 to 25. If the severity level is in the range 0-10, 
					the message is informational or a warning, and not an error.
			   - Errors resulting from programming errors in your SQL code have a severity level in the range 11-16. 
			   - Severity levels 17-25 indicate resource problems, hardware problems or internal problems in SQL Server, 
					and a severity of 20 or higher is fatal, the connection will be terminated.

3) State :-
               - a value between 0 and 127. 
			   - The meaning of this item is specific to the error messages. 
			   - Microsoft has not documented these values.

4) Line :-
               - Line number within the procedure/function/trigger/batch the error occurred.
			   - A line number of 0 indicates that the problem occurred when the procedure was invoked.

5) Message text :-
               - The actual text of the message that tells you what went wrong.
			   - You can find this text in master..sysmessages, or rather a template for it, with placeholders for names of databases, tables etc.





Error  Contains:
ERROR_LINE    ==>   Returns the line number at which the error occurred
ERROR_MESSAGE ==>   Return information about the cause of the error.
ERROR_NUMBER  ==>   Returns the unique number for the error that occurred.
ERROR_PROCEDURE ==> Returns the name of the stored procedure or trigger in which the error occurred.
ERROR_SEVERITY  ==> Returns a value indicating how serious the error is.


Syntax:
	BEGIN TRY
	{ sql_statement | statement_block }
	END TRY

	BEGIN CATCH
	{ sql_statement | statement_block }
	END CATCH


*/

-- Example

SELECT 1 /0 --perform an operation 
IF @@ERROR<> 0   PRINT 'Error :P hahahah :P' --@@error is A built-in Function check if there an error
GO
------------------Ex 2 ------Handle Error Divid By Zero
	Begin try 
		select 5/0;
	End try 
	Begin catch 
		--print 'Can Not Div by Zero'
		--RaisError('Can Not Div by Zero',16,1);
		Throw 50000,'Div By Zero Not Applicable ',1;
 end catch 
 ------------------------------------Show All Error Message
 Select *  from sys.messages Order by message_ID ;
 
 ---------------------Adding A new Error Message to View Sys.Message  
 exec sp_addmessage 50001,16,N'·« Ì„ﬂ‰ «·ﬁ”„Â ⁄·Ì «·’›—';
 ---------------------------------


 -----------------------------Using RaisError (ErrorNo,'Message',Severity,Variable)
	 Begin try 
		select 5/0;
	 End try 
	 Begin catch 
	  raiserror(50001,16,1);
	 End catch
 -------------------------------------USING THROW instead of RaisError
 --- Used to Throw Error for Application to Notify Developer by Error Ecurance
 /*
  --Syntax: 
 Throw <Number>,'Message Text',Severity Level,State
	<Number> :  this number is message number , USER range of 50000 to 2,147,483,647, System range 1-49999
 */
 -- Example For THROW :-
-- With TRY....CATCH :-
------------------------
--Throw 50005, 'That Is Not Test',16
BEGIN TRY
	SELECT 100/0 AS 'Problem'
END TRY
BEGIN CATCH
	PRINT 'error :P';
	THROW 50022,'Type Anything You Want',16
END CATCH 



-----------------------Handle Try & Catch Using Stored Procedure-------------------------------

-------------- Create a procedure to retrieve error information.-------------------------------------
go
	CREATE PROCEDURE SP_Get_Errors
	AS
		SELECT 
			ERROR_NUMBER() AS ErrorNumber,
			ERROR_SEVERITY() AS ErrorSeverity,
			ERROR_PROCEDURE() as ErrorProcedure,
			ERROR_LINE() as ErrorLine,
			ERROR_MESSAGE() as ErrorMessage;
GO
-- Note This Proc Hide Exception& Error From Application
----------------------------USE Proc------------
GO
BEGIN TRY
    -- Generate divide-by-zero error.
    SELECT 1/0;
END TRY
BEGIN CATCH
    -- Execute the error retrieval routine.
    EXECUTE SP_Get_Errors;
END CATCH;
GO
----------------------------Use The Same Example But With THrow
BEGIN TRY
    -- Generate divide-by-zero error.
    SELECT 1/0;
END TRY
BEGIN CATCH
    -- Execute the error retrieval routine.
    EXECUTE usp_GetErrorInfo;
	throw;-- Means Throw the Exception with the Definition Of the Previews StoredPro And Log the Error
END CATCH;
GO
--------------------Create Pro To Log Error in Error Table
Create Table ErrorLog(ID Bigint Identity Primary Key,
					  ErrNo int,
					  MessageText NVarchar(Max),
					  SeverityNo Tinyint,
					  ProcName Nvarchar(Max),
					  Error_Date Datetime)
GO
CREATE PROCEDURE SP_Log_Errors
	AS
	Declare @ErrorNo int,@errorMessage Varchar(Max),@ErrorSev tinyint,@ErrorProc NVarchar(Max)
		SELECT 
			@ErrorNo=ERROR_NUMBER() ,
			@errorSev=ERROR_SEVERITY(),
			@errorProc=ERROR_PROCEDURE(),
			@errormessage=ERROR_MESSAGE()
			Insert into ErrorLog Values(@ErrorNo,@errorMessage,@ErrorSev,@ErrorProc,getdate())
GO

BEGIN TRY
    -- Generate divide-by-zero error.
    SELECT 1/0;
END TRY
BEGIN CATCH
    
    EXECUTE SP_Log_Errors;
	Select * from ErrorLog
END CATCH;
GO
--========================
--Programming with T-SQL
--======================== 
/*
Lesson 01: T-SQL Programming Elements
Lesson 02: Controlling Program Flow

Lesson 1: T-SQL Programming Elements :-
---------------------------------------
				1- Introducing T-SQL Batches
				    - Working with Batches
				2- Introducing T-SQL Variables
				    - Working with Variables
				3- Working with Synonyms

--Introducing T-SQL Batches
---------------------------
 1) T-SQL batches are collections of one or more T-SQL statements 
     sent to SQL Server as a unit for parsing, optimization, and execution
 2) Batches are terminated with GO by default
 3) Batches are boundaries for variable scope
 4) Some statements (for example, CREATE FUNCTION, CREATE PROCEDURE, CREATE VIEW) 
	may not be combined with others in the same batch


==> 
CREATE VIEW <view_name>
AS ...;
GO
==> 
CREATE PROCEDURE <procedure_name>
AS ...;
GO

-----------------------
--Working with Batches

     *) Batches are parsed for syntax as a unit
     *) Syntax errors cause the entire batch to be rejected
     *) Runtime errors may allow the batch to continue after failure, by default
Batches can contain error-handling code
*/
-- in SQL server  Code Error

use Northwind
go
Create table t1(Id int , code int , name nvarchar(50))
go
insert into t1 VALUES(1,2,N'abc');

--InValid batch
INSERT INTO dbo.t1 VALUES(1,2,N'abc');
INSERT INTO dbo.t1 VALUES(2,3,N'def');
INSERT INTO dbo.t1 VALUE(1,2,N'abc');
INSERT INTO dbo.t1 VALUES(2,3,N'def');
GO


--Valid batch
INSERT INTO dbo.t1 VALUES(1,2,N'abc');
INSERT INTO dbo.t1 VALUES(2,3,N'def');
GO
--invalid batch
INSERT INTO dbo.t1 VALUE(1,2,N'abc');
INSERT INTO dbo.t1 VALUES(2,3,N'def');
GO
--Batches can contain error-handling code
--------------------------------------------------------------------------------------
--Introducing T-SQL Variables
------------------------------
/*
       - Variables are objects that allow storage of a value for use later in the same batch
       - Variables are defined with the DECLARE keyword
	        - In SQL Server 2008 and later, variables can be declared and initialized in the same statement
       - Variables are always local to the batch in which they're declared and go out of scope when the batch ends
*/
go
Create proc Sp_getAllProduct  @ID int
as 
begin 
   select * from Products where categoryID = @ID; 
end 
go
--Declare and initialize variables
DECLARE @catid INT = 2;
--Use variables to pass parameters to procedure
EXEC Sp_getAllProduct @catid
GO

------------------------------------------------------------
-- Working with Variables
--------------------------

--Initialize a variable using the DECLARE statement
DECLARE @i INT = 0;
Declare @x Int,  @m int,   @n Varchar(20)
--go
Declare @x Int=50 , @m int,@n Varchar(20)

--Assign a single (scalar) value using the SET statement
SET @i = 1;
--Assign a value to a variable using a SELECT statement
--Be sure that the SELECT statement returns exactly one row
SELECT @i = COUNT(*) FROM Orders;
select @i
go
--EXample 02
select Sum(Quantity*UnitPrice) From [Order Details] where OrderID like N'11%'; -- ensure that my query returns Single Value

Declare @i as Int
SELECT @i =  Sum(Quantity*UnitPrice) FROM [Order Details] where OrderID like N'11%';
select @i
--------------
--------------------------------------------------
-- Working with Synonyms
-------------------------
/*
 - A synonym is an alias or link to an object stored  on the same SQL Server instance or on a linked server
           *) Synonyms can point to tables, views, procedures, and functions
 - Synonyms can be used for referencing remote objects as though they were located locally,
    or for providing alternative names to other local objects
 - Use the CREATE and DROP commands to manage synonyms
*/

USE Northwind 
Go
-- creating & Use TVF 
Create Function Fn_ShowAllEmployeeInTheOrders()
returns table 
as 
return select EmployeeID from orders
GO
------
select * from Fn_ShowAllEmployeeInTheOrders()

GO
-- create & Use synonym for TVF
CREATE SYNONYM MyFun FOR 	Northwind.dbo.Fn_ShowAllEmployeeInTheOrders; -- Should Have Full Name
GO
select * from MyFun();

--Deleting synonym
drop synonym myfun;

 --=======================================================================================================
 --Lesson 2: Controlling Program Flow
 --=================================

								--Understanding T-SQL Control-of-Flow Language
								--Working with IFÖELSE
								--Working with WHILE
/*
--Understanding T-SQL Control-of-Flow Language
-----------------------------------------------
   SQL Server provides additional language elements that control the flow of execution of T-SQL statements
        - Used in batches, stored procedures, and multistatement functions

   Control-of-flow elements allow statements to be performed in a specified order or not at all
       - The default is for statements to execute sequentially

   Includes IFÖELSE, BEGINÖEND, WHILE, RETURN, and others
*/
--=====
-- IF
--===== True
--------
if 1=1
begin 
    print 'welcome in SQL'
end 
--False 
--------
if 1=2
begin 
    print 'Hello in SQL'
end 
else
begin 
    print 'Finish  SQL Course'
end 
--------------------------------------------
 if 1=1
 begin 
    select * from Employees
 end
 --------------------------------
 Declare @x int = 2;
 if @x = 1
 begin 
   select * from Employees
 end 
 ----------------------------------------------------------------
 declare @ID int ;
 select @ID=orderID from Orders where orderID = 10248
 
 if 1=1 
 begin 
 select * from [Order Details] 
 where OrderID = @ID
 end
 -----------------------------------------------------------------

-------------------------------------------------------------------
/*
IFÖELSE uses a predicate to determine the flow of the code
The code in the IF block is executed if the predicate evaluates to TRUE 
The code in the ELSE block is executed if the predicate evaluates to FALSE or UNKNOWN
Very useful when combined with the EXISTS operator
*/
--IF ... Else
if 1=2
begin 
    print 'Hello in SQL'
end 
else
begin 
    print 'Finish  SQL Course'
end
go 
----------------------------------
Use Northwind;
declare @x as decimal;
select @x= sum(Quantity) from [Order Details];
--select @x;

if @x<30000
begin
print Concat(@x,'Quantity Very Low')
end
else
begin
print Concat(@x,' is good ')
end
go
----------------------------------------------------------
--Working with WHILE
----------------------
-- WHILE enables code to execute in a loop
-- Statements in the WHILE block repeat as the predicate evaluates to TRUE
-- The loop ends when the predicate evaluates to FALSE or UNKNOWN
-- Execution can be altered by BREAK or CONTINUE
 -----------------------------
 --Loop While (+Declaring Variable)
 
 Declare @x int = 1
 While (@X<=10)
 begin 
    Print concat('Welcome in SQL ',@x )
	set @x= @x+1 --Or==> Set @x+=1 ==>NOTE: skiping this step make an Infinit Loop 
 end 
 ----------------------------------------
 --Using Break
 -------
 declare @v int=2000
while (@v<=2020)
	begin
	print Concat('Welcome to SQL',@v)
	set @v+=4
		if @v=2016
			begin
				break;
			end
	end
 go
 -----------------------------------------------------
 --CONTINUE
 ------------
 Declare @Number int = 1
 While (@Number<=10)
 begin 
    Print concat('Welcome in SQL ',@Number )
	set @Number= @Number+1 

	if(@number <5)
	  begin
	    CONTINUE;
	  end
 end
 
 --------------------------------------------------------
 -- WHILE Example :-
declare @id as int=1, @n as nvarchar(50) -- Declaring more than One Variable
while @id<=7
	begin
		select @n=lastname 
		from Employees
		where EmployeeID=@id
		print @n
		set @id=@id+1
	End
GO 