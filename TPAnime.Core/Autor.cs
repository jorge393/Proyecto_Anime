using System;
using System.Collections.Generic;

namespace TPAnime.Core;
public class Autor
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public List<Anime> animes;
    public Autor() { }
    public Autor(string nombre)
    {
        Nombre = nombre;
        animes = new List<Anime>();
    }
}


