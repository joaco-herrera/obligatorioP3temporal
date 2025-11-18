using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.Excepciones
{
    public class RolException : LogicaNegocioException
    {
        public RolException()
        {
        }

        public RolException(string? message) : base(message)
        {
        }
    }
}
