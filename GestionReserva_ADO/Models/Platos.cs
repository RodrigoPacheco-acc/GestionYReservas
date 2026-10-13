using System;
using System.Collections.Generic;

namespace GestionReserva_ADO.Models;

public partial class Platos
{
    public int PlatoId { get; set; }

    public string NombrePlato { get; set; } = null!;

    public string? Descripcion { get; set; }

    public int CategoriaId { get; set; }

    public int? TiempoPreparacionMinutos { get; set; }

    public bool Disponible { get; set; }

    public decimal? PrecioReferencial { get; set; }

    public virtual Categorias Categoria { get; set; } = null!;
}
