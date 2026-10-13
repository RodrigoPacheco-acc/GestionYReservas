using System;
using System.Collections.Generic;

namespace GestionReserva_ADO.Models;

public partial class ReservaEmpleados
{
    public int ReservaEmpleadoId { get; set; }

    public int ReservaId { get; set; }

    public int EmpleadoId { get; set; }

    public string RolEnReserva { get; set; } = null!;

    public virtual Empleados Empleado { get; set; } = null!;

    public virtual Reservas Reserva { get; set; } = null!;
}
