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

    public bool Activo { get; set; }

    public virtual Cargos Cargo { get; set; } = null!;

    public virtual ICollection<ReservaEmpleados> ReservaEmpleados { get; set; } = new List<ReservaEmpleados>();

    public virtual ICollection<Reservas> Reservas { get; set; } = new List<Reservas>();
}
