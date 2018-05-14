create database Ristorante;
use Ristorante;

create table Menu(
	id int identity(1,1) primary key not null,
	Primo nvarchar(50) not null,
	Secondo nvarchar(50) not null,
	Contorno nvarchar(50) not null,
	Dolce nvarchar(50) not null,
	Pasto nvarchar(50) not null,
);
