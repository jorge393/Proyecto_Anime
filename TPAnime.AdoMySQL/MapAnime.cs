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

        public MapAutor MapAutor { get; set; }
        public MapEstudio MapEstudio { get; set; }
        public MapAnime(MapAutor mapAutor, MapEstudio mapEstudio) : this(mapAutor.AdoAGBD)
        {
            MapAutor = mapAutor;
            MapEstudio = mapEstudio;
        }

        #region AltaAnime
        public async Task AltaAnimeAsync(Anime anime)
        => await EjecutarComandoAsync("altaAnime", ConfigurarAltaAnime, PostAltaAnime, anime);

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
        public async Task<List<Anime>> ObtenerAnimeAsync() => await ColeccionDesdeTablaAsync();
        public override Anime ObjetoDesdeFila(DataRow fila)
        =>  new Anime(){
            Id = Convert.ToInt32(fila["idAnime"]),
            Nombre = fila["nombre"].ToString(),
            Genero = fila["genero"].ToString(),
            Episodios = Convert.ToInt32(fila["episodios"]),
            Lanzamiento = Convert.ToDateTime(fila["lanzamiento"]),
            Estado = fila["estado"].ToString(),
            Estudio =  MapEstudio.EstudioPorid(Convert.ToInt32(fila["idEstudio"])),
            Autor =  MapAutor.AutorPorid(Convert.ToInt32(fila["idAutor"])),
        };
        #endregion

        #region AnimePorId
        public async Task<Anime> AnimePoridAsync(int? Id)
        {
            SetComandoSP("llamarAnime");

            BP.CrearParametro("unIdAnime")
              .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
              .SetValor(Id)
              .AgregarParametro();
            return await ElementoDesdeSPAsync();
        }
        #endregion

        #region actualizarAnime
        public async Task actualizarAnimeAsync(Anime anime)
        {
            await EjecutarComandoAsync("actualizarAnime", ConfigurarAltaAnimeActualizado, anime);
        }

        public void ConfigurarAltaAnimeActualizado(Anime anime)
        {
            SetComandoSP("actualizarAnime");

            BP.CrearParametro("unIdAnime")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
            .SetValor(anime.Id)
            .AgregarParametro();
            BP.CrearParametro("unNombre")
            .SetTipoVarchar(45)
            .SetValor(anime.Nombre)
            .AgregarParametro();
            BP.CrearParametro("unGenero")
            .SetTipoVarchar(45)
            .SetValor(anime.Genero)
            .AgregarParametro();
            BP.CrearParametro("unEpisodios")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
            .SetValor(anime.Episodios)
            .AgregarParametro();
            BP.CrearParametro("unLanzamiento")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.DateTime)
            .SetValor(anime.Lanzamiento)
            .AgregarParametro();
            BP.CrearParametro("unEstado")
            .SetTipoVarchar(45)
            .SetValor(anime.Genero)
            .AgregarParametro();
            BP.CrearParametro("unIdEstudio")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
            .SetValor(anime.Estudio.Id)
            .AgregarParametro();
            BP.CrearParametro("unIdAutor")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
            .SetValor(anime.Autor.Id)
            .AgregarParametro();
        }

        #endregion

        #region eliminarAnime
        public async Task eliminarAnimeAsync(Anime anime)
        {

            await EjecutarComandoAsync("eliminarAnime", ConfigurarbajaAnime, anime);
        }
        public void ConfigurarbajaAnime(Anime anime)
        {
            SetComandoSP("eliminarAnime");

            BP.CrearParametro("unIdAnime")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
            .SetValor(anime.Id)
            .AgregarParametro();
        }
        #endregion

    }
}