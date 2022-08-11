DELIMITER $$
drop PROCEDURE if EXISTS altaAutor;

CREATE PROCEDURE altaAutor (out unIdAutor int, unNombre VARCHAR(45))
BEGIN 
    INSERT INTO Autor (nombre)
            VALUE (unNombre);
    SET unIdAutor = last_insert_id();
END $$