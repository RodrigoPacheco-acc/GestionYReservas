using System;
using System.Collections.Generic;

namespace GestionReserva_ADO.Models;

public partial class DetallePedido
{
    public int DetallePedidoId { get; set; }

    public int PedidoId { get; set; }

    public int PlatoId { get; set; }

    public int Cantidad { get; set; }

    public virtual Pedidos Pedido { get; set; } = null!;

    public virtual Platos Plato { get; set; } = null!;
}
