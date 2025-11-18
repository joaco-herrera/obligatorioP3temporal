using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.Excepciones
{
    public class ApellidoException : LogicaNegocioException
    {
        public ApellidoException()
        {
        }

        public ApellidoException(string? message) : base(message)
        {
        }
    }
}