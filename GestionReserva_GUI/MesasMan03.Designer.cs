namespace GestionReserva_GUI
{
    partial class MesasMan03
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
            nudNumeroMesa = new NumericUpDown();
            nudCapacidad = new NumericUpDown();
            cboZona = new ComboBox();
            cboEstadoMesa = new ComboBox();
            btnActualizar = new Button();
            btnCancelar = new Button();
            ((System.ComponentModel.ISupportInitialize)nudNumeroMesa).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudCapacidad).BeginInit();
            SuspendLayout();
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(312, 12);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(151, 28);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Actualizar Mesa";
            //
            // lbl1
            //
            lbl1.AutoSize = true;
            lbl1.Location = new Point(34, 72);
            lbl1.Name = "lbl1";
            lbl1.Size = new Size(124, 20);
            lbl1.TabIndex = 1;
            lbl1.Text = "Número de mesa:";
            //
            // lbl2
            //
            lbl2.AutoSize = true;
            lbl2.Location = new Point(34, 125);
            lbl2.Name = "lbl2";
            lbl2.Size = new Size(155, 20);
            lbl2.TabIndex = 2;
            lbl2.Text = "Capacidad (personas):";
            //
            // lbl3
            //
            lbl3.AutoSize = true;
            lbl3.Location = new Point(34, 178);
            lbl3.Name = "lbl3";
            lbl3.Size = new Size(45, 20);
            lbl3.TabIndex = 3;
            lbl3.Text = "Zona:";
            //
            // lbl4
            //
            lbl4.AutoSize = true;
            lbl4.Location = new Point(34, 231);
            lbl4.Name = "lbl4";
            lbl4.Size = new Size(131, 20);
            lbl4.TabIndex = 4;
            lbl4.Text = "Estado de la mesa:";
            //
            // nudNumeroMesa
            //
            nudNumeroMesa.Location = new Point(226, 70);
            nudNumeroMesa.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            nudNumeroMesa.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudNumeroMesa.Name = "nudNumeroMesa";
            nudNumeroMesa.Size = new Size(93, 27);
            nudNumeroMesa.TabIndex = 5;
            nudNumeroMesa.Value = new decimal(new int[] { 1, 0, 0, 0 });
            //
            // nudCapacidad
            //
            nudCapacidad.Location = new Point(226, 123);
            nudCapacidad.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            nudCapacidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudCapacidad.Name = "nudCapacidad";
            nudCapacidad.Size = new Size(93, 27);
            nudCapacidad.TabIndex = 6;
            nudCapacidad.Value = new decimal(new int[] { 1, 0, 0, 0 });
            //
            // cboZona
            //
            cboZona.DropDownStyle = ComboBoxStyle.DropDownList;
            cboZona.FormattingEnabled = true;
            cboZona.Location = new Point(226, 175);
            cboZona.Name = "cboZona";
            cboZona.Size = new Size(305, 28);
            cboZona.TabIndex = 7;
            //
            // cboEstadoMesa
            //
            cboEstadoMesa.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEstadoMesa.FormattingEnabled = true;
            cboEstadoMesa.Location = new Point(226, 228);
            cboEstadoMesa.Name = "cboEstadoMesa";
            cboEstadoMesa.Size = new Size(305, 28);
            cboEstadoMesa.TabIndex = 8;
            //
            // btnActualizar
            //
            btnActualizar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnActualizar.Location = new Point(516, 290);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(110, 29);
            btnActualizar.TabIndex = 9;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            //
            // btnCancelar
            //
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(661, 290);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(110, 29);
            btnCancelar.TabIndex = 10;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            //
            // MesasMan03
            //
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 340);
            Controls.Add(btnCancelar);
            Controls.Add(btnActualizar);
            Controls.Add(cboEstadoMesa);
            Controls.Add(cboZona);
            Controls.Add(nudCapacidad);
            Controls.Add(nudNumeroMesa);
            Controls.Add(lbl4);
            Controls.Add(lbl3);
            Controls.Add(lbl2);
            Controls.Add(lbl1);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MesasMan03";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Actualizar mesa";
            ((System.ComponentModel.ISupportInitialize)nudNumeroMesa).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudCapacidad).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lbl1;
        private Label lbl2;
        private Label lbl3;
        private Label lbl4;
        private NumericUpDown nudNumeroMesa;
        private NumericUpDown nudCapacidad;
        private ComboBox cboZona;
        private ComboBox cboEstadoMesa;
        private Button btnActualizar;
        private Button btnCancelar;
    }
}
