﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Noticias.Web.Interfaces;
using Noticias.Web.Models;

namespace Noticias.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly INoticiasService _noticiasService;

        public HomeController(ILogger<HomeController> logger, INoticiasService noticiasService)
        {
            _logger = logger;
            _noticiasService = noticiasService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _noticiasService.GetHome();
            return View(new HomeViewModel{ Noticias = model});
        }

        public async Task<IActionResult> Noticia(int id)
        {
            var model = await _noticiasService.GetNoticia(id);
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
