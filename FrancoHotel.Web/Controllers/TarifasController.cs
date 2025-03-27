using System.Threading.Tasks;
using FrancoHotel.Application.Dtos.RecepcionDtos;
using FrancoHotel.Application.Dtos.TarifasDto;
using FrancoHotel.Application.Dtos.TarifasDtos;
using FrancoHotel.Application.Interfaces;
using FrancoHotel.Application.Services;
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
        public async Task<IActionResult> Details(int Id)
        {
            var result = await(_tarifasService.GetById(Id));
            if (result.Success)
            {
                return View(result.Data);
            }
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
        public async Task<IActionResult> Create(SaveTarifasDtos saveTarifasDtos)
        {
            try
            {
                await _tarifasService.Save(saveTarifasDtos);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TarifasController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _tarifasService.GetById(id);
            if(result.Success)
            {
                return View(result.Data);
            }
            return View();
        }

        // POST: TarifasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateTarifasDto updateTarifasDto)
        {
            try
            {
                await _tarifasService.Update(updateTarifasDto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TarifasController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _tarifasService.GetById(id);
            if(result.Success)
            {
                RemoveTarifasDto removeTarifasDto = new RemoveTarifasDto()
                {
                    Id = result.Data.Id,
                    Fecha = result.Data.Fecha,
                    Usuario = result.Data.Usuario
                };
                return View(removeTarifasDto);
            }
            return View();
        }

        // POST: TarifasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(RemoveTarifasDto removeTarifasDto)
        {
            try
            {
                await _tarifasService.Remove(removeTarifasDto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
