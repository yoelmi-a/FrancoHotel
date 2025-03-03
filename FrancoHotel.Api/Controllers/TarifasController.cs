using FrancoHotel.Domain.Entities;
using FrancoHotel.Persistence.Interfaces;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FrancoHotel.Persistence.Repositories;

namespace FrancoHotel.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarifasController : ControllerBase
    {
        private readonly ITarifasRepository _tarifasRepository;
        public TarifasController(ITarifasRepository tarifasRepository,
                                    ILogger<TarifasController> logger)
        {
            _tarifasRepository = tarifasRepository;
        }
        [HttpGet("GetTarigas")]
        public async Task<IActionResult> GetAll()
        {
            var tarifas = await _tarifasRepository.GetAllAsync();
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

            var tarifasfiltradas = await _tarifasRepository.GetAllAsync(filter);
            return Ok(tarifasfiltradas);
        }
        [HttpGet("GetTarifasById")]
        public async Task<IActionResult> GetById(short id)
        {
            var tarifas = await _tarifasRepository.GetEntityByIdAsync(id);
            return Ok(tarifas);
        }
        [HttpGet("ExistTarifas/{id}")]
        public async Task<IActionResult> GetExistTarifa(short id)
        {
            // Obtener la tarifa usando el ID
            var tarifas = await _tarifasRepository.GetEntityByIdAsync(id);

            // Verificar si la tarifa existe y si su descuento es mayor a cero
            if (tarifas != null && tarifas.Descuento > 0)
            {
                return Ok(true);
            }

            return Ok(false);
        }
        [HttpPost("SaveTarifas")]
        public async Task<IActionResult> Post([FromBody] Tarifas tarifas)
        {
            await _tarifasRepository.SaveEntityAsync(tarifas);
            return Ok(tarifas);
        }
        [HttpPut("UpdateTarifas")]
        public async Task<IActionResult> Put([FromBody] Tarifas tarifas)
        {
            await _tarifasRepository.UpdateEntityAsync(tarifas);
            return Ok(tarifas);
        }

        [HttpDelete("RemoveTarifa")]
        public async Task<IActionResult> RemoveTarifa(int id, int idUsuarioMod)
        {
            var entity = await _tarifasRepository.GetEntityByIdAsync(id);
            if (entity == null)
            {
                return NotFound("Tarifa no encontrada");
            }
            entity.Borrado = true;
            entity.BorradoPorU = idUsuarioMod;
            entity.UsuarioMod = idUsuarioMod;
            entity.FechaModificacion = DateTime.Now;
            await _tarifasRepository.UpdateEntityAsync(entity);
            return Ok("Tarifa borrada");
        }
    }
}


