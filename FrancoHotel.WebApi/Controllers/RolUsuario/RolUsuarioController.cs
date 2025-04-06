using FrancoHotel.WebApi.Models.RolUsuarioModels;
using FrancoHotel.WebApi.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FrancoHotel.WebApi.Controllers.RolUsuario
{
    public class RolUsuarioController : Controller
    {
        private readonly IRolUsuarioRepository _repository;
        public RolUsuarioController(IRolUsuarioRepository repository)
        {
            _repository = repository;
        }
        // GET: RolUsuarioController
        public async Task<IActionResult> Index()
        {
            try
            {
                var result = await _repository.GetAllAsync();
                return View(result);
            }
            catch (Exception)
            {
                ViewBag.Message = "Error al obtener los roles";
                return View();
            }
        }
        // GET: RolUsuarioController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var result = await _repository.GetByIdAsync(id);
                return View(result);
            }
            catch (Exception)
            {
                ViewBag.Message = "Error al ver el detalle del rol";
                return View();
            }
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
            try
            {
                await _repository.CreateEntityAsync(rolModel);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                ViewBag.Message = "Error al crear el rol";
                return View();
            }
        }

        // GET: RolUsuarioController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var result = await _repository.GetByIdAsync(id);
                return View(result);
            }
            catch (Exception)
            {
                ViewBag.Message = "Error al obtener el rol para editar";
                return View();
            }
        }

        // POST: RolUsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(GetRolUsuarioModel rolModel)
        {
            try
            {
                await _repository.UpdateEntityAsync(rolModel);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                ViewBag.Message = "Error al editar el rol";
                return View();
            }
        }

        // GET: RolUsuarioController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _repository.GetByIdRemoveAsync(id);
                return View(result);
            }
            catch (Exception)
            {
                ViewBag.Message = "Error al obtener el rol para eliminar";
                return View();
            }
        }

        // POST: RolUsuarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(RemoveRolUsuarioModel rolModel)
        {
            try
            {
                await _repository.RemoveEntityAsync(rolModel);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                ViewBag.Message = "Error al eliminar el rol";
                return View();
            }
        }
    }
}