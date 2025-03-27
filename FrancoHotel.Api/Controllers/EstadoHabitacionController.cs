using FrancoHotel.Application.Dtos.EstadoHabitacionDtos;
using FrancoHotel.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FrancoHotel.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoHabitacionController : ControllerBase
    {
        private readonly IEstadoHabitacionService _estadoHabitacionService;

        public EstadoHabitacionController(IEstadoHabitacionService estadoHabitacionService)
        {
            _estadoHabitacionService = estadoHabitacionService;
        }

        [HttpGet("GetEstadoHabitacion")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _estadoHabitacionService.GetAll();
            return Ok(result);
        }

        [HttpGet("GetEstadoHabitacionById")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _estadoHabitacionService.GetById(id);
            return Ok(result);
        }

        [HttpPost("SaveEstadoHabitacion")]
        public async Task<IActionResult> Post([FromBody] SaveEstadoHabitacionDto estadoHabitacion)
        {
            var result = await _estadoHabitacionService.Save(estadoHabitacion);
            return Ok(result);
        }

        [HttpPut("UpdateEstadoHabitacion")]
        public async Task<IActionResult> Put([FromBody] UpdateEstadoHabitacionDto estadoHabitacion)
        {
            var result = await _estadoHabitacionService.Update(estadoHabitacion);
            return Ok(result);
        }

        [HttpDelete("RemoveEstadoHabitacion")]
        public async Task<IActionResult> RemoveEsEstadoHabitacion([FromBody] RemoveEstadoHabitacionDto estadoHabitacion)
        {
            var result = await _estadoHabitacionService.Remove(estadoHabitacion);
            return Ok(result);
        }
    }
}
