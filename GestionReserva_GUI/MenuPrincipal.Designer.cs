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
            label1 = new Label();
            label2 = new Label();
            btnMesas = new Button();
            btnPedidos = new Button();
            btnPlatos = new Button();
            btnReservas = new Button();
            btnClientes = new Button();
            btnReportes = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 25F);
            label1.Location = new Point(263, 40);
            label1.Name = "label1";
            label1.Size = new Size(243, 46);
            label1.TabIndex = 0;
            label1.Text = "Menu Principal";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Click += this.label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.Location = new Point(308, 97);
            label2.Name = "label2";
            label2.Size = new Size(149, 19);
            label2.TabIndex = 1;
            label2.Text = "Gestion de restaurante";
            // 
            // btnMesas
            // 
            btnMesas.Font = new Font("Segoe UI", 12F);
            btnMesas.Location = new Point(193, 146);
            btnMesas.Name = "btnMesas";
            btnMesas.Size = new Size(163, 57);
            btnMesas.TabIndex = 2;
            btnMesas.Text = "Mesas";
            btnMesas.UseVisualStyleBackColor = true;
            btnMesas.Click += this.button1_Click;
            // 
            // btnPedidos
            // 
            btnPedidos.Font = new Font("Segoe UI", 12F);
            btnPedidos.Location = new Point(193, 235);
            btnPedidos.Name = "btnPedidos";
            btnPedidos.Size = new Size(163, 57);
            btnPedidos.TabIndex = 3;
            btnPedidos.Text = "Pedidos";
            btnPedidos.UseVisualStyleBackColor = true;
            // 
            // btnPlatos
            // 
            btnPlatos.Font = new Font("Segoe UI", 12F);
            btnPlatos.Location = new Point(193, 328);
            btnPlatos.Name = "btnPlatos";
            btnPlatos.Size = new Size(163, 57);
            btnPlatos.TabIndex = 4;
            btnPlatos.Text = "Platos";
            btnPlatos.UseVisualStyleBackColor = true;
            // 
            // btnReservas
            // 
            btnReservas.Font = new Font("Segoe UI", 12F);
            btnReservas.Location = new Point(410, 146);
            btnReservas.Name = "btnReservas";
            btnReservas.Size = new Size(163, 57);
            btnReservas.TabIndex = 5;
            btnReservas.Text = "Reservas";
            btnReservas.UseVisualStyleBackColor = true;
            // 
            // btnClientes
            // 
            btnClientes.Font = new Font("Segoe UI", 12F);
            btnClientes.Location = new Point(410, 235);
            btnClientes.Name = "btnClientes";
            btnClientes.Size = new Size(163, 57);
            btnClientes.TabIndex = 6;
            btnClientes.Text = "Clientes";
            btnClientes.UseVisualStyleBackColor = true;
            btnClientes.Click += this.button5_Click;
            // 
            // btnReportes
            // 
            btnReportes.Font = new Font("Segoe UI", 12F);
            btnReportes.Location = new Point(410, 328);
            btnReportes.Name = "btnReportes";
            btnReportes.Size = new Size(163, 57);
            btnReportes.TabIndex = 7;
            btnReportes.Text = "Reportes";
            btnReportes.UseVisualStyleBackColor = true;
            // 
            // MenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnReportes);
            Controls.Add(btnClientes);
            Controls.Add(btnReservas);
            Controls.Add(btnPlatos);
            Controls.Add(btnPedidos);
            Controls.Add(btnMesas);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "MenuPrincipal";
            Text = "Form2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Button btnMesas;
        private Button btnPedidos;
        private Button btnPlatos;
        private Button btnReservas;
        private Button btnClientes;
        private Button btnReportes;
    }
}