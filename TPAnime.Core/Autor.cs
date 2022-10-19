﻿using System;
using System.Collections.Generic;

namespace TPAnime.Core;
public class Autor
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? Apellido { get; set; }

    public Autor() { }
    public Autor(string nombre, string apellido)
    {
        Nombre = nombre;
        Apellido = apellido;
    }
}


