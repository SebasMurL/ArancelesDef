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
	[Id] INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
	[Nombre] NVARCHAR(50) not null,
	[Id_Pais] INT not null,
	FOREIGN KEY ([Id_Pais]) REFERENCES [Paises] ([Id])
);
CREATE TABLE [TiposDeAranceles]
(
	[Id] INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    [Nombre] NVARCHAR (90) NOT NULL,
    [FechaVigencia] SMALLDATETIME NOT NULL,
)


INSERT INTO [Paises] ([Nombre],[Moneda])
VALUES ('China', 'Yuan');

INSERT INTO [Empresas] ([Nombre],[Id_Pais])
VALUES ('Nike', 3); --Id_Pais : 1

INSERT INTO [TiposDeAranceles] ([Nombre],[FechaVigencia])
VALUES ('Ad Valorem', GETDATE()); --Id_Pais : 1

SELECT * FROM [Paises];

SELECT * FROM [Empresas];

SELECT * FROM [TiposDeAranceles];