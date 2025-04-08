using FrancoHotel.WebApi.Models.RolUsuarioModels;
using FrancoHotel.WebApi.Repository.Interfaces;
using FrancoHotel.WebApi.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FrancoHotel.WebApi.Controllers.RolUsuario
{
    public class RolUsuarioController : Controller
    {
        private readonly IRolUsuarioService _service;
        public RolUsuarioController(IRolUsuarioService service)
        {
            _service = service;
        }
        // GET: RolUsuarioController
        public async Task<IActionResult> Index()
        {
            var roles = await _service.GetAllAsync();
            return View(roles);
        }
        // GET: RolUsuarioController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var roles = await _service.GetByIdAsync(id);
            return View(roles);
        }

        // GET: RolUsuarioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RolUsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PostRolUsuarioModel rolModel)
        {
            await _service.CreateEntityAsync(rolModel);
            return RedirectToAction(nameof(Index));
        }

        // GET: RolUsuarioController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var rol = await _service.GetByIdAsync(id);
            return View(rol);
        }

        // POST: RolUsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(GetRolUsuarioModel rolModel)
        {
            await _service.UpdateEntityAsync(rolModel);
            return RedirectToAction(nameof(Index));
        }

        // GET: RolUsuarioController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var rol = await _service.GetByIdRemoveAsync(id);
            return View(rol);
        }

        // POST: RolUsuarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(RemoveRolUsuarioModel rolModel)
        {
            await _service.RemoveEntityAsync(rolModel);
            return RedirectToAction(nameof(Index));
        }
    }
}