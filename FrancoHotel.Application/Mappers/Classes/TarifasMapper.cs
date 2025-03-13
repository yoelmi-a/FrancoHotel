using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrancoHotel.Application.Dtos.TarifasDto;
using FrancoHotel.Application.Dtos.TarifasDtos;
using FrancoHotel.Application.Mappers.Interfaces;
using FrancoHotel.Domain.Entities;

namespace FrancoHotel.Application.Mappers.Classes
{
    public class TarifasMapper : BaseMapper<SaveTarifasDtos, UpdateTarifasDto, RemoveTarifasDto, Tarifas>, ITarifasMapper
    {
        public override List<UpdateTarifasDto> DtoList(List<Tarifas> entities)
        {
            throw new NotImplementedException();
        }

        public override UpdateTarifasDto EntityToDto(Tarifas entity)
        {
            UpdateTarifasDto dto = new UpdateTarifasDto();
            dto.Id = entity.Id;
            dto.IdCategoria = entity.IdCategoria;
            dto.FechaInicio = entity.FechaInicio;
            dto.FechaFin = entity.FechaFin;
            dto.PrecioPorNoche = entity.PrecioPorNoche;
            dto.Descuento = entity.Descuento;
            dto.Descripcion = entity.Descripcion;
            dto.Estado = entity.Estado;
            return dto;
        }

        public override Tarifas RemoveDtoToEntity(RemoveTarifasDto dto, Tarifas entity)
        {
            entity.FechaModificacion = dto.Fecha;
            entity.UsuarioMod = dto.Usuario;
            entity.Borrado = true;
            entity.BorradoPorU = dto.Usuario;
            return entity;
        }

        public override Tarifas SaveDtoToEntity(SaveTarifasDtos dto)
        {
            Tarifas entity = new Tarifas();
            entity.CreadorPorU = dto.Usuario;
            entity.IdCategoria = dto.IdCategoria;
            entity.FechaInicio = dto.FechaInicio;
            entity.FechaFin = dto.FechaFin;
            entity.PrecioPorNoche = dto.PrecioPorNoche;
            entity.Descuento = dto.Descuento;
            entity.Descripcion = dto.Descripcion;
            entity.Estado = dto.Estado;
            entity.Borrado = false;
            return entity;
        }

        public override Tarifas UpdateDtoToEntity(UpdateTarifasDto dto, Tarifas entity)
        {
            entity.IdCategoria = dto.IdCategoria;
            entity.FechaInicio = dto.FechaInicio;
            entity.FechaFin = dto.FechaFin;
            entity.PrecioPorNoche = dto.PrecioPorNoche;
            entity.Descuento = dto.Descuento;
            entity.Descripcion = dto.Descripcion;
            entity.Estado = dto.Estado;
            entity.UsuarioMod = dto.Usuario;
            entity.FechaModificacion = dto.Fecha;
            return entity;
        }
    }
}
