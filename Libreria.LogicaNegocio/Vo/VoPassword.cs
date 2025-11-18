using Libreria.LogicaNegocio.Excepciones;
using Libreria.LogicaNegocio.InterfacesDominio;

namespace Libreria.LogicaNegocio.Vo
{
    public record VoPassword : IValidable
    {
        public string Value { get; private set; }
        public VoPassword(string value)
        {
            Value = value;
            Validable(); 
        }
        public void Validable()
        {
            if (string.IsNullOrEmpty(Value))
                throw new PasswordException("El password no puede estar vacío");
            if (Value.Length < 8)
                throw new PasswordException("El password debe tener al menos 8 caracteres");
        }
    }
}