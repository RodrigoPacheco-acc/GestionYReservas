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
    }
}
