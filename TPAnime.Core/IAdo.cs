using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TPAnime.Core
{
    public interface IAdo
    {
        void altaAutor(Autor autor);
        List<Autor> obtenerAutores();

        void altaEstudio(Estudio estudio);
        List<Estudio> obtenerEstudio();

        void altaAnime(Anime anime);
        List<Anime> obtenerAnimes(Autor autor, Estudio estudio);


        void eliminarAutor(Autor autor);
        void eliminarEstudio(Estudio estudio);
        void eliminarAnime(Anime anime);

        void actualizarAutor(Autor autor);
        void actualizarEstudio(Autor autor);
        void actualizarAnime(Autor autor);


        Autor AutorPorid(int id);
        Autor EstudioPorid(int id);
        Autor AnimePorid(int id);



    }
}