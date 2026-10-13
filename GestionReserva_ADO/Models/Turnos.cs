using System;
using System.Collections.Generic;

namespace GestionReserva_ADO.Models;

public partial class Turnos
{
    public int TurnoId { get; set; }

    public string NombreTurno { get; set; } = null!;

    public TimeOnly HoraInicio { get; set; }

    public TimeOnly HoraFin { get; set; }

    public virtual ICollection<Reservas> Reservas { get; set; } = new List<Reservas>();
}
