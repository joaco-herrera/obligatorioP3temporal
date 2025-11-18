using Libreria.LogicaNegocio.Entidades;

namespace Libreria.LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioEquipo
    {
        IEnumerable<Equipo> GetAll();
        Equipo GetById(int id);
    }
}