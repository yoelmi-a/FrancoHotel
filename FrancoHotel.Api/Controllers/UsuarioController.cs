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

        [HttpPost("SaveCliente")]
        public async Task<IActionResult> Post([FromBody] Usuario usuario)
        {
            await _usuarioRepository.SaveEntityAsync(usuario);
            return Ok(usuario);
        }

        [HttpPost("UpdatePiso")]
        public async Task<IActionResult> Put([FromBody] Usuario usuario)
        {
            await _usuarioRepository.UpdateEntityAsync(usuario);
            return Ok(usuario);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
