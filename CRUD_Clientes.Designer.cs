namespace TP5
{
    partial class CRUD_Clientes
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
            Label1 = new Label();
            Label2 = new Label();
            Label3 = new Label();
            Label4 = new Label();
            Label5 = new Label();
            Label6 = new Label();
            TxtCode = new TextBox();
            TxtRS = new TextBox();
            TxtDomicilio = new TextBox();
            TxtLocalidad = new TextBox();
            TxtCUIT = new TextBox();
            BackBtn = new Button();
            SaveBtn = new Button();
            LblFecha = new Label();
            DeleteBtn = new Button();
            GrillaClientes = new DataGridView();
            comboBox1 = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)GrillaClientes).BeginInit();
            SuspendLayout();
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Location = new Point(35, 15);
            Label1.Name = "Label1";
            Label1.Size = new Size(49, 15);
            Label1.TabIndex = 0;
            Label1.Text = "Codigo:";
            // 
            // Label2
            // 
            Label2.AutoSize = true;
            Label2.Location = new Point(8, 73);
            Label2.Name = "Label2";
            Label2.Size = new Size(76, 15);
            Label2.TabIndex = 1;
            Label2.Text = "Razón Social:";
            // 
            // Label3
            // 
            Label3.AutoSize = true;
            Label3.Location = new Point(23, 102);
            Label3.Name = "Label3";
            Label3.Size = new Size(61, 15);
            Label3.TabIndex = 2;
            Label3.Text = "Domicilio:";
            // 
            // Label4
            // 
            Label4.AutoSize = true;
            Label4.Location = new Point(198, 134);
            Label4.Name = "Label4";
            Label4.Size = new Size(61, 15);
            Label4.TabIndex = 3;
            Label4.Text = "Localidad:";
            // 
            // Label5
            // 
            Label5.AutoSize = true;
            Label5.Location = new Point(59, 134);
            Label5.Name = "Label5";
            Label5.Size = new Size(25, 15);
            Label5.TabIndex = 4;
            Label5.Text = "CP:";
            // 
            // Label6
            // 
            Label6.AutoSize = true;
            Label6.Location = new Point(49, 44);
            Label6.Name = "Label6";
            Label6.Size = new Size(35, 15);
            Label6.TabIndex = 5;
            Label6.Text = "CUIT:";
            // 
            // TxtCode
            // 
            TxtCode.Location = new Point(90, 12);
            TxtCode.Name = "TxtCode";
            TxtCode.Size = new Size(57, 23);
            TxtCode.TabIndex = 6;
            TxtCode.TextChanged += TxtCode_TextChanged;
            // 
            // TxtRS
            // 
            TxtRS.Location = new Point(90, 70);
            TxtRS.Name = "TxtRS";
            TxtRS.Size = new Size(367, 23);
            TxtRS.TabIndex = 7;
            TxtRS.TextChanged += TxtRS_TextChanged;
            // 
            // TxtDomicilio
            // 
            TxtDomicilio.Location = new Point(90, 99);
            TxtDomicilio.Name = "TxtDomicilio";
            TxtDomicilio.Size = new Size(679, 23);
            TxtDomicilio.TabIndex = 8;
            // 
            // TxtLocalidad
            // 
            TxtLocalidad.Location = new Point(265, 131);
            TxtLocalidad.Name = "TxtLocalidad";
            TxtLocalidad.ReadOnly = true;
            TxtLocalidad.Size = new Size(244, 23);
            TxtLocalidad.TabIndex = 9;
            // 
            // TxtCUIT
            // 
            TxtCUIT.Location = new Point(90, 41);
            TxtCUIT.Name = "TxtCUIT";
            TxtCUIT.Size = new Size(124, 23);
            TxtCUIT.TabIndex = 11;
            // 
            // BackBtn
            // 
            BackBtn.Location = new Point(693, 165);
            BackBtn.Name = "BackBtn";
            BackBtn.Size = new Size(75, 23);
            BackBtn.TabIndex = 12;
            BackBtn.Text = "Salir";
            BackBtn.UseVisualStyleBackColor = true;
            BackBtn.Click += BackBtn_Click;
            // 
            // SaveBtn
            // 
            SaveBtn.Location = new Point(531, 165);
            SaveBtn.Name = "SaveBtn";
            SaveBtn.Size = new Size(75, 23);
            SaveBtn.TabIndex = 13;
            SaveBtn.Text = "Guardar";
            SaveBtn.UseVisualStyleBackColor = true;
            SaveBtn.Click += SaveBtn_Click;
            // 
            // LblFecha
            // 
            LblFecha.AutoSize = true;
            LblFecha.Location = new Point(153, 15);
            LblFecha.Name = "LblFecha";
            LblFecha.Size = new Size(82, 15);
            LblFecha.TabIndex = 14;
            LblFecha.Text = "Fecha de alta: ";
            LblFecha.Visible = false;
            // 
            // DeleteBtn
            // 
            DeleteBtn.Location = new Point(612, 165);
            DeleteBtn.Name = "DeleteBtn";
            DeleteBtn.Size = new Size(75, 23);
            DeleteBtn.TabIndex = 15;
            DeleteBtn.Text = "Borrar";
            DeleteBtn.UseVisualStyleBackColor = true;
            DeleteBtn.Click += DeleteBtn_Click;
            // 
            // GrillaClientes
            // 
            GrillaClientes.AllowUserToAddRows = false;
            GrillaClientes.AllowUserToDeleteRows = false;
            GrillaClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GrillaClientes.Location = new Point(8, 204);
            GrillaClientes.Name = "GrillaClientes";
            GrillaClientes.ReadOnly = true;
            GrillaClientes.Size = new Size(761, 360);
            GrillaClientes.TabIndex = 16;
            GrillaClientes.CellDoubleClick += GrillaClientes_CellDoubleClick;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(90, 131);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(100, 23);
            comboBox1.TabIndex = 17;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // CRUD_Clientes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(780, 576);
            Controls.Add(comboBox1);
            Controls.Add(GrillaClientes);
            Controls.Add(DeleteBtn);
            Controls.Add(LblFecha);
            Controls.Add(SaveBtn);
            Controls.Add(BackBtn);
            Controls.Add(TxtCUIT);
            Controls.Add(TxtLocalidad);
            Controls.Add(TxtDomicilio);
            Controls.Add(TxtRS);
            Controls.Add(TxtCode);
            Controls.Add(Label6);
            Controls.Add(Label5);
            Controls.Add(Label4);
            Controls.Add(Label3);
            Controls.Add(Label2);
            Controls.Add(Label1);
            Name = "CRUD_Clientes";
            Text = "Clientes";
            Load += CRUD_Clientes_Load;
            ((System.ComponentModel.ISupportInitialize)GrillaClientes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Label1;
        private Label Label2;
        private Label Label3;
        private Label Label4;
        private Label Label5;
        private Label Label6;
        private TextBox TxtCode;
        private TextBox TxtRS;
        private TextBox TxtDomicilio;
        private TextBox TxtLocalidad;
        private TextBox TxtCUIT;
        private Button BackBtn;
        private Button SaveBtn;
        private Label LblFecha;
        private Button DeleteBtn;
        private DataGridView GrillaClientes;
        private ComboBox comboBox1;
    }
}