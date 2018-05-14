CREATE PROCEDURE AddMenu
 @Primo NVARCHAR(50),
 @Secondo NVARCHAR(50),
 @Contorno NVARCHAR(50),
 @Dolce NVARCHAR(50),
 @Giorno DATE,
 @Pasto NVARCHAR(50)
as
	INSERT INTO Menu(Primo,Secondo,Contorno,Dolce,Giorno,Pasto)
				VALUES(@Primo,@Secondo,@Contorno,@Dolce,@Giorno,@Pasto)
go

CREATE PROCEDURE ElencoMenu
as
	SELECT Id,Giorno,Pasto FROM Menu
go

CREATE PROCEDURE VisualizzaMenu
@id int

as
	SELECT Id,Primo,Secondo,Contorno,Dolce,Giorno,Pasto FROM Menu WHERE Id = @id
go