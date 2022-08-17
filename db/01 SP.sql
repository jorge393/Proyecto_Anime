DELIMITER $$
drop PROCEDURE if EXISTS altaAutor;

CREATE PROCEDURE altaAutor (out unIdAutor int, unNombre VARCHAR(45))
BEGIN 
    INSERT INTO Autor (nombre)
            VALUE (unNombre);
    SET unIdAutor = last_insert_id();
END $$

DELIMITER $$
drop PROCEDURE if EXISTS altaEstudio;

CREATE PROCEDURE altaEstudio (out unIdEstudio int, unNombre VARCHAR(45), unDomicilio VARCHAR(45))
BEGIN 
    INSERT INTO Estudio (nombre, dommicilio)
            VALUE (unNombre, unDomicilio);
    SET unIdEstudio = last_insert_id();
END $$

DELIMITER $$
drop PROCEDURE if EXISTS altaAnime;

CREATE PROCEDURE altaAnime (out unIdAnime int, unNombre VARCHAR(45), unEpisodios INT, unLanzamiento DATE, unEstado varchar(45) )
BEGIN 
    INSERT INTO Anime (nombre, episodios, lanzamiento, estado)
            VALUE (unNombre, unEpisodios, unLanzamiento, unEstado);
    SET unIdAnime = last_insert_id();
END $$

