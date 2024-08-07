Use DMLTest;
Go
CREATE Function AddNumbers(@first INT,@second INT)
RETURNS INT
AS
	Begin
		Declare @result int=@first+@second
		return @result
	END

SELECT dbo.addNumbers(50,10)

Select   dbo.AddNumbers(UnitPrice,Quantity)
From Northwind.dbo.[Order Details]
SELECT 1+'10'
Select 1+'Ten'
SELECT '10'+'20' ,CAST('10' AS INT)+CAST('20' AS INT) As [Explicit Convert]

Select OrderDate,FORMAT(OrderDate,'dddd dd/MMMM/yyyy' )
From Northwind.dbo.Orders


Select SUM(Quantity*UnitPrice)
From Northwind.dbo.[Order Details]

