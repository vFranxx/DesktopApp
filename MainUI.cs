using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.CodeDom.Compiler;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TP5
{
    public partial class MainUI : Form
    {
        private readonly string Username;
        private readonly string Password;
        private readonly string Database;
        private readonly string SQLConnectionString;

        private const string ConnectionStringTemplate = "Data Source=DESKTOP-UJR9NPC\\SQLEXPRESS;Initial Catalog={0};Integrated Security=False;packet size=4096;UID={1};PWD={2}";

        public MainUI(string user, string pass, string db)
        {
            InitializeComponent();
            /*Username = user;
            Password = pass;
            Database = db;*/

            Username = LogInActual.Usuario;
            Password = LogInActual.Contraseña;
            Database = LogInActual.DB;

            // Construir la cadena de conexión usando la plantilla           {0}  -    {1}   -   {2}
            SQLConnectionString = string.Format(ConnectionStringTemplate, Database, Username, Password);

            LogInActual.Usuario = "";
            LogInActual.Contraseña = "";
            LogInActual.DB = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (TextCmd.Text == "")
                {
                    // Mostrar msj en un label de información 
                    LabelInfo.Text = "Debe ingresar un comando SQL para ejecutar";
                    LabelInfo.ForeColor = Color.Red;
                    return;
                }

                // Conexion SQL Server
                var LocalCNX = new SqlConnection(SQLConnectionString);

                // Actualizar label de información
                LabelInfo.Text = LocalCNX.ToString();
                LabelInfo.Refresh();

                // Abro la conexion
                LocalCNX.Open();

                LabelInfo.Text = "Conexión Exitosa!!!";
                LabelInfo.ForeColor = Color.Green;

                // Ejecutar el comando
                var LocalCMD = new SqlCommand(TextCmd.Text, LocalCNX);

                // Si el comando es un SELECT entonces retorna los datos en una grilla
                if (TextCmd.Text.ToUpper().Contains("SELECT"))
                {
                    // Defino el Data Adapter donde va a ejecutar la SQL(select)
                    var LocalDA = new SqlDataAdapter(LocalCMD);

                    // Paso el resultado a un Data Table
                    var LocalDT = new DataTable();
                    LocalDA.Fill(LocalDT);

                    // Asocio los datos a la grilla
                    Grid.DataSource = LocalDT;

                    LabelInfo.Text = "Registros recuperados: " + LocalDT.Rows.Count;

                    // Personalizo la grilla
                    Grid.AllowUserToAddRows = false;
                    Grid.AllowUserToDeleteRows = false;
                    Grid.ReadOnly = true;
                }
                else
                {
                    // Ejecuta el comando
                    LabelInfo.Text = "Resultado del comando SQL <Filas Afectadas>: " + LocalCMD.ExecuteNonQuery(); ;
                }

                LocalCNX.Close();
            }
            catch (Exception ex)
            {
                LabelInfo.Text = "Error: " + ex.Message;
                LabelInfo.ForeColor = Color.Red;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var LocalForm = new CRUD_Sucursales(SQLConnectionString);
            LocalForm.Show(this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var LocalForm = new CRUD_Clientes(SQLConnectionString);
            LocalForm.Show(this);
        }

        private void Filters_Click(object sender, EventArgs e)
        {
            var LocalForm = new Filters_page(SQLConnectionString);
            LocalForm.Show(this);
        }
    }
}
