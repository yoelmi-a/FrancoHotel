using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrancoHotel.Application.Base;
using FrancoHotel.Application.Dtos.PisoDtos;
using FrancoHotel.Application.Dtos.RecepcionDtos;

namespace FrancoHotel.Application.Interfaces
{
    public interface IRecepcionService : IBaseService<SaveRecepcionDto, UpdateRecepcionDto, RemoveRecepcionDto>
    {
    }
}
