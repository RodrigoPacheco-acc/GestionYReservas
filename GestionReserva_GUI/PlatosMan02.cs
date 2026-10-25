using System;
using System.Windows.Forms;
using GestionReserva_BE;
using GestionReserva_BL;

namespace GestionReserva_GUI
{
    public partial class PlatosMan02 : Form
    {
        PlatosBL objPlatoBL = new PlatosBL();

        public PlatosMan02()
        {
            InitializeComponent();
            CargarCategorias();
        }

        private void CargarCategorias()
        {
            cboCategoria.DataSource = objPlatoBL.ListarCategorias();
            cboCategoria.DisplayMember = "NombreCategoria";
            cboCategoria.ValueMember = "CategoriaId";
            cboCategoria.SelectedIndex = -1;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
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

            PlatosBE objPlato = new PlatosBE();

            objPlato.NombrePlato = txtNombrePlato.Text.Trim();
            objPlato.Descripcion = txtDescripcion.Text.Trim();
            objPlato.CategoriaId = Convert.ToInt32(cboCategoria.SelectedValue);
            objPlato.TiempoPreparacionMinutos = Convert.ToInt32(nudTiempoPreparacion.Value);
            objPlato.Disponible = chkDisponible.Checked;
            objPlato.PrecioReferencial = nudPrecioReferencial.Value;
            objPlato.UsuarioCreacion = Environment.UserName;
            objPlato.Estado = Convert.ToInt32(nudEstado.Value);

            if (objPlatoBL.AgregarPlato(objPlato))
            {
                MessageBox.Show("Plato registrado correctamente.");
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("No se pudo registrar el plato. Verifique los datos e intente nuevamente.");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

