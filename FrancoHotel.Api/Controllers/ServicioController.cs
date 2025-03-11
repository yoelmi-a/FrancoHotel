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
    public class ServicioController : ControllerBase
    {
        private readonly IServiciosRepository _serviciosRepository;

        public ServicioController(IServiciosRepository serviciosRepository,
                              ILogger<PisoController> logger)
        {
            _serviciosRepository = serviciosRepository;
        }

        [HttpGet("GetServicios")]
        public async Task<IActionResult> GetAll()
        {
            var servicios = await _serviciosRepository.GetAllAsync();
            return Ok(servicios);
        }

        [HttpGet("GetServicioById")]
        public async Task<IActionResult> GetById(short id)
        {
            var servicio = await _serviciosRepository.GetEntityByIdAsync(id);
            return Ok(servicio);
        }

        [HttpPost("SaveServicio")]
        public async Task<IActionResult> Post([FromBody] Servicios servicio)
        {
            await _serviciosRepository.SaveEntityAsync(servicio);
            return Ok(servicio);
        }

        [HttpPut("UpdateServicio")]
        public async Task<IActionResult> Put([FromBody] Servicios servicio)
        {
            await _serviciosRepository.UpdateEntityAsync(servicio);
            return Ok(servicio);
        }

        [HttpDelete("RemoveServicio")]
        public async Task<IActionResult> RemoveServicio(int id, int idUsuarioMod)
        {
            return Ok("Cliente borrado");
        }
    }
}
