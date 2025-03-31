using FrancoHotel.WebApi.Models;
using FrancoHotel.WebApi.Models.RolUsuarioModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrancoHotel.WebApi.Controllers.RolUsuario
{
    public class RolUsuarioController : Controller
    {
        // GET: RolUsuarioController
        public async Task<IActionResult> Index()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5089/api/");
                var response = await client.GetAsync("RolUsuario/GetRolUsuarios");

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<OperationResultModel<List<GetRolUsuarioModel>>>();
                    return View(result.Data);
                }
                else
                {
                    ViewBag.Message = "Error al obtener los roles";
                    return View();
                }
            }
        }
        // GET: RolUsuarioController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5089/api/");
                var response = await client.GetAsync($"RolUsuario/GetRolUsuarioById?id={id}");

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<OperationResultModel<GetRolUsuarioModel>>();
                    return View(result.Data);
                }
                else
                {
                    ViewBag.Message = "Error al obtener el rol";
                    return View();
                }
            }
        }

        // GET: RolUsuarioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RolUsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PostRolUsuarioModel rolModel)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:5089/api/");
                    var response = await client.PostAsJsonAsync<PostRolUsuarioModel>("RolUsuario/SaveRolUsuario", rolModel);

                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadFromJsonAsync<OperationResultModel<PostRolUsuarioModel>>();
                    }
                    else
                    {
                        ViewBag.Message = "Error al guardar el rol";
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

        // GET: RolUsuarioController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5089/api/");
                var response = await client.GetAsync($"RolUsuario/GetRolUsuarioById?id={id}");

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<OperationResultModel<GetRolUsuarioModel>>();
                    return View(result.Data);
                }
                else
                {
                    ViewBag.Message = "Error al obtener el rol";
                    return View();
                }
            }
        }

        // POST: RolUsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(GetRolUsuarioModel rolModel)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:5089/api/");
                    var response = await client.PutAsJsonAsync<GetRolUsuarioModel>("RolUsuario/UpdateRolUsuario", rolModel);

                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadFromJsonAsync<OperationResultModel<GetRolUsuarioModel>>();
                    }
                    else
                    {
                        ViewBag.Message = "Error al actualizar el rol";
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

        // GET: RolUsuarioController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5089/api/");
                var response = await client.GetAsync($"RolUsuario/GetRolUsuarioById?id={id}");

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<OperationResultModel<RemoveRolUsuarioModel>>();
                    return View(result.Data);
                }
                else
                {
                    ViewBag.Message = "Error al obtener el rol";
                    return View();
                }
            }
        }

        // POST: RolUsuarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(RemoveRolUsuarioModel rolModel)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:5089/api/");
                    var response = await client.PutAsJsonAsync<RemoveRolUsuarioModel>("RolUsuario/RemoveRolUsuario", rolModel);

                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadFromJsonAsync<OperationResultModel<RemoveRolUsuarioModel>>();
                    }
                    else
                    {
                        ViewBag.Message = "Error al remover el rol";
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