using FrancoHotel.WebApi.Models.UsuarioModels;
using FrancoHotel.WebApi.Repository.Interfaces;
using FrancoHotel.WebApi.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FrancoHotel.WebApi.Controllers.Usuario
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _service;
        public UsuarioController(IUsuarioService service)
        {
            _service = service;
        }
        // GET: UsuarioController
        public async Task<IActionResult> Index()
        {
            var usuarios = await _service.GetAllAsync();
            return View(usuarios);
        }

        // GET: UsuarioController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var usuario = await _service.GetByIdAsync(id);
            return View(usuario);
        }

        // GET: UsuarioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PostUsuarioModel usuarioModel)
        {
            await _service.CreateEntityAsync(usuarioModel);
            return RedirectToAction(nameof(Index));
        }

        // GET: UsuarioController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var usuario = await _service.GetByIdAsync(id);
            return View(usuario);
        }

        // PUT: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(GetUsuarioModel usuarioModel)
        {
            await _service.UpdateEntityAsync(usuarioModel);
            return RedirectToAction(nameof(Index));
        }

        // GET: UsuarioController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var usuario = await _service.GetByIdRemoveAsync(id);
            return View(usuario);
        }

        // POST: UsuarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(RemoveUsuarioModel usuarioModel)
        {
            await _service.RemoveEntityAsync(usuarioModel);
            return RedirectToAction(nameof(Index));
        }
    }
}