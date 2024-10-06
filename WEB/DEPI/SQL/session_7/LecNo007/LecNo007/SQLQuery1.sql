CREATE Function ConcatenateText 
		(@text1 Nvarchar(20),
		@text2 nvarchar(20))
RETURNS NVARCHAR(100)
AS
	Begin
		Declare @Final Nvarchar(100)
		SET @Final=@text1+' '+@text2
		RETURN @final
	END

Go
Select FirstName,LastName,DBO.ConcatenateText(FirstName,LastName) As FullName
From Employees

GO
Declare @NationalID VarChar(20)='299081500123422'
SELECT @NationalID,Len(@NationalID),
	ISNumeric(@NationalID),
	SubString(@nationalID,2,2) As [Year],
	SUBSTRING(@NationalID,4,2) As [month],
	SUBSTRING(@nationalID,6,2)

GO
Select CompanyName,
	TRIM(LEFT(CompanyName,CharIndex(' ',CompanyName))),
	CharIndex(' ',CompanyName) AS [Space Position],
	SUBSTRING(CompanyName,CharIndex(' ',CompanyName)+1,
		Len(CompanyName)-CharIndex(' ',CompanyName)) As LastName
From Customers

--Format Function:
---------------
SELECT OrderDate,FORMAT(OrderDate,'D') [Use D],
	FORMAT(OrderDate,'dddd dd/MMMM/yyyy')[Use Pattern],
	FORMAT(OrderDate,'dddd dd/MMMM/yyyy','fr-FR')[Use pattern With Culuture]
FROM Orders
GO
--------Truncation
Declare @x int=10
SELECT CAST(@x As Char(1))

SELECT SUM(Quantity),MAX(Quantity),AVG(UnitPrice)
FROM [Order Details]