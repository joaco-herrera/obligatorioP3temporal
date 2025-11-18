using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Libreria.WebApp.Filter
{
    public class AdminAutorizado : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var rol = context.HttpContext.Session.GetString("rol");

            if (string.IsNullOrEmpty(rol) || rol.ToLower() != "admin")
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