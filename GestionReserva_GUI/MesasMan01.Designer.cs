namespace GestionReserva_GUI
{
    partial class MesasMan01
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
            lblTitulo = new Label();
            dgvMesas = new DataGridView();
            btnNuevo = new Button();
            btnActualizar = new Button();
            btnEliminar = new Button();
            btnCerrar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvMesas).BeginInit();
            SuspendLayout();
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(26, 11);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(275, 31);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Mantenimiento de Mesas";
            //
            // dgvMesas
            //
            dgvMesas.AllowUserToAddRows = false;
            dgvMesas.AllowUserToDeleteRows = false;
            dgvMesas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvMesas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMesas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMesas.Location = new Point(26, 54);
            dgvMesas.MultiSelect = false;
            dgvMesas.Name = "dgvMesas";
            dgvMesas.ReadOnly = true;
            dgvMesas.RowHeadersWidth = 51;
            dgvMesas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMesas.Size = new Size(887, 398);
            dgvMesas.TabIndex = 1;
            //
            // btnNuevo
            //
            btnNuevo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnNuevo.Location = new Point(88, 470);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(120, 32);
            btnNuevo.TabIndex = 2;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            //
            // btnActualizar
            //
            btnActualizar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnActualizar.Location = new Point(289, 470);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(120, 32);
            btnActualizar.TabIndex = 3;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            //
            // btnEliminar
            //
            btnEliminar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnEliminar.Location = new Point(491, 470);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(120, 32);
            btnEliminar.TabIndex = 4;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            //
            // btnCerrar
            //
            btnCerrar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnCerrar.Location = new Point(681, 470);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(120, 32);
            btnCerrar.TabIndex = 5;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            //
            // MesasMan01
            //
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(942, 517);
            Controls.Add(btnCerrar);
            Controls.Add(btnEliminar);
            Controls.Add(btnActualizar);
            Controls.Add(btnNuevo);
            Controls.Add(dgvMesas);
            Controls.Add(lblTitulo);
            Name = "MesasMan01";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Mantenimiento de Mesas";
            Load += MesasMan01_Load;
            ((System.ComponentModel.ISupportInitialize)dgvMesas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private DataGridView dgvMesas;
        private Button btnNuevo;
        private Button btnActualizar;
        private Button btnEliminar;
        private Button btnCerrar;
    }
}
