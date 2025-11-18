using Libreria.LogicaNegocio.InterfacesDominio;
using Libreria.LogicaNegocio.Vo;

namespace Libreria.LogicaNegocio.Entidades
{
    public abstract class Pago : IEntity, IValidable
    {
        public int Id { get; set; }
        public VoDescripcionGasto Descripcion { get; set; }
        public VoMonto Monto { get; set; }

        public int MetodoPagoId { get; set; }
        public MetodoPago MetodoPago { get; set; }

        public int TipoGastoId { get; set; }
        public TipoGasto TipoGasto { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        protected Pago() { }

        protected Pago(VoDescripcionGasto descripcion, VoMonto monto,
                      int metodoPagoId, int tipoGastoId, int usuarioId)
        {
            Descripcion = descripcion;
            Monto = monto;
            MetodoPagoId = metodoPagoId;
            TipoGastoId = tipoGastoId;
            UsuarioId = usuarioId;
        }

        public abstract void Validable();
        public abstract decimal CalcularMontoTotal();
    }
}