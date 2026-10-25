using System;
using System.Windows.Forms;
using GestionReserva_BE;
using GestionReserva_BL;

namespace GestionReserva_GUI
{
    public partial class PlatosMan03 : Form
    {
        PlatosBL objPlatoBL = new PlatosBL();
        PlatosBE objPlato = new PlatosBE();

        public PlatosMan03(PlatosBE plato)
        {
            InitializeComponent();

            objPlato = plato;

            CargarCategorias();
            CargarDatos();
        }

        private void CargarCategorias()
        {
            cboCategoria.DataSource = objPlatoBL.ListarCategorias();
            cboCategoria.DisplayMember = "NombreCategoria";
            cboCategoria.ValueMember = "CategoriaId";
        }

        private void CargarDatos()
        {
            txtNombrePlato.Text = objPlato.NombrePlato;
            txtDescripcion.Text = objPlato.Descripcion;
            cboCategoria.SelectedValue = objPlato.CategoriaId;
            nudTiempoPreparacion.Value = objPlato.TiempoPreparacionMinutos ?? 0;
            chkDisponible.Checked = objPlato.Disponible;
            nudPrecioReferencial.Value = objPlato.PrecioReferencial ?? 0;
            nudEstado.Value = objPlato.Estado;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (txtNombrePlato.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el nombre del plato.");
                txtNombrePlato.Focus();
                return;
            }

            if (cboCategoria.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione una categoría.");
                cboCategoria.Focus();
                return;
            }

            objPlato.NombrePlato = txtNombrePlato.Text.Trim();
            objPlato.Descripcion = txtDescripcion.Text.Trim();
            objPlato.CategoriaId = Convert.ToInt32(cboCategoria.SelectedValue);
            objPlato.TiempoPreparacionMinutos = Convert.ToInt32(nudTiempoPreparacion.Value);
            objPlato.Disponible = chkDisponible.Checked;
            objPlato.PrecioReferencial = nudPrecioReferencial.Value;
            objPlato.UsuarioUltModificacion = Environment.UserName;
            objPlato.Estado = Convert.ToInt32(nudEstado.Value);

            if (objPlatoBL.ActualizarPlato(objPlato))
            {
                MessageBox.Show("Plato actualizado correctamente.");
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("No se pudo actualizar el plato. Verifique los datos e intente nuevamente.");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

