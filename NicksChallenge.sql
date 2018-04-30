use NickChallenge;
go

--CREATE SCHEMA Sales;
--GO

--CREATE TABLE Sales.Products
--(
--	[ID] INT unique identity not null,
--	[Name] VARCHAR(50) not null,
--	[Price] MONEY not null,
	 
--	PRIMARY KEY (ID)
--)

--CREATE TABLE Sales.Customers
--(
--	[ID] INT unique identity not null,
--	[Firstname] VARCHAR(50) not null,
--	[Lastname] VARCHAR(50) not null,
--	[CardNumber] INT not null,
	 
--	PRIMARY KEY (ID)
--)

--CREATE TABLE Sales.Orders
--(
--	[id] INT unique identity not null, 
--	[ProductID] INT not null,
--	[CustomerID] INT not null,
	 
--	PRIMARY KEY (ID),

--	CONSTRAINT FK_Product_Cascade 
--	FOREIGN KEY (ProductID) REFERENCES [Sales].[Products] (ID)
--	ON DELETE CASCADE,

--	CONSTRAINT FK_Customer_Cascade 
--	FOREIGN KEY (CustomerID) REFERENCES [Sales].[Customers] (ID)
--	ON DELETE CASCADE
--)

--DATA INSERTATIONS
--INSERT INTO Sales.Customers (Firstname, Lastname, CardNumber) values ('Tina', 'Smith', 123456789);
--INSERT INTO Sales.Customers (Firstname, Lastname, CardNumber) values ('John', 'Smith', 223456789);
--INSERT INTO Sales.Customers (Firstname, Lastname, CardNumber) values ('Frank', 'Bobbin', 323456789);

--INSERT INTO Sales.Products (Name, Price) values ('iPhone',  200);
--INSERT INTO Sales.Products (Name, Price) values ('Galaxy S9',  300);
--INSERT INTO Sales.Products (Name, Price) values ('Nokia', 10);

--INSERT INTO Sales.Orders (ProductID, CustomerID) values (1, 1);
--INSERT INTO Sales.Orders (ProductID, CustomerID) values (1, 2);
--INSERT INTO Sales.Orders (ProductID, CustomerID) values (2, 1);
--INSERT INTO Sales.Orders (ProductID, CustomerID) values (3, 3);


--Report all orders by Tina Smith
SELECT *
FROM Sales.Customers As Customers
INNER JOIN Sales.Orders AS Orders
  ON Customers.ID = Orders.CustomerID
WHERE Customers.Firstname = 'Tina' 
AND Customers.Lastname = 'Smith'

--Report all revenue generated by sales of iPhone
SELECT SUM(Products.Price)
FROM Sales.Products AS Products
INNER JOIN Sales.Orders AS Orders
  ON Products.ID = Orders.ProductID
WHERE Products.Name = 'iPhone'

-- Update value
UPDATE Sales.Products  
    SET Price = 250 
    WHERE ID = 1
GO  