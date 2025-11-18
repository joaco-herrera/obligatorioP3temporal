using Libreria.LogicaAplicacion.Dtos.Usuarios;
using Libreria.LogicaAplicacion.Mapper;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.InterfacesLogicaAplicacion;
using Libreria.LogicaNegocio.InterfacesRepositorios;

namespace Libreria.LogicaAplicacion.CasosUso.Usuarios
{
    public class AddUsuario : ICUAdd<UsuarioDtoAlta>
    {
        private IRepositorioUsuario _repo;
        private IRepositorioAuditoria _auditoria;

        public AddUsuario(IRepositorioUsuario repo, IRepositorioAuditoria auditoria)
        {
            _repo = repo;
            _auditoria = auditoria;
        }

        public void Execute(UsuarioDtoAlta usuariodto)
        {
            var usuario = UsuarioMapper.FromDto(usuariodto, _repo);
            _repo.Add(usuario);
            var log = new Auditoria("CREATE", "Usuario", usuario.Id, "Admin", $"Creó usuario: {usuario.Nombre.Value} {usuario.Apellido.Value}");
            _auditoria.Registrar(log);
        }
    }
}