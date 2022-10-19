using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TPAnime.Core
{
    public interface IAdo
    {
        #region Autor
        void altaAutor(Autor autor);
        List<Autor> obtenerAutores();
        void eliminarAutor(Autor autor);
        void actualizarAutor(Autor autor);
        Autor AutorPorid(int id);
        #endregion

        #region Estudio
        void altaEstudio(Estudio estudio);
        List<Estudio> obtenerEstudio();
        void eliminarEstudio(Estudio estudio);
        void actualizarEstudio(Estudio estudio);
        Estudio EstudioPorid(int id);
        #endregion

        #region Anime
        void altaAnime(Anime anime);
        // List<Anime> obtenerAnimes(Autor autor, Estudio estudio);
        List<Anime> obtenerAnimes();
        Anime AnimePorid(int? id);
        void eliminarAnime(Anime anime);
        void actualizarAnime(Anime anime);
        #endregion


    }
}