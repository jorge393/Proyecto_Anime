DELIMITER $$
CREATE TRIGGER befdeleteAutor BEFORE DELETE ON Autor
FOR EACH ROW
BEGIN
     DELETE FROM Anime
     WHERE idAutor = OLD.idAutor;
END $$

DELIMITER $$
CREATE TRIGGER befdeleteEstudio BEFORE DELETE ON Estudio
FOR EACH ROW
BEGIN
     DELETE FROM Estudio
     WHERE idEstudio = OLD.idEstudio;
END $$