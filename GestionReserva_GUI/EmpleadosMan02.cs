using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GestionReserva_ADO;
using GestionReserva_ADO.Models;
using GestionReserva_BL;

namespace GestionReserva_GUI
{
    public partial class EmpleadosMan02 : Form
    {
        private readonly EmpleadosBL objEmpleadoBL =
            new EmpleadosBL();

        public EmpleadosMan02()
        {
            InitializeComponent();

            cboSexo.Items.AddRange(new object[]
            {
                "M",
                "F"
            });

            CargarCargos();

            dtpFechaContratacion.Value = DateTime.Today;
            dtpFechaContratacion.MaxDate = DateTime.Today;

            dtpFechaNacimiento.MaxDate = DateTime.Today;
            dtpFechaNacimiento.Value = DateTime.Today.AddYears(-18);
        }

        private void CargarCargos()
        {
            using (ReservaContext bd = new ReservaContext())
            {
                cboCargo.DataSource = bd.Cargos.ToList();
                cboCargo.DisplayMember = "NombreCargo";
                cboCargo.ValueMember = "CargoId";
                cboCargo.SelectedIndex = -1;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombres.Text) ||
                string.IsNullOrWhiteSpace(txtApellidos.Text) ||
                string.IsNullOrWhiteSpace(txtDni.Text) ||
                string.IsNullOrWhiteSpace(txtDireccion.Text) ||
                string.IsNullOrWhiteSpace(txtUbigeoId.Text) ||
                cboCargo.SelectedIndex == -1 ||
                cboSexo.SelectedIndex == -1)
            {
                MessageBox.Show("Complete los campos obligatorios.");
                return;
            }

            if (!int.TryParse(txtUbigeoId.Text, out int ubigeoId))
            {
                MessageBox.Show("Ingrese un UbigeoId válido.");
                return;
            }

            Empleados empleado = new Empleados
            {
                Nombres = txtNombres.Text.Trim(),
                Apellidos = txtApellidos.Text.Trim(),
                Dni = txtDni.Text.Trim(),
                Telefono = txtTelefono.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                FechaContratacion = DateOnly.FromDateTime(
                    dtpFechaContratacion.Value),
                FechaNacimiento = DateOnly.FromDateTime(
                    dtpFechaNacimiento.Value),
                CargoId = Convert.ToInt32(cboCargo.SelectedValue),
                Sexo = cboSexo.Text,
                Direccion = txtDireccion.Text.Trim(),
                UbigeoId = ubigeoId,
                UsuarioCreacion = Environment.UserName
            };

            if (objEmpleadoBL.AgregarEmpleado(empleado))
            {
                MessageBox.Show("Empleado registrado correctamente.");
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show(
                    "No se pudo registrar. Verifique los datos y las relaciones.");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
