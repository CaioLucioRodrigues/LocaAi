using AutoMapper;
using LocaAi.Domain.Entities;
using LocaAi.Domain.Interfaces.Repositories;
using LocaAi.Presentation.Site.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocaAi.Presentation.Site.Controllers
{
    public class CaracteristicasController : Controller
    {
        private readonly ICaracteristicaRepository _caracteristicaRepository;
        private readonly IMapper _mapper;

        public CaracteristicasController(ICaracteristicaRepository caracteristicaRepository,
                                    IMapper mapper)
        {
            _caracteristicaRepository = caracteristicaRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {   
            return View(_mapper.Map<IEnumerable<CaracteristicaViewModel>>(await _caracteristicaRepository.CarregarTodos()));
        }

        public async Task<IActionResult> Details(int id)
        {
            var caracteristicaViewModel = await ObterCaracteristica(id);

            if (caracteristicaViewModel == null)
                return NotFound();

            return View(caracteristicaViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CaracteristicaViewModel caracteristicaViewModel)
        {
            if (!ModelState.IsValid)
                return View(caracteristicaViewModel);

            var categoria = _mapper.Map<Caracteristica>(caracteristicaViewModel);
            await _caracteristicaRepository.Adicionar(categoria);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var caracteristicaViewModel = await ObterCaracteristica(id);

            if (caracteristicaViewModel == null)
                return NotFound();
            return View(caracteristicaViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CaracteristicaViewModel caracteristicaViewModel)
        {
            if (id != caracteristicaViewModel.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(caracteristicaViewModel);

            var caracteristica = _mapper.Map<Caracteristica>(caracteristicaViewModel);
            await _caracteristicaRepository.Atualizar(caracteristica);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var caracteristicaViewModel = await ObterCaracteristica(id);

            if (caracteristicaViewModel == null)
                return NotFound();

            return View(caracteristicaViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var caracteristicaViewModel = await ObterCaracteristica(id);

            if (caracteristicaViewModel == null)
                return NotFound();

            await _caracteristicaRepository.Remover(id);

            return RedirectToAction(nameof(Index));
        }

        private async Task<CaracteristicaViewModel> ObterCaracteristica(int id)
        {
            return _mapper.Map<CaracteristicaViewModel>(await _caracteristicaRepository.CarregarPorID(id));
        }
    }
}
