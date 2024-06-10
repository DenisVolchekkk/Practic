USE Bicycles
DROP TABLE IF EXISTS PartOrders;
DROP TABLE IF EXISTS PartBicycles;
DROP TABLE IF EXISTS Bicycles;
DROP TABLE IF EXISTS Parts;
DROP TABLE IF EXISTS Suppliers;
DROP TABLE IF EXISTS SupplierTypes;
go
CREATE TABLE SupplierTypes (
    SupplierTypeId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    SupplierTypeName NVARCHAR(100)
);

CREATE TABLE Suppliers (
    SupplierId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    SupplierName NVARCHAR(100),
    ContactInfo NVARCHAR(100),
    Address NVARCHAR(255),
    SupplierTypeId INT,
    FOREIGN KEY (SupplierTypeId) REFERENCES SupplierTypes(SupplierTypeId)
);

CREATE TABLE Parts (
    PartId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    PartName NVARCHAR(100),
    PartDescription NVARCHAR(255),
    SupplierId INT,
    FOREIGN KEY (SupplierId) REFERENCES Suppliers(SupplierId)
);


CREATE TABLE Bicycles (
    BicycleId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    ModelName NVARCHAR(100),
);

CREATE TABLE PartOrders (
    PartOrderId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    OrderDate DATE,
    ExpectedDeliveryDate DATE,
	BicycleId INT,
	CountOfBicycles INT,
    FOREIGN KEY (BicycleId) REFERENCES Bicycles(BicycleId)
);

CREATE TABLE PartBicycles (
    PartBicycleId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    PartId INT,
    BicycleId INT,
    QuantityRequired INT,
    FOREIGN KEY (PartId) REFERENCES Parts(PartId),
    FOREIGN KEY (BicycleId) REFERENCES Bicycles(BicycleId)
);