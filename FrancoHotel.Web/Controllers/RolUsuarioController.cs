using FrancoHotel.Application.Dtos.RolUsuariosDtos;
using FrancoHotel.Persistence.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FrancoHotel.Web.Controllers
{
    public class RolUsuarioController : Controller
    {
        private readonly IRolUsuarioService _rolUsuarioService;
        public RolUsuarioController(IRolUsuarioService rolUsuarioService)
        {
            _rolUsuarioService = rolUsuarioService;
        }

        // GET: RolUsuarioController
        public async Task<IActionResult> Index()
        {
            var result = await _rolUsuarioService.GetAll();
            if (result.Success)
            {
                List<UpdateRolUsuarioDtos> rol = (List<UpdateRolUsuarioDtos>)result.Data;
                return View(rol);
            }
            return View();
        }

        // GET: RolUsuarioController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var result = await _rolUsuarioService.GetById(id);
            if (result.Success)
            {
                UpdateRolUsuarioDtos rol = result.Data;
                return View(rol);
            }
            return View();
        }

        // GET: RolUsuarioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RolUsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SaveRolUsuarioDtos saveRolUsuarioDtos)
        {
            try
            {
                var result = await _rolUsuarioService.Save(saveRolUsuarioDtos);
                if (result.Success)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError(string.Empty, result.Message);
                return View(saveRolUsuarioDtos);
            }
            catch
            {
                return View();
            }
        }

        // GET: RolUsuarioController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _rolUsuarioService.GetById(id);
            if (result.Success)
            {
                UpdateRolUsuarioDtos rol = (UpdateRolUsuarioDtos)result.Data;
                return View(rol);
            }
            return View();
        }

        // POST: RolUsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateRolUsuarioDtos updateRolUsuarioDtos)
        {
            try
            {
                var result = await _rolUsuarioService.Update(updateRolUsuarioDtos);
                if (result.Success)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError(string.Empty, result.Message);
                return View(updateRolUsuarioDtos);
            }
            catch
            {
                return View();
            }
        }

        // GET: RolUsuarioController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _rolUsuarioService.GetById(id);

            if (result.Success)
            {
                RemoveRolUsuarioDtos remove = new RemoveRolUsuarioDtos()
                {
                    IdRolUsuario = result.Data.IdRolUsuario,
                    Fecha = result.Data.Fecha,
                    Usuario = result.Data.Usuario
                };
                return View(remove);
            }
            return View();
        }

        // POST: RolUsuarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(RemoveRolUsuarioDtos removeRolUsuarioDtos)
        {
            try
            {
                await _rolUsuarioService.Remove(removeRolUsuarioDtos);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
