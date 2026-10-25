using GestionReserva_ADO.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GestionReserva_ADO
{
    public class ClientesADO
    {
        public List<Clientes> ListarClientes()
        {
            using (ReservaContext bd = new ReservaContext())
            {
                return bd.Clientes
                    .OrderBy(c => c.Apellidos)
                    .ThenBy(c => c.Nombres)
                    .ToList();
            }
        }

        public Clientes? BuscarCliente(int clienteId)
        {
            using (ReservaContext bd = new ReservaContext())
            {
                return bd.Clientes
                    .FirstOrDefault(c => c.ClienteId == clienteId);
            }
        }

        public bool AgregarCliente(Clientes cliente)
        {
            try
            {
                using (ReservaContext bd = new ReservaContext())
                {
                    cliente.FechaCreacion = DateTime.Now;
                    cliente.Estado = 1;

                    bd.Clientes.Add(cliente);
                    bd.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool ActualizarCliente(Clientes cliente)
        {
            try
            {
                using (ReservaContext bd = new ReservaContext())
                {
                    Clientes? actual = bd.Clientes
                        .FirstOrDefault(c => c.ClienteId == cliente.ClienteId);

                    if (actual == null)
                        return false;

                    actual.Nombres = cliente.Nombres;
                    actual.Apellidos = cliente.Apellidos;
                    actual.Telefono = cliente.Telefono;
                    actual.Correo = cliente.Correo;
                    actual.FechaNacimiento = cliente.FechaNacimiento;
                    actual.Sexo = cliente.Sexo;
                    actual.CategoriaCliente = cliente.CategoriaCliente;
                    actual.FechaUltModificacion = DateTime.Now;
                    actual.UsuarioUltModificacion =
                        cliente.UsuarioUltModificacion;

                    bd.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool EliminarCliente(int clienteId, string usuario)
        {
            try
            {
                using (ReservaContext bd = new ReservaContext())
                {
                    Clientes? cliente = bd.Clientes
                        .FirstOrDefault(c => c.ClienteId == clienteId);

                    if (cliente == null)
                        return false;

                    cliente.Estado = 0;
                    cliente.FechaUltModificacion = DateTime.Now;
                    cliente.UsuarioUltModificacion = usuario;

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
