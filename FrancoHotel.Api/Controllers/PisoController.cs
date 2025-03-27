using System.Linq.Expressions;
using FrancoHotel.Application.Dtos.PisoDtos;
using FrancoHotel.Application.Interfaces;
using FrancoHotel.Domain.Base;
using FrancoHotel.Domain.Entities;
using FrancoHotel.Persistence.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FrancoHotel.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PisoController : ControllerBase
    {
        private readonly IPisoService _pisoService;

        public PisoController(IPisoService pisoService)
        {
            _pisoService = pisoService;
        }

        [HttpGet("GetPisos")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _pisoService.GetAll();
            return Ok(result);
        }

        [HttpGet("GetPisoById")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _pisoService.GetById(id);
            return Ok(result);
        }

        [HttpPost("SavePiso")]
        public async Task<IActionResult> Post([FromBody] SavePisoDto piso)
        {
            var result = await _pisoService.Save(piso);
            return Ok(result);
        }

        [HttpPut("UpdatePiso")]
        public async Task<IActionResult> Put([FromBody] UpdatePisoDto piso)
        {
            var result = await _pisoService.Update(piso);
            return Ok(result);
        }

        [HttpPut("RemovePiso")]
        public async Task<IActionResult> RemovePiso(RemovePisoDto dto)
        {
            var result = await _pisoService.Remove(dto);
            return Ok(result);
        }
    }
}
