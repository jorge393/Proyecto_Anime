using et12.edu.ar.AGBD.Ado;
using et12.edu.ar.AGBD.Mapeadores;
using System;
using System.Data;
using System.Collections.Generic;
using TPAnime.Core;

namespace TPAnime.AdoMySQL
{
    public class MapAutor : Mapeador<Autor>
    {
        public MapAutor(AdoAGBD ado) : base(ado)
        {
            Tabla = "Autor";
        }

        public override Autor ObjetoDesdeFila(DataRow fila)
        => new Autor()
        {
            Id = Convert.ToInt32(fila["idAutor"]),
            Nombre = fila["Nombre"].ToString() 
        
        };

        public void altaAutor(Autor autor)
        => EjecutarComandoCon("altaAutor", ConfigurarAltaAutor, PostAltaAutor, autor);
        public void ConfigurarAltaAutor(Autor autor)
        {
            SetComandoSP("AltaAutor");

            BP.CrearParametroSalida("unidAutor")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
            .AgregarParametro();

            BP.CrearParametro("unnombre")
            .SetTipoVarchar(45)
            .SetValor(autor.Nombre)
            .AgregarParametro();
        }
        public void PostAltaAutor(Autor autor)
        => autor.Id = Convert.ToInt32(GetParametro("unidAutor").Value);
    }
        public List<Autor> obtenerAutores() => ColeccionDesdeTabla();
}