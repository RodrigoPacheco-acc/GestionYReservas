namespace GestionReserva_GUI
{
    partial class ClientesMan02
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
            lblNombres = new Label();
            txtNombres = new TextBox();
            txtApellidos = new TextBox();
            lblApellidos = new Label();
            txtCorreo = new TextBox();
            lblCorreo = new Label();
            txtTelefono = new TextBox();
            lblTelefono = new Label();
            lblCategoria = new Label();
            lblSexo = new Label();
            lblFechaNacimiento = new Label();
            dtpFechaNacimiento = new DateTimePicker();
            cboSexo = new ComboBox();
            cboCategoria = new ComboBox();
            btnGuardar = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblTitulo.Location = new Point(254, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(157, 21);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Registro de Clientes";
            // 
            // lblNombres
            // 
            lblNombres.AutoSize = true;
            lblNombres.Location = new Point(30, 54);
            lblNombres.Name = "lblNombres";
            lblNombres.Size = new Size(59, 15);
            lblNombres.TabIndex = 1;
            lblNombres.Text = "Nombres:";
            // 
            // txtNombres
            // 
            txtNombres.Location = new Point(198, 52);
            txtNombres.Name = "txtNombres";
            txtNombres.Size = new Size(350, 23);
            txtNombres.TabIndex = 2;
            // 
            // txtApellidos
            // 
            txtApellidos.Location = new Point(198, 92);
            txtApellidos.Name = "txtApellidos";
            txtApellidos.Size = new Size(350, 23);
            txtApellidos.TabIndex = 4;
            // 
            // lblApellidos
            // 
            lblApellidos.AutoSize = true;
            lblApellidos.Location = new Point(30, 94);
            lblApellidos.Name = "lblApellidos";
            lblApellidos.Size = new Size(59, 15);
            lblApellidos.TabIndex = 3;
            lblApellidos.Text = "Apellidos:";
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(198, 172);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(350, 23);
            txtCorreo.TabIndex = 8;
            // 
            // lblCorreo
            // 
            lblCorreo.AutoSize = true;
            lblCorreo.Location = new Point(30, 173);
            lblCorreo.Name = "lblCorreo";
            lblCorreo.Size = new Size(46, 15);
            lblCorreo.TabIndex = 7;
            lblCorreo.Text = "Correo:";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(198, 131);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(192, 23);
            txtTelefono.TabIndex = 6;
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(30, 134);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(56, 15);
            lblTelefono.TabIndex = 5;
            lblTelefono.Text = "Teléfono:";
            // 
            // lblCategoria
            // 
            lblCategoria.AutoSize = true;
            lblCategoria.Location = new Point(30, 292);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(61, 15);
            lblCategoria.TabIndex = 13;
            lblCategoria.Text = "Categoría:";
            // 
            // lblSexo
            // 
            lblSexo.AutoSize = true;
            lblSexo.Location = new Point(30, 253);
            lblSexo.Name = "lblSexo";
            lblSexo.Size = new Size(34, 15);
            lblSexo.TabIndex = 11;
            lblSexo.Text = "Sexo:";
            // 
            // lblFechaNacimiento
            // 
            lblFechaNacimiento.AutoSize = true;
            lblFechaNacimiento.Location = new Point(30, 213);
            lblFechaNacimiento.Name = "lblFechaNacimiento";
            lblFechaNacimiento.Size = new Size(120, 15);
            lblFechaNacimiento.TabIndex = 9;
            lblFechaNacimiento.Text = "Fecha de nacimiento:";
            // 
            // dtpFechaNacimiento
            // 
            dtpFechaNacimiento.CustomFormat = "dd/MM/yyyy";
            dtpFechaNacimiento.Format = DateTimePickerFormat.Custom;
            dtpFechaNacimiento.Location = new Point(198, 211);
            dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            dtpFechaNacimiento.Size = new Size(132, 23);
            dtpFechaNacimiento.TabIndex = 17;
            dtpFechaNacimiento.Value = new DateTime(2026, 10, 19, 12, 39, 0, 0);
            // 
            // cboSexo
            // 
            cboSexo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSexo.FormattingEnabled = true;
            cboSexo.Location = new Point(198, 250);
            cboSexo.Name = "cboSexo";
            cboSexo.Size = new Size(71, 23);
            cboSexo.TabIndex = 18;
            // 
            // cboCategoria
            // 
            cboCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCategoria.FormattingEnabled = true;
            cboCategoria.Location = new Point(198, 290);
            cboCategoria.Name = "cboCategoria";
            cboCategoria.Size = new Size(132, 23);
            cboCategoria.TabIndex = 19;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(452, 326);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(102, 23);
            btnGuardar.TabIndex = 20;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(578, 326);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(107, 23);
            btnCancelar.TabIndex = 21;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // ClientesMan02
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 367);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(cboCategoria);
            Controls.Add(cboSexo);
            Controls.Add(dtpFechaNacimiento);
            Controls.Add(lblCategoria);
            Controls.Add(lblSexo);
            Controls.Add(lblFechaNacimiento);
            Controls.Add(txtCorreo);
            Controls.Add(lblCorreo);
            Controls.Add(txtTelefono);
            Controls.Add(lblTelefono);
            Controls.Add(txtApellidos);
            Controls.Add(lblApellidos);
            Controls.Add(txtNombres);
            Controls.Add(lblNombres);
            Controls.Add(lblTitulo);
            Name = "ClientesMan02";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registro de Cliente";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblNombres;
        private TextBox txtNombres;
        private TextBox txtApellidos;
        private Label lblApellidos;
        private TextBox txtCorreo;
        private Label lblCorreo;
        private TextBox txtTelefono;
        private Label lblTelefono;
        private Label lblCategoria;
        private Label lblSexo;
        private Label lblFechaNacimiento;
        private DateTimePicker dtpFechaNacimiento;
        private ComboBox cboSexo;
        private ComboBox cboCategoria;
        private Button btnGuardar;
        private Button btnCancelar;
    }
}