using Libreria.LogicaNegocio.Entidades;

namespace Libreria.LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioPago :
        IRepositorioAdd<Pago>,
        IRepositorioGetAll<Pago>,
        IRepositorioGetById<Pago>,
        IRepositorioDelete<Pago>,
        IRepositorioUpdate<Pago>
    {
        IEnumerable<Pago> GetPagosByMesYAnio(int mes, int anio);
        IEnumerable<Usuario> GetUsuariosPorMontoSuperior(decimal monto);
    }
}