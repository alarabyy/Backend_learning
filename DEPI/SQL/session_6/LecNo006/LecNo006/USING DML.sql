/*
T-SQL ELEMENTS:
----------------
	Predicates :(IN,Between .. AND..,LIKE, IS, NOT,EXITS)
	Operators:
		Assignment
		Comparison
		Concatenation
		Arithmetic
	Expressions: CASE
	Functions
	Controlling of Flow
	Comments
	Variables
USING DML:
	SELECT
	INSERT
	UPDATE
	DELETE
Functions
*/
------------------------------------------------------------
--------------USING DML
/*
INSERT ROWS:
----------------
1- Insert INTO Table (Column List) Values (value1,value2,...)
2- INSERT INTO Table 
	Select ..... From ....
3- Select .... INTO Table
	From..

*/
------------------------------------------------------------

CREATE Database DMLTest;
Go
Use DMLTest;
Go
--CREATE New Tables
CREATE TABLE Departments 
(DepartmentID INT Primary Key,DepartmentName NVarchar(20))

SP_HElP 'DEPARTments'
GO
Create Table Employees(EmployeeID INT Constraint PK_EMP Primary Key,
						FirstName Nvarchar(20),
						LastName Nvarchar(50),Salary Decimal(10,2),
						HireDate Date,
						Department INT Constraint fk_Dept Foreign Key References Departments(DepartmentID))
Alter Table Employees Alter Column Salary Decimal(10,2) NOT NULL
--INSERT STATEMENT
--INSERT VALUES
INSERT INTO Departments Values (101,'IT'),(102,'HR'),(103,'Sales')
Select * From Departments
Insert INTO Departments Values (103,'Finance') --Violation of PRIMARY KEY
INSERT INTO Departments (DepartmentName) Values ('Finance')

--INSERT Sample Data Into EMployees
Select * From Employees
INSERT INTO Employees VALUES (1,'Ahmed','Hamdy',12000,'2/10/2024',101) --INSERT SIngle Row
INSERT INTO Employees VALUES (2,'Hossam','Ahmed',15000,'5/1/2020',103),
							(3,'Elsayed','Abdo',20000,GETDATE(),102),
							(4,'Basil','Ashraf',18000,GETDate(),101)
--Use Column List
INSERT INTO Employees (EmployeeID,FirstName,Salary) Values (5,'Mohamed',1000)

Select * From Employees

SELECT * From Northwind.dbo.Employees

ALter Table Employees Alter Column Salary Decimal(10,2)
GO
INSERT INTO DMLTest.DBO. Employees (EmployeeID,LastName,FirstName,HireDate)
SELECT EmployeeID,LastName,FirstName,HireDate
FROM Northwind.dbo.Employees
Where EmployeeID>5

Go
CREATE Schema HR Authorization DBO
Create table HR.Candidates (CandiateID Int,RegisterDate Datetime)
GO
----SELECT INTO --COPY Table
Select * INTO koko
From Northwind.dbo.Orders
Select * From koko

----------------------------UPDATE STATEMENT:
/*
SYNTAX:
	UPDATE TableName
	SET Column=Value|Expression ,Column=Value|Expression
	WHERE <UPDATE CRITERIA>
*/
SELECT * From Employees

UPDATE Employees
SET LastName='ALi',HireDate='1/1/2023',Department=103,Salary=6000
WHERE EmployeeID=5
--Increase All Salaries by 10%
UPDATE Employees 
SET Salary=salary*1.1

UPDATE Employees
SET Salary=6000
Where Salary IS Null
/*
DELETE STATEMENT
DELETE FROM Table
WHERE
*/
Select * from koko
Delete From koko
----------------------------Automatic Column Value
/*
IDENTITY:
--------------
IDentity(seed,Increment)
	Identity(1000,1)
- Column Property
- Based on Intergral Values
-have SEED , INCREMENT
	Seed = Start value
	Increment = Number to Add Everey row
-ONLY ONE IDENTITY Column per table

*/
Create Table Products (ProductID INT IDENTITY(1000,1) Primary Key,
						Productname Nvarchar(20),
						Price Decimal(6,2),
						--Code INT Identity, Only one identity column per table is allowed.
						--Number TinyINT Identity(300,1)
						)
----IDENTITY Column Must Skipped from Insert Statement (BY Default)
Insert INTO Products Values ('TEA',20),('Coffee',30),('Sugar',25)
Select * From Products

INSERT into products Values (101,'T-Shirt',250) --Error
Go
----------------IN Case you need to insert manual into Identity Column
SET IDENTITY_Insert Products ON
INSERT INTO Products  Values (102,'Shirt',250)--MUST Use Column List
SET IDENTITY_INSERT Products OFF

SET IDENTITY_Insert Products ON
INSERT INTO Products (ProductID,Productname,Price) Values (101,'T-Shirt',250)
SET IDENTITY_INSERT Products OFF
INSERT INTO Products values ('Oil',50)
SELECT * From Products
Delete From Products

SELECT * From Products
INSERT INTO Products values ('Oil',50)
TRUNCATE Table Products
SELECT * From Products
INSERT INTO Products values ('Oil',50)
GO
SElect * From Products
Create Table Users (UserID UniqueIdentifier Primary key,UserName Nvarchar(20))

Insert Into Users Values (NewID(),'Mohamed'),(NewID(),'Dina')

Select * from users
