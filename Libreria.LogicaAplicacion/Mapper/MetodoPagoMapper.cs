using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaAplicacion.Dtos.MetodosPago;

namespace Libreria.LogicaAplicacion.Mapper
{
    public class MetodoPagoMapper
    {
        public static MetodoPagoDtoListado ToDto(MetodoPago metodoPago)
        {
            return new MetodoPagoDtoListado(
                metodoPago.Id,
                metodoPago.Tipo
            );
        }

        public static IEnumerable<MetodoPagoDtoListado> ToListDto(IEnumerable<MetodoPago> metodosPago)
        {
            List<MetodoPagoDtoListado> metodosListadoDto = new List<MetodoPagoDtoListado>();
            foreach (var item in metodosPago)
            {
                metodosListadoDto.Add(ToDto(item));
            }
            return metodosListadoDto;
        }
    }
}
