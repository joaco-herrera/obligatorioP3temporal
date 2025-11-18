using Libreria.LogicaAplicacion.Dtos.TipoGasto;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.Vo;

namespace Libreria.LogicaAplicacion.Mapper
{
    public class TipoGastoMapper
    {
        public static TipoGasto FromDto(TipoGastoDtoAlta tipoGastoDto)
        {
            return new TipoGasto(
                                new VoNombreGasto(tipoGastoDto.Nombre),
                                new VoDescripcionGasto(tipoGastoDto.Descripcion));
        }

        public static TipoGastoDtoListado ToDto(TipoGasto tipoGasto)
        {
            return new TipoGastoDtoListado(
                                         tipoGasto.Id,
                                         tipoGasto.Nombre.Value,
                                         tipoGasto.Descripcion.Value
                                         );
        }

        public static IEnumerable<TipoGastoDtoListado> ToListDto(IEnumerable<TipoGasto> gastos)
        {
            List<TipoGastoDtoListado> tipoGastoListadoDto = new List<TipoGastoDtoListado>();
            foreach (var item in gastos)
            {
                tipoGastoListadoDto.Add(ToDto(item));
            }
            return tipoGastoListadoDto;
        }
    }
}
