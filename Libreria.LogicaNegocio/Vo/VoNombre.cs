using Libreria.LogicaNegocio.Excepciones;
using Libreria.LogicaNegocio.InterfacesDominio;

namespace Libreria.LogicaNegocio.Vo
{
    public record VoNombre : IValidable 
    {
        public string Value { get; private set; }

        public VoNombre(string value)
        {
            Value = value;
            Validable();
        }

        public void Validable()
        {
            if (string.IsNullOrEmpty(Value))
                throw new NombreException("El nombre no puede estar vacio");
        }

    }
}
