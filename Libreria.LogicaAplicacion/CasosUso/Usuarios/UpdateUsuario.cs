using Libreria.LogicaAplicacion.Dtos.Usuarios;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.InterfacesLogicaAplicacion;
using Libreria.LogicaNegocio.InterfacesRepositorios;
using Libreria.LogicaNegocio.Vo;

namespace Libreria.LogicaAplicacion.CasosUso.Usuarios
{
    public class UpdateUsuario : ICUUpdate<UsuarioDtoAlta>
    {
        private IRepositorioUsuario _repo;
        private IRepositorioAuditoria _auditoria;

        public UpdateUsuario(IRepositorioUsuario repo, IRepositorioAuditoria auditoria)
        {
            _repo = repo;
            _auditoria = auditoria;
        }

        public void Execute(int id, UsuarioDtoAlta dto)
        {
            var usuarioActualizado = Usuario.CrearPorRol(
                new VoNombre(dto.Nombre),
                new VoApellido(dto.Apellido),
                new VoEmail(dto.Email),
                new VoPassword(dto.Password),
                dto.Rol,
                dto.EquipoId
            );
            _repo.Update(id, usuarioActualizado);
            var log = new Auditoria("UPDATE", "Usuario", id, "Admin", $"Modificó usuario: {usuarioActualizado.Nombre.Value}");
            _auditoria.Registrar(log);
        }
    }
}