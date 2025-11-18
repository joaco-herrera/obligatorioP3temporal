using Microsoft.AspNetCore.Mvc;

namespace Libreria.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
