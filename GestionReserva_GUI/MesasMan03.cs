using System;
using System.Windows.Forms;
using GestionReserva_BE;
using GestionReserva_BL;

namespace GestionReserva_GUI
{
    public partial class MesasMan03 : Form
    {
        MesasBL objMesaBL = new MesasBL();
        MesasBE objMesa = new MesasBE();

        public MesasMan03(MesasBE mesa)
        {
            InitializeComponent();

            objMesa = mesa;

            CargarZonas();
            CargarEstadosMesa();
            CargarDatos();
        }

        private void CargarZonas()
        {
            cboZona.DataSource = objMesaBL.ListarZonas();
            cboZona.DisplayMember = "NombreZona";
            cboZona.ValueMember = "ZonaId";
        }

        private void CargarEstadosMesa()
        {
            cboEstadoMesa.DataSource = objMesaBL.ListarEstadosMesa();
        }

        private void CargarDatos()
        {
            nudNumeroMesa.Value = objMesa.NumeroMesa;
            nudCapacidad.Value = objMesa.Capacidad;
            cboZona.SelectedValue = objMesa.ZonaId;
            cboEstadoMesa.SelectedItem = objMesa.EstadoMesa;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
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

            // Se arma un objeto nuevo para no alterar la fila del listado si la actualización falla.
            MesasBE objMesaActualizada = new MesasBE();

            objMesaActualizada.MesaId = objMesa.MesaId;
            objMesaActualizada.NumeroMesa = Convert.ToInt32(nudNumeroMesa.Value);
            objMesaActualizada.Capacidad = Convert.ToInt32(nudCapacidad.Value);
            objMesaActualizada.ZonaId = Convert.ToInt32(cboZona.SelectedValue);
            objMesaActualizada.EstadoMesa = cboEstadoMesa.SelectedItem?.ToString() ?? "";
            objMesaActualizada.UsuarioUltModificacion = Environment.UserName;

            string mensaje = objMesaBL.ValidarMesa(objMesaActualizada);

            if (mensaje != "")
            {
                MessageBox.Show(mensaje);
                return;
            }

            if (objMesaActualizada.NumeroMesa != objMesa.NumeroMesa
                && objMesaBL.ExisteNumeroMesa(objMesaActualizada.NumeroMesa, objMesaActualizada.MesaId))
            {
                MessageBox.Show("Ya existe otra mesa activa con el número " + objMesaActualizada.NumeroMesa + ".");
                nudNumeroMesa.Focus();
                return;
            }

            if (objMesaBL.ActualizarMesa(objMesaActualizada))
            {
                MessageBox.Show("Mesa actualizada correctamente.");
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("No se pudo actualizar la mesa. Verifique que la mesa y la zona sigan activas e intente nuevamente.");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
