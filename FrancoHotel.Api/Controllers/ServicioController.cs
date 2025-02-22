﻿using FrancoHotel.Domain.Entities;
using FrancoHotel.Persistence.Interfaces;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrancoHotel.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicioController : ControllerBase
    {
        private readonly IServiciosRepository _serviciosRepository;

        public ServicioController(IServiciosRepository serviciosRepository,
                              ILogger<PisoController> logger)
        {
            _serviciosRepository = serviciosRepository;
        }

        [HttpGet("GetServicios")]
        public async Task<IActionResult> GetAll()
        {
            var servicios = await _serviciosRepository.GetAllAsync();
            return Ok(servicios);
        }

        [HttpGet("GetServiciosByFilter")]
        public async Task<IActionResult> GetAllbyFilter(Expression<Func<Servicios, bool>> filter)
        {
            var servicios = await _serviciosRepository.GetAllAsync(filter);
            return Ok(servicios);
        }

        [HttpGet("GetServicioById")]
        public async Task<IActionResult> GetById(short id)
        {
            var servicio = await _serviciosRepository.GetEntityByIdAsync(id);
            return Ok(servicio);
        }

        [HttpGet("ExistServicio")]
        public async Task<IActionResult> GetExistPiso(Expression<Func<Servicios, bool>> filter)
        {
            var servicio = await _serviciosRepository.Exists(filter);
            return Ok(servicio);
        }

        [HttpPost("SaveServicio")]
        public async Task<IActionResult> Post([FromBody] Servicios servicio)
        {
            await _serviciosRepository.SaveEntityAsync(servicio);
            return Ok(servicio);
        }

        [HttpPut("UpdateServicio")]
        public async Task<IActionResult> Put([FromBody] Servicios servicio)
        {
            await _serviciosRepository.UpdateEntityAsync(servicio);
            return Ok(servicio);
        }

        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
        }
    }
}
