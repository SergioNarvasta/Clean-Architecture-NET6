using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService) {
          _usuarioService = usuarioService;
        }

        [HttpGet]
        public IActionResult Index()
        {
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
        public async Task Create(Usuario usuario)
        {
             await _usuarioService.Create(usuario);
        }

        [HttpPost]
        public async Task Update(Usuario usuario)
        {
            await _usuarioService.Update(usuario);
        }

        [HttpPost]
        public async Task Delete(int usuarioId)
        {
            await _usuarioService.Delete(usuarioId);
        }

    }
}
