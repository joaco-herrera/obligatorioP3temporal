using Libreria.LogicaNegocio.Excepciones;
using Libreria.LogicaNegocio.InterfacesDominio;

namespace Libreria.LogicaNegocio.Vo
{
    public record VoNombreEquipo : IValidable
    {
        public string Value { get; private set; }

        public VoNombreEquipo(string value)
        {
            Value = value;
            Validable();
        }

        public void Validable()
        {
            if (string.IsNullOrEmpty(Value))
                throw new NombreEquipoException("El nombre del equipo no puede estar vacio");
        }

    }
}
