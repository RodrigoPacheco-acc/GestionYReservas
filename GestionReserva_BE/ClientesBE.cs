using System;
using System.Collections.Generic;
using System.Text;

namespace GestionReserva_BE
{
    public class ClientesBE
    {
        public int ClienteId { get; set; }

        public string Nombres { get; set; } = "";
        public string Apellidos { get; set; } = "";
        public string? Telefono { get; set; }
        public string Correo { get; set; } = "";

        public DateOnly FechaNacimiento { get; set; }

        public string Sexo { get; set; } = "";
        public string? CategoriaCliente { get; set; }

        public DateTime FechaCreacion { get; set; }
        public string? UsuarioCreacion { get; set; }

        public DateTime? FechaUltModificacion { get; set; }
        public string? UsuarioUltModificacion { get; set; }

        public int Estado { get; set; }
    }
}

