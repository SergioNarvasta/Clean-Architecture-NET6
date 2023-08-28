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

        [HttpPost]
        public async Task<JsonResult> IniciarSesion(AccesoDto acceso)
        {
           var response = await _accesoService.IniciarSesion(acceso);
            if(response != null) {
                HttpContext.Session.SetString("AccesoId", response.Id.ToString());
            }
            return Json(response);
        }

        [HttpPost]
        public ActionResult CerrarSesion()
        {
            HttpContext.Session.Remove("AccesoId");

            return RedirectToAction("Index", "Home");
        }
    }
}
