using Libreria.LogicaNegocio.Excepciones;
using Libreria.LogicaNegocio.InterfacesDominio;

namespace Libreria.LogicaNegocio.Vo
{
    public record VoNombreGasto : IValidable
    {
        public string Value { get; private set; }

        public VoNombreGasto(string value)
        {
            Value = value;
            Validable();
        }

        public void Validable()
        {
            if (string.IsNullOrWhiteSpace(Value))
                throw new NombreTipoGastoException("El nombre del gasto no puede estar vacío.");

            if (Value.Length < 3)
                throw new NombreTipoGastoException("El nombre del gasto debe tener al menos 3 caracteres.");
        }
    }
}