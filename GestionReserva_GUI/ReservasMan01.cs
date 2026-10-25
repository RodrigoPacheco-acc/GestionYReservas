using GestionReserva_BE;
using GestionReserva_BL;
using System;
using System.Windows.Forms;

namespace GestionReserva_GUI
{
    public partial class ReservasMan01 : Form
    {
        ReservasBL objReservaBL = new ReservasBL();

        public ReservasMan01()
        {
            InitializeComponent();
        }

        private void ReservasMan01_Load(object sender, EventArgs e)
        {
            ListarReservas();
        }

        private void ListarReservas()
        {
            dgvReservas.DataSource = objReservaBL.ListarReservas();

            // Las relaciones se muestran por su nombre y el listado solo contiene reservas activas.
            dgvReservas.Columns["ClienteId"]!.Visible = false;
            dgvReservas.Columns["MesaId"]!.Visible = false;
            dgvReservas.Columns["TurnoId"]!.Visible = false;
            dgvReservas.Columns["EstadoId"]!.Visible = false;
            dgvReservas.Columns["EmpleadoId"]!.Visible = false;
            dgvReservas.Columns["Estado"]!.Visible = false;

            dgvReservas.Columns["FechaReserva"]!.DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvReservas.Columns["HoraReserva"]!.DefaultCellStyle.Format = "HH:mm";
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            ReservasMan02 frmRegistro = new ReservasMan02();

            if (frmRegistro.ShowDialog() == DialogResult.OK)
            {
                ListarReservas();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvReservas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una reserva para actualizar.");
                return;
            }

            ReservasBE? objReserva = dgvReservas.CurrentRow.DataBoundItem as ReservasBE;

            if (objReserva == null)
            {
                MessageBox.Show("No se pudo obtener la reserva seleccionada.");
                return;
            }

            ReservasMan03 frmActualizar = new ReservasMan03(objReserva);

            if (frmActualizar.ShowDialog() == DialogResult.OK)
            {
                ListarReservas();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvReservas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una reserva para eliminar.");
                return;
            }

            ReservasBE? objReserva = dgvReservas.CurrentRow.DataBoundItem as ReservasBE;

            if (objReserva == null)
            {
                MessageBox.Show("No se pudo obtener la reserva seleccionada.");
                return;
            }

            if (objReservaBL.TienePedidosActivos(objReserva.ReservaId))
            {
                MessageBox.Show("No se puede eliminar la reserva de " + objReserva.NombreCliente + " porque tiene pedidos registrados.");
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Está seguro de eliminar la reserva seleccionada: " + objReserva.NombreCliente + ", "
                    + objReserva.FechaReserva.ToString("dd/MM/yyyy") + " " + objReserva.HoraReserva.ToString("HH:mm")
                    + ", mesa " + objReserva.NumeroMesa + "?",
                "Eliminar Reserva",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                if (objReservaBL.EliminarReserva(objReserva.ReservaId, Environment.UserName))
                {
                    MessageBox.Show("Reserva eliminada correctamente.");
                    ListarReservas();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar la reserva. Es posible que ya no exista o que tenga pedidos registrados.");
                }
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
