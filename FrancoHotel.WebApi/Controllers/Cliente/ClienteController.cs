using FrancoHotel.WebApi.Models;
using FrancoHotel.WebApi.Models.ClienteModels;
using FrancoHotel.WebApi.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FrancoHotel.WebApi.Controllers.Cliente
{
    public class ClienteController : Controller
    {
        private readonly IClienteService _service;
        public ClienteController(IClienteService service)
        {
            _service = service;
        }

        // GET: ClienteController
        public async Task<IActionResult> Index()
        {
            var clientes = await _service.GetAllAsync();
            return View(clientes);
        }

        // GET: ClienteController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var cliente = await _service.GetByIdAsync(id);
            return View(cliente);
        }

        // GET: ClienteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PostClienteModel clienteModel)
        {
            await _service.CreateEntityAsync(clienteModel);
            return RedirectToAction(nameof(Index));
        }

        // GET: ClienteController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var cliente = await _service.GetByIdAsync(id);
            return View(cliente);
        }

        // PUT: ClienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(GetClienteModel clienteModel)
        {
            await _service.UpdateEntityAsync(clienteModel);
            return RedirectToAction(nameof(Index));
        }

        // GET: ClienteController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var cliente = await _service.GetByIdRemoveAsync(id);
            return View(cliente);
        }

        // POST: ClienteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(RemoveClienteModel clienteModel)
        {
            await _service.RemoveEntityAsync(clienteModel);
            return RedirectToAction(nameof(Index));
        }
    }
}
