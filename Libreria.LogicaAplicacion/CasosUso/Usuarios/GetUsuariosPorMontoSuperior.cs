using Libreria.LogicaNegocio.InterfacesRepositorios;

namespace Libreria.LogicaAplicacion.CasosUso.Usuarios
{
    public class GetUsuariosPorMontoSuperior
    {
        private readonly IRepositorioPago _repoPago;
        private readonly IRepositorioUsuario _repoUsuario;

        public GetUsuariosPorMontoSuperior(IRepositorioPago repoPago, IRepositorioUsuario repoUsuario)
        {
            _repoPago = repoPago;
            _repoUsuario = repoUsuario;
        }

        public IEnumerable<UsuarioConMontoDtoListado> Execute(decimal monto)
        {
            var usuarios = _repoPago.GetUsuariosPorMontoSuperior(monto);
            var resultado = new List<UsuarioConMontoDtoListado>();

            foreach (var usuario in usuarios)
            {
                decimal montoTotal = 0;
                var todosPagos = _repoPago.GetAll();

                var pagosDelUsuario = new List<Libreria.LogicaNegocio.Entidades.Pago>();
                foreach (var pago in todosPagos)
                {
                    if (pago.UsuarioId == usuario.Id)
                    {
                        pagosDelUsuario.Add(pago);
                    }
                }

                foreach (var pago in pagosDelUsuario)
                {
                    montoTotal += pago.CalcularMontoTotal();
                }

                var dto = new UsuarioConMontoDtoListado(
                    usuario.Id,
                    usuario.Nombre.Value,
                    usuario.Apellido.Value,
                    usuario.Email.Value,
                    montoTotal
                );

                resultado.Add(dto);
            }

            return resultado;
        }
    }
}