using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP5
{
    public partial class Results_view : Form
    {
        private DataTable datos; // Guardo referencia de lo que llegó

        public Results_view(DataTable datos)
        {
            InitializeComponent();
            this.datos = datos; // Copia
            GrillaResultados.DataSource = datos;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Abro cuadro de dialogo estándar de Windows
                SaveFileDialog File = new SaveFileDialog();
                File.Filter = "Archivos de texto (*.txt)|*.txt"; // Especifico que solo quiero que se muestren archivos txt
                File.Title = "Guardar como archivo de texto"; // Titulo del cuadro de dialogo
                File.ShowDialog();

                // Si selecciona un nombre valido
                if (File.FileName != "") 
                {
                    // Creo un streamwriter para escribir en el archivo seleccionado
                    using (StreamWriter sw = new StreamWriter(File.FileName))
                    {
                        // Escribo los encabezados de columna
                        foreach (DataGridViewColumn columna in GrillaResultados.Columns) 
                        {
                            sw.Write(columna.HeaderText + "\t"); // "\t" es un caracter de tabulación
                        }

                        sw.WriteLine(); // Salto una linea

                        // Escribo cada fila de los datos
                        foreach (DataRow fila in datos.Rows) 
                        {
                            foreach (var item in fila.ItemArray) 
                            {
                                sw.Write(item.ToString() + "\t");
                            }
                            sw.WriteLine(); // Salto de linea
                        }

                        MessageBox.Show("Datos exportados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
