﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FrancoHotel.Domain.Base;

namespace FrancoHotel.Domain.Entities
{
    public sealed class Piso : BaseEntity<int>
    {
        [Column("IdPiso")]
        [Key]
        public override int Id { get; set; }
        public string? Descripcion { get; set; }
        public BaseEstadoYFecha EstadoYFecha { get; set; } = new BaseEstadoYFecha();

    }
}
