﻿using ImpostoRenda.Web.Interfaces;
using ImpostoRenda.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ImpostoRenda.Web.Controllers
{

    public class HomeController : Controller
    {
        private readonly IImpostoService _impostoService;

        private readonly ILogger<HomeController> _logger;

        public HomeController(IImpostoService impostoService, ILogger<HomeController> logger)
        {
            _logger = logger;
            _impostoService = impostoService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(ImpostoRequest impostoRequest)
        {

            var result = await _impostoService.CalcImpostoAsync(impostoRequest);
            ViewBag.Result = result;
            return View(impostoRequest);
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
