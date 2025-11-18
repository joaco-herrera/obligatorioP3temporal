namespace Libreria.LogicaAplicacion.Dtos.Pagos
{
    public record PagoDtoListado(
        int Id,
        string Descripcion,
        decimal Monto,
        decimal MontoTotal,
        string TipoPago,
        string MetodoPago,
        string TipoGasto,
        string Usuario,

        DateTime? FechaPago,
        string? NumeroRecibo,

        DateTime? FechaDesde,
        DateTime? FechaHasta,
        decimal? SaldoPendiente
    );
}