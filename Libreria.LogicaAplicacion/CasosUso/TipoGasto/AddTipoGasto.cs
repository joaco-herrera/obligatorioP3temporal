using Libreria.LogicaAplicacion.Dtos.TipoGasto;
using Libreria.LogicaAplicacion.Mapper;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.InterfacesLogicaAplicacion;
using Libreria.LogicaNegocio.InterfacesRepositorios;

namespace Libreria.LogicaAplicacion.CasosUso.TipoGasto
{
    public class AddTipoGasto : ICUAdd<TipoGastoDtoAlta>
    {
        private IRepositorioTipoGasto _repo;
        private IRepositorioAuditoria _auditoria;

        public AddTipoGasto(IRepositorioTipoGasto repo, IRepositorioAuditoria auditoria)
        {
            _repo = repo;
            _auditoria = auditoria;
        }

        public void Execute(TipoGastoDtoAlta tipoGastodto)
        {
            var tipoGasto = TipoGastoMapper.FromDto(tipoGastodto);
            _repo.Add(tipoGasto);

            var log = new Auditoria("CREATE", "TipoGasto", tipoGasto.Id, "Admin", $"Creó: {tipoGasto.Nombre.Value}");
            _auditoria.Registrar(log);
        }
    }
}
