using FrancoHotel.WebApi.Models;
using FrancoHotel.WebApi.Models.ClienteModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FrancoHotel.WebApi.Controllers.Cliente
{
    public class ClienteController : Controller
    {
        // GET: ClienteController
        public async Task<IActionResult> Index()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5089/api/");
                var response = await client.GetAsync("Cliente/GetClientes");

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<OperationResultModel<List<GetClienteModel>>>();
                    return View(result.Data);
                }
                else
                {
                    ViewBag.Message = "Error al obtener clientes";
                    return View();
                }
            }
        }

        // GET: ClienteController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5089/api/");
                var response = await client.GetAsync($"Cliente/GetClienteById?id={id}");

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<OperationResultModel<GetClienteModel>>();
                    return View(result.Data);
                }
                else
                {
                    ViewBag.Message = "Error al ver el detalle del cliente";
                    return View();
                }
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
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:5089/api/");
                    var response = await client.PostAsJsonAsync<PostClienteModel>("Cliente/SaveCliente", clienteModel);

                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadFromJsonAsync<OperationResultModel<PostClienteModel>>();
                    }
                    else
                    {
                        ViewBag.Message = "Error al crear el cliente";
                        return View();
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClienteController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5089/api/");
                var response = await client.GetAsync($"Cliente/GetClienteById?id={id}");

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<OperationResultModel<GetClienteModel>>();
                    return View(result.Data);
                }
                else
                {
                    ViewBag.Message = "Error al obtener el cliente";
                    return View();
                }
            }
        }

        // PUT: ClienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(GetClienteModel clienteModel)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:5089/api/");
                    var response = await client.PutAsJsonAsync("Cliente/UpdateCliente", clienteModel);

                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadFromJsonAsync<OperationResultModel<GetClienteModel>>();
                    }
                    else
                    {
                        ViewBag.Message = "Error al editar el cliente";
                        return View();
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClienteController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5089/api/");
                var response = await client.GetAsync($"Cliente/GetClienteById?id={id}");


                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<OperationResultModel<RemoveClienteModel>>();
                    return View(result.Data);
                }
                else
                {
                    ViewBag.Message = "Error al obtener el cliente";
                    return View();
                }
            }
        }

        // POST: ClienteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(RemoveClienteModel clienteModel)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:5089/api/");
                    var response = await client.PutAsJsonAsync<RemoveClienteModel>("Cliente/RemoveCliente", clienteModel);

                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadFromJsonAsync<OperationResultModel<RemoveClienteModel>>();
                    }
                    else
                    {
                        ViewBag.Message = "Error al remover el cliente";
                        return View();
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}