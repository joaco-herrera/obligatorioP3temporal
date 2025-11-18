using Libreria.LogicaNegocio.Excepciones;
using Libreria.LogicaNegocio.InterfacesDominio;

namespace Libreria.LogicaNegocio.Vo
{
    public record VoRol : IValidable
    {
        public string Value { get; private set; }

        private VoRol() { }

        public VoRol(string value)
        {
            Value = value;
            Validable();
        }

        public void Validable()
        {
            if (string.IsNullOrEmpty(Value))
                throw new RolException("El rol no puede estar vacio");
        }

    }
}
