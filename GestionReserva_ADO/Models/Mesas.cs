using System;
using System.Collections.Generic;

namespace GestionReserva_ADO.Models;

public partial class Mesas
{
    public int MesaId { get; set; }

    public int NumeroMesa { get; set; }

    public int Capacidad { get; set; }

    public int ZonaId { get; set; }

    public string Estado { get; set; } = null!;

    public virtual ICollection<Reservas> Reservas { get; set; } = new List<Reservas>();

    public virtual Zonas Zona { get; set; } = null!;
}
