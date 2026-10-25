namespace GestionReserva_GUI
{
    partial class ReservasMan03
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
            lbl1 = new Label();
            lbl2 = new Label();
            lbl3 = new Label();
            lbl4 = new Label();
            lbl5 = new Label();
            lbl6 = new Label();
            lbl7 = new Label();
            lbl8 = new Label();
            lbl9 = new Label();
            cboCliente = new ComboBox();
            dtpFechaReserva = new DateTimePicker();
            dtpHoraReserva = new DateTimePicker();
            nudNumeroPersonas = new NumericUpDown();
            cboMesa = new ComboBox();
            cboTurno = new ComboBox();
            cboEstadoReserva = new ComboBox();
            cboEmpleado = new ComboBox();
            txtObservaciones = new TextBox();
            btnActualizar = new Button();
            btnCancelar = new Button();
            ((System.ComponentModel.ISupportInitialize)nudNumeroPersonas).BeginInit();
            SuspendLayout();
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(305, 12);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(176, 28);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Actualizar Reserva";
            //
            // lbl1
            //
            lbl1.AutoSize = true;
            lbl1.Location = new Point(34, 72);
            lbl1.Name = "lbl1";
            lbl1.Size = new Size(58, 20);
            lbl1.TabIndex = 1;
            lbl1.Text = "Cliente:";
            //
            // lbl2
            //
            lbl2.AutoSize = true;
            lbl2.Location = new Point(34, 125);
            lbl2.Name = "lbl2";
            lbl2.Size = new Size(50, 20);
            lbl2.TabIndex = 2;
            lbl2.Text = "Fecha:";
            //
            // lbl3
            //
            lbl3.AutoSize = true;
            lbl3.Location = new Point(34, 178);
            lbl3.Name = "lbl3";
            lbl3.Size = new Size(45, 20);
            lbl3.TabIndex = 3;
            lbl3.Text = "Hora:";
            //
            // lbl4
            //
            lbl4.AutoSize = true;
            lbl4.Location = new Point(34, 231);
            lbl4.Name = "lbl4";
            lbl4.Size = new Size(151, 20);
            lbl4.TabIndex = 4;
            lbl4.Text = "Número de personas:";
            //
            // lbl5
            //
            lbl5.AutoSize = true;
            lbl5.Location = new Point(34, 284);
            lbl5.Name = "lbl5";
            lbl5.Size = new Size(45, 20);
            lbl5.TabIndex = 5;
            lbl5.Text = "Mesa:";
            //
            // lbl6
            //
            lbl6.AutoSize = true;
            lbl6.Location = new Point(34, 337);
            lbl6.Name = "lbl6";
            lbl6.Size = new Size(48, 20);
            lbl6.TabIndex = 6;
            lbl6.Text = "Turno:";
            //
            // lbl7
            //
            lbl7.AutoSize = true;
            lbl7.Location = new Point(34, 390);
            lbl7.Name = "lbl7";
            lbl7.Size = new Size(152, 20);
            lbl7.TabIndex = 7;
            lbl7.Text = "Estado de la reserva:";
            //
            // lbl8
            //
            lbl8.AutoSize = true;
            lbl8.Location = new Point(34, 443);
            lbl8.Name = "lbl8";
            lbl8.Size = new Size(75, 20);
            lbl8.TabIndex = 8;
            lbl8.Text = "Empleado:";
            //
            // lbl9
            //
            lbl9.AutoSize = true;
            lbl9.Location = new Point(34, 496);
            lbl9.Name = "lbl9";
            lbl9.Size = new Size(108, 20);
            lbl9.TabIndex = 9;
            lbl9.Text = "Observaciones:";
            //
            // cboCliente
            //
            cboCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCliente.FormattingEnabled = true;
            cboCliente.Location = new Point(226, 69);
            cboCliente.Name = "cboCliente";
            cboCliente.Size = new Size(400, 28);
            cboCliente.TabIndex = 10;
            //
            // dtpFechaReserva
            //
            dtpFechaReserva.CustomFormat = "dd/MM/yyyy";
            dtpFechaReserva.Format = DateTimePickerFormat.Custom;
            dtpFechaReserva.Location = new Point(226, 122);
            dtpFechaReserva.Name = "dtpFechaReserva";
            dtpFechaReserva.Size = new Size(150, 27);
            dtpFechaReserva.TabIndex = 11;
            //
            // dtpHoraReserva
            //
            dtpHoraReserva.CustomFormat = "HH:mm";
            dtpHoraReserva.Format = DateTimePickerFormat.Custom;
            dtpHoraReserva.Location = new Point(226, 175);
            dtpHoraReserva.Name = "dtpHoraReserva";
            dtpHoraReserva.ShowUpDown = true;
            dtpHoraReserva.Size = new Size(93, 27);
            dtpHoraReserva.TabIndex = 12;
            //
            // nudNumeroPersonas
            //
            nudNumeroPersonas.Location = new Point(226, 229);
            nudNumeroPersonas.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            nudNumeroPersonas.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudNumeroPersonas.Name = "nudNumeroPersonas";
            nudNumeroPersonas.Size = new Size(93, 27);
            nudNumeroPersonas.TabIndex = 13;
            nudNumeroPersonas.Value = new decimal(new int[] { 1, 0, 0, 0 });
            //
            // cboMesa
            //
            cboMesa.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMesa.FormattingEnabled = true;
            cboMesa.Location = new Point(226, 281);
            cboMesa.Name = "cboMesa";
            cboMesa.Size = new Size(400, 28);
            cboMesa.TabIndex = 14;
            //
            // cboTurno
            //
            cboTurno.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTurno.FormattingEnabled = true;
            cboTurno.Location = new Point(226, 334);
            cboTurno.Name = "cboTurno";
            cboTurno.Size = new Size(400, 28);
            cboTurno.TabIndex = 15;
            //
            // cboEstadoReserva
            //
            cboEstadoReserva.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEstadoReserva.FormattingEnabled = true;
            cboEstadoReserva.Location = new Point(226, 387);
            cboEstadoReserva.Name = "cboEstadoReserva";
            cboEstadoReserva.Size = new Size(400, 28);
            cboEstadoReserva.TabIndex = 16;
            //
            // cboEmpleado
            //
            cboEmpleado.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEmpleado.FormattingEnabled = true;
            cboEmpleado.Location = new Point(226, 440);
            cboEmpleado.Name = "cboEmpleado";
            cboEmpleado.Size = new Size(400, 28);
            cboEmpleado.TabIndex = 17;
            //
            // txtObservaciones
            //
            txtObservaciones.Location = new Point(226, 493);
            txtObservaciones.MaxLength = 300;
            txtObservaciones.Multiline = true;
            txtObservaciones.Name = "txtObservaciones";
            txtObservaciones.ScrollBars = ScrollBars.Vertical;
            txtObservaciones.Size = new Size(532, 67);
            txtObservaciones.TabIndex = 18;
            //
            // btnActualizar
            //
            btnActualizar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnActualizar.Location = new Point(516, 590);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(110, 29);
            btnActualizar.TabIndex = 19;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            //
            // btnCancelar
            //
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(661, 590);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(110, 29);
            btnCancelar.TabIndex = 20;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            //
            // ReservasMan03
            //
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 640);
            Controls.Add(btnCancelar);
            Controls.Add(btnActualizar);
            Controls.Add(txtObservaciones);
            Controls.Add(cboEmpleado);
            Controls.Add(cboEstadoReserva);
            Controls.Add(cboTurno);
            Controls.Add(cboMesa);
            Controls.Add(nudNumeroPersonas);
            Controls.Add(dtpHoraReserva);
            Controls.Add(dtpFechaReserva);
            Controls.Add(cboCliente);
            Controls.Add(lbl9);
            Controls.Add(lbl8);
            Controls.Add(lbl7);
            Controls.Add(lbl6);
            Controls.Add(lbl5);
            Controls.Add(lbl4);
            Controls.Add(lbl3);
            Controls.Add(lbl2);
            Controls.Add(lbl1);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ReservasMan03";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Actualizar reserva";
            ((System.ComponentModel.ISupportInitialize)nudNumeroPersonas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lbl1;
        private Label lbl2;
        private Label lbl3;
        private Label lbl4;
        private Label lbl5;
        private Label lbl6;
        private Label lbl7;
        private Label lbl8;
        private Label lbl9;
        private ComboBox cboCliente;
        private DateTimePicker dtpFechaReserva;
        private DateTimePicker dtpHoraReserva;
        private NumericUpDown nudNumeroPersonas;
        private ComboBox cboMesa;
        private ComboBox cboTurno;
        private ComboBox cboEstadoReserva;
        private ComboBox cboEmpleado;
        private TextBox txtObservaciones;
        private Button btnActualizar;
        private Button btnCancelar;
    }
}
