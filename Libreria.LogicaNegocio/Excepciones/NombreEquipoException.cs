using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.Excepciones
{
    public class NombreEquipoException : LogicaNegocioException
    {
        public NombreEquipoException()
        {
        }

        public NombreEquipoException(string? message) : base(message)
        {
        }
    }
}
