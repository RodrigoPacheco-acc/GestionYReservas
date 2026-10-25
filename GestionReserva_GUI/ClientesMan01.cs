using GestionReserva_BE;
using GestionReserva_BL;
using System;
using System.Windows.Forms;

namespace GestionReserva_GUI
{
    public partial class ClientesMan01 : Form
    {
        ClientesBL objClienteBL = new ClientesBL();

        public ClientesMan01()
        {
            InitializeComponent();
        }

        private void ClientesMan01_Load(object sender, EventArgs e)
        {
            ListarClientes();
        }

        private void ListarClientes()
        {
            dgvClientes.DataSource = objClienteBL.ListarClientes();

            dgvClientes.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            if (dgvClientes.Columns.Contains("Estado"))
                dgvClientes.Columns["Estado"]!.Visible = false;

            if (dgvClientes.Columns.Contains("UsuarioCreacion"))
                dgvClientes.Columns["UsuarioCreacion"]!.Visible = false;

            if (dgvClientes.Columns.Contains("UsuarioUltModificacion"))
                dgvClientes.Columns["UsuarioUltModificacion"]!.Visible = false;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            ClientesMan02 frm = new ClientesMan02();

            if (frm.ShowDialog() == DialogResult.OK)
                ListarClientes();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un cliente.");
                return;
            }

            ClientesBE? cliente =
                dgvClientes.CurrentRow.DataBoundItem as ClientesBE;

            if (cliente == null)
            {
                MessageBox.Show("No se pudo obtener el cliente.");
                return;
            }

            ClientesMan03 frm = new ClientesMan03(cliente);

            if (frm.ShowDialog() == DialogResult.OK)
                ListarClientes();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un cliente.");
                return;
            }

            ClientesBE? cliente =
                dgvClientes.CurrentRow.DataBoundItem as ClientesBE;

            if (cliente == null)
                return;

            DialogResult respuesta = MessageBox.Show(
                "¿Desea eliminar al cliente " +
                cliente.Nombres + " " + cliente.Apellidos + "?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                if (objClienteBL.EliminarCliente(
                    cliente.ClienteId, Environment.UserName))
                {
                    MessageBox.Show("Cliente eliminado correctamente.");
                    ListarClientes();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el cliente.");
                }
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void EmpleadosMan01_Load(object sender, EventArgs e)
        {

        }
    }
}
