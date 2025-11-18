using Libreria.LogicaAplicacion.Dtos.Pagos;
using Libreria.LogicaAplicacion.Mapper;
using Libreria.LogicaNegocio.InterfacesRepositorios;

namespace Libreria.LogicaAplicacion.CasosUso.Pagos
{
    public class GetPagosByMesYAnio
    {
        private readonly IRepositorioPago _repo;

        public GetPagosByMesYAnio(IRepositorioPago repo)
        {
            _repo = repo;
        }

        public IEnumerable<PagoDtoListado> Execute(int mes, int anio)
        {
            var pagos = _repo.GetPagosByMesYAnio(mes, anio);
            return PagoMapper.ToListDto(pagos);
        }
    }
}