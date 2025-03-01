using FrancoHotel.Domain.Entities;
using FrancoHotel.Persistence.Interfaces;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrancoHotel.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoHabitacionController : ControllerBase
    {
        private readonly IEstadoHabitacionRepository _estadoHabitacionRepository;

        public EstadoHabitacionController(IEstadoHabitacionRepository estadoHabitacionRepository,
                              ILogger<PisoController> logger)
        {
            _estadoHabitacionRepository = estadoHabitacionRepository;
        }

        [HttpGet("GetEstadoHabitacion")]
        public async Task<IActionResult> GetAll()
        {
            var estadoHabitacion = await _estadoHabitacionRepository.GetAllAsync();
            return Ok(estadoHabitacion);
        }

        [HttpGet("GetEstadoHabitacionById")]
        public async Task<IActionResult> GetById(short id)
        {
            var estadoHabitacion = await _estadoHabitacionRepository.GetEntityByIdAsync(id);
            return Ok(estadoHabitacion);
        }

        [HttpPost("SaveEstadoHabitacion")]
        public async Task<IActionResult> Post([FromBody] EstadoHabitacion estadoHabitacion)
        {
            await _estadoHabitacionRepository.SaveEntityAsync(estadoHabitacion);
            return Ok(estadoHabitacion);
        }

        [HttpPut("UpdateEstadoHabitacion")]
        public async Task<IActionResult> Put([FromBody] EstadoHabitacion estadoHabitacion)
        {
            await _estadoHabitacionRepository.UpdateEntityAsync(estadoHabitacion);
            return Ok(estadoHabitacion);
        }
    }
}
