using Libreria.LogicaAplicacion.CasosUso.Usuarios;
using Libreria.LogicaAplicacion.Dtos.Equipos;
using Libreria.LogicaAplicacion.Dtos.Usuarios;
using Libreria.LogicaNegocio.InterfacesLogicaAplicacion;
using Libreria.LogicaNegocio.Utilidades;
using Libreria.WebApp.Filter;
using Libreria.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace Libreria.WebApp.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly ICUGetAll<UsuarioDtoListado> _getAll;
        private readonly ICUGetById<UsuarioDtoListado> _getById;
        private readonly ICUAdd<UsuarioDtoAlta> _add;
        private readonly ICUDelete<UsuarioDtoAlta> _delete;
        private readonly ICUUpdate<UsuarioDtoAlta> _update;
        private readonly GetUsuariosPorMontoSuperior _getUsuariosPorMonto;
        private readonly ICUGetAll<EquipoDtoListado> _getAllEquipos;


        public UsuariosController(
            ICUGetAll<UsuarioDtoListado> getAll,
            ICUAdd<UsuarioDtoAlta> add,
            ICUDelete<UsuarioDtoAlta> delete,
            ICUUpdate<UsuarioDtoAlta> update,
            ICUGetById<UsuarioDtoListado> getById,
            GetUsuariosPorMontoSuperior getUsuariosPorMonto,
            ICUGetAll<EquipoDtoListado> getAllEquipos
        )
        {
            _getAll = getAll;
            _add = add;
            _delete = delete;
            _update = update;
            _getById = getById;
            _getUsuariosPorMonto = getUsuariosPorMonto;
            _getAllEquipos = getAllEquipos;
        }
        [GerenteAdminAutorizado]
        public IActionResult Index()
        {
            return View(_getAll.Execute());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(UsuarioDtoAlta usuario)
        {
            try
            {
                var nuevoUsuario = new UsuarioDtoAlta(
                    usuario.Nombre,
                    usuario.Apellido,
                    null,  
                    usuario.Password,
                    "Empleado",
                    2
                );
                _add.Execute(nuevoUsuario);
                var usuarioCreado = _getAll.Execute()
                    .OrderByDescending(u => u.Id)
                    .FirstOrDefault();
                string emailGenerado = usuarioCreado?.Email ?? "desconocido@laempresa.com";
                TempData["SuccessMessage"] = $"Usuario registrado exitosamente. Email: {emailGenerado}";
                return RedirectToAction("Index", "Login");
            }
            catch (Exception e)
            {
                TempData["ErrorMessage"] = $"Error al registrar usuario: {e.Message}";
                return View(usuario);
            }
        }
        [GerenteAdminAutorizado]
        public IActionResult Registrar()
        {
            ViewBag.Equipos = _getAllEquipos.Execute();
            return View();
        }
        [GerenteAdminAutorizado]
        [HttpPost]
        public IActionResult Registrar(UsuarioDtoAlta usuario)
        {
            try
            {
                var nuevoUsuario = new UsuarioDtoAlta(
                    usuario.Nombre,
                    usuario.Apellido,
                    null,
                    usuario.Password,
                    usuario.Rol,
                    usuario.EquipoId
                );
                _add.Execute(nuevoUsuario);
                var usuarioCreado = _getAll.Execute()
                    .OrderByDescending(u => u.Id)
                    .FirstOrDefault();
                string emailGenerado = usuarioCreado?.Email ?? "desconocido@laempresa.com";
                TempData["SuccessMessage"] = $"Usuario registrado exitosamente. Email: {emailGenerado}";
                return RedirectToAction("Index", "Usuarios");
            }
            catch (Exception e)
            {
                ViewBag.Equipos = _getAllEquipos.Execute();
                TempData["ErrorMessage"] = $"Error al registrar usuario: {e.Message}";
                return View(usuario);
            }
        }
        [GerenteAdminAutorizado]
        public IActionResult Details(int id)
        {
            try
            {
                var usuario = _getById.Execute(id);
                if (usuario == null)
                {
                    TempData["ErrorMessage"] = "No se encontró el usuario";
                    return RedirectToAction("Index");
                }
                return View(usuario);
            }
            catch (Exception e)
            {
                TempData["ErrorMessage"] = $"Error: {e.Message}";
                return RedirectToAction("Index");
            }
        }
        [GerenteAdminAutorizado]
        public IActionResult Edit(int id)
        {
            try
            {
                if (id == 0)
                {
                    TempData["ErrorMessage"] = "ID de usuario inválido";
                    return RedirectToAction("Index");
                }
                UsuarioDtoListado usuario = _getById.Execute(id);
                if (usuario == null)
                {
                    TempData["ErrorMessage"] = $"No se encontró el usuario con ID {id}";
                    return RedirectToAction("Index");
                }
                ViewBag.Equipos = _getAllEquipos.Execute();
                return View(usuario);
            }
            catch (Exception e)
            {
                TempData["ErrorMessage"] = $"Error: {e.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [GerenteAdminAutorizado]
        public IActionResult Edit(UsuarioDtoListado usuario)
        {
            try
            {
                var usuarioActualDto = _getById.Execute(usuario.Id);
                var usuarioAlta = new UsuarioDtoAlta(
                    usuario.Nombre,
                    usuario.Apellido,
                    usuario.Email,
                    usuarioActualDto.Password,
                    usuario.Rol,
                    usuario.EquipoId
                );
                _update.Execute(usuario.Id, usuarioAlta);
                TempData["SuccessMessage"] = "Usuario modificado exitosamente";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.Equipos = _getAllEquipos.Execute();
                TempData["ErrorMessage"] = $"Error al modificar usuario: {e.Message}";
                return View(usuario);
            }
        }
        [GerenteAdminAutorizado]
        public IActionResult Delete(int id)
        {
            try
            {
                _delete.Execute(id);
                TempData["SuccessMessage"] = "Usuario eliminado exitosamente";
                return RedirectToAction("Index", "Usuarios");
            }
            catch (Exception e)
            {
                string fullMessage = e.Message + (e.InnerException?.Message ?? "");

                string mensaje = fullMessage.Contains("REFERENCE constraint")
                    ? "No se puede eliminar este usuario porque tiene pagos asociados."
                    : $"Error al eliminar usuario: {e.Message}";

                TempData["ErrorMessage"] = mensaje;
                return RedirectToAction("Index", "Usuarios");
            }
        }
        [GerenteAutorizado]
        public IActionResult UsuariosPorMonto(decimal? monto)
        {
            try
            {
                var viewModel = new UsuariosPorMontoViewModel();

                if (monto.HasValue && monto.Value > 0)
                {
                    viewModel.Monto = monto.Value;
                    viewModel.Usuarios = _getUsuariosPorMonto.Execute(monto.Value);
                }
                return View(viewModel);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error: {ex.Message}";
                return View(new UsuariosPorMontoViewModel());
            }
        }
    }
}