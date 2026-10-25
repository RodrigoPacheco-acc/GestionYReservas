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

    public byte[]? Foto { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string? UsuarioCreacion { get; set; }

    public DateTime? FechaUltModificacion { get; set; }

    public string? UsuarioUltModificacion { get; set; }

    public int Estado { get; set; }

    public virtual Categorias Categoria { get; set; } = null!;
}
