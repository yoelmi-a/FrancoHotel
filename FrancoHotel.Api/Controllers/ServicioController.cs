using FrancoHotel.Domain.Entities;
using FrancoHotel.Persistence.Interfaces;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FrancoHotel.Persistence.Repositories;
using FrancoHotel.Application.Interfaces;
using FrancoHotel.Application.Dtos.ServiciosDto;

namespace FrancoHotel.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicioController : ControllerBase
    {
        private readonly IServiciosService _serviciosService;

        public ServicioController(IServiciosService serviciosService)
        {
            _serviciosService = serviciosService;
        }

        [HttpGet("GetServicios")]
        public async Task<IActionResult> GetAll()
        {
            var servicios = await _serviciosService.GetAll();
            return Ok(servicios);
        }

        [HttpGet("GetServicioById")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _serviciosService.GetById(id);
            return Ok(result);
        }

        [HttpPost("SaveServicio")]
        public async Task<IActionResult> Post([FromBody] SaveServiciosDto servicio)
        {
            var result = await _serviciosService.Save(servicio);
            return Ok(result);
        }

        [HttpPut("UpdateServicio")]
        public async Task<IActionResult> Put([FromBody] UpdateServiciosDto servicio)
        {
            var result = await _serviciosService.Update(servicio);
            return Ok(result);
        }

        [HttpPut("RemoveServicio")]
        public async Task<IActionResult> RemoveServicio([FromBody] RemoveServiciosDto servicio)
        {
            var result = await _serviciosService.Remove(servicio);
            return Ok(result);
        }
    }
}
