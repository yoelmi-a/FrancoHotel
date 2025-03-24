﻿using FrancoHotel.Application.Dtos.UsuariosDtos;
using FrancoHotel.Application.Interfaces;
using FrancoHotel.Domain.Entities;
using FrancoHotel.Persistence.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpGet("GetUsuarioById")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _usuarioService.GetById(id);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpGet("GetUsuarioByIdRolUsuario")]
        public async Task<IActionResult> GetByRolUsuario(int idRolUsuario)
        {
            var result = await _usuarioService.GetUsuarioByIdRolUsuario(idRolUsuario);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpGet("GetUsuariosByEstado")]
        public async Task<IActionResult> GetByEstado(bool estado)
        {
            var result = await _usuarioService.GetUsuariosByEstado(estado);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpPost("SaveUsuario")]
        public async Task<IActionResult> Post([FromBody] SaveUsuarioDtos usuario)
        {
            var result = await _usuarioService.Save(usuario);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpPut("UpdateUsuario")]
        public async Task<IActionResult> Put([FromBody] UpdateUsuarioDtos usuario)
        {
            var result = await _usuarioService.Update(usuario);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpDelete("RemoveUsuario")]
        public async Task<IActionResult> RemoveUsuario([FromBody] RemoveUsuarioDtos dto)
        {
            var result = await _usuarioService.Remove(dto);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
    }
}
