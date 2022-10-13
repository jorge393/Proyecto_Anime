using System;
using System.ComponentModel.DataAnnotations;
using TPAnime.Core;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace TPAnime.MVC.ViewModels
{
    public class VMEstudio
    {
        public SelectList? Estudios {get;set;}
        public SelectList? Autores {get;set;}
        public string? NombreAnime {get;set;}

        [Range(1,byte.MaxValue, ErrorMessage = "Seleccionar un estudio")]
        public byte IdEstudio {get;set;}
        public int IdAnime {get;set;}
        public VMEstudio(){ }
        public VMEstudio(IEnumerable<Estudio> estudios, IEnumerable<Autor> autor)
        {
            Estudios = new SelectList(estudios,
                                    dataTextField: nameof(Estudio.Nombre),
                                    dataValueField: nameof(Estudio.Id));
            Autores = new SelectList(autor,
                                    dataTextField: nameof(Autor.Nombre),
                                    dataValueField: nameof(Autor.Id));
        }
        public VMEstudio(IEnumerable<Estudio> estudios, IEnumerable<Autor> autor, Anime anime)
        {
            Estudios = new SelectList(estudios,
                                    dataTextField: nameof(Estudio.Nombre),
                                    dataValueField: nameof(Estudio.Id),
                                    selectedValue: anime.Id);
            Autores = new SelectList(autor,
                                    dataTextField: nameof(Autor.Nombre),
                                    dataValueField: nameof(Autor.Id),
                                    selectedValue: anime.Id);
            NombreAnime = anime.Nombre;
            IdAnime = anime.Id;
        }

    }
}