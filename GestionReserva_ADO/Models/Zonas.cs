using System;
using System.Collections.Generic;

namespace GestionReserva_ADO.Models;

public partial class Zonas
{
    public int ZonaId { get; set; }

    public string NombreZona { get; set; } = null!;

    public string? Descripcion { get; set; }

    public int CapacidadTotal { get; set; }

    public virtual ICollection<Mesas> Mesas { get; set; } = new List<Mesas>();
}
