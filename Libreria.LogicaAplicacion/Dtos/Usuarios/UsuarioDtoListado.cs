

namespace Libreria.LogicaAplicacion.Dtos.Usuarios
{
    public record UsuarioDtoListado(
                                int Id,
                                string Nombre,
                                string Apellido,
                                string Email,
                                string Password,
                                string Rol,
                                int EquipoId,
                                string NombreEquipo
                                )
    {
    }
}
