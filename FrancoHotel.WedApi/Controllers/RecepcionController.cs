using FrancoHotel.WedApi.Interfaces;
using FrancoHotel.WedApi.Models;
using FrancoHotel.WedApi.Models.RecepcionModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrancoHotel.WedApi.Controllers
{
    public class RecepcionController : Controller
    {
        private readonly IRecepcionRepository _repository;
        public RecepcionController(IRecepcionRepository repository)
        {
            _repository = repository;
        }
        // GET: RecepcionController
        public async Task<IActionResult> Index()
        {
            try
            {
                var recepcion = await _repository.GetAllAsync();
                return View(recepcion);
            }
            catch (Exception)
            {
                ViewBag.Message = "Error al obtener las recepciones.";
                return View();
            }
        }

        // GET: RecepcionController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var recepcion = await _repository.GetByIdUpdateAsync(id);
                return View(recepcion);
            }
            catch (Exception)
            {
                ViewBag.Message = "Error al obtener la reserva.";
                return View();
            }
        }

        // GET: RecepcionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RecepcionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PostRecepcionModel postRecepcionModel)
        {
            try
            {
                await _repository.CreateEntityAsync(postRecepcionModel);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                ViewBag.Message = "Error al guardar la Reserva.";
                return View();
            }
        }

        // GET: RecepcionController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var recepcion = await _repository.GetByIdUpdateAsync(id);
                return View(recepcion);
            }
            catch (Exception)
            {

                ViewBag.Message = "Error al obtener la reserva.";
                return View();
            }
        }

        // POST: RecepcionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(GetRecepcionModel recepcionModel)
        {
            try
            {
                await _repository.UpdateEntityAsync(recepcionModel);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                ViewBag.Message = "Error al actualizar la reserva.";
                return View();
            }
        }

        // GET: RecepcionController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var recepcion = await _repository.GetByIdRemoveAsync(id);
                return View(recepcion);
            }
            catch (Exception)
            {

                ViewBag.Message = "Error al obtener la reserva.";
                return View();
            }
        }

        // POST: RecepcionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(RemoveRecepcionModel recepcionModel)
        {
            try
            {
                await _repository.RemoveEntityAsync(recepcionModel);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                ViewBag.Message = "Error al remover la reserva.";
                return View();
            }
        }
    }
}