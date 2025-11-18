using Libreria.LogicaAplicacion.Dtos.Pagos;

namespace Libreria.WebApp.Models
{
    public class PagosFiltroViewModel
    {
        public int? Mes { get; set; }
        public int? Anio { get; set; }
        public IEnumerable<PagoDtoListado> Pagos { get; set; } = new List<PagoDtoListado>();
    }
}