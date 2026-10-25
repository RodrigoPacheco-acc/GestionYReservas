using System;
using System.Collections.Generic;

namespace GestionReserva_ADO.Models;

public partial class Reservas
{
    public int ReservaId { get; set; }

    public int ClienteId { get; set; }

    public DateOnly FechaReserva { get; set; }

    public TimeOnly HoraReserva { get; set; }

    public int NumeroPersonas { get; set; }

    public int MesaId { get; set; }

    public int TurnoId { get; set; }

    public int EstadoId { get; set; }

    public int EmpleadoId { get; set; }

    public string? Observaciones { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string? UsuarioCreacion { get; set; }

    public DateTime? FechaUltModificacion { get; set; }

    public string? UsuarioUltModificacion { get; set; }

    public int Estado { get; set; }

    public virtual Clientes Cliente { get; set; } = null!;

    public virtual Empleados Empleado { get; set; } = null!;

    public virtual EstadosReserva EstadoReserva { get; set; } = null!;

    public virtual Mesas Mesa { get; set; } = null!;

    public virtual ICollection<Pedidos> Pedidos { get; set; } = new List<Pedidos>();

    public virtual ICollection<ReservaEmpleados> ReservaEmpleados { get; set; } = new List<ReservaEmpleados>();

    public virtual Turnos Turno { get; set; } = null!;
}
