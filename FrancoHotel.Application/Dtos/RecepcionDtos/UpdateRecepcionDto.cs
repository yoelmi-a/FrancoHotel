using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrancoHotel.Application.Dtos.RecepcionDtos
{
    public class UpdateRecepcionDto : RecepcionDtos
    {
        public  int Id { get; set; }
        public DateTime? FechaSalidaConfirmacion { get; set; }

    }
}
