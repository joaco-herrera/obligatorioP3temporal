using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.Excepciones;
using Libreria.LogicaNegocio.InterfacesRepositorios;

namespace Libreria.Infraestructura.AccesoDatos.EF
{
    public class RepositorioEquipo : IRepositorioEquipo
    {
        private LibreriaContext _context;

        public RepositorioEquipo(LibreriaContext context)
        {
            _context = context;
        }

        public IEnumerable<Equipo> GetAll()
        {
            return _context.Equipos
                .OrderBy(x => x.Nombre.Value)
                .ToList();
        }

        public Equipo GetById(int id)
        {
            var equipo = _context.Equipos
                .FirstOrDefault(e => e.Id == id);
            if (equipo == null)
            {
                throw new NombreEquipoException("No se encontró el equipo con id: " + id);
            }
            return equipo;
        }
    }
}