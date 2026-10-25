namespace GestionReserva_GUI
{
    partial class MenuPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            menuPrincipalToolStripMenuItem = new ToolStripMenuItem();
            clientesToolStripMenuItem = new ToolStripMenuItem();
            empleadosToolStripMenuItem1 = new ToolStripMenuItem();
            gestionarEmpleadosToolStripMenuItem = new ToolStripMenuItem();
            reservasToolStripMenuItem1 = new ToolStripMenuItem();
            gestionarReservasToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { menuPrincipalToolStripMenuItem, empleadosToolStripMenuItem1, reservasToolStripMenuItem1 });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1384, 24);
            menuStrip1.TabIndex = 9;
            menuStrip1.Text = "menuStrip1";
            // 
            // menuPrincipalToolStripMenuItem
            // 
            menuPrincipalToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { clientesToolStripMenuItem });
            menuPrincipalToolStripMenuItem.Name = "menuPrincipalToolStripMenuItem";
            menuPrincipalToolStripMenuItem.Size = new Size(61, 20);
            menuPrincipalToolStripMenuItem.Text = "Clientes";
            // 
            // clientesToolStripMenuItem
            // 
            clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            clientesToolStripMenuItem.Size = new Size(167, 22);
            clientesToolStripMenuItem.Text = "Gestionar clientes";
            clientesToolStripMenuItem.Click += clientesToolStripMenuItem_Click;
            // 
            // empleadosToolStripMenuItem1
            // 
            empleadosToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { gestionarEmpleadosToolStripMenuItem });
            empleadosToolStripMenuItem1.Name = "empleadosToolStripMenuItem1";
            empleadosToolStripMenuItem1.Size = new Size(77, 20);
            empleadosToolStripMenuItem1.Text = "Empleados";
            // 
            // gestionarEmpleadosToolStripMenuItem
            // 
            gestionarEmpleadosToolStripMenuItem.Name = "gestionarEmpleadosToolStripMenuItem";
            gestionarEmpleadosToolStripMenuItem.Size = new Size(185, 22);
            gestionarEmpleadosToolStripMenuItem.Text = "Gestionar empleados";
            gestionarEmpleadosToolStripMenuItem.Click += empleadosToolStripMenuItem_Click;
            // 
            // reservasToolStripMenuItem1
            // 
            reservasToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { gestionarReservasToolStripMenuItem });
            reservasToolStripMenuItem1.Name = "reservasToolStripMenuItem1";
            reservasToolStripMenuItem1.Size = new Size(64, 20);
            reservasToolStripMenuItem1.Text = "Reservas";
            // 
            // gestionarReservasToolStripMenuItem
            // 
            gestionarReservasToolStripMenuItem.Name = "gestionarReservasToolStripMenuItem";
            gestionarReservasToolStripMenuItem.Size = new Size(169, 22);
            gestionarReservasToolStripMenuItem.Text = "Gestionar reservas";
            gestionarReservasToolStripMenuItem.Click += reservasToolStripMenuItem_Click;
            // 
            // MenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1384, 811);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Name = "MenuPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Menú Principal";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip menuStrip1;
        private ToolStripMenuItem menuPrincipalToolStripMenuItem;
        private ToolStripMenuItem clientesToolStripMenuItem;
        private ToolStripMenuItem empleadosToolStripMenuItem1;
        private ToolStripMenuItem gestionarEmpleadosToolStripMenuItem;
        private ToolStripMenuItem reservasToolStripMenuItem1;
        private ToolStripMenuItem gestionarReservasToolStripMenuItem;
    }
}