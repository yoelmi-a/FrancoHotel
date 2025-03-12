using FrancoHotel.Domain.Entities;
using FrancoHotel.Persistence.Interfaces;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FrancoHotel.Persistence.Repositories;
using FrancoHotel.Application.Interfaces;
using FrancoHotel.Application.Services;
using FrancoHotel.Application.Dtos.TarifasDto;
using FrancoHotel.Application.Dtos.RecepcionDtos;
using FrancoHotel.Application.Dtos.TarifasDtos;

namespace FrancoHotel.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarifasController : ControllerBase
    {
        private readonly  TarifasService _tarifasService;
        public TarifasController(ITarifasService tarifasService)
        {
            _tarifasService = (TarifasService?)tarifasService;
        }

        [HttpGet("GetTarigas")]
        public async Task<IActionResult> GetAll()
        {
            var tarifas = await _tarifasService.GetAll();
            return Ok(tarifas);
        }

        [HttpGet("GetTarifasByFilter")]
        public async Task<IActionResult> GetAllByFilter([FromQuery] string estado,
                                                        [FromQuery] string comparacion,
                                                        [FromQuery] decimal precio)
        {
            Expression<Func<Tarifas, bool>> filter;

            if (comparacion.ToLower() == "mayor")
            {
                filter = t => t.Estado == estado && t.PrecioPorNoche > precio;
            }
            else if (comparacion.ToLower() == "menor")
            {
                filter = t => t.Estado == estado && t.PrecioPorNoche < precio;
            }
            else
            {
                return BadRequest("El parámetro comparacion debe ser 'mayor' o 'menor'");
            }

            var tarifasfiltradas = await _tarifasService.GetAllByFilter(filter);
            return Ok(tarifasfiltradas);
        }

        [HttpGet("GetTarifasById")]
        public async Task<IActionResult> GetById(short id)
        {
            var tarifas = await _tarifasService.GetById(id);
            return Ok(tarifas);
        }

        [HttpGet("ExistTarifas/{id}")]
        public async Task<IActionResult> GetExistTarifa(short id)
        {
            var tarifas = await _tarifasService.GetById(id);
            return Ok(tarifas);
        }

        [HttpPost("SaveTarifas")]
        public async Task<IActionResult> Post([FromBody] SaveTarifasDtos tarifas)
        {
            await _tarifasService.Save(tarifas);
            return Ok(tarifas);
        }

        [HttpPut("UpdateTarifaByCategoria")]
        public async Task<IActionResult> Put([FromQuery] string categoria, [FromQuery] decimal precio)
        {
            var result = await _tarifasService.UpdateTarifaByCategoria(categoria, precio);
            return Ok(new { message = "Tarifas actualizadas correctamente." });
        }

        [HttpPut("UpdateTarifasByFechas")]
        public async Task<IActionResult> Put([FromQuery]  DateTime fechaInicio, [FromQuery]  DateTime fechaFin, [FromQuery] decimal porcentajeCambio)
        {
            var result = await _tarifasService.UpdateTarifasByFechas(fechaInicio, fechaFin, porcentajeCambio);
            return Ok(new { message = "Tarifas actualizadas correctamente." });
        }

        [HttpPut("UpdateTarifas")]
        public async Task<IActionResult> Put([FromBody] UpdateTarifasDto tarifasDto)
        {
            var result = await _tarifasService.Update(tarifasDto);
            return Ok(result);
        }

        [HttpDelete("RemoveTarifa")]
        public async Task<IActionResult> RemoveTarifa([FromBody] RemoveTarifasDto tarifasDto)
        {
            var result = await _tarifasService.Remove(tarifasDto);
            return Ok(result);
        }

    }
}


