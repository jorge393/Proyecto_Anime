using System;
using System.ComponentModel.DataAnnotations;
using TPAnime.Core;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace TPAnime.MVC.ViewModels
{
    public class VMAnime
    {
        public SelectList? Estudios { get; set; }
        public SelectList? Autores { get; set; }
        public string? NombreAnime { get; set; }
        public string? GeneroAnime { get; set; }
        public int EpisodiosAnime { get; set; }
        public DateTime LanzamientoAnime { get; set; }
        public string? EstadoAnime { get; set; }


        [Range(1, byte.MaxValue, ErrorMessage = "Seleccionar un estudio")]
        public byte IdEstudio { get; set; }

        [Range(1, byte.MaxValue, ErrorMessage = "Seleccionar un Autor")]
        public byte idAutor { get; set; }
        public int IdAnime { get; set; }
        public VMAnime() { }
        public VMAnime(IEnumerable<Estudio> estudios, IEnumerable<Autor> autores)
        {
            Estudios = new SelectList(estudios,
                                    dataTextField: nameof(Estudio.Nombre),
                                    dataValueField: nameof(Estudio.Id));
            Autores = new SelectList(autores,
                                    dataTextField: nameof(Autor.Nombre),
                                    dataValueField: nameof(Autor.Id));
        }
        public VMAnime(IEnumerable<Estudio> estudios, IEnumerable<Autor> autores, Anime anime)
        {
            Estudios = new SelectList(estudios,
                                    dataTextField: nameof(Estudio.Nombre),
                                    dataValueField: nameof(Estudio.Id),
                                    selectedValue: anime.Id);

            Autores = new SelectList(autores,
                                    dataTextField: nameof(Autor.Nombre),
                                    dataValueField: nameof(Autor.Id),
                                    selectedValue: anime.Id);
            NombreAnime = anime.Nombre;
            GeneroAnime = anime.Genero;
            EpisodiosAnime = anime.Episodios;
            LanzamientoAnime = anime.Lanzamiento;
            EstadoAnime = anime.Estado;
            IdAnime = anime.Id;
        }

    }
}