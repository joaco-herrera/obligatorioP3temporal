using Libreria.LogicaNegocio.InterfacesLogicaAplicacion;
using Libreria.LogicaAplicacion.Dtos.Usuarios;
using Microsoft.AspNetCore.Mvc;

namespace Libreria.WebApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly ICUGetAll<UsuarioDtoListado> _getAllUsuarios;

        public LoginController(ICUGetAll<UsuarioDtoListado> getAllUsuarios)
        {
            _getAllUsuarios = getAllUsuarios;
        }

        public IActionResult Index()
        {
            var rol = HttpContext.Session.GetString("rol");
            if (!string.IsNullOrEmpty(rol))
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            try
            {
                var usuario = _getAllUsuarios.Execute()
                             .FirstOrDefault(u => u.Email == email && u.Password == password);

                if (usuario != null)
                {
                    HttpContext.Session.SetString("rol", usuario.Rol);
                    HttpContext.Session.SetString("email", usuario.Email);
                    HttpContext.Session.SetString("nombre", usuario.Nombre);
                    HttpContext.Session.SetInt32("userId", usuario.Id);
                    TempData["SuccessMessage"] = $"Bienvenido {usuario.Nombre}!";
                    if (usuario.Rol == "Admin")
                    {
                        return RedirectToAction("Index");
                    }
                    else 
                    {
                        return RedirectToAction("Index");
                    }
                }
                TempData["ErrorMessage"] = "Usuario o contraseña incorrectos";
                return View("Index");
            }
            catch (Exception e)
            {
                TempData["ErrorMessage"] = $"Error al iniciar sesión: {e.Message}";
                return View("Index");
            }
        }
        [HttpPost]
        public IActionResult Logout()
        {
            var nombre = HttpContext.Session.GetString("nombre");
            HttpContext.Session.Clear();
            TempData["InfoMessage"] = $"Sesión cerrada. Hasta pronto!";
            return RedirectToAction("Index");
        }
    }
}