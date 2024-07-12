
USE [master]

GO

CREATE DATABASE [AppCars]

GO

USE [AppCars]

GO

CREATE TABLE [MainCars]
(
[Id] int IDENTITY(1, 1) NOT NULL,
[Marka] nvarchar(50) NOT NULL,
[Model] nvarchar(50) NOT NULL,

CONSTRAINT PK_MainCars PRIMARY KEY([Id])
)
GO

	--('BMW', 'X6M'),
	--('Audi', 'A7'),
	--('Volvo', 'XC90'),
	--('Ford', 'F150'),
	--('Kia', 'Optima'),
	--('Toyota', 'Prado')

INSERT INTO [MainCars] 
	([Marka], [Model])
VALUES 
	('Ford', 'F-130'),
	('Ford', 'F-131'),
	('Ford', 'F-132'),
	('Ford', 'F-133'),
	('Ford', 'F-134'),
	('Ford', 'F-135'),
	('Ford', 'F-136'),
	('BMW', '321'),
	('BMW', '322'),
	('BMW', '323'),
	('BMW', '324'),
	('BMW', '325'),
	('BMW', '326'),
	('BMW', '327'),
	('BMW', '328'),
	('BMW', '329'),
	('BMW', '330'),
	('BMW', '331'),
	('BMW', '332'),
	('BMW', '333'),
	('BMW', '335'),
	('BMW', '334'),
	('BMW', '336'),
	('BMW', '337'),
	('BMW', '338'),
	('BMW', '339'),
	('BMW', '341'),
	('BMW', '342'),
	('BMW', '343'),
	('BMW', '344'),
	('BMW', '345'),
	('Audi', 'A1'),
	('Audi', 'A2'),
	('Audi', 'A3'),
	('Audi', 'A4'),
	('Audi', 'A5'),
	('Li', 'L1'),
	('Li', 'L2'),
	('Li', 'L3'),
	('Li', 'L4'),
	('Li', 'L5'),
	('Li', 'L6'),
	('Li', 'L7'),
	('Li', 'L8'),
	('Li', 'L9'),
	('Li', 'L10'),
	('Li', 'L11'),
	('Li', 'L12')
GO

SELECT * 
FROM [MainCars]
ORDER BY [Marka]