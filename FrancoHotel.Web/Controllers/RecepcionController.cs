using FrancoHotel.Application.Dtos.RecepcionDtos;
using FrancoHotel.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FrancoHotel.Web.Controllers
{
    public class RecepcionController : Controller
    {
        private readonly IRecepcionService _recepcionService;
        public RecepcionController(IRecepcionService recepcionService)
        {
            _recepcionService = recepcionService;
        }

        // GET: RecepcionController
        public async Task<IActionResult> Index()
        {
            var result = await _recepcionService.GetAll();

            if (result.Success)
            {
                return View(result.Data);
            }
            return View();
        }

        // GET: RecepcionController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var result = await (_recepcionService.GetById(id));
            if (result.Success)
            {
                return View(result.Data);
            }
            return View();
        }

        // GET: RecepcionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RecepcionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SaveRecepcionDto saveRecepcionDto)
        {
            try
            {
                await _recepcionService.Save(saveRecepcionDto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RecepcionController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var result = await _recepcionService.GetById(id);
            if (result.Success)
            {
                return View(result.Data);
            }
            return View();
        }

        // POST: RecepcionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(UpdateRecepcionDto updateRecepcionDto)
        {
            try
            {
                await _recepcionService.Update(updateRecepcionDto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RecepcionController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _recepcionService.GetById(id);

            if (result.Success)
            {
                RemoveRecepcionDto removeRecepcionDto = new RemoveRecepcionDto()
                {
                    Id = result.Data.Id,
                    Fecha = result.Data.Fecha,
                    Usuario = result.Data.Usuario
                };
                return View(removeRecepcionDto);
            }
            return View();
        }

        // POST: RecepcionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(RemoveRecepcionDto removeDto)
        {
            try
            {
                await _recepcionService.Remove(removeDto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}