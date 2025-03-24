using FrancoHotel.Application.Dtos.ClienteDtos;
using FrancoHotel.Application.Interfaces;
using FrancoHotel.Domain.Entities;
using FrancoHotel.Persistence.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FrancoHotel.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet("GetClientes")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _clienteService.GetAll();
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpGet("GetClienteById")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _clienteService.GetById(id);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpGet("GetClienteByDocumento")]
        public async Task<IActionResult> GetByDocumento(string documento)
        {
            var result = await _clienteService.GetClienteByDocumento(documento);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpGet("GetClientesByEstado")]
        public async Task<IActionResult> GetByEstado(bool estado)
        {
            var result = await _clienteService.GetClientesByEstado(estado);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpPost("SaveCliente")]
        public async Task<IActionResult> Post([FromBody] SaveClienteDtos cliente)
        {
            var result = await _clienteService.Save(cliente);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpPut("UpdateCliente")]
        public async Task<IActionResult> Put([FromBody] UpdateClienteDtos cliente)
        {
            var result = await _clienteService.Update(cliente);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpPut("UpdateTipoDocumento")]
        public async Task<IActionResult> PutDocumento([FromBody] UpdateClienteDtos cliente)
        {
            var result = await _clienteService.UpdateTipoDocumento(cliente);
            return Ok(result);
        }

        [HttpPut("UpdateEstado")]
        public async Task<IActionResult> PutEstado([FromBody] UpdateClienteDtos cliente, bool nuevoEstado)
        {
            var result = await _clienteService.UpdateEstado(cliente, nuevoEstado);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpDelete("RemoveCliente")]
        public async Task<IActionResult> RemoveCliente([FromBody] RemoveClienteDtos dto)
        {
            var result = await _clienteService.Remove(dto);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
    }
}