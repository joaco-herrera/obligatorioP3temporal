using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.InterfacesRepositorios;
using Libreria.LogicaNegocio.Excepciones;

namespace Libreria.Infraestructura.AccesoDatos.EF
{
    public class RepositorioTipoGasto : IRepositorioTipoGasto
    {
        private LibreriaContext _context;
        public RepositorioTipoGasto(LibreriaContext context)
        {
            _context = context;
        }

        public void Add(TipoGasto obj)
        {
            _context.TiposGasto.Add(obj);
            _context.SaveChanges();
        }

        public IEnumerable<TipoGasto> GetAll()
        {
            return _context.TiposGasto
                .OrderBy(x => x.Nombre.Value)
                .ToList();
        }

        public TipoGasto GetById(int id)
        {
            TipoGasto unTipoDeGasto = _context.TiposGasto
                  .FirstOrDefault(tipoGasto => tipoGasto.Id == id);
            if (unTipoDeGasto == null)
            {
                throw new Exception("No se encontro el id");
            }
            return unTipoDeGasto;
        }

        public void Update(int id, TipoGasto obj)
        {
            TipoGasto unTipoDeGasto = GetById(id);
            unTipoDeGasto.Update(obj);
            _context.SaveChanges(); 
        }

        public void Delete(int id)
        {
            TipoGasto unTipoDeGasto = GetById(id);

            bool estaEnUso = false;
            foreach (var pago in _context.Pagos)
            {
                if (pago.TipoGastoId == id)
                {
                    estaEnUso = true;
                    break;
                }
            }

            if (estaEnUso)
            {
                throw new TipoGastoEnUsoException("No se puede eliminar el tipo de gasto porque está siendo utilizado en pagos registrados.");
            }

            _context.TiposGasto.Remove(unTipoDeGasto);
            _context.SaveChanges();
        }


    }
}
