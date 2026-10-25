using System;
using System.Collections.Generic;

namespace GestionReserva_ADO.Models;

public partial class Cargos
{
    public int CargoId { get; set; }

    public string NombreCargo { get; set; } = null!;

    public string? DescripcionCargo { get; set; }

    public decimal? SalarioBase { get; set; }

    public virtual ICollection<Empleados> Empleados { get; set; } = new List<Empleados>();
}
