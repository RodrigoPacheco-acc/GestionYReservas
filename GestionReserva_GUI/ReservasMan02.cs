using System;
using System.Windows.Forms;
using GestionReserva_BE;
using GestionReserva_BL;

namespace GestionReserva_GUI
{
    public partial class ReservasMan02 : Form
    {
        ReservasBL objReservaBL = new ReservasBL();

        public ReservasMan02()
        {
            InitializeComponent();
            CargarCombos();

            dtpFechaReserva.Value = DateTime.Today;
            dtpHoraReserva.Value = DateTime.Today.AddHours(DateTime.Now.Hour + 1);
        }

        // Al registrar solo se listan clientes, mesas, turnos y empleados activos (id actual = 0).
        private void CargarCombos()
        {
            cboCliente.DataSource = objReservaBL.ListarClientes(0);
            cboCliente.DisplayMember = "NombreCompleto";
            cboCliente.ValueMember = "ClienteId";
            cboCliente.SelectedIndex = -1;

            cboMesa.DataSource = objReservaBL.ListarMesas(0);
            cboMesa.DisplayMember = "DescripcionMesa";
            cboMesa.ValueMember = "MesaId";
            cboMesa.SelectedIndex = -1;

            cboTurno.DataSource = objReservaBL.ListarTurnos(0);
            cboTurno.DisplayMember = "DescripcionTurno";
            cboTurno.ValueMember = "TurnoId";
            cboTurno.SelectedIndex = -1;

            cboEstadoReserva.DataSource = objReservaBL.ListarEstadosReserva();
            cboEstadoReserva.DisplayMember = "NombreEstado";
            cboEstadoReserva.ValueMember = "EstadoId";
            cboEstadoReserva.SelectedIndex = 0;

            cboEmpleado.DataSource = objReservaBL.ListarEmpleados(0);
            cboEmpleado.DisplayMember = "NombreCompleto";
            cboEmpleado.ValueMember = "EmpleadoId";
            cboEmpleado.SelectedIndex = -1;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cboCliente.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un cliente.");
                cboCliente.Focus();
                return;
            }

            if (cboMesa.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione una mesa.");
                cboMesa.Focus();
                return;
            }

            if (cboTurno.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un turno.");
                cboTurno.Focus();
                return;
            }

            if (cboEstadoReserva.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione el estado de la reserva.");
                cboEstadoReserva.Focus();
                return;
            }

            if (cboEmpleado.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione el empleado que registra la reserva.");
                cboEmpleado.Focus();
                return;
            }

            ReservasBE objReserva = new ReservasBE();

            objReserva.ClienteId = Convert.ToInt32(cboCliente.SelectedValue);
            // DateTimePicker trabaja con DateTime; la columna es DATE y TIME (DateOnly / TimeOnly).
            // La hora se toma sin segundos para que la validación de cruce compare horas exactas.
            objReserva.FechaReserva = DateOnly.FromDateTime(dtpFechaReserva.Value);
            objReserva.HoraReserva = new TimeOnly(dtpHoraReserva.Value.Hour, dtpHoraReserva.Value.Minute);
            objReserva.NumeroPersonas = Convert.ToInt32(nudNumeroPersonas.Value);
            objReserva.MesaId = Convert.ToInt32(cboMesa.SelectedValue);
            objReserva.TurnoId = Convert.ToInt32(cboTurno.SelectedValue);
            objReserva.EstadoId = Convert.ToInt32(cboEstadoReserva.SelectedValue);
            objReserva.EmpleadoId = Convert.ToInt32(cboEmpleado.SelectedValue);
            objReserva.Observaciones = txtObservaciones.Text.Trim() == "" ? null : txtObservaciones.Text.Trim();
            objReserva.UsuarioCreacion = Environment.UserName;

            string mensaje = objReservaBL.ValidarReserva(objReserva);

            if (mensaje != "")
            {
                MessageBox.Show(mensaje);
                return;
            }

            if (objReservaBL.AgregarReserva(objReserva))
            {
                MessageBox.Show("Reserva registrada correctamente.");
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("No se pudo registrar la reserva. Verifique los datos e intente nuevamente.");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
