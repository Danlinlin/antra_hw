USE AdventureWorks2022
GO

--Q1
SELECT ProductID, Name, Color, ListPrice
FROM Production.Product

--Q2
SELECT ProductID, Name, Color, ListPrice
FROM Production.Product
WHERE ListPrice != 0

--Q3
SELECT ProductID, Name, Color, ListPrice
FROM Production.Product
WHERE Color IS NULL

--Q4
SELECT ProductID, Name, Color, ListPrice
FROM Production.Product
WHERE Color IS NOT NULL

--Q5
SELECT ProductID, Name, Color, ListPrice
FROM Production.Product
WHERE Color IS NOT NULL AND ListPrice > 0

--Q6
SELECT Name + ' ' + Color as NameColor
FROM Production.Product
WHERE Color IS NOT NULL

--Q7
SELECT TOP 6 'NAME: ' + Name + ' -- ' + 'COLOR: ' + Color as Result
FROM Production.Product
WHERE Color IN ('Black', 'Silver') AND Name LIKE '%C%' AND Name NOT LIKE '%[1-9]%'

--Q8
SELECT ProductID, Name
FROM Production.Product
WHERE ProductID BETWEEN 400 AND 500

--Q9
SELECT ProductID, Name, Color
FROM Production.Product
WHERE Color IN ('Black', 'Blue')

--Q10
SELECT *
FROM Production.Product
WHERE Name LIKE 'S%'

--Q11
SELECT TOP 6 Name, ListPrice
FROM Production.Product
WHERE Name LIKE 'S%'
ORDER BY Name

--Q12
SELECT TOP 5 Name, ListPrice
FROM Production.Product
WHERE Name LIKE '[A,S]%'
ORDER BY Name

--Q13
SELECT *
FROM Production.Product
WHERE Name LIKE 'SPO' OR Name LIKE 'SPO[^K]%'
ORDER BY Name

--Q14
SELECT DISTINCT Color
FROM Production.Product
WHERE Color IS NOT NULL
ORDER BY Color DESC

--Q15
SELECT DISTINCT CAST(ProductSubcategoryID AS CHAR) + Color as result
FROM Production.Product
WHERE ProductSubcategoryID IS NOT NULL AND Color IS NOT NULL
ORDER BY result DESC







