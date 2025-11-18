namespace Libreria.LogicaAplicacion.CasosUso.Usuarios
{
    public record UsuarioConMontoDtoListado(
        int Id,
        string Nombre,
        string Apellido,
        string Email,
        decimal MontoTotal
    )
    {
    }
}