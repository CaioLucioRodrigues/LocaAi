using AutoMapper;
using LocaAi.Domain.Entities;
using LocaAi.Domain.Interfaces.Repositories;
using LocaAi.Presentation.Site.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocaAi.Presentation.Site.Controllers
{
    public class CategoriasController : BaseController
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IMapper _mapper;

        public CategoriasController(ICategoriaRepository categoriaRepository,
                                    IMapper mapper)
        {
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {   
            return View(_mapper.Map<IEnumerable<CategoriaViewModel>>(await _categoriaRepository.CarregarTodos()));
        }

        public async Task<IActionResult> Details(int id)
        {
            var categoriaViewModel = await ObterCategoria(id);

            if (categoriaViewModel == null)
                return NotFound();

            return View(categoriaViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoriaViewModel categoriaViewModel)
        {
            if (!ModelState.IsValid)
                return View(categoriaViewModel);

            var categoria = _mapper.Map<Categoria>(categoriaViewModel);
            await _categoriaRepository.Adicionar(categoria);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var categoriaViewModel = await ObterCategoria(id);

            if (categoriaViewModel == null)
                return NotFound();

            return View(categoriaViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CategoriaViewModel categoriaViewModel)
        {
            if (id != categoriaViewModel.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(categoriaViewModel);

            var categoria = _mapper.Map<Categoria>(categoriaViewModel);
            await _categoriaRepository.Atualizar(categoria);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var categoriaViewModel = await ObterCategoria(id);

            if (categoriaViewModel == null)
                return NotFound();

            return View(categoriaViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoriaViewModel = await ObterCategoria(id);

            if (categoriaViewModel == null)
                return NotFound();

            await _categoriaRepository.Remover(id);

            return RedirectToAction(nameof(Index));
        }

        private async Task<CategoriaViewModel> ObterCategoria(int id)
        {
            return _mapper.Map<CategoriaViewModel>(await _categoriaRepository.CarregarPorID(id));
        }
    }
}
