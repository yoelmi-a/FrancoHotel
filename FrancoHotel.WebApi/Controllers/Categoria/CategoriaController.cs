using FrancoHotel.WebApi.Models.CategoriaModels;
using FrancoHotel.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FrancoHotel.WebApi.Models.ClienteModels;
using FrancoHotel.WebApi.Repository.Interfaces;

namespace FrancoHotel.WebApi.Controllers.Categoria
{
    public class CategoriaController : Controller
    {
        private readonly ICategoriaRepository _repository;
        public CategoriaController(ICategoriaRepository repository)
        {
            _repository = repository;
        }
        // GET: CategoriaController
        public async Task<IActionResult> Index()
        {
            try
            {
                var categorias = await _repository.GetAllAsync();
                return View(categorias);
            }
            catch (Exception)
            {
                ViewBag.Message = "Error al obtener la lista de categorias";
                return View();
            }
        }

        // GET: CategoriaController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var categoria = await _repository.GetByIdAsync(id);
                return View(categoria);
            }
            catch (Exception)
            {
                ViewBag.Message = "Error al obtener el categoria";
                return View();
            }
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
            try
            {
                await _repository.CreateEntityAsync(categoriaModel);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                ViewBag.Message = "Error al crear el categoria";
                return View();
            }
        }

        // GET: CategoriaController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var categoria = await _repository.GetByIdAsync(id);
                return View(categoria);
            }
            catch (Exception)
            {
                ViewBag.Message = "Error al obtener el categoria";
                return View();
            }
        }

        // POST: CategoriaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(GetCategoriaModel categoriaModel)
        {
            try
            {
                await _repository.UpdateEntityAsync(categoriaModel);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                ViewBag.Message = "Error al editar el categoria";
                return View();
            }
        }

        // GET: CategoriaController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var categoria = await _repository.GetByIdRemoveAsync(id);
                return View(categoria);
            }
            catch (Exception)
            {
                ViewBag.Message = "Error al obtener el categoria";
                return View();
            }
        }

        // POST: CategoriaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(RemoveCategoriaModel categoriaModel)
        {
            try
            {
                await _repository.RemoveEntityAsync(categoriaModel);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                ViewBag.Message = "Error al eliminar el categoria";
                return View();
            }
        }
    }
}
