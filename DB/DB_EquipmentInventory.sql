CREATE DATABASE equipmentInventory
GO

USE equipmentInventory;
GO

CREATE TABLE EquipmentType(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Description NVARCHAR(100) NOT NULL,
	CreationDate DATE DEFAULT GETDATE() NOT NULL,
	ModifyDate DATE,
	DeletedDate DATE,
	Deleted BIT DEFAULT 0 NOT NULL,
);
GO

INSERT INTO EquipmentType (Description) VALUES 
('Laptop'),
('Desktop'),
('Printer'),
('Monitor');
GO

CREATE TABLE Equipment(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Brand NVARCHAR(100) NOT NULL,
	Model NVARCHAR(100) NOT NULL,
	EquipmentTypeId INT NOT NULL,
	PurchaseDate DATE NOT NULL,
	SerialNumber NVARCHAR(100),
	CreationDate DATE DEFAULT GETDATE() NOT NULL,
	ModifyDate DATE,
	DeletedDate DATE,
	Deleted BIT DEFAULT 0 NOT NULL,
	FOREIGN KEY (EquipmentTypeId) REFERENCES EquipmentType(Id)
);
GO

CREATE TABLE MaintenanceTask(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Description NVARCHAR(200) NOT NULL,
	CreationDate DATE DEFAULT GETDATE() NOT NULL,
	ModifyDate DATE,
	DeletedDate DATE,
	Deleted BIT DEFAULT 0 NOT NULL
);
GO

CREATE TABLE EquipmentMaintenance(
	EquipmentId INT NOT NULL,
	MaintenanceTaskId INT NOT NULL,
	CreationDate DATE DEFAULT GETDATE() NOT NULL,
	ModifyDate DATE,
	DeletedDate DATE,
	Deleted BIT DEFAULT 0 NOT NULL,
	PRIMARY KEY (EquipmentId, MaintenanceTaskId),
	FOREIGN KEY (EquipmentId) REFERENCES Equipment(Id),
	FOREIGN KEY (MaintenanceTaskId) REFERENCES MaintenanceTask(Id)
);
GO