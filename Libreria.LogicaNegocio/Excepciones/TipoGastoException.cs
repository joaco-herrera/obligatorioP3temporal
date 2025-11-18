using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.Excepciones
{
    public class TipoGastoException : LogicaNegocioException
    {
        public TipoGastoException()
        {
        }
        public TipoGastoException(string? message) : base(message)
        {
        }
    }
}
