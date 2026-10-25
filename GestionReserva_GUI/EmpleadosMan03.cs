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
    public partial class EmpleadosMan03 : Form
    {
        private readonly EmpleadosBL objEmpleadoBL =
            new EmpleadosBL();

        private readonly Empleados empleadoOriginal;

        public EmpleadosMan03(Empleados empleado)
        {
            InitializeComponent();

            empleadoOriginal = empleado;

            cboSexo.Items.AddRange(new object[]
            {
                "M",
                "F"
            });

            CargarCargos();
            CargarDatos();

            dtpFechaContratacion.MaxDate = DateTime.Today;
            dtpFechaNacimiento.MaxDate = DateTime.Today;
        }

        private void CargarCargos()
        {
            using (ReservaContext bd = new ReservaContext())
            {
                cboCargo.DataSource = bd.Cargos.ToList();
                cboCargo.DisplayMember = "NombreCargo";
                cboCargo.ValueMember = "CargoId";
            }
        }

        private void CargarDatos()
        {
            txtNombres.Text = empleadoOriginal.Nombres;
            txtApellidos.Text = empleadoOriginal.Apellidos;
            txtDni.Text = empleadoOriginal.Dni;
            txtTelefono.Text = empleadoOriginal.Telefono;
            txtEmail.Text = empleadoOriginal.Email;
            txtDireccion.Text = empleadoOriginal.Direccion;
            txtUbigeoId.Text = empleadoOriginal.UbigeoId.ToString();

            dtpFechaContratacion.Value =
                empleadoOriginal.FechaContratacion.ToDateTime(
                    TimeOnly.MinValue);

            dtpFechaNacimiento.Value =
                empleadoOriginal.FechaNacimiento.ToDateTime(
                    TimeOnly.MinValue);

            cboSexo.SelectedItem = empleadoOriginal.Sexo;
            cboCargo.SelectedValue = empleadoOriginal.CargoId;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombres.Text) ||
                string.IsNullOrWhiteSpace(txtApellidos.Text) ||
                string.IsNullOrWhiteSpace(txtDni.Text) ||
                string.IsNullOrWhiteSpace(txtDireccion.Text) ||
                string.IsNullOrWhiteSpace(txtUbigeoId.Text) ||
                cboSexo.SelectedIndex == -1 ||
                cboCargo.SelectedIndex == -1)
            {
                MessageBox.Show("Complete los campos obligatorios.");
                return;
            }

            if (!int.TryParse(txtUbigeoId.Text, out int ubigeoId))
            {
                MessageBox.Show("Ingrese un Código de Ubigeo válido.");
                return;
            }

            empleadoOriginal.Nombres = txtNombres.Text.Trim();
            empleadoOriginal.Apellidos = txtApellidos.Text.Trim();
            empleadoOriginal.Dni = txtDni.Text.Trim();
            empleadoOriginal.Telefono = txtTelefono.Text.Trim();
            empleadoOriginal.Email = txtEmail.Text.Trim();
            empleadoOriginal.Direccion = txtDireccion.Text.Trim();
            empleadoOriginal.UbigeoId = ubigeoId;
            empleadoOriginal.FechaContratacion =
                DateOnly.FromDateTime(dtpFechaContratacion.Value);
            empleadoOriginal.FechaNacimiento =
                DateOnly.FromDateTime(dtpFechaNacimiento.Value);
            empleadoOriginal.Sexo = cboSexo.Text;
            empleadoOriginal.CargoId =
                Convert.ToInt32(cboCargo.SelectedValue);
            empleadoOriginal.UsuarioUltModificacion =
                Environment.UserName;

            if (objEmpleadoBL.ActualizarEmpleado(empleadoOriginal))
            {
                MessageBox.Show("Empleado actualizado correctamente.");
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show(
                    "No se pudo actualizar. Verifique los datos.");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
