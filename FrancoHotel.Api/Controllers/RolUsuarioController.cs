using FrancoHotel.Application.Dtos.RolUsuariosDtos;
using FrancoHotel.Persistence.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FrancoHotel.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolUsuarioController : ControllerBase
    {
        private readonly IRolUsuarioService _rolUsuarioService;

        public RolUsuarioController(IRolUsuarioService rolUsuarioService)
        {
            _rolUsuarioService = rolUsuarioService;
        }

        [HttpGet("GetRolUsuarios")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _rolUsuarioService.GetAll();
            return Ok(result);
        }

        [HttpGet("GetRolUsuarioById")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _rolUsuarioService.GetById(id);
            return Ok(result);
        }

        [HttpGet("GetRolUsuarioByDescripcion")]
        public async Task<IActionResult> GetByDescripcion(string descripcion)
        {
            var result = await _rolUsuarioService.GetRolUsuarioByDescripcion(descripcion);
            return Ok(result);
        }

        [HttpPost("SaveRolUsuario")]
        public async Task<IActionResult> Post([FromBody] SaveRolUsuarioDtos rolUsuario)
        {
            var result = await _rolUsuarioService.Save(rolUsuario);
            return Ok(result);
        }

        [HttpPut("UpdateRolUsuario")]
        public async Task<IActionResult> Put([FromBody] UpdateRolUsuarioDtos rolUsuario)
        {
            var result = await _rolUsuarioService.Update(rolUsuario);
            return Ok(result);
        }

        [HttpDelete("RemoveRolUsuario")]
        public async Task<IActionResult> RemoveRolUsuario([FromBody] RemoveRolUsuarioDtos dto)
        {
            var result = await _rolUsuarioService.Remove(dto);
            return Ok(result);
        }
    }
}
