using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers;

public class EmpleadosController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}