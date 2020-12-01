create table Categories (
	ID integer not null primary key,
	Name varchar(20) not null);

create table Games (
	ID integer not null primary key,
	Title varchar(30) not null,
	CategoryID integer not null default 1,
	foreign key (CategoryID) references Categories (ID));

insert into Categories(ID, Name) values
(1, "Nicht angegeben"),
(2, "Shooter"),
(3, "Strategie"),
(4, "Puzzle");

insert into Games (ID, Title, CategoryID) values
(1, "Witcher 3 - Wild Hunt", 1),
(2, "Age of Empires II", 3),
(3, "Battlefront II", 2),
(4, "Red Dead Redamption 2", 2);