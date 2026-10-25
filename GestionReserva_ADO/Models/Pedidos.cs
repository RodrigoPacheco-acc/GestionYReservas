using System;
using System.Collections.Generic;

namespace GestionReserva_ADO.Models;

public partial class Pedidos
{
    public int PedidoId { get; set; }

    public DateTime FechaPedido { get; set; }

    public int ReservaId { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string? UsuarioCreacion { get; set; }

    public DateTime? FechaUltModificacion { get; set; }

    public string? UsuarioUltModificacion { get; set; }

    public int Estado { get; set; }

    public virtual ICollection<DetallePedido> DetallePedido { get; set; } = new List<DetallePedido>();

    public virtual Reservas Reserva { get; set; } = null!;
}
