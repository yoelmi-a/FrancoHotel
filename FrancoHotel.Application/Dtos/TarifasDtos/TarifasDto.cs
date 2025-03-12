using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrancoHotel.Application.Dtos.TarifasDto
{
    public class TarifasDto
    {
        public int? IdCategoria { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public decimal PrecioPorNoche { get; set; }
        public decimal Descuento { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public int CreadoPorU { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public int UsuarioMod { get; set; }
        public int BorradoPorU { get; set; }
        public bool Borrado { get; set; }

    }
}
