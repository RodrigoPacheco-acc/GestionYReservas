using System;
using System.Collections.Generic;

namespace GestionReserva_ADO.Models;

public partial class Reservas
{
    public int ReservaId { get; set; }

    public string NombreReservante { get; set; } = null!;

    public string? TelefonoReservante { get; set; }

    public string? EmailReservante { get; set; }

    public DateOnly FechaReserva { get; set; }

    public TimeOnly HoraReserva { get; set; }

    public int NumeroPersonas { get; set; }

    public int MesaId { get; set; }

    public int TurnoId { get; set; }

    public int EstadoId { get; set; }

    public int EmpleadoId { get; set; }

    public string? Observaciones { get; set; }

    public DateTime FechaCreacion { get; set; }

    public virtual Empleados Empleado { get; set; } = null!;

    public virtual EstadosReserva Estado { get; set; } = null!;

    public virtual Mesas Mesa { get; set; } = null!;

    public virtual ICollection<ReservaEmpleados> ReservaEmpleados { get; set; } = new List<ReservaEmpleados>();

    public virtual Turnos Turno { get; set; } = null!;
}
