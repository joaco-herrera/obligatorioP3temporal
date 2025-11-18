using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.Excepciones
{
    public class PagoException : LogicaNegocioException
    {
        public PagoException()
        {
        }
        public PagoException(string? message) : base(message)
        {
        }
    }
}
