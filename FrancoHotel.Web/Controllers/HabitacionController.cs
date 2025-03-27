using FrancoHotel.Application.Dtos.HabitacionDtos;
using FrancoHotel.Application.Dtos.PisoDtos;
using FrancoHotel.Application.Interfaces;
using FrancoHotel.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrancoHotel.Web.Controllers
{
    public class HabitacionController : Controller
    {
        private readonly IHabitacionService _habitacionService;

        public HabitacionController(IHabitacionService habitacionService)
        {
            _habitacionService = habitacionService;
        }
        // GET: HabitacionController
        public async Task<IActionResult> Index()
        {
            var result = await _habitacionService.GetAll();

            if (result.Success)
            {
                return View(result.Data);
            }
            return View();
        }

        // GET: HabitacionController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var result = await (_habitacionService.GetById(id));
            if (result.Success)
            {
                return View(result.Data);
            }
            return View();
        }

        // GET: HabitacionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HabitacionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SaveHabitacionDto saveHabitacionDto)
        {
            try
            {
                await _habitacionService.Save(saveHabitacionDto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HabitacionController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _habitacionService.GetById(id);

            if (result.Success)
            {
                return View(result.Data);
            }
            return View();
        }

        // POST: HabitacionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateHabitacionDto updateHabitacionDto)
        {
            try
            {
                await _habitacionService.Update(updateHabitacionDto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HabitacionController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _habitacionService.GetById(id);

            if (result.Success)
            {
                RemoveHabitacionDto dto = new RemoveHabitacionDto()
                {
                    IdHabitacion = result.Data.IdHabitacion,
                    Fecha = result.Data.Fecha,
                    Usuario = result.Data.Usuario
                };
                return View(dto);
            }
            return View();
        }

        // POST: HabitacionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(RemoveHabitacionDto removeHabitacionDto)
        {
            try
            {
                await _habitacionService.Remove(removeHabitacionDto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
