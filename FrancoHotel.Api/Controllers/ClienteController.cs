using FrancoHotel.Domain.Entities;
using FrancoHotel.Persistence.Interfaces;
using FrancoHotel.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FrancoHotel.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository clienteRepository,
                                 ILogger<ClienteController> logger)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpGet("GetClientes")]
        public async Task<IActionResult> Get()
        {
            var clientes = await _clienteRepository.GetAllAsync();
            return Ok(clientes);
        }

        [HttpGet("GetClienteById")]
        public async Task<IActionResult> Get(int id)
        {
            var cliente = await _clienteRepository.GetEntityByIdAsync(id);
            return Ok(cliente);
        }

        [HttpGet("GetClienteByDocumento")]
        public async Task<IActionResult> Get(string documento)
        {
            var cliente = await _clienteRepository.GetClienteByDocumento(documento);
            return Ok(cliente);
        }

        [HttpGet("GetClientesByEstado")]
        public async Task<IActionResult> Get(bool estado)
        {
            var cliente = await _clienteRepository.GetClientesByEstado(estado);
            return Ok(cliente);
        }

        [HttpPost("SaveCliente")]
        public async Task<IActionResult> Post([FromBody] Cliente cliente)
        {
            await _clienteRepository.SaveEntityAsync(cliente);
            return Ok(cliente);
        }

        [HttpPut("UpdateCliente")]
        public async Task<IActionResult> Put([FromBody] Cliente cliente)
        {
            await _clienteRepository.UpdateEntityAsync(cliente);
            return Ok(cliente);
        }

        [HttpPut("UpdateTipoDocumento")]
        public async Task<IActionResult> PutDocumento([FromBody] Cliente cliente)
        {
            await _clienteRepository.UpdateTipoDocumento(cliente);
            return Ok(cliente);
        }

        [HttpPut("UpdateEstado")]
        public async Task<IActionResult> PutEstado([FromBody] Cliente cliente , bool nuevoEstado)
        {
            await _clienteRepository.UpdateEstado(cliente , nuevoEstado);
            return Ok(cliente);
        }

        [HttpDelete("RemoveCliente")]
        public async Task<IActionResult> RemoveCliente(int id, int idUsuarioMod)
        {
            var entity = await _clienteRepository.GetEntityByIdAsync(id);
            if(entity == null)
            {
                return NotFound("Cliente no encontrado");
            }
            entity.Borrado = true;
            entity.BorradoPorU = idUsuarioMod;
            entity.UsuarioMod = idUsuarioMod;
            entity.FechaModificacion = DateTime.Now;
            await _clienteRepository.UpdateEntityAsync(entity);
            return Ok("Cliente borrado");
        }
    }
}
