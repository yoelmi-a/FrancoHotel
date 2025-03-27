using FrancoHotel.Application.Dtos.EstadoHabitacionDtos;
using FrancoHotel.Application.Dtos.HabitacionDtos;
using FrancoHotel.Application.Interfaces;
using FrancoHotel.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrancoHotel.Web.Controllers
{
    public class EstadoHabitacionController : Controller
    {
        private readonly IEstadoHabitacionService _estadoHabitacionService;

        public EstadoHabitacionController(IEstadoHabitacionService estadoHabitacionService)
        {
            _estadoHabitacionService = estadoHabitacionService;
        }
        // GET: EstadoHabitacionController
        public async Task<IActionResult> Index()
        {
            var result = await _estadoHabitacionService.GetAll();

            if (result.Success)
            {
                return View(result.Data);
            }
            return View();
        }

        // GET: EstadoHabitacionController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var result = await (_estadoHabitacionService.GetById(id));
            if (result.Success)
            {
                return View(result.Data);
            }
            return View();
        }

        // GET: EstadoHabitacionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EstadoHabitacionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SaveEstadoHabitacionDto estadoHabitacionDto)
        {
            try
            {
                await _estadoHabitacionService.Save(estadoHabitacionDto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EstadoHabitacionController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _estadoHabitacionService.GetById(id);

            if (result.Success)
            {
                return View(result.Data);
            }
            return View();
        }

        // POST: EstadoHabitacionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateEstadoHabitacionDto updateEstadoHabitacionDto)
        {
            try
            {
                await _estadoHabitacionService.Update(updateEstadoHabitacionDto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EstadoHabitacionController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _estadoHabitacionService.GetById(id);

            if (result.Success)
            {
                RemoveEstadoHabitacionDto dto = new RemoveEstadoHabitacionDto()
                {
                    IdEstadoHabitacion = result.Data.IdEstadoHabitacion,
                    Fecha = result.Data.Fecha,
                    Usuario = result.Data.Usuario
                };
                return View(dto);
            }
            return View();
        }

        // POST: EstadoHabitacionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(RemoveEstadoHabitacionDto removeEstadoHabitacionDto)
        {
            try
            {
                await _estadoHabitacionService.Remove(removeEstadoHabitacionDto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
