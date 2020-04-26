using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Noticias.Web.Interfaces;
using Noticias.Web.Models;

namespace Noticias.Web.Controllers
{
    public class AdminController : Controller
    {
        const string AUTORES = "Autores",
            EDIT_AUTOR = "EditAutor";
        private readonly IAutoresService _autoresService;
        public AdminController(IAutoresService autoresService)
        {
            _autoresService = autoresService;
        }

        public async Task<IActionResult> Autores()
        {
            var model = await _autoresService.GetAutores();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> CreateAutor()
        {
            return View(EDIT_AUTOR, new EditAutorViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> CreateAutor(EditAutorViewModel autor)
        {
            if (!ModelState.IsValid)
            {
                return View(EDIT_AUTOR, autor);
            }

            await _autoresService.CreateAutor(autor);

            return RedirectToAction(AUTORES);
        }

        [HttpGet]
        public async Task<IActionResult> EditAutor(int id)
        {
            Debug.WriteLine(id);
            var autorModel = await _autoresService.GetAutor(id);

            return View(new EditAutorViewModel(){
                AutorId = autorModel.AutorId,
                Nombre = autorModel.Nombre,
                Apellidos = autorModel.Apellidos
            });
        }

        [HttpPost]
        public async Task<IActionResult> EditAutor(EditAutorViewModel autor)
        {
            if (!ModelState.IsValid)
            {
                return View(autor);
            }

            await _autoresService.UpdateAutor(autor);

            return RedirectToAction(AUTORES);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteAutor(int id)
        {

            return RedirectToAction(AUTORES);
        }
    }
}