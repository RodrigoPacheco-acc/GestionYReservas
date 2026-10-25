using System;
using System.Collections.Generic;
using System.Text;

namespace GestionReserva_BE
{
    public class EmpleadosBE
    {
        public int EmpleadoId { get; set; }

        public string Nombres { get; set; } = "";
        public string Apellidos { get; set; } = "";
        public string DNI { get; set; } = "";
        public string? Telefono { get; set; }
        public string? Email { get; set; }

        public DateOnly FechaContratacion { get; set; }

        public int CargoId { get; set; }

        public bool Activo { get; set; }
    }
}
