using et12.edu.ar.AGBD.Ado;
using et12.edu.ar.AGBD.Mapeadores;
using System;
using System.Data;
using System.Collections.Generic;
using TPAnime.Core;

namespace TPAnime.AdoMySQL
{
    public class MapEstudio : Mapeador<Estudio>
    {
        public MapEstudio(AdoAGBD ado) : base(ado) => Tabla = "Estudio";

        public override Estudio ObjetoDesdeFila(DataRow fila)
        => new Estudio()
        {
            Id = Convert.ToInt32(fila["idEstudio"]),
            Nombre = fila["nombre"].ToString(),
            Domicilio = fila["Domicilio"].ToString()
        };

        #region AltaEstudio

        public async Task AltaEstudioaAsync(Estudio estudio)
            => await EjecutarComandoAsync("altaEstudio", ConfigurarAltaEstudio, PostAltaEstudio, estudio);


        public void ConfigurarAltaEstudio(Estudio estudio)
        {
            SetComandoSP("altaEstudio");

            BP.CrearParametroSalida("unIdEstudio")
              .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UByte)
              .AgregarParametro();

            BP.CrearParametro("unNombre")
              .SetTipoVarchar(45)
              .SetValor(estudio.Nombre)
              .AgregarParametro();

            BP.CrearParametro("unDomicilio")
              .SetTipoVarchar(45)
              .SetValor(estudio.Domicilio)
              .AgregarParametro();
        }

        public void PostAltaEstudio(Estudio estudio)
        {
            var paramIdEstudio = GetParametro("unIdEstudio");
            estudio.Id = Convert.ToByte(paramIdEstudio.Value);
        }

        #endregion

        #region estudioPorid

        public async Task<Estudio> EstudioPoridAsync(int Id)
        {
            SetComandoSP("llamarEstudio");

            BP.CrearParametro("unIdEstudio")
              .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
              .SetValor(Id)
              .AgregarParametro();

            return await ElementoDesdeSPAsync();
        }

        public Estudio EstudioPorid(int Id)
        {
            SetComandoSP("llamarEstudio");

            BP.CrearParametro("unIdEstudio")
              .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
              .SetValor(Id)
              .AgregarParametro();

            return ElementoDesdeSP();
        }
        #endregion

        #region eliminarEstudio
        public async Task eliminarEstudioAsync(Estudio estudio)
        {
            await EjecutarComandoAsync("eliminarEstudio", ConfigurarbajaEstudio, estudio);
        }

        public void ConfigurarbajaEstudio(Estudio estudio)
        {
            SetComandoSP("eliminarEstudio");

            BP.CrearParametro("unIdEstudio")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
            .SetValor(estudio.Id)
            .AgregarParametro();
        }
        #endregion

        #region actualizarEstudio
        public async Task actualizarEstudioAsync(Estudio estudio)
        {
            await EjecutarComandoAsync("actualizarEstudio", ConfigurarAltaEstudioActualizado, estudio);
        }


        public void ConfigurarAltaEstudioActualizado(Estudio estudio)
        {
            SetComandoSP("actualizarEstudio");

            BP.CrearParametro("unIdEstudio")
                .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
                .SetValor(estudio.Id)
                .AgregarParametro();

            BP.CrearParametro("unNombre")
                .SetTipoVarchar(45)
                .SetValor(estudio.Nombre)
                .AgregarParametro();

            BP.CrearParametro("unDomicilio")
                .SetTipoVarchar(45)
                .SetValor(estudio.Domicilio)
                .AgregarParametro();
        }
        #endregion

        public async Task<List<Estudio>> ObtenerEstudiosAsync() => await ColeccionDesdeTablaAsync();
    }
}