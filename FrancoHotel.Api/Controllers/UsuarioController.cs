using FrancoHotel.Application.Dtos.UsuariosDtos;
using FrancoHotel.Persistence.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FrancoHotel.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet("GetUsuarios")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _usuarioService.GetAll();
            return Ok(result);
        }

        [HttpGet("GetUsuarioById")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _usuarioService.GetById(id);
            return Ok(result);
        }

        [HttpGet("GetUsuarioByIdRolUsuario")]
        public async Task<IActionResult> GetByRolUsuario(int idRolUsuario)
        {
            var result = await _usuarioService.GetUsuarioByIdRolUsuario(idRolUsuario);
            return Ok(result);
        }

        [HttpGet("GetUsuariosByEstado")]
        public async Task<IActionResult> GetByEstado(bool estado)
        {
            var result = await _usuarioService.GetUsuariosByEstado(estado);
            return Ok(result);
        }

        [HttpPost("SaveUsuario")]
        public async Task<IActionResult> Post([FromBody] SaveUsuarioDtos usuario)
        {
            var result = await _usuarioService.Save(usuario);
            return Ok(result);
        }

        [HttpPut("UpdateUsuario")]
        public async Task<IActionResult> Put([FromBody] UpdateUsuarioDtos usuario)
        {
            var result = await _usuarioService.Update(usuario);
            return Ok(result);
        }

        [HttpDelete("RemoveUsuario")]
        public async Task<IActionResult> RemoveUsuario([FromBody] RemoveUsuarioDtos dto)
        {
            var result = await _usuarioService.Remove(dto);
            return Ok(result);
        }
    }
}
