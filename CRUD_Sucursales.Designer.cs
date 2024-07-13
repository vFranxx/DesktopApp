namespace TP5
{
    partial class CRUD_Sucursales
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
            BackBtn = new Button();
            DeleteBtn = new Button();
            SaveBtn = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            comboBox1 = new ComboBox();
            TxtBoxCP = new TextBox();
            TxtBoxLocalidad = new TextBox();
            TxtBoxPartido = new TextBox();
            TxtBoxDomicilio = new TextBox();
            SuspendLayout();
            // 
            // BackBtn
            // 
            BackBtn.Location = new Point(713, 165);
            BackBtn.Name = "BackBtn";
            BackBtn.Size = new Size(75, 23);
            BackBtn.TabIndex = 0;
            BackBtn.Text = "Salir";
            BackBtn.UseVisualStyleBackColor = true;
            BackBtn.Click += BackBtn_Click;
            // 
            // DeleteBtn
            // 
            DeleteBtn.Location = new Point(632, 165);
            DeleteBtn.Name = "DeleteBtn";
            DeleteBtn.Size = new Size(75, 23);
            DeleteBtn.TabIndex = 2;
            DeleteBtn.Text = "Borrar";
            DeleteBtn.UseVisualStyleBackColor = true;
            DeleteBtn.Click += DeleteBtn_Click;
            // 
            // SaveBtn
            // 
            SaveBtn.Location = new Point(551, 165);
            SaveBtn.Name = "SaveBtn";
            SaveBtn.Size = new Size(75, 23);
            SaveBtn.TabIndex = 3;
            SaveBtn.Text = "Guardar";
            SaveBtn.UseVisualStyleBackColor = true;
            SaveBtn.Click += SaveBtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(46, 17);
            label1.Name = "label1";
            label1.Size = new Size(25, 15);
            label1.TabIndex = 4;
            label1.Text = "CP:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 46);
            label2.Name = "label2";
            label2.Size = new Size(61, 15);
            label2.TabIndex = 5;
            label2.Text = "Localidad:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(23, 75);
            label3.Name = "label3";
            label3.Size = new Size(48, 15);
            label3.TabIndex = 6;
            label3.Text = "Partido:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(14, 107);
            label4.Name = "label4";
            label4.Size = new Size(59, 15);
            label4.TabIndex = 7;
            label4.Text = "Provincia:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(13, 136);
            label5.Name = "label5";
            label5.Size = new Size(60, 15);
            label5.TabIndex = 8;
            label5.Text = "Dirección:";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "BUENOS AIRES", "CATAMARCA", "CHACO", "CHUBUT", "CÓRDOBA", "CORRIENTES", "ENTRE RÍOS", "FORMOSA", "JUJUY", "LA PAMPA", "LA RIOJA", "MENDOZA", "MISIONES", "NEUQUÉN", "RÍO NEGRO", "SALTA", "SAN JUAN", "SAN LUIS", "SANTA CRUZ", "SANTA FE", "SANTIAGO DEL ESTERO", "TIERRA DEL FUEGO", "TUCUMÁN" });
            comboBox1.Location = new Point(79, 104);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(218, 23);
            comboBox1.TabIndex = 9;
            // 
            // TxtBoxCP
            // 
            TxtBoxCP.Location = new Point(79, 14);
            TxtBoxCP.Name = "TxtBoxCP";
            TxtBoxCP.Size = new Size(100, 23);
            TxtBoxCP.TabIndex = 10;
            TxtBoxCP.TextChanged += TxtBoxCP_TextChanged;
            // 
            // TxtBoxLocalidad
            // 
            TxtBoxLocalidad.Location = new Point(79, 43);
            TxtBoxLocalidad.Name = "TxtBoxLocalidad";
            TxtBoxLocalidad.Size = new Size(218, 23);
            TxtBoxLocalidad.TabIndex = 11;
            // 
            // TxtBoxPartido
            // 
            TxtBoxPartido.Location = new Point(79, 72);
            TxtBoxPartido.Name = "TxtBoxPartido";
            TxtBoxPartido.Size = new Size(218, 23);
            TxtBoxPartido.TabIndex = 12;
            // 
            // TxtBoxDomicilio
            // 
            TxtBoxDomicilio.Location = new Point(79, 133);
            TxtBoxDomicilio.Name = "TxtBoxDomicilio";
            TxtBoxDomicilio.Size = new Size(628, 23);
            TxtBoxDomicilio.TabIndex = 13;
            // 
            // CRUD_Sucursales
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 194);
            Controls.Add(TxtBoxDomicilio);
            Controls.Add(TxtBoxPartido);
            Controls.Add(TxtBoxLocalidad);
            Controls.Add(TxtBoxCP);
            Controls.Add(comboBox1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(SaveBtn);
            Controls.Add(DeleteBtn);
            Controls.Add(BackBtn);
            Name = "CRUD_Sucursales";
            Text = "Sucursales";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BackBtn;
        private Button DeleteBtn;
        private Button SaveBtn;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private ComboBox comboBox1;
        private TextBox TxtBoxCP;
        private TextBox TxtBoxLocalidad;
        private TextBox TxtBoxPartido;
        private TextBox TxtBoxDomicilio;
    }
}