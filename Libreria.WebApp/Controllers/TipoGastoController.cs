using Libreria.LogicaAplicacion.Dtos.TipoGasto;
using Libreria.LogicaNegocio.InterfacesLogicaAplicacion;
using Libreria.WebApp.Filter;
using Microsoft.AspNetCore.Mvc;

namespace Libreria.WebApp.Controllers
{
    [AdminAutorizado]
    public class TipoGastoController : Controller
    {
        private readonly ICUGetAll<TipoGastoDtoListado> _getAll;
        private readonly ICUGetById<TipoGastoDtoListado> _getById;
        private readonly ICUAdd<TipoGastoDtoAlta> _add;
        private readonly ICUDelete<TipoGastoDtoAlta> _delete;
        private readonly ICUUpdate<TipoGastoDtoAlta> _update;

        public TipoGastoController(
            ICUGetAll<TipoGastoDtoListado> getAll,
            ICUAdd<TipoGastoDtoAlta> add,
            ICUDelete<TipoGastoDtoAlta> delete,
            ICUUpdate<TipoGastoDtoAlta> update,
            ICUGetById<TipoGastoDtoListado> getById
        )
        {
            _getAll = getAll;
            _add = add;
            _delete = delete;
            _update = update;
            _getById = getById;
        }

        public IActionResult Index(string mensaje)
        {
            if (!string.IsNullOrEmpty(mensaje))
            {
                ViewBag.Mensaje = mensaje;
            }
            return View(_getAll.Execute());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TipoGastoDtoAlta tipoGasto)
        {
            try
            {
                _add.Execute(tipoGasto);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return View(tipoGasto);
            }
        }

        public IActionResult Details(int id)
        {
            var tipoGasto = _getById.Execute(id);
            if (tipoGasto == null)
                return RedirectToAction("Index", new { mensaje = "No se encontró el tipo de gasto" });

            return View(tipoGasto);
        }

        public IActionResult Edit(int id)
        {
            if (id == 0) 
            {
                return RedirectToAction("Index");
            }

            TipoGastoDtoListado tipoGasto = _getById.Execute(id);
            if (tipoGasto == null)
            {
                return RedirectToAction("Index", new { mensaje = "No se encontró " + id });
            }

            ViewBag.Id = id;
            return View(tipoGasto); 
        }

        [HttpPost]
        public IActionResult Edit(int id, TipoGastoDtoAlta tipoGasto)
        {
            try
            {
                _update.Execute(id, tipoGasto);
                return RedirectToAction("Index", new { mensaje = "Modificación exitosa" });
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", new { mensaje = e.Message });
            }
        }
        public IActionResult Delete(int id)
        {
            try
            {
                _delete.Execute(id);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", new { mensaje = e.Message });
            }
        }
    }
}