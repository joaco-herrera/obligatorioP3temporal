using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.Excepciones
{
    public class NombreTipoGastoException : LogicaNegocioException
    {
        public NombreTipoGastoException()
        {
        }
        public NombreTipoGastoException(string? message) : base(message)
        {
        }
    }
}