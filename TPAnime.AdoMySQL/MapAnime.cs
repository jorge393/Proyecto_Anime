using et12.edu.ar.AGBD.Ado;
using et12.edu.ar.AGBD.Mapeadores;
using System;
using System.Data;
using System.Collections.Generic;
using TPAnime.Core;

namespace TPAnime.AdoMySQL
{
    public class MapAnime : Mapeador<Anime>
    {
        public MapAnime(AdoAGBD ado) : base(ado) => Tabla = "Anime";

        public MapAutor mapAutor { get; set; }
        public MapEstudio mapEstudio { get; set; }
        public MapAnime(MapAutor MapAutor, MapEstudio MapEstudio) : this(MapAutor.AdoAGBD)
        {
            MapAutor = mapAutor;
            MapEstudio = mapEstudio;
        }

        #region AltaAnime
            public void AltaAnime(Anime anime)
            => EjecutarComandoCon("altaAnime", ConfigurarAltaAnime, PostAltaAnime, anime);

            private void ConfigurarAltaAnime(Anime anime)
            {
                SetComandoSP("altaAnime");

                BP.CrearParametroSalida("unIdAnime").SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32).AgregarParametro();

                BP.CrearParametro("unnombre").SetTipoVarchar(45).SetValor(anime.Nombre).AgregarParametro();

                BP.CrearParametro("ungenero").SetTipoVarchar(45).SetValor(anime.Genero).AgregarParametro();

                BP.CrearParametro("unEpisodios").SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32).SetValor(anime.Episodios).AgregarParametro();

                BP.CrearParametro("unlanzamiento").SetTipo(MySql.Data.MySqlClient.MySqlDbType.DateTime).SetValor(anime.Lanzamiento).AgregarParametro();

                BP.CrearParametro("unestado").SetTipoVarchar(45).SetValor(anime.Estado).AgregarParametro();

                BP.CrearParametro("unIdAutor").SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32).SetValor(anime.Autor.Id).AgregarParametro();

                BP.CrearParametro("unIdEstudio").SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32).SetValor(anime.Estudio.Id).AgregarParametro();

            }
            public void PostAltaAnime(Anime anime)
                => anime.Id = Convert.ToInt32(GetParametro("unidAnime").Value);    
        #endregion
        
        #region ObtenerAnimes
            public List<Anime> ObtenerAnime() => ColeccionDesdeTabla();
            public override Anime ObjetoDesdeFila(DataRow fila)
            => new Anime()
            {
                Id = Convert.ToInt32(fila["idAnime"]),
                Nombre = fila["nombre"].ToString(),
                Genero = fila["genero"].ToString(),
                Episodios = Convert.ToInt32(fila["episodios"]),
                Lanzamiento = Convert.ToDateTime(fila["Lanzamiento"]),
                Estado = fila["estado"].ToString(),
                Autor = mapAutor.AutorPorid(Convert.ToInt32(fila["idautor"])),
                Estudio = mapEstudio.EstudioPorid(Convert.ToInt32(fila["idestudio"]))
            };
            public List<Anime> ObtenerAnime(Autor autor, Estudio estudio)
            {
                SetComandoSP("llamarAutor");

                BP.CrearParametro("unidAutor")
                .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
                .SetValor(autor.Id)
                .AgregarParametro();

                SetComandoSP("llamarEstudio");

                BP.CrearParametro("unidEstudio")
                .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
                .SetValor(estudio.Id)
                .AgregarParametro();

                return ColeccionDesdeSP();
            }    
        #endregion
        
    }
}