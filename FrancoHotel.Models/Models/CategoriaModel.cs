namespace FrancoHotel.Models.Models
{
    class CategoriaModel
    {
        public int IdCategoria { get; set; }
        public int? IdCombinacion { get; set; }
        public string Descripcion { get; set; }
        public bool? Estado { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public int? CreadorPorU { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public int? UsuarioMod { get; set; }
        public int? BorradoPorU { get; set; }
        public bool? Borrado { get; set; }
    }
}
