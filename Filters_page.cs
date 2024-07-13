using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP5
{
    public partial class Filters_page : Form
    {
        private readonly string SQLString;

        public Filters_page(string SQLStringConnection)
        {
            InitializeComponent();
            SQLString = SQLStringConnection;
        }

        private void Fechas_Click(object sender, EventArgs e)
        {
            DateTime fecha1 = dateTimePicker1.Value;
            DateTime fecha2 = dateTimePicker2.Value;

            string query = "SELECT * FROM dbo.CLIENTES ";
            query += "WHERE FECHA_ALTA BETWEEN @FechaInicio AND @FechaFin ";
            query += "ORDER BY FECHA_ALTA";

            try 
            { 
                using (var LocalCNX = new SqlConnection(SQLString))
                {
                    LocalCNX.Open();

                    using (var LocalCMD = new SqlCommand(query, LocalCNX))
                    {
                        LocalCMD.Parameters.AddWithValue("@FechaInicio", fecha1);
                        LocalCMD.Parameters.AddWithValue("@FechaFin", fecha2);

                        var LocalDA = new SqlDataAdapter(LocalCMD);
                        var LocalDT = new DataTable();

                        LocalDA.Fill(LocalDT);

                        var LocalForm = new Results_view(LocalDT);
                        LocalForm.Show(this);
                    }

                    LocalCNX.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar clientes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
