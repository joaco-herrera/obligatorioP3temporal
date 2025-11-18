using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.InterfacesRepositorios;

namespace Libreria.Infraestructura.AccesoDatos.EF
{
    public class RepositorioMetodoPago : IRepositorioMetodoPago
    {
        private LibreriaContext _context;

        public RepositorioMetodoPago(LibreriaContext context)
        {
            _context = context;
        }

        public IEnumerable<MetodoPago> GetAll()
        {
            return _context.MetodosPago
                .OrderBy(m => m.Tipo)
                .ToList();
        }

        public MetodoPago GetById(int id)
        {
            var metodoPago = _context.MetodosPago
                .FirstOrDefault(m => m.Id == id);

            if (metodoPago == null)
            {
                throw new Exception($"No se encontró el método de pago con id: {id}");
            }

            return metodoPago;
        }
    }
}