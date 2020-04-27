using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Noticias.Web.Interfaces;
using Noticias.Web.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Noticias.Web.Controllers {
    public class AdminController : Controller {
        const string INDEX_AUTORES = "Autores",
            EDIT_AUTOR = "EditAutor",
            EDIT_NOTICIA = "EditNoticia",
            INDEX_NOTICIAS = "Noticias";
        private readonly IAutoresService _autoresService;
        private readonly INoticiasService _noticiasService;
        public AdminController (IAutoresService autoresService, INoticiasService noticiasService) 
        {
            _noticiasService = noticiasService;
            _autoresService = autoresService;
        }

        public async Task<IActionResult> Noticias () 
        {
            var model = await _noticiasService.GetNoticiasAdmin();

            return View (model);
        }

        private async Task<IEnumerable<SelectListItem>> GetAutoresForSelect()
        {
            var autores = await _autoresService.GetAutores();

            return autores.Select(a =>new SelectListItem() { Text = a.NombreCompleto, Value = a.AutorId.ToString() } );
        }

        [HttpGet]
        public async Task<IActionResult> EditNoticia (int id)
        {
            ViewData[INDEX_AUTORES] = await this.GetAutoresForSelect();

            var model = await _noticiasService.GetNoticiaForEdit(id);

            return View(EDIT_NOTICIA, model);
        }

        [HttpPost]
        public async Task<IActionResult> EditNoticia (EditNoticiaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewData[INDEX_AUTORES] = await this.GetAutoresForSelect();

                return View(EDIT_NOTICIA, model);
            }

            await _noticiasService.UpdateNoticia(model);

            return RedirectToAction (INDEX_NOTICIAS);
        }

        [HttpGet]
        public async Task<IActionResult> CreateNoticia ()
        {
            ViewData[INDEX_AUTORES] = await this.GetAutoresForSelect();

            return View(EDIT_NOTICIA, new EditNoticiaViewModel{ FechaCreacion = DateTime.Now });
        }

        [HttpPost]
        public async Task<IActionResult> CreateNoticia (EditNoticiaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewData[INDEX_AUTORES] = await this.GetAutoresForSelect();
                return View(EDIT_NOTICIA, model);
            }

            await _noticiasService.CreateNoticia(model);

            return RedirectToAction (INDEX_NOTICIAS);
        }

        public async Task<IActionResult> Autores () {
            var model = await _autoresService.GetAutores ();

            return View (model);
        }

        [HttpGet]
        public IActionResult CreateAutor () 
        {
            return View(EDIT_AUTOR, new EditAutorViewModel ());
        }

        [HttpPost]
        public async Task<IActionResult> CreateAutor (EditAutorViewModel autor) {
            if (!ModelState.IsValid) {
                return View (EDIT_AUTOR, autor);
            }

            await _autoresService.CreateAutor (autor);

            return RedirectToAction (INDEX_AUTORES);
        }

        [HttpGet]
        public async Task<IActionResult> EditAutor (int id) 
        {
            Debug.WriteLine (id);
            var autorModel = await _autoresService.GetAutor (id);

            return View (new EditAutorViewModel () {
                AutorId = autorModel.AutorId,
                    Nombre = autorModel.Nombre,
                    Apellidos = autorModel.Apellidos
            });
        }

        [HttpPost]
        public async Task<IActionResult> EditAutor (EditAutorViewModel autor) {
            if (!ModelState.IsValid) {
                return View (autor);
            }

            await _autoresService.UpdateAutor (autor);

            return RedirectToAction (INDEX_AUTORES);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteAutor (int id) 
        {
            await _autoresService.DeleteAutor(id);
            return RedirectToAction (INDEX_AUTORES);
        }
    }
}