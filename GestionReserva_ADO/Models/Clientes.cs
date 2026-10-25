using System;
using System.Collections.Generic;

namespace GestionReserva_ADO.Models;

public partial class Clientes
{
    public int ClienteId { get; set; }

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string? Telefono { get; set; }

    public string Correo { get; set; } = null!;

    public DateOnly FechaNacimiento { get; set; }

    public string Sexo { get; set; } = null!;

    public string? CategoriaCliente { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string? UsuarioCreacion { get; set; }

    public DateTime? FechaUltModificacion { get; set; }

    public string? UsuarioUltModificacion { get; set; }

    public int Estado { get; set; }

    // Solo lectura (EF no la mapea): texto para mostrar en los ComboBox.
    public string NombreCompleto => Nombres + " " + Apellidos + (Estado == 0 ? " [inactivo]" : "");

    public virtual ICollection<Reservas> Reservas { get; set; } = new List<Reservas>();
}
