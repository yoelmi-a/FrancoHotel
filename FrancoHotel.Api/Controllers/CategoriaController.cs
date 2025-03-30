using FrancoHotel.Application.Dtos.CategoriaDtos;
using FrancoHotel.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrancoHotel.Api.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet("GetCategoria")]
        public async Task<IActionResult> Index()
        {
            var result = await _categoriaService.GetAll();
            return Ok(result);
        }

        [HttpGet("GetCategoriaById")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _categoriaService.GetById(id);
            return Ok(result);
        }

        [HttpPost("SaveCategoria")]
        public async Task<IActionResult> Post([FromBody] SaveCategoriaDto categoria)
        {
            var result = await _categoriaService.Save(categoria);
            return Ok(result);
        }

        [HttpPut("UpdateCategoria")]
        public async Task<IActionResult> Put([FromBody] UpdateCategoriaDto categoria)
        {
            var result = await _categoriaService.Update(categoria);
            return Ok(result);
        }

        [HttpPut("RemoveCategoria")]
        public async Task<IActionResult> Delete([FromBody] RemoveCategoriaDto categoria)
        {
            var result = await _categoriaService.Remove(categoria);
            return Ok(result);
        }
    }
}
