

namespace Libreria.LogicaNegocio.Excepciones
{
    public class TipoGastoEnUsoException : LogicaNegocioException
    {
        public TipoGastoEnUsoException()
        {
        }

        public TipoGastoEnUsoException(string? message) : base(message)
        {
        }
    }
}
