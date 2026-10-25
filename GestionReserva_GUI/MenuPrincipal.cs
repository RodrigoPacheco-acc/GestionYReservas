using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GestionReserva_GUI
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void btnPlatos_Click(object sender, EventArgs e)
        {
            PlatosMan01 objPlato = new PlatosMan01();
            objPlato.ShowDialog();
        }

        private void btnMesas_Click(object sender, EventArgs e)
        {
            MesasMan01 objMesa = new MesasMan01();
            objMesa.ShowDialog();
        }

        private void btnReservas_Click(object sender, EventArgs e)
        {
            ReservasMan01 objReserva = new ReservasMan01();
            objReserva.ShowDialog();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            ClientesMan01 frm = new ClientesMan01();
            frm.ShowDialog();
        }


        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult respuesta = MessageBox.Show(
                    "¿Está seguro de que desea cerrar la aplicación?",
                    "Cerrar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (respuesta == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
            }

            base.OnFormClosing(e);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MesasMan01 formulario = new MesasMan01();
            formulario.MdiParent = this;
            formulario.Show();
        }

        private void platosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlatosMan01 formulario = new PlatosMan01();
            formulario.MdiParent = this;
            formulario.Show();
        }

        private void reservasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReservasMan01 formulario = new ReservasMan01();
            formulario.MdiParent = this;
            formulario.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClientesMan01 formulario = new ClientesMan01();
            formulario.MdiParent = this;
            formulario.Show();
        }

        private void empleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmpleadosMan01 formulario = new EmpleadosMan01();
            formulario.MdiParent = this;
            formulario.Show();
        }
    }
}