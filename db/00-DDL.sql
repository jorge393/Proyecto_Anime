-- Active: 1632321143175@@127.0.0.1@3306
DROP DATABASE IF EXISTS ProyectoAnime;
Create database ProyectoAnime;
USE ProyectoAnime;
Create table Autor 
(
	idAutor int not null auto_increment,
    nombre varchar(45) not null,
    CONSTRAINT PK_Autor PRIMARY KEY (idAutor) 
);

CREATE TABLE Estudio
(
	idEstudio int not null auto_increment,
    domicilio varchar(50) not null,
    nombre varchar(45) not null,
    CONSTRAINT PK_Estudio PRIMARY KEY(idEstudio) 
);

Create table Anime
(
 idAnime int not null AUTO_INCREMENT,
 nombre varchar (50) not null,
 genero varchar(45) not null,
 episodios smallint not null,
 lanzamiento date not null,
 estado varchar(45) not null,
 idEstudio int not null,
 idAutor int not null, 
 CONSTRAINT PK_Anime PRIMARY KEY (idAnime),
 CONSTRAINT FK_Anime_Estudio FOREIGN KEY(idEstudio)
	REFERENCES Estudio (idEstudio),
 CONSTRAINT FK_Anime_Autor FOREIGN KEY(idAutor)
	REFERENCES Autor (idAutor)
);