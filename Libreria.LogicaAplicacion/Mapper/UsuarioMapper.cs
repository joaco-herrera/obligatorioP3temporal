using Libreria.LogicaAplicacion.Dtos.Usuarios;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.InterfacesRepositorios;
using Libreria.LogicaNegocio.Vo;
using Libreria.LogicaNegocio.Utilidades;

namespace Libreria.LogicaAplicacion.Mapper
{
    public class UsuarioMapper
    {

        public static Usuario FromDto(UsuarioDtoAlta dto, IRepositorioUsuario repo)
        {
            int equipoId = dto.EquipoId > 0 ? dto.EquipoId : 1;

            string emailUnico = repo.GenerarEmailUnico(dto.Nombre, dto.Apellido);

            return dto.Rol switch
            {
                "Admin" => new Admin(
                    new VoNombre(dto.Nombre),
                    new VoApellido(dto.Apellido),
                    new VoEmail(emailUnico),
                    new VoPassword(dto.Password),
                    equipoId
                ),
                "Gerente" => new Gerente(
                    new VoNombre(dto.Nombre),
                    new VoApellido(dto.Apellido),
                    new VoEmail(emailUnico),
                    new VoPassword(dto.Password),
                    equipoId
                ),
                _ => new Empleado(
                    new VoNombre(dto.Nombre),
                    new VoApellido(dto.Apellido),
                    new VoEmail(emailUnico),
                    new VoPassword(dto.Password),
                    equipoId
                )
            };
        }

        public static UsuarioDtoListado ToDto(Usuario usuario)
        {
            return new UsuarioDtoListado(
                usuario.Id,
                usuario.Nombre.Value,
                usuario.Apellido.Value,
                usuario.Email.Value,
                usuario.Password.Value,
                usuario.Rol,
                usuario.EquipoId,
                usuario.Equipo?.Nombre.Value ?? "Sin equipo"
            );
        }

        public static IEnumerable<UsuarioDtoListado> ToListDto(IEnumerable<Usuario> usuarios)
        {
            List<UsuarioDtoListado> usuariosListadoDto = new List<UsuarioDtoListado>();
            foreach (var item in usuarios)
            {
                usuariosListadoDto.Add(ToDto(item));
            }
            return usuariosListadoDto;
        }
    }
}