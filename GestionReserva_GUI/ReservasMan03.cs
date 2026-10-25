using System;
using System.Windows.Forms;
using GestionReserva_BE;
using GestionReserva_BL;

namespace GestionReserva_GUI
{
    public partial class ReservasMan03 : Form
    {
        ReservasBL objReservaBL = new ReservasBL();
        ReservasBE objReserva = new ReservasBE();

        public ReservasMan03(ReservasBE reserva)
        {
            InitializeComponent();

            objReserva = reserva;

            CargarCombos();
            CargarDatos();
        }

        // Se listan los registros activos más la relación actual de la reserva, aunque esté inactiva,
        // para conservarla. No se pueden elegir otros registros inactivos.
        private void CargarCombos()
        {
            cboCliente.DataSource = objReservaBL.ListarClientes(objReserva.ClienteId);
            cboCliente.DisplayMember = "NombreCompleto";
            cboCliente.ValueMember = "ClienteId";

            cboMesa.DataSource = objReservaBL.ListarMesas(objReserva.MesaId);
            cboMesa.DisplayMember = "DescripcionMesa";
            cboMesa.ValueMember = "MesaId";

            cboTurno.DataSource = objReservaBL.ListarTurnos(objReserva.TurnoId);
            cboTurno.DisplayMember = "DescripcionTurno";
            cboTurno.ValueMember = "TurnoId";

            cboEstadoReserva.DataSource = objReservaBL.ListarEstadosReserva();
            cboEstadoReserva.DisplayMember = "NombreEstado";
            cboEstadoReserva.ValueMember = "EstadoId";

            cboEmpleado.DataSource = objReservaBL.ListarEmpleados(objReserva.EmpleadoId);
            cboEmpleado.DisplayMember = "NombreCompleto";
            cboEmpleado.ValueMember = "EmpleadoId";
        }

        private void CargarDatos()
        {
            cboCliente.SelectedValue = objReserva.ClienteId;
            // DateOnly / TimeOnly se convierten a DateTime para los DateTimePicker.
            dtpFechaReserva.Value = objReserva.FechaReserva.ToDateTime(TimeOnly.MinValue);
            dtpHoraReserva.Value = DateTime.Today.Add(objReserva.HoraReserva.ToTimeSpan());
            nudNumeroPersonas.Value = objReserva.NumeroPersonas;
            cboMesa.SelectedValue = objReserva.MesaId;
            cboTurno.SelectedValue = objReserva.TurnoId;
            cboEstadoReserva.SelectedValue = objReserva.EstadoId;
            cboEmpleado.SelectedValue = objReserva.EmpleadoId;
            txtObservaciones.Text = objReserva.Observaciones;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
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

            // Se arma un objeto nuevo para no alterar la fila del listado si la actualización falla.
            ReservasBE objReservaActualizada = new ReservasBE();

            objReservaActualizada.ReservaId = objReserva.ReservaId;
            objReservaActualizada.ClienteId = Convert.ToInt32(cboCliente.SelectedValue);
            objReservaActualizada.FechaReserva = DateOnly.FromDateTime(dtpFechaReserva.Value);
            objReservaActualizada.HoraReserva = new TimeOnly(dtpHoraReserva.Value.Hour, dtpHoraReserva.Value.Minute);
            objReservaActualizada.NumeroPersonas = Convert.ToInt32(nudNumeroPersonas.Value);
            objReservaActualizada.MesaId = Convert.ToInt32(cboMesa.SelectedValue);
            objReservaActualizada.TurnoId = Convert.ToInt32(cboTurno.SelectedValue);
            objReservaActualizada.EstadoId = Convert.ToInt32(cboEstadoReserva.SelectedValue);
            objReservaActualizada.EmpleadoId = Convert.ToInt32(cboEmpleado.SelectedValue);
            objReservaActualizada.Observaciones = txtObservaciones.Text.Trim() == "" ? null : txtObservaciones.Text.Trim();
            objReservaActualizada.UsuarioUltModificacion = Environment.UserName;

            string mensaje = objReservaBL.ValidarReserva(objReservaActualizada);

            if (mensaje != "")
            {
                MessageBox.Show(mensaje);
                return;
            }

            if (objReservaBL.ActualizarReserva(objReservaActualizada))
            {
                MessageBox.Show("Reserva actualizada correctamente.");
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("No se pudo actualizar la reserva. Verifique los datos e intente nuevamente.");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
