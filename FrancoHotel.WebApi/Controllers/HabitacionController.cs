using FrancoHotel.WebApi.Models.PisoModels;
using FrancoHotel.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FrancoHotel.WebApi.Models.HabitacionModels;
using FrancoHotel.WebApi.Repositories.Interfaces;

namespace FrancoHotel.WebApi.Controllers
{
    public class HabitacionController : Controller
    {
        private readonly IHabitacionRepository _repository;
        public HabitacionController(IHabitacionRepository repository)
        {
            _repository = repository;
        }
        // GET: HabitacionController
        public async Task<IActionResult> Index()
        {
            try
            {
                var habitaciones = await _repository.GetAllAsync();
                return View(habitaciones);
            }
            catch (Exception)
            {
                ViewBag.Message = "Error al obtener las la habitaciones.";
                return View();
            }
        }

        // GET: HabitacionController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var habitacion = await _repository.GetByIdUpdateAsync(id);
                return View(habitacion);
            }
            catch (Exception)
            {
                ViewBag.Message = "Error al obtener la habitación.";
                return View();
            }
        }

        // GET: HabitacionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HabitacionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PostHabitacionModel habitacionModel)
        {
            try
            {
                await _repository.CreateEntityAsync(habitacionModel);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                ViewBag.Message = "Error al guardar la habitación.";
                return View();
            }
        }

        // GET: HabitacionController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var habitacion = await _repository.GetByIdUpdateAsync(id);
                return View(habitacion);
            }
            catch (Exception)
            {

                ViewBag.Message = "Error al obtener la habitación.";
                return View();
            }
        }

        // POST: HabitacionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(GetHabitacionModel habitacionModel)
        {
            try
            {
                await _repository.UpdateEntityAsync(habitacionModel);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                ViewBag.Message = "Error al actualizar la habitación.";
                return View();
            }
        }

        // GET: HabitacionController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var habitacion = await _repository.GetByIdRemoveAsync(id);
                return View(habitacion);
            }
            catch (Exception)
            {

                ViewBag.Message = "Error al obtener la habitación.";
                return View();
            }
        }

        // POST: HabitacionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(RemoveHabitacionModel habitacionModel)
        {
            try
            {
                await _repository.RemoveEntityAsync(habitacionModel);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                ViewBag.Message = "Error al remover la habitación.";
                return View();
            }
        }
    }
}
