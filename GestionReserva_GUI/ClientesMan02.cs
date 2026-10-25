using GestionReserva_BE;
using GestionReserva_BL;
using System;
using System.Windows.Forms;

namespace GestionReserva_GUI
{
    public partial class ClientesMan02 : Form
    {
        private readonly ClientesBL objClienteBL = new ClientesBL();

        public ClientesMan02()
        {
            InitializeComponent();

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
            dtpFechaNacimiento.Value = DateTime.Today.AddYears(-18);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombres.Text) ||
                string.IsNullOrWhiteSpace(txtApellidos.Text) ||
                string.IsNullOrWhiteSpace(txtCorreo.Text) ||
                cboSexo.SelectedIndex == -1 ||
                cboCategoria.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Complete todos los campos obligatorios.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            ClientesBE cliente = new ClientesBE
            {
                Nombres = txtNombres.Text.Trim(),
                Apellidos = txtApellidos.Text.Trim(),
                Telefono = txtTelefono.Text.Trim(),
                Correo = txtCorreo.Text.Trim(),
                FechaNacimiento = DateOnly.FromDateTime(
                    dtpFechaNacimiento.Value),
                Sexo = cboSexo.Text,
                CategoriaCliente = cboCategoria.Text,
                UsuarioCreacion = Environment.UserName
            };

            if (objClienteBL.AgregarCliente(cliente))
            {
                MessageBox.Show("Cliente registrado correctamente.");
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show(
                    "No se pudo registrar el cliente. Verifique los datos.");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
