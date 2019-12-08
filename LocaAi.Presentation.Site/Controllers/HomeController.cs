using LocaAi.Domain.Interfaces.Services.Logging;
using LocaAi.Presentation.Site.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;

namespace LocaAi.Presentation.Site.Controllers
{
    [Route("")]
    [Route("Home")]
    public class HomeController : Controller
    {
        private readonly ILogServiceBase _logger;

        public HomeController(ILogServiceBase logger)
        {
            _logger = logger;
        }

        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            _logger.LogInfo<HomeController>("O usuário acessou Home/Index");
            return View();
        }

        [Route("Privacidade")]
        public IActionResult Privacy()
        {
            return View();
        }

        [Route("Erro")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
