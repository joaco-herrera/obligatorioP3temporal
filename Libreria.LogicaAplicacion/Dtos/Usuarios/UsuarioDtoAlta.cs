namespace Libreria.LogicaAplicacion.Dtos.Usuarios
{
    public record UsuarioDtoAlta(
        string Nombre,
        string Apellido,
        string? Email,            
        string Password,
        string Rol,
        int EquipoId = 2
    )
    {
    }
}
