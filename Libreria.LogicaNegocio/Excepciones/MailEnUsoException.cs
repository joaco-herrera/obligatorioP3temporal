
namespace Libreria.LogicaNegocio.Excepciones
{
    public class MailEnUsoException : LogicaNegocioException
    {
        public MailEnUsoException()
        {
        }

        public MailEnUsoException(string? message) : base(message)
        {
        }
    }
}