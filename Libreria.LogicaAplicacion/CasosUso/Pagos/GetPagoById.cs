using Libreria.LogicaNegocio.InterfacesLogicaAplicacion;
using Libreria.LogicaNegocio.InterfacesRepositorios;
using Libreria.LogicaAplicacion.Dtos.Pagos;
using Libreria.LogicaAplicacion.Mapper;

namespace Libreria.LogicaAplicacion.CasosUso.Pagos
{
    public class GetPagoById : ICUGetById<PagoDtoDetalle>
    {
        private IRepositorioPago _repo;

        public GetPagoById(IRepositorioPago repo)
        {
            _repo = repo;
        }

        public PagoDtoDetalle Execute(int id)
        {
            var pago = _repo.GetById(id);
            return PagoMapper.ToDetalleDto(pago);
        }
    }
}