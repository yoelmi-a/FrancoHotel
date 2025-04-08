using FrancoHotel.WebApi.Models.CategoriaModels;
using FrancoHotel.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FrancoHotel.WebApi.Models.ClienteModels;
using FrancoHotel.WebApi.Repository.Interfaces;
using FrancoHotel.WebApi.Service.Interfaces;

namespace FrancoHotel.WebApi.Controllers.Categoria
{
    public class CategoriaController : Controller
    {
        private readonly ICategoriaService _service;
        public CategoriaController(ICategoriaService service)
        {
            _service = service;
        }
        // GET: CategoriaController
        public async Task<IActionResult> Index()
        {
            var categorias = await _service.GetAllAsync();
            return View(categorias);
        }

        // GET: CategoriaController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var categoria = await _service.GetByIdAsync(id);
            return View(categoria);
        }

        // GET: CategoriaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PostCategoriaModel categoriaModel)
        {
            await _service.CreateEntityAsync(categoriaModel);
            return RedirectToAction(nameof(Index));
        }

        // GET: CategoriaController/Edit/5
        public async Task<IActionResult> Edit(int id)
        { 
            var categoria = await _service.GetByIdAsync(id);
            return View(categoria);
        }

        // POST: CategoriaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(GetCategoriaModel categoriaModel)
        {
            await _service.UpdateEntityAsync(categoriaModel);
            return RedirectToAction(nameof(Index));
        }

        // GET: CategoriaController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var categoria = await _service.GetByIdRemoveAsync(id);
            return View(categoria);
        }

        // POST: CategoriaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(RemoveCategoriaModel categoriaModel)
        {
            await _service.RemoveEntityAsync(categoriaModel);
            return RedirectToAction(nameof(Index));
        }
    }
}
