﻿namespace FrancoHotel.WebApi.Models.CategoriaModels
{
    public class PostCategoriaModel
    {
        public string? Descripcion { get; set; }
        public bool? Estado { get; set; }
        public DateTime Fecha { get; set; }
        public int Usuario { get; set; }
    }
}
