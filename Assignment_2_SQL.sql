USE AdventureWorks2022
GO

--Q1
SELECT COUNT(ProductID) As TotalNumOfProducts
FROM Production.Product

--Q2
SELECT COUNT(pp.ProductID) AS NumOfProductsInSubCategory
FROM Production.Product pp, Production.ProductSubcategory ps
WHERE pp.ProductSubcategoryID = ps.ProductSubcategoryID AND ps.ProductSubcategoryID IS NOT NULL

--Q3
SELECT pp.ProductSubcategoryID, COUNT(pp.ProductID) AS CountedProducts
FROM Production.Product pp
WHERE pp.ProductSubcategoryID IS NOT NULL
GROUP BY pp.ProductSubcategoryID

--Q4
SELECT COUNT(ProductID) AS NumOfProductsNoSubCategory
FROM Production.Product
WHERE ProductSubcategoryID IS NULL

--Q5
SELECT pi.ProductID, SUM(pi.Quantity)
FROM Production.ProductInventory pi
GROUP BY pi.ProductID

--Q6
SELECT pi.ProductID, SUM(pi.Quantity) AS TheSum
FROM Production.ProductInventory pi
WHERE pi.LocationID = 40 
GROUP BY pi.ProductID
HAVING SUM(pi.Quantity) < 100

--Q7
SELECT pi.Shelf, pi.ProductID, SUM(pi.Quantity) AS TheSum
FROM Production.ProductInventory pi
WHERE pi.LocationID = 40 
GROUP BY pi.Shelf, pi.ProductID
HAVING SUM(pi.Quantity) < 100

--Q8
SELECT pi.ProductID, AVG(pi.Quantity) AS TheAvg
FROM Production.ProductInventory pi
WHERE pi.LocationID = 10 
GROUP BY pi.ProductID

--Q9
SELECT pi.ProductID, pi.Shelf, AVG(pi.Quantity) AS TheAvg
FROM Production.ProductInventory pi
GROUP BY pi.ProductID, pi.Shelf

--Q10
SELECT pi.ProductID, pi.Shelf, AVG(pi.Quantity) AS TheAvg
FROM Production.ProductInventory pi
WHERE pi.Shelf != 'N/A'
GROUP BY pi.ProductID, pi.Shelf

--Q11
SELECT pp.Color, pp.Class, COUNT(pp.ProductID) AS TheCount, AVG(PP.ListPrice) AS AvgPrice
FROM Production.Product pp
WHERE pp.Color IS NOT NULL AND pp.Class IS NOT NULL
GROUP BY pp.Color, pp.Class

--Q12
SELECT pc.Name AS Country, ps.Name AS Province
FROM Person.CountryRegion pc 
LEFT JOIN Person.StateProvince ps 
ON pc.CountryRegionCode = ps.CountryRegionCode

--Q13
SELECT pc.Name AS Country, ps.Name AS Province
FROM Person.CountryRegion pc 
LEFT JOIN Person.StateProvince ps 
ON pc.CountryRegionCode = ps.CountryRegionCode
WHERE pc.Name IN ('Germany', 'Canada')

USE Northwind
GO

--Q14
SELECT DISTINCT p.ProductID, p.ProductName
FROM Products p
INNER JOIN [Order Details] od ON p.ProductID = od.ProductID
INNER JOIN Orders o ON od.OrderID = o.OrderID
WHERE YEAR(GETDATE()) - YEAR(o.OrderDate) <= 26

--Q15
SELECT Top 5 o.ShipPostalCode 
FROM Orders o
WHERE o.ShipPostalCode IS NOT NULL
GROUP BY o.ShipPostalCode 
ORDER BY COUNT(o.OrderID) DESC

--Q16
SELECT Top 5 o.ShipPostalCode 
FROM Orders o
WHERE o.ShipPostalCode IS NOT NULL AND YEAR(GETDATE()) - YEAR(o.OrderDate) <= 26
GROUP BY o.ShipPostalCode 
ORDER BY COUNT(o.OrderID) DESC

--Q17
SELECT c.City, COUNT(c.CustomerID) AS NumOfCustomer
FROM Customers c
GROUP BY c.City

--Q18
SELECT c.City, COUNT(c.CustomerID) AS NumOfCustomer
FROM Customers c
GROUP BY c.City
HAVING COUNT(c.CustomerID) > 2

--Q19
SELECT DISTINCT c.CompanyName
FROM Customers c 
LEFT JOIN Orders o ON c.CustomerID = o.CustomerID
WHERE o.OrderDate > '1998-01-01'

--Q20
SELECT c.CompanyName, MAX(o.OrderDate) AS MostRecentOrderDate
FROM Customers c 
LEFT JOIN Orders o ON c.CustomerID = o.CustomerID 
WHERE o.OrderDate IS NOT NULL
GROUP BY c.CompanyName

--Q21
SELECT c.CompanyName, SUM(od.Quantity) AS TotalQuantityOfProducts
FROM Customers c
LEFT JOIN Orders o ON c.CustomerID = o.CustomerID
LEFT JOIN [Order Details] od ON o.OrderID = od.OrderID
GROUP BY c.CompanyName

--Q22
SELECT c.CustomerID, SUM(od.Quantity) AS TotalQuantityOfProducts
FROM Customers c 
LEFT JOIN Orders o ON c.CustomerID = o.CustomerID
LEFT JOIN [Order Details] od ON o.OrderID = od.OrderID
GROUP BY c.CustomerID
HAVING SUM(od.Quantity) > 100

--Q23
SELECT s.CompanyName AS 'Supplier Company Name', p.CompanyName AS 'Shipping Company Name'
FROM Suppliers s
CROSS JOIN Shippers p

--Q24
SELECT o.OrderDate, p.ProductName
FROM Products p 
LEFT JOIN [Order Details] od ON p.ProductID = od.ProductID
LEFT JOIN Orders o ON od.OrderID = o.OrderID

--Q25
SELECT e1.FirstName + ' ' + e1.LastName AS 'Employee1', e2.FirstName + ' ' + e2.LastName AS 'Employee2'
FROM Employees e1 
INNER JOIN Employees e2 ON e1.Title = e2.Title
WHERE e1.EmployeeID < e2.EmployeeID

--Q26
SELECT m.FirstName + ' ' + m.LastName AS Manager
FROM Employees e 
LEFT JOIN Employees m ON e.ReportsTo = m.EmployeeID
GROUP BY m.FirstName, m.LastName
HAVING COUNT(e.EmployeeID) > 2

--Q27
SELECT c.City AS City, c.CompanyName AS Name, c.ContactName AS 'Contact Name', 'Customer' AS Type
FROM Customers c
UNION
SELECT s.City AS City, s.CompanyName AS Name, s.ContactName AS 'Contact Name', 'Supplier' AS Type
FROM Suppliers s
ORDER BY City