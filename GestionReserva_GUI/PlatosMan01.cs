using GestionReserva_BE;
using GestionReserva_BL;
using System;
using System.Windows.Forms;

namespace GestionReserva_GUI
{
    public partial class PlatosMan01 : Form
    {
        PlatosBL objPlatoBL = new PlatosBL();

        public PlatosMan01()
        {
            InitializeComponent();
        }

        private void PlatosMan01_Load(object sender, EventArgs e)
        {
            ListarPlatos();
        }

        private void ListarPlatos()
        {
            dgvPlatos.DataSource = objPlatoBL.ListarPlatos();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            PlatosMan02 frmRegistro = new PlatosMan02();

            if (frmRegistro.ShowDialog() == DialogResult.OK)
            {
                ListarPlatos();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvPlatos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un plato para actualizar.");
                return;
            }

            PlatosBE objPlato = dgvPlatos.CurrentRow.DataBoundItem as PlatosBE;

            if (objPlato == null)
            {
                MessageBox.Show("No se pudo obtener el plato seleccionado.");
                return;
            }

            PlatosMan03 frmActualizar = new PlatosMan03(objPlato);

            if (frmActualizar.ShowDialog() == DialogResult.OK)
            {
                ListarPlatos();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvPlatos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un plato para eliminar.");
                return;
            }

            PlatosBE objPlato = dgvPlatos.CurrentRow.DataBoundItem as PlatosBE;

            if (objPlato == null)
            {
                MessageBox.Show("No se pudo obtener el plato seleccionado.");
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Está seguro de eliminar el plato seleccionado: " + objPlato.NombrePlato + "?",
                "Eliminar Plato",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                if (objPlatoBL.EliminarPlato(objPlato.PlatoId))
                {
                    MessageBox.Show("Plato eliminado correctamente.");
                    ListarPlatos();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el plato. Es posible que esté relacionado con otros registros.");
                }
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }

    }
}

