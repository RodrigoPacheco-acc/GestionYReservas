using System;
using System.Collections.Generic;

namespace GestionReserva_ADO.Models;

public partial class Empleados
{
    public int EmpleadoId { get; set; }

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string Dni { get; set; } = null!;

    public string? Telefono { get; set; }

    public string? Email { get; set; }

    public DateOnly FechaContratacion { get; set; }

    public int CargoId { get; set; }

    public byte[]? Foto { get; set; }

    public string Sexo { get; set; } = null!;

    public DateOnly FechaNacimiento { get; set; }

    public string Direccion { get; set; } = null!;

    public int UbigeoId { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string? UsuarioCreacion { get; set; }

    public DateTime? FechaUltModificacion { get; set; }

    public string? UsuarioUltModificacion { get; set; }

    public int Estado { get; set; }

    // Solo lectura (EF no la mapea): texto para mostrar en los ComboBox.
    public string NombreCompleto => Nombres + " " + Apellidos + (Estado == 0 ? " [inactivo]" : "");

    public virtual Cargos Cargo { get; set; } = null!;

    public virtual ICollection<ReservaEmpleados> ReservaEmpleados { get; set; } = new List<ReservaEmpleados>();

    public virtual ICollection<Reservas> Reservas { get; set; } = new List<Reservas>();

    public virtual Ubigeo Ubigeo { get; set; } = null!;
}
