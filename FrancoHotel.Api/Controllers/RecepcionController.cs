using System.Linq.Expressions;
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
        private readonly IRecepcionRepository _recepcionRepository;
        public RecepcionController(IRecepcionRepository recepcionRepository,
                                 ILogger<PisoController> logger)
        {
            _recepcionRepository = recepcionRepository;
        }
        [HttpGet("GetRecepcion")]
        public async Task<IActionResult> GetAll()
        {
            var recepcion = await _recepcionRepository.GetAllAsync();
            return Ok(recepcion);
        }
        [HttpGet("GetRecepcionByFilter")]
        public async Task<IActionResult> GetAllByFilter([FromQuery] DateTime fechaInicio,
                                                 [FromQuery] DateTime fechaFin,
                                                 [FromQuery] bool estado)
        {
            Expression<Func<Recepcion, bool>> filter = r =>
                r.FechaEntrada >= fechaInicio &&
                r.FechaSalida <= fechaFin &&
                r.Estado == estado; 

            var recepciones = await _recepcionRepository.GetAllAsync(filter);
            return Ok(recepciones);
        }
        [HttpGet("GetRecepcionById")]
        public async Task<IActionResult> GetById(short id)
        {
            var recepcion = await _recepcionRepository.GetEntityByIdAsync(id);
            return Ok(recepcion);
        }
        [HttpGet("ExistRecepcion")]
        public async Task<IActionResult> GetExist([FromQuery] int id)
        {
            Expression<Func<Recepcion, bool>> filter = r => r.Id == id && r.Estado;
            var recepcion = await _recepcionRepository.Exists(filter);
            return Ok(recepcion);
        }
        [HttpPost("SaveRecepcion")]
        public async Task<IActionResult> Post([FromBody] Recepcion recepcion)
        {
            await _recepcionRepository.SaveEntityAsync(recepcion);
            return Ok(recepcion);
        }
        [HttpPut("UpdateRecepcion")]
        public async Task<IActionResult> Put([FromBody] Recepcion  recepcion)
        {
            await _recepcionRepository.UpdateEntityAsync(recepcion);
            return Ok(recepcion);
        }
    }
}
