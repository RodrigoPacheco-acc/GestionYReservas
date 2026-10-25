using GestionReserva_ADO;
using GestionReserva_ADO.Models;
using GestionReserva_BE;
using System.Collections.Generic;

namespace GestionReserva_BL
{
    public class ReservasBL
    {
        public List<ReservasBE> ListarReservas()
        {
            ReservasADO objReservaADO = new ReservasADO();
            return objReservaADO.ListarReservas();
        }

        public bool AgregarReserva(ReservasBE objReserva)
        {
            if (ValidarCamposObligatorios(objReserva) != "")
            {
                return false;
            }

            ReservasADO objReservaADO = new ReservasADO();
            return objReservaADO.AgregarReserva(objReserva);
        }

        public bool ActualizarReserva(ReservasBE objReserva)
        {
            if (objReserva.ReservaId <= 0 || ValidarCamposObligatorios(objReserva) != "")
            {
                return false;
            }

            ReservasADO objReservaADO = new ReservasADO();
            return objReservaADO.ActualizarReserva(objReserva);
        }

        public bool EliminarReserva(int reservaId, string usuario)
        {
            ReservasADO objReservaADO = new ReservasADO();
            return objReservaADO.EliminarReserva(reservaId, usuario);
        }

        public bool TienePedidosActivos(int reservaId)
        {
            ReservasADO objReservaADO = new ReservasADO();
            return objReservaADO.TienePedidosActivos(reservaId);
        }

        // Devuelve "" si la reserva es válida, o el mensaje a mostrar al usuario.
        // Primero revisa los campos obligatorios y luego las reglas que dependen de la BD.
        public string ValidarReserva(ReservasBE objReserva)
        {
            string mensaje = ValidarCamposObligatorios(objReserva);

            if (mensaje != "")
            {
                return mensaje;
            }

            ReservasADO objReservaADO = new ReservasADO();
            return objReservaADO.ValidarReserva(objReserva);
        }

        // idActual = 0 al registrar; al editar, el id de la relación actual para conservarla aunque esté inactiva.
        public List<Clientes> ListarClientes(int clienteIdActual)
        {
            ReservasADO objReservaADO = new ReservasADO();
            return objReservaADO.ListarClientes(clienteIdActual);
        }

        public List<Mesas> ListarMesas(int mesaIdActual)
        {
            ReservasADO objReservaADO = new ReservasADO();
            return objReservaADO.ListarMesas(mesaIdActual);
        }

        public List<Turnos> ListarTurnos(int turnoIdActual)
        {
            ReservasADO objReservaADO = new ReservasADO();
            return objReservaADO.ListarTurnos(turnoIdActual);
        }

        public List<EstadosReserva> ListarEstadosReserva()
        {
            ReservasADO objReservaADO = new ReservasADO();
            return objReservaADO.ListarEstadosReserva();
        }

        public List<Empleados> ListarEmpleados(int empleadoIdActual)
        {
            ReservasADO objReservaADO = new ReservasADO();
            return objReservaADO.ListarEmpleados(empleadoIdActual);
        }

        private string ValidarCamposObligatorios(ReservasBE objReserva)
        {
            if (objReserva.ClienteId <= 0)
            {
                return "Seleccione un cliente.";
            }

            if (objReserva.FechaReserva == default(DateOnly))
            {
                return "Ingrese la fecha de la reserva.";
            }

            if (objReserva.NumeroPersonas <= 0)
            {
                return "Ingrese un número de personas mayor a cero.";
            }

            if (objReserva.MesaId <= 0)
            {
                return "Seleccione una mesa.";
            }

            if (objReserva.TurnoId <= 0)
            {
                return "Seleccione un turno.";
            }

            if (objReserva.EstadoId <= 0)
            {
                return "Seleccione el estado de la reserva.";
            }

            if (objReserva.EmpleadoId <= 0)
            {
                return "Seleccione el empleado que registra la reserva.";
            }

            if (objReserva.Observaciones != null && objReserva.Observaciones.Length > 300)
            {
                return "Las observaciones no pueden superar los 300 caracteres.";
            }

            return "";
        }

    }
}
