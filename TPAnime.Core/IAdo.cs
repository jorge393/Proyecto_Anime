using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TPAnime.Core
{
    public interface IAdo
    {
        #region Autor
        Task altaAutorAsync(Autor autor);
        Task<List<Autor>> obtenerAutoresAsync();
        Task actualizarAutorAsync(Autor autor);
        Task eliminarAutorAsync(Autor autor);
        Task<Autor> AutorPoridAsync(int id);
        #endregion

        #region Estudio
        Task altaEstudioAsync(Estudio estudio);
        Task<List<Estudio>> obtenerEstudioAsync();
        Task eliminarEstudioAsync(Estudio estudio);
        Task actualizarEstudioAsync(Estudio estudio);
        Task<Estudio> EstudioPoridAsync(int id);
        #endregion

        #region Anime
        Task altaAnimeAsync(Anime anime);
        // List<Anime> obtenerAnimes(Autor autor, Estudio estudio);
        Task<List<Anime>> obtenerAnimesAsync();
        Task<Anime> AnimePoridAsync(int? id);
        Task eliminarAnimeAsync(Anime anime);
        Task actualizarAnimeAsync(Anime anime);
        #endregion


    }
}