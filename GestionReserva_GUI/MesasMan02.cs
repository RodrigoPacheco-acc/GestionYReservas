using System;
using System.Windows.Forms;
using GestionReserva_BE;
using GestionReserva_BL;

namespace GestionReserva_GUI
{
    public partial class MesasMan02 : Form
    {
        MesasBL objMesaBL = new MesasBL();

        public MesasMan02()
        {
            InitializeComponent();
            CargarZonas();
            CargarEstadosMesa();
        }

        private void CargarZonas()
        {
            cboZona.DataSource = objMesaBL.ListarZonas();
            cboZona.DisplayMember = "NombreZona";
            cboZona.ValueMember = "ZonaId";
            cboZona.SelectedIndex = -1;
        }

        private void CargarEstadosMesa()
        {
            cboEstadoMesa.DataSource = objMesaBL.ListarEstadosMesa();
            cboEstadoMesa.SelectedItem = "Disponible";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cboZona.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione una zona.");
                cboZona.Focus();
                return;
            }

            if (cboEstadoMesa.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione el estado de la mesa.");
                cboEstadoMesa.Focus();
                return;
            }

            MesasBE objMesa = new MesasBE();

            objMesa.NumeroMesa = Convert.ToInt32(nudNumeroMesa.Value);
            objMesa.Capacidad = Convert.ToInt32(nudCapacidad.Value);
            objMesa.ZonaId = Convert.ToInt32(cboZona.SelectedValue);
            objMesa.EstadoMesa = cboEstadoMesa.SelectedItem?.ToString() ?? "";
            objMesa.UsuarioCreacion = Environment.UserName;

            string mensaje = objMesaBL.ValidarMesa(objMesa);

            if (mensaje != "")
            {
                MessageBox.Show(mensaje);
                return;
            }

            if (objMesaBL.ExisteNumeroMesa(objMesa.NumeroMesa, 0))
            {
                MessageBox.Show("Ya existe una mesa activa con el número " + objMesa.NumeroMesa + ".");
                nudNumeroMesa.Focus();
                return;
            }

            if (objMesaBL.AgregarMesa(objMesa))
            {
                MessageBox.Show("Mesa registrada correctamente.");
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("No se pudo registrar la mesa. Verifique los datos e intente nuevamente.");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
