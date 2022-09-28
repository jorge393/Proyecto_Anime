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
        List<Anime> obtenerAnimes();


        void eliminarAutor(Autor autor);
        void eliminarEstudio(Autor autor);
        void eliminarAnime(Autor autor);


    }
}