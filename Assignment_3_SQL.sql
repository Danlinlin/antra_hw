USE Northwind
GO

--Q1
SELECT DISTINCT c.City
FROM Customers c
JOIN Employees e ON c.City = e.City;

--Q2
--a.Use sub-query
SELECT DISTINCT c.City
FROM Customers c
WHERE c.City NOT IN (
    SELECT e.City
    FROM Employees e
)
--b.Do not use sub-query
SELECT DISTINCT c.City
FROM Customers c
LEFT JOIN Employees e ON c.City = e.City
WHERE e.City IS NULL

--Q3
SELECT ProductID, SUM(Quantity) as TotalQuantity
FROM [Order Details]
GROUP BY ProductID

--Q4
SELECT c.City, SUM(od.Quantity) AS TotalProductsOrdered
FROM Customers c
JOIN Orders o ON c.CustomerID = o.CustomerID
JOIN [Order Details] od ON o.OrderID = od.OrderID
GROUP BY c.City

--Q5
--a.Use union
SELECT City
FROM (
    SELECT City
    FROM Customers
    GROUP BY City
    HAVING COUNT(CustomerID) >= 2
    UNION
    SELECT City
    FROM Customers
    GROUP BY City
    HAVING COUNT(CustomerID) >= 2
) AS Cities
--b.Use sub-query and no union
SELECT City
FROM (
    SELECT City, COUNT(*) AS NumOfCustomer
    FROM Customers
    GROUP BY City
) AS CityCounts
WHERE NumOfCustomer >= 2

--Q6
SELECT c.City
FROM Customers c
JOIN Orders o ON c.CustomerID = o.CustomerID
JOIN [Order Details] od ON o.OrderID = od.OrderID
GROUP BY c.City
HAVING COUNT(DISTINCT od.ProductID) >= 2

--Q7
SELECT DISTINCT c.CustomerID, c.CompanyName, c.City AS CustomerCity, o.ShipCity AS OrderShipCity
FROM Customers c
JOIN Orders o ON c.CustomerID = o.CustomerID
WHERE c.City <> o.ShipCity

--Q8
WITH ProductQuantities AS (
    SELECT 
        od.ProductID, 
        SUM(od.Quantity) AS TotalQuantity
    FROM [Order Details] od
    GROUP BY od.ProductID
),
RankedCities AS (
    SELECT 
        od.ProductID, 
        c.City, 
        SUM(od.Quantity) AS CityQuantity,
        RANK() OVER (PARTITION BY od.ProductID ORDER BY SUM(od.Quantity) DESC) AS CityRank
    FROM ProductQuantities pq
    JOIN [Order Details] od ON pq.ProductID = od.ProductID
    JOIN Orders o ON od.OrderID = o.OrderID
    JOIN Customers c ON o.CustomerID = c.CustomerID
    GROUP BY od.ProductID, c.City
),
ProductPrices AS (
    SELECT 
        ProductID, 
        AVG(UnitPrice) AS AveragePrice
    FROM [Order Details]
    GROUP BY ProductID
)
SELECT TOP 5 
    pq.ProductID, 
    pq.TotalQuantity, 
    pp.AveragePrice, 
    rc.City AS MostOrderedCity
FROM ProductQuantities pq
JOIN ProductPrices pp ON pq.ProductID = pp.ProductID
JOIN RankedCities rc ON pq.ProductID = rc.ProductID
WHERE rc.CityRank = 1
ORDER BY pq.TotalQuantity DESC

--Q9
--a.Use sub-query
SELECT DISTINCT e.City
FROM Employees e
WHERE e.City NOT IN (
    SELECT DISTINCT o.ShipCity
    FROM Orders o
)
--b.Do not use sub-query
SELECT DISTINCT e.City
FROM Employees e
LEFT JOIN Orders o ON e.City = o.ShipCity
WHERE o.ShipCity IS NULL

--Q10
WITH EmployeeSales AS (
    SELECT 
        e.City AS EmployeeCity, 
        COUNT(o.OrderID) AS NumberOfOrders
    FROM Employees e
    JOIN Orders o ON e.EmployeeID = o.EmployeeID
    GROUP BY e.City
),
MaxEmployeeSales AS (
    SELECT TOP 1 
        EmployeeCity
    FROM EmployeeSales
    ORDER BY NumberOfOrders DESC
),
ProductQuantities AS (
    SELECT 
        o.ShipCity AS OrderCity, 
        SUM(od.Quantity) AS TotalQuantity
    FROM Orders o
    JOIN [Order Details] od ON o.OrderID = od.OrderID
    GROUP BY o.ShipCity
),
MaxProductQuantities AS (
    SELECT TOP 1 
        OrderCity
    FROM ProductQuantities
    ORDER BY TotalQuantity DESC
)
SELECT 
    (SELECT EmployeeCity FROM MaxEmployeeSales) AS CityWithMostSales,
    (SELECT OrderCity FROM MaxProductQuantities) AS CityWithMostProductsOrdered

--Q11
--ID: primary key for the table
WITH CTE AS (
    SELECT *,
    ROW_NUMBER() OVER (
        PARTITION BY ColumnHasDuplicates
        ORDER BY ID
    ) AS RowNum
    FROM TableToRemoveDuplicates
)
DELETE FROM CTE WHERE RowNum > 1;

