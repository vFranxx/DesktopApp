namespace TP5
{
    partial class MainUI
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            TextCmd = new TextBox();
            Grid = new DataGridView();
            LabelInfo = new Label();
            button2 = new Button();
            button3 = new Button();
            Filters = new Button();
            ((System.ComponentModel.ISupportInitialize)Grid).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(12, 12);
            button1.Name = "button1";
            button1.Size = new Size(118, 35);
            button1.TabIndex = 0;
            button1.Text = "Ejecutar comando";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // TextCmd
            // 
            TextCmd.Location = new Point(136, 19);
            TextCmd.Name = "TextCmd";
            TextCmd.Size = new Size(827, 23);
            TextCmd.TabIndex = 1;
            // 
            // Grid
            // 
            Grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Grid.Location = new Point(136, 85);
            Grid.Name = "Grid";
            Grid.Size = new Size(827, 572);
            Grid.TabIndex = 2;
            // 
            // LabelInfo
            // 
            LabelInfo.AutoSize = true;
            LabelInfo.Location = new Point(136, 57);
            LabelInfo.Name = "LabelInfo";
            LabelInfo.Size = new Size(37, 15);
            LabelInfo.TabIndex = 3;
            LabelInfo.Text = "Info...";
            // 
            // button2
            // 
            button2.Location = new Point(12, 85);
            button2.Name = "button2";
            button2.Size = new Size(118, 36);
            button2.TabIndex = 4;
            button2.Text = "ABM Sucursales";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(12, 127);
            button3.Name = "button3";
            button3.Size = new Size(118, 34);
            button3.TabIndex = 5;
            button3.Text = "ABM Clientes";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // Filters
            // 
            Filters.Location = new Point(12, 623);
            Filters.Name = "Filters";
            Filters.Size = new Size(118, 34);
            Filters.TabIndex = 6;
            Filters.Text = "Filtros";
            Filters.UseVisualStyleBackColor = true;
            Filters.Click += Filters_Click;
            // 
            // MainUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(975, 680);
            Controls.Add(Filters);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(LabelInfo);
            Controls.Add(Grid);
            Controls.Add(TextCmd);
            Controls.Add(button1);
            Name = "MainUI";
            Text = "Administración de la Base de Datos";
            ((System.ComponentModel.ISupportInitialize)Grid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox TextCmd;
        private DataGridView Grid;
        private Label LabelInfo;
        private Button button2;
        private Button button3;
        private Button Filters;
    }
}
