using System;
using System.Collections.Generic;
using System.Text;

namespace GestionReserva_BE
{
    public class MesasBE
    {
        public int MesaId { get; set; }

        public int NumeroMesa { get; set; }

        public int Capacidad { get; set; }

        public int ZonaId { get; set; }

        public string NombreZona { get; set; } = "";

        public string EstadoMesa { get; set; } = "";

        public DateTime FechaCreacion { get; set; }

        public string UsuarioCreacion { get; set; } = "";

        public DateTime? FechaUltModificacion { get; set; }

        public string? UsuarioUltModificacion { get; set; }

        public int Estado { get; set; }
    }
}
