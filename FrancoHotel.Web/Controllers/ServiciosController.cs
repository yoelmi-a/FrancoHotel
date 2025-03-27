using FrancoHotel.Application.Dtos.PisoDtos;
using FrancoHotel.Application.Dtos.ServiciosDto;
using FrancoHotel.Application.Interfaces;
using FrancoHotel.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrancoHotel.Web.Controllers
{
    public class ServiciosController : Controller
    {
        private readonly IServiciosService _serviciosService;

        public ServiciosController(IServiciosService serviciosService)
        {
            _serviciosService = serviciosService;
        }
        // GET: ServiciosController
        public async Task<IActionResult> Index()
        {
            var result = await _serviciosService.GetAll();

            if (result.Success)
            {
                return View(result.Data);
            }
            return View();
        }

        // GET: ServiciosController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var result = await (_serviciosService.GetById(id));
            if (result.Success)
            {
                return View(result.Data);
            }
            return View();
        }

        // GET: ServiciosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ServiciosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SaveServiciosDto saveServiciosDto)
        {
            try
            {
                await _serviciosService.Save(saveServiciosDto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ServiciosController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _serviciosService.GetById(id);

            if (result.Success)
            {
                return View(result.Data);
            }
            return View();
        }

        // POST: ServiciosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateServiciosDto updateServiciosDto)
        {
            try
            {
                await _serviciosService.Update(updateServiciosDto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ServiciosController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _serviciosService.GetById(id);

            if (result.Success)
            {
                RemoveServiciosDto dto = new RemoveServiciosDto()
                {
                    IdServicio = result.Data.IdServicio,
                    Fecha = result.Data.Fecha,
                    Usuario = result.Data.Usuario
                };
                return View(dto);
            }
            return View();
        }

        // POST: ServiciosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(RemoveServiciosDto removeServiciosDto)
        {
            try
            {
                await _serviciosService.Remove(removeServiciosDto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
