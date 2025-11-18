using Libreria.LogicaNegocio.Vo;

namespace Libreria.LogicaNegocio.Entidades
{
    public class PagoRecurrente : Pago
    {
        public VoPeriodoPago Periodo { get; set; }

        public PagoRecurrente() : base() { }

        public PagoRecurrente(VoDescripcionGasto descripcion, VoMonto monto,
                             int metodoPagoId, int tipoGastoId, int usuarioId,
                             VoPeriodoPago periodo)
            : base( descripcion, monto, metodoPagoId, tipoGastoId, usuarioId)
        {
            Periodo = periodo;
            Validable();
        }

        public override void Validable()
        {
            if (Descripcion == null)
                throw new Exception("La descripción es obligatoria.");

            if (Monto == null)
                throw new Exception("El monto es obligatorio.");

            if (Periodo == null)
                throw new Exception("El período es obligatorio.");

            if (MetodoPagoId <= 0)
                throw new Exception("Debe seleccionar un método de pago.");

            if (TipoGastoId <= 0)
                throw new Exception("Debe seleccionar un tipo de gasto.");

            if (UsuarioId <= 0)
                throw new Exception("El usuario es obligatorio.");
        }

        public override decimal CalcularMontoTotal()
        {
            int cantidadMeses = Periodo.CalcularCantidadMeses();
            return Monto.Value * cantidadMeses;
        }

        public decimal CalcularSaldoPendiente(DateTime fechaActual)
        {
            if (!Periodo.FechaDesde.HasValue || !Periodo.FechaHasta.HasValue)
                return 0;

            if (fechaActual >= Periodo.FechaHasta.Value)
                return 0; 

            if (fechaActual < Periodo.FechaDesde.Value)
            {
                return CalcularMontoTotal();
            }

            int mesesRestantes = ((Periodo.FechaHasta.Value.Year - fechaActual.Year) * 12) +
                                (Periodo.FechaHasta.Value.Month - fechaActual.Month);

            if (mesesRestantes < 0) mesesRestantes = 0;

            return Monto.Value * mesesRestantes;
        }
    }
}