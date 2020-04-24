using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Noticias.Web.Interfaces;

namespace Noticias.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAutoresService _autoresService;
        public AdminController(IAutoresService autoresService)
        {
            _autoresService = autoresService;
        }

        public async Task<IActionResult> Autores()
        {
            var model = await _autoresService.GetAutores();

            return View();
        }
    }
}