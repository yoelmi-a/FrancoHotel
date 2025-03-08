using System.Linq.Expressions;
using FrancoHotel.Application.Dtos.PisoDtos;
using FrancoHotel.Application.Interfaces;
using FrancoHotel.Domain.Base;
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
        private readonly IPisoService _pisoService;

        public PisoController(IPisoRepository pisoRepository,
                              IPisoService pisoService)
        {
            _pisoRepository = pisoRepository;
            _pisoService = pisoService;
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
        public async Task<IActionResult> Post([FromBody] SavePisoDto piso)
        {
            await _pisoService.Save(piso);
            return Ok(piso);
        }

        [HttpPut("UpdatePiso")]
        public async Task<IActionResult> Put([FromBody] UpdatePisoDto piso)
        {
            OperationResult result = new OperationResult();
            result = await _pisoService.Update(piso);
            return Ok(result.Message);
        }

        [HttpDelete("RemovePiso")]
        public async Task<IActionResult> RemovePiso(RemovePisoDto dto)
        {
            await _pisoService.Remove(dto);
            return Ok("Cliente borrado");
        }
    }
}
