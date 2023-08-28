using Application.Interfaces;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;


namespace WebApp.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IRolService _rolService;
        private readonly IAccesoService _accesoService;
        public UsuarioController(IUsuarioService usuarioService, IRolService rolService, IAccesoService accesoService) {
            _usuarioService = usuarioService;
            _rolService = rolService;
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
            var rolList = await _rolService.GetList();
            ViewBag.RolList = rolList.Where(x => x.Estado == Utils.Enums.Estados.Active).ToList();
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> GetList() {
            var list = await _usuarioService.GetList();
            return Json(list);
        }

        [HttpGet]
        public async Task<JsonResult> GetById(int usuarioId)
        {
            var obj = await _usuarioService.GetById(usuarioId);
            return Json(obj);
        }

        [HttpPost]
        public async Task<JsonResult> Create(Usuario usuario)
        {
            var response =  await _usuarioService.Create(usuario);
            return Json(response);
        }

        [HttpPost]
        public async Task<JsonResult> Update(Usuario usuario)
        {
            var response = await _usuarioService.Update(usuario);
            return Json(response);
        }

        [HttpPost]
        public async Task<JsonResult> Delete(int usuarioId)
        {
            var response = await _usuarioService.Delete(usuarioId);
            return Json(response);
        }

    }
}
