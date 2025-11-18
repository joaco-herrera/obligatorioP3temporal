using Libreria.LogicaNegocio.InterfacesLogicaAplicacion;
using Libreria.LogicaNegocio.InterfacesRepositorios;
using Libreria.LogicaAplicacion.Dtos.MetodosPago;
using Libreria.LogicaAplicacion.Mapper;

namespace Libreria.LogicaAplicacion.CasosUso.MetodosPago
{
    public class GetAllMetodosPago : ICUGetAll<MetodoPagoDtoListado>
    {
        private IRepositorioMetodoPago _repo;

        public GetAllMetodosPago(IRepositorioMetodoPago repo)
        {
            _repo = repo;
        }

        public IEnumerable<MetodoPagoDtoListado> Execute()
        {
            var metodosPago = _repo.GetAll();
            return MetodoPagoMapper.ToListDto(metodosPago);
        }
    }
}