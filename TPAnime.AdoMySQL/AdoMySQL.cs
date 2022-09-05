using System;
using System.Collections.Generic;
using et12.edu.ar.AGBD.Ado;
using TPAnime.Core;

namespace TPAnime.AdoMySQL
{
    public class AdoMySQL : IAdo
    {
        AdoAGBD Ado {get;set;}
        public MapAutor mapAutor {get;set;}
        public MapEstudio mapEstudio {get;set;}
        public MapAnime mapAnime {get;set;}
        
        public AdoMySQL(AdoAGBD ado)
        {
            Ado = ado;
            mapAutor = new MapAutor(Ado);
            mapEstudio = new MapEstudio(Ado);
            mapAnime = new MapAnime(mapAutor);
            mapAnime = new MapAnime(mapEstudio);

        }
        public void altaAutor(Autor autor) => mapAutor.altaAutor(autor);
        public List<Autor> obtenerAutores() => mapAutor.ObtenerAutores();

        public void altaEstudio(Estudio estudio) => mapEstudio.AltaEstudio(estudio);
        public List<Estudio> obtenerEstudio() => mapEstudio.ObtenerEstudios();
        



        public void altaAnime(Anime anime) => mapAnime.ObtenerAnime();
        
        public List<Anime> obtenerAnimes(Autor autor, Estudio estudio)
            => mapAnime.ObtenerAnime(autor,estudio);

        public List<Anime> obtenerAnimes()
        {
            throw new NotImplementedException();
        }
    }
}