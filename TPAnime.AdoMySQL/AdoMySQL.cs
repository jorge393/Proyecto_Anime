using System;
using System.Collections.Generic;
using et12.edu.ar.AGBD.Ado;
using TPAnime.Core;

namespace TPAnime.AdoMySQL
{
    public class AdoMySQL : IAdo
    {
        AdoAGBD Ado { get; set; }
        public MapAutor mapAutor { get; set; }
        public MapEstudio mapEstudio { get; set; }
        public MapAnime mapAnime { get; set; }

        public AdoMySQL(AdoAGBD ado)
        {
            Ado = ado;
            mapAutor = new MapAutor(Ado);
            mapEstudio = new MapEstudio(Ado);
            mapAnime = new MapAnime(mapAutor, mapEstudio);
        }
        //AUTOR
        public void altaAutor(Autor autor)
        {
            mapAutor.altaAutor(autor);
        }
        public List<Autor> obtenerAutores()
        {
            return mapAutor.ObtenerAutores();
        }
        public void eliminarAutor(Autor autor) => mapAutor.eliminarAutor(autor);

        public Autor AutorPorid(int id)
        {
            return mapAutor.AutorPorid(id);
        }
        public void actualizarAutor(Autor autor)
        {
            mapAutor.actualizarAutor(autor);
        }

        //ESTUDIO
        public void altaEstudio(Estudio estudio)
        {
            mapEstudio.AltaEstudio(estudio);
        }
        public List<Estudio> obtenerEstudio()
        {
            return mapEstudio.ObtenerEstudios();
        }
        public void eliminarEstudio(Estudio estudio)
        {
            mapEstudio.eliminarEstudio(estudio);
        }

        public Estudio EstudioPorid(int id)
        {
            return mapEstudio.EstudioPorid(id);
        }

        public void actualizarEstudio(Estudio estudio)
        {
            mapEstudio.actualizarEstudio(estudio);
        }

        // ANIME
        public void altaAnime(Anime anime)
        {
            mapAnime.AltaAnime(anime);
        }
        public List<Anime> obtenerAnimes()
        {
            return mapAnime.ObtenerAnime();
        }
        public void eliminarAnime(Anime anime)
        {
            throw new NotImplementedException();
        }




        public void actualizarAnime(Anime anime)
        {
            throw new NotImplementedException();
        }


        public Anime AnimePorid(int id)
        {
            throw new NotImplementedException();
        }
    }
}