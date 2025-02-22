using FrancoHotel.Domain.Entities;
using FrancoHotel.Persistence.Interfaces;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrancoHotel.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HabitacionController : ControllerBase
    {

        private readonly IHabitacionRepository _habitacionRepository;

        public HabitacionController(IHabitacionRepository habitacionRepository,
                                  ILogger<PisoController> logger)
        {
            _habitacionRepository = habitacionRepository;
        }

        [HttpGet("GetHabitacion")]
        public async Task<IActionResult> GetAll()
        {
            var habitacion = await _habitacionRepository.GetAllAsync();
            return Ok(habitacion);
        }

        [HttpGet("GetHabitacionByFilter")]
        public async Task<IActionResult> GetAllbyFilter(Expression<Func<Habitacion, bool>> filter)
        {
            var estadoHabitacion = await _habitacionRepository.GetAllAsync(filter);
            return Ok(estadoHabitacion);
        }

        [HttpGet("GetHabitacionById")]
        public async Task<IActionResult> GetById(short id)
        {
            var estadoHabitacion = await _habitacionRepository.GetEntityByIdAsync(id);
            return Ok(estadoHabitacion);
        }

        [HttpGet("ExistHabitacion")]
        public async Task<IActionResult> GetExistPiso(Expression<Func<Habitacion, bool>> filter)
        {
            var estadoHabitacion = await _habitacionRepository.Exists(filter);
            return Ok(estadoHabitacion);
        }

        [HttpPost("SaveHabitacion")]
        public async Task<IActionResult> Post([FromBody] Habitacion habitacion)
        {
            await _habitacionRepository.SaveEntityAsync(habitacion);
            return Ok(habitacion);
        }

        [HttpPut("UpdateHabitacion")]
        public async Task<IActionResult> Put([FromBody] Habitacion habitacion)
        {
            await _habitacionRepository.UpdateEntityAsync(habitacion);
            return Ok(habitacion);
        }

        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
        }
    }
}
