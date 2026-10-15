using System;
using System.Collections.Generic;
using System.Linq;
using GestionReserva_ADO.Models;
using GestionReserva_BE;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace GestionReserva_ADO
{
    public class ReservasADO
    {
        // Estados de reserva que no ocupan la mesa (Cancelada, Cancelada por el Restaurante,
        // No Show, Anulada por el Solicitante). Son los mismos que excluye la BD en
        // uq_reservas_mesa_fecha_hora y en usp_insertar_reserva / usp_actualizar_reserva.
        private readonly int[] estadosReservaLibres = { 6, 7, 8, 19 };

        public List<ReservasBE> ListarReservas()
        {
            List<ReservasBE> lista = new List<ReservasBE>();

            using (ReservaContext bd = new ReservaContext())
            {
                lista = (from reserva in bd.Reservas
                         join cliente in bd.Clientes on reserva.ClienteId equals cliente.ClienteId
                         join mesa in bd.Mesas on reserva.MesaId equals mesa.MesaId
                         join zona in bd.Zonas on mesa.ZonaId equals zona.ZonaId
                         join turno in bd.Turnos on reserva.TurnoId equals turno.TurnoId
                         join estadoReserva in bd.EstadosReserva on reserva.EstadoId equals estadoReserva.EstadoId
                         join empleado in bd.Empleados on reserva.EmpleadoId equals empleado.EmpleadoId
                         where reserva.Estado == 1
                         orderby reserva.FechaReserva descending, reserva.HoraReserva
                         select new ReservasBE
                         {
                             ReservaId = reserva.ReservaId,
                             ClienteId = reserva.ClienteId,
                             NombreCliente = cliente.Nombres + " " + cliente.Apellidos,
                             FechaReserva = reserva.FechaReserva,
                             HoraReserva = reserva.HoraReserva,
                             NumeroPersonas = reserva.NumeroPersonas,
                             MesaId = reserva.MesaId,
                             NumeroMesa = mesa.NumeroMesa,
                             NombreZona = zona.NombreZona,
                             TurnoId = reserva.TurnoId,
                             NombreTurno = turno.NombreTurno,
                             EstadoId = reserva.EstadoId,
                             NombreEstado = estadoReserva.NombreEstado,
                             EmpleadoId = reserva.EmpleadoId,
                             NombreEmpleado = empleado.Nombres + " " + empleado.Apellidos,
                             Observaciones = reserva.Observaciones,
                             FechaCreacion = reserva.FechaCreacion,
                             UsuarioCreacion = reserva.UsuarioCreacion ?? "",
                             FechaUltModificacion = reserva.FechaUltModificacion,
                             UsuarioUltModificacion = reserva.UsuarioUltModificacion,
                             Estado = reserva.Estado
                         }).ToList();
            }

            return lista;
        }

        public bool AgregarReserva(ReservasBE objReserva)
        {
            try
            {
                using (ReservaContext bd = new ReservaContext())
                {
                    if (ValidarReserva(bd, objReserva) != "")
                    {
                        return false;
                    }

                    using (IDbContextTransaction transaccion = bd.Database.BeginTransaction())
                    {
                        Reservas nuevaReserva = new Reservas
                        {
                            ClienteId = objReserva.ClienteId,
                            FechaReserva = objReserva.FechaReserva,
                            HoraReserva = objReserva.HoraReserva,
                            NumeroPersonas = objReserva.NumeroPersonas,
                            MesaId = objReserva.MesaId,
                            TurnoId = objReserva.TurnoId,
                            EstadoId = objReserva.EstadoId,
                            EmpleadoId = objReserva.EmpleadoId,
                            Observaciones = objReserva.Observaciones,
                            UsuarioCreacion = objReserva.UsuarioCreacion,
                            Estado = 1
                        };

                        bd.Reservas.Add(nuevaReserva);
                        bd.SaveChanges();

                        ActualizarCategoriaCliente(bd, objReserva.ClienteId);

                        transaccion.Commit();
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool ActualizarReserva(ReservasBE objReserva)
        {
            try
            {
                using (ReservaContext bd = new ReservaContext())
                {
                    Reservas? reserva = bd.Reservas.Find(objReserva.ReservaId);

                    if (reserva == null || reserva.Estado == 0)
                    {
                        return false;
                    }

                    if (ValidarReserva(bd, objReserva) != "")
                    {
                        return false;
                    }

                    int clienteAnterior = reserva.ClienteId;

                    using (IDbContextTransaction transaccion = bd.Database.BeginTransaction())
                    {
                        reserva.ClienteId = objReserva.ClienteId;
                        reserva.FechaReserva = objReserva.FechaReserva;
                        reserva.HoraReserva = objReserva.HoraReserva;
                        reserva.NumeroPersonas = objReserva.NumeroPersonas;
                        reserva.MesaId = objReserva.MesaId;
                        reserva.TurnoId = objReserva.TurnoId;
                        reserva.EstadoId = objReserva.EstadoId;
                        reserva.EmpleadoId = objReserva.EmpleadoId;
                        reserva.Observaciones = objReserva.Observaciones;
                        reserva.FechaUltModificacion = DateTime.Now;
                        reserva.UsuarioUltModificacion = objReserva.UsuarioUltModificacion;

                        bd.SaveChanges();

                        ActualizarCategoriaCliente(bd, objReserva.ClienteId);

                        if (clienteAnterior != objReserva.ClienteId)
                        {
                            ActualizarCategoriaCliente(bd, clienteAnterior);
                        }

                        transaccion.Commit();
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool EliminarReserva(int reservaId, string usuario)
        {
            try
            {
                using (ReservaContext bd = new ReservaContext())
                {
                    Reservas? reserva = bd.Reservas.Find(reservaId);

                    if (reserva == null || reserva.Estado == 0)
                    {
                        return false;
                    }

                    if (TienePedidosActivos(bd, reservaId))
                    {
                        return false;
                    }

                    using (IDbContextTransaction transaccion = bd.Database.BeginTransaction())
                    {
                        reserva.Estado = 0;
                        reserva.FechaUltModificacion = DateTime.Now;
                        reserva.UsuarioUltModificacion = usuario;

                        bd.SaveChanges();

                        ActualizarCategoriaCliente(bd, reserva.ClienteId);

                        transaccion.Commit();
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        // Devuelve "" si la reserva cumple las reglas de la BD, o el mensaje a mostrar al usuario.
        public string ValidarReserva(ReservasBE objReserva)
        {
            using (ReservaContext bd = new ReservaContext())
            {
                return ValidarReserva(bd, objReserva);
            }
        }

        public bool TienePedidosActivos(int reservaId)
        {
            using (ReservaContext bd = new ReservaContext())
            {
                return TienePedidosActivos(bd, reservaId);
            }
        }

        // Los combos devuelven solo registros activos. Al editar una reserva se pasa el id actual
        // para incluirlo aunque esté inactivo; al registrar se pasa 0.
        public List<Clientes> ListarClientes(int clienteIdActual)
        {
            List<Clientes> lista = new List<Clientes>();

            using (ReservaContext bd = new ReservaContext())
            {
                lista = (from cliente in bd.Clientes
                         where cliente.Estado == 1 || cliente.ClienteId == clienteIdActual
                         orderby cliente.Apellidos, cliente.Nombres
                         select cliente).ToList();
            }

            return lista;
        }

        public List<Mesas> ListarMesas(int mesaIdActual)
        {
            List<Mesas> lista = new List<Mesas>();

            using (ReservaContext bd = new ReservaContext())
            {
                lista = (from mesa in bd.Mesas.Include(m => m.Zona)
                         where mesa.Estado == 1 || mesa.MesaId == mesaIdActual
                         orderby mesa.NumeroMesa
                         select mesa).ToList();
            }

            return lista;
        }

        public List<Turnos> ListarTurnos(int turnoIdActual)
        {
            List<Turnos> lista = new List<Turnos>();

            using (ReservaContext bd = new ReservaContext())
            {
                lista = (from turno in bd.Turnos
                         where turno.Estado == 1 || turno.TurnoId == turnoIdActual
                         orderby turno.HoraInicio
                         select turno).ToList();
            }

            return lista;
        }

        public List<EstadosReserva> ListarEstadosReserva()
        {
            List<EstadosReserva> lista = new List<EstadosReserva>();

            using (ReservaContext bd = new ReservaContext())
            {
                lista = (from estadoReserva in bd.EstadosReserva
                         orderby estadoReserva.EstadoId
                         select estadoReserva).ToList();
            }

            return lista;
        }

        public List<Empleados> ListarEmpleados(int empleadoIdActual)
        {
            List<Empleados> lista = new List<Empleados>();

            using (ReservaContext bd = new ReservaContext())
            {
                lista = (from empleado in bd.Empleados
                         where empleado.Estado == 1 || empleado.EmpleadoId == empleadoIdActual
                         orderby empleado.Apellidos, empleado.Nombres
                         select empleado).ToList();
            }

            return lista;
        }

        // Al registrar se exigen cliente, mesa, turno y empleado activos.
        // Al actualizar solo se revisa lo que cambia, porque en la BD hay reservas que ya
        // referencian un empleado inactivo o superan la capacidad de su mesa.
        private string ValidarReserva(ReservaContext bd, ReservasBE objReserva)
        {
            Reservas? original = null;

            if (objReserva.ReservaId > 0)
            {
                original = bd.Reservas.Find(objReserva.ReservaId);

                if (original == null || original.Estado == 0)
                {
                    return "La reserva seleccionada ya no existe.";
                }
            }

            if ((original == null || original.ClienteId != objReserva.ClienteId)
                && !bd.Clientes.Any(cliente => cliente.ClienteId == objReserva.ClienteId && cliente.Estado == 1))
            {
                return "El cliente seleccionado no existe o está inactivo.";
            }

            Mesas? mesa = bd.Mesas.Find(objReserva.MesaId);

            if (mesa == null)
            {
                return "La mesa seleccionada no existe.";
            }

            bool cambioMesa = original == null || original.MesaId != objReserva.MesaId;

            if (cambioMesa && mesa.Estado == 0)
            {
                return "La mesa seleccionada está inactiva.";
            }

            if ((cambioMesa || original!.NumeroPersonas != objReserva.NumeroPersonas)
                && objReserva.NumeroPersonas > mesa.Capacidad)
            {
                return "La mesa " + mesa.NumeroMesa + " tiene capacidad para " + mesa.Capacidad + " personas.";
            }

            if ((original == null || original.TurnoId != objReserva.TurnoId)
                && !bd.Turnos.Any(turno => turno.TurnoId == objReserva.TurnoId && turno.Estado == 1))
            {
                return "El turno seleccionado no existe o está inactivo.";
            }

            if (!bd.EstadosReserva.Any(estadoReserva => estadoReserva.EstadoId == objReserva.EstadoId))
            {
                return "El estado de reserva seleccionado no existe.";
            }

            if ((original == null || original.EmpleadoId != objReserva.EmpleadoId)
                && !bd.Empleados.Any(empleado => empleado.EmpleadoId == objReserva.EmpleadoId && empleado.Estado == 1))
            {
                return "El empleado seleccionado no existe o está inactivo.";
            }

            if (ExisteCruceDeReserva(bd, objReserva))
            {
                return "La mesa " + mesa.NumeroMesa + " ya está reservada para el "
                    + objReserva.FechaReserva.ToString("dd/MM/yyyy") + " a las "
                    + objReserva.HoraReserva.ToString("HH:mm") + ".";
            }

            return "";
        }

        // Misma regla que uq_reservas_mesa_fecha_hora: entre reservas activas que ocupan la mesa
        // no puede repetirse la combinación mesa + fecha + hora.
        private bool ExisteCruceDeReserva(ReservaContext bd, ReservasBE objReserva)
        {
            if (estadosReservaLibres.Contains(objReserva.EstadoId))
            {
                return false;
            }

            return (from reserva in bd.Reservas
                    where reserva.MesaId == objReserva.MesaId
                          && reserva.FechaReserva == objReserva.FechaReserva
                          && reserva.HoraReserva == objReserva.HoraReserva
                          && reserva.Estado == 1
                          && !estadosReservaLibres.Contains(reserva.EstadoId)
                          && reserva.ReservaId != objReserva.ReservaId
                    select reserva).Any();
        }

        private bool TienePedidosActivos(ReservaContext bd, int reservaId)
        {
            return bd.Pedidos.Any(pedido => pedido.ReservaId == reservaId && pedido.Estado == 1);
        }

        // Mantiene la categoría del cliente igual que lo hacen los procedimientos de reservas de la BD.
        private void ActualizarCategoriaCliente(ReservaContext bd, int clienteId)
        {
            bd.Database.ExecuteSqlInterpolated($"EXEC usp_actualizar_categoria_cliente @cliente_id = {clienteId}");
        }

    }
}
