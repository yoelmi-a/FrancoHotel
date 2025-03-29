using System.Net.Http.Json;
using FrancoHotel.WedApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrancoHotel.WedApi.Controllers
{
    public class TarifasController : Controller
    {
        // GET: TarifasController
        public async Task<ActionResult> Index()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5089/api/");
                var response = await client.GetAsync("Tarifas/GetTarifas");

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<OperationResultModel<List<GetTarifasModel>>>();
                    return View(result.Data);
                }
                else
                {
                    ViewBag.Message = "Error al obtener los Tarifas";
                    return View();
                }
            }
        }

        // GET: TarifasController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5089/api/");
                var response = await client.GetAsync($"Tarifas/GetTarifasById?id={id}");

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<OperationResultModel<GetTarifasModel>>();
                    return View(result.Data);
                }
                else
                {
                    ViewBag.Message = "Error al obtener el Tarifas";
                    return View();
                }
            }
        }

        // GET: TarifasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TarifasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PostTarifasModel postTarifasModel)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:5089/api/");
                    var response = await client.PostAsJsonAsync<PostTarifasModel>("Tarifas/SaveTarifas", postTarifasModel);

                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadFromJsonAsync<OperationResultModel<PostTarifasModel>>();
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TarifasController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5089/api/");
                var response = await client.GetAsync($"Tarifas/GetTarifasById?id={id}");

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<OperationResultModel<GetTarifasModel>>();
                    return View(result.Data);
                }
                else
                {
                    ViewBag.Message = "Error al obtener el Tarifas";
                    return View();
                }
            }
        }

        // POST: TarifasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(GetTarifasModel tarifas)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5089/api/");
                var response = await client.PutAsJsonAsync<GetTarifasModel>("Tarifas/UpdateTarifas", tarifas);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<OperationResultModel<GetTarifasModel>>();
                }
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: TarifasController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5089/api/");
                var response = await client.GetAsync($"Tarifas/GetTarifasById?id={id}");

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<OperationResultModel<RemoveTarifasModel>>();
                    return View(result.Data);
                }
                else
                {
                    ViewBag.Message = "Error al obtener el Tarifas";
                    return View();
                }
            }
        }

        // POST: TarifasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(RemoveTarifasModel remove)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:5089/api/");
                    var response = await client.PutAsJsonAsync<RemoveTarifasModel>("Tarifas/RemoveTarifas", remove);

                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadFromJsonAsync<OperationResultModel<RemoveTarifasModel>>();
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
