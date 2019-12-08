using KissLog;
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
        private readonly ILogger _logger;

        public HomeController(ILogger logger)
        {
            _logger = logger;
        }

        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            _logger.Trace("O usuário acessou Home/Index");
            return View();
        }

        [Route("Privacidade")]
        public IActionResult Privacy()
        {
            try
            {
                throw new Exception("ERRO CARALHO !!!");
            }
            catch (Exception e)
            {
                _logger.Error(e);
                throw;
            }
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
