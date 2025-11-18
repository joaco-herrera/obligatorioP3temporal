using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;

namespace Libreria.Infraestructura.AccesoDatos.EF
{
    public class RepositorioPago : IRepositorioPago
    {
        private LibreriaContext _context;

        public RepositorioPago(LibreriaContext context)
        {
            _context = context;
        }

        public void Add(Pago obj)
        {
            _context.Pagos.Add(obj);
            _context.SaveChanges();
        }

        public IEnumerable<Pago> GetAll()
        {
            return _context.Pagos
                .Include(p => p.MetodoPago)
                .Include(p => p.TipoGasto)
                .Include(p => p.Usuario)
                .OrderByDescending(p => p.Id)
                .ToList();
        }

        public Pago GetById(int id)
        {
            var pago = _context.Pagos
                .Include(p => p.MetodoPago)
                .Include(p => p.TipoGasto)
                .Include(p => p.Usuario)
                .FirstOrDefault(p => p.Id == id);

            if (pago == null)
            {
                throw new Exception($"No se encontró el pago con id: {id}");
            }

            return pago;
        }

        public void Update(int id, Pago obj)
        {
            var pagoExistente = _context.Pagos.FirstOrDefault(p => p.Id == id);

            if (pagoExistente == null)
            {
                throw new Exception("No se encontró el pago");
            }

            pagoExistente.Descripcion = obj.Descripcion;
            pagoExistente.Monto = obj.Monto;
            pagoExistente.MetodoPagoId = obj.MetodoPagoId;
            pagoExistente.TipoGastoId = obj.TipoGastoId;

            pagoExistente.Validable();
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var pago = GetById(id);
            _context.Pagos.Remove(pago);
            _context.SaveChanges();
        }

        public IEnumerable<Pago> GetPagosByMesYAnio(int mes, int anio)
        {
            var fechaBuscada = new DateTime(anio, mes, 1);

            return _context.Pagos
                .Include(p => p.MetodoPago)
                .Include(p => p.TipoGasto)
                .Include(p => p.Usuario)
                .AsEnumerable()
                .Where(pago =>
                {
                    if (pago is PagoUnico pagoUnico)
                    {
                        return pagoUnico.FechaPago.HasValue &&
                               pagoUnico.FechaPago.Value.Month == mes &&
                               pagoUnico.FechaPago.Value.Year == anio;
                    }
                    else if (pago is PagoRecurrente pagoRecurrente)
                    {
                        return pagoRecurrente.Periodo != null &&
                               pagoRecurrente.Periodo.FechaDesde.HasValue &&
                               pagoRecurrente.Periodo.FechaHasta.HasValue &&
                               fechaBuscada >= pagoRecurrente.Periodo.FechaDesde.Value &&
                               fechaBuscada <= pagoRecurrente.Periodo.FechaHasta.Value;
                    }
                    return false;
                })
                .ToList();
        }

        public IEnumerable<Usuario> GetUsuariosPorMontoSuperior(decimal monto)
        {
            return _context.Pagos
                .Include(p => p.Usuario)
                .AsEnumerable()
                .GroupBy(p => p.UsuarioId)
                .Select(g => new
                {
                    Usuario = g.First().Usuario,
                    MontoTotal = g.Sum(p => p.CalcularMontoTotal())
                })
                .Where(x => x.MontoTotal > monto)
                .Select(x => x.Usuario)
                .Distinct()
                .OrderBy(u => u.Nombre.Value)
                .ToList();
        }
    }
}