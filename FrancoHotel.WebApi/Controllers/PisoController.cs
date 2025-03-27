using System.Net.Http.Json;
using FrancoHotel.WebApi.Models;
using FrancoHotel.WebApi.Models.PisoModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrancoHotel.WebApi.Controllers
{
    public class PisoController : Controller
    {
        // GET: PisoController
        public async Task<IActionResult> Index()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5089/api/");
                var response = await client.GetAsync("Piso/GetPisos");

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<OperationResultModel<List<GetPisoModel>>>();
                    return View(result.Data);
                }
                else
                {
                    ViewBag.Message = "Error al obtener los pisos";
                    return View();
                }
            }
        }

        // GET: PisoController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5089/api/");
                var response = await client.GetAsync($"Piso/GetPisoById?id={id}");

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<OperationResultModel<GetPisoModel>>();
                    return View(result.Data);
                }
                else
                {
                    ViewBag.Message = "Error al obtener el piso";
                    return View();
                }
            }
        }

        // GET: PisoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PisoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PostPisoModel pisoModel)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:5089/api/");
                    var response = await client.PostAsJsonAsync<PostPisoModel>("Piso/SavePiso", pisoModel);

                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadFromJsonAsync<OperationResultModel<PostPisoModel>>();
                    }
                    else
                    {
                        ViewBag.Message = "Error al guardar el piso";
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

        // GET: PisoController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5089/api/");
                var response = await client.GetAsync($"Piso/GetPisoById?id={id}");

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<OperationResultModel<GetPisoModel>>();
                    return View(result.Data);
                }
                else
                {
                    ViewBag.Message = "Error al obtener el piso";
                    return View();
                }
            }
        }

        // PUT: PisoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(GetPisoModel pisoModel)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5089/api/");
                var response = await client.PutAsJsonAsync<GetPisoModel>("Piso/UpdatePiso", pisoModel);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<OperationResultModel<GetPisoModel>>();
                }
                else
                {
                    ViewBag.Message = "Error al actualizar el piso";
                    return View();
                }
            }
            return RedirectToAction(nameof(Index));


        }

        // GET: PisoController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5089/api/");
                var response = await client.GetAsync($"Piso/GetPisoById?id={id}");

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<OperationResultModel<RemovePisoModel>>();
                    return View(result.Data);
                }
                else
                {
                    ViewBag.Message = "Error al obtener el piso";
                    return View();
                }
            }
        }

        // POST: PisoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(RemovePisoModel pisoModel)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:5089/api/");
                    var response = await client.PutAsJsonAsync<RemovePisoModel>("Piso/RemovePiso", pisoModel);

                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadFromJsonAsync<OperationResultModel<RemovePisoModel>>();
                    }
                    else
                    {
                        ViewBag.Message = "Error al remover el piso";
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
