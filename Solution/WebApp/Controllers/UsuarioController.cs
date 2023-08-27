using Application.Interfaces;
using Azure;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
