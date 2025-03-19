using System.Linq.Expressions;
using FrancoHotel.Application.Dtos.RecepcionDtos;
using FrancoHotel.Application.Dtos.UsuariosDtos;
using FrancoHotel.Application.Interfaces;
using FrancoHotel.Application.Services;

using FrancoHotel.Domain.Base;
using FrancoHotel.Domain.Entities;
using FrancoHotel.Persistence.Interfaces;
using FrancoHotel.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrancoHotel.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecepcionController : ControllerBase
    {
        private readonly IRecepcionService _recepcionService;
        public RecepcionController(IRecepcionService recepcionService)
        {
            _recepcionService = recepcionService;
        }

        
        [HttpGet("GetRecepcionByFilter")]
        public async Task<IActionResult> GetAllByFilter([FromQuery] DateTime fechaInicio,
                                                 [FromQuery] DateTime fechaFin,
                                                 [FromQuery] EstadoReserva estado)
        {
            Expression<Func<Recepcion, bool>> filter = r =>
                r.FechaEntrada >= fechaInicio &&
                r.FechaSalida <= fechaFin &&
                r.Estado == estado; 

            var recepciones = await _recepcionService.GetAllByFilter(filter);
            return Ok(recepciones);
        }
        [HttpGet("GetRecepcion")]
        public async Task<IActionResult> GetAll()
        {
            var recepcion = await _recepcionService.GetAll();
            return Ok(recepcion);
        }
        
        [HttpGet("GetRecepcionById")]
        public async Task<IActionResult> GetById(short id)
        {
            var recepcion = await _recepcionService.GetById(id);
            return Ok(recepcion);
        }
        
        [HttpGet("ExistRecepcion")]
        public async Task<IActionResult> GetExist([FromQuery] int id)
        {
            Expression<Func<Recepcion, bool>> filter = r => r.Id == id;
            var recepcion = await _recepcionService.Exists(filter);
            return Ok(recepcion);
        }
        
        [HttpPost("SaveRecepcion")]
        public async Task<IActionResult> Post([FromBody] SaveRecepcionDto recepcion)
        {
            await _recepcionService.Save(recepcion);
            return Ok(recepcion);
        }

        [HttpPut("UpdateRecepcion")]
        public async Task<IActionResult> Put([FromBody] UpdateRecepcionDto  recepcion)
        {
            var result = await _recepcionService.Update(recepcion);
            return Ok(result);
        }
        
        [HttpDelete("RemoveRecepcion")]
        public async Task<IActionResult> RemoveRecepcion([FromBody] RemoveRecepcionDto recepcionDto)
        {
            var result = await _recepcionService.Remove(recepcionDto);
            return Ok(result);
        }
    }
}
