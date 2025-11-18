using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Libreria.WebApp.Filter
{
    public class UsuarioAutorizado : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var rol = context.HttpContext.Session.GetString("rol");

            if (string.IsNullOrEmpty(rol) || rol.ToLower() != "usuario")
            {
                context.Result = new RedirectToActionResult(
                    "Index",
                    "Login",
                    new { mensaje = "Acceso denegado" }
                );
            }
        }
    }
}