using Libreria.LogicaAplicacion.Dtos.Pagos;
using Libreria.LogicaAplicacion.CasosUso.Pagos;
using Libreria.LogicaNegocio.InterfacesLogicaAplicacion;
using Microsoft.AspNetCore.Mvc;

namespace Libreria.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagosController : ControllerBase
    {
        private readonly ICUGetById<PagoDtoDetalle> _getById;

        public PagosController(ICUGetById<PagoDtoDetalle> getById)
        {
            _getById = getById;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var pago = _getById.Execute(id);

                return Ok(pago); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = ex.Message });
            }
        }
    }
}