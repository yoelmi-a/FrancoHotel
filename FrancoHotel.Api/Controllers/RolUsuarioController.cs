using FrancoHotel.Domain.Entities;
using FrancoHotel.Persistence.Interfaces;
using FrancoHotel.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FrancoHotel.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolUsuarioController : ControllerBase
    {
        private readonly IRolUsuarioRepository _rolUsuarioRepository;

        public RolUsuarioController(IRolUsuarioRepository rolUsuarioRepository,
                                    ILogger<RolUsuarioController> logger)
        {
            _rolUsuarioRepository = rolUsuarioRepository;
        }

        [HttpGet("GetRolUsuarios")]
        public async Task<IActionResult> Get()
        {
            var rolUsuarios = await _rolUsuarioRepository.GetAllAsync();
            return Ok(rolUsuarios);
        }

        [HttpGet("GetRolUsuarioById")]
        public async Task<IActionResult> Get(int id)
        {
            var rolUsuario = await _rolUsuarioRepository.GetEntityByIdAsync(id);
            return Ok(rolUsuario);
        }

        [HttpPost("SaveRolUsuario")]
        public async Task<IActionResult> Post([FromBody] RolUsuario rolUsuario)
        {
            await _rolUsuarioRepository.SaveEntityAsync(rolUsuario);
            return Ok(rolUsuario);
        }

        [HttpPost("UpdatePiso")]
        public async Task<IActionResult> Put([FromBody] RolUsuario rolUsuario)
        {
            await _rolUsuarioRepository.UpdateEntityAsync(rolUsuario);
            return Ok(rolUsuario);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
