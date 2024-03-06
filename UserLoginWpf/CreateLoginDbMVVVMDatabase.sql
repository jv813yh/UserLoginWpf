create database LoginDbMVVM
go
use LoginDbMVVM
go
create table [User]
(
	[Id] UNIQUEIDENTIFIER primary Key default NEWID(),
	[Username] nvarchar (50) unique not null,
	[Password] nvarchar (100) not null,
	[Name] nvarchar (50) not null,
	[LastName] nvarchar (50) not null,
	[Email] nvarchar (100) unique not null,
)
go
insert into [User] values (NEWID(), 'admin', 'admin', 'Jozef', 'NetJunior', 'netJunior@gmail.com')
insert into [User] values (NEWID(), 'krillex', '123rillex123', 'Norbert', 'Mikertos', 'norkoMike@gmail.com')
insert into [User] values (NEWID(), 'wpfMaestro', 'wpfIsMyLife', 'Augustus', 'Norimbus', 'norimbusA@gmail.com')

go