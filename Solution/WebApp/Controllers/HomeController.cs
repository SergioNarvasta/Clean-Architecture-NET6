using Application.Interfaces;
using Azure;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading;
using WebApp.Models;

namespace WebApp.Controllers
{
    /*Una lista de todos 
    los comisarios se conservará junto con la lista de los eventos en los que esté involucrado cada
    comisario ya sea cumpliendo la tarea de juez u observador */
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAccesoService _accesoService;

        public HomeController(ILogger<HomeController> logger, IAccesoService accesoService)
        {
            _logger = logger;
            _accesoService = accesoService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Acceso = false;
            var accesoId = HttpContext.Session.GetString("AccesoId");
            if(accesoId != null) {
                var acceso = await _accesoService.GetById(int.Parse(accesoId));
                ViewBag.Acceso = true;
                ViewBag.NombreUsuario = string.Concat(acceso.UsuarioAsoc.Nombres, " ", acceso.UsuarioAsoc.Apellidos);
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}