using GestionReserva_BE;
using GestionReserva_BL;
using System;
using System.Windows.Forms;

namespace GestionReserva_GUI
{
    public partial class MesasMan01 : Form
    {
        MesasBL objMesaBL = new MesasBL();

        public MesasMan01()
        {
            InitializeComponent();
        }

        private void MesasMan01_Load(object sender, EventArgs e)
        {
            ListarMesas();
        }

        private void ListarMesas()
        {
            dgvMesas.DataSource = objMesaBL.ListarMesas();

            // La zona se muestra por su nombre y el listado solo contiene mesas activas.
            dgvMesas.Columns["ZonaId"]!.Visible = false;
            dgvMesas.Columns["Estado"]!.Visible = false;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            MesasMan02 frmRegistro = new MesasMan02();

            if (frmRegistro.ShowDialog() == DialogResult.OK)
            {
                ListarMesas();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvMesas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una mesa para actualizar.");
                return;
            }

            MesasBE? objMesa = dgvMesas.CurrentRow.DataBoundItem as MesasBE;

            if (objMesa == null)
            {
                MessageBox.Show("No se pudo obtener la mesa seleccionada.");
                return;
            }

            MesasMan03 frmActualizar = new MesasMan03(objMesa);

            if (frmActualizar.ShowDialog() == DialogResult.OK)
            {
                ListarMesas();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvMesas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una mesa para eliminar.");
                return;
            }

            MesasBE? objMesa = dgvMesas.CurrentRow.DataBoundItem as MesasBE;

            if (objMesa == null)
            {
                MessageBox.Show("No se pudo obtener la mesa seleccionada.");
                return;
            }

            if (objMesaBL.TieneReservasVigentes(objMesa.MesaId))
            {
                MessageBox.Show("No se puede eliminar la mesa " + objMesa.NumeroMesa + " porque tiene reservas vigentes.");
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Está seguro de eliminar la mesa seleccionada: " + objMesa.NumeroMesa + " (" + objMesa.NombreZona + ")?",
                "Eliminar Mesa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                if (objMesaBL.EliminarMesa(objMesa.MesaId, Environment.UserName))
                {
                    MessageBox.Show("Mesa eliminada correctamente.");
                    ListarMesas();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar la mesa. Es posible que ya no exista o que tenga reservas vigentes.");
                }
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
