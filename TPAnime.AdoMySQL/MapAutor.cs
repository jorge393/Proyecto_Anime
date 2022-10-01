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

        //DAR DE ALTA AUTORES
        public void altaAutor(Autor autor)
        {
            EjecutarComandoCon("altaAutor", ConfigurarAltaAutor, PostAltaAutor, autor);
        } 
        public void ConfigurarAltaAutor(Autor autor)
        {
            SetComandoSP("altaAutor");

            BP.CrearParametroSalida("unidAutor")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
            .AgregarParametro();

            BP.CrearParametro("unNombre")
            .SetTipoVarchar(45)
            .SetValor(autor.Nombre)
            .AgregarParametro();
        }

        public void PostAltaAutor(Autor autor)
        => autor.Id = Convert.ToInt32(GetParametro("unidAutor").Value);

        public Autor AutorPorid(int Id)
        {
            SetComandoSP("llamarAutor");

            BP.CrearParametro("unIdAutor")
              .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
              .SetValor(Id)
              .AgregarParametro();

            return ElementoDesdeSP();
        }






        //OBTENER AUTORES
        public List<Autor> ObtenerAutores() => ColeccionDesdeTabla();


        //ELIMINAR AUTORES
        public void eliminarAutor(Autor autor)
        {

            EjecutarComandoCon("eliminarAutor", buscarAutor, autor);
        } 

        public void buscarAutor(Autor autor){


            // int num = 0;
            List<Autor> autores = new List<Autor>();
            autores.Remove(autor);
            // foreach (Autor item in autores)
            // {
            //     if (item == autor)
            //     {
            //         num = item.Id;
            //     }
            // }
            
        }
        // public void borrarAutor()
        // {

        // }
            
    }
}