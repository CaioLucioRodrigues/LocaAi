using LocaAi.Domain.Entities;
using LocaAi.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LocaAi.Presentation.Site.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuariosController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public IActionResult Adicionar()
        {
            //var usuario = _usuarioRepository.BuscarPorNome("teste");
            return View();
        }

        [HttpPost]
        public IActionResult Adicionar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                //_usuarioRepository.Add(usuario);
            }

            return View(usuario);
        }
    }
}