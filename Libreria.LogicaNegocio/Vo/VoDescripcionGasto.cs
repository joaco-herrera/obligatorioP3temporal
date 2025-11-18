using Libreria.LogicaNegocio.Excepciones;
using Libreria.LogicaNegocio.InterfacesDominio;

namespace Libreria.LogicaNegocio.Vo
{
    public record VoDescripcionGasto : IValidable
    {
        public string Value { get; private set; }

        public VoDescripcionGasto(string value)
        {
            Value = value;
            Validable();
        }

        public void Validable()
        {
            if (string.IsNullOrWhiteSpace(Value))
                throw new DescripcionTipoGastoException("La descripción no puede estar vacía.");
        }
    }
}
