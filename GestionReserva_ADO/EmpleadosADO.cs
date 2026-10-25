using GestionReserva_ADO.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GestionReserva_ADO
{
    public class EmpleadosADO
    {
        public List<Empleados> ListarEmpleados()
        {
            using (ReservaContext bd = new ReservaContext())
            {
                return bd.Empleados
                    .Where(e => e.Estado == 1)
                    .OrderBy(e => e.Apellidos)
                    .ThenBy(e => e.Nombres)
                    .ToList();
            }
        }

        public Empleados? BuscarEmpleado(int empleadoId)
        {
            using (ReservaContext bd = new ReservaContext())
            {
                return bd.Empleados
                    .FirstOrDefault(e => e.EmpleadoId == empleadoId);
            }
        }

        public bool AgregarEmpleado(Empleados empleado)
        {
            try
            {
                using (ReservaContext bd = new ReservaContext())
                {
                    empleado.FechaCreacion = DateTime.Now;
                    empleado.Estado = 1;

                    bd.Empleados.Add(empleado);
                    bd.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool ActualizarEmpleado(Empleados empleado)
        {
            try
            {
                using (ReservaContext bd = new ReservaContext())
                {
                    Empleados? actual = bd.Empleados
                        .FirstOrDefault(e =>
                            e.EmpleadoId == empleado.EmpleadoId);

                    if (actual == null)
                        return false;

                    actual.Nombres = empleado.Nombres;
                    actual.Apellidos = empleado.Apellidos;
                    actual.Dni = empleado.Dni;
                    actual.Telefono = empleado.Telefono;
                    actual.Email = empleado.Email;
                    actual.FechaContratacion = empleado.FechaContratacion;
                    actual.CargoId = empleado.CargoId;
                    actual.Sexo = empleado.Sexo;
                    actual.FechaNacimiento = empleado.FechaNacimiento;
                    actual.Direccion = empleado.Direccion;
                    actual.UbigeoId = empleado.UbigeoId;
                    actual.FechaUltModificacion = DateTime.Now;
                    actual.UsuarioUltModificacion =
                        empleado.UsuarioUltModificacion;

                    bd.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool EliminarEmpleado(int empleadoId, string usuario)
        {
            try
            {
                using (ReservaContext bd = new ReservaContext())
                {
                    Empleados? empleado = bd.Empleados
                        .FirstOrDefault(e =>
                            e.EmpleadoId == empleadoId);

                    if (empleado == null)
                        return false;

                    empleado.Estado = 0;
                    empleado.FechaUltModificacion = DateTime.Now;
                    empleado.UsuarioUltModificacion = usuario;

                    bd.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
