using FrancoHotel.Application.Dtos.CategoriaDtos;
using FrancoHotel.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FrancoHotel.Web.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ICategoriaService _categoriaService;
        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        // GET: CategoriaController
        public async Task<IActionResult> Index()
        {
            var result = await _categoriaService.GetAll();
            if (result.Success)
            {
                List<UpdateCategoriaDto> categorias = (List<UpdateCategoriaDto>)result.Data;
                return View(categorias);
            }
            return View();
        }

        // GET: CategoriaController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var result = await _categoriaService.GetById(id);
            if (result.Success)
            {
                UpdateCategoriaDto categoria = result.Data;
                return View(categoria);
            }
            return View();
        }

        // GET: CategoriaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SaveCategoriaDto saveCategoriaDto)
        {
            try
            {
                var result = await _categoriaService.Save(saveCategoriaDto);
                if (result.Success)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError(string.Empty, result.Message);
                return View(saveCategoriaDto);
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoriaController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _categoriaService.GetById(id);
            if (result.Success)
            {
                UpdateCategoriaDto categoria = result.Data;
                return View(categoria);
            }
            return View();
        }

        // POST: CategoriaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateCategoriaDto updateCategoriaDto)
        {
            try
            {
                var result = await _categoriaService.Update(updateCategoriaDto);
                if (result.Success)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError(string.Empty, result.Message);
                return View(updateCategoriaDto);
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoriaController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _categoriaService.GetById(id);
            if (result.Success)
            {
                RemoveCategoriaDto categoria = new RemoveCategoriaDto()
                {
                    Id = id,
                    Fecha = result.Data.Fecha,
                    Usuario = result.Data.Usuario
                };
                return View(categoria);
            }
            return View();
        }

        // POST: CategoriaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(RemoveCategoriaDto removeCategoriaDto)
        {
            try
            {
                await _categoriaService.Remove(removeCategoriaDto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
