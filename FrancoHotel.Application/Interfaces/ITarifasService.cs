using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrancoHotel.Application.Base;
using FrancoHotel.Application.Dtos.PisoDtos;

namespace FrancoHotel.Application.Interfaces
{
    public interface ITarifasService : IBaseService< UpdatePisoDto, RemovePisoDto>
    {
    }
}
