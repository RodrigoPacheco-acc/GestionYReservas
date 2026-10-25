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

    public virtual DbSet<Clientes> Clientes { get; set; }

    public virtual DbSet<DetallePedido> DetallePedido { get; set; }

    public virtual DbSet<Empleados> Empleados { get; set; }

    public virtual DbSet<EstadosReserva> EstadosReserva { get; set; }

    public virtual DbSet<Mesas> Mesas { get; set; }

    public virtual DbSet<Pedidos> Pedidos { get; set; }

    public virtual DbSet<Platos> Platos { get; set; }

    public virtual DbSet<Reservas> Reservas { get; set; }

    public virtual DbSet<Turnos> Turnos { get; set; }

    public virtual DbSet<Ubigeo> Ubigeo { get; set; }

    public virtual DbSet<Zonas> Zonas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=bd_reservas_restaurante;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Ignore<ReservaEmpleados>();

        modelBuilder.Entity<Cargos>(entity =>
        {
            entity.ToTable("cargos");

            entity.HasKey(e => e.CargoId).HasName("pk_cargos");

            entity.Property(e => e.CargoId)
                .HasColumnName("cargo_id");

            entity.Property(e => e.NombreCargo)
                .HasColumnName("nombre_cargo")
                .HasMaxLength(50);

            entity.Property(e => e.DescripcionCargo)
                .HasColumnName("descripcion_cargo")
                .HasMaxLength(200);

            entity.Property(e => e.SalarioBase)
                .HasColumnName("salario_base")
                .HasColumnType("decimal(10, 2)");
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

        modelBuilder.Entity<Clientes>(entity =>
        {
            entity.ToTable("clientes");

            entity.HasKey(e => e.ClienteId).HasName("pk_clientes");

            entity.HasIndex(e => e.Correo, "uq_clientes_correo").IsUnique();

            entity.Property(e => e.ClienteId)
                .HasColumnName("cliente_id");

            entity.Property(e => e.Nombres)
                .HasColumnName("nombres")
                .HasMaxLength(50);

            entity.Property(e => e.Apellidos)
                .HasColumnName("apellidos")
                .HasMaxLength(50);

            entity.Property(e => e.Telefono)
                .HasColumnName("telefono")
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.Property(e => e.Correo)
                .HasColumnName("correo")
                .HasMaxLength(100);

            entity.Property(e => e.FechaNacimiento)
                .HasColumnName("fecha_nacimiento");

            entity.Property(e => e.Sexo)
                .HasColumnName("sexo")
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();

            entity.Property(e => e.CategoriaCliente)
                .HasColumnName("categoria_cliente")
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("Nuevo");

            entity.Property(e => e.FechaCreacion)
                .HasColumnName("fecha_creacion")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.UsuarioCreacion)
                .HasColumnName("usuario_creacion")
                .HasMaxLength(50)
                .HasDefaultValueSql("(suser_sname())");

            entity.Property(e => e.FechaUltModificacion)
                .HasColumnName("fecha_ult_modificacion")
                .HasColumnType("datetime");

            entity.Property(e => e.UsuarioUltModificacion)
                .HasColumnName("usuario_ult_modificacion")
                .HasMaxLength(50);

            entity.Property(e => e.Estado)
                .HasColumnName("estado");
        });

        modelBuilder.Entity<DetallePedido>(entity =>
        {
            entity.ToTable("detalle_pedido");

            entity.HasKey(e => e.DetallePedidoId).HasName("pk_detalle_pedido");

            entity.HasIndex(e => new { e.PedidoId, e.PlatoId }, "uq_detalle_pedido_pedido_plato").IsUnique();

            entity.Property(e => e.DetallePedidoId)
                .HasColumnName("detalle_pedido_id");

            entity.Property(e => e.PedidoId)
                .HasColumnName("pedido_id");

            entity.Property(e => e.PlatoId)
                .HasColumnName("plato_id");

            entity.Property(e => e.Cantidad)
                .HasColumnName("cantidad");

            entity.HasOne(d => d.Pedido).WithMany(p => p.DetallePedido)
                .HasForeignKey(d => d.PedidoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_detalle_pedido_pedidos");

            entity.HasOne(d => d.Plato).WithMany()
                .HasForeignKey(d => d.PlatoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_detalle_pedido_platos");
        });

        modelBuilder.Entity<Empleados>(entity =>
        {
            entity.ToTable("empleados");

            entity.HasKey(e => e.EmpleadoId).HasName("pk_empleados");

            entity.HasIndex(e => e.Dni, "uq_empleados_dni").IsUnique();

            entity.Property(e => e.EmpleadoId)
                .HasColumnName("empleado_id");

            entity.Property(e => e.Nombres)
                .HasColumnName("nombres")
                .HasMaxLength(50);

            entity.Property(e => e.Apellidos)
                .HasColumnName("apellidos")
                .HasMaxLength(50);

            entity.Property(e => e.Dni)
                .HasColumnName("dni")
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength();

            entity.Property(e => e.Telefono)
                .HasColumnName("telefono")
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.Property(e => e.Email)
                .HasColumnName("email")
                .HasMaxLength(100);

            entity.Property(e => e.FechaContratacion)
                .HasColumnName("fecha_contratacion");

            entity.Property(e => e.CargoId)
                .HasColumnName("cargo_id");

            entity.Property(e => e.Foto)
                .HasColumnName("foto");

            entity.Property(e => e.Sexo)
                .HasColumnName("sexo")
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();

            entity.Property(e => e.FechaNacimiento)
                .HasColumnName("fecha_nacimiento");

            entity.Property(e => e.Direccion)
                .HasColumnName("direccion")
                .HasMaxLength(150);

            entity.Property(e => e.UbigeoId)
                .HasColumnName("ubigeo_id");

            entity.Property(e => e.FechaCreacion)
                .HasColumnName("fecha_creacion")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.UsuarioCreacion)
                .HasColumnName("usuario_creacion")
                .HasMaxLength(50)
                .HasDefaultValueSql("(suser_sname())");

            entity.Property(e => e.FechaUltModificacion)
                .HasColumnName("fecha_ult_modificacion")
                .HasColumnType("datetime");

            entity.Property(e => e.UsuarioUltModificacion)
                .HasColumnName("usuario_ult_modificacion")
                .HasMaxLength(50);

            entity.Property(e => e.Estado)
                .HasColumnName("estado");

            entity.HasOne(d => d.Cargo).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.CargoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_empleados_cargos");

            entity.HasOne(d => d.Ubigeo).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.UbigeoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_empleados_ubigeo");
        });

        modelBuilder.Entity<EstadosReserva>(entity =>
        {
            entity.ToTable("estados_reserva");

            entity.HasKey(e => e.EstadoId).HasName("pk_estados_reserva");

            entity.Property(e => e.EstadoId)
                .HasColumnName("estado_id");

            entity.Property(e => e.NombreEstado)
                .HasColumnName("nombre_estado")
                .HasMaxLength(50);

            entity.Property(e => e.Descripcion)
                .HasColumnName("descripcion")
                .HasMaxLength(200);
        });

        modelBuilder.Entity<Mesas>(entity =>
        {
            entity.ToTable("mesas");

            entity.HasKey(e => e.MesaId).HasName("pk_mesas");

            entity.Property(e => e.MesaId)
                .HasColumnName("mesa_id");

            entity.Property(e => e.NumeroMesa)
                .HasColumnName("numero_mesa");

            entity.Property(e => e.Capacidad)
                .HasColumnName("capacidad");

            entity.Property(e => e.ZonaId)
                .HasColumnName("zona_id");

            entity.Property(e => e.EstadoMesa)
                .HasColumnName("estado_mesa")
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("Disponible");

            entity.Property(e => e.FechaCreacion)
                .HasColumnName("fecha_creacion")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.UsuarioCreacion)
                .HasColumnName("usuario_creacion")
                .HasMaxLength(50)
                .HasDefaultValueSql("(suser_sname())");

            entity.Property(e => e.FechaUltModificacion)
                .HasColumnName("fecha_ult_modificacion")
                .HasColumnType("datetime");

            entity.Property(e => e.UsuarioUltModificacion)
                .HasColumnName("usuario_ult_modificacion")
                .HasMaxLength(50);

            entity.Property(e => e.Estado)
                .HasColumnName("estado");

            entity.HasOne(d => d.Zona).WithMany(p => p.Mesas)
                .HasForeignKey(d => d.ZonaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_mesas_zonas");
        });

        modelBuilder.Entity<Pedidos>(entity =>
        {
            entity.ToTable("pedidos");

            entity.HasKey(e => e.PedidoId).HasName("pk_pedidos");

            entity.Property(e => e.PedidoId)
                .HasColumnName("pedido_id");

            entity.Property(e => e.FechaPedido)
                .HasColumnName("fecha_pedido")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.ReservaId)
                .HasColumnName("reserva_id");

            entity.Property(e => e.FechaCreacion)
                .HasColumnName("fecha_creacion")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.UsuarioCreacion)
                .HasColumnName("usuario_creacion")
                .HasMaxLength(50)
                .HasDefaultValueSql("(suser_sname())");

            entity.Property(e => e.FechaUltModificacion)
                .HasColumnName("fecha_ult_modificacion")
                .HasColumnType("datetime");

            entity.Property(e => e.UsuarioUltModificacion)
                .HasColumnName("usuario_ult_modificacion")
                .HasMaxLength(50);

            entity.Property(e => e.Estado)
                .HasColumnName("estado");

            entity.HasOne(d => d.Reserva).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.ReservaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_pedidos_reservas");
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
                .HasColumnName("disponible");

            entity.Property(e => e.PrecioReferencial)
                .HasColumnName("precio_referencial")
                .HasColumnType("decimal(8, 2)");

            entity.HasOne(d => d.Categoria).WithMany(p => p.Platos)
                .HasForeignKey(d => d.CategoriaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_platos_categorias");

            entity.Property(e => e.Foto)
                .HasColumnName("foto");

            entity.Property(e => e.FechaCreacion)
                .HasColumnName("fecha_creacion")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.UsuarioCreacion)
                .HasColumnName("usuario_creacion")
                .HasMaxLength(50)
                .HasDefaultValueSql("(suser_sname())");

            entity.Property(e => e.FechaUltModificacion)
                .HasColumnName("fecha_ult_modificacion")
                .HasColumnType("datetime");

            entity.Property(e => e.UsuarioUltModificacion)
                .HasColumnName("usuario_ult_modificacion")
                .HasMaxLength(50);

            entity.Property(e => e.Estado)
                .HasColumnName("estado");

        });

        modelBuilder.Entity<Reservas>(entity =>
        {
            entity.ToTable("reservas");

            entity.HasKey(e => e.ReservaId).HasName("pk_reservas");

            entity.HasIndex(e => new { e.MesaId, e.FechaReserva, e.HoraReserva }, "uq_reservas_mesa_fecha_hora")
                .IsUnique()
                .HasFilter("([estado]=(1) AND [estado_id]<>(6) AND [estado_id]<>(7) AND [estado_id]<>(8) AND [estado_id]<>(19))");

            entity.Property(e => e.ReservaId)
                .HasColumnName("reserva_id");

            entity.Property(e => e.ClienteId)
                .HasColumnName("cliente_id");

            entity.Property(e => e.FechaReserva)
                .HasColumnName("fecha_reserva");

            entity.Property(e => e.HoraReserva)
                .HasColumnName("hora_reserva");

            entity.Property(e => e.NumeroPersonas)
                .HasColumnName("numero_personas");

            entity.Property(e => e.MesaId)
                .HasColumnName("mesa_id");

            entity.Property(e => e.TurnoId)
                .HasColumnName("turno_id");

            entity.Property(e => e.EstadoId)
                .HasColumnName("estado_id");

            entity.Property(e => e.EmpleadoId)
                .HasColumnName("empleado_id");

            entity.Property(e => e.Observaciones)
                .HasColumnName("observaciones")
                .HasMaxLength(300);

            entity.Property(e => e.FechaCreacion)
                .HasColumnName("fecha_creacion")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.UsuarioCreacion)
                .HasColumnName("usuario_creacion")
                .HasMaxLength(50)
                .HasDefaultValueSql("(suser_sname())");

            entity.Property(e => e.FechaUltModificacion)
                .HasColumnName("fecha_ult_modificacion")
                .HasColumnType("datetime");

            entity.Property(e => e.UsuarioUltModificacion)
                .HasColumnName("usuario_ult_modificacion")
                .HasMaxLength(50);

            entity.Property(e => e.Estado)
                .HasColumnName("estado");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_reservas_clientes");

            entity.HasOne(d => d.Empleado).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.EmpleadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_reservas_empleados");

            entity.HasOne(d => d.EstadoReserva).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.EstadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_reservas_estados_reserva");

            entity.HasOne(d => d.Mesa).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.MesaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_reservas_mesas");

            entity.HasOne(d => d.Turno).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.TurnoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_reservas_turnos");
        });

        modelBuilder.Entity<Turnos>(entity =>
        {
            entity.ToTable("turnos");

            entity.HasKey(e => e.TurnoId).HasName("pk_turnos");

            entity.Property(e => e.TurnoId)
                .HasColumnName("turno_id");

            entity.Property(e => e.NombreTurno)
                .HasColumnName("nombre_turno")
                .HasMaxLength(50);

            entity.Property(e => e.HoraInicio)
                .HasColumnName("hora_inicio_turno");

            entity.Property(e => e.HoraFin)
                .HasColumnName("hora_fin_turno");

            entity.Property(e => e.FechaCreacion)
                .HasColumnName("fecha_creacion")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.UsuarioCreacion)
                .HasColumnName("usuario_creacion")
                .HasMaxLength(50)
                .HasDefaultValueSql("(suser_sname())");

            entity.Property(e => e.FechaUltModificacion)
                .HasColumnName("fecha_ult_modificacion")
                .HasColumnType("datetime");

            entity.Property(e => e.UsuarioUltModificacion)
                .HasColumnName("usuario_ult_modificacion")
                .HasMaxLength(50);

            entity.Property(e => e.Estado)
                .HasColumnName("estado");
        });

        modelBuilder.Entity<Ubigeo>(entity =>
        {
            entity.ToTable("ubigeo");

            entity.HasKey(e => e.UbigeoId).HasName("pk_ubigeo");

            entity.Property(e => e.UbigeoId)
                .HasColumnName("ubigeo_id");

            entity.Property(e => e.Departamento)
                .HasColumnName("departamento")
                .HasMaxLength(50);

            entity.Property(e => e.Provincia)
                .HasColumnName("provincia")
                .HasMaxLength(50);

            entity.Property(e => e.Distrito)
                .HasColumnName("distrito")
                .HasMaxLength(50);
        });

        modelBuilder.Entity<Zonas>(entity =>
        {
            entity.ToTable("zonas");

            entity.HasKey(e => e.ZonaId).HasName("pk_zonas");

            entity.Property(e => e.ZonaId)
                .HasColumnName("zona_id");

            entity.Property(e => e.NombreZona)
                .HasColumnName("nombre_zona")
                .HasMaxLength(50);

            entity.Property(e => e.Descripcion)
                .HasColumnName("descripcion")
                .HasMaxLength(200);

            entity.Property(e => e.FechaCreacion)
                .HasColumnName("fecha_creacion")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.UsuarioCreacion)
                .HasColumnName("usuario_creacion")
                .HasMaxLength(50)
                .HasDefaultValueSql("(suser_sname())");

            entity.Property(e => e.FechaUltModificacion)
                .HasColumnName("fecha_ult_modificacion")
                .HasColumnType("datetime");

            entity.Property(e => e.UsuarioUltModificacion)
                .HasColumnName("usuario_ult_modificacion")
                .HasMaxLength(50);

            entity.Property(e => e.Estado)
                .HasColumnName("estado");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
