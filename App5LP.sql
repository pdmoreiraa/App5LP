create database dbApp5LP;
use dbApp5LP;
create table usuario
(
IdUsu int primary key auto_increment,
nomeUsu varchar(50) not null,
Cargo varchar(50) not null,
DataNasc datetime
);

create table cliente
(
IdCli int primary key auto_increment,
nomeCli varchar(50) not null,
email varchar(150) not null,
CPF varchar(11) not null,
telefone varchar(11) not null
);