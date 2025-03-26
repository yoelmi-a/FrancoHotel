using FrancoHotel.Domain.Entities;
using FrancoHotel.Persistence.Interfaces;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using FrancoHotel.Persistence.Repositories;
using FrancoHotel.Application.Interfaces;
using FrancoHotel.Application.Dtos.HabitacionDtos;

namespace FrancoHotel.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HabitacionController : ControllerBase
    {

        private readonly IHabitacionService _habitacionService;

        public HabitacionController(IHabitacionService habitacionService,
                                  ILogger<PisoController> logger)
        {
            _habitacionService = _habitacionService;
        }

        [HttpGet("GetHabitacion")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _habitacionService.GetAll();
            return Ok(result);
        }

        [HttpGet("GetHabitacionById")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _habitacionService.GetById(id);
            return Ok(result);
        }

        [HttpPost("SaveHabitacion")]
        public async Task<IActionResult> Post([FromBody] SaveHabitacionDto habitacion)
        {
            var result = await _habitacionService.Save(habitacion);
            return Ok(result);
        }

        [HttpPut("UpdateHabitacion")]
        public async Task<IActionResult> Put([FromBody] UpdateHabitacionDto habitacion)
        {
            var result = await _habitacionService.Update(habitacion);
            return Ok(result);
        }

        [HttpDelete("RemoveHabitacion")]
        public async Task<IActionResult> RemoveHabitacion(RemoveHabitacionDto habitacion)
        {
            var result = await _habitacionService.Remove(habitacion);
            return Ok(result);
        }
    }
}
