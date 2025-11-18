using Libreria.LogicaAplicacion.Dtos.TipoGasto;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.InterfacesLogicaAplicacion;
using Libreria.LogicaNegocio.InterfacesRepositorios;

namespace Libreria.LogicaAplicacion.CasosUso.TipoGasto
{
    public class RemoveTipoGasto : ICUDelete<TipoGastoDtoAlta>
    {
        private readonly IRepositorioTipoGasto _repo;
        private readonly IRepositorioAuditoria _auditoria;

        public RemoveTipoGasto(IRepositorioTipoGasto repo, IRepositorioAuditoria auditoria)
        {
            _repo = repo;
            _auditoria = auditoria;
        }

        public void Execute(int id)
        {
            _repo.Delete(id);

            var log = new Auditoria("DELETE", "TipoGasto", id, "Admin", "Eliminó tipo de gasto");
            _auditoria.Registrar(log);
        }
    }
}