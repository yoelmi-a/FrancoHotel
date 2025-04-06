using FrancoHotel.WebApi.Models;
using FrancoHotel.WebApi.Models.ClienteModels;
using FrancoHotel.WebApi.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FrancoHotel.WebApi.Controllers.Cliente
{
    public class ClienteController : Controller
    {
        private readonly IClienteRepository _repository;
        public ClienteController(IClienteRepository repository)
        {
            _repository = repository;
        }
        // GET: ClienteController
        public async Task<IActionResult> Index()
        {
            try
            {
                var result = await _repository.GetAllAsync();
                return View(result);
            }
            catch (Exception)
            {
                ViewBag.Message = "Error al obtener los clientes";
                return View();
            }
        }

        // GET: ClienteController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var cliente = await _repository.GetByIdAsync(id);
                return View(cliente);
            }
            catch (Exception)
            {
                ViewBag.Message = "Error al ver el detalle del cliente";
                return View();
            }
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
            try
            {
                await _repository.CreateEntityAsync(clienteModel);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                ViewBag.Message = "Error al crear el cliente";
                return View();
            }
        }

        // GET: ClienteController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var cliente = await _repository.GetByIdAsync(id);
                return View(cliente);
            }
            catch (Exception)
            {
                ViewBag.Message = "Error al editar el cliente";
                return View();
            }
        }

        // PUT: ClienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(GetClienteModel clienteModel)
        {
            try
            {
                await _repository.UpdateEntityAsync(clienteModel);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                ViewBag.Message = "Error al editar el cliente";
                return View();
            }
        }

        // GET: ClienteController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var cliente = await _repository.GetByIdRemoveAsync(id);
                return View(cliente);
            }
            catch (Exception)
            {
                ViewBag.Message = "Error al eliminar el cliente";
                return View();
            }
        }

        // POST: ClienteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(RemoveClienteModel clienteModel)
        {
            try
            {
                await _repository.RemoveEntityAsync(clienteModel);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                ViewBag.Message = "Error al eliminar el cliente";
                return View();
            }
        }
    }
}