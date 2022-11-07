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
        public async Task altaAutorAsync(Autor autor) => await mapAutor.altaAutorAsync(autor);
        
        async Task<List<Autor>> IAdo.obtenerAutoresAsync() => await mapAutor.ObtenerAutoresAsync();
        
        public async Task eliminarAutorAsync(Autor autor) => await mapAutor.eliminarAutorAsync(autor);

        public async Task<Autor> AutorPoridAsync(int id) => await mapAutor.AutorPoridAsync(id);
        
        public async Task actualizarAutorAsync(Autor autor) => await mapAutor.actualizarAutorAsync(autor);
        

        //ESTUDIO
        public async Task altaEstudioAsync(Estudio estudio) => await mapEstudio.AltaEstudioaAsync(estudio);
        
        public async Task<List<Estudio>> obtenerEstudioAsync() => await mapEstudio.ObtenerEstudiosAsync();
        public async Task eliminarEstudioAsync(Estudio estudio) => await mapEstudio.eliminarEstudioAsync(estudio);
        
        public async Task<Estudio> EstudioPoridAsync(int id) => await mapEstudio.EstudioPoridAsync(id);
        
        public async Task actualizarEstudioAsync(Estudio estudio) => await mapEstudio.actualizarEstudioAsync(estudio);
        

        // ANIME
        public async Task altaAnimeAsync(Anime anime)
        {
            await mapAnime.AltaAnimeAsync(anime);
        }
        public async Task<List<Anime>> obtenerAnimesAsync()
        {
            return await  mapAnime.ObtenerAnimeAsync();
        }
        public async Task<Anime> AnimePoridAsync(int? id)
        {
            return await mapAnime.AnimePoridAsync(id);
        }
        public async Task eliminarAnimeAsync(Anime anime)
        {
            await mapAnime.eliminarAnimeAsync(anime);
        }
        public async Task actualizarAnimeAsync(Anime anime)
        {
            await mapAnime.actualizarAnimeAsync(anime);
        }
    }
}