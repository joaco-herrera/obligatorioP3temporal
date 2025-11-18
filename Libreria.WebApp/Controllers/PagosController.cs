using Libreria.LogicaAplicacion.CasosUso.Pagos;
using Libreria.WebApp.Filter;
using Libreria.LogicaAplicacion.Dtos.MetodosPago;
using Libreria.LogicaAplicacion.Dtos.Pagos;
using Libreria.LogicaAplicacion.Dtos.TipoGasto;
using Libreria.LogicaNegocio.InterfacesLogicaAplicacion;
using Libreria.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Libreria.WebApp.Controllers
{
    public class PagosController : Controller
    {
        private readonly ICUAdd<PagoDtoAlta> _addPago;
        private readonly ICUGetAll<MetodoPagoDtoListado> _getAllMetodosPago;
        private readonly ICUGetAll<TipoGastoDtoListado> _getAllTiposGasto;
        private readonly ICUGetAll<PagoDtoListado> _getAllPagos;
        private readonly GetPagosByMesYAnio _getPagosByMesYAnio; 
        public PagosController(
            ICUAdd<PagoDtoAlta> addPago,
            ICUGetAll<MetodoPagoDtoListado> getAllMetodosPago,
            ICUGetAll<TipoGastoDtoListado> getAllTiposGasto,
            ICUGetAll<PagoDtoListado> getAllPagos,
            GetPagosByMesYAnio getPagosByMesYAnio) 
        {
            _addPago = addPago;
            _getAllMetodosPago = getAllMetodosPago;
            _getAllTiposGasto = getAllTiposGasto;
            _getAllPagos = getAllPagos;
            _getPagosByMesYAnio = getPagosByMesYAnio; 
        }

        [GerenteAutorizado]
        public IActionResult Index(int? mes, int? anio)
        {
            try
            {
                var viewModel = new PagosFiltroViewModel();
                if (mes.HasValue && anio.HasValue)
                {
                    viewModel.Mes = mes.Value;
                    viewModel.Anio = anio.Value;
                    viewModel.Pagos = _getPagosByMesYAnio.Execute(mes.Value, anio.Value);
                }
                else
                {
                    viewModel.Mes = null;
                    viewModel.Anio = null;
                    viewModel.Pagos = _getAllPagos.Execute();
                }
                return View(viewModel);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error al cargar los pagos: {ex.Message}";
                return RedirectToAction("Index", "Home");
            }
        }
        public IActionResult Create()
        {
            var userId = HttpContext.Session.GetInt32("userId");
            if (userId == null)
            {
                TempData["ErrorMessage"] = "Debe iniciar sesión para registrar un pago.";
                return RedirectToAction("Index", "Login");
            }
            var viewModel = new PagoCreateViewModel();
            var metodosPagoList = new List<SelectListItem>();
            var metodosPago = _getAllMetodosPago.Execute();
            foreach (var metodo in metodosPago)
            {
                metodosPagoList.Add(new SelectListItem
                {
                    Value = metodo.Id.ToString(),
                    Text = metodo.Tipo
                });
            }
            viewModel.MetodosPago = metodosPagoList;
            var tiposGastoList = new List<SelectListItem>();
            var tiposGasto = _getAllTiposGasto.Execute();
            foreach (var tipo in tiposGasto)
            {
                tiposGastoList.Add(new SelectListItem
                {
                    Value = tipo.Id.ToString(),
                    Text = tipo.Nombre
                });
            }
            viewModel.TiposGasto = tiposGastoList;
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PagoCreateViewModel viewModel)
        {
            Console.WriteLine("=== INICIO POST CREATE ===");
            Console.WriteLine($"TipoPago: {viewModel.TipoPago}");
            Console.WriteLine($"Descripcion: {viewModel.Descripcion}");
            Console.WriteLine($"Monto: {viewModel.Monto}");
            try
            {
                var userId = HttpContext.Session.GetInt32("userId");
                Console.WriteLine($"UserId de sesión: {userId}");
                if (userId == null)
                {
                    Console.WriteLine("ERROR: Usuario no logueado");
                    TempData["ErrorMessage"] = "Debe iniciar sesión para registrar un pago.";
                    return RedirectToAction("Index", "Login");
                }
                if (viewModel.TipoPago == "Unico")
                {
                    if (!viewModel.FechaPago.HasValue)
                    {
                        ModelState.AddModelError("FechaPago", "La fecha de pago es obligatoria para pagos únicos.");
                    }
                    if (string.IsNullOrWhiteSpace(viewModel.NumeroRecibo))
                    {
                        ModelState.AddModelError("NumeroRecibo", "El número de recibo es obligatorio para pagos únicos.");
                    }
                }
                else if (viewModel.TipoPago == "Recurrente")
                {
                    if (!viewModel.FechaDesde.HasValue)
                    {
                        ModelState.AddModelError("FechaDesde", "La fecha desde es obligatoria para pagos recurrentes.");
                    }
                    if (!viewModel.FechaHasta.HasValue)
                    {
                        ModelState.AddModelError("FechaHasta", "La fecha hasta es obligatoria para pagos recurrentes.");
                    }
                    if (viewModel.FechaDesde.HasValue && viewModel.FechaHasta.HasValue &&
                        viewModel.FechaDesde >= viewModel.FechaHasta)
                    {
                        ModelState.AddModelError("FechaHasta", "La fecha hasta debe ser posterior a la fecha desde.");
                    }
                }
                Console.WriteLine($"ModelState.IsValid: {ModelState.IsValid}");
                if (!ModelState.IsValid)
                {
                    Console.WriteLine("ERROR: ModelState no válido");
                    foreach (var error in ModelState)
                    {
                        Console.WriteLine($"Key: {error.Key}");
                        foreach (var err in error.Value.Errors)
                        {
                            Console.WriteLine($"  Error: {err.ErrorMessage}");
                        }
                    }
                    var metodosPagoList = new List<SelectListItem>();
                    var metodosPago = _getAllMetodosPago.Execute();
                    foreach (var metodo in metodosPago)
                    {
                        metodosPagoList.Add(new SelectListItem
                        {
                            Value = metodo.Id.ToString(),
                            Text = metodo.Tipo
                        });
                    }
                    viewModel.MetodosPago = metodosPagoList;
                    var tiposGastoList = new List<SelectListItem>();
                    var tiposGasto = _getAllTiposGasto.Execute();
                    foreach (var tipo in tiposGasto)
                    {
                        tiposGastoList.Add(new SelectListItem
                        {
                            Value = tipo.Id.ToString(),
                            Text = tipo.Nombre
                        });
                    }
                    viewModel.TiposGasto = tiposGastoList;

                    return View(viewModel);
                }
                Console.WriteLine("=== ANTES DE CREAR DTO ===");
                var pagoDto = new PagoDtoAlta(
                    TipoPago: viewModel.TipoPago,
                    Descripcion: viewModel.Descripcion,
                    Monto: viewModel.Monto,
                    MetodoPagoId: viewModel.MetodoPagoId,
                    TipoGastoId: viewModel.TipoGastoId,
                    UsuarioId: userId.Value,
                    FechaPago: viewModel.FechaPago,
                    NumeroRecibo: viewModel.NumeroRecibo,
                    FechaDesde: viewModel.FechaDesde,
                    FechaHasta: viewModel.FechaHasta
                );
                Console.WriteLine("=== ANTES DE EXECUTE ===");
                _addPago.Execute(pagoDto);
                Console.WriteLine("=== DESPUÉS DE EXECUTE - ÉXITO ===");
                TempData["SuccessMessage"] = "Pago registrado exitosamente.";
                return RedirectToAction("Create");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"=== ERROR CAPTURADO: {ex.Message} ===");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
                TempData["ErrorMessage"] = $"Error al registrar el pago: {ex.Message}";
                var metodosPagoList = new List<SelectListItem>();
                var metodosPago = _getAllMetodosPago.Execute();
                foreach (var metodo in metodosPago)
                {
                    metodosPagoList.Add(new SelectListItem
                    {
                        Value = metodo.Id.ToString(),
                        Text = metodo.Tipo
                    });
                }
                viewModel.MetodosPago = metodosPagoList;

                var tiposGastoList = new List<SelectListItem>();
                var tiposGasto = _getAllTiposGasto.Execute();
                foreach (var tipo in tiposGasto)
                {
                    tiposGastoList.Add(new SelectListItem
                    {
                        Value = tipo.Id.ToString(),
                        Text = tipo.Nombre
                    });
                }
                viewModel.TiposGasto = tiposGastoList;
                return View(viewModel);
            }
        }
    }
}