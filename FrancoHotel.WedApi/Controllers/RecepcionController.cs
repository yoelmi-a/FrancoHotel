using FrancoHotel.WedApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrancoHotel.WedApi.Controllers
{
    public class RecepcionController : Controller
    {
        // GET: RecepcionController
        public async Task<IActionResult> Index()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5089/api/");
                var response = await client.GetAsync("Recepcion/GetRecepcion");

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<OperationResultModel<List<GetRecepcionModel>>>();
                    return View(result.Data);
                }
                else
                {
                    ViewBag.Message = "Error al obtener los Reserva";
                    return View();
                }
            }
        }

        // GET: RecepcionController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5089/api/");
                var response = await client.GetAsync($"Recepcion/GetRecepcionById?id={id}");

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<OperationResultModel<GetRecepcionModel>>();
                    return View(result.Data);
                }
                else
                {
                    ViewBag.Message = "Error al obtener el Recepcion";
                    return View();
                }
            }
        }

        // GET: RecepcionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RecepcionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PostRecepcionModel postRecepcionModel)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:5089/api/");
                    var response = await client.PostAsJsonAsync<PostRecepcionModel>("Recepcion/SaveRecepcion", postRecepcionModel);

                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadFromJsonAsync<OperationResultModel<PostRecepcionModel>>();
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RecepcionController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5089/api/");
                var response = await client.GetAsync($"Recepcion/GetRecepcionById?id={id}");

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<OperationResultModel<GetRecepcionModel>>();
                    return View(result.Data);
                }
                else
                {
                    ViewBag.Message = "Error al obtener el piso";
                    return View();
                }
            }
        }

        // POST: RecepcionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(GetRecepcionModel recepcion)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5089/api/");
                var response = await client.PutAsJsonAsync<GetRecepcionModel>("Recepcion/UpdateRecepcion", recepcion);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<OperationResultModel<GetRecepcionModel>>();
                }
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: RecepcionController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5089/api/");
                var response = await client.GetAsync($"Recepcion/GetRecepcionById?id={id}");

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<OperationResultModel<RemoveRecepcionModel>>();
                    return View(result.Data);
                }
                else
                {
                    ViewBag.Message = "Error al obtener el Recepcion";
                    return View();
                }
            }
        }

        // POST: RecepcionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(RemoveRecepcionModel remove)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:5089/api/");
                    var response = await client.PutAsJsonAsync<RemoveRecepcionModel>("Recepcion/RemoveRecepcion", remove);

                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadFromJsonAsync<OperationResultModel<RemoveRecepcionModel>>();
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