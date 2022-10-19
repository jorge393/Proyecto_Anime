
-- AUTOR
DELIMITER $$
DROP PROCEDURE IF EXISTS altaAutor $$

CREATE PROCEDURE altaAutor (out unIdAutor int, unNombre VARCHAR(45), unApellido VARCHAR(45))
BEGIN 
    INSERT INTO Autor (nombre, apellido)
            VALUE (unNombre, unApellido);
    SET unIdAutor = last_insert_id();
END $$

DELIMITER $$
DROP PROCEDURE IF EXISTS llamarAutor;
CREATE PROCEDURE llamarAutor(unIdAutor int)
BEGIN
    SELECT *
    FROM Autor
    WHERE idAutor = unIdAutor;
END $$

DELIMITER $$
DROP PROCEDURE IF EXISTS eliminarAutor $$
CREATE PROCEDURE eliminarAutor(unIdAutor int)
BEGIN
    DELETE FROM Autor
    WHERE idAutor = unIdAutor;
END $$

DELIMITER $$
DROP PROCEDURE IF EXISTS actualizarAutor $$
CREATE PROCEDURE actualizarAutor(unIdAutor int, unNombre VARCHAR(45), unApellido VARCHAR(45))
BEGIN
    UPDATE Autor
    SET nombre = unNombre,
        apellido = unApellido
    WHERE idAutor = unIdAutor;
END $$





-- ESTUDIO
DELIMITER $$
DROP PROCEDURE if EXISTS altaEstudio $$

CREATE PROCEDURE altaEstudio (out unIdEstudio int, unNombre VARCHAR(45), unDomicilio VARCHAR(45))
BEGIN 
    INSERT INTO Estudio (nombre, domicilio)
            VALUE (unNombre, unDomicilio);
    SET unIdEstudio = last_insert_id();
END $$
DROP PROCEDURE IF EXISTS llamarEstudio;
CREATE PROCEDURE llamarEstudio(unIdEstudio int)
BEGIN
    SELECT *
    FROM Estudio
    WHERE idEstudio = unIdEstudio;
END $$

DELIMITER $$
DROP PROCEDURE IF EXISTS eliminarEstudio $$
CREATE PROCEDURE eliminarEstudio(unIdEstudio int)
BEGIN
    DELETE FROM Estudio
    WHERE idEstudio = unIdEstudio;
END $$


DELIMITER $$
DROP PROCEDURE IF EXISTS ActualizarEstudio $$
CREATE PROCEDURE ActualizarEstudio(unIdEstudio int, unNombre VARCHAR(45), unDomicilio VARCHAR(45))
BEGIN
    UPDATE Estudio
    SET Nombre = unNombre,
        Domicilio = unDomicilio
    WHERE idEstudio = unIdEstudio;
END $$



-- ANIME
DELIMITER $$
DROP PROCEDURE if EXISTS altaAnime $$

CREATE PROCEDURE altaAnime (out unIdAnime int, unNombre VARCHAR(45),ungenero varchar(45), unEpisodios INT, unLanzamiento DATE, unEstado varchar(45) )
BEGIN 
    INSERT INTO Anime (nombre, genero, episodios, lanzamiento, estado)
            VALUE (unNombre, ungenero, unEpisodios, unLanzamiento, unEstado);
    SET unIdAnime = last_insert_id();
END $$

DELIMITER $$
DROP PROCEDURE IF EXISTS eliminarAnime $$
CREATE PROCEDURE eliminarAnime(unId int)
BEGIN
    DELETE FROM Anime
    WHERE idAnime = unId;
END $$


DELIMITER $$
DROP PROCEDURE IF EXISTS ActualizarAnime $$
CREATE PROCEDURE ActualizarAnime(unId int, unNombre VARCHAR(45), unEpisodios INT, unLanzamiento DATE, unEstado VARCHAR(45))
BEGIN
    UPDATE Anime
    SET Nombre = unNombre
    AND Episodios = unEpisodios
    AND Lanzamiento = unLanzamiento
    AND Estado = UnEstado
    WHERE idAnime = unId;
END $$
