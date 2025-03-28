using FrancoHotel.WebApi.Models.PisoModels;
using FrancoHotel.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FrancoHotel.WebApi.Models.HabitacionModels;

namespace FrancoHotel.WebApi.Controllers
{
    public class HabitacionController : Controller
    {
        // GET: HabitacionController
        public async Task<IActionResult> Index()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5089/api/");
                var response = await client.GetAsync("Habitacion/GetHabitacion");

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<OperationResultModel<List<GetHabitacionModel>>>();
                    return View(result.Data);
                }
                else
                {
                    ViewBag.Message = "Error al obtener las la habitaciones.";
                    return View();
                }
            }
        }

        // GET: HabitacionController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5089/api/");
                var response = await client.GetAsync($"Habitacion/GetHabitacionById?id={id}");

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<OperationResultModel<GetHabitacionModel>>();
                    return View(result.Data);
                }
                else
                {
                    ViewBag.Message = "Error al obtener la habitación.";
                    return View();
                }
            }
        }

        // GET: HabitacionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HabitacionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PostHabitacionModel habitacionModel)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5089/api/");
                var response = await client.PostAsJsonAsync<PostHabitacionModel>("Habitacion/SaveHabitacion", habitacionModel);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<OperationResultModel<PostHabitacionModel>>();
                }
                else
                {
                    ViewBag.Message = "Error al guardar la habitación.";
                    return View();
                }
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: HabitacionController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5089/api/");
                var response = await client.GetAsync($"Habitacion/GetHabitacionById?id={id}");

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<OperationResultModel<GetHabitacionModel>>();
                    return View(result.Data);
                }
                else
                {
                    ViewBag.Message = "Error al obtener la habitación.";
                    return View();
                }
            }
        }

        // POST: HabitacionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(GetHabitacionModel habitacionModel)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:5089/api/");
                    var response = await client.PutAsJsonAsync<GetHabitacionModel>("Habitacion/UpdateHabitacion", habitacionModel);

                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadFromJsonAsync<OperationResultModel<GetHabitacionModel>>();
                    }
                    else
                    {
                        ViewBag.Message = "Error al actualizar la habitación.";
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

        // GET: HabitacionController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5089/api/");
                var response = await client.GetAsync($"Habitacion/GetHabitacionById?id={id}");

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<OperationResultModel<RemoveHabitacionModel>>();
                    return View(result.Data);
                }
                else
                {
                    ViewBag.Message = "Error al obtener la habitación.";
                    return View();
                }
            }
        }

        // POST: HabitacionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(RemoveHabitacionModel habitacionModel)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:5089/api/");
                    var response = await client.PutAsJsonAsync<RemoveHabitacionModel>("Habitacion/RemoveHabitacion", habitacionModel);

                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadFromJsonAsync<OperationResultModel<RemoveHabitacionModel>>();
                    }
                    else
                    {
                        ViewBag.Message = "Error al remover la habitación.";
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
