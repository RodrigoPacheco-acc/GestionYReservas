using System;
using System.Collections.Generic;

namespace GestionReserva_ADO.Models;

public partial class Mesas
{
    public int MesaId { get; set; }

    public int NumeroMesa { get; set; }

    public int Capacidad { get; set; }

    public int ZonaId { get; set; }

    public string EstadoMesa { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public string? UsuarioCreacion { get; set; }

    public DateTime? FechaUltModificacion { get; set; }

    public string? UsuarioUltModificacion { get; set; }

    public int Estado { get; set; }

    // Solo lectura (EF no la mapea): texto para mostrar en los ComboBox. Requiere cargar la Zona.
    public string DescripcionMesa => "Mesa " + NumeroMesa + " - " + (Zona != null ? Zona.NombreZona : "") + " (" + Capacidad + " pers.)" + (Estado == 0 ? " [inactiva]" : "");

    public virtual ICollection<Reservas> Reservas { get; set; } = new List<Reservas>();

    public virtual Zonas Zona { get; set; } = null!;
}
