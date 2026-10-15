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
    }
}
