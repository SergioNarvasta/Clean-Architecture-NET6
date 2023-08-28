using Application.Interfaces;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class RolController : Controller
    {
        private readonly IRolService _rolService;
        public RolController(IRolService rolService) {
          _rolService = rolService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> GetList()
        {
            var list = await _rolService.GetList();
            return Json(list);
        }

        [HttpPost]
        public async Task<JsonResult> Create(Rol rol)
        {
            var response = await _rolService.Create(rol);
            return Json(response);
        }
    }
}
