DELIMITER $$

CREATE TRIGGER befdeleAutor BEFORE DELETE ON Autor
FOR EACH ROW
BEGIN

    DELETE FROM Anime
    WHERE idAutor = OLD.idAutor;


    -- DECLARE varId INTEGER;
    -- SELECT idAutor INTO varId
    -- FROM Anime
    -- WHERE idAutor = NEW.idAutor;
    -- IF(varId = idAutor)THEN
    -- DELETE IdAutor From Anime WHERE 

END $$