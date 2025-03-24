using FrancoHotel.Application.Dtos.ClienteDtos;
using FrancoHotel.Persistence.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FrancoHotel.Web.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteService _clienteService;
        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        // GET: ClienteController
        public async Task<IActionResult> Index()
        {
            var result = await _clienteService.GetAll();
            if (result.Success)
            {
                List<UpdateClienteDtos> clientes = (List<UpdateClienteDtos>)result.Data;
                return View(clientes);
            }
            return View();
        }

        // GET: ClienteController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var result = await _clienteService.GetById(id);
            if (result.Success)
            {
                UpdateClienteDtos cliente = result.Data;
                return View(cliente);
            }
            return View();
        }

        // GET: ClienteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SaveClienteDtos saveClienteDto)
        {
            try
            {
                var result = await _clienteService.Save(saveClienteDto);
                if (result.Success)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError(string.Empty, result.Message);
                return View(saveClienteDto);
            }
            catch
            {
                return View();
            }
        }

        // GET: ClienteController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _clienteService.GetById(id);
            if (result.Success)
            {
                UpdateClienteDtos cliente = (UpdateClienteDtos)result.Data;
                return View(cliente);
            }
            return View();
        }

        // POST: ClienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateClienteDtos updateClienteDto)
        {
            try
            {
                var result = await _clienteService.Update(updateClienteDto);
                if (result.Success)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError(string.Empty, result.Message);
                return View(updateClienteDto);
            }
            catch
            {
                return View();
            }
        }
        /*
                // GET: RolUsuarioController/Delete/5
                public ActionResult Delete(int id)
                {
                    return View();
                }

                // POST: RolUsuarioController/Delete/5
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