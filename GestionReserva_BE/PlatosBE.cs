using System;
using System.Collections.Generic;
using System.Text;

namespace GestionReserva_BE
{
    public class PlatosBE
    {
        public int PlatoId { get; set; }

        public string NombrePlato { get; set; } = "";

        public string? Descripcion { get; set; }

        public int CategoriaId { get; set; }

        public int? TiempoPreparacionMinutos { get; set; }

        public bool Disponible { get; set; }

        public decimal? PrecioReferencial { get; set; }

        public DateTime FechaCreacion { get; set; }

        public string UsuarioCreacion { get; set; } = "";

        public DateTime? FechaUltModificacion { get; set; }

        public string? UsuarioUltModificacion { get; set; }

        public int Estado { get; set; }
    }
}
