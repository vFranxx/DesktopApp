namespace TP5
{
    partial class Filters_page
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
            Fechas = new Button();
            dateTimePicker1 = new DateTimePicker();
            dateTimePicker2 = new DateTimePicker();
            SuspendLayout();
            // 
            // Fechas
            // 
            Fechas.Location = new Point(12, 12);
            Fechas.Name = "Fechas";
            Fechas.Size = new Size(75, 23);
            Fechas.TabIndex = 0;
            Fechas.Text = "Fechas";
            Fechas.UseVisualStyleBackColor = true;
            Fechas.Click += Fechas_Click;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(93, 12);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(170, 23);
            dateTimePicker1.TabIndex = 1;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(93, 41);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(170, 23);
            dateTimePicker2.TabIndex = 2;
            // 
            // Filters_page
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(275, 76);
            Controls.Add(dateTimePicker2);
            Controls.Add(dateTimePicker1);
            Controls.Add(Fechas);
            Name = "Filters_page";
            Text = "Filtros";
            ResumeLayout(false);
        }

        #endregion

        private Button Fechas;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
    }
}