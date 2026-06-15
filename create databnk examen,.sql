create schema if not exists MasterMindDb;
use MasterMindDb;

create table if not exists MasterMindDb.User(
  idUser int auto_increment not null,
  nameUser varchar(60) not null,
  pogingen int not null,
  primary key (idUser)
);