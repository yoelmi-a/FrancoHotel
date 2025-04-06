using FrancoHotel.WebApi.Models.UsuarioModels;
using FrancoHotel.WebApi.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FrancoHotel.WebApi.Controllers.Usuario
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepository _repository;
        public UsuarioController(IUsuarioRepository repository)
        {
            _repository = repository;
        }
        // GET: UsuarioController
        public async Task<IActionResult> Index()
        {
            try
            {
                var usuarios = await _repository.GetAllAsync();
                return View(usuarios);
            }
            catch (Exception)
            {
                ViewBag.Message = "Error al obtener los usuarios";
                return View();
            }
        }

        // GET: UsuarioController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var usuario = await _repository.GetByIdAsync(id);
                return View(usuario);
            }
            catch (Exception)
            {
                ViewBag.Message = "Error al ver el detalle del usuario";
                return View();
            }
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
            try
            {
                await _repository.CreateEntityAsync(usuarioModel);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                ViewBag.Message = "Error al crear el usuario";
                return View();
            }
        }

        // GET: UsuarioController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var usuario = await _repository.GetByIdAsync(id);
                return View(usuario);
            }
            catch (Exception)
            {
                ViewBag.Message = "Error al obtener el usuario";
                return View();
            }
        }

        // PUT: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(GetUsuarioModel usuarioModel)
        {
            try
            {
                await _repository.UpdateEntityAsync(usuarioModel);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                ViewBag.Message = "Error al editar el usuario";
                return View();
            }
        }

        // GET: UsuarioController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var usuario = await _repository.GetByIdRemoveAsync(id);
                return View(usuario);
            }
            catch (Exception)
            {
                ViewBag.Message = "Error al obtener el usuario";
                return View();
            }
        }

        // POST: UsuarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(RemoveUsuarioModel usuarioModel)
        {
            try
            {
                await _repository.RemoveEntityAsync(usuarioModel);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                ViewBag.Message = "Error al eliminar el usuario";
                return View();
            }
        }
    }
}