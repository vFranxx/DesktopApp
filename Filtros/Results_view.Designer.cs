namespace TP5
{
    partial class Results_view
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
            GrillaResultados = new DataGridView();
            button1 = new Button();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)GrillaResultados).BeginInit();
            SuspendLayout();
            // 
            // GrillaResultados
            // 
            GrillaResultados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GrillaResultados.Location = new Point(12, 12);
            GrillaResultados.Name = "GrillaResultados";
            GrillaResultados.Size = new Size(776, 426);
            GrillaResultados.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(12, 444);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 1;
            button1.Text = "Exportar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(713, 444);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 2;
            button2.Text = "Salir";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Results_view
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(796, 473);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(GrillaResultados);
            Name = "Results_view";
            Text = "Resultados";
            ((System.ComponentModel.ISupportInitialize)GrillaResultados).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView GrillaResultados;
        private Button button1;
        private Button button2;
    }
}