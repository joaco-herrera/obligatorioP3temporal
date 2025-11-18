using Libreria.LogicaNegocio.InterfacesDominio;

namespace Libreria.LogicaNegocio.Vo
{
    public record VoMonto : IValidable
    {
        public decimal Value { get; private set; }

        public VoMonto(decimal value)
        {
            Value = value;
            Validable();
        }

        public void Validable()
        {
            if (Value <= 0)
                throw new Exception("El monto debe ser mayor a cero.");

            if (Value > 999999999.99m)
                throw new Exception("El monto supera el límite permitido.");
        }
    }
}