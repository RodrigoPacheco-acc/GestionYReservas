using System;
using System.Collections.Generic;

namespace GestionReserva_ADO.Models;

public partial class Turnos
{
    public int TurnoId { get; set; }

    public string NombreTurno { get; set; } = null!;

    public TimeOnly HoraInicio { get; set; }

    public TimeOnly HoraFin { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string? UsuarioCreacion { get; set; }

    public DateTime? FechaUltModificacion { get; set; }

    public string? UsuarioUltModificacion { get; set; }

    public int Estado { get; set; }

    // Solo lectura (EF no la mapea): texto para mostrar en los ComboBox.
    public string DescripcionTurno => NombreTurno + " (" + HoraInicio.ToString("HH:mm") + " - " + HoraFin.ToString("HH:mm") + ")" + (Estado == 0 ? " [inactivo]" : "");

    public virtual ICollection<Reservas> Reservas { get; set; } = new List<Reservas>();
}
