using et12.edu.ar.AGBD.Ado;
using et12.edu.ar.AGBD.Mapeadores;
using System.Data;
using TPAnime.Core;

namespace TPAnime.AdoMySQL
{
    public class MapAutor : Mapeador<Autor>
    {
        public MapAutor(AdoAGBD ado) : base(ado) => Tabla = "Autor";

        #region AltaAutores
        public void altaAutor(Autor autor)
        {
            EjecutarComandoCon("altaAutor", ConfigurarAltaAutor, PostAltaAutor, autor);
        }
        public void ConfigurarAltaAutor(Autor autor)
        {
            SetComandoSP("altaAutor");

            BP.CrearParametroSalida("unidAutor").SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32).AgregarParametro();

            BP.CrearParametro("unNombre").SetTipoVarchar(45).SetValor(autor.Nombre).AgregarParametro();
        }

        public void PostAltaAutor(Autor autor)
        => autor.Id = Convert.ToInt32(GetParametro("unidAutor").Value);

        public Autor AutorPorid(int Id)
        {
            SetComandoSP("llamarAutor");

            BP.CrearParametro("unidAutor")
              .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
              .SetValor(Id)
              .AgregarParametro();

            return ElementoDesdeSP();
        }
        #endregion

        #region ObtenerAutores
        public List<Autor> ObtenerAutores() => ColeccionDesdeTabla();
        public override Autor ObjetoDesdeFila(DataRow fila)
        => new Autor()
        {
            Id = Convert.ToInt32(fila["idAutor"]),
            Nombre = fila["nombre"].ToString()

        };
        #endregion

        #region eliminarAutor
        public void eliminarAutor(Autor autor)
        {

            EjecutarComandoCon("eliminarAutor", ConfigurarbajaAutor, autor);
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
            
            public void actualizarAutor(Autor autor)
            {
                EjecutarComandoCon("actualizarAutor", ConfigurarAltaAutorActualizado, autor);
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
            }

        #endregion
    }
}