using FrancoHotel.Domain.Entities;
using FrancoHotel.Persistence.Interfaces;
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
        public async Task<IActionResult> Get()
        {
            var pisos = await _pisoRepository.GetAllAsync();
            return Ok(pisos);
        }

        [HttpGet("GetPisoById")]
        public async Task<IActionResult> Get(int id)
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

        [HttpPost("UpdatePiso")]
        public async Task<IActionResult> Put([FromBody] Piso piso)
        {
            await _pisoRepository.UpdateEntityAsync(piso);
            return Ok(piso);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
