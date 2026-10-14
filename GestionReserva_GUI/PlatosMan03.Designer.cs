namespace GestionReserva_GUI
{
    partial class PlatosMan03
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
            btnCancelar = new Button();
            btnActualizar = new Button();
            chkDisponible = new CheckBox();
            nudEstado = new NumericUpDown();
            nudPrecioReferencial = new NumericUpDown();
            nudTiempoPreparacion = new NumericUpDown();
            cboCategoria = new ComboBox();
            txtDescripcion = new TextBox();
            txtNombrePlato = new TextBox();
            lbl7 = new Label();
            lbl6 = new Label();
            lbl5 = new Label();
            lbl4 = new Label();
            lbl3 = new Label();
            lbl2 = new Label();
            lbl1 = new Label();
            lblTitulo = new Label();
            ((System.ComponentModel.ISupportInitialize)nudEstado).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPrecioReferencial).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudTiempoPreparacion).BeginInit();
            SuspendLayout();
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(663, 478);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(110, 29);
            btnCancelar.TabIndex = 32;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnActualizar.Location = new Point(518, 478);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(110, 29);
            btnActualizar.TabIndex = 31;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // chkDisponible
            // 
            chkDisponible.AutoSize = true;
            chkDisponible.Checked = true;
            chkDisponible.CheckState = CheckState.Checked;
            chkDisponible.Location = new Point(228, 335);
            chkDisponible.Name = "chkDisponible";
            chkDisponible.Size = new Size(193, 24);
            chkDisponible.TabIndex = 30;
            chkDisponible.Text = "Disponible para la venta";
            chkDisponible.UseVisualStyleBackColor = true;
            // 
            // nudEstado
            // 
            nudEstado.Location = new Point(228, 429);
            nudEstado.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nudEstado.Name = "nudEstado";
            nudEstado.Size = new Size(172, 27);
            nudEstado.TabIndex = 29;
            nudEstado.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // nudPrecioReferencial
            // 
            nudPrecioReferencial.DecimalPlaces = 2;
            nudPrecioReferencial.Location = new Point(228, 382);
            nudPrecioReferencial.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            nudPrecioReferencial.Name = "nudPrecioReferencial";
            nudPrecioReferencial.Size = new Size(172, 27);
            nudPrecioReferencial.TabIndex = 28;
            // 
            // nudTiempoPreparacion
            // 
            nudTiempoPreparacion.Location = new Point(228, 270);
            nudTiempoPreparacion.Maximum = new decimal(new int[] { 1440, 0, 0, 0 });
            nudTiempoPreparacion.Name = "nudTiempoPreparacion";
            nudTiempoPreparacion.Size = new Size(93, 27);
            nudTiempoPreparacion.TabIndex = 27;
            // 
            // cboCategoria
            // 
            cboCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCategoria.FormattingEnabled = true;
            cboCategoria.Location = new Point(228, 216);
            cboCategoria.Name = "cboCategoria";
            cboCategoria.Size = new Size(305, 28);
            cboCategoria.TabIndex = 26;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(228, 124);
            txtDescripcion.MaxLength = 300;
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.ScrollBars = ScrollBars.Vertical;
            txtDescripcion.Size = new Size(532, 67);
            txtDescripcion.TabIndex = 25;
            // 
            // txtNombrePlato
            // 
            txtNombrePlato.Location = new Point(228, 72);
            txtNombrePlato.MaxLength = 100;
            txtNombrePlato.Name = "txtNombrePlato";
            txtNombrePlato.Size = new Size(532, 27);
            txtNombrePlato.TabIndex = 24;
            // 
            // lbl7
            // 
            lbl7.AutoSize = true;
            lbl7.Location = new Point(36, 431);
            lbl7.Name = "lbl7";
            lbl7.Size = new Size(57, 20);
            lbl7.TabIndex = 23;
            lbl7.Text = "Estado:";
            // 
            // lbl6
            // 
            lbl6.AutoSize = true;
            lbl6.Location = new Point(36, 385);
            lbl6.Name = "lbl6";
            lbl6.Size = new Size(127, 20);
            lbl6.TabIndex = 22;
            lbl6.Text = "Precio referencial:";
            // 
            // lbl5
            // 
            lbl5.AutoSize = true;
            lbl5.Location = new Point(36, 337);
            lbl5.Name = "lbl5";
            lbl5.Size = new Size(84, 20);
            lbl5.TabIndex = 21;
            lbl5.Text = "Disponible:";
            // 
            // lbl4
            // 
            lbl4.AutoSize = true;
            lbl4.Location = new Point(36, 270);
            lbl4.Name = "lbl4";
            lbl4.Size = new Size(169, 40);
            lbl4.TabIndex = 20;
            lbl4.Text = "Tiempo de preparación \r\n(minutos):";
            // 
            // lbl3
            // 
            lbl3.AutoSize = true;
            lbl3.Location = new Point(36, 216);
            lbl3.Name = "lbl3";
            lbl3.Size = new Size(77, 20);
            lbl3.TabIndex = 19;
            lbl3.Text = "Categoría:";
            // 
            // lbl2
            // 
            lbl2.AutoSize = true;
            lbl2.Location = new Point(36, 127);
            lbl2.Name = "lbl2";
            lbl2.Size = new Size(90, 20);
            lbl2.TabIndex = 18;
            lbl2.Text = "Descripción:";
            // 
            // lbl1
            // 
            lbl1.AutoSize = true;
            lbl1.Location = new Point(36, 74);
            lbl1.Name = "lbl1";
            lbl1.Size = new Size(131, 20);
            lbl1.TabIndex = 17;
            lbl1.Text = "Nombre del plato:";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(312, 21);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(151, 28);
            lblTitulo.TabIndex = 33;
            lblTitulo.Text = "Actualizar Plato";
            // 
            // PlatosMan03
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 522);
            Controls.Add(lblTitulo);
            Controls.Add(btnCancelar);
            Controls.Add(btnActualizar);
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
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PlatosMan03";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Actualizar plato";
            ((System.ComponentModel.ISupportInitialize)nudEstado).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudPrecioReferencial).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudTiempoPreparacion).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancelar;
        private Button btnActualizar;
        private CheckBox chkDisponible;
        private NumericUpDown nudEstado;
        private NumericUpDown nudPrecioReferencial;
        private NumericUpDown nudTiempoPreparacion;
        private ComboBox cboCategoria;
        private TextBox txtDescripcion;
        private TextBox txtNombrePlato;
        private Label lbl7;
        private Label lbl6;
        private Label lbl5;
        private Label lbl4;
        private Label lbl3;
        private Label lbl2;
        private Label lbl1;
        private Label lblTitulo;
    }
}