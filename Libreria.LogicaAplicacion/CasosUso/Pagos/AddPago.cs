using Libreria.LogicaNegocio.InterfacesLogicaAplicacion;
using Libreria.LogicaNegocio.InterfacesRepositorios;
using Libreria.LogicaAplicacion.Dtos.Pagos;
using Libreria.LogicaAplicacion.Mapper;

namespace Libreria.LogicaAplicacion.CasosUso.Pagos
{
    public class AddPago : ICUAdd<PagoDtoAlta>
    {
        private IRepositorioPago _repo;

        public AddPago(IRepositorioPago repo)
        {
            _repo = repo;
        }

        public void Execute(PagoDtoAlta dto)
        {
            var pago = PagoMapper.FromDto(dto);
            _repo.Add(pago);
        }
    }
}