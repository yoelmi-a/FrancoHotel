using FrancoHotel.Application.Dtos.PisoDtos;
using FrancoHotel.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrancoHotel.Web.Controllers
{
    public class PisoController : Controller
    {
        private readonly IPisoService _pisoService;
        public PisoController(IPisoService pisoService)
        {
            _pisoService = pisoService;
        }
        // GET: PisoController
        public async Task<IActionResult> Index()
        {
            var result = await _pisoService.GetAll();
            
            if (result.Success)
            {
                return View(result.Data);
            }
            return View();
        }

        // GET: PisoController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var result = await (_pisoService.GetById(id));
            if (result.Success)
            {
                return View(result.Data);
            }
            return View();
        }

        // GET: PisoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PisoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SavePisoDto savePisoDto)
        {
            try
            {
                await _pisoService.Save(savePisoDto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PisoController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _pisoService.GetById(id);

            if (result.Success)
            {
                return View(result.Data);
            }
            return View();
        }

        // POST: PisoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdatePisoDto updatePisoDto)
        {
            try
            {
                await _pisoService.Update(updatePisoDto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PisoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PisoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
