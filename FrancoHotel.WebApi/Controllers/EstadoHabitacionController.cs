using FrancoHotel.WebApi.Models.HabitacionModels;
using FrancoHotel.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FrancoHotel.WebApi.Models.EstadoHabitacionModels;
using FrancoHotel.WebApi.Repositories.Interfaces;

namespace FrancoHotel.WebApi.Controllers
{
    public class EstadoHabitacionController : Controller
    {
        private readonly IEstadoHabitacionRepository _repository;
        public EstadoHabitacionController(IEstadoHabitacionRepository repository)
        {
            _repository = repository;
        }
        // GET: EstadoHabitacionController
        public async Task<IActionResult> Index()
        {
            try
            {
                var habitaciones = await _repository.GetAllAsync();
                return View(habitaciones);
            }
            catch (Exception)
            {
                ViewBag.Message = "Error al obtener los estados de habitaciones.";
                return View();
            }
        }

        // GET: EstadoHabitacionController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var habitacion = await _repository.GetByIdUpdateAsync(id);
                return View(habitacion);
            }
            catch (Exception)
            {
                ViewBag.Message = "Error al obtener el estado de habitación.";
                return View();
            }
        }

        // GET: EstadoHabitacionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EstadoHabitacionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PostEstadoHabitacionModel estadoHabitacionModel)
        {
            try
            {
                await _repository.CreateEntityAsync(estadoHabitacionModel);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                ViewBag.Message = "Error al guardar el estado de habitación.";
                return View();
            }
        }

        // GET: EstadoHabitacionController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var habitacion = await _repository.GetByIdUpdateAsync(id);
                return View(habitacion);
            }
            catch (Exception)
            {

                ViewBag.Message = "Error al obtener el estado de habitación.";
                return View();
            }
        }

        // POST: EstadoHabitacionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(GetEstadoHabitacionModel estadoHabitacionModel)
        {
            try
            {
                await _repository.UpdateEntityAsync(estadoHabitacionModel);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                ViewBag.Message = "Error al actualizar el estado de habitación."; ;
                return View();
            }
        }

        // GET: EstadoHabitacionController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var habitacion = await _repository.GetByIdRemoveAsync(id);
                return View(habitacion);
            }
            catch (Exception)
            {

                ViewBag.Message = "Error al obtener el estado de habitación.";
                return View();
            }
        }

        // POST: EstadoHabitacionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(RemoveEstadoHabitacionModel estadoHabitacionModel)
        {
            try
            {
                await _repository.RemoveEntityAsync(estadoHabitacionModel);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                ViewBag.Message = "Error al remover  el estado de habitación.";
                return View();
            }
        }
    }
}
