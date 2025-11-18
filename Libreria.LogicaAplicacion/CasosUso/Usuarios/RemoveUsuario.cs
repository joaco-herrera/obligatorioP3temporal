using Libreria.LogicaAplicacion.Dtos.Usuarios;
using Libreria.LogicaAplicacion.Mapper;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.InterfacesLogicaAplicacion;
using Libreria.LogicaNegocio.InterfacesRepositorios;


namespace Libreria.LogicaAplicacion.CasosUso.Usuarios
{
    public class RemoveUsuario : ICUDelete<UsuarioDtoAlta>
    {
        private IRepositorioUsuario _repo;
        private IRepositorioAuditoria _auditoria;

        public RemoveUsuario(IRepositorioUsuario repo, IRepositorioAuditoria auditoria)
        {
            _repo = repo;
            _auditoria = auditoria;
        }
        public void Execute(int id)
        {
            _repo.Delete(id);

            var log = new Auditoria("DELETE", "Usuario", id, "Admin", "Eliminó usuario");
            _auditoria.Registrar(log);

        }
    }
}

