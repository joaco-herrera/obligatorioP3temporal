using Libreria.LogicaNegocio.Entidades;

namespace Libreria.LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioMetodoPago :
        IRepositorioGetAll<MetodoPago>,
        IRepositorioGetById<MetodoPago>
    {
    }
}