using System;
using System.Collections.Generic;
using System.Text;

namespace GestionReserva_BE
{
    public class ReservasBE
    {
        public int ReservaId { get; set; }

        public int ClienteId { get; set; }

        public string NombreCliente { get; set; } = "";

        public DateOnly FechaReserva { get; set; }

        public TimeOnly HoraReserva { get; set; }

        public int NumeroPersonas { get; set; }

        public int MesaId { get; set; }

        public int NumeroMesa { get; set; }

        public string NombreZona { get; set; } = "";

        public int TurnoId { get; set; }

        public string NombreTurno { get; set; } = "";

        public int EstadoId { get; set; }

        public string NombreEstado { get; set; } = "";

        public int EmpleadoId { get; set; }

        public string NombreEmpleado { get; set; } = "";

        public string? Observaciones { get; set; }

        public DateTime FechaCreacion { get; set; }

        public string UsuarioCreacion { get; set; } = "";

        public DateTime? FechaUltModificacion { get; set; }

        public string? UsuarioUltModificacion { get; set; }

        public int Estado { get; set; }
    }
}
