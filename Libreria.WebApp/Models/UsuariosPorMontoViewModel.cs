using Libreria.LogicaAplicacion.CasosUso.Usuarios;

namespace Libreria.WebApp.Models
{
    public class UsuariosPorMontoViewModel
    {
        public decimal? Monto { get; set; }
        public IEnumerable<UsuarioConMontoDtoListado> Usuarios { get; set; } = new List<UsuarioConMontoDtoListado>();
    }
}