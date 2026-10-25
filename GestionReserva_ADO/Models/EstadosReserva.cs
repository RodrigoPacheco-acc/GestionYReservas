using System;
using System.Collections.Generic;

namespace GestionReserva_ADO.Models;

public partial class EstadosReserva
{
    public int EstadoId { get; set; }

    public string NombreEstado { get; set; } = null!;

    public string? Descripcion { get; set; }

    public virtual ICollection<Reservas> Reservas { get; set; } = new List<Reservas>();
}
