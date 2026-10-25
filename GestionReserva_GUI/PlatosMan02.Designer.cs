namespace GestionReserva_GUI
{
    partial class PlatosMan02
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
            txtNombrePlato = new TextBox();
            txtDescripcion = new TextBox();
            cboCategoria = new ComboBox();
            nudTiempoPreparacion = new NumericUpDown();
            nudPrecioReferencial = new NumericUpDown();
            nudEstado = new NumericUpDown();
            chkDisponible = new CheckBox();
            btnGuardar = new Button();
            btnCancelar = new Button();
            ((System.ComponentModel.ISupportInitialize)nudTiempoPreparacion).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPrecioReferencial).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudEstado).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(301, 12);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(176, 28);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Registro de Platos";
            // 
            // lbl1
            // 
            lbl1.AutoSize = true;
            lbl1.Location = new Point(34, 72);
            lbl1.Name = "lbl1";
            lbl1.Size = new Size(131, 20);
            lbl1.TabIndex = 1;
            lbl1.Text = "Nombre del plato:";
            // 
            // lbl2
            // 
            lbl2.AutoSize = true;
            lbl2.Location = new Point(34, 125);
            lbl2.Name = "lbl2";
            lbl2.Size = new Size(90, 20);
            lbl2.TabIndex = 2;
            lbl2.Text = "Descripción:";
            // 
            // lbl3
            // 
            lbl3.AutoSize = true;
            lbl3.Location = new Point(34, 214);
            lbl3.Name = "lbl3";
            lbl3.Size = new Size(77, 20);
            lbl3.TabIndex = 3;
            lbl3.Text = "Categoría:";
            // 
            // lbl4
            // 
            lbl4.AutoSize = true;
            lbl4.Location = new Point(34, 268);
            lbl4.Name = "lbl4";
            lbl4.Size = new Size(169, 40);
            lbl4.TabIndex = 4;
            lbl4.Text = "Tiempo de preparación \r\n(minutos):";
            // 
            // lbl5
            // 
            lbl5.AutoSize = true;
            lbl5.Location = new Point(34, 335);
            lbl5.Name = "lbl5";
            lbl5.Size = new Size(84, 20);
            lbl5.TabIndex = 5;
            lbl5.Text = "Disponible:";
            // 
            // lbl6
            // 
            lbl6.AutoSize = true;
            lbl6.Location = new Point(34, 383);
            lbl6.Name = "lbl6";
            lbl6.Size = new Size(127, 20);
            lbl6.TabIndex = 6;
            lbl6.Text = "Precio referencial:";
            // 
            // lbl7
            // 
            lbl7.AutoSize = true;
            lbl7.Location = new Point(34, 429);
            lbl7.Name = "lbl7";
            lbl7.Size = new Size(57, 20);
            lbl7.TabIndex = 7;
            lbl7.Text = "Estado:";
            // 
            // txtNombrePlato
            // 
            txtNombrePlato.Location = new Point(226, 70);
            txtNombrePlato.MaxLength = 100;
            txtNombrePlato.Name = "txtNombrePlato";
            txtNombrePlato.Size = new Size(532, 27);
            txtNombrePlato.TabIndex = 8;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(226, 122);
            txtDescripcion.MaxLength = 300;
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.ScrollBars = ScrollBars.Vertical;
            txtDescripcion.Size = new Size(532, 67);
            txtDescripcion.TabIndex = 9;
            // 
            // cboCategoria
            // 
            cboCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCategoria.FormattingEnabled = true;
            cboCategoria.Location = new Point(226, 214);
            cboCategoria.Name = "cboCategoria";
            cboCategoria.Size = new Size(305, 28);
            cboCategoria.TabIndex = 10;
            // 
            // nudTiempoPreparacion
            // 
            nudTiempoPreparacion.Location = new Point(226, 268);
            nudTiempoPreparacion.Maximum = new decimal(new int[] { 1440, 0, 0, 0 });
            nudTiempoPreparacion.Name = "nudTiempoPreparacion";
            nudTiempoPreparacion.Size = new Size(93, 27);
            nudTiempoPreparacion.TabIndex = 11;
            // 
            // nudPrecioReferencial
            // 
            nudPrecioReferencial.DecimalPlaces = 2;
            nudPrecioReferencial.Location = new Point(226, 380);
            nudPrecioReferencial.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            nudPrecioReferencial.Name = "nudPrecioReferencial";
            nudPrecioReferencial.Size = new Size(172, 27);
            nudPrecioReferencial.TabIndex = 12;
            // 
            // nudEstado
            // 
            nudEstado.Location = new Point(226, 427);
            nudEstado.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nudEstado.Name = "nudEstado";
            nudEstado.Size = new Size(172, 27);
            nudEstado.TabIndex = 13;
            nudEstado.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // chkDisponible
            // 
            chkDisponible.AutoSize = true;
            chkDisponible.Checked = true;
            chkDisponible.CheckState = CheckState.Checked;
            chkDisponible.Location = new Point(226, 333);
            chkDisponible.Name = "chkDisponible";
            chkDisponible.Size = new Size(193, 24);
            chkDisponible.TabIndex = 14;
            chkDisponible.Text = "Disponible para la venta";
            chkDisponible.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            btnGuardar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnGuardar.Location = new Point(516, 476);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(110, 29);
            btnGuardar.TabIndex = 15;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(661, 476);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(110, 29);
            btnCancelar.TabIndex = 16;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // PlatosMan02
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 527);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(chkDisponible);
            Controls.Add(nudEstado);
            Controls.Add(nudPrecioReferencial);
            Controls.Add(nudTiempoPreparacion);
            Controls.Add(cboCategoria);
            Controls.Add(txtDescripcion);
            Controls.Add(txtNombrePlato);
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
            Name = "PlatosMan02";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registro de Plato";
            ((System.ComponentModel.ISupportInitialize)nudTiempoPreparacion).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudPrecioReferencial).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudEstado).EndInit();
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
        private TextBox txtNombrePlato;
        private TextBox txtDescripcion;
        private ComboBox cboCategoria;
        private NumericUpDown nudTiempoPreparacion;
        private NumericUpDown nudPrecioReferencial;
        private NumericUpDown nudEstado;
        private CheckBox chkDisponible;
        private Button btnGuardar;
        private Button btnCancelar;
    }
}