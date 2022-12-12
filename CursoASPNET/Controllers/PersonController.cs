using CursoASPNET.Models;
using Microsoft.AspNetCore.Mvc;

namespace CursoASPNET.Controllers
{
    public class PersonController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Edit(PersonViewModel? model = null)    
        {
            return View(model ?? new PersonViewModel());
        }
    }
}
