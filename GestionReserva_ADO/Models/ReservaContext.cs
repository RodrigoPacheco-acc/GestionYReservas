using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GestionReserva_ADO.Models;

public partial class ReservaContext : DbContext
{
    public ReservaContext()
    {
    }

    public ReservaContext(DbContextOptions<ReservaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cargos> Cargos { get; set; }

    public virtual DbSet<Categorias> Categorias { get; set; }

    public virtual DbSet<Empleados> Empleados { get; set; }

    public virtual DbSet<EstadosReserva> EstadosReserva { get; set; }

    public virtual DbSet<Mesas> Mesas { get; set; }

    public virtual DbSet<Platos> Platos { get; set; }

    public virtual DbSet<ReservaEmpleados> ReservaEmpleados { get; set; }

    public virtual DbSet<Reservas> Reservas { get; set; }

    public virtual DbSet<Turnos> Turnos { get; set; }

    public virtual DbSet<Zonas> Zonas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=bd_reservas_restaurante;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cargos>(entity =>
        {
            entity.HasKey(e => e.CargoId).HasName("PK__Cargos__B4E665CD8907DC19");

            entity.ToTable("cargos");

            entity.Property(e => e.DescripcionCargo).HasMaxLength(200);
            entity.Property(e => e.NombreCargo).HasMaxLength(50);
            entity.Property(e => e.SalarioBase).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Categorias>(entity =>
        {
            entity.HasKey(e => e.CategoriaId);

            entity.ToTable("categorias");

            entity.Property(e => e.CategoriaId)
                .HasColumnName("categoria_id");

            entity.Property(e => e.Descripcion)
                .HasColumnName("descripcion")
                .HasMaxLength(200);

            entity.Property(e => e.NombreCategoria)
                .HasColumnName("nombre_categoria")
                .HasMaxLength(50);
        });


        modelBuilder.Entity<Empleados>(entity =>
        {
            entity.HasKey(e => e.EmpleadoId).HasName("PK__Empleado__958BE910692AAA31");

            entity.HasIndex(e => e.Dni, "UQ__Empleado__C035B8DDB9BFDF34").IsUnique();

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Apellidos).HasMaxLength(50);
            entity.Property(e => e.Dni)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("DNI");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Nombres).HasMaxLength(50);
            entity.Property(e => e.Telefono)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.HasOne(d => d.Cargo).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.CargoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Empleados_Cargos");
        });

        modelBuilder.Entity<EstadosReserva>(entity =>
        {
            entity.HasKey(e => e.EstadoId).HasName("PK__EstadosR__FEF86B00DDC71E97");

            entity.Property(e => e.Descripcion).HasMaxLength(200);
            entity.Property(e => e.NombreEstado).HasMaxLength(50);
        });

        modelBuilder.Entity<Mesas>(entity =>
        {
            entity.HasKey(e => e.MesaId).HasName("PK__Mesas__6A4196E878DBF750");

            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("Disponible");

            entity.HasOne(d => d.Zona).WithMany(p => p.Mesas)
                .HasForeignKey(d => d.ZonaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Mesas_Zonas");
        });


        modelBuilder.Entity<Platos>(entity =>
        {
            entity.ToTable("platos");

            entity.HasKey(e => e.PlatoId);

            entity.Property(e => e.PlatoId)
                .HasColumnName("plato_id");

            entity.Property(e => e.NombrePlato)
                .HasColumnName("nombre_plato")
                .HasMaxLength(100);

            entity.Property(e => e.Descripcion)
                .HasColumnName("descripcion")
                .HasMaxLength(300);

            entity.Property(e => e.CategoriaId)
                .HasColumnName("categoria_id");

            entity.Property(e => e.TiempoPreparacionMinutos)
                .HasColumnName("tiempo_preparacion_minutos");

            entity.Property(e => e.Disponible)
                .HasColumnName("disponible")
                .HasDefaultValue(true);

            entity.Property(e => e.PrecioReferencial)
                .HasColumnName("precio_referencial")
                .HasColumnType("decimal(8, 2)");

            entity.HasOne(d => d.Categoria).WithMany(p => p.Platos)
                .HasForeignKey(d => d.CategoriaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Platos_Categorias");

            entity.Property(e => e.Foto)
                .HasColumnName("foto");

            entity.Property(e => e.FechaCreacion)
                .HasColumnName("fecha_creacion")
                .HasColumnType("datetime");

            entity.Property(e => e.UsuarioCreacion)
                .HasColumnName("usuario_creacion")
                .HasMaxLength(50);

            entity.Property(e => e.FechaUltModificacion)
                .HasColumnName("fecha_ult_modificacion")
                .HasColumnType("datetime");

            entity.Property(e => e.UsuarioUltModificacion)
                .HasColumnName("usuario_ult_modificacion")
                .HasMaxLength(50);

            entity.Property(e => e.Estado)
                .HasColumnName("estado");

        });


        modelBuilder.Entity<ReservaEmpleados>(entity =>
        {
            entity.HasKey(e => e.ReservaEmpleadoId).HasName("PK__ReservaE__A89E1BC5A7860DBA");

            entity.Property(e => e.RolEnReserva).HasMaxLength(50);

            entity.HasOne(d => d.Empleado).WithMany(p => p.ReservaEmpleados)
                .HasForeignKey(d => d.EmpleadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReservaEmpleados_Empleados");

            entity.HasOne(d => d.Reserva).WithMany(p => p.ReservaEmpleados)
                .HasForeignKey(d => d.ReservaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReservaEmpleados_Reservas");
        });

        modelBuilder.Entity<Reservas>(entity =>
        {
            entity.HasKey(e => e.ReservaId).HasName("PK__Reservas__C399376311E488E4");

            entity.Property(e => e.EmailReservante).HasMaxLength(100);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NombreReservante).HasMaxLength(100);
            entity.Property(e => e.Observaciones).HasMaxLength(300);
            entity.Property(e => e.TelefonoReservante)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.HasOne(d => d.Empleado).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.EmpleadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reservas_Empleados");

            entity.HasOne(d => d.Estado).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.EstadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reservas_EstadosReserva");

            entity.HasOne(d => d.Mesa).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.MesaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reservas_Mesas");

            entity.HasOne(d => d.Turno).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.TurnoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reservas_Turnos");
        });

        modelBuilder.Entity<Turnos>(entity =>
        {
            entity.HasKey(e => e.TurnoId).HasName("PK__Turnos__AD3E2E943A2D805F");

            entity.Property(e => e.NombreTurno).HasMaxLength(50);
        });

        modelBuilder.Entity<Zonas>(entity =>
        {
            entity.HasKey(e => e.ZonaId).HasName("PK__Zonas__1F1E05763342BA73");

            entity.Property(e => e.Descripcion).HasMaxLength(200);
            entity.Property(e => e.NombreZona).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
