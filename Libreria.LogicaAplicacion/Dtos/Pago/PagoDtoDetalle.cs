namespace Libreria.LogicaAplicacion.Dtos.Pagos
{
    public record PagoDtoDetalle(
        int Id,
        string Descripcion,
        decimal Monto,
        decimal MontoTotal,
        string TipoPago,
        MetodoPagoDtoDetalle MetodoPago,
        TipoGastoDtoDetalle TipoGasto,
        UsuarioDtoDetalle Usuario,
        DateTime? FechaPago,
        string? NumeroRecibo,
        DateTime? FechaDesde,
        DateTime? FechaHasta,
        int? CantidadMeses,
        decimal? SaldoPendiente
    );

    public record MetodoPagoDtoDetalle(int Id, string Tipo);
    public record TipoGastoDtoDetalle(int Id, string Nombre, string Descripcion);
    public record UsuarioDtoDetalle(int Id, string Nombre, string Apellido, string Email);
}