using System.Net.Http.Json;
using FrancoHotel.WebApi.Models;
using FrancoHotel.WebApi.Models.PisoModels;
using FrancoHotel.WebApi.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrancoHotel.WebApi.Controllers
{
    public class PisoController : Controller
    {
        private readonly IPisoRepository _repository;
        public PisoController(IPisoRepository repository)
        {
            _repository = repository;
        }
        // GET: PisoController
        public async Task<IActionResult> Index()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var pisos = await _repository.GetAllAsync();
                    return View(pisos);
                }
                catch (Exception)
                {
                    ViewBag.Message = "Error al obtener los pisos";
                    return View();
                }
            }
        }

        // GET: PisoController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var piso = await _repository.GetByIdUpdateAsync(id);
                return View(piso);
            }
            catch (Exception)
            {
                ViewBag.Message = "Error al obtener el piso";
                return View();
            }
        }

        // GET: PisoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PisoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PostPisoModel pisoModel)
        {
            try
            {
                await _repository.CreateEntityAsync(pisoModel);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                ViewBag.Message = "Error al guardar el piso";
                return View();
            }

        }

        // GET: PisoController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var piso = await _repository.GetByIdUpdateAsync(id);
                return View(piso);
            }
            catch (Exception)
            {

                ViewBag.Message = "Error al obtener el piso";
                return View();
            }
        }

        // PUT: PisoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(GetPisoModel pisoModel)
        {
            try
            {
                await _repository.UpdateEntityAsync(pisoModel);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                ViewBag.Message = "Error al actualizar el piso";
                return View();
            }
        }

        // GET: PisoController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var habitacion = await _repository.GetByIdRemoveAsync(id);
                return View(habitacion);
            }
            catch (Exception)
            {

                ViewBag.Message = "Error al obtener el piso";
                return View();
            }
        }

        // POST: PisoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(RemovePisoModel pisoModel)
        {
            try
            {
                await _repository.RemoveEntityAsync(pisoModel);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                ViewBag.Message = "Error al remover el piso";
                return View();
            }
        }
    }
}
