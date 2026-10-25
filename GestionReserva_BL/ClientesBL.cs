using GestionReserva_ADO;
using GestionReserva_ADO.Models;
using GestionReserva_BE;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GestionReserva_BL
{
    public class ClientesBL
    {
        public List<ClientesBE> ListarClientes()
        {
            ClientesADO ado = new ClientesADO();

            return ado.ListarClientes()
                .Select(c => ConvertirBE(c))
                .ToList();
        }

        public ClientesBE? BuscarCliente(int clienteId)
        {
            ClientesADO ado = new ClientesADO();
            Clientes? cliente = ado.BuscarCliente(clienteId);

            return cliente == null ? null : ConvertirBE(cliente);
        }

        public bool AgregarCliente(ClientesBE cliente)
        {
            if (!ValidarCliente(cliente))
                return false;

            ClientesADO ado = new ClientesADO();

            return ado.AgregarCliente(ConvertirModelo(cliente));
        }

        public bool ActualizarCliente(ClientesBE cliente)
        {
            if (cliente.ClienteId <= 0 || !ValidarCliente(cliente))
                return false;

            ClientesADO ado = new ClientesADO();

            return ado.ActualizarCliente(ConvertirModelo(cliente));
        }

        public bool EliminarCliente(int clienteId, string usuario)
        {
            if (clienteId <= 0)
                return false;

            ClientesADO ado = new ClientesADO();

            return ado.EliminarCliente(clienteId, usuario);
        }

        private bool ValidarCliente(ClientesBE c)
        {
            return !string.IsNullOrWhiteSpace(c.Nombres)
                && !string.IsNullOrWhiteSpace(c.Apellidos)
                && !string.IsNullOrWhiteSpace(c.Correo)
                && !string.IsNullOrWhiteSpace(c.Sexo)
                && c.FechaNacimiento != default(DateOnly);
        }

        private ClientesBE ConvertirBE(Clientes c)
        {
            return new ClientesBE
            {
                ClienteId = c.ClienteId,
                Nombres = c.Nombres,
                Apellidos = c.Apellidos,
                Telefono = c.Telefono,
                Correo = c.Correo,
                FechaNacimiento = c.FechaNacimiento,
                Sexo = c.Sexo,
                CategoriaCliente = c.CategoriaCliente,
                FechaCreacion = c.FechaCreacion,
                UsuarioCreacion = c.UsuarioCreacion,
                FechaUltModificacion = c.FechaUltModificacion,
                UsuarioUltModificacion = c.UsuarioUltModificacion,
                Estado = c.Estado
            };
        }

        private Clientes ConvertirModelo(ClientesBE c)
        {
            return new Clientes
            {
                ClienteId = c.ClienteId,
                Nombres = c.Nombres,
                Apellidos = c.Apellidos,
                Telefono = c.Telefono,
                Correo = c.Correo,
                FechaNacimiento = c.FechaNacimiento,
                Sexo = c.Sexo,
                CategoriaCliente = c.CategoriaCliente,
                UsuarioCreacion = c.UsuarioCreacion,
                UsuarioUltModificacion = c.UsuarioUltModificacion
            };
        }
    }
}
