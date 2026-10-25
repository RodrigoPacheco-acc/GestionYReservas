using GestionReserva_BE;
using GestionReserva_BL;
using System;
using System.Windows.Forms;

namespace GestionReserva_GUI
{
    public partial class ClientesMan03 : Form
    {
        private readonly ClientesBL objClienteBL = new ClientesBL();
        private readonly ClientesBE clienteOriginal;

        public ClientesMan03(ClientesBE cliente)
        {
            InitializeComponent();
            clienteOriginal = cliente;

            cboSexo.Items.AddRange(new object[]
            {
                "M",
                "F"
            });

            cboCategoria.Items.AddRange(new object[]
            {
                "Nuevo",
                "Regular",
                "Frecuente"
            });

            dtpFechaNacimiento.MaxDate = DateTime.Today;

            txtNombres.Text = cliente.Nombres;
            txtApellidos.Text = cliente.Apellidos;
            txtTelefono.Text = cliente.Telefono;
            txtCorreo.Text = cliente.Correo;
            dtpFechaNacimiento.Value =
                cliente.FechaNacimiento.ToDateTime(
                    TimeOnly.MinValue) > DateTime.Today
                ? DateTime.Today
                : cliente.FechaNacimiento.ToDateTime(
                    TimeOnly.MinValue);

            cboSexo.SelectedItem = cliente.Sexo;

            if (cliente.CategoriaCliente != null)
                cboCategoria.SelectedItem = cliente.CategoriaCliente;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombres.Text) ||
                string.IsNullOrWhiteSpace(txtApellidos.Text) ||
                string.IsNullOrWhiteSpace(txtCorreo.Text) ||
                cboSexo.SelectedIndex == -1 ||
                cboCategoria.SelectedIndex == -1)
            {
                MessageBox.Show("Complete los campos obligatorios.");
                return;
            }

            clienteOriginal.Nombres = txtNombres.Text.Trim();
            clienteOriginal.Apellidos = txtApellidos.Text.Trim();
            clienteOriginal.Telefono = txtTelefono.Text.Trim();
            clienteOriginal.Correo = txtCorreo.Text.Trim();
            clienteOriginal.FechaNacimiento =
                DateOnly.FromDateTime(dtpFechaNacimiento.Value);
            clienteOriginal.Sexo = cboSexo.Text;
            clienteOriginal.CategoriaCliente = cboCategoria.Text;
            clienteOriginal.UsuarioUltModificacion =
                Environment.UserName;

            if (objClienteBL.ActualizarCliente(clienteOriginal))
            {
                MessageBox.Show("Cliente actualizado correctamente.");
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("No se pudo actualizar el cliente.");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
