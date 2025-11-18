using Libreria.LogicaNegocio.Excepciones;
using Libreria.LogicaNegocio.InterfacesDominio;

namespace Libreria.LogicaNegocio.Vo
{
    public record VoApellido : IValidable
    {
        public string Value { get; private set; }

        public VoApellido(string value)
        {
            Value = value;
            Validable(); 
        }

        public void Validable()
        {
            if (string.IsNullOrEmpty(Value))
                throw new ApellidoException("El apellido no puede estar vacío");

            if (Value.Length < 2) 
                throw new ApellidoException("El apellido debe tener al menos 2 caracteres");
        }
    }
}

