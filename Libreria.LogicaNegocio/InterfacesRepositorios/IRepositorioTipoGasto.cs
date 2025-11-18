using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Libreria.LogicaNegocio.Entidades;

namespace Libreria.LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioTipoGasto :
        IRepositorioAdd<TipoGasto>,
        IRepositorioGetAll<TipoGasto>,
        IRepositorioGetById<TipoGasto>,
        IRepositorioDelete<TipoGasto>,
        IRepositorioUpdate<TipoGasto>
    {
    }
} 