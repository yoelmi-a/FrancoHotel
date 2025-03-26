using FrancoHotel.Application.Dtos.UsuariosDtos;
using FrancoHotel.Persistence.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FrancoHotel.Web.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        // GET: UsuarioController
        public async Task<ActionResult> Index()
        {
            var result = await _usuarioService.GetAll();
            if (result.Success)
            {
                List<UpdateUsuarioDtos> usuarios = (List<UpdateUsuarioDtos>)result.Data;
                return View(usuarios);
            }
            return View();
        }

        // GET: UsuarioController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var result = await _usuarioService.GetById(id);
            if (result.Success)
            {
                UpdateUsuarioDtos usuario = result.Data;
                return View(usuario);
            }
            return View();
        }

        // GET: UsuarioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SaveUsuarioDtos saveUsuarioDtos)
        {
            try
            {
                var result = await _usuarioService.Save(saveUsuarioDtos);
                if (result.Success)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError(string.Empty, result.Message);
                return View(saveUsuarioDtos);
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuarioController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _usuarioService.GetById(id);
            if (result.Success)
            {
                UpdateUsuarioDtos usuario = (UpdateUsuarioDtos)result.Data;
                return View(usuario);
            }
            return View();
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateUsuarioDtos updateUsuarioDtos)
        {
            try
            {
                var result = await _usuarioService.Update(updateUsuarioDtos);
                if (result.Success)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError(string.Empty, result.Message);
                return View(updateUsuarioDtos);
            }
            catch
            {
                return View();
            }
        }
/*
        // GET: UsuarioController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsuarioController/Delete/5
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
*/
    }
}