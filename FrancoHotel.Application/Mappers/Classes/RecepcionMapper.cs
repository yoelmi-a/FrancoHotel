
using FrancoHotel.Application.Dtos.RecepcionDtos;
using FrancoHotel.Application.Mappers.Interfaces;
using FrancoHotel.Domain.Entities;

namespace FrancoHotel.Application.Mappers.Classes
{
    public class RecepcionMapper : BaseMapper<SaveRecepcionDto, UpdateRecepcionDto, RemoveRecepcionDto, Recepcion>, IRecepcionMapper
    {
        public override List<UpdateRecepcionDto> DtoList(List<Recepcion> entities)
        {
            return entities.Select(entity => new UpdateRecepcionDto()
            {
                Id = entity.Id,
                IdCliente = entity.IdCliente,
                IdHabitacion = entity.IdHabitacion,
                FechaEntrada = entity.FechaEntrada,
                FechaSalida = entity.FechaSalida,
                FechaSalidaConfirmacion = entity.FechaSalidaConfirmacion,
                PrecioInicial = entity.PrecioInicial,
                Adelanto = entity.Adelanto,
                PrecioRestante = entity.PrecioRestante,
                TotalPagado = entity.TotalPagado,
                CostoPenalidad = entity.CostoPenalidad,
                Observacion = entity.Observacion,
                Estado = entity.Estado,
                CantidadPersonas = entity.CantidadPersonas,
                IdServicioPorCategoria = entity.IdServicioPorCategoria,
                PrecioServiciosExtra = entity.PrecioServiciosExtra,
                Usuario = (int)entity.CreadorPorU!
            }).ToList();
        }

        public override UpdateRecepcionDto EntityToDto(Recepcion entity)
        {
            UpdateRecepcionDto dto = new UpdateRecepcionDto();
            dto.Id = entity.Id;
            dto.IdCliente = entity.IdCliente;
            dto.IdHabitacion = entity.IdHabitacion;
            dto.FechaEntrada = entity.FechaEntrada;
            dto.FechaSalida = entity.FechaSalida;
            dto.FechaSalidaConfirmacion = entity.FechaSalidaConfirmacion;
            dto.PrecioInicial = entity.PrecioInicial;
            dto.Adelanto = entity.Adelanto;
            dto.PrecioRestante = entity.PrecioRestante;
            dto.TotalPagado = entity.TotalPagado;
            dto.CostoPenalidad = entity.CostoPenalidad;
            dto.Observacion = entity.Observacion;
            dto.Estado = entity.Estado;
            dto.CantidadPersonas = entity.CantidadPersonas;
            dto.IdServicioPorCategoria = entity.IdServicioPorCategoria;
            dto.PrecioServiciosExtra = entity.PrecioServiciosExtra;
            dto.Usuario = (int)entity.CreadorPorU!;
            return dto;
        }

        public override Recepcion RemoveDtoToEntity(RemoveRecepcionDto dto, Recepcion entity)
        {
            entity.FechaModificacion = dto.Fecha;
            entity.UsuarioMod = dto.Usuario;
            entity.Borrado = true;
            entity.BorradoPorU = dto.Usuario;
            return entity;
        }

        public override Recepcion SaveDtoToEntity(SaveRecepcionDto dto)
        {
            Recepcion entity = new Recepcion();
            entity.IdCliente = dto.IdCliente;
            entity.IdHabitacion = dto.IdHabitacion;
            entity.FechaEntrada = dto.FechaEntrada;
            entity.FechaSalida = dto.FechaSalida;
            entity.PrecioInicial = dto.PrecioInicial;
            entity.Adelanto = dto.Adelanto;
            entity.PrecioRestante = dto.PrecioRestante;
            entity.TotalPagado = dto.TotalPagado;
            entity.CostoPenalidad = dto.CostoPenalidad;
            entity.Observacion = dto.Observacion;
            entity.Estado = dto.Estado;
            entity.CreadorPorU = dto.Usuario;
            entity.CantidadPersonas = dto.CantidadPersonas;
            entity.IdServicioPorCategoria = dto.IdServicioPorCategoria;
            entity.PrecioServiciosExtra = dto.PrecioServiciosExtra;
            entity.Borrado = false;
            return entity;
        }

        public override Recepcion UpdateDtoToEntity(UpdateRecepcionDto dto, Recepcion entity)
        {
            entity.Id = dto.Id;
            entity.IdCliente = dto.IdCliente;
            entity.IdHabitacion = dto.IdHabitacion;
            entity.FechaEntrada = dto.FechaEntrada;
            entity.FechaSalida = dto.FechaSalida;
            entity.PrecioInicial = dto.PrecioInicial;
            entity.Adelanto = dto.Adelanto;
            entity.PrecioRestante = dto.PrecioRestante;
            entity.TotalPagado = dto.TotalPagado;
            entity.CostoPenalidad = dto.CostoPenalidad;
            entity.Observacion = dto.Observacion;
            entity.Estado = dto.Estado;
            entity.CreadorPorU = dto.Usuario;
            entity.CantidadPersonas = dto.CantidadPersonas;
            entity.IdServicioPorCategoria = dto.IdServicioPorCategoria;
            entity.PrecioServiciosExtra = dto.PrecioServiciosExtra;
            entity.UsuarioMod = dto.Usuario;
            entity.FechaModificacion = dto.Fecha;
            entity.FechaSalidaConfirmacion = dto.FechaSalidaConfirmacion;
            return entity;
        }
    }
}
