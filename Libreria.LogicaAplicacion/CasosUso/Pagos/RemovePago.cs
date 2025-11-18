using Libreria.LogicaNegocio.InterfacesLogicaAplicacion;
using Libreria.LogicaNegocio.InterfacesRepositorios;
using Libreria.LogicaAplicacion.Dtos.Pagos;

namespace Libreria.LogicaAplicacion.CasosUso.Pagos
{
    public class RemovePago : ICUDelete<PagoDtoAlta>
    {
        private IRepositorioPago _repo;

        public RemovePago(IRepositorioPago repo)
        {
            _repo = repo;
        }

        public void Execute(int id)
        {
            _repo.Delete(id);
        }
    }
}