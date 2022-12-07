using Microsoft.AspNetCore.Mvc;

namespace CursoASPNET.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
