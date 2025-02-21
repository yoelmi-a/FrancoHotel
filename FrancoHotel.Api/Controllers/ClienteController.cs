using FrancoHotel.Domain.Entities;
using FrancoHotel.Persistence.Interfaces;
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

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
