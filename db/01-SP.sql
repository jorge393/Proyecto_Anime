
-- AUTOR
DELIMITER $$
DROP PROCEDURE if EXISTS altaAutor;

CREATE PROCEDURE altaAutor (out unIdAutor int, unNombre VARCHAR(45))
BEGIN 
    INSERT INTO Autor (nombre)
            VALUE (unNombre);
    SET unIdAutor = last_insert_id();
END $$

DROP PROCEDURE IF EXISTS eliminarAutor;
DELIMITER $$
CREATE PROCEDURE eliminarAutor(unId int)
BEGIN
    DELETE FROM Autor
    WHERE idAutor = unId;
END $$

DROP PROCEDURE IF EXISTS ActualizarAutor;

DELIMITER $$
CREATE PROCEDURE ActualizarAutor(unId int, unNombre VARCHAR(45))
BEGIN
    UPDATE Autor
    SET Nombre = unNombre
    WHERE idAutor = unId;
END $$





-- ESTUDIO
DELIMITER $$
DROP PROCEDURE if EXISTS altaEstudio;

CREATE PROCEDURE altaEstudio (out unIdEstudio int, unNombre VARCHAR(45), unDomicilio VARCHAR(45))
BEGIN 
    INSERT INTO Estudio (nombre, domicilio)
            VALUE (unNombre, unDomicilio);
    SET unIdEstudio = last_insert_id();
END $$

DROP PROCEDURE IF EXISTS eliminarEstudio;
DELIMITER $$
CREATE PROCEDURE eliminarEstudio(unId int)
BEGIN
    DELETE FROM Estudio
    WHERE idEstudio = unId;
END $$

DROP PROCEDURE IF EXISTS ActualizarEstudio;

DELIMITER $$
CREATE PROCEDURE ActualizarEstudio(unId int, unNombre VARCHAR(45), unDomicilio VARCHAR(45))
BEGIN
    UPDATE Estudio
    SET Nombre = unNombre
    AND Domicilio = unDomicilio
    WHERE idEstudio = unId;
END $$



-- ANIME
DELIMITER $$
DROP PROCEDURE if EXISTS altaAnime;

CREATE PROCEDURE altaAnime (out unIdAnime int, unNombre VARCHAR(45), unEpisodios INT, unLanzamiento DATE, unEstado varchar(45) )
BEGIN 
    INSERT INTO Anime (nombre, episodios, lanzamiento, estado)
            VALUE (unNombre, unEpisodios, unLanzamiento, unEstado);
    SET unIdAnime = last_insert_id();
END $$

DROP PROCEDURE IF EXISTS eliminarAnime;
DELIMITER $$
CREATE PROCEDURE eliminarAnime(unId int)
BEGIN
    DELETE FROM Anime
    WHERE idAnime = unId;
END $$

DROP PROCEDURE IF EXISTS ActualizarAnime;

DELIMITER $$
CREATE PROCEDURE ActualizarAnime(unId int, unNombre VARCHAR(45), unEpisodios INT, unLanzamiento DATE, unEstado VARCHAR(45))
BEGIN
    UPDATE Anime
    SET Nombre = unNombre
    AND Episodios = unEpisodios
    AND Lanzamiento = unLanzamiento
    AND Estado = UnEstado
    WHERE idAnime = unId;
END $$
