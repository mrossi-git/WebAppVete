using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using WebAppEncuesta.DB;
using WebAppVete.Models;

namespace WebAppVete.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BaseDatos _DB;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _DB = new BaseDatos();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListarMascotas()
        {
            return View(_DB.ObtenerMascotas(0));
        }

        public IActionResult CrearMascota()
        {
            ViewBag.Especies = new SelectList(_DB.ObtenerEspecies(0), "Id", "Nombre");
            return View();
        }

        public IActionResult GuardarMascota(Mascota mascota)
        {
            string result = _DB.GuardarMascota(mascota);

            if (string.IsNullOrEmpty(result))
                return RedirectToAction("ListarMascotas");
            else
                return View("Errores", result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
