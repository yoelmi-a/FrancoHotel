using System.Linq.Expressions;
using FrancoHotel.Domain.Entities;
using FrancoHotel.Persistence.Interfaces;
using FrancoHotel.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FrancoHotel.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PisoController : ControllerBase
    {
        private readonly IPisoRepository _pisoRepository;

        public PisoController(IPisoRepository pisoRepository,
                              ILogger<PisoController> logger)
        {
            _pisoRepository = pisoRepository;
        }

        [HttpGet("GetPisos")]
        public async Task<IActionResult> GetAll()
        {
            var pisos = await _pisoRepository.GetAllAsync();
            return Ok(pisos);
        }

        [HttpGet("GetPisoByEstado")]
        public async Task<IActionResult> GetByEstado(bool? estado)
        {
            var pisos = await _pisoRepository.GetPisoByEstado(estado);
            return Ok(pisos);
        }

        [HttpGet("GetPisoById")]
        public async Task<IActionResult> GetById(int id)
        {
            var piso = await _pisoRepository.GetEntityByIdAsync(id);
            return Ok(piso);
        }

        [HttpPost("SavePiso")]
        public async Task<IActionResult> Post([FromBody] Piso piso)
        {
            await _pisoRepository.SaveEntityAsync(piso);
            return Ok(piso);
        }

        [HttpPut("UpdatePiso")]
        public async Task<IActionResult> Put([FromBody] Piso piso)
        {
            await _pisoRepository.UpdateEntityAsync(piso);
            return Ok(piso);
        }

        [HttpDelete("RemovePiso")]
        public async Task<IActionResult> RemovePiso(int id, int idUsuarioMod)
        {
            var entity = await _pisoRepository.GetEntityByIdAsync(id);
            if (entity == null)
            {
                return NotFound("Piso no encontrado");
            }
            entity.Borrado = true;
            entity.BorradoPorU = idUsuarioMod;
            entity.UsuarioMod = idUsuarioMod;
            entity.FechaModificacion = DateTime.Now;
            await _pisoRepository.UpdateEntityAsync(entity);
            return Ok("Piso borrado");
        }
    }
}
