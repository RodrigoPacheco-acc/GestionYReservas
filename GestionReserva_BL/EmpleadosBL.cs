using GestionReserva_ADO;
using GestionReserva_ADO.Models;
using System.Collections.Generic;

namespace GestionReserva_BL
{
    public class EmpleadosBL
    {
        private readonly EmpleadosADO objEmpleadoADO =
            new EmpleadosADO();

        public List<Empleados> ListarEmpleados()
        {
            return objEmpleadoADO.ListarEmpleados();
        }

        public Empleados? BuscarEmpleado(int empleadoId)
        {
            return objEmpleadoADO.BuscarEmpleado(empleadoId);
        }

        public bool AgregarEmpleado(Empleados empleado)
        {
            if (string.IsNullOrWhiteSpace(empleado.Nombres) ||
                string.IsNullOrWhiteSpace(empleado.Apellidos) ||
                string.IsNullOrWhiteSpace(empleado.Dni))
            {
                return false;
            }

            return objEmpleadoADO.AgregarEmpleado(empleado);
        }

        public bool ActualizarEmpleado(Empleados empleado)
        {
            if (empleado.EmpleadoId <= 0 ||
                string.IsNullOrWhiteSpace(empleado.Nombres) ||
                string.IsNullOrWhiteSpace(empleado.Apellidos) ||
                string.IsNullOrWhiteSpace(empleado.Dni))
            {
                return false;
            }

            return objEmpleadoADO.ActualizarEmpleado(empleado);
        }

        public bool EliminarEmpleado(int empleadoId, string usuario)
        {
            if (empleadoId <= 0)
                return false;

            return objEmpleadoADO.EliminarEmpleado(
                empleadoId, usuario);
        }
    }
}
