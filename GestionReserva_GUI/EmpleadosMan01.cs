using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GestionReserva_ADO.Models;
using GestionReserva_BL;

namespace GestionReserva_GUI
{
    public partial class EmpleadosMan01 : Form
    {
        private readonly EmpleadosBL objEmpleadoBL =
            new EmpleadosBL();

        public EmpleadosMan01()
        {
            InitializeComponent();
        }

        private void EmpleadosMan01_Load(object sender, EventArgs e)
        {
            ListarEmpleados();
        }

        private void ListarEmpleados()
        {
            dgvEmpleados.DataSource =
                objEmpleadoBL.ListarEmpleados();

            dgvEmpleados.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            if (dgvEmpleados.Columns.Contains("Foto"))
                dgvEmpleados.Columns["Foto"]!.Visible = false;

            if (dgvEmpleados.Columns.Contains("Cargo"))
                dgvEmpleados.Columns["Cargo"]!.Visible = false;

            if (dgvEmpleados.Columns.Contains("Ubigeo"))
                dgvEmpleados.Columns["Ubigeo"]!.Visible = false;

            if (dgvEmpleados.Columns.Contains("ReservaEmpleados"))
                dgvEmpleados.Columns["ReservaEmpleados"]!.Visible = false;

            if (dgvEmpleados.Columns.Contains("Reservas"))
                dgvEmpleados.Columns["Reservas"]!.Visible = false;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            EmpleadosMan02 frm = new EmpleadosMan02();

            if (frm.ShowDialog() == DialogResult.OK)
                ListarEmpleados();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvEmpleados.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un empleado.");
                return;
            }

            Empleados? empleado =
                dgvEmpleados.CurrentRow.DataBoundItem as Empleados;

            if (empleado == null)
                return;

            EmpleadosMan03 frm = new EmpleadosMan03(empleado);

            if (frm.ShowDialog() == DialogResult.OK)
                ListarEmpleados();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvEmpleados.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un empleado.");
                return;
            }

            Empleados? empleado =
                dgvEmpleados.CurrentRow.DataBoundItem as Empleados;

            if (empleado == null)
                return;

            DialogResult respuesta = MessageBox.Show(
                "¿Desea desactivar al empleado " +
                empleado.Nombres + " " + empleado.Apellidos + "?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                if (objEmpleadoBL.EliminarEmpleado(
                    empleado.EmpleadoId, Environment.UserName))
                {
                    MessageBox.Show("Empleado desactivado correctamente.");
                    ListarEmpleados();
                }
                else
                {
                    MessageBox.Show("No se pudo desactivar al empleado.");
                }
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
