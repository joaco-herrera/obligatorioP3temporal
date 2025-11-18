using Libreria.LogicaNegocio.Entidades;

namespace Libreria.LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioUsuario :
        IRepositorioAdd<Usuario>,
        IRepositorioGetAll<Usuario>,
        IRepositorioGetById<Usuario>,
        IRepositorioDelete<Usuario>,
        IRepositorioUpdate<Usuario>
    {
        bool ExisteEmail(string email);
        string GenerarEmailUnico(string nombre, string apellido);
    }
}
