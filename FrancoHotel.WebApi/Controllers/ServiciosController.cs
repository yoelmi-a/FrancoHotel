using FrancoHotel.WebApi.Models.EstadoHabitacionModels;
using FrancoHotel.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FrancoHotel.WebApi.Models.ServiciosModels;
using FrancoHotel.WebApi.Repositories.Interfaces;

namespace FrancoHotel.WebApi.Controllers
{
    public class ServiciosController : Controller
    {
        private readonly IServiciosRepository _repository;
        public ServiciosController(IServiciosRepository repository)
        {
            _repository = repository;
        }
        // GET: ServiciosController
        public async Task<IActionResult> Index()
        {
            try
            {
                var habitaciones = await _repository.GetAllAsync();
                return View(habitaciones);
            }
            catch (Exception)
            {
                ViewBag.Message = "Error al obtener los servicios.";
                return View();
            }
        }

        // GET: ServiciosController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var habitacion = await _repository.GetByIdUpdateAsync(id);
                return View(habitacion);
            }
            catch (Exception)
            {
                ViewBag.Message = "Error al obtener el servicio.";
                return View();
            }
        }

        // GET: ServiciosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ServiciosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PostServiciosModel serviciosModel)
        {
            try
            {
                await _repository.CreateEntityAsync(serviciosModel);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                ViewBag.Message = "Error al guardar el servicio.";
                return View();
            }
        }

        // GET: ServiciosController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var habitacion = await _repository.GetByIdUpdateAsync(id);
                return View(habitacion);
            }
            catch (Exception)
            {

                ViewBag.Message = "Error al obtener el servicio.";
                return View();
            }
        }

        // POST: ServiciosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(GetServiciosModel serviciosModel)
        {
            try
            {
                await _repository.UpdateEntityAsync(serviciosModel);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                ViewBag.Message = "Error al actualizar el servicio.";
                return View();
            }
        }

        // GET: ServiciosController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var habitacion = await _repository.GetByIdRemoveAsync(id);
                return View(habitacion);
            }
            catch (Exception)
            {

                ViewBag.Message = "Error al obtener el servicio.";
                return View();
            }
        }

        // POST: ServiciosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(RemoveServiciosModel serviciosModel)
        {
            try
            {
                await _repository.RemoveEntityAsync(serviciosModel);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                ViewBag.Message = "Error al remover  el servicio.";
                return View();
            }
        }
    }
}
