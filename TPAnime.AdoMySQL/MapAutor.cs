using et12.edu.ar.AGBD.Ado;
using et12.edu.ar.AGBD.Mapeadores;
using System.Data;
using TPAnime.Core;
using System;

namespace TPAnime.AdoMySQL
{
    public class MapAutor : Mapeador<Autor>
    {
        // public Anime anime { get; set; }
        public MapAutor(AdoAGBD ado) : base(ado) => Tabla = "Autor";

        #region AltaAutores
        public async Task altaAutorAsync(Autor autor)
        {
            await EjecutarComandoAsync("altaAutor", ConfigurarAltaAutor, PostAltaAutor, autor);
        }
        public void ConfigurarAltaAutor(Autor autor)
        {
            SetComandoSP("altaAutor");

            BP.CrearParametroSalida("unidAutor")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
            .AgregarParametro();

            BP.CrearParametro("unNombre")
            .SetTipoVarchar(45).
            SetValor(autor.Nombre).
            AgregarParametro();

            BP.CrearParametro("unApellido").
            SetTipoVarchar(45).
            SetValor(autor.Apellido).
            AgregarParametro();

        }

        public void PostAltaAutor(Autor autor)
        => autor.Id = Convert.ToInt32(GetParametro("unidAutor").Value);
        #endregion


        public async Task<Autor> AutorPoridAsync(int Id)
        {
            SetComandoSP("llamarAutor");

            BP.CrearParametro("unidAutor")
              .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
              .SetValor(Id)
              .AgregarParametro();

            return await ElementoDesdeSPAsync();
        }

         public Autor AutorPorid(int Id)
        {
            SetComandoSP("llamarAutor");

            BP.CrearParametro("unidAutor")
              .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
              .SetValor(Id)
              .AgregarParametro();

            return ElementoDesdeSP();
        }

        #region ObtenerAutores
        public async Task<List<Autor>> ObtenerAutoresAsync() => await ColeccionDesdeTablaAsync();

        public override Autor ObjetoDesdeFila(DataRow fila)
        => new Autor()
        {
            Id = Convert.ToInt32(fila["idAutor"]),
            Nombre = fila["nombre"].ToString(),
            Apellido = fila["apellido"].ToString()
        };
        #endregion

        #region eliminarAutor
        public async Task eliminarAutorAsync(Autor autor)
        {
            await EjecutarComandoAsync("eliminarAutor", ConfigurarbajaAutor, autor);
        }
        public void ConfigurarbajaAutor(Autor autor)
        {

            SetComandoSP("eliminarAutor");

            BP.CrearParametro("unIdAutor")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
            .SetValor(autor.Id)
            .AgregarParametro();
        }
        #endregion

        #region actualizarAutor

        public async Task actualizarAutorAsync(Autor autor)
        {
            await EjecutarComandoAsync("actualizarAutor", ConfigurarAltaAutorActualizado, autor);
        }

        public void ConfigurarAltaAutorActualizado(Autor autor)
        {
            SetComandoSP("actualizarAutor");

            BP.CrearParametro("unIdAutor")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
            .SetValor(autor.Id)
            .AgregarParametro();

            BP.CrearParametro("unNombre")
            .SetTipoVarchar(45)
            .SetValor(autor.Nombre)
            .AgregarParametro();

            BP.CrearParametro("unApellido")
            .SetTipoVarchar(45)
            .SetValor(autor.Apellido)
            .AgregarParametro();
        }
        #endregion
    }
}