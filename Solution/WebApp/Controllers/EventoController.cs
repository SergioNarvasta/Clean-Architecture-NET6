using Application.Interfaces;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;


namespace WebApp.Controllers
{
    public class EventoController : Controller
    {
        private readonly IEventoService _eventoService;
        private readonly IAccesoService _accesoService;
        public EventoController(IEventoService eventoService, IAccesoService accesoService) {
            _eventoService = eventoService;
            _accesoService = accesoService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.Acceso = false;
            var accesoId = HttpContext.Session.GetString("AccesoId");
            if (accesoId != null)
            {
                var acceso = await _accesoService.GetById(int.Parse(accesoId));
                ViewBag.Acceso = true;
                ViewBag.NombreUsuario = string.Concat(acceso.UsuarioAsoc.Nombres, " ", acceso.UsuarioAsoc.Apellidos);
            }
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> GetList() {
            var list = await _eventoService.GetList();
            return Json(list);
        }

        [HttpGet]
        public async Task<JsonResult> GetById(int eventoId)
        {
            var obj = await _eventoService.GetById(eventoId);
            return Json(obj);
        }

        [HttpPost]
        public async Task<JsonResult> Create(Evento evento)
        {
            var response =  await _eventoService.Create(evento);
            return Json(response);
        }

        [HttpPost]
        public async Task<JsonResult> Update(Evento evento)
        {
            var response = await _eventoService.Update(evento);
            return Json(response);
        }

        [HttpPost]
        public async Task<JsonResult> Delete(int eventoId)
        {
            var response = await _eventoService.Delete(eventoId);
            return Json(response);
        }

    }
}
