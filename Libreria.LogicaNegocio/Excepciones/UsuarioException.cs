

namespace Libreria.LogicaNegocio.Excepciones
{
    public class UsuarioException : LogicaNegocioException
    {
        public UsuarioException()
        {
        }
        public UsuarioException(string? message) : base(message)
        {
        }
    }
}
