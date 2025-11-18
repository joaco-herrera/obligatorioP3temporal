using Libreria.LogicaNegocio.Vo;

namespace Libreria.LogicaNegocio.Entidades
{
    public class PagoUnico : Pago
    {
        public DateTime? FechaPago { get; set; }
        public string? NumeroRecibo { get; set; }

        public PagoUnico() : base() { }

        public PagoUnico(VoDescripcionGasto descripcion, VoMonto monto,
                        int metodoPagoId, int tipoGastoId, int usuarioId,
                        DateTime? fechaPago, string? numeroRecibo)
            : base(descripcion, monto, metodoPagoId, tipoGastoId, usuarioId)
        {
            FechaPago = fechaPago;
            NumeroRecibo = numeroRecibo;
            Validable();
        }

        public override void Validable()
        {
            if (Descripcion == null)
                throw new Exception("La descripción es obligatoria.");
            if (Monto == null)
                throw new Exception("El monto es obligatorio.");
            if (!FechaPago.HasValue)
                throw new Exception("La fecha de pago es obligatoria.");
            if (FechaPago.Value > DateTime.Now.AddDays(1))
                throw new Exception("La fecha de pago no puede ser futura.");
            if (string.IsNullOrWhiteSpace(NumeroRecibo))
                throw new Exception("El número de recibo es obligatorio.");
            if (NumeroRecibo.Length < 3 || NumeroRecibo.Length > 50)
                throw new Exception("El número de recibo debe tener entre 3 y 50 caracteres.");
            if (MetodoPagoId <= 0)
                throw new Exception("Debe seleccionar un método de pago.");
            if (TipoGastoId <= 0)
                throw new Exception("Debe seleccionar un tipo de gasto.");
            if (UsuarioId <= 0)
                throw new Exception("El usuario es obligatorio.");
        }

        public override decimal CalcularMontoTotal()
        {
            return Monto.Value;
        }

        public decimal CalcularSaldoPendiente()
        {
            return 0;
        }
    }
}
