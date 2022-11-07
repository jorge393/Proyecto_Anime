﻿using System;
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
        public async Task altaAutor(Autor autor)
        {
            await mapAutor.altaAutor(autor);
        }
        Task<List<Autor>> IAdo.obtenerAutoresAsync()
        {
            return mapAutor.ObtenerAutoresAsync();
        }
        public void eliminarAutor(Autor autor) => mapAutor.eliminarAutor(autor);

        public async Task<Autor> AutorPoridAsync(int id)
        {
            return await mapAutor.AutorPoridAsync(id);
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
        public Anime AnimePorid(int? id)
        {
            return mapAnime.AnimePorid(id);
        }
        public void eliminarAnime(Anime anime)
        {
            mapAnime.eliminarAnime(anime);
        }
        public void actualizarAnime(Anime anime)
        {
            mapAnime.actualizarAnime(anime);
        }
    }
}