CREATE DATABASE db_ArancelesDef;
GO
USE db_ArancelesDef;
GO

CREATE TABLE [Paises] 
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Nombre] NVARCHAR(100) NOT NULL,
	[Moneda] NVARCHAR(300) NOT NULL,
);
CREATE TABLE [Empresas](
	[Id] INT PRIMARY KEY IDENTITY (1,1) not null,
	[Nombre] NVARCHAR(50) not null,
	[Id_Pais] INT not null,
	FOREIGN KEY ([Id_Pais]) REFERENCES [Paises] ([Id])
);


INSERT INTO [Paises] ([Nombre],[Moneda])
VALUES ('China', 'Yuan');

INSERT INTO [Empresas] ([Nombre],[Id_Pais])
VALUES ('Nike', 3);

SELECT * FROM [Paises];

SELECT * FROM [Empresas];