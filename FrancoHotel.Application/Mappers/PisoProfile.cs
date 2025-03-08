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

            CreateMap<UpdatePisoDto, Piso>()
                .ForMember(ent => ent.UsuarioMod, dto => dto.MapFrom(data => data.Usuario))
                .ForMember(ent => ent.FechaModificacion, dto => dto.MapFrom(data => data.Fecha))
                .ReverseMap();

            CreateMap<RemovePisoDto, Piso>()
                .ForMember(ent => ent.BorradoPorU, dto => dto.MapFrom(data => data.Usuario))
                .ForMember(ent => ent.UsuarioMod, dto => dto.MapFrom(data => data.Usuario))
                .ForMember(ent => ent.Borrado, dto => dto.MapFrom(data => true))
                .ForMember(ent => ent.FechaModificacion, dto => dto.MapFrom(data => data.Fecha))
                .ReverseMap();
        }
    }
}
