using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Libreria.LogicaNegocio.Excepciones
{
    public class NombreException : LogicaNegocioException
    {
        public NombreException()
        {
        }
        public NombreException(string? message) : base(message)
        {
        }
    }
}
