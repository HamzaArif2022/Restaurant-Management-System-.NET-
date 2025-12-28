

-- 1️⃣ Create the database
CREATE DATABASE RestaurantManagement;
GO

-- 2️⃣ Use the database
USE RestaurantManagement;
GO

-- 3️⃣ Create Clients table
CREATE TABLE Clients (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Phone NVARCHAR(20) NULL,
    Email NVARCHAR(100) NULL,
    JoinDate DATE DEFAULT CAST(GETDATE() AS DATE),
    LoyaltyPoints INT DEFAULT 0
);
GO

-- 4️⃣ Create Employees table
CREATE TABLE Employees (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Role NVARCHAR(50) NOT NULL,
    Email NVARCHAR(100) NULL,
    Phone NVARCHAR(20) NULL,
    HireDate DATE NULL,
    PasswordHash NVARCHAR(255) NULL
);
GO

-- 5️⃣ Create MenuItems table
CREATE TABLE MenuItems (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(MAX) NULL,
    Price DECIMAL(10,2) NOT NULL,
    BuyingPrice DECIMAL(10,2) NULL,
    Category NVARCHAR(50) NULL,
    PreparationTime INT NULL,
    IsAvailable BIT DEFAULT 1,
    Image NVARCHAR(MAX) NULL  -- stores file path or URL of the product image
);

GO

-- 6️⃣ Create Ingredients table
CREATE TABLE Ingredients (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Quantity DECIMAL(10,2) NOT NULL,
    Unit NVARCHAR(10) NOT NULL
);
GO

-- 7️⃣ Create MenuItemIngredients table
CREATE TABLE MenuItemIngredients (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    MenuItemId INT NOT NULL,
    IngredientId INT NOT NULL,
    QuantityRequired DECIMAL(10,2) NOT NULL,
    CONSTRAINT FK_MenuItemIngredients_MenuItems FOREIGN KEY (MenuItemId)
        REFERENCES MenuItems(Id),
    CONSTRAINT FK_MenuItemIngredients_Ingredients FOREIGN KEY (IngredientId)
        REFERENCES Ingredients(Id)
);
GO

-- 8️⃣ Create PaymentMethods table
CREATE TABLE PaymentMethods (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Label NVARCHAR(100) NOT NULL,
    IsActive BIT DEFAULT 1
);
GO

-- 9️⃣ Create Inventory table
CREATE TABLE Inventory (
    IngredientId INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Quantity DECIMAL(10,2) NULL,
    Unit NVARCHAR(20) NULL,
    ReorderLevel DECIMAL(10,2) NULL,
    SupplierInfo NVARCHAR(MAX) NULL
);
GO

-- 🔟 Create Orders table
CREATE TABLE Orders (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    ClientId INT NULL,
    EmployeeId INT NULL,
    TableNumber INT NULL,
    OrderDate DATETIME2 NOT NULL DEFAULT GETDATE(),
    Status NVARCHAR(20) NOT NULL DEFAULT 'Pending',
    Notes NVARCHAR(MAX) NULL,
    TotalAmount DECIMAL(10,2) NOT NULL DEFAULT 0,
    CONSTRAINT FK_Orders_Clients FOREIGN KEY (ClientId) REFERENCES Clients(Id),
    CONSTRAINT FK_Orders_Employees FOREIGN KEY (EmployeeId) REFERENCES Employees(Id)
);
GO

-- 1️⃣1️⃣ Create Payments table
CREATE TABLE Payments (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    OrderId INT NOT NULL,
    Amount DECIMAL(10,2) NOT NULL,
    PaymentMethod NVARCHAR(50) NULL,
    PaymentTime DATETIME2 NOT NULL DEFAULT GETDATE(),
    Tips DECIMAL(10,2) DEFAULT 0,
    CONSTRAINT FK_Payments_Orders FOREIGN KEY (OrderId) REFERENCES Orders(Id)
);
GO
CREATE TABLE Users (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(100) NOT NULL UNIQUE,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(255) NOT NULL,
    Role NVARCHAR(20) NOT NULL CHECK (Role IN ('Admin', 'Cashier')),
    CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
    LastLogin DATETIME2 NULL,
    IsActive BIT NOT NULL DEFAULT 1
);

GO


-- 1️⃣ Create OrderItems table (SQL Server)
CREATE TABLE OrderItems (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    OrderId INT NOT NULL,
    MenuItemId INT NOT NULL,
    Quantity INT NOT NULL DEFAULT 1,
    SpecialRequests NVARCHAR(MAX) NULL,
    ItemStatus NVARCHAR(20) NOT NULL DEFAULT 'Waiting',

    CONSTRAINT FK_OrderItems_Orders
        FOREIGN KEY (OrderId) REFERENCES Orders(Id),

    CONSTRAINT FK_OrderItems_MenuItems
        FOREIGN KEY (MenuItemId) REFERENCES MenuItems(Id)
);
GO


