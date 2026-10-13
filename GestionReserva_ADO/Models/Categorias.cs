using System;
using System.Collections.Generic;

namespace GestionReserva_ADO.Models;

public partial class Categorias
{
    public int CategoriaId { get; set; }

    public string NombreCategoria { get; set; } = null!;

    public string? Descripcion { get; set; }

    public virtual ICollection<Platos> Platos { get; set; } = new List<Platos>();
}
