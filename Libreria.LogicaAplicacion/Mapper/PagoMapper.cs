using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.Vo;
using Libreria.LogicaAplicacion.Dtos.Pagos;

namespace Libreria.LogicaAplicacion.Mapper
{
    public class PagoMapper
    {
        public static PagoDtoListado ToDto(Pago pago)
        {
            DateTime? fechaPago = null;
            string? numeroRecibo = null;
            DateTime? fechaDesde = null;
            DateTime? fechaHasta = null;
            decimal? saldoPendiente = null;
            string tipoPago = "";

            if (pago is PagoUnico pagoUnico)
            {
                fechaPago = pagoUnico.FechaPago;
                numeroRecibo = pagoUnico.NumeroRecibo;
                saldoPendiente = pagoUnico.CalcularSaldoPendiente();
                tipoPago = "Único";
            }
            else if (pago is PagoRecurrente pagoRecurrente)
            {
                fechaDesde = pagoRecurrente.Periodo.FechaDesde;
                fechaHasta = pagoRecurrente.Periodo.FechaHasta;
                saldoPendiente = pagoRecurrente.CalcularSaldoPendiente(DateTime.Now);
                tipoPago = "Recurrente";
            }
            return new PagoDtoListado(
                pago.Id,
                pago.Descripcion.Value,
                pago.Monto.Value,
                pago.CalcularMontoTotal(),
                tipoPago,
                pago.MetodoPago.Tipo,
                pago.TipoGasto.Nombre.Value,
                $"{pago.Usuario.Nombre.Value} {pago.Usuario.Apellido.Value}",
                fechaPago,
                numeroRecibo,
                fechaDesde,
                fechaHasta,
                saldoPendiente
            );
        }

        public static IEnumerable<PagoDtoListado> ToListDto(IEnumerable<Pago> pagos)
        {
            List<PagoDtoListado> pagosListadoDto = new List<PagoDtoListado>();
            foreach (var item in pagos)
            {
                pagosListadoDto.Add(ToDto(item));
            }
            return pagosListadoDto;
        }

        public static PagoDtoDetalle ToDetalleDto(Pago pago)
        {
            DateTime? fechaPago = null;
            string? numeroRecibo = null;
            DateTime? fechaDesde = null;
            DateTime? fechaHasta = null;
            int? cantidadMeses = null;
            decimal? saldoPendiente = null;
            string tipoPago = "";

            if (pago is PagoUnico pagoUnico)
            {
                fechaPago = pagoUnico.FechaPago;
                numeroRecibo = pagoUnico.NumeroRecibo;
                saldoPendiente = pagoUnico.CalcularSaldoPendiente();
                tipoPago = "Único";
            }
            else if (pago is PagoRecurrente pagoRecurrente)
            {
                fechaDesde = pagoRecurrente.Periodo.FechaDesde;
                fechaHasta = pagoRecurrente.Periodo.FechaHasta;
                cantidadMeses = pagoRecurrente.Periodo.CalcularCantidadMeses();
                saldoPendiente = pagoRecurrente.CalcularSaldoPendiente(DateTime.Now);
                tipoPago = "Recurrente";
            }

            return new PagoDtoDetalle(
                pago.Id,
                pago.Descripcion.Value,
                pago.Monto.Value,
                pago.CalcularMontoTotal(),
                tipoPago,
                new MetodoPagoDtoDetalle(pago.MetodoPago.Id, pago.MetodoPago.Tipo),
                new TipoGastoDtoDetalle(pago.TipoGasto.Id, pago.TipoGasto.Nombre.Value, pago.TipoGasto.Descripcion.Value),
                new UsuarioDtoDetalle(pago.Usuario.Id, pago.Usuario.Nombre.Value, pago.Usuario.Apellido.Value, pago.Usuario.Email.Value),
                fechaPago,
                numeroRecibo,
                fechaDesde,
                fechaHasta,
                cantidadMeses,
                saldoPendiente
            );
        }

        public static Pago FromDto(PagoDtoAlta dto)
        {
            var descripcion = new VoDescripcionGasto(dto.Descripcion);
            var monto = new VoMonto(dto.Monto);

            if (dto.TipoPago == "Unico")
            {
                if (!dto.FechaPago.HasValue)
                    throw new Exception("La fecha de pago es obligatoria para pagos únicos.");
                if (string.IsNullOrWhiteSpace(dto.NumeroRecibo))
                    throw new Exception("El número de recibo es obligatorio para pagos únicos.");
                return new PagoUnico(
                    descripcion,
                    monto,
                    dto.MetodoPagoId,
                    dto.TipoGastoId,
                    dto.UsuarioId,
                    dto.FechaPago.Value,
                    dto.NumeroRecibo
                );
            }
            else if (dto.TipoPago == "Recurrente")
            {
                if (!dto.FechaDesde.HasValue || !dto.FechaHasta.HasValue)
                    throw new Exception("Las fechas desde y hasta son obligatorias para pagos recurrentes.");

                var periodo = new VoPeriodoPago(dto.FechaDesde.Value, dto.FechaHasta.Value);
                return new PagoRecurrente(
                    descripcion,
                    monto,
                    dto.MetodoPagoId,
                    dto.TipoGastoId,
                    dto.UsuarioId,
                    periodo
                );
            }
            else
            {
                throw new Exception("Tipo de pago no válido. Debe ser 'Unico' o 'Recurrente'.");
            }
        }
    }
}