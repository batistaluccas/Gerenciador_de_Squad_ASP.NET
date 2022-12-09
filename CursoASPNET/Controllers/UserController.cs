using Common;
using CursoASPNET.Models;
using Microsoft.AspNetCore.Mvc;

namespace CursoASPNET.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Edit(UserViewModel model)
        {
            return View(model ?? new UserViewModel());
        }
    }
}
