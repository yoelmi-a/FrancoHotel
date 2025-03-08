using AutoMapper;
using FrancoHotel.Application.Dtos.PisoDtos;
using FrancoHotel.Domain.Entities;

namespace FrancoHotel.Application.Mappers
{
    public class PisoProfile : Profile
    {
        public PisoProfile()
        {
            CreateMap<SavePisoDto, Piso>()
                .ForMember(ent => ent.CreadorPorU, dto => dto.MapFrom(data => data.Usuario))
                .ForPath(ent => ent.EstadoYFecha.FechaCreacion, dto => dto.MapFrom(data => data.Fecha))
                .ForPath(ent => ent.EstadoYFecha.Estado, dto => dto.MapFrom(data => data.Estado))
                .ReverseMap();
        }
    }
}
