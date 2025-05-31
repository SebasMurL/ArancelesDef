CREATE DATABASE db_ArancelesDef;
GO
USE db_ArancelesDef;
GO

CREATE TABLE [Paises] (
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Nombre] NVARCHAR(100) NOT NULL,
	[Moneda] NVARCHAR(300) NOT NULL,
);


INSERT INTO [Paises] ([Nombre],[Moneda])
VALUES ('China', 'Yuan');

SELECT * FROM [Paises];