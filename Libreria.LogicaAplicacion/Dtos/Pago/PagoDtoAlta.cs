namespace Libreria.LogicaAplicacion.Dtos.Pagos
{
    public record PagoDtoAlta(
        string TipoPago, 
        string Descripcion,
        decimal Monto,
        int MetodoPagoId,
        int TipoGastoId,
        int UsuarioId,
        DateTime? FechaPago,
        string? NumeroRecibo,
        DateTime? FechaDesde,
        DateTime? FechaHasta
    );
}