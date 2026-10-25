using System;
using System.Collections.Generic;

namespace GestionReserva_ADO.Models;

public partial class Ubigeo
{
    public int UbigeoId { get; set; }

    public string Departamento { get; set; } = null!;

    public string Provincia { get; set; } = null!;

    public string Distrito { get; set; } = null!;

    public virtual ICollection<Empleados> Empleados { get; set; } = new List<Empleados>();
}
