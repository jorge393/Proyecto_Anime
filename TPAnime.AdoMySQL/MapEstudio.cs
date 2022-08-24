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
        public MapEstudio(AdoAGBD ado) : base(ado)
        {
            Tabla = "Estudio";
        }
        public override Estudio ObjetoDesdeFila(DataRow fila)
        => new Estudio()
        {
            Id = Convert.ToInt32(fila["idEstudio"]),
            Nombre = fila["nombre"].ToString(),
            Domicilio = fila["Domicilio"].ToString()
        };

        public void AltaEstudio(Estudio estudio)
            => EjecutarComandoCon("altaEstudio", ConfigurarAltaEstudio, PostAltaEstudio, estudio);

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

        public Estudio EstudioPorid(int Id)
        {
            SetComandoSP("llamarEstudio");

            BP.CrearParametro("unIdEstudio")
              .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
              .SetValor(Id)
              .AgregarParametro();

            return ElementoDesdeSP();
        }
        public List<Estudio> ObtenerEstudios() => ColeccionDesdeTabla();
    }
}