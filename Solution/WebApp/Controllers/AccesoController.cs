using Application.Interfaces;
using Domain.Dto;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class AccesoController : Controller
    {
        private readonly IAccesoService _accesoService;

        public AccesoController(IAccesoService accesoService) {
          _accesoService = accesoService;
        }
        public IActionResult Index()
        {
            return View();
        }

        /*[HttpPost]
        public async Task<JsonResult> IniciarSesion(AccesoDto acceso) {
           
        }*/
    }
}
