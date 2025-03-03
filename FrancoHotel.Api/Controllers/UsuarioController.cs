using FrancoHotel.Domain.Entities;
using FrancoHotel.Persistence.Interfaces;
using FrancoHotel.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FrancoHotel.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository,
                                 ILogger<UsuarioController> logger)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet("GetUsuarios")]
        public async Task<IActionResult> Get()
        {
            var usuarios = await _usuarioRepository.GetAllAsync();
            return Ok(usuarios);
        }

        [HttpGet("GetUsuarioById")]
        public async Task<IActionResult> Get(int id)
        {
            var usuario = await _usuarioRepository.GetEntityByIdAsync(id);
            return Ok(usuario);
        }

        [HttpGet("GetUsuarioByClave")]
        public async Task<IActionResult> Get(string clave)
        {
            var usuario = await _usuarioRepository.GetUsuarioByClave(clave);
            return Ok(usuario);
        }

        [HttpGet("GetUsuarioByIdRolUsuario")]
        public async Task<IActionResult> GetRolUsuario(int idRolUsuario)
        {
            var usuario = await _usuarioRepository.GetUsuarioByIdRolUsuario(idRolUsuario);
            return Ok(usuario);
        }

        [HttpGet("GetUsuariosByEstado")]
        public async Task<IActionResult> GetEstado(bool estado)
        {
            var usuario = await _usuarioRepository.GetUsuariosByEstado(estado);
            return Ok(usuario);
        }

        [HttpPost("SaveUsuario")]
        public async Task<IActionResult> Post([FromBody] Usuario usuario)
        {
            await _usuarioRepository.SaveEntityAsync(usuario);
            return Ok(usuario);
        }

        [HttpPost("UpdateUsuario")]
        public async Task<IActionResult> Put([FromBody] Usuario usuario)
        {
            await _usuarioRepository.UpdateEntityAsync(usuario);
            return Ok(usuario);
        }

        [HttpPost("UpdateClave")]
        public async Task<IActionResult> PutClave([FromBody] Usuario usuario)
        {
            await _usuarioRepository.UpdateEntityAsync(usuario);
            return Ok(usuario);
        }

        [HttpPost("UpdateEstado")]
        public async Task<IActionResult> PutEstado([FromBody] Usuario entity, bool nuevoEstado)
        {
            await _usuarioRepository.UpdateEstado(entity, nuevoEstado);
            return Ok(entity);
        }

        [HttpDelete("RemoveUsuario")]
        public async Task<IActionResult> RemovePiso(int id, int idUsuarioMod, DateTime fechaMod)
        {
            await _usuarioRepository.RemoveEntityAsync(id, idUsuarioMod, fechaMod);
            return Ok(id);
        }
    }
}
