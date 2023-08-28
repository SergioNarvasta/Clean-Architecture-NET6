using Application.Interfaces;
using Domain.Dto;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class AccesoController : Controller
    {
        private readonly IAccesoService _accesoService;
        private readonly IUsuarioService _usuarioService;

        public AccesoController(IAccesoService accesoService, IUsuarioService usuarioService) {
            _accesoService = accesoService;
            _usuarioService = usuarioService;
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

        [HttpPost]
        public async Task<JsonResult> CrearSesion(UsuarioAccesoDto usuarioAccesoDto)
        {
            var usuario = new Usuario()
            {
                Nombres = usuarioAccesoDto.Nombres,
                Apellidos = usuarioAccesoDto.Apellidos,
                DNI = usuarioAccesoDto.DNI,
                FechaNac = usuarioAccesoDto.FechaNac,
                Estado = Utils.Enums.Estados.Active
            };
            var usuarioCreate = await _usuarioService.Create(usuario);

            var acceso = new Acceso()
            {
                Usuario = usuarioAccesoDto.Usuario,
                Clave = usuarioAccesoDto.Clave,
                UsuarioId = usuarioCreate.Id
            };
            var response = await _accesoService.Create(acceso);

            return Json(response);
        }
    }
}
