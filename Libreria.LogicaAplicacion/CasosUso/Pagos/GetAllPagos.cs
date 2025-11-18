using Libreria.LogicaNegocio.InterfacesLogicaAplicacion;
using Libreria.LogicaNegocio.InterfacesRepositorios;
using Libreria.LogicaAplicacion.Dtos.Pagos;
using Libreria.LogicaAplicacion.Mapper;

namespace Libreria.LogicaAplicacion.CasosUso.Pagos
{
    public class GetAllPagos : ICUGetAll<PagoDtoListado>
    {
        private IRepositorioPago _repo;

        public GetAllPagos(IRepositorioPago repo)
        {
            _repo = repo;
        }

        public IEnumerable<PagoDtoListado> Execute()
        {
            var pagos = _repo.GetAll();
            return PagoMapper.ToListDto(pagos);
        }
    }
}