create database viagem;
use viagem;

create table Usuario(
id int auto_increment not null primary key,
nomeDeUsuario varchar(255) not null,
dataDeNascimento datetime not null,
login varchar(255) not null,
senha varchar(255) not null,
tipo int not null);

create table Pacote(
id int auto_increment not null primary key,
imagem varchar(255) not null,
nomeDoPacote varchar(255) not null,
origemDoPacote varchar(255) not null,
destinoDoPacote varchar(255) not null,
atrativos varchar(1000) not null,
saida datetime not null,
retorno datetime not null,
usuario varchar(255));
insert into usuario(nomeDeUsuario, dataDeNascimento, login, senha, tipo) values("adm", "0001-01-01 01:01:01", "adm123", "1234", 1 );
