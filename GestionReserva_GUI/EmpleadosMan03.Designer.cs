namespace GestionReserva_GUI
{
    partial class EmpleadosMan03
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
            txtUbigeoId = new TextBox();
            lblUbigeoId = new Label();
            txtDireccion = new TextBox();
            lblDireccion = new Label();
            dtpFechaContratacion = new DateTimePicker();
            lblFechaContratacion = new Label();
            txtDni = new TextBox();
            lblDNI = new Label();
            btnCancelar = new Button();
            btnGuardar = new Button();
            cboCargo = new ComboBox();
            cboSexo = new ComboBox();
            dtpFechaNacimiento = new DateTimePicker();
            lblCargo = new Label();
            lblSexo = new Label();
            lblFechaNacimiento = new Label();
            txtEmail = new TextBox();
            lblEmail = new Label();
            txtTelefono = new TextBox();
            lblTelefono = new Label();
            txtApellidos = new TextBox();
            lblApellidos = new Label();
            txtNombres = new TextBox();
            lblNombres = new Label();
            lblTitulo = new Label();
            SuspendLayout();
            // 
            // txtUbigeoId
            // 
            txtUbigeoId.Location = new Point(199, 449);
            txtUbigeoId.Name = "txtUbigeoId";
            txtUbigeoId.Size = new Size(71, 23);
            txtUbigeoId.TabIndex = 71;
            // 
            // lblUbigeoId
            // 
            lblUbigeoId.AutoSize = true;
            lblUbigeoId.Location = new Point(31, 451);
            lblUbigeoId.Name = "lblUbigeoId";
            lblUbigeoId.Size = new Size(106, 15);
            lblUbigeoId.TabIndex = 70;
            lblUbigeoId.Text = "Código de Ubigeo:";
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(199, 409);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(192, 23);
            txtDireccion.TabIndex = 69;
            // 
            // lblDireccion
            // 
            lblDireccion.AutoSize = true;
            lblDireccion.Location = new Point(31, 411);
            lblDireccion.Name = "lblDireccion";
            lblDireccion.Size = new Size(60, 15);
            lblDireccion.TabIndex = 68;
            lblDireccion.Text = "Dirección:";
            // 
            // dtpFechaContratacion
            // 
            dtpFechaContratacion.CustomFormat = "dd/MM/yyyy";
            dtpFechaContratacion.Format = DateTimePickerFormat.Custom;
            dtpFechaContratacion.Location = new Point(199, 251);
            dtpFechaContratacion.Name = "dtpFechaContratacion";
            dtpFechaContratacion.Size = new Size(132, 23);
            dtpFechaContratacion.TabIndex = 67;
            dtpFechaContratacion.Value = new DateTime(2026, 10, 19, 12, 39, 0, 0);
            // 
            // lblFechaContratacion
            // 
            lblFechaContratacion.AutoSize = true;
            lblFechaContratacion.Location = new Point(31, 252);
            lblFechaContratacion.Name = "lblFechaContratacion";
            lblFechaContratacion.Size = new Size(127, 15);
            lblFechaContratacion.TabIndex = 66;
            lblFechaContratacion.Text = "Fecha de contratación:";
            // 
            // txtDni
            // 
            txtDni.Location = new Point(199, 131);
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(192, 23);
            txtDni.TabIndex = 65;
            // 
            // lblDNI
            // 
            lblDNI.AutoSize = true;
            lblDNI.Location = new Point(31, 134);
            lblDNI.Name = "lblDNI";
            lblDNI.Size = new Size(30, 15);
            lblDNI.TabIndex = 64;
            lblDNI.Text = "DNI:";
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(585, 486);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(107, 23);
            btnCancelar.TabIndex = 63;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(459, 486);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(102, 23);
            btnGuardar.TabIndex = 62;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // cboCargo
            // 
            cboCargo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCargo.FormattingEnabled = true;
            cboCargo.Location = new Point(199, 329);
            cboCargo.Name = "cboCargo";
            cboCargo.Size = new Size(132, 23);
            cboCargo.TabIndex = 61;
            // 
            // cboSexo
            // 
            cboSexo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSexo.FormattingEnabled = true;
            cboSexo.Location = new Point(199, 369);
            cboSexo.Name = "cboSexo";
            cboSexo.Size = new Size(71, 23);
            cboSexo.TabIndex = 60;
            // 
            // dtpFechaNacimiento
            // 
            dtpFechaNacimiento.CustomFormat = "dd/MM/yyyy";
            dtpFechaNacimiento.Format = DateTimePickerFormat.Custom;
            dtpFechaNacimiento.Location = new Point(199, 290);
            dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            dtpFechaNacimiento.Size = new Size(132, 23);
            dtpFechaNacimiento.TabIndex = 59;
            dtpFechaNacimiento.Value = new DateTime(2026, 10, 19, 12, 39, 0, 0);
            // 
            // lblCargo
            // 
            lblCargo.AutoSize = true;
            lblCargo.Location = new Point(31, 332);
            lblCargo.Name = "lblCargo";
            lblCargo.Size = new Size(42, 15);
            lblCargo.TabIndex = 58;
            lblCargo.Text = "Cargo:";
            // 
            // lblSexo
            // 
            lblSexo.AutoSize = true;
            lblSexo.Location = new Point(31, 371);
            lblSexo.Name = "lblSexo";
            lblSexo.Size = new Size(34, 15);
            lblSexo.TabIndex = 57;
            lblSexo.Text = "Sexo:";
            // 
            // lblFechaNacimiento
            // 
            lblFechaNacimiento.AutoSize = true;
            lblFechaNacimiento.Location = new Point(31, 292);
            lblFechaNacimiento.Name = "lblFechaNacimiento";
            lblFechaNacimiento.Size = new Size(120, 15);
            lblFechaNacimiento.TabIndex = 56;
            lblFechaNacimiento.Text = "Fecha de nacimiento:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(199, 211);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(350, 23);
            txtEmail.TabIndex = 55;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(31, 212);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(39, 15);
            lblEmail.TabIndex = 54;
            lblEmail.Text = "Email:";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(199, 171);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(192, 23);
            txtTelefono.TabIndex = 53;
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(31, 174);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(56, 15);
            lblTelefono.TabIndex = 52;
            lblTelefono.Text = "Teléfono:";
            // 
            // txtApellidos
            // 
            txtApellidos.Location = new Point(199, 92);
            txtApellidos.Name = "txtApellidos";
            txtApellidos.Size = new Size(350, 23);
            txtApellidos.TabIndex = 51;
            // 
            // lblApellidos
            // 
            lblApellidos.AutoSize = true;
            lblApellidos.Location = new Point(31, 94);
            lblApellidos.Name = "lblApellidos";
            lblApellidos.Size = new Size(59, 15);
            lblApellidos.TabIndex = 50;
            lblApellidos.Text = "Apellidos:";
            // 
            // txtNombres
            // 
            txtNombres.Location = new Point(199, 52);
            txtNombres.Name = "txtNombres";
            txtNombres.Size = new Size(350, 23);
            txtNombres.TabIndex = 49;
            // 
            // lblNombres
            // 
            lblNombres.AutoSize = true;
            lblNombres.Location = new Point(31, 54);
            lblNombres.Name = "lblNombres";
            lblNombres.Size = new Size(59, 15);
            lblNombres.TabIndex = 48;
            lblNombres.Text = "Nombres:";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblTitulo.Location = new Point(255, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(158, 21);
            lblTitulo.TabIndex = 47;
            lblTitulo.Text = "Actualizar Empleado";
            // 
            // EmpleadosMan03
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(704, 521);
            Controls.Add(txtUbigeoId);
            Controls.Add(lblUbigeoId);
            Controls.Add(txtDireccion);
            Controls.Add(lblDireccion);
            Controls.Add(dtpFechaContratacion);
            Controls.Add(lblFechaContratacion);
            Controls.Add(txtDni);
            Controls.Add(lblDNI);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(cboCargo);
            Controls.Add(cboSexo);
            Controls.Add(dtpFechaNacimiento);
            Controls.Add(lblCargo);
            Controls.Add(lblSexo);
            Controls.Add(lblFechaNacimiento);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Controls.Add(txtTelefono);
            Controls.Add(lblTelefono);
            Controls.Add(txtApellidos);
            Controls.Add(lblApellidos);
            Controls.Add(txtNombres);
            Controls.Add(lblNombres);
            Controls.Add(lblTitulo);
            Name = "EmpleadosMan03";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Actualizar empleado";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtUbigeoId;
        private Label lblUbigeoId;
        private TextBox txtDireccion;
        private Label lblDireccion;
        private DateTimePicker dtpFechaContratacion;
        private Label lblFechaContratacion;
        private TextBox txtDni;
        private Label lblDNI;
        private Button btnCancelar;
        private Button btnGuardar;
        private ComboBox cboCargo;
        private ComboBox cboSexo;
        private DateTimePicker dtpFechaNacimiento;
        private Label lblCargo;
        private Label lblSexo;
        private Label lblFechaNacimiento;
        private TextBox txtEmail;
        private Label lblEmail;
        private TextBox txtTelefono;
        private Label lblTelefono;
        private TextBox txtApellidos;
        private Label lblApellidos;
        private TextBox txtNombres;
        private Label lblNombres;
        private Label lblTitulo;
    }
}