using System;
using System.Collections.Generic;

namespace TPAnime.Core;
public class Autor
{
    public int Id {get ;set;}
    public string Nombre {get ;set;}
    public List<Anime> animes;

    public Autor(int id,string nombre)
    {
        Id = id;
        Nombre =nombre;
        animes = new List<Anime>();
    }
}


