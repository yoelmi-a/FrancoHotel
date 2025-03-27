using FrancoHotel.Application.Interfaces;
using FrancoHotel.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrancoHotel.Web.Controllers
{
    public class TarifasController : Controller
{
        private readonly ITarifasService _tarifasService;
        public TarifasController(ITarifasService tarifasService)
        {
            _tarifasService = tarifasService;
        }

        // GET: TarifasController
        public async Task<IActionResult> Index()
        {
            var result = await _tarifasService.GetAll();

            if (result.Success)
            {
                return View(result.Data);
            }
            return View();
        }

        // GET: TarifasController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TarifasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TarifasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: TarifasController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TarifasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: TarifasController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TarifasController/Delete/5
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
